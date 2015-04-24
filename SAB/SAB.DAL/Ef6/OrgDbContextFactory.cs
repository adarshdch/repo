using System.Collections.Generic;
using System.Data.SqlClient;
using SAB.Entities;
using SAB.Framework.DbRepository.DataContext;
using SAB.Framework.DbRepository.Ef6;
using SAB.Framework.DbRepository.UnitOfWork;

namespace SAB.DAL.Ef6
{
	public class OrgDbContextFactory
	{

		private static string GetOrgConnectionString(string theDatabaseName)
		{
			var aSqlBuilder = new SqlConnectionStringBuilder
			{
				DataSource = ".",
				InitialCatalog = theDatabaseName,
				PersistSecurityInfo = true,
				IntegratedSecurity = true,
				MultipleActiveResultSets = true,
				UserID = "sa",
				Password = "Test123!@#"
			};

			return aSqlBuilder.ToString();
		}

		public static IDataContextAsync GetOrgDbConext(string theOrgCode)
		{
			var aOrgConnectionString = GetOrgConnectionString(string.Format("{0}Db", theOrgCode));
			var aDbContext = new MasterOrgDbContext(aOrgConnectionString);

			InitializeData();


			return aDbContext;
		}

		private static void InitializeData()
		{
			var aTemplates = new List<Template>()
			{
				new Template(){TemplateCode = "DojoConsole", RelativePath = @"master\v1\Dojo_Console.xsl"},
				new Template(){TemplateCode = "DojoForm", RelativePath = @"master\v1\Dojo_Form.xsl"}
			};
			var aPages = new List<Page>()
			{
				//new Page(){PageCode = "console", PageType = PageType.Console, RelativePath = @"master\demo\console.xml", TemplateCode = "Console"},
				//new Page(){PageCode = "form", PageType = PageType.Form, RelativePath = @"master\demo\form.xml", TemplateCode = "Form"},
				//new Page(){PageCode = "aa-pages-c-main", PageType = PageType.Console, RelativePath = @"master\pages\aa-pages-c-main.xml", TemplateCode = "Console"},
				//new Page(){PageCode = "aa-pages-f-details", PageType = PageType.Form, RelativePath = @"master\pages\aa-pages-f-details.xml", TemplateCode = "Form"},
				//new Page(){PageCode = "aa-users-f-userdetails", PageType = PageType.Form, RelativePath = @"master\admin\users\aa-users-f-userdetails.xml", TemplateCode = "Form"},
				//new Page(){PageCode = "aa-pages-f-pagedetails", PageType = PageType.Form, RelativePath = @"master\admin\pages\aa-pages-f-pagedetails.xml", TemplateCode = "Form"},
				new Page(){PageCode = "form", PageType = PageType.Form, RelativePath = @"master\demo\form.xml", TemplateCode = "DojoForm"},
				new Page(){PageCode = "console", PageType = PageType.Form, RelativePath = @"master\demo\console.xml", TemplateCode = "DojoConsole"}
			};
			using (IDataContextAsync northwindFakeContext = new MasterOrgDbContext())
			using (IUnitOfWork unitOfWork = new UnitOfWork(northwindFakeContext))
			{
				var aPage = unitOfWork.Repository<Page>().Find("form");
				if (aPage == null)
				{
					unitOfWork.Repository<Page>().InsertRange(aPages);
					unitOfWork.Repository<Template>().InsertRange(aTemplates);

					unitOfWork.SaveChanges();
				}
			}
		}
	}
}
