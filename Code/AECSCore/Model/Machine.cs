using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AECSCore
{
    public class Machine
    {
        public Int32 Id { get; set; }

        public String Name { get; set; }

        public String ShortName { get; set; }

        public Int32? DepartmentId { get; set; }

        private Department _department;
        [ForeignKey("DepartmentId")]
        public virtual Department Department 
        {   
            get
            {
                return _department;
            }
            set
            {
                _department = value;
                DepartmentId = value.Id;
            }
        }

        public void Copy(Machine Source)
        {
            this.Id = Source.Id;
            this.Name = Source.Name;
            this.ShortName = Source.Name;
            this.DepartmentId = Source.DepartmentId;
           
        }
         
    }
}
