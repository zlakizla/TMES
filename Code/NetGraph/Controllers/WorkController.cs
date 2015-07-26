using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NetGraph.ViewModels;
namespace NetGraph.Controllers
{
    public class WorkController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetRootDetails(String Order, String Id)
        {
          //  var SelectedWork = AppContext.FindByOrder(Order).RootWorks.FirstOrDefault(x => x.Id == Id);
            var Model = new WorkViewModel(true);      
            return PartialView("GetWorkDetails", Model);
        }

        [HttpGet]
        public ActionResult GetDetails(String Order, String Id)
        {
            //var SelectedWork = AppContext.FindByOrder(Order).RootWorks.FirstOrDefault(x => x.Id == Id);
            var Model = new WorkViewModel(false);
            return PartialView("GetWorkDetails", Model);
        }
    }
}
