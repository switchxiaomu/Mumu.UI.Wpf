using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Media;

namespace Mumu.UI.Wpf
{
    public class BaseAdorner : Adorner
    {
        protected virtual VisualCollection VisualCollection { get; set; }

        protected override int VisualChildrenCount => VisualCollection.Count;

        protected override Visual GetVisualChild(int index)
        {
            return VisualCollection[index];
        }

        public BaseAdorner(UIElement element) : base(element)
        {
            VisualCollection = new VisualCollection(this);
        }
    }
}
