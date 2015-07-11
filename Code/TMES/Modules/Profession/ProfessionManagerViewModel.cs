using AECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMES.ViewModel
{
    class ProfessionManagerViewModel : ModuleViewModel
    {
        private ProfessionEditViewModel _professionEditViewModel;
        public ProfessionEditViewModel ProfessionEditViewModel
        {
            get
            {
                if (_professionEditViewModel == null)
                {
                    _professionEditViewModel = new ProfessionEditViewModel(this);
                }
                return _professionEditViewModel;
            }
            set
            {
                _professionEditViewModel = value;
            }
        }

        private ProfessionListViewModel _professionListViewModel;
        public ProfessionListViewModel ProfessionListViewModel
        {
            get
            {
                if (_professionListViewModel == null)
                {
                    _professionListViewModel = new ProfessionListViewModel(this);
                }
                return _professionListViewModel;
            }
            set
            {
                _professionListViewModel = value;
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
                ProfessionEditViewModel = new ProfessionEditViewModel(this);
                OnPropertyChanged("SelectedItem");
                OnPropertyChanged("ProfessionEditViewModel");

            }
        }

        public ProfessionManagerViewModel()
        {
            base.Name = "ПРОФЕССИИ";
            base.Icon = "Machines.png";
        }

    }
}
