using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AECSCore;

namespace RSCore
{
    public class OrderRepository : IOrderRepository
    {
        public IEnumerable<Order> SelectAll()
        {
            throw new NotImplementedException();
        }

        public Order SelectById(Int32 Id)
        {
            throw new NotImplementedException();
        }

        public Order SelectByCode(String Code)
        {
            Order Result = null;
            using (var Context = new NSIEntities())
            {
                var SearchResult = Context.Zakaz.FirstOrDefault(x => x.zakaz == Code);
                if (SearchResult != null)
                {
                    Result = new Order();
                    Result.Code = Code;
                    Result.Name = SearchResult.NaimZak;
                }
            }
            return Result;
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
