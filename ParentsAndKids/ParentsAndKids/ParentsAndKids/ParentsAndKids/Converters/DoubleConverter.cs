﻿using System;
using System.Globalization;
using Xamarin.Forms;

namespace ParentsAndKids.Converters {
    public class DoubleConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is double)
                return value.ToString();
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (double.TryParse(value as string, out double doub))
                return doub;
            return value;
        }
    }
}
