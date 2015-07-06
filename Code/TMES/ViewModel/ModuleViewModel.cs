using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMES.ViewModel
{
    public class ModuleViewModel : ViewModelBase
    {
        public String Name {get; set;}

        private String _icon;
        public String Icon 
        {
            get
            {
                return @"pack://application:,,,/Themes/Icons/" + _icon;
            }
            set
            {
                _icon = value;
            }
        }

        private ObservableCollection<ModuleViewModel> _openedModules;
        public ObservableCollection<ModuleViewModel> OpenedModules
        {
            get
            {
                if (_openedModules == null)
                {
                    _openedModules = new ObservableCollection<ModuleViewModel>();
                }
                return _openedModules;
            }
            set
            {
                _openedModules = value;
            }
        }

        public ModuleViewModel()
        {

        }

        public ModuleViewModel(String Name_)
        {
            this.Name = Name_;
        }

        public static ModuleViewModel Empty()
        {
            return new ModuleViewModel();
        }
    }
}
