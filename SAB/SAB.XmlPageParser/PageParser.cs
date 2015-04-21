

using SAB.XmlPageParser.Helper;

namespace SAB.XmlPageParser
{
	public class PageParser
	{
		public PageParserResponse Parse(PageParserRequest theRequest)
		{
			var aResponse = new PageParserResponse()
			{
				Response = theRequest.PageXDocument
			};

			VariableParser.Parse(theRequest, aResponse);


			return aResponse;
		}
	}
}
