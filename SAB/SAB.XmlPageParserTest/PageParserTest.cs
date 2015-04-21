
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SAB.Utility;
using SAB.XmlPageParser;

namespace SAB.XmlPageParserTest
{
	[TestClass]
	public class PageParserTest
	{
		[TestMethod]
		public void ParseTest()
		{
			var aParse = new PageParser();
			var aRequest = new PageParserRequest()
			{
				PageXDocument = File.ReadAllText(@"C:\D\Git\repo\static\pages\master\Form.xml")
			};
			aRequest.Params["gid"] = "form";
			var aResponse = aParse.Parse(aRequest);

			File.WriteAllText(Path.Combine(UtilPath.TestOutputDirectory, "Form.xml"), aResponse.PageXDocument.ToString());
		}
	}
}
