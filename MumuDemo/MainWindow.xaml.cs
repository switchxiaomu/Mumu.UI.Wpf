using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MumuDemo
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty CurrentValueProperty = DependencyProperty.Register("CurrentValue", typeof(double), typeof(MainWindow), new PropertyMetadata(20d));
        public static readonly DependencyProperty StartProperty = DependencyProperty.Register("Start", typeof(double), typeof(MainWindow), new PropertyMetadata(20d));
        public static readonly DependencyProperty EndProperty = DependencyProperty.Register("End", typeof(double), typeof(MainWindow), new PropertyMetadata(85d));

        public static readonly DependencyProperty CountProperty = DependencyProperty.Register("Count", typeof(int), typeof(MainWindow), new PropertyMetadata(300));
        public static readonly DependencyProperty CountPerPageProperty = DependencyProperty.Register("CountPerPage", typeof(int), typeof(MainWindow), new PropertyMetadata(10));
        public static readonly DependencyProperty CurrentProperty = DependencyProperty.Register("Current", typeof(int), typeof(MainWindow), new PropertyMetadata(1));

        public static readonly DependencyProperty Count2Property = DependencyProperty.Register("Count2", typeof(int), typeof(MainWindow), new PropertyMetadata(300));
        public static readonly DependencyProperty CountPerPage2Property = DependencyProperty.Register("CountPerPage2", typeof(int), typeof(MainWindow), new PropertyMetadata(10));
        public static readonly DependencyProperty Current2Property = DependencyProperty.Register("Current2", typeof(int), typeof(MainWindow), new PropertyMetadata(1));

        public static readonly DependencyProperty Count3Property = DependencyProperty.Register("Count3", typeof(int), typeof(MainWindow), new PropertyMetadata(300));
        public static readonly DependencyProperty CountPerPage3Property = DependencyProperty.Register("CountPerPage3", typeof(int), typeof(MainWindow), new PropertyMetadata(10));
        public static readonly DependencyProperty Current3Property = DependencyProperty.Register("Current3", typeof(int), typeof(MainWindow), new PropertyMetadata(1));
        public MainWindow()
        {
            InitializeComponent();
            var timer = new Timer { Interval = 3000 };
            timer.Elapsed += Change;
            timer.Start();
        }

        private void Change(object sender, ElapsedEventArgs e)
        {
            //随机数
            var random = new Random();
            var value = random.Next(-20, 20);
            Dispatcher.Invoke(() =>
            {
                CurrentValue = value;
            });
        }

        public double CurrentValue
        {
            get => (double)GetValue(CurrentValueProperty);
            set => SetValue(CurrentValueProperty, value);
        }
        public double Start
        {
            get => (double)GetValue(StartProperty);
            set => SetValue(StartProperty, value);
        }

        public double End
        {
            get => (double)GetValue(EndProperty);
            set => SetValue(EndProperty, value);
        }
        public int Count
        {
            get => (int)GetValue(CountProperty);
            set => SetValue(CountProperty, value);
        }
        public int CountPerPage
        {
            get => (int)GetValue(CountPerPageProperty);
            set => SetValue(CountPerPageProperty, value);
        }
        public int Current
        {
            get => (int)GetValue(CurrentProperty);
            set => SetValue(CurrentProperty, value);
        }
        public int Count2
        {
            get => (int)GetValue(Count2Property);
            set => SetValue(Count2Property, value);
        }
        public int CountPerPage2
        {
            get => (int)GetValue(CountPerPage2Property);
            set => SetValue(CountPerPage2Property, value);
        }
        public int Current2
        {
            get => (int)GetValue(Current2Property);
            set => SetValue(Current2Property, value);
        }
        public int Count3
        {
            get => (int)GetValue(Count3Property);
            set => SetValue(Count3Property, value);
        }
        public int CountPerPage3
        {
            get => (int)GetValue(CountPerPage3Property);
            set => SetValue(CountPerPage3Property, value);
        }
        public int Current3
        {
            get => (int)GetValue(Current3Property);
            set => SetValue(Current3Property, value);
        }

        private void PreviousButton_Click(object sender, RoutedEventArgs e)
        {
            this.stepBar.Progress--;
        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
        {
            this.stepBar.Progress++;
        }
    }
}
