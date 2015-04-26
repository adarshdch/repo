
using System.Web.Mvc;
using SAB.XmlPageParser;

namespace SAB.Interface.Controllers
{
		public class PageController : Controller
		{

			[HttpGet]
			[ActionName("Html")]
			public string HtmlGet(string pagecode)
			{
				var aParse = new PageParser();
				var aRequest = new PageParserRequest()
				{
					OrgCode = "Master",
					Step = ExecutionStep.Select,
					OutputType = ContentType.FullHtml,
					PageXDocument = System.IO.File.ReadAllText(@"C:\D\Git\repo\static\pages\master\Form.xml"),
					Xslt = System.IO.File.ReadAllText(@"C:\D\Git\repo\static\stylesheets\master\v1\Dojo_Form.xslt")
				};
				aRequest.Params["gid"] = "form";
				var aResponse = aParse.Parse(aRequest);
				return aResponse.Output.ToString();
			}

			[HttpPost]
			[ActionName("Html")]
			public string HtmlPost(string pagecode)
			{
				return "Post";
			}

		}
}