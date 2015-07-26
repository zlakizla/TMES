using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Drawing;

using NetGraph.ViewModels;
using Utils;
namespace NetGraph.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index(String Order)
        {
           // var Context = new UserContext();
           // var pek = Context.Works.Local;
           // var bek = Context.Elements.Local;
            var model = new MainViewModel();
             
            model.RequestedOrderCode = Order;
            if (Order != null)
            {
                model.Load();
            }
            return View(model);
        }
    }
}
