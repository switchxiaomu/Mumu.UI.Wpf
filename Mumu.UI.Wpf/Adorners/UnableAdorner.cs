using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace Mumu.UI.Wpf
{
    public class UnableAdorner : BaseAdorner
    {
        private readonly UnablePanel unablePanel;

        public UnableAdorner(UIElement uIElement) : base(uIElement)
        {
            unablePanel = new UnablePanel();
            VisualCollection.Add(unablePanel);
        }

        public void SetEnable(bool isEnable)
        {
            unablePanel.Visibility = isEnable ? Visibility.Collapsed : Visibility.Visible;
        }

        protected override Size MeasureOverride(Size constraint)
        {
            return base.MeasureOverride(constraint);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            unablePanel.Arrange(new Rect(finalSize));
            return base.ArrangeOverride(finalSize);

        }
    }
}
