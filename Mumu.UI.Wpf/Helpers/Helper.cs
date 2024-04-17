using Mumu.UI.Wpf.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Mumu.UI.Wpf
{
    public class Helper
    {
        #region 是否使用禁用的样式设计UnablePanel
        public static bool GetUseDisabledCursor(DependencyObject obj)
        {
            return (bool)obj.GetValue(UseDisabledCursorProperty);
        }

        public static void SetUseDisabledCursor(DependencyObject obj, bool value)
        {
            obj.SetValue(UseDisabledCursorProperty, value);
        }

        public static readonly DependencyProperty UseDisabledCursorProperty =
            DependencyProperty.RegisterAttached("UseDisabledCursor", typeof(bool), typeof(Helper), new PropertyMetadata(false, OnUseDisabledCursorPropertyChanged));

        private static void OnUseDisabledCursorPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FrameworkElement framework)
            {
                if ((bool)e.NewValue)
                {
                    framework.IsEnabledChanged += Framework_IsEnabledChanged;
                    framework.Loaded += Framework_Loaded;
                }
                else
                {
                    framework.IsEnabledChanged -= Framework_IsEnabledChanged;
                    framework.Loaded -= Framework_Loaded;
                }
            }
            else
            {
                throw new Exception("Source Must be FrameworkElement");
            }
        }

        private static void SetEnable(FrameworkElement framework)
        {
            var adorner = (UnableAdorner)framework.GetOrAddAdorner(typeof(UnableAdorner));
            adorner.SetEnable(framework.IsEnabled);
        }

        private static void Framework_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (sender is FrameworkElement framework && framework.IsLoaded)
            {
                SetEnable(framework);
            }
        }

        private static void Framework_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is FrameworkElement framework)
            {
                SetEnable(framework);
            }
        }
        #endregion

    }
}
