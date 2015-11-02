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
        public Order Get(int Id)
        {     
            try
            {
                Console.WriteLine("Incoming request for order:" + Id);
                this.Id = Id;
                var Result = GetOrderById(Id);
                if(Result != null)
                {
                    Console.WriteLine("Found order, [Id: " + Result.Id + ", Name: " + Result.Name + "]");
                    return Result;
                }
                else
                {
                    Console.WriteLine("Order not found");
                }
                return GetOrderById(Id);
            }
			catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
        
        private Order GetOrderById(Int32 OrderId)
        {
            var Result = new Order(); 
            
            var dbManager = DatabaseManager.GetInstance();
            String Request = @"SELECT zakaz, NaimZak
                            FROM [NSI].[dbo].[Zakaz]
                            WHERE zakaz = @Order";
            var RequestArgs = new Dictionary<String,Object>();
            RequestArgs.Add("Order",Id);
            var Reader = dbManager.SendRequest(Request, RequestArgs);
            
            if(Reader.Count > 0)
            {
                Result.Code = Reader[0].ToString();
                Result.Name = Reader[1].ToString();
            }
            return Result;
        }
        
        private bool IsOrderExist()
        {
             return false;
        }
    }
}