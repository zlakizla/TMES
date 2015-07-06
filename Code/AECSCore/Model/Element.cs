using System;
using System.ComponentModel;

namespace AECSCore
{
    public enum ElementType
    {
        [Description("Z")]
        Empty,
        [Description("И")]
        Document,
        [Description("Б")]
        Block,
        [Description("Д")]
        Detail,
        [Description("Н")]
        Normalized,
        [Description("П")]
        Purchased,
        [Description("К")]
        [Obsolete] // Крепеж теперь относится к покупным позициям
        Connector
    }

    /// <summary>
    /// PODO : Базовые класс для заводских позиций, состоящий из типа (T), индекса (IND) и обозначения (PICH)
    /// </summary>
    public class Element
    {
        #region Constants

        /// <summary>
        /// Ограничения, обусловленные ограничениями большой машины
        /// </summary>

        public static readonly Int32 PurchasedMaxIndexLength = 0;
        public static readonly Int32 PurchasedMaxDenotationLength = 47;
        public static readonly Int32 MaxIndexLength = 4;
        public static readonly Int32 MaxDenotationLength = 43;

        #endregion Constants 

        #region Properties
        private String _index;
        /// <summary>
        /// Индекс позиции (не более 4 символов, для покупных всегда равен нулю)
        /// </summary>
        public String Index
        {
            get
            {
                if (_index == null)
                {
                    return "";
                }
                return _index;
            }
            set
            {
                if (this.Type == ElementType.Purchased)
                {
                    if (value.Length > PurchasedMaxIndexLength)
                    {
                        throw new ArgumentException("Неправильно задан индекс позиции - у покупных позиций он не может быть больше" 
                            + PurchasedMaxIndexLength.ToString());
                    }
                }
                if (value.Length > MaxIndexLength)
                {
                    throw new ArgumentException(@"Неправильно задан индекс позиции - он не может быть больше" + 
                            MaxIndexLength.ToString() + "символов");
                }
                _index = value;
            }
        }

        private String _denotation;
        /// <summary>
        /// Обозначение (PICH) (не более 47 символов для покупных позиций и 43 для всех остальных)
        /// </summary>
        public String Denotation
        {
            get
            {
                if (_denotation == null)
                {
                    return "";
                }
                return _denotation;
            }
            set
            {
                if (this.Type == ElementType.Purchased)
                {
                    if (value.Length > PurchasedMaxDenotationLength)
                    {
                        throw new ArgumentException(@"Неправильно задано обозначение - оно не может быть больше" +
                            PurchasedMaxDenotationLength.ToString() + "символов для покупных.");
                    }
                }
                else
                {
                    if (value.Length > MaxDenotationLength)
                    {
                        throw new ArgumentException(@"Неправильно задано обозначение - оно не может быть больше" +
                            MaxDenotationLength.ToString() + "символов для непокупных.");
                    }
                }
                _denotation = value;
            }
        }

        private ElementType _type;
        /// <summary>
        /// Тип
        /// </summary>
        public ElementType Type
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }
        #endregion Properties

        #region Constructor

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="Type_">Тип (TIP)</param>
        /// <param name="Index_">Индекс (IND)</param>
        /// <param name="Denotation_">Обозначение (PICH)</param>
        public Element(ElementType Type_, String Index_, String Denotation_)
        {
            this.Type = Type_;
            this.Index = Index_;
            this.Denotation = Denotation_;
        }

        /// <summary>
        /// Конструктор пустой позиции
        /// </summary>
        public Element()
        {
            this.Type = ElementType.Empty;
            this.Index = "";
            this.Denotation = "";
        }

        #endregion Constructor
    }
}