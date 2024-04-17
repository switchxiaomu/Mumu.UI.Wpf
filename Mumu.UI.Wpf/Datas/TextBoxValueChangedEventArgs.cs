using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mumu.UI.Wpf.Datas
{
    public class TextBoxValueChangedEventArgs<T> : RoutedPropertyChangedEventArgs<T>
    {
        public bool IsManual { get; private set; }
        public bool IsBusy { get; private set; }

        public TextBoxValueChangedEventArgs(T oldValue, T newValue, bool isManual, bool isBusy = false, RoutedEvent routedEvent = null)
            : base(oldValue, newValue, routedEvent)
        {
            IsManual = isManual;
            IsBusy = isBusy;
        }
    }
}
