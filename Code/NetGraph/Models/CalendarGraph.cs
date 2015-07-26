

using System.Collections.Generic;
using System;
using System.Data.SqlClient;
using AECSCore;
public class CalendarGraph
{
    #region Properties

    private Order _order;
    public Order Order
    {
        get
        {
            return _order;
        }
        set
        {
            _order = value;
        }
    }

    /// <summary>
    /// Zero-level works 
    /// </summary>
    private List<Work> _rootWorks;
    public List<Work> RootWorks
    {
        get
        {
            if (_rootWorks == null)
            {
                _rootWorks = new List<Work>();
            }
            return _rootWorks;
        }
        set
        {
            _rootWorks = value;
        }

    }

    private List<Element> _elements;
    public List<Element> Elements
    {
        get
        {
            if (_elements == null)
            {
                _elements = new List<Element>();
            }
            return _elements;
        }
        set
        {
            _elements = value;
        }
    }


    #endregion Properties

    #region Constructor

    public CalendarGraph(Order Order)
    {
        this.Order = Order;

       /// OrderExplode();
      ///  CacheExpandResults();
    }

    #endregion Constructor

    #region Methods

    /// <summary>
    /// Получить корневые работы по 
    /// </summary>
    /// <returns></returns>
    public List<Work> GetRoot()
    {
        var Result = new List<Work>();
        //var StandartWorks = GetStandartWorks();
        //var PreparationWorks = GetPreparationWorks();
        //var MainWorks = GetMainWorks();

        //for (int i = 0; i < StandartWorks.Count; i++)
        //{
        //    Result.Add(StandartWorks[i]);
        //}

        //for (int i = 0; i < PreparationWorks.Count; i++)
        //{
        //    Result.Add(PreparationWorks[i]);
        //}

        //for (int i = 0; i < MainWorks.Count; i++)
        //{
        //    Result.Add(MainWorks[i]);
        //}
        //RootWorks = Result;
        return Result;

    }


    #endregion Methods

    #region Logic

    /// <summary>
    /// Закэшировать результаты разузлования в таблицу NetGraphExplode для быстродействия.
    /// Берутся все значения из tempPOSPRIMB, начинающиеся с 'Branch'.
    /// TODO : Требуется рассмотрение мультипользовательского режима. 
    /// </summary>
    private void CacheExpandResults()
    {
        //        using (var Cmd = new SqlCommand("", DBManager.MainConn))
        //        {
        //            Cmd.CommandText = @"
        //                                TRUNCATE TABLE ConstDocs.dbo.NetGraphExplode;
        //                                INSERT INTO ConstDocs.dbo.NetGraphExplode
        //                                SELECT 
        //		                                TIP,
        //		                                IND1,
        //		                                PICH,
        //		                                IND2,
        //		                                P2NI,
        //		                                Z,
        //		                                NS,
        //		                                KSP,
        //		                                KSZ,
        //		                                Depth,
        //		                                id,
        //		                                Parent,
        //                                        IND1 + PICH AS Obozn
        //                                 FROM ConstDocs.dbo.tempPOSPRIMB 
        //                                WHERE id LIKE 'Branch%';
        //                                CREATE INDEX Obozn ON ConstDocs.dbo.NetGraphExplode
        //                                (Obozn)
        //                                WITH DROP_EXISTING ;
        //                                CREATE INDEX INDnPICH ON ConstDocs.dbo.NetGraphExplode
        //	                            (IND1)
        //	                            WITH DROP_EXISTING ;";
        //            Cmd.ExecuteNonQuery();
        //        }
    }

    /// <summary>
    /// Метод получает список работ, стандартных для каждого заказа (конкурс, торги, оплата, закупки)
    /// </summary>
    /// <returns></returns>
    private List<Work> GetStandartWorks()
    {
        var Result = new List<Work>();
        return Result;
    }

    /// <summary>
    /// /Метод получает список работ, выполняемых цехами вспомогательного производства
    /// </summary>
    /// <returns></returns>
    private List<Work> GetPreparationWorks()
    {
        var Result = new List<Work>();

//        using (var Cmd = new SqlCommand("", DBManager.MainConn))
//        {
//            Cmd.CommandText = @"  SELECT c,z,SUM(NV) as Duration
//                              FROM [ConstDocs].[dbo].[BlocksByOperation]
//                              WHERE C IN (1,2,3,5,8,12,38,44)
//                              GROUP BY  c,z
//                              ORDER BY C ASC
//                            "; //WHERE id LIKE 'Branch%' AND C IN (1,2,3,5,8,12,38,44)
//            using (SqlDataReader dr = Cmd.ExecuteReader())
//            {
//                while (dr.Read())
//                {
//                    var Duration = Convert.ToDouble(dr["Duration"]);
//                    var ShortName = dr["C"].ToString();
//                    //  var TargetDepartment = Department.GetByShortName(ShortName);
//                    //   var Work = new Work(Duration, -1, -1, TargetDepartment);
//                    //  Result.Add(Work); 
//                }
//            }
//        }
        return Result;
    }

    /// <summary>
    /// Метод получает список работ, выполняемых цехами основного производства
    /// </summary>
    /// <returns></returns>
    private List<Work> GetMainWorks()
    {
        var Result = new List<Work>();
        return Result;
    }

    private void OrderExplode()
    {
        //var RequestedOrder = new Exploder(Order);
        //RequestedOrder.ClearPreviousExplosion("Branch");
        //RequestedOrder.Explode();
        //Elements = RequestedOrder.Elements;
    }


    #endregion Logic
}