using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Core
{
 /*   public enum ElementType
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
    }*/

    /// <summary>
    /// PODO : Базовые класс для заводских позиций, состоящий из типа (T), индекса (IND) и обозначения (PICH)
    /// </summary>
    public class Element //: Item, IExplodable
    {
        /*
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

        private ICollection<Element> _content;
        public ICollection<Element> Content
        {
            get
            {
                if(_content == null)
                {
                    _content = new List<Element>();
                }
                return _content;
            }
            set
            {
                _content = value;
            }
        }

        public Element Parent
        {
            get;
            set;
        }

        public Int32 Depth { get; set; }

        public void Explode(IExploder Exploder)
        {
            Exploder.Explode(this);
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

        public override String ToString()
        {
            if(Index == "0000" && Denotation == "00000000000")
            {
                return "Root";
            }
            else
            {
                return Index + Denotation;
            }
        }

        public static Element Root()
        {
            var Result = new Element();
            Result.Index = "0000";
            Result.Denotation = "00000000000";
            Result.Depth = -1;

            return Result;
        }

        public Element FindAncestor(Element Parent)
        {
            var Result = this.Parent;
            while(Result != Parent)
            {

                Result = Result.Parent;
                if(Result == null)
                {
                    break;
                }
            }
            return Result;
        }

        public static bool operator ==(Element First, Element Second)
        {
            if (ReferenceEquals(First, Second))
            {
                return true;
            }
            if(ReferenceEquals(First, null))
            {
                return false;
            }
            if (ReferenceEquals(null, Second))
            {
                return false;
            }
            if(First.Index != Second.Index)
            {
                return false;
            }
            if (First.Depth != Second.Depth)
            {
                return false;
            }
            if (First.Denotation != Second.Denotation)
            {
                return false;
            }

            return true;
        }

        public static bool operator !=(Element First, Element Second)
        {
            if (ReferenceEquals(First, Second))
            {
                return false;
            }
            if (ReferenceEquals(First, null))
            {
                return true;
            }
            if (ReferenceEquals(null, Second))
            {
                return true;
            }
            if (First.Index != Second.Index)
            {
                return true;
            }
            if (First.Depth != Second.Depth)
            {
                return true;
            }
            if (First.Denotation != Second.Denotation)
            {
                return true;
            }

            return false;
        }*/
    }
}