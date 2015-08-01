using AECSCore;
using RSCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace NetGraph
{
    public class ElementExploder : IExploder
    {


        public Order Order { get; set; }
        public Element Target
        {
            get;
            set;
        }

        public ElementExploder(Order Order)
        {
            this.Order = Order;
                
        }

        public void Explode(IExplodable Target)
        {
            if(Target is Element == false)
            {
                throw new ArgumentException();
            }
            this.Target = Target as Element;

            ExplodeContent();
            GetContent();
          

        }

        private void GetContent()
        {
            var Store = new ExploderResultRepository();
            var AllRecords = Store.SelectAll();
            foreach(var Record in AllRecords)
            {
                
                if(Record.Depth > 0)
                {
                    
                    Record.Parent = AllRecords.First(x => x.Id == Record.Parent.Id);
                    Record.Parent.Content.Add(Record);
                }
                else
                {
                   (Target as Element).Content.Add(Record);
                }
                
            }
        }

        private void ExplodeContent()
        {
            var Id = new SqlParameter("@id", "NetGraph");
            var IND1 = new SqlParameter("@IND1", Target.Index);
            var PICH1 = new SqlParameter("@PICH1", Target.Denotation);
            var Z = new SqlParameter("@Z", Order.Code);
            var NS = new SqlParameter("@NS", 43);
            var Context = new Context();
            Context.Exec("EXEC ConstDocs.dbo.RazuzlovM3 @id, @IND1, @PICH1, @Z"
                , Id
                , IND1
                , PICH1
                , Z);
        }

    }
}