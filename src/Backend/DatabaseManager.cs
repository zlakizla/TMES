using System;
using System.Data;
//using System.Runtime;
using System.Data.SqlClient;
using System.Data.Common;
using System.Collections;
using System.Collections.Generic;
namespace Backend
{
	public class DatabaseManager
	{
		private static DatabaseManager globalDatabaseManager;
		public static DatabaseManager GetInstance()
		{
			if(globalDatabaseManager == null)
			{
				globalDatabaseManager = new DatabaseManager();
			}
			return globalDatabaseManager;
		}
		public const String PrimaryConnectionString = 
		//@"Data Source=localhost;Initial Catalog=NSI;Integrated Security=True"; 
		@"Server=ms-sql-7.in-solve.ru;Database=1gb_x_t_mes;User Id=1gb_kdergachev;
Password=qwerty";
		private SqlConnection _primaryConnection;
		private SqlConnection PrimaryConnection
		{
			get
			{
				if(_primaryConnection == null)
				{
					_primaryConnection = new SqlConnection(PrimaryConnectionString);
				}
				if(_primaryConnection.State != ConnectionState.Open)
				{
					_primaryConnection.Open();
					if(_primaryConnection.State != ConnectionState.Open)
					{
						 Console.WriteLine("Primary SQL Connection established!");
					}
				}
				return _primaryConnection;
			}
		}
		public	DatabaseManager()
		{
			var TestConn = PrimaryConnection;
		}
		
		public void SendCommand(String Command, Dictionary<String, Object> Parameters)
		{
			using(SqlCommand cmd = new SqlCommand("",PrimaryConnection))
			{
				foreach(var Parameter in Parameters)
				{
					cmd.Parameters.AddWithValue(Parameter.Key, Parameter.Value);
				}
                cmd.CommandText = Command;
				cmd.ExecuteNonQuery();
			}
		}
        
		
		public IList<Row> SendRequest(String Command, Dictionary<String, Object> Parameters = null)
		{		
			// TODO : Конкретизировать резалт	
			var Result = new List<Row>();
            if(Parameters == null)
            {
                Parameters = new Dictionary<String, Object>();
            }
			using(SqlCommand cmd = new SqlCommand(Command,PrimaryConnection))
			{
                foreach(var Parameter in Parameters)
                {
                    cmd.Parameters.AddWithValue(Parameter.Key, Parameter.Value);
                }
				using(SqlDataReader dr = cmd.ExecuteReader())
				{
					var Request = cmd.CommandText;
					var RequestParams = cmd.Parameters.ToString();
             		Console.WriteLine("Send request for database:" + Request);
					Console.WriteLine("Parameters:" + RequestParams);
					
                    var Dataset = new Dataset(dr);        
                    Result = Dataset.Rows;
				}
			}      
			return Result;
		}
	}
}