using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Builder;
using Microsoft.AspNet.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc; // Contains 
using Microsoft.AspNet.Mvc.Razor; //Contains RazorViewEngine class 
using Microsoft.Extensions.OptionsModel; // Contains 'IOptions'
namespace Launcher
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            
        }

        // This method gets called by a runtime.
        // Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
           services.AddMvc();
           services.Configure<RazorViewEngineOptions>(options =>
           {
                var expander = new ViewLocationExpander();
                options.ViewLocationExpanders.Add(expander);
           });
          //  services.AddRouting();
            // Uncomment the following line to add Web API services which makes it easier to port Web API 2 controllers.
            // You will also need to add the Microsoft.AspNet.Mvc.WebApiCompatShim package to the 'dependencies' section of project.json.
            // services.AddWebApiConventions();
           
        }

        // Configure is called after ConfigureServices is called.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.MinimumLevel = LogLevel.Debug;
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();

            // Add the platform handler to the request pipeline.
            app.UseIISPlatformHandler();

            // Configure the HTTP request pipeline.
            app.UseStaticFiles();

            // app.UseMvc(routes => 
            // {
            //    routes.MapRoute(
            //        name: "default",
            //        template: "{controller=Home}/{action=Index}/{id?}");
            // });
            
            // Add MVC to the request pipeline.                
            app.UseMvcWithDefaultRoute(); 
           
        }
    }

        public class ViewLocationExpander : IViewLocationExpander
    {
        public IEnumerable<string> ExpandViewLocations(ViewLocationExpanderContext context, IEnumerable<string> viewLocations)
        {
            
            //return viewLocations.Select(s => s.Replace("/Views/", "E:/Views/"));
             var locations = new List<string>(viewLocations);
            // locations.Add("../FrontEnd/Views/{1}/index.cshtml");
            // locations.Add("~/../FrontEnd/Views/{1}/index.cshtml");
            //locations.Add("/Views/{1}/{0}.cshtml");

            return locations;
        }

        public void PopulateValues(ViewLocationExpanderContext context)
        {

        }
    }
}