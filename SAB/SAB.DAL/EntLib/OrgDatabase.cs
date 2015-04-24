
using System.Data;

namespace SAB.DAL.EntLib
{
	public static class OrgDatabase
	{
		public static DataSet SelectQuery(string theOrgCode, string theSelectQuery)
		{
			if (string.IsNullOrWhiteSpace(theSelectQuery) || theSelectQuery.Contains("[*"))
			{
				return null;
			}

			var aDatabase = DbFactory.GetOrgDatabase(theOrgCode);
			var aDataSet = aDatabase.ExecuteDataSet(CommandType.Text, theSelectQuery);
			return aDataSet;
		}

		public static int InsertOrUpdateOrDeleteQuery(string theOrgCode, string theInsertOrUpdateOrDelete)
		{
			if (string.IsNullOrWhiteSpace(theInsertOrUpdateOrDelete) || theInsertOrUpdateOrDelete.Contains("[*"))
			{
				return 0;
			}

			var aDatabase = DbFactory.GetOrgDatabase(theOrgCode);
			return aDatabase.ExecuteNonQuery(CommandType.Text, theInsertOrUpdateOrDelete);
		}

	}
}
