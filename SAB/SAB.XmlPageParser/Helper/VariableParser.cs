
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Xml.Linq;
using System.Xml.XPath;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using SAB.Utility.Xml;

namespace SAB.XmlPageParser.Helper
{
	internal class VariableParser
	{
		public static void Parse(PageParserRequest theRequest, PageParserResponse theResponse)
		{
			#region Calculate variable valus

			var aVariableNodes = theResponse.PageXDocument.XPathSelectElements("/Form/Variables/Variable")
										.Concat(theResponse.PageXDocument.XPathSelectElements("/Report/Variables/Variable")).ToList();

			if (aVariableNodes.Any() == false)
				return;

			aVariableNodes.ForEach(theVariableNode => ParseVariables(theVariableNode, theRequest));

			#endregion

			#region Replace variables with calculated values

			var aPageDocumentText = new StringBuilder(theResponse.PageXDocument.FirstNode.ToString());
			aVariableNodes.ForEach(theVariable =>
			{
				var aVariableKey = string.Format("[*{0}*]", theVariable.Attribute("key").Value);
				var aVariableValue = theVariable.Attribute("value").Value;
				aPageDocumentText.Replace(aVariableKey, aVariableValue);
			});

			#endregion

			#region Replace form variables with value

			var aFields = theResponse.PageXDocument.XPathSelectElements("/Form/HtmlForm//Field");
			aFields.ForEach(theField =>
			{
				//aPageDocumentText
				var aFieldName = theField.AttributeValue("sid");
				var aFieldValue = theField.AttributeValue("value");
				aPageDocumentText.Replace(string.Format("[*form.{0}*]", aFieldName), aFieldValue);
			});

			#endregion

			theResponse.PageXDocument.FirstNode.ReplaceWith(XElement.Parse(aPageDocumentText.ToString()));
		}

		protected static void ParseVariables(XElement theVariableElement, PageParserRequest theRequest)
		{
			var aVariableSource = theVariableElement.Attribute("source");

			if (aVariableSource == null || string.IsNullOrWhiteSpace(aVariableSource.Value))
				return;

			switch (aVariableSource.Value)
			{
				case "param":
					var aVariableValue = theRequest.Params[theVariableElement.Attribute("key").Value];
					theVariableElement.SetAttributeValue("value", aVariableValue);
					break;
				case "query":
					break;
				default:
					break;
			}
		}

	}
}
