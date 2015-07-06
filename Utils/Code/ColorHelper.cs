using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Utils
{
    public static class ColorHelper
    {
        public static Color FromInt(Int32 Code)
        {
            byte[] ARBG = BitConverter.GetBytes(Code);
            Color Result = Color.FromArgb(ARBG[3], ARBG[2], ARBG[1], ARBG[0]);
            return Result;
        }

        public static Int32 ToInt(this Color Color)
        {

            var ARBG = new Byte[] { Color.B, Color.G, Color.R, Color.A };
            var Result = BitConverter.ToInt32(ARBG, 0);
  
            return Result;
        }

    }
}
