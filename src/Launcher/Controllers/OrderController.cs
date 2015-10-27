using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Backend;
using Entities;

namespace Launcher.Controllers
{
   [Route("api/[controller]")] 
    public class OrderController : Controller
    {   
        private Int32 Id;
		// GET api/order/5
        [HttpGet("{id}")]
        public bool Get(int Id)
        {     
			Console.WriteLine("Incoming request for order:" + Id);
            this.Id = Id;
            return IsOrderExist();
        }
        
        private bool IsOrderExist()
        {
             var dbManager = DatabaseManager.GetInstance();
             String Request = @"SELECT * 
                                FROM [NSI].[dbo].[ZakazVPR]
                                WHERE PTP = '00'   
                                AND Z = @Order";
             Console.WriteLine("Send request for database:" + Request);
             var RequestArgs = new Dictionary<String,Object>();
             RequestArgs.Add("Order",Id);
             var Reader = dbManager.SendRequest(Request, RequestArgs);
             if(Reader.HasRows)
             {
                 Console.WriteLine("Recieved response from database");
                 return true;
             }
             return false;
        }
    }
}