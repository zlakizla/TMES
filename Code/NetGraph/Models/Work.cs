

using System;
using System.Collections.Generic;

public enum WorkType
{
    Empty
}

/// <summary>
/// Класс описывает объекты типа "Работа", которые представляют единицу отображения на календарном графике.
/// </summary>
//public class Work : IStorable
//{

//    public static Int32 IdCounter;
  

//    #region Properties

//    /// <summary>
//    /// Первичный ключ
//    /// </summary>
//    private String _id;
//    public String Id
//    {
//        get
//        {
//            return _id;
//        }
//        set
//        {
//            _id = value;
//        }
//    }

//    /// <summary>
//    /// Тип работы
//    /// </summary>
//    private WorkType? _type;
//    public WorkType Type
//    {
//        get
//        {
//            if(_type == null)
//            {
//                return WorkType.Empty;
//            }
//            return _type.Value;
//        }
//        set
//        {
//            _type = value;
//        }
//    }

//    /// <summary>
//    /// Список блоков, к которому относится данная работа. Может указывать на один блок или на несколько блоков.
//    /// </summary>
//    private List<Element> _target;
//    public List<Element> Target
//    { 
//        get
//        {
//            if(_target == null)
//            {
//                _target = new List<Element>();
//            }
//            return _target;
//        }
//        set
//        {
//            _target = value;
//        }
//    }

//    private Department _department;
//    public Department Department
//    {
//        get
//        {
//            return _department;
//        }
//        set
//        {
//            _department = value;
//        }
   
//    }

//    private Double _duration;
//    public Double Duration
//    {
//        get
//        {
//            return _duration;
//        }
//        set
//        {
//            _duration = value;
//        }
//    }



//    public Int32 ExecutionChain { get; set; }

//    public String Name { get; set; }
//    public String Cypher { get; set; }


//    #endregion Properties

//    #region Constructor

//    /// 
//    /// <param name="Duration"></param>
//    /// <param name="Target"></param>
//    /// <param name="Profession"></param>
//    /// <param name="Departament"></param>
//    public Work(Double Duration_, Int32 Target_, Int32 Profession_, Department Department_)
//    {
//        this.Id = Work.IdCounter++.ToString();
//        this.Duration = Duration_;
//        this.Department = Department_;
//    }

//    //:: Конструктор корневых работ
//    public Work(String Name_Oper, Int32 Cypher, Int32 Duration)
//    {
//        this.Name = Name_Oper;
//        this.Cypher = Cypher.ToString();
//        this.Duration = Duration;
//    }

//    public Work()
//    {

//    }

//    ~Work()
//    {

//    }

//    public virtual void Dispose()
//    {

//    }
//    #endregion Constructor



//    //private List<Element> ContentBlocks{ get;  set;} 
//    //public List<Work> CurrentWorks{ get;  set;} 

//    //private float id(automatically){ get;  set;} 
//    //private string NameProfession{ get;  set;} 
//    //private List<Work> Prerequest{ get;  set;} 
//    //private Priority Priority{ get;  set;} 
//    //private int Profession{ get;  set;} 
	
//    //private float Time end{ get;  set;} 
//    //private float Time start{ get;  set;} 

//    //public Element Element;
//    //public Worker  Worker ;

//    #region Methods

//    /// <summary>
//    /// Метод получает записи нулевого уровня  
//    /// </summary>
   
//    public void CalculateDuration()
//    {

//    }

//    public bool Delete()
//    {

//        return false;
//    }

//    public void GetContentBlocks()
//    {

//    }

//    public void GetCurrentWorks(){

//    }

//    public bool Insert(){

//        return false;
//    }

//    public IStorable Select(){

//        return null;
//    }

//    public List<IStorable> SelectAll(){

//        return null;
//    }

//    public void SumDepartment(){

//    }

//    public void SumProfession(){

//    }

//    public bool Update(){

//        return false;
//    }

//    #endregion Methods

//    #region Logic

  

//    #endregion Logic 
//}