using System;
using System.Drawing;
using System.Reflection;

namespace Utils
{

    [System.AttributeUsage(System.AttributeTargets.Field)]
    ///<summary>
    /// Атрибут для полей Enum, принимает параметры RGB для задания соответствия между членом перечисления и объектом Color. 
    ///</summary>
    public class ColorAttribute : System.Attribute
    {
        public Color Color;
        public ColorAttribute(Int32 Red, Int32 Green, Int32 Blue)
        {
            this.Color = Color.FromArgb(Red, Green, Blue);
        }
    }

    ///<summary>
    /// Класс расширения, реализующий преобразование Enum в Color
    ///</summary>
    public static class EnumToColorConverter
    {
        ///<summary>
        /// Метод расширения, позволяющий преобразовать Enum с атрибутом ColorAttribute в объект типа Color.
        ///</summary>
        public static Color ToColor(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            ColorAttribute[] Attributes = (ColorAttribute[])fi.GetCustomAttributes(typeof(ColorAttribute), false);
            if (Attributes != null && Attributes.Length > 0)
            {
                return Attributes[0].Color;
            }
            else
            {
                throw new InvalidCastException("ColorAttribute required for Enum field for EnumToColor conversion");
            }
        }
    }
}