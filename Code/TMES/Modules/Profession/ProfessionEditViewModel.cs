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

namespace TMES.ViewModel
{
    public class ProfessionEditViewModel : ModuleViewModel
    {
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
                OnPropertyChanged("SelectedItem");
            }
        }

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
        public ProfessionEditViewModel(ModuleViewModel Parent)
        {
            this.Parent = Parent;

            SelectedItem = (Parent as ProfessionManagerViewModel).SelectedItem;
        }
        public ProfessionEditViewModel()
        {

        }

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

                var DBRecord = Context.Machines
                .SingleOrDefault(x => x.Id == SelectedItem.Id);

                if (DBRecord != null)
                {
                    //Context.Machines.Attach(SelectedItem);
                    //Context.Entry(SelectedItem).State = EntityState.Modified;

                    //Context.SaveChanges();
                }
            }
          
        }
    }
}
