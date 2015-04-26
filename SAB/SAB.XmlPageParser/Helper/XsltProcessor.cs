
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Xsl;

namespace SAB.XmlPageParser.Helper
{
	internal class XsltProcessor
	{
		public static void ApplyXslt(PageParserRequest theRequest, PageParserResponse theResponse)
		{
			StringBuilder aOutput;
			using (var aXsltReader = new StringReader(theRequest.Xslt)) // xslInput is a string that contains xsl
			using (var aXmlReader = new StringReader(theRequest.PageXDocument)) // xmlInput is a string that contains xml
			{
				using (var aXslt = XmlReader.Create(aXsltReader))
				using (var aXml = XmlReader.Create(aXmlReader))
				{
					var aTransformer = new XslCompiledTransform(true);
					aTransformer.Load(aXslt);

					using (var aStringWriter = new StringWriter())
					using (var aOutputWriter = XmlWriter.Create(aStringWriter, aTransformer.OutputSettings)) // use OutputSettings of xsl, so it can be output as HTML
					{
						aTransformer.Transform(aXml, GetXsltArgumentList(theRequest), aOutputWriter);
						theResponse.Output = new StringBuilder(aStringWriter.ToString());
					}
				}
			}
			
		}

		private static XsltArgumentList GetXsltArgumentList(PageParserRequest theRequest)
		{
			var aXsltArgs = new XsltArgumentList();
			//aXsltArgs.AddParam(Literals.PageCode, "", theRequest.PageCode);
			//aXsltArgs.AddParam(Literals.OrgCode, "", theRequest.Data.OrgCode);
			aXsltArgs.AddParam(Literals.OutputType, "", theRequest.OutputType.ToString());
			return aXsltArgs;
		}
	}
}
