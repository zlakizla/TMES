using AECSCore;
using DAL;
using TMES.ViewModel;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Data;
using System.Collections;

namespace TMES.ViewModel
{
    public class PersonEditViewModel : ModuleViewModel
    {

        #region Properties

        private ModuleViewModel _parent;
        public ModuleViewModel Parent
        {
            get
            {
                return _parent;
            }
            set
            {
                _parent = value;
            }
        }

        private Person _selectedItem;
        public Person SelectedItem
        {
            get
            {
                
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                OnPropertyChanged("SelectedItem");
                OnPropertyChanged("SelectedDepartment");
            }
        }

        private IEnumerable<Department> _departments;
        public IEnumerable<Department> Departments
        {
            get
            {
                if(_departments == null)
                {
                    using(var Context = UserContext.GetInstance())
                    {
                        
                        _departments = Context.Departments.ToList();
                    }
                    return _departments;
                }
                return _departments; 
            }
            set
            {
                _departments = value;
            }
        }

        private List<Department> _testList;
        public List<Department> TestList
        {
            get
            {
                if(_testList == null)
                {
                    _testList = new List<Department>();
                }
                return _testList;
            }
        } 

        private Department _selectedDepartment;
        public Department SelectedDepartment
        {
            get
            {
                //var Result = Departments.FirstOrDefault(x => x.Id == SelectedItem.Department.Id);
                var Result = SelectedItem.Department;
                return Result;
            }
            set
            {
                SelectedItem.Department = value;

                //OnPropertyChanged("SelectedDepartment");
            }
        }

        #endregion Properties

        #region Constructor
        public PersonEditViewModel(ModuleViewModel Parent)
        {
            this.Parent = Parent;
            TestList.Add(new Department(1, "1", "1", -1));
            TestList.Add(new Department(2, "2", "2", -1));
            SelectedItem = (Parent as PersonManagerViewModel).SelectedItem;
        }
        public PersonEditViewModel()
        {

        }
        #endregion Constructor

        private RelayCommand _saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                if (_saveCommand == null)
                {
                    _saveCommand = new RelayCommand(param => this.Save(), null);
                }
                return _saveCommand;
            }
        }

        public void Save()
        {
            using(var Context = new UserContext())
            {
                var DBRecord = 
                Context.Persons
                .SingleOrDefault(x => x.Id == SelectedItem.Id);

                if(DBRecord != null)
                {
                    DBRecord.Copy(SelectedItem);
                    Context.SaveChanges();
                }
            }
          
        }
    }
}
