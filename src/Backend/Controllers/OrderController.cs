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
        [HttpGet("SrvGetRootTask")]
        public List<Work> Pek(int Id)
        {
             Console.WriteLine("Request for SrvGetRootTask");
             var Result = new List<Work>();
            
            var dbManager = DatabaseManager.GetInstance();
            String Request = @"SELECT NAZVO
                            FROM [ConstDocs].[dbo].[BlocksByOperation]
                            WHERE id = @id";
            var RequestArgs = new Dictionary<String,Object>();
            try
            {

                 RequestArgs.Add("id","NetGraph8");
                 var Reader = dbManager.SendRequest(Request, RequestArgs);
                 Console.WriteLine("Results found: " + Reader.Count.ToString());
            }
            catch (System.Exception e)
            {
                Console.WriteLine(e.ToString());
            }
          
            //  for (int i = 0; i < Reader.Count; i++)
            //  {
            //      var Work = new Work();
            //      Work.Id = i;
            //      Work.Name = Reader[i].ToString();
            //      Result.Add(Work);
            //  }
            //  Console.WriteLine("Response from SrvGetRootTask");
  
            return Result;
        }
        
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
            var Rows = dbManager.SendRequest(Request, RequestArgs);

            if(Rows.Count > 0)
            {         
                Result.Code = Rows[0]["zakaz"] as String;
                Result.Name = Rows[0]["NaimZak"] as String;
            }
            return Result;
        }
        
        private bool IsOrderExist()
        {
             return false;
        }
    }
}