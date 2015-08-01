using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Media;
using System.Linq;
using System.Web;
using AECSCore;

using Utils;

namespace AECSCore
{
    public class Department
    {
        #region Properties

        private Int32 _id;
        public Int32 Id
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
            }
        }

        private String _shortName;
        public String ShortName
        {
            get
            {
                return _shortName;
            }
            set
            {
                _shortName = value;
            }
        }

        private String _name;
        public String Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        private Color _color;
        public Color Color
        {
            get
            {
                
                return  _color; //ColorHelper.FromInt(ColorCode);
            }
            set
            {
                _color = value;
                //ColorCode = value.ToInt();               
            }
        }

        public Brush Brush
        {
            get
            {
                return new SolidColorBrush(Color);
            }
        }

        /// MOCK
        public Double Duration { get; set; }
        public Boolean IsDeleted { get; set; }

        public Int32 _colorCode;
        public Int32 ColorCode 
        { 
            get
            {
                return _colorCode;
            }
            set
            {
                _colorCode = value;
            }
        }

        private static List<Department> _allDepartments;
        public static List<Department> AllDepartments
        {
            get
            {
                if (_allDepartments == null)
                {
                    _allDepartments = new List<Department>();
                }
                return _allDepartments;
            }
            set
            {
                _allDepartments = value;
            }
        }

        #endregion Properties

        #region Constructor

        public Department(Int32 Id_, String Name_, String ShortName_, Int32 ColorCode_)
        {
            this.Id = Id_;
            this.ShortName = ShortName_;
            this.Name = Name_;
            this.ColorCode = ColorCode_;
        }

        public Department()
        {

        }

        #endregion Constructor

        #region Methods

        /// <summary>
        /// Получить цех по краткому наименованию ("3" - третий, "5" - пятый, и так далее)
        /// </summary>
        /// <param name="ShortName">Краткое наименование цеха по технорму/сопроводительным</param>
        /// <returns></returns>
        public static Department GetByShortName(String ShortName)
        {
            Department Result;
             var Department = AllDepartments.FirstOrDefault(x => x.ShortName.Trim() == ShortName);
            if (Department != null)
            {
                Result = new Department(Department.Id, Department.Name, Department.ShortName, Department.ColorCode);
            }
            else
            {
                Result = new Department();
            }
            return Result;
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object obj)
        {
            //return base.Equals(obj);
            if(obj is Department)
            {
                var Right = obj as Department;
                if(this.Id == Right.Id)
                {
                    return true;
                }
            }
            return false;
           
        }

        #endregion Methods
    }
}