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
    public class MachineListViewModel : ModuleViewModel
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

        private ObservableCollection<Machine> _items;
        public ObservableCollection<Machine> Items
        {
            get
            {
                if(_items == null)
                {
                    _items = new ObservableCollection<Machine>();
                }
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        private Machine _selectedItem;

        public Machine SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                if(Parent is MachineManagerViewModel)
                {
                    (Parent as MachineManagerViewModel).SelectedItem = value;
                }
                OnPropertyChanged("SelectedItem");
            }
        }

        public MachineListViewModel()
        {

            Context.Machines.Load();
            this.Items = Context.Machines.Local;
            IsEditable = true;


        }

        public MachineListViewModel(ModuleViewModel Parent)
        {
            this.Parent = Parent;
            Context.Machines.Load();
            this.Items = Context.Machines.Local;
            IsEditable = true;

           
        }



        public MachineListViewModel(Department Department)
        {
       
    
            Context.Machines.Load();
            var AllMachines = Context.Machines.Local;
           // var Machines = Context.Machines.Where(x => x.DepartmentId == Department.Id);
           //  Machines.Load();
            this.Items = AllMachines;
         //   UserContext.Changed += UserContext_Changed;

        }

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
            var CreatedItem = new Machine()
            {
                Name = "Машина", 
                ShortName = "МШ",
                DepartmentId = 1
            };
            Context.Machines.Add(CreatedItem);
            Context.SaveChanges();
        }

        private void Delete()
        {
            (Items as ObservableCollection<Machine>).Remove(SelectedItem);
            Context.SaveChanges();
        }


        #endregion Methods
    }
}
