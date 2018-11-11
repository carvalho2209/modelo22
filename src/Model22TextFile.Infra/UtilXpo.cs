using DevExpress.Xpo;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

namespace Model22TextFile.Infra
{
    public static class UtilXpo
    {
        public static DataTable ExecutaSelect(string pSql)
        {
            try
            {
                var session = Session.DefaultSession;
                var cmd = session.Connection.CreateCommand();
                cmd.CommandText = pSql;
                cmd.CommandTimeout = TimeSpan.FromMinutes(15).Seconds;
                var reader = cmd.ExecuteReader();
                var dt = new DataTable();
                dt.Load(reader);

                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ExecuteNonQuery(string pSql, Dictionary<object, DbType> parameters = null)
        {
            try
            {
                var session = Session.DefaultSession;
                var cmd = session.Connection.CreateCommand();
                
                cmd.CommandText = pSql;
                cmd.CommandTimeout = TimeSpan.FromMinutes(15).Seconds;

                foreach (var parameter in parameters ?? new Dictionary<object, DbType>())
                {
                    var newParameter = cmd.CreateParameter();

                    newParameter.Value = parameter.Key;
                    newParameter.DbType = parameter.Value;

                    cmd.Parameters.Add(newParameter);
                }

                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void WriteLog(string pText)
        {
            var text = string.Format("{0} - {1}", DateTime.Now, pText);
            var pathTemp = Environment.ExpandEnvironmentVariables("%temp%");
            var fileName = "log22.tmp";
            var fullFileName = Path.Combine(pathTemp, fileName);

            File.AppendAllText(fullFileName, Environment.NewLine);
            File.AppendAllText(fullFileName, text);
        }
    }
}
