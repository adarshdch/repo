
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace SAB.DAL.EntLib
{
	public class DbFactory
	{
		private static readonly DatabaseProviderFactory DbProviderFactory;

		static DbFactory()
		{
			DbProviderFactory = new DatabaseProviderFactory();
		}

		public static Database GetDatabase(string theConnnectionStringName)
		{
			return DbProviderFactory.Create(theConnnectionStringName);
		}


		public static Database GetOrgDatabase(string theOrgCode)
		{
			return DbProviderFactory.Create(string.Format("{0}Db", theOrgCode));
		}
	}
}
