using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;


namespace TMES.ViewModel
{
    public class MainMenuViewModel : ViewModelBase
    {

        public ObservableCollection<ModuleViewModel> _windows;
        public ObservableCollection<ModuleViewModel> Windows
        {
            get
            {
                return _windows;
            }
            set
            {
                _windows = value;
            }
        }

        public MainMenuViewModel(ObservableCollection<ModuleViewModel> Windows_)
        {
            this.Windows = Windows_;

        }

        private RelayCommand _ordersMenuCommand;
        public ICommand OrdersMenuCommand
        {
            get
            {
                if (_ordersMenuCommand == null)
                {
                    _ordersMenuCommand = new RelayCommand(param => this.OrdersMenu(), null); 
                }
                return _ordersMenuCommand;
            }
        }

        private RelayCommand _chartsMenuCommand;
        public ICommand ChartsMenuCommand
        {
            get
            {
                if (_chartsMenuCommand == null)
                {
                    _chartsMenuCommand = new RelayCommand(param => this.ChartMenu(), null);
                }
                return _chartsMenuCommand;
            }
        }

        private RelayCommand _monitoreMenuCommand;
        public ICommand MonitoreMenuCommand
        {
            get
            {
                if (_monitoreMenuCommand == null)
                {
                    _monitoreMenuCommand = new RelayCommand(param => this.MonitoreMenu(), null);
                }
                return _monitoreMenuCommand;
            }
        }

        public void OrdersMenu()
        {
            Windows.Add(new OrdersViewModel());
            OnPropertyChanged("Windows");
        }

        public void ChartMenu()
        {
            Windows.Add(new ModuleViewModel("ГРАФИКИ"));
            OnPropertyChanged("Windows");
        }

        public void MonitoreMenu()
        {
            Windows.Add(new MonitoreViewModel());
            OnPropertyChanged("Windows");
        }
    }
}
