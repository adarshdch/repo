

using System.Text;
using System.Xml.Linq;

namespace SAB.XmlPageParser
{
	public class PageParserResponse
	{
		public XDocument PageXDocument { get; set; }

		public StringBuilder Output { get; set; }
	}
}
