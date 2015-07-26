using AECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IOrderRepository
    {
        IEnumerable<Order> SelectAll();
        Order SelectById(Int32 Id);

        Order SelectByCode(String Name);

        void Insert(Order Department);
        void Update(Order Department);
        void Delete(Order Department);
        void Save();
    }
}
