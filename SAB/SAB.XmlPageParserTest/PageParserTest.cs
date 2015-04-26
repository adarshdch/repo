
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
				OrgCode = "Master",
				Step = ExecutionStep.Select,
				OutputType = ContentType.FullHtml,
				PageXDocument = File.ReadAllText(@"C:\D\Git\repo\static\pages\master\Form.xml"),
				Xslt = File.ReadAllText(@"C:\D\Git\repo\static\stylesheets\master\v1\Dojo_Form.xslt")
			};
			aRequest.Params["gid"] = "form";
			var aResponse = aParse.Parse(aRequest);

			File.WriteAllText(Path.Combine(UtilPath.TestOutputDirectory, "Form.html"), aResponse.Output.ToString());
		}
	}
}
