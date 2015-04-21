
using System.Linq;
using System.Net.Cache;
using System.Xml.Linq;
using System.Xml.XPath;

namespace SAB.XmlPageParser.Helper
{
	internal class VariableParser
	{
		public static void Parse(PageParserRequest theRequest, PageParserResponse theResponse)
		{
			var aVariableNodes = theResponse.PageXDocument.XPathSelectElements("/Form/Variables/Variable")
										.Concat(theResponse.PageXDocument.XPathSelectElements("/Report/Variables/Variable")).ToList();
			
			if (aVariableNodes.Any() == false)
				return;

			aVariableNodes.ForEach(theVariableNode => Parse(theVariableNode, theRequest));
		}

		protected static void Parse(XElement theVariableElement, PageParserRequest theRequest)
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
