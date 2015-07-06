using AECSCore;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Windows.Input;
using System.Collections.ObjectModel;

namespace TMES.ViewModel
{
    public class PersonListViewModel : ModuleViewModel
    {
        //:: TODO : Replace ModuleViewModel to specialized
        //:: container class that will be common for all list/edit objects
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

        private UserContext _context;
        public UserContext Context
        {
            get
            {
                if(_context == null)
                {
                    _context = new UserContext();
                }
                return _context;
            }
            set
            {
                _context = value;
            }
        }

        private Boolean _isEditable;
        public Boolean IsEditable
        {
            get
            {
                return _isEditable;
            } 
            set
            {
                _isEditable = value;
            }
        }

        private ObservableCollection<Person> _items;
        public ObservableCollection<Person> Items
        {
            get
            {
                if(_items == null)
                {
                    _items = new ObservableCollection<Person>();
                }
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
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
                if(Parent is PersonManagerViewModel)
                {
                    (Parent as PersonManagerViewModel).SelectedItem = value;
                }
                OnPropertyChanged("SelectedItem");
            }
        }


        #region Constructor
        public PersonListViewModel()
        {

            Context.Persons.Load();
            this.Items = Context.Persons.Local;
            IsEditable = true;
            this.IsDepartmentVisible = true;

        }

        public PersonListViewModel(ModuleViewModel Parent)
        {
            this.Parent = Parent;
            Context.Persons.Load();
            this.Items = Context.Persons.Local;
            IsEditable = true;
            this.IsDepartmentVisible = true;
        }

        public PersonListViewModel(Department Department)
        {
       
            Context.Persons.Where(x => x.DepartmentId == Department.Id).Load();
            var AllPersons = Context.Persons.Local;
            this.Items = AllPersons;
            this.IsDepartmentVisible = false;

        }

        #endregion Constructor

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
            var CreatedItem = new Person()
            {
                LastName = "Doe", 
                FirstName = "John"
            };
            Context.Persons.Add(CreatedItem);
            UserContext.ChangedMade();
  
            Context.SaveChanges();
        }

        private void Delete()
        {
            (Items as ObservableCollection<Person>).Remove(SelectedItem);
            Context.SaveChanges();
        }


        #endregion Methods

        #region Columns

        public Boolean IsDepartmentVisible { get; set; }
     

        #endregion Columns
    }
}
