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
    public class ProfessionListViewModel : ModuleViewModel
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

        private ObservableCollection<Profession> _items;
        public ObservableCollection<Profession> Items
        {
            get
            {
                if(_items == null)
                {
                    _items = new ObservableCollection<Profession>();
                }
                return _items;
            }
            set
            {
                _items = value;
                OnPropertyChanged("Items");
            }
        }

        private Profession _selectedItem;

        public Profession SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                _selectedItem = value;
                if (Parent is ProfessionManagerViewModel)
                {
                    (Parent as ProfessionManagerViewModel).SelectedItem = value;
                }
                OnPropertyChanged("SelectedItem");
                _selectedItem = value;
            }
        }

        public ProfessionListViewModel()
        {

            Context.Professions.Load();
            this.Items = Context.Professions.Local;
            IsEditable = true;
        }

        public ProfessionListViewModel(ModuleViewModel Parent)
        {
            this.Parent = Parent;
            Context.Professions.Load();
            this.Items = Context.Professions.Local;
            IsEditable = true;

           
        }



        public ProfessionListViewModel(Department Department)
        {


            Context.Professions.Load();
            var AllMachines = Context.Professions.Local;
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
            var CreatedItem = new Profession
            { Name = "Машина"
                //ShortName = "МШ",
                //DepartmentId = 1
            };
            Context.Professions.Add(CreatedItem);
            UserContext.ChangedMade();
  
            Context.SaveChanges();
        }

        private void Delete()
        {
            (Items as ObservableCollection<Profession>).Remove(SelectedItem);
            Context.SaveChanges();
        }


        #endregion Methods
    }
}
