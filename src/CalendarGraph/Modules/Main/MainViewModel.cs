using System;
using System.Collections.Generic;
using System.Linq;
using Core;

namespace CalendarGraph.ViewModels
{

    public class MainViewModel
    {
        #region Properties

        public String RequestedOrderCode;
        public Order Order;
        public CalendarGraph CalendarGraph;


        #endregion Properties

        #region Methods

        /// <summary>
        /// Initialize CalendarGraph layout based on requested order code
        /// </summary>
        public void Load()
        {
            if (String.IsNullOrWhiteSpace(RequestedOrderCode))
            {
                RequestedOrderCode = "203467";
            }
            this.Order = GetOrder(RequestedOrderCode);
            if (Order == null)
            {
                return;
            }

            CalendarGraph = new CalendarGraph(Order);

            /*
            this.Departments = GetDivisions();
            this.StandartWorks = GetStandartWorks();
            this.PreparationWorks = GetPreparationWorks();
            this.MainWorks = GetMainWorks();*/
        }

        private Order GetOrder(String Code)
        {
            //var Store = new OrderRepository();
            //  var Result = Store.SelectByCode(Code);
            // return Result;
            return null;
        }

        #endregion Methods

        /*

                

        private ExploderViewModel _exploderModel;
        public ExploderViewModel ExploderModel
        {
            get;

            set;

        }

 
        private IEnumerable<Department> _departments;
        public IEnumerable<Department> Departments
        {
            get 
            { 
                if(_departments == null)
                {
                    _departments = new List<Department>();
                }
                return _departments; 
            }
            set 
            { 
                _departments = value; 
            }
        }
        
        private List<Element> _elements;
        public List<Element> Elements
        {
            get
            {
                if (_elements == null)
                {
                    _elements = new List<Element>();
                }
                return _elements;
            }
            set
            {
                _elements = value;
            }

        }

        private IEnumerable<Work> _standartWorks;
        public IEnumerable<Work> StandartWorks
        {
            get
            {
                if (_standartWorks == null)
                {
                    _standartWorks = new List<Work>();
                }
                return _standartWorks;
            }
            set
            {
                _standartWorks = value;
            }
        }

        private IEnumerable<Work> _mainWorks;
        public IEnumerable<Work> MainWorks
        {
            get
            {
                if (_mainWorks == null)
                {
                    _mainWorks = new List<Work>();
                }
                return _mainWorks;
            }
            set
            {
                _mainWorks = value;
            }
        }

        private IEnumerable<Work> _preparationWorks;
        public IEnumerable<Work> PreparationWorks
        {
            get
            {
                if (_preparationWorks == null)
                {
                    _preparationWorks = new List<Work>();
                }
                return _preparationWorks;
            }
            set
            {
                _preparationWorks = value;
            }
        }



   

        /// <summary>
        /// TODO
        /// </summary>
        private IEnumerable<Department> GetDivisions()
        {
            var Store = new DepartmentRepository();
            var Result = Store.SelectAll();
            return Result;
        }


        public IEnumerable<Work> GetStandartWorks()
        {
            var Result = new List<Work>();

            var ContractWork = new Work();
            ContractWork.Name = "Контракт";
            ContractWork.Duration = 6;

            var AuctionWork = new Work();
            AuctionWork.Name = "Торги";
            AuctionWork.Duration = 70;
            AuctionWork.XOffset = ContractWork.Duration;

            var PaymentWork = new Work();
            PaymentWork.Name = "Оплата";
            PaymentWork.Duration = 17;
            PaymentWork.XOffset = AuctionWork.XOffset + AuctionWork.Duration + 40;

            var BuyMaterialsWork = new Work();
            BuyMaterialsWork.Name = "Закуп. матер.";
            BuyMaterialsWork.Duration = 200;
            BuyMaterialsWork.XOffset = PaymentWork.XOffset + PaymentWork.Duration;

            var BuyPurchasedWork = new Work();
            BuyPurchasedWork.Name = "Закуп. ПКИ";
            BuyPurchasedWork.Duration = 200;
            BuyPurchasedWork.XOffset = PaymentWork.XOffset + PaymentWork.Duration;


            Result.Add(ContractWork);
            Result.Add(AuctionWork);
            Result.Add(PaymentWork);
            Result.Add(BuyMaterialsWork);
            Result.Add(BuyPurchasedWork);

            return Result;
        }

        public IEnumerable<Work> GetPreparationWorks()
        {
            var PaymentWork = this.StandartWorks.First(x => x.Name == "Оплата");
            List<Work> Result = new List<Work>();
            var PrepDepartments = this.Departments.Where(x => x.Id < 15);
            foreach(var Department in PrepDepartments)
            {
                var Work = new Work();
                Work.Department = Department;
                Work.Duration = Department.Duration;
                Work.XOffset = PaymentWork.XOffset + PaymentWork.Duration;
                Result.Add(Work);
            }
            return Result;
        }

        public IEnumerable<Work> GetMainWorks()
        {
            var Purchased = this.StandartWorks.First(x => x.Name == "Закуп. ПКИ");
            List<Work> Result = new List<Work>();
            var PrepDepartments = this.Departments.Where(x => x.Id > 15);
            foreach (var Department in PrepDepartments)
            {
                var Work = new Work();
                Work.Department = Department;
                Work.Duration = Department.Duration;
                Work.XOffset = Purchased.XOffset + Purchased.Duration;
                Result.Add(Work);
            }
            return Result;
        }

    }
    */
    }
}