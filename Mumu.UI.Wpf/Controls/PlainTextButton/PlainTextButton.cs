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
using static System.Net.Mime.MediaTypeNames;

namespace Mumu.UI.Wpf
{
    public class PlainTextButton : Button
    {
        static PlainTextButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(PlainTextButton), new FrameworkPropertyMetadata(typeof(PlainTextButton)));
        }

        public static readonly DependencyProperty ToBeSelectedProperty = DependencyProperty.Register("ToBeSelected"
            , typeof(bool), typeof(PlainTextButton));

        #region Properties
        public bool ToBeSelected
        {
            get { return (bool)GetValue(ToBeSelectedProperty); }
            set { SetValue(ToBeSelectedProperty, value); }
        }
        #endregion
    }
}
