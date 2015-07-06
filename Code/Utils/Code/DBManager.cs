using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utils
{
    using System.Data.SqlClient;
     
    /// <summary>
    /// Класс для организации прямых запросов к БД, минуя Entity Framework
    /// </summary>
    public class DBManager
    {
        private static string ConnectionString
        {
            get
            {
                return System.Configuration.ConfigurationManager.ConnectionStrings["Direct"].ConnectionString;
            }
        }

        private static SqlConnection _mainConn;
        public static SqlConnection MainConn
        {
            get
            {
                if (_mainConn == null)
                {
                    _mainConn = new SqlConnection(ConnectionString);
                }
                if (_mainConn.State == System.Data.ConnectionState.Closed)
                {
                    _mainConn.Open();
                }
                return _mainConn;
            }
        }

        public static SqlConnection GetSQLConnection()
        {
            SqlConnection conn = new SqlConnection(@"" + System.Configuration.ConfigurationManager.ConnectionStrings["ORDER_DBFConnectionString"].ConnectionString);
            try
            {
                conn.Open();
            }
            catch (NullReferenceException)
            {
                conn = null;
            }
            return conn;
        }
    }
}
