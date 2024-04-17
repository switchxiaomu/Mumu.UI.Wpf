using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Mumu.UI.Wpf
{
    public class IsLastItemConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ContentControl contentPresenter = values[0] as ContentControl;
            ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer(contentPresenter);

            bool flag = false;
            if (itemsControl != null)
            {
                int index = itemsControl.ItemContainerGenerator.IndexFromContainer(contentPresenter);
                flag = (index == (itemsControl.Items.Count - 1));
            }

            return flag;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
