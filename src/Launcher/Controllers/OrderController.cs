using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Launcher.Controllers
{
   [Route("api/[controller]")] 
    public class OrderController : Controller
    {   
		// GET api/order/5
        [HttpGet("{id}")]
        public bool Get(int Id)
        {
			Console.WriteLine("Incoming request for order:" + Id);
            return IsOrderExist();
        }
        
        private bool IsOrderExist()
        {
            return true;
        }
    }
}
