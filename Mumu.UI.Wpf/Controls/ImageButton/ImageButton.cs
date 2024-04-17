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
    public class ImageButton : Button
    {
        static ImageButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ImageButton), new FrameworkPropertyMetadata(typeof(ImageButton)));
        }

        public static readonly DependencyProperty SourceDataProperty = DependencyProperty.Register("SourceData"
            , typeof(ImageSource), typeof(ImageButton));

        #region properties
        public ImageSource SourceData
        {
            get { return (ImageSource)GetValue(SourceDataProperty); }
            set { SetValue(SourceDataProperty, value); }
        }
        #endregion
    }
}
