using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
   public class Department
    {

        public Int32 Id;        
        public String ShortName;
        public String Name;

        //  private Color _color;
        //  public Color Color
        //  {
        //      get
        //      {
        //          
        //          return  _color; //ColorHelper.FromInt(ColorCode);
        //      }
        //      set
        //      {
        //          _color = value;
        //          //ColorCode = value.ToInt();               
        //      }
        //  }

        //  public Brush Brush
        //  {
        //      get
        //      {
        //          return new SolidColorBrush(Color);
        //      }
        //  }

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
    }
}
