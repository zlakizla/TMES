using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Entities;

namespace Backend
{

    public class OrderRepository : IOrderRepository
    {
        OrderService Service;
        
        public OrderRepository()
        {
            Service = new OrderService();
        }
        public IEnumerable<Order> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Order SelectById(Int32 Id)
        {
            var Result = Service.GetOrderById(Id);
            return Result;
        }

        public Order SelectByCode(String Code)
        {
          throw new NotImplementedException();
        }

        public void Insert(Order Department)
        {
            throw new NotImplementedException();
        }

        public void Update(Order Department)
        {
            throw new NotImplementedException();
        }

        public void Delete(Order Department)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
