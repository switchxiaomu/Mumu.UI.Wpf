﻿using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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
    public class StepBar : ItemsControl
    {
        #region 依赖属性定义

        #region Progress

        public int Progress
        {
            get { return (int)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        public static readonly DependencyProperty ProgressProperty =
            DependencyProperty.Register("Progress", typeof(int), typeof(StepBar), new PropertyMetadata(0, OnProgressChangedCallback, OnProgressCoerceValueCallback));

        private static object OnProgressCoerceValueCallback(DependencyObject d, object baseValue)
        {
            //不让Progress超出边界
            StepBar stepBar = d as StepBar;
            int newValue = Convert.ToInt32(baseValue);
            if (newValue < 0)
            {
                return 0;
            }
            else if (newValue >= stepBar.Items.Count)
            {
                return stepBar.Items.Count - 1;
            }
            return newValue;
        }

        private static void OnProgressChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {

        }

        #endregion

        #region ItemWidth

        public double ItemWidth
        {
            get { return (double)GetValue(ItemWidthProperty); }
            set { SetValue(ItemWidthProperty, value); }
        }

        public static readonly DependencyProperty ItemWidthProperty =
            DependencyProperty.Register("ItemWidth", typeof(double), typeof(StepBar), new PropertyMetadata(50d));

        #endregion

        #endregion

        static StepBar()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(StepBar), new FrameworkPropertyMetadata(typeof(StepBar)));
        }

        #region Override方法
        protected override DependencyObject GetContainerForItemOverride()
        {
            return new StepBarItem();
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            //设置Item的显示数字
            StepBarItem stepBarItem = element as StepBarItem;
            ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer(stepBarItem);
            int index = itemsControl.ItemContainerGenerator.IndexFromContainer(stepBarItem);
            stepBarItem.Number = Convert.ToString(++index);
            base.PrepareContainerForItemOverride(element, item);
        }

        protected override void OnItemsChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnItemsChanged(e);

            //ItemsControl数量变化时，重新设置各个Item的显示的数字
            for (int i = 0; i < this.Items.Count; i++)
            {
                StepBarItem stepBarItem = this.ItemContainerGenerator.Items[i] as StepBarItem;
                if (stepBarItem != null)
                {
                    int temp = i;
                    stepBarItem.Number = Convert.ToString(++temp);
                }
            }
            //进度重新回到第一个
            this.Progress = 0;
        }
        #endregion
    }
}
