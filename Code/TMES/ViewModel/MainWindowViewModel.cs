using DAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMES.ViewModel
{
    class MainWindowViewModel : ModuleViewModel
    {

        public String Text
        {
            get
            {
                return "пэпэкбэк";
            }
        }

        private ViewModelBase _mainMenuViewModel;
        public ViewModelBase MainMenuViewModel
        {
            get
            {
                if (_mainMenuViewModel == null)
                {
                    _mainMenuViewModel = new MainMenuViewModel(OpenedModules);
                }
                return _mainMenuViewModel;
            }
        }

        public MainWindowViewModel()
        {
            OpenedModules.Add(new EnterpriseViewModel());
          ;
         //   OpenedModules.Add(new OrdersViewModel());
         //   OpenedModules.Add(new MonitoreViewModel());
           
        }

        
    }
}
