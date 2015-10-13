using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using CalendarGraph.ViewModels;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CalendarGraph.Modules
{
    [Route("api/[controller]")]
    public class CalendarGraphController : Controller
    {
        #region State

        // Состояние текущего сеанса пользователя
        private MainViewModel _mainViewModel;
        public MainViewModel MainViewModel
        {
            get
            {
                if(_mainViewModel == null)
                {
                    _mainViewModel = new MainViewModel();
                }
                return _mainViewModel;
            }
            set
            {
                _mainViewModel = value;
            }
        }

        #endregion State

        #region Actions

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Order">Номер заказа, переданный с фронтэнда</param>
        /// <returns></returns>
        [Route("[action]/{Order:int}")]
        public String Build(String Order)
        {
            
            return "er";
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        #endregion Actions

        #region Examples




        // GET api/values/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/values
        //[HttpPost]
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        #endregion Examples
    }
}
