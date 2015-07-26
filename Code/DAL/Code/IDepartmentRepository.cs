using AECSCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IDepartmentRepository
    {
        IEnumerable<Department> SelectAll();
        Department SelectById(Int32 Id);

        void Insert(Department Department);
        void Update(Department Department);
        void Delete(Department Department);
        void Save();
    }
}
