﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace Mumu.UI.Wpf
{
    public class BrushToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return Colors.Transparent;
            if (value is SolidColorBrush)
                return (value as SolidColorBrush).Color;
            else if (value is LinearGradientBrush)
                return (value as LinearGradientBrush).GradientStops[0].Color;
            else if (value is RadialGradientBrush)
                return (value as RadialGradientBrush).GradientStops[0].Color;
            else
                return Colors.Transparent;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
