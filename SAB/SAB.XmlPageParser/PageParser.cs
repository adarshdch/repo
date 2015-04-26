

using System.Xml.Linq;
using SAB.XmlPageParser.Helper;

namespace SAB.XmlPageParser
{
	public class PageParser
	{
		public PageParserResponse Parse(PageParserRequest theRequest)
		{
			var aResponse = new PageParserResponse()
			{
				PageXDocument = XDocument.Parse(theRequest.PageXDocument, LoadOptions.None)
			};

			VariableParser.Parse(theRequest, aResponse);
			QueryProcessor.Parse(theRequest, aResponse);
			XsltProcessor.ApplyXslt(theRequest, aResponse);

			return aResponse;
		}
	}
}
