using System.Data.SqlClient;
public class DBManager
{
    private static string ConnectionString
    {
        get
        {
            return System.Configuration.ConfigurationManager.ConnectionStrings["NSIEntities"].ConnectionString;
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
}