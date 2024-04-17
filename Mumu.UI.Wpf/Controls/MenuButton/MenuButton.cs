using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mumu.UI.Wpf
{
    public class MenuButton : Button
    {
        static MenuButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(MenuButton), new FrameworkPropertyMetadata(typeof(MenuButton)));
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius"
            , typeof(CornerRadius), typeof(MenuButton));
        public static readonly DependencyProperty PathDataProperty = DependencyProperty.Register("PathData"
            , typeof(PathGeometry), typeof(MenuButton));
        public static readonly DependencyProperty IsSelectedProperty = DependencyProperty.Register("IsSelected"
            , typeof(bool), typeof(MenuButton));
        public static readonly DependencyProperty ToBeSelectedProperty = DependencyProperty.Register("ToBeSelected"
            , typeof(bool), typeof(MenuButton));

        #region Properties
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public PathGeometry PathData
        {
            get { return (PathGeometry)GetValue(PathDataProperty); }
            set { SetValue(PathDataProperty, value); }
        }
        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); }
        }

        public bool ToBeSelected
        {
            get { return (bool)GetValue(ToBeSelectedProperty); }
            set { SetValue(ToBeSelectedProperty, value); }
        }
        #endregion
    }
}
