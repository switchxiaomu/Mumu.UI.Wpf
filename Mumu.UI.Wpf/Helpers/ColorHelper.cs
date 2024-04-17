using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Mumu.UI.Wpf
{
    public class ColorHelper
    {
        #region IsCheckedBackgroundColor
        public static Brush GetIsCheckedBackgroundColor(DependencyObject obj)
        {
            return (Brush)obj.GetValue(IsCheckedBackgroundColorProperty);
        }

        public static void SetIsCheckedBackgroundColor(DependencyObject obj, bool value)
        {
            obj.SetValue(IsCheckedBackgroundColorProperty, value);
        }

        public static readonly DependencyProperty IsCheckedBackgroundColorProperty =
            DependencyProperty.RegisterAttached("IsCheckedBackgroundColor", typeof(Brush), typeof(ColorHelper));
        #endregion
    }
}
