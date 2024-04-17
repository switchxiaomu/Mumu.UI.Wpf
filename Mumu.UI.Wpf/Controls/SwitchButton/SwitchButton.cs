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
    public enum SwitchButtonType
    {
        Standard,
        Round
    }
    public enum SwitchButtonColorType
    {
        Green,
        Blue
    }

    public class SwitchButton : ToggleButton
    {
        static SwitchButton()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SwitchButton), new FrameworkPropertyMetadata(typeof(SwitchButton)));
        }

        public static readonly DependencyProperty SwitchButtonStyleProperty = DependencyProperty.Register("SwitchButtonStyle"
           , typeof(SwitchButtonType), typeof(SwitchButton));
        public static readonly DependencyProperty DisplayTextProperty = DependencyProperty.Register("DisplayText"
            , typeof(bool), typeof(SwitchButton));
        public static readonly DependencyProperty SwitchButtonColorProperty = DependencyProperty.Register("SwitchButtonColor",
            typeof(SwitchButtonColorType), typeof(SwitchButton));

        #region Properties
        public SwitchButtonType SwitchButtonStyle
        {
            get { return (SwitchButtonType)GetValue(SwitchButtonStyleProperty); }
            set { SetValue(SwitchButtonStyleProperty, value); }
        }
        public bool DisplayText
        {
            get { return (bool)GetValue(DisplayTextProperty); }
            set { SetValue(DisplayTextProperty, value); }
        }
        public SwitchButtonColorType SwitchButtonColor
        {
            get { return (SwitchButtonColorType)GetValue(SwitchButtonColorProperty); }
            set { SetValue(SwitchButtonColorProperty, value); }
        }
        #endregion
    }
}
