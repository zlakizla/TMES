using System;
using System.Drawing;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace TMES.Converters
{
    public class ColorToIntConverter : IValueConverter
    {
        
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            System.Windows.Media.Brush Result;
            System.Drawing.Color Color = System.Drawing.Color.FromArgb((int)value);
            var Colour = System.Windows.Media.Color.FromArgb(0xFF, Color.R, Color.G, Color.B);
            Result = new SolidColorBrush(Colour);
            return Result;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //if (value != null && value.ToString() == NewItemPlaceholderName)
         //       return DependencyProperty.UnsetValue;
            return value;
        }
    }
}