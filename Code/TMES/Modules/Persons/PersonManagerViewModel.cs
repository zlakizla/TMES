using AECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMES.ViewModel
{
    class PersonManagerViewModel : ModuleViewModel
    {
        private PersonEditViewModel _PersonEditViewModel;
        public PersonEditViewModel PersonEditViewModel
        {
            get
            {
                if (SelectedItem == null)
                {
                    return null;
                }
                if(_PersonEditViewModel == null)
                {
                    _PersonEditViewModel = new PersonEditViewModel(this);
                }
                return _PersonEditViewModel;
            }
            set
            {
                _PersonEditViewModel = value;
            }
        }

        private PersonListViewModel _PersonListViewModel;
        public PersonListViewModel PersonListViewModel
        {
            get
            {
                if(_PersonListViewModel == null)
                {
                    _PersonListViewModel = new PersonListViewModel(this);
                }
                return _PersonListViewModel;
            }
            set
            {
                _PersonListViewModel = value;
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
                PersonEditViewModel = new PersonEditViewModel(this);
                OnPropertyChanged("SelectedItem");
                OnPropertyChanged("PersonEditViewModel");

            }
        }

        public PersonManagerViewModel()
        {
            base.Name = "ПЕРСОНАЛ";
            base.Icon = "Persons.png";
        }


    }
}
