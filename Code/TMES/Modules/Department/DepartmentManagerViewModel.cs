using AECSCore;
using DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace TMES.ViewModel
{
    class DepartmentManagerViewModel : ModuleViewModel
    {

        #region Properties
        
        private UserContext _context;
        public UserContext Context
        {
            get
            {
                if (_context == null)
                {
                    _context = new UserContext();
                }
                return _context;
            }
        }

        private DepartmentListViewModel _departmentListViewModel;
        public DepartmentListViewModel DepartmentListViewModel
        {
            get
            {
                if (_departmentListViewModel == null)
                {
                    _departmentListViewModel = new DepartmentListViewModel(this);
                }
                return _departmentListViewModel;
            }
            set
            {
                _departmentListViewModel = value;
            }
        }

        private DepartmentEditViewModel _departmentEditViewModel;
        public DepartmentEditViewModel DepartmentEditViewModel
        {
            get
            {
                if (SelectedItem == null)
                {
                    return null;
                }
                if(_departmentEditViewModel == null)
                {
                    _departmentEditViewModel = new DepartmentEditViewModel(this);
                }
                return _departmentEditViewModel;
            }
            set
            {
                _departmentEditViewModel = value;
                OnPropertyChanged("DepartmentEditViewModel");
                
            }
        }

        private Department _selectedItem;
        public Department SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                DepartmentEditViewModel = new DepartmentEditViewModel(this);
                OnPropertyChanged("SelectedItem");
                OnPropertyChanged("DepartmentEditViewModel");

            }
        }

        private BindingList<Department> _departments;
        public BindingList<Department> Departments
        {
            get
            {
                if(_departments == null)
                {
                    Context.Departments.Load();
                    _departments = Context.Departments.Local.ToBindingList<Department>(); 
                }
                return _departments;
            }
            set
            {
                _departments = value;
                OnPropertyChanged("Departments");
            }
        }
        public void Save()
        {
            OnPropertyChanged("Departments");
            OnPropertyChanged("Context");
        }

        private Department _selectedDepartment;
        public Department SelectedDepartment
        {
            get
            {
                return _selectedDepartment;
            }
            set
            {
                _selectedDepartment = value;
                DepartmentEditViewModel = new DepartmentEditViewModel(this);
                OnPropertyChanged("SelectedDepartment");
            }
        }
 
        #endregion Properties

        #region Commands 

        private RelayCommand _createCommand;
        public ICommand CreateCommand
        {
            get
            {
                if (_createCommand == null)
                {
                    _createCommand = new RelayCommand(param => this.Create(), null);
                }
                return _createCommand;
            }
        }

        private RelayCommand _deleteCommand;
        public ICommand DeleteCommand
        {
            get
            {
                if (_deleteCommand == null)
                {
                    _deleteCommand = new RelayCommand(param => this.Delete(), null);
                }
                return _deleteCommand;
            }
        }


        #endregion Commands

        #region Methods

        private void Create()
        {

            Departments.Add(new Department() { Name = "Цех 0", ShortName = "0" });
            Context.SaveChanges();
        }

        private void Delete()
        {
            Departments.Remove(SelectedDepartment);
            Context.SaveChanges();
        }

        #endregion Methods

        #region Constructor

        public DepartmentManagerViewModel()
        {
            base.Name = "ПОДРАЗДЕЛЕНИЯ";
            base.Icon = "Departments.png";
            SelectedDepartment = Departments.FirstOrDefault();
           
            /*Departments.Add(new Department(1, "1", "1", 0));
            Departments.Add(new Department(2, "2", "2", 0));
            Departments.Add(new Department(3, "3", "3", 0));*/
        }

        #endregion Constructor


    }
}
