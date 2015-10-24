using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Launcher.Controllers
{
    // Этот контроллер возвращает нам представление (View)
    // Так как мы пока придерживаемся концепции single page application, 
    // обращаемся мы к нему один раз, чтобы сформировать начальную страницу - подцепить скрипты, стили, Razor-разметку
 //   [Route("[controller]")] -- не требуется для страницы по умолчанию
    public class HomeController : Controller
    {   
        public ViewResult Index()
        {
            Console.Write("New instance of application was initialized\n");
            return View();
        }
    }
}
