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
		@"Data Source=I3RU-ПК;Initial Catalog=NSI;Integrated Security=True"; 
		
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
						 Console.WriteLine("Connection failed");
					}
				}
				
				return _primaryConnection;
			}
		}
		public	DatabaseManager()
		{
			
			//System.Data.Common.DbConnection
			//SqlConnection
		}
		
		public void SendCommand(String Command, Dictionary<String, Object> Parameters)
		{
			using(SqlCommand cmd = new SqlCommand("",PrimaryConnection))
			{
				foreach(var Parameter in Parameters)
				{
					cmd.Parameters.AddWithValue(Parameter.Key, Parameter.Value);
				}
				cmd.ExecuteNonQuery();
			}
		}
		
		public SqlDataReader SendRequest(String Command, Dictionary<String, Object> Parameters)
		{			
			using(SqlCommand cmd = new SqlCommand(Command,PrimaryConnection))
			{
				foreach(var Parameter in Parameters)
				{
					cmd.Parameters.AddWithValue(Parameter.Key, Parameter.Value);
				}
				//:: Derg : Будет допилено чтоб возвращал коллекцию результатов
				//  using(SqlDataReader dr = cmd.ExecuteReader())
				//  {
				//  	while(dr.Read())
				//  	{
				//  		
				//  		dr[dr.FieldCount]
				//  	}
				//  }
				using(SqlDataReader dr = cmd.ExecuteReader())
				{
					return dr;
				}
			}
		}
	}
}
