using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq.Mapping;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AECSCore
{
    public class Profession
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

        private Int32 _code;
        public Int32 Code
        {
            get
            {
                return _code;
            }
            set
            {
                _code = value;
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

        //private String _altname;
        //public String AltName
        //{
        //    get
        //    {
        //        return _altname;
        //    }
        //    set
        //    {
        //        _altname = value;
        //    }
        //}

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

        //private String _altshortName;
        //public String AltShortName
        //{
        //    get
        //    {
        //        return _altshortName;
        //    }
        //    set
        //    {
        //        _altshortName = value;
        //    }
        //}

        private static List<Profession> _allProfession;

        public static List<Profession> AllProfessions
        {
            get
            {
                if (_allProfession == null)
                {
                    _allProfession = new List<Profession>();
                }
                return _allProfession;
            }
            set
            {
                _allProfession = value;

            }

        }

        #endregion Properties

        #region Constructor

        public Profession(Int32 Id_, Int32 Code_, String Name_, String shortName_)
        {
            Id = Id_;
            Code = Code_;
            Name = Name_;
            ShortName = shortName_;
            //AltName = altName_;
            //ShortName = altShortName;
        }

        public Profession()
        {
            
        }
        #endregion 

        #region Methods

        //public static Profession GetAllProfession(Int32 Code)
        //{
        //    Profession Result;

        //    var Profession= AllProfessions.FirstOrDefault(x => x.Code == Code);
        //    if (Profession != null)
        //    {
        //Result= new Profession(Profession.Id,Profession.Code,Profession.Name/*, Profession.AltName*/, Profession.ShortName /*, Profession.AltShortName*/);        
        //    }
        //    else
        //    {
        //        Result= new Profession();
        //    }
        //    return Result;
        //}

        #endregion Methods

        #region Logic

        #endregion Logic
    }
}