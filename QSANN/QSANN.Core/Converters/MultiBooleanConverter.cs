using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace QSANN.Core.Converters
{
    public class MultiBooleanConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (values.Any(value => !bool.TryParse(value.ToString(), out bool result)))
            {
                return Binding.DoNothing;
            }

            bool a = (bool)values[0];
            bool b = (bool)values[1];

            return a && b ? Visibility.Visible : Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}