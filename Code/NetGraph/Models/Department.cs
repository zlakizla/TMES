using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;
using Utils;

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
           // if (ColorCode < 0)
          //  {
           //     return Color.FromArgb(100, 100, 100);
          // // }
          //  else
          //  {
                return Color.FromArgb(ColorCode);
          //  }
        }
        set
        {
            _color = value;
        }
    }

    

    [NotMapped]
    public String CssColor
    {
        get
        {
            return "white";
           // return Color.ToCss();
        }
    }

    public Int32 ColorCode { get; set; }

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
        var AllDepartments = NetGraph.ViewModels.MainViewModel.Departments;
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

    #endregion Methods

    #region Logic


    #endregion Logic

}
