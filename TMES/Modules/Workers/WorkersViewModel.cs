using AECSCore;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMES.ViewModel
{
    class WorkersViewModel : ModuleViewModel
    {

        public Boolean IsEditable { get; set; }


        private UserContext _userContext;
        public UserContext UserContext
        {
            get
            {
                if(_userContext == null)
                {
                    _userContext = new UserContext();
                }
                return _userContext;
            }
            set
            {
                _userContext = value;
            }
        }

        private BindingList<Worker> _workers;
        public BindingList<Worker> Workers
        {
            get
            {
                if(_workers == null)
                {
                    _workers = new BindingList<Worker>();
                }
                return _workers;
            }
            set
            {
                _workers = value;
            }
        }

        public WorkersViewModel()
        {
            base.Name = "ПЕРСОНАЛ";
            base.Icon = "Persons.png";
        }

        public WorkersViewModel(Department Department)
        {
            base.Name = "ПЕРСОНАЛ";

           
           
        }

    }
}
