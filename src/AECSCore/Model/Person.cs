using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;


namespace AECSCore
{
    public enum Gender
    {
        Male,
        Female
    }
    public  class Person
    {

        public Int32 Id {get; set;}

        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }

        public Gender Gender { get; set; }

        public String Title { get; set; }

        public Int32? DepartmentId  { get; set; }
        public Int32? ProfessionId { get; set; }
        private Profession _profession;
        public virtual Profession Profession
        {
            get
            {
                return _profession;
            }
            set
            {
                _profession = value;
                ProfessionId = value.Id;
            }
        }
        private Department _department;
        [ForeignKey("DepartmentdId")]
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
  
        public String PhotoId  { get; set; }

        [ForeignKey("PhotoId")]
        public Photo Photo { get; set; }


        /// <summary>
        /// This method copy primitive properties field by field.
        /// Complex properties do not copied.
        /// Use for Entity Framework update process.
        /// </summary>
        /// <param name="Source"></param>
        public void Copy(Person Source)
        {
            this.Id = Source.Id;
            this.FirstName = Source.FirstName;
            this.MiddleName = Source.MiddleName;
            this.Title = Source.Title;
            this.LastName = Source.LastName;     
            this.DepartmentId = Source.DepartmentId;
            Profession = Source.Profession;
        }

    }
}
