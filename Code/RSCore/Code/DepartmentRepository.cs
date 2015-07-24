using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using AECSCore;


namespace RSCore
{
    public class DepartmentRepository : IDepartmentRepository
    {
        public IEnumerable<Department> SelectAll()
        {
            
            throw new NotImplementedException();   
        }

        public Department SelectById(Int32 Id)
        {
            Department Result = null;
            using(var Context = new NSIEntities())
            {

                var SearchResult = Context.PDivision.FirstOrDefault(x => x.ID == Id);
                if(SearchResult != null)
                {
                    Result = new Department();
                    Result.Id = SearchResult.ID;
                    Result.ShortName = SearchResult.Name;
                }
            }
            return Result;
        }

        public void Insert(Department Department)
        {
            throw new NotSupportedException("ReadOnly");

        }

        public void Update(Department Department)
        {
            throw new NotSupportedException("ReadOnly");
        }

        public void Delete(Department Department)
        {
            throw new NotSupportedException("ReadOnly");
        }

        public void Save()
        {
            throw new NotSupportedException("ReadOnly");
        }

        public DepartmentRepository()
        {

        }
    }
}
