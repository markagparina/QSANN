using System;
using System.Globalization;
using System.Windows.Data;

namespace QSANN.Core.Converters
{
    public class StringToBooleanConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return parameter?.ToString() == value?.ToString();

            //if (bool.TryParse(value?.ToString(), out bool result) && result)
            //{
            //    return parameter.ToString();
            //}

            //return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (bool.TryParse(value.ToString(), out bool result) && result)
            {
                return parameter.ToString();
            }

            return Binding.DoNothing;
        }
    }
}