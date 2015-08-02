using AECSCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMES.ViewModel
{
    public class OrdersViewModel : ModuleViewModel
    {
        private ObservableCollection<Order> _orders;
        public ObservableCollection<Order> Orders
        {
            get
            {
                if (_orders == null)
                {
                    _orders = new ObservableCollection<Order>(); 
                }
                return _orders;
            }
            set
            {
                _orders = value;
            }
        }

        private Order _selectedOrder;
        public Order SelectedOrder
        {
            get
            {
                if (_selectedOrder == null)
                {
                    _selectedOrder = new Order();
                }
                return _selectedOrder;
            }
            set
            {
                _selectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }

      
        public ObservableCollection<Element> SelectedOrderContent
        {
            get
            {

                return _selectedOrder.Content as ObservableCollection<Element>;
            }
            set
            {
                _selectedOrder.Content = value;
            }
        }

        public OrdersViewModel()
        {
            base.Name = "ЗАКАЗЫ";
            base.Icon = "Orders.png";
            this.SelectedOrder = Order.GetFakeOrder();
            this.Orders = Order.GetFakeOrders();
        }

   
    }
}
