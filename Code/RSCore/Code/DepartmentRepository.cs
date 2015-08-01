using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using AECSCore;
using Utils;
using System.Windows.Media;

namespace RSCore
{
    public class DepartmentRepository : IDepartmentRepository
    {


        public IEnumerable<Department> SelectAll()
        {

            List<Department> Result = new List<Department>();
            using (var Context = new ConstDocsEntities())
            {

                var SearchResult = Context.RootWorks;
                foreach(var Row in SearchResult)
                {
                    Department Department = new Department();
                    Department.ShortName = Row.C.ToString();
                    Department.Name = Row.C.ToString();
                    Department.Duration = Row.Duration ?? 0;
                    Department.Color = ColorHelper.Random((int)Row.C);
                 //   Department.ColorCode = Department.Color.ToInt();
                    Result.Add(Department);
                }
               
            }
            return Result; 
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
                    //Result.ColorCode = ColorHelper.Random().ToInt();
                    
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
