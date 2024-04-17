using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mumu.UI.Wpf
{
    public class ThresholdRangeBar : RangeBase
    {
        private FrameworkElement Indicator;

        static ThresholdRangeBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ThresholdRangeBar), new FrameworkPropertyMetadata(typeof(ThresholdRangeBar)));
        }

        public static readonly DependencyProperty CornerRadiusProperty = DependencyProperty.Register("CornerRadius"
            , typeof(CornerRadius), typeof(ThresholdRangeBar));
        public static readonly DependencyProperty InnerCornerRadiusProperty = DependencyProperty.Register("InnerCornerRadius"
            , typeof(CornerRadius), typeof(ThresholdRangeBar));
        public static readonly DependencyProperty IndicatorLowBrushProperty = DependencyProperty.Register("IndicatorLowBrush"
            , typeof(Brush), typeof(ThresholdRangeBar));
        public static readonly DependencyProperty IndicatorHighBrushProperty = DependencyProperty.Register("IndicatorHighBrush"
            , typeof(Brush), typeof(ThresholdRangeBar));
        public static readonly DependencyProperty CurrentValueProperty = DependencyProperty.Register("CurrentValue"
            , typeof(double), typeof(ThresholdRangeBar), new PropertyMetadata(OnCurrentValueChanged));
        public static readonly DependencyProperty ThresholdValueProperty = DependencyProperty.Register("ThresholdValue"
            , typeof(double), typeof(ThresholdRangeBar), new PropertyMetadata(OnCurrentValueChanged));

        private static void OnCurrentValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ThresholdRangeBar bar = d as ThresholdRangeBar;
            if (bar == null)
            {
                return;
            }

            var halfWidth = bar.Width / 2;
            var perWidth = halfWidth / ((double)bar.GetValue(ThresholdValueProperty) * 2);

            var newWidth = (double)e.NewValue * perWidth;

            if(newWidth > 0)
            {
                newWidth = Math.Min(newWidth, halfWidth);
                bar.Indicator?.SetValue(Canvas.LeftProperty, halfWidth);
                bar.Indicator?.SetValue(FrameworkElement.WidthProperty, newWidth);
            }
            else
            {
                newWidth = -Math.Max(newWidth, -halfWidth);
                bar.Indicator?.SetValue(Canvas.LeftProperty, halfWidth - newWidth);
                bar.Indicator?.SetValue(FrameworkElement.WidthProperty, newWidth);
            }

            Brush indicatorBrush = bar.GetValue(IndicatorLowBrushProperty) as Brush;

            double thresholdWidth = (double)bar.GetValue(ThresholdValueProperty) * perWidth;
            if(thresholdWidth is double.NaN)
            {
                thresholdWidth = 0;
            }

            if(newWidth > thresholdWidth)
            {
                indicatorBrush = bar.GetValue(IndicatorHighBrushProperty) as Brush;
            }
            else
            {
                indicatorBrush = bar.GetValue(IndicatorLowBrushProperty) as Brush;
            }

            bar.SetValue(ForegroundProperty, indicatorBrush);
        }

        #region Properties
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }
        public CornerRadius InnerCornerRadius
        {
            get { return (CornerRadius)GetValue(InnerCornerRadiusProperty); }
            set { SetValue(InnerCornerRadiusProperty, value); }
        }
        public Brush IndicatorLowBrush
        {
            get { return (Brush)GetValue(IndicatorLowBrushProperty); }
            set { SetValue(IndicatorLowBrushProperty, value); }
        }
        public Brush IndicatorHighBrush
        {
            get { return (Brush)GetValue(IndicatorHighBrushProperty); }
            set { SetValue(IndicatorHighBrushProperty, value); }
        }
        public double CurrentValue
        {
            get { return (double)GetValue(CurrentValueProperty); }
            set { SetValue(CurrentValueProperty, value); }
        }
        public double ThresholdValue
        {
            get { return (double)GetValue(ThresholdValueProperty); }
            set { SetValue(ThresholdValueProperty, value); }
        }
        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.Indicator = GetTemplateChild("Indicator") as FrameworkElement;
            this.Indicator?.SetValue(System.Windows.Controls.Canvas.LeftProperty, this.Width / 2);
            this.Indicator?.SetValue(FrameworkElement.HeightProperty, this.Height - (this.BorderThickness.Top + this.BorderThickness.Bottom));
        }
    }
}
