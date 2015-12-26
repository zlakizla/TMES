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
        public OrderService Service;
        
        public OrderController()
        {
            this.Service = new OrderService();
        }
        
        private Int32 Id;
		// GET api/order/5
        [HttpGet("{id}")]
        public Order Get(int Id)
        {     
            try
            {
                return Service.GetOrderById(Id);
            }
			catch(Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }
        }
        
        [HttpGet("{id}/build")]
        //:: Provide full data set for gantt-controll to build diagramm 'by division'
        public IList<GanttData> GetDetails(int Id)
        {
            var Result = new List<GanttData>();
            var Order = this.Get(Id);
            Result = Service.GetDetails(Order) as List<GanttData>;
            
            return Result;
        }      
    }
}