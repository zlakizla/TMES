using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace Entities
{
    public class Order 
    {
        public Int32 Id;
        public String Code;
        public String Name;
        public DateTime StartTime;

       // public Element Root { get; set; }
//  
//          private ICollection<Element> _content;
//          public ICollection<Element> Content
//          {
//              get
//              {
//                  if (_content == null)
//                  {
//                      _content = new ObservableCollection<Element>();
//                  }
//                  return _content;
//              }
//              set
//              {
//                  _content = value;
//              }
//          }
//  
//          public void Explode(IExploder Exploder)
//          {
//              Exploder.Explode(this);
//          }

 
        public Order()
        {
        
        }
        public static Order GetFakeOrder(String Name = "9915240")
        {
            var Result = new Order();
            Result.Name = "9915240";

            //  (Result.Content as List<Element>).Add(new Element(ElementType.Block,"УЭ","8.815.240"));
            //  (Result.Content as List<Element>).Add(new Element(ElementType.Block, "УЭ", "7.715.240"));
            //  
            return Result;
        }

        //  public static ObservableCollection<Order> GetFakeOrders()
        //  {
        //      var Result = new ObservableCollection<Order>();
        //      Result.Add(GetFakeOrder("512"));
        //      Result.Add(GetFakeOrder("220"));
        //      return Result;
        //  }
      
    }
}
