using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Drawing;

using NetGraph.ViewModels;
using Utils;
using AECSCore;
namespace NetGraph.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        private MainViewModel _model;
        public MainViewModel Model
        {
            get
            {
                if(_model == null)
                {
                    _model = new MainViewModel();
                }
                return _model;
            }
            set
            {
                _model = value;
            }
        }

        private static MainViewModel _instance;
        public static MainViewModel GetInstance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new MainViewModel();
                }
                return _instance;
            }
            set
            {
                _instance = value;
            }

        }
        

        public ActionResult Index(String Order)
        {
           // var Context = new UserContext();
           // var pek = Context.Works.Local;
           // var bek = Context.Elements.Local;
           
             
            Model.RequestedOrderCode = Order;
            if (Order != null)
            {
                Model.Load();
            }
            GetInstance = Model;
            return View(Model);
        }

        [HttpGet]
        public ActionResult Test1(String Index, String Denotation, Int32 Depth)
        {
          
            var  Selected = GetInstance.CalendarGraph.ActiveElement.Content
                .FirstOrDefault(x => x.Index == Index
                                && x.Denotation == Denotation
                                && x.Depth == Depth);
            GetInstance.CalendarGraph.ActiveElement = Selected;
           
         
            var ExploderVM = new ExploderViewModel(GetInstance.CalendarGraph);
           
            ExploderVM.SelectedElement = Selected;
            return PartialView("~/Views/Exploder/Exploder.cshtml", ExploderVM);
        }

        public ActionResult OpenParent(String Index, String Denotation, Int32 Depth)
        {
 
            var Incoming = new Element()
            {
                Index = Index,
                Denotation = Denotation,
                Depth = Depth
            };


            Element Selected;

            if (GetInstance.CalendarGraph.ActiveElement == Incoming)
            {
                Selected = GetInstance.CalendarGraph.ActiveElement;
            }
            else
            {
                Selected = GetInstance.CalendarGraph.ActiveElement.FindAncestor(Incoming);
                GetInstance.CalendarGraph.ActiveElement = Selected;
            }
           
            var ExploderVM = new ExploderViewModel(GetInstance.CalendarGraph);

            ExploderVM.SelectedElement = Selected;
            return PartialView("~/Views/Exploder/Exploder.cshtml", ExploderVM);
        }

        public ActionResult LoadWorkDetail(String Index, String Denotation, Int32 Depth)
        {
            var Incoming = new Element()
            {
                Index = Index,
                Denotation = Denotation,
                Depth = Depth
            };

            var WorkDetailVM = new WorkDetailViewModel(Incoming);

            return PartialView("~/Views/WorkDetail/WorkDetail.cshtml", WorkDetailVM);
        }
    }
}
