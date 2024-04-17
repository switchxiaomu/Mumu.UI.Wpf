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
    public class PathIconButton : Button
    {
        static PathIconButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PathIconButton), new FrameworkPropertyMetadata(typeof(PathIconButton)));
        }

        public static readonly DependencyProperty ToBeSelectedProperty = DependencyProperty.Register("ToBeSelected"
            , typeof(bool), typeof(PathIconButton));
        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius"
            , typeof(CornerRadius), typeof(PathIconButton));
        public static readonly DependencyProperty PathDataProperty = DependencyProperty.Register("PathData"
            , typeof(PathGeometry), typeof(PathIconButton));
        public static readonly DependencyProperty PathWidthProperty = DependencyProperty.Register("PathWidth"
            , typeof(double), typeof(PathIconButton), new FrameworkPropertyMetadata(32d));
        public static readonly DependencyProperty MouseOverPathColorProperty = DependencyProperty.Register("MouseOverPathColor"
            , typeof(Brush), typeof(PathIconButton), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(233, 233, 233))));
        public static readonly DependencyProperty PressedPathColorProperty = DependencyProperty.Register("PressedPathColor"
            , typeof(Brush), typeof(PathIconButton), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(233, 233, 233))));
        public static readonly DependencyProperty NormalPathColorProperty = DependencyProperty.Register("NormalPathColor"
            , typeof(Brush), typeof(PathIconButton), new FrameworkPropertyMetadata(new SolidColorBrush(Color.FromRgb(233, 233, 233))));
        public static readonly DependencyProperty MouseOverBackgroundProperty = DependencyProperty.Register("MouseOverBackground"
            , typeof(Brush), typeof(PathIconButton));
        public static readonly DependencyProperty PressedBackgroundProperty = DependencyProperty.Register("PressedBackground"
            , typeof(Brush), typeof(PathIconButton));


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

        public double PathWidth
        {
            get { return (double)GetValue(PathWidthProperty); }
            set { SetValue(PathWidthProperty, value); }
        }

        public Brush NormalPathColor
        {
            get { return (Brush)GetValue(NormalPathColorProperty); }
            set { SetValue(NormalPathColorProperty, value); }
        }

        public Brush MouseOverPathColor
        {
            get { return (Brush)GetValue(MouseOverPathColorProperty); }
            set { SetValue(MouseOverPathColorProperty, value); }
        }

        public Brush MouseOverBackground
        {
            get { return (Brush)GetValue(MouseOverBackgroundProperty); }
            set { SetValue(MouseOverBackgroundProperty, value); }
        }

        public Brush PressedBackground
        {
            get { return (Brush)GetValue(PressedBackgroundProperty); }
            set { SetValue(PressedBackgroundProperty, value); }
        }
        public Brush PressedPathColor
        {
            get { return (Brush)GetValue(PressedPathColorProperty); }
            set { SetValue(PressedPathColorProperty, value); }
        }
        public bool ToBeSelected
        {
            get { return (bool)GetValue(ToBeSelectedProperty); }
            set { SetValue(ToBeSelectedProperty, value); }
        }
        #endregion
    }
}
