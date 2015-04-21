

namespace SAB.XmlPageParser
{
	public class PageParser
	{
		public PageParserResponse Parse(PageParserRequest theRequest)
		{
			var aResponse = new PageParserResponse()
			{
				Response = theRequest.PageXml
			};


			return aResponse;
		}
	}
}
