using AECSCore;
using RSCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;

namespace NetGraph.ViewModels
{

    public class MainViewModel
    {

        #region Properties
        private String _requestedOrderCode;
        public String RequestedOrderCode
        {
            get
            {
                return _requestedOrderCode;
            }
            set
            {
                _requestedOrderCode = value;
            }
        }

        private Order _order;
        public Order Order
        {
            get { return _order; }
            set { _order = value; }
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

        private List<Work> _commonWorks;
        public List<Work> CommonWorks
        {
            get
            {
                if (_commonWorks == null)
                {
                    _commonWorks = new List<Work>();
                }
                return _commonWorks;
            }
            set
            {
                _commonWorks = value;
            }
        }

        private List<Work> _works;
        public List<Work> Works
        {
            get
            {
                if (_works == null)
                {
                    _works = new List<Work>();
                }
                return _works;
            }
            set
            {
                _works = value;
            }
        }

        private List<Work> _preparationWorks;
        public List<Work> PreparationWorks
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
        #endregion Properties
       
        /// <summary>
        /// Initialize CalendarGraph layout based on requested order code
        /// </summary>
        public void Load()
        {
            this.Order = GetOrder(RequestedOrderCode);
            var CalendarGraph = new CalendarGraph(Order);  
         //   this.Departments = GetDivisions();  
            //AppContext.FindByOrder("4").RootWorks = Works;
            // Graph.GetRoot();
            //Elements = Graph.Elements;
            //Works = Graph.RootWorks;
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

        private Order GetOrder(String Code)
        {
            var Store = new OrderRepository();
            var Result = Store.SelectByCode(Code);
            return Result;
        }


        //:: Populate CalendarGraph with some FakeWorks
        #region Mock
        //private void FakeLoad()
        //{
            
           
        //    Departments = FakeDepartments();
        //    AppContext.Departments = Departments;

        //    Elements = FakeExlosion();

        //    var FirstFakeWork = new Work(10.0, 1, 3, Departments[0]);
        //    FirstFakeWork.Target.Add(new Element(ElementType.Block,"УЭ","4100200"));


        //    Works.Add(FirstFakeWork);
        //    Works.Add(new Work(10.0, 1, 3, Departments[1]));
        //    Works.Add(new Work(10.0, 1, 3, Departments[2]));
        //    Works.Add(new Work(10.0, 1, 3, Departments[3]));

        //    FakeCommonWorks();
        //    FakePreparationWorks();
        //}

        //private List<Element> FakeExlosion()
        //{
        //    var Elements = new List<Element>();
        //    var RootBlock = new Element(ElementType.Block, "Ха", "123456789");
        //    var Level1BlockOne = new Element(ElementType.Block, "Хб", "1000001", RootBlock);
        //    var Level1BlockTwo = new Element(ElementType.Block, "Хб", "1000002", RootBlock);
        //    var Level2BlockOne = new Element(ElementType.Purchased, "Хб", "2000001", Level1BlockOne);
        //    Elements.Add(RootBlock);
        //    Elements.Add(Level1BlockOne);
        //    Elements.Add(Level1BlockTwo);
        //    Elements.Add(Level2BlockOne);
        //    return Elements;
        //}

        //private List<Department> FakeDepartments()
        //{
        //    var Result = new List<Department>();
        //    Result.Add(new Department(1, "Цех 2", "12", Color.CadetBlue.ToArgb()));
        //    Result.Add(new Department(2, "Цех 4", "14", Color.Red.ToArgb()));
        //    Result.Add(new Department(3, "Цех 11", "11", Color.MediumTurquoise.ToArgb()));
        //    Result.Add(new Department(4, "Цех 15", "15", Color.FromArgb(40,198,13).ToArgb()));
        //    Result.Add(new Department(5, "Контракт", "К", Color.Gray.ToArgb()));
        //    Result.Add(new Department(6, "Торги", "Т", Color.Gray.ToArgb()));
        //    Result.Add(new Department(7, "Оплата", "О", Color.Gray.ToArgb()));
        //    Result.Add(new Department(8, "Закуп. мат.", "И", Color.Gray.ToArgb()));
        //    Result.Add(new Department(9, "Закуп. ПКИ", "П", Color.Gray.ToArgb()));
        //    Result.Add(new Department(10, "Цех 1", "1", Color.FromArgb(0, 162, 232).ToArgb()));
        //    return Result;

        //    //Color.FromArgb(0,162,232).ToArgb()));
        //}

        //private void FakeCommonWorks()
        //{
        //    CommonWorks.Add(new Work(10.0, 0, 3, Departments[4]));
        //    CommonWorks.Add(new Work(10.0, 0, 3, Departments[5]));
        //    CommonWorks.Add(new Work(10.0, 0, 3, Departments[6]));
        //    CommonWorks.Add(new Work(10.0, 0, 3, Departments[7]));
        //    CommonWorks.Add(new Work(10.0, 0, 3, Departments[8]));
        //}

        //private void FakePreparationWorks()
        //{
        //    PreparationWorks.Add(new Work(10.0, 0, 0, Departments[9]));
        //}
        #endregion Mock

    }
}