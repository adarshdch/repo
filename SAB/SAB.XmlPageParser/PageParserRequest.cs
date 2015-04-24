

using System.Collections.Specialized;

namespace SAB.XmlPageParser
{
	public class PageParserRequest
	{
		public PageParserRequest()
		{
			Params = new NameValueCollection();
		}

		public string PageXDocument { get; set; }

		public string OrgCode { get; set; }

		public ExecutionStep Step { get; set; }

		public NameValueCollection Params { get; set; }

	}
}
