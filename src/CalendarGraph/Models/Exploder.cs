
/// <summary>
/// Класс, реализующий процедуру разузлования
/// </summary>
using System;
using System.Collections.Generic;


//public class Exploder
//{

//    #region Properties

//    /// <summary>
//    /// Список головных позиций в заказе
//    /// </summary>
//    private List<Element> _rootElements;
//    public List<Element> RootElements
//    {
//        get
//        {
//            if (_rootElements == null)
//            {
//                _rootElements = new List<Element>();
//            }
//            return _rootElements;
//        }
//        set
//        {
//            _rootElements = value;
//        }
//    }

//    /// <summary>
//    ///  Все позиции, входящие в заказ
//    /// </summary>
//    private  List<Element> _elements;
//    public List<Element> Elements
//    {
//        get
//        {
//            if (_elements == null)
//            {
//                _elements = new List<Element>();
//            }
//            return _elements;
//        }
//        set
//        {
//            _elements = value;
//        }
//    }

//    /// <summary>
//    /// Номер заказа, по которому происходило разузловпние
//    /// </summary>
//    private String _order;
//    public String Order
//    {
//        get
//        {
//            return _order;
//        }
//        set
//        {
//            _order = value;
//        }
//    }

//    #endregion Properties

//    #region Constructor

//    /// <summary>
//    /// Конструктор
//    /// </summary>
//    /// <param name="Order_">Номер заказа (Z, Zakaz)</param>
//    public Exploder(String Order_)
//    {
//        this.Order = Order_;
//    }

//    #endregion Constructor

//    #region Methods

//    /// <summary>
//    /// Разузловывает заказ с учетом ВПР
//    /// </summary>
//    /// <returns></returns>
//    public void Explode()
//    {
       
//        RootElements = GetRootBlocks();
//        for (int i = 0; i < RootElements.Count; i++)
//        {
//            var Branch = Explode(RootElements[i].Index, RootElements[i].Denotation, "Branch" + i);
//            for (int j = 0; j < Branch.Count; j++)
//            {
//                Elements.Add(Branch[j]);
//            }
//        }
//    }

//    /// <summary>
//    /// Разузловывает блок
//    /// </summary>
//    /// <param name="Index">Индекс блока (IND)</param>
//    /// <param name="Denotation">Обозначение блока (PICH)</param>
//    /// <returns></returns>
//    private List<Element> Explode(String Index_, String Denotation_, String BranchName_)
//    {
//        var Result = new List<Element>();

////        using (var Cmd = new SqlCommand("", DBManager.MainConn))
////        {
////            Cmd.Parameters.AddWithValue("Order", Order);
////            Cmd.Parameters.AddWithValue("Index", Index_);
////            Cmd.Parameters.AddWithValue("Denotation", Denotation_);
////            Cmd.Parameters.AddWithValue("Id", BranchName_);
////            Cmd.CommandText = @"EXEC ConstDocs.dbo.RazuzlovM3 @Id, @Index, @Denotation, @Order";
////            Cmd.ExecuteNonQuery();

////            Cmd.CommandText = @"SELECT *
////                                FROM [ConstDocs].[dbo].[tempPOSPRIMB]
////                                WHERE id = @Id";
            
////            using (SqlDataReader dr = Cmd.ExecuteReader())
////            {
////                while (dr.Read())
////                {
////                    var RawType = dr["TIP"].ToString();
////                    var Type = EnumHelper.FindInDesc<ElementType>(RawType);
////                    var Index = dr["IND1"].ToString();
////                    var Denotation = dr["PICH"].ToString();
////                    var Quantity = dr["KSP"].ToString();
////                    var Depth = (Int32)dr["Depth"];

////                    //:: Разрешить ссылки 
////                    var ParentLevel = Result.FindAll(x => Convert.ToInt32(x.Depth) == Depth - 1);
////                    var ParentIndex = dr["IND2"].ToString().Trim();
////                    var ParentDenotation = dr["P2NI"].ToString();
////                    var Parent = ParentLevel.Find(x => x.Index == ParentIndex && x.Denotation == ParentDenotation);
          
////                    var Block = new Element(Type, Index, Denotation, Parent, Order, Quantity);
////                    Block.Depth = Depth.ToString();

////                    Result.Add(Block);
////                }
////            }
////        }

//        return Result;
//    }


//    /// <summary>
//    /// Очистить результаты предыдущего разузлования по шаблону '@Template%'
//    /// </summary>
//    /// <param name="Template"></param>
//    public void ClearPreviousExplosion(String Template)
//    {
////        using (var Cmd = new SqlCommand("", DBManager.MainConn))
////        {
////            Cmd.CommandText = @"DELETE FROM ConstDocs.dbo.tempPOSPRIMB 
////                                WHERE id LIKE @Template";
////            Cmd.Parameters.AddWithValue("Template", Template + "%");

////            Cmd.ExecuteNonQuery();
////        }
//    }

//    #endregion Methods

//    #region Logic

//    private List<Element> GetRootBlocks()
//    {   
//        var Result = new List<Element>();
//        using (var Cmd = new SqlCommand("", DBManager.MainConn))
//        {
//            Cmd.Parameters.AddWithValue("Order", Order);
//            Cmd.CommandText = @"SELECT T_CH,
//                                       IND_CH,
//                                       OBOZN_CH,
//                                       KSP
//                                FROM [ZakazVPR]
//                                WHERE Z = @Order";
//            using (SqlDataReader dr = Cmd.ExecuteReader())
//            {
//                while(dr.Read())
//                {
//                    var RawType = dr["T_CH"].ToString();
//                    var Type = EnumHelper.FindInDesc<ElementType>(RawType);
//                    var Index = dr["IND_CH"].ToString();
//                    var Denotation = dr["OBOZN_CH"].ToString();
//                    var Quantity = dr["KSP"].ToString();
//                    var RootBlock = new Element(Type, Index, Denotation, Element.Root, Order, Quantity);
//                    Result.Add(RootBlock);
//                }
//            }
//        }
//        return Result;
//    }

//    #endregion Logic


//}