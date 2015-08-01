using AECSCore;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace RSCore
{
    public class ExploderResultRepository : IElementRepository
    {
        /// TODO : REMOVE MAGIC STRING
        public IEnumerable<Element> SelectAll()
        {
            var Result = new List<Element>();
            using(var Context = new ConstDocsEntities())
            {

                var RawResult = Context.tempPOSPRIMB
                                .Where(x => x.id == "NetGraph").ToList();

                foreach(tempPOSPRIMB Record in RawResult)
                {
                    var MockParent = new Element()
                    {
                        Id = Record.Parent
                        //Index = Record.IND2,
                        //Denotation = Record.P2NI,
                        //Type = ElementType.Block,
                        //Depth = Record.Depth - 1
                    };
                    var Element = new Element()
                    {
                        Id = Record.id_record,
                        Type = EnumHelper.FindInDesc<ElementType>(Record.TIP),
                        Index = Record.IND1,
                        Denotation = Record.PICH,  
                        Depth = Record.Depth,
                        Parent = MockParent
                    };
                    Result.Add(Element);
                }
            }
            return Result;
        }

        public Element SelectById(int Id)
        {
            throw new NotImplementedException();
        }

        public Element SelectByCode(string Name)
        {
            throw new NotImplementedException();
        }

        public void Insert(Element Department)
        {
            throw new NotImplementedException();
        }

        public void Update(Element Department)
        {
            throw new NotImplementedException();
        }

        public void Delete(Element Department)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
