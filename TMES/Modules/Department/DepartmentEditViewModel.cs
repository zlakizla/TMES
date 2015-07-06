using AECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace TMES.ViewModel
{
    public class DepartmentEditViewModel : ModuleViewModel
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

        private MachineListViewModel _machineViewModel;
        public MachineListViewModel MachineViewModel
        {
            get
            {
                if(_machineViewModel == null)
                {
                    _machineViewModel = new MachineListViewModel(SelectedItem);
                }
                return _machineViewModel;
            }
            set
            {
                _machineViewModel = value;
            }
        }

        private PersonListViewModel _personViewModel;
        public PersonListViewModel PersonViewModel
        {
            get
            {
                if (_personViewModel == null)
                {
                    _personViewModel = new PersonListViewModel(SelectedItem);
                }
                return _personViewModel;
            }
            set
            {
                _personViewModel = value;
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
                OnPropertyChanged("SelectedItem");
                OnPropertyChanged("SelectedColor");
            }
        }

        public Color SelectedColor
        {
            get
            {
                if (SelectedItem == null)
                {
                    return Color.FromArgb(255, 0, 0, 0);
                }
                return SelectedItem.Color;
            }
            set
            {
                SelectedItem.Color = value;
                (Parent as DepartmentManagerViewModel).SelectedItem = SelectedItem;
                OnPropertyChanged("SelectedColor");
                OnPropertyChanged("SelectedItem");

            }
        }

        #endregion Properties

        #region Constructor
        public DepartmentEditViewModel()
        {
               
        }

        public DepartmentEditViewModel(ModuleViewModel Parent_)
        {
            this.Parent = Parent_;
            if(Parent is DepartmentManagerViewModel)
            {
                this.SelectedItem = (Parent as DepartmentManagerViewModel).SelectedItem;
            }
        }

        #endregion Constructor 

        #region Commands 
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

        #endregion Commands

        #region Methods

        public void Save()
        {
            if(Parent is DepartmentManagerViewModel)
            {
                (Parent as DepartmentManagerViewModel).Context.SaveChanges();
                (Parent as DepartmentManagerViewModel).Save();
         
            }
        }

        #endregion Methods

    }
}
