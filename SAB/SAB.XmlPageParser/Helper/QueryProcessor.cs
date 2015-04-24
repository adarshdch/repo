
using System.IO;
using System.Xml.XPath;
using Microsoft.Practices.EnterpriseLibrary.Common.Utility;
using SAB.DAL.EntLib;
using SAB.Utility.Xml;

namespace SAB.XmlPageParser.Helper
{
	internal class QueryProcessor
	{
		public static void Parse(PageParserRequest theRequest, PageParserResponse theResponse)
		{
			//Execute current step query (SELECT/INSERT/UPDATE/DELETE)
			var aHtmlForm = theResponse.PageXDocument.XPathSelectElement("/Form/HtmlForm");

			//Get the appropriate query
			string aStepQuery;
			switch (theRequest.Step)
			{
				case ExecutionStep.Select:
					aStepQuery = aHtmlForm.AttributeValue("selectquery");
					var aDataSet = OrgDatabase.SelectQuery(theRequest.OrgCode, aStepQuery);


					var aTable = aDataSet.Tables[0];
					if (aTable == null || aTable.Rows == null || aTable.Rows.Count == 0)
					{
						throw new FileNotFoundException("Record not found!");
					}
					var aHtmlFormFields = aHtmlForm.Elements("Field");
					aHtmlFormFields.ForEach(theField => theField.SetAttributeValue("value", aTable.Rows[0][theField.Attribute("sid").Value]));
					break;
				case ExecutionStep.Insert:
					aStepQuery = aHtmlForm.AttributeValue("insertquery");
					OrgDatabase.InsertOrUpdateOrDeleteQuery(theRequest.OrgCode, aStepQuery);
					break;
				case ExecutionStep.Update:
					aStepQuery = aHtmlForm.AttributeValue("updatequery");
					OrgDatabase.InsertOrUpdateOrDeleteQuery(theRequest.OrgCode, aStepQuery);
					break;
				case ExecutionStep.Delete:
					aStepQuery = aHtmlForm.AttributeValue("deletequery");
					OrgDatabase.InsertOrUpdateOrDeleteQuery(theRequest.OrgCode, aStepQuery);
					break;
				default:
					break;
			}

			//Execute the query


		}
	}
}
