using AECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMES.ViewModel
{
    class MachineManagerViewModel : ModuleViewModel
    {
        private MachineEditViewModel _machineEditViewModel;
        public MachineEditViewModel MachineEditViewModel
        {
            get
            {
                if (SelectedItem == null)
                {
                    return null;
                }
                if(_machineEditViewModel == null)
                {
                    _machineEditViewModel = new MachineEditViewModel(this);
                }
                return _machineEditViewModel;
            }
            set
            {
                _machineEditViewModel = value;
            }
        }

        private MachineListViewModel _machineListViewModel;
        public MachineListViewModel MachineListViewModel
        {
            get
            {
                if(_machineListViewModel == null)
                {
                    _machineListViewModel = new MachineListViewModel(this);
                }
                return _machineListViewModel;
            }
            set
            {
                _machineListViewModel = value;
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
                MachineEditViewModel = new MachineEditViewModel(this);
                OnPropertyChanged("SelectedItem");
                OnPropertyChanged("MachineEditViewModel");

            }
        }

        public MachineManagerViewModel()
        {
            base.Name = "МАШИНЫ";
            base.Icon = "Machines.png";
        }


    }
}
