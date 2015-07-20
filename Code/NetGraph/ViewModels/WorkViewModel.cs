using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetGraph.ViewModels
{
    public class WorkViewModel
    {

        public CalendarGraph Context { get; set; }

        private List<Work> _rootWorks;
        public List<Work> RootWorks
        {
            get
            {
                if (_rootWorks == null)
                {
                    _rootWorks = new List<Work>();
                }
                return _rootWorks;
            }
        }

        public WorkViewModel()
        {


        }

        public WorkViewModel(Work Work_)
        {
           
        }

        public WorkViewModel(Boolean IsRootFake)
        {
            if (IsRootFake)
            {
                RootWorks.Add(new Work("ПОДГОТОВИТЕЛЬНАЯ", 10, 120));
                RootWorks.Add(new Work("КАБ.ШНУР.", 150, 34));
                RootWorks.Add(new Work("АВТОМАТ.", 117, 49));
                RootWorks.Add(new Work("СБОРКА", 31, 25));

            }
        }
    }
}