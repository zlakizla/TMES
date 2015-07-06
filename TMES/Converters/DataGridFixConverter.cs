using System;
using System.Windows;
using System.Windows.Data;

namespace TMES.Converters
{
    public class DataGridFixConverter : IValueConverter
    {
        private const string NewItemPlaceholderName = "{NewItemPlaceholder}";
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null && value.ToString() == NewItemPlaceholderName)
                return DependencyProperty.UnsetValue;
            return value;
        }
    }
}