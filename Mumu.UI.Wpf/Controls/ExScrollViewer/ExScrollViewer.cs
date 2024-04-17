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
    public class ExScrollViewer : ScrollViewer
    {
        static ExScrollViewer()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ExScrollViewer), new FrameworkPropertyMetadata(typeof(ExScrollViewer)));
        }

        public double VerticalOffsetEx
        {
            get { return (double)GetValue(VerticalOffsetExProperty); }
            set { SetValue(VerticalOffsetExProperty, value); }
        }

        public static readonly DependencyProperty VerticalOffsetExProperty =
            DependencyProperty.Register("VerticalOffsetEx", typeof(double), typeof(ExScrollViewer), new PropertyMetadata(0d, VerticalOffsetExChangedCallback));

        private static void VerticalOffsetExChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ExScrollViewer scrollViewer = d as ExScrollViewer;
            scrollViewer.ScrollToVerticalOffset((double)e.NewValue);
        }
    }
}
