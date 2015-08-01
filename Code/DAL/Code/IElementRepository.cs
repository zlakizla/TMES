using AECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IElementRepository 
    {
        IEnumerable<Element> SelectAll();
        Element SelectById(Int32 Id);

        Element SelectByCode(String Name);

        void Insert(Element Department);
        void Update(Element Department);
        void Delete(Element Department);
        void Save();
    }
}
