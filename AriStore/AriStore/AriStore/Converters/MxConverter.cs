﻿namespace AriStore.Converters
{
    using System;
    using System.Globalization;
    using Xamarin.Forms;

    public class MxConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            
            return (int)value == 1?"+ ":"- ";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
