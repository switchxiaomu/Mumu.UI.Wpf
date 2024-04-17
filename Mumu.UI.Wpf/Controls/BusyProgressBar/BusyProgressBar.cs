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
    public enum ProgressBarType
    {
        Standard,
        Circular
    }

    public class BusyProgressBar : ProgressBar
    {
        static BusyProgressBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BusyProgressBar), new FrameworkPropertyMetadata(typeof(BusyProgressBar)));
        }

        public static readonly DependencyProperty ProgressBarStyleProperty = DependencyProperty.Register("ProgressBarStyle"
            , typeof(ProgressBarType), typeof(BusyProgressBar));
        public static readonly DependencyProperty DisplayTextProperty = DependencyProperty.Register("DisplayText"
            , typeof(bool), typeof(BusyProgressBar));

        #region Properties
        public ProgressBarType ProgressBarStyle
        {
            get { return (ProgressBarType)GetValue(ProgressBarStyleProperty); }
            set { SetValue(ProgressBarStyleProperty, value); }
        }
        public bool DisplayText
        {
            get { return (bool)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }
        #endregion
    }
}
