﻿using System;
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
    public class StepBarItem : ContentControl
    {
        #region 依赖属性定义
        public string Number
        {
            get { return (string)GetValue(NumberProperty); }
            set { SetValue(NumberProperty, value); }
        }

        public static readonly DependencyProperty NumberProperty =
            DependencyProperty.Register("Number", typeof(string), typeof(StepBarItem));
        #endregion

        static StepBarItem()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StepBarItem), new FrameworkPropertyMetadata(typeof(StepBarItem)));
        }
    }
}
