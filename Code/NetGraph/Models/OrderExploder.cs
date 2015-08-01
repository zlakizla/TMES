using AECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetGraph
{
    public class OrderExploder : IExploder
    {

        public Order Order { get; set; }

        public void Explode(IExplodable Target)
        {
            if(Target is Order == false)
            {
                throw new ArgumentException();
            }
            this.Order = Target as Order;
            ExplodeContent();
          
        }

        private void ExplodeContent()
        {
            var Exploder = new ElementExploder(this.Order);
            foreach (Element HeadBlock in this.Order.Content)
            {
                HeadBlock.Explode(Exploder);
            }
        }
    }
}