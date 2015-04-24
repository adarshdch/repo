
using System.Xml.Linq;

namespace SAB.Utility.Xml
{
	public static class XElementExtension
	{
		public static string AttributeValue(this XElement theElement, string theAttributeName)
		{
			return (string) theElement.Attribute(theAttributeName) ?? "";
		}
	}
}
