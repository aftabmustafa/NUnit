using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.OleDb;
using System.Data;
using Dapper;

namespace POM1.DataAccess
{
    public static class ExcelDataAccess
    {
        public static string TestDataFileConnection()
        {
            var FileName = ConfigurationManager.AppSettings["TestDataSheetPath"];

            var Connection = String.Format(@"Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0}; Extended Property='Excel 12.0; HDR=YES'", FileName);

            return Connection;
        }

        public static UserData GetTestData(string KeyName)
        {
            using (var Connection = new OleDbConnection(TestDataFileConnection()))
            {
                Connection.Open();

                var query = String.Format("select * from [DataSet$] where key = '{0}' ", KeyName);

                var Value = Connection.Query<UserData>(query).FirstOrDefault();

                Connection.Close();

                return Value;
            }
        }
    }
}
