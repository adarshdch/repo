
using System.Data;
using System.Text;
using System.Xml.Linq;

namespace SAB.DAL.EntLib
{
	public static class DbExtensions
	{
		public static XElement XmlElement(this DataSet theDataSet)
		{
			var aDataSetXml = new StringBuilder();

			aDataSetXml.Append("<DataSet>");
			foreach (DataTable theTable in theDataSet.Tables)
			{
				aDataSetXml.Append(theTable.XmlElement());
				aDataSetXml.Append("</Table>");
			}
			aDataSetXml.Append("</DataSet>");

			return XElement.Parse(aDataSetXml.ToString());
		}

		public static XElement XmlElement(this DataTable theDataTable)
		{
			var aDataTableXml = new StringBuilder();

			aDataTableXml.Append("<Table>");
			foreach (DataRow theRow in theDataTable.Rows)
			{
				aDataTableXml.Append("<Row>");
				foreach (var theField in theRow.ItemArray)
				{
					aDataTableXml.Append("<Col>");
					aDataTableXml.Append(theField);
					aDataTableXml.Append("</Col>");
				}
				aDataTableXml.Append("</Row>");
			}
			aDataTableXml.Append("</Table>");

			return XElement.Parse(aDataTableXml.ToString());
		}
	}
}
