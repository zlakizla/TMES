using AECSCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMES.ViewModel
{
    public class MonitoreViewModel : ModuleViewModel
    {
        #region Properties


        public MonitoreViewModel()
        {
            base.Name = "ДИСПЕТЧИРИЗАЦИЯ";
            base.Icon = "Orders.png";
        }
        private ObservableCollection<Department> _allDepartments;
        public ObservableCollection<Department> AllDepartments
        {
            get
            {
                if (_allDepartments == null)
                {

                    Global.Context.Departments.ToList();
                    _allDepartments = Global.Context.Departments.Local;
                }
                return _allDepartments;
            }
            set
            {
                _allDepartments = value;
            }
        }



        #endregion Properties
    }
}
