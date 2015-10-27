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
//              using (var Context = new NSIEntities())
//              {
//                  var SearchResult = Context.Zakaz.FirstOrDefault(x => x.zakaz == Code);
//                  if (SearchResult != null)
//                  {
//                      Result = new Order();
//                      Result.Code = Code;
//                      Result.Name = SearchResult.NaimZak;                
//                  }
//  
//                  // PTP = "00" - planned, "02" - unplanned
//                  IEnumerable<ZakazVPR> Content = Context.ZakazVPR.
//                                                  Where(x => x.Z == Code
//                                                   && x.PTP == "00").ToList();
//                  foreach(var Record in Content)
//                  {
//             
//                      var Element = new Element()
//                      {
//               
//                          Type = ElementType.Block,
//                          Index = Record.IND_CH,
//                          Denotation = Record.OBOZN_CH,
//                          Amount = Record.KSP ?? 1
//                      };
//                      Result.Content.Add(Element);
//                  }
//  
//              }

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
