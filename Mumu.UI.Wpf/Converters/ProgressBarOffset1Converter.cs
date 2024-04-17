using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace Mumu.UI.Wpf
{
    public class ProgressBarOffset1Converter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var min = (double)values[0];
            var max = (double)values[1];
            var value = (double)values[2];
            var percent = Math.Round((value - min) / (max - min), 2);

            var totalWidth = (double)values[3];
            var actualWidth = (double)values[4];

            var left = (totalWidth - actualWidth) / 2;
            var half = totalWidth * percent;
            var result = (half - left) / actualWidth;
            result = result < 0 ? 0 : result > 1 ? 1 : result;
            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return new object[] { DependencyProperty.UnsetValue, DependencyProperty.UnsetValue };
        }
    }
}
