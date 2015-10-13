using System;
using System.Linq;

namespace NetGraph
{

    public class ElementExploder //: IExploder
    {
        /*
        public Element OrderRoot { get; set; }

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
            var Store = new ExploderResultRepository(CalendarGraph.Counter);
            var AllRecords = Store.SelectAll();

            var RootElement = Target as Element;
            var RequestedRoot = AllRecords.FirstOrDefault(x => x.Denotation == RootElement.Denotation
                                    && x.Index == RootElement.Index
                                    &&  x.Parent.Id == -1);
            if(RequestedRoot == null)
            {
                throw new EntryPointNotFoundException("ElementExploder faced an error");
            }

            foreach(var Record in AllRecords)
            {
                if(Record.Depth > 0)
                {
                    
                    Record.Parent = AllRecords.First(x => x.Id == Record.Parent.Id);
                    Record.Parent.Content.Add(Record);
                }
                else
                {
                    Record.Parent = Order.Root;
                    //if(OrderRoot != null)
                    //{

                    //}
                   //(Target as Element).Content.Add(Record);
                }
                Target.Content  = RequestedRoot.Content;
            }
            CalendarGraph.Counter++;
        }

        private void ExplodeContent()
        {
            var Id = new SqlParameter("@id", "NetGraph" + CalendarGraph.Counter );
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
     
    }   */
    }
}