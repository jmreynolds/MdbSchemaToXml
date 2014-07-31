using System;
using System.Data;
using System.Data.OleDb;
using System.Xml.Linq;

namespace MdbSchemaToXml
{
    public class MdbToXml
    {
        public void GenerateXmlOutput(string pathToData, string pathToOutput)
        {
            string connectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + pathToData;
            var databaseConnection = new OleDbConnection(connectionString);
            databaseConnection.Open();

            var databaseElement = new XElement("Root");

            DataTable dataTable = databaseConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            if (dataTable != null)
            {

                int numTables = dataTable.Rows.Count;
                for (int tableIndex = 0; tableIndex < numTables; ++tableIndex)
                {
                    var tableName = dataTable.Rows[tableIndex]["TABLE_NAME"].ToString();
                    var dataTableElement = new XElement("Table", tableName);
                    databaseElement.Add(dataTableElement);


                    var schemaTable = databaseConnection.GetOleDbSchemaTable(OleDbSchemaGuid.Columns, new object[] { null, null, tableName, null });
                    if (schemaTable != null)
                        foreach (DataRow row in schemaTable.Rows)
                        {
                            var fieldName = row[3];
                            var fieldElement = new XElement("Field", fieldName);
                            dataTableElement.Add(fieldElement);
                        }
                }
            }
            Console.WriteLine(databaseElement);
            databaseElement.Save(pathToOutput);
            Console.ReadKey();
        }
    }
}
