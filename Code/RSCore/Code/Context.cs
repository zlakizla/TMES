using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RSCore
{
    public class Context
    {
        public DbContext GetInstance()
        {
           return new NSIEntities();
        }

        public void Exec(String Command, params object[] Params)
        {
            using(var Instance = new NSIEntities())
            {
                Instance.Database.ExecuteSqlCommand(Command, Params);
            }
        }
    }
}
