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
    public class UnablePanel : Control
    {
        static UnablePanel()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(UnablePanel), new FrameworkPropertyMetadata(typeof(UnablePanel)));
            BackgroundProperty.OverrideMetadata(typeof(UnablePanel), new FrameworkPropertyMetadata(Brushes.Transparent));
            //禁用鼠标
            CursorProperty.OverrideMetadata(typeof(UnablePanel), new FrameworkPropertyMetadata(Cursors.No));
        }
    }
}
