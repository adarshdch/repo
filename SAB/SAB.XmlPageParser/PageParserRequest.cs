

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

		public NameValueCollection Params { get; set; }

	}
}
