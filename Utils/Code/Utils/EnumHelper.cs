using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Utils
{

    ///<summary>
    /// Класс, расширяющий возможности работы перечислений (enum) с помощью атрибутов
    /// Позволяет делать String-перечисления
    ///</summary>
    public static class EnumHelper
    {
        ///<summary>
        /// Получить список всех элементов перечисления T
        ///</summary>
        public static List<TEnum> GetAllItems<TEnum>()
        where TEnum : struct
        {
            var Result = new List<TEnum>();
            foreach (object item in Enum.GetValues(typeof(TEnum)))
            {
                Result.Add((TEnum)item);
            }
            return Result;
        }

        ///<summary>
        /// Получить словарь соответствия enum и их описаний
        ///</summary>
        public static Dictionary<TEnum, String> GetDescDictionary<TEnum>()
        where TEnum : struct
        {
            var Result = new Dictionary<TEnum, String>();
            foreach (object item in Enum.GetValues(typeof(TEnum)))
            {
                Result.Add((TEnum)item, ((Enum)item).GetDesc());
            }
            return Result;
        }

        ///<summary>
        /// Получить описание конкретного элемента перечисления
        ///</summary>
        public static String GetDesc(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static Int32 Value(this Enum value)
        {
            return Convert.ToInt32(value);
        }

        public static String Representation(this Enum value)
        {
            return Convert.ToInt32(value).ToString();
        }

        public static TEnum FindIn<TEnum>(String Value) where TEnum : struct
        {
            var Values = Enum.GetValues(typeof(TEnum));
            foreach (TEnum Item in Values)
            {
                if (Item.ToString() == Value)
                {
                    return Item;
                }
            }
            throw new KeyNotFoundException("Value " + Value + " not found.");
        }


        /// <summary>
        /// Найти значение перечисления TEnum по атрибуту [Description], равному Desc
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="Desc"></param>
        /// <returns></returns>
        public static TEnum FindInDesc<TEnum>(String Desc) where TEnum : struct
        {
            var Values = Enum.GetValues(typeof(TEnum));
            foreach (TEnum Item in Values)
            {
                if ((Item as Enum).GetDesc() == Desc)
                {
                    return Item;
                }
            }
            throw new KeyNotFoundException("Desc " + Desc + " not found.");
        }



    }
}