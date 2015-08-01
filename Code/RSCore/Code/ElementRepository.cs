using AECSCore;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RSCore
{
    public class ElementRepository : IElementRepository
    {

        public IEnumerable<Element> SelectAll()
        {
            throw new NotImplementedException();
        
        }

        public Element SelectById(int Id)
        {
            throw new NotImplementedException();
        }

        public Element SelectByCode(string Name)
        {
            throw new NotImplementedException();
        }

        //public Element Find(Expression<Func<ConstSP, Boolean>>)
        //{

        //}

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
