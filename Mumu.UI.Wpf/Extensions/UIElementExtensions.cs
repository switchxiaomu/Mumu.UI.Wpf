﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows;

namespace Mumu.UI.Wpf.Extensions
{
    public static class UIElementExtensions
    {
        public static Adorner GetOrAddAdorner(this UIElement uIElement, Type type)
        {
            AdornerLayer adornerLayer = AdornerLayer.GetAdornerLayer(uIElement);
            if (adornerLayer == null)
            {
                throw new Exception("VisualParents Must have AdornerDecorator!");
            }
            var adorner = adornerLayer.GetAdorners(uIElement)?.FirstOrDefault(x => x?.GetType() == type);
            if (adorner == null)
            {
                lock (uIElement)
                {
                    if (adorner == null)
                    {
                        adorner = (Adorner)Activator.CreateInstance(type, new object[] { uIElement });
                        adornerLayer.Add(adorner);
                    }
                }
            }
            return adorner;
        }
    }
}
