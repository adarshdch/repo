
using System.Data;
using System.Xml.Linq;

namespace SAB.DAL.EntLib
{
	public static class OrgDatabase
	{
		public static DataSet SelectQuery(string theOrgCode, string theSelectQuery)
		{
			var aDatabase = DbFactory.GetOrgDatabase(theOrgCode);
			var aDataSet = aDatabase.ExecuteDataSet(CommandType.Text, theSelectQuery);
			return aDataSet;
		}

		
	}
}
