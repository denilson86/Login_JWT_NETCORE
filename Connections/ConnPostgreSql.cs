using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Sys3.Web.API.Login.Connections
{
    public class ConnPostgreSql
    {

        static string serverName = "52.173.133.97";
        static string port = "5432";
        static string userName = "postgres";
        static string password = "C4POr2d2Sys3";
        static string databaseName = "Sys3_Sistemas";

        public static DataSet Select(string query, int modo)
        {
            DataSet ds = new DataSet();
            try
            {
                SysCob.Library.ConnPostgreSql.ConnPostgreSql conn = new SysCob.Library.ConnPostgreSql.ConnPostgreSql();
                conn._databaseName(databaseName); conn._password(password); conn._userName(userName); conn._port(port);
                conn._serverName(serverName);
                ds = conn.Select(query, modo);
                return ds;
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                throw;
            }
        }
        public static void Execute(string query, int modo)
        {
            try
            {
                SysCob.Library.ConnPostgreSql.ConnPostgreSql conn = new SysCob.Library.ConnPostgreSql.ConnPostgreSql();
                conn._databaseName(databaseName); conn._password(password); conn._userName(userName); conn._port(port);
                conn._serverName(serverName);
                conn.ExecuteNonQuery(query, modo);
            }
            catch (Exception ex)
            {
                string error = ex.Message.ToString();
                throw;
            }
        }
    }
}
