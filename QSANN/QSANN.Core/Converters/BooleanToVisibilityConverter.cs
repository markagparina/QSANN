﻿using System;
using System.Windows;
using System.Windows.Data;

namespace QSANN.Core.Converters
{
    public class BoolToVisibleOrHidden : IValueConverter
    {
        #region Constructors

        /// <summary>
        /// The default constructor
        /// </summary>
        public BoolToVisibleOrHidden()
        { }

        #endregion Constructors

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool bValue = (bool)value;
            if (bValue)
                return Visibility.Visible;
            else
                return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Visibility visibility = (Visibility)value;

            if (visibility == Visibility.Visible)
                return true;
            else
                return false;
        }

        #endregion IValueConverter Members
    }
}