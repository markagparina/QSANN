﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace QSANN.Core.Converters
{
    public class InverseBooleanToVisibilityConverter : IValueConverter
    {
        #region Constructors

        /// <summary>
        /// The default constructor
        /// </summary>
        public InverseBooleanToVisibilityConverter()
        { }

        #endregion Constructors

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool bValue = (bool)value;
            if (!bValue)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;

            if (visibility == Visibility.Visible)
                return false;
            else
                return true;
        }

        #endregion IValueConverter Members
    }
}