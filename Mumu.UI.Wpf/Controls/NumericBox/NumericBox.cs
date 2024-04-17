using Mumu.UI.Wpf.Datas;
using Mumu.UI.Wpf.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Mumu.UI.Wpf
{
    [DefaultEvent("ValueChanged"), DefaultProperty("Value")]
    [TemplatePart(Name = TextBoxTemplateName, Type = typeof(TextBox))]
    [TemplatePart(Name = NumericUpTemplateName, Type = typeof(RepeatButton))]
    [TemplatePart(Name = NumericDownTemplateName, Type = typeof(RepeatButton))]
    public class NumericBox : Control
    {
        private static readonly Type _typeofSelf = typeof(NumericBox);

        private const double DefaultInterval = 1d;
        private const int DefaultDelay = 500;

        private const string TextBoxTemplateName = "PART_TextBox";
        private const string NumericUpTemplateName = "PART_NumericUp";
        private const string NumericDownTemplateName = "PART_NumericDown";

        private static RoutedCommand _increaseCommand = null;
        private static RoutedCommand _decreaseCommand = null;

        private TextBox _valueTextBox;
        private RepeatButton _repeatUp;
        private RepeatButton _repeatDown;

        private double _internalLargeChange = DefaultInterval;
        private double _intervalValueSinceReset = 0;
        private double? _lastOldValue = null;

        private bool _isManual;
        private bool _isBusy;

        static NumericBox()
        {
            InitializeCommands();

            DefaultStyleKeyProperty.OverrideMetadata(_typeofSelf, new FrameworkPropertyMetadata(_typeofSelf));
        }

        private static void InitializeCommands()
        {
            _increaseCommand = new RoutedCommand("Increase", _typeofSelf);
            _decreaseCommand = new RoutedCommand("Decrease", _typeofSelf);

            CommandManager.RegisterClassCommandBinding(_typeofSelf, new CommandBinding(_increaseCommand, OnIncreaseCommand, OnCanIncreaseCommand));
            CommandManager.RegisterClassCommandBinding(_typeofSelf, new CommandBinding(_decreaseCommand, OnDecreaseCommand, OnCanDecreaseCommand));
        }

        public static RoutedCommand IncreaseCommand
        {
            get { return _increaseCommand; }
        }

        public static RoutedCommand DecreaseCommand
        {
            get { return _decreaseCommand; }
        }

        private static void OnIncreaseCommand(object sender, RoutedEventArgs e)
        {
            var numericBox = sender as NumericBox;
            numericBox.ContinueChangeValue(true);
        }

        private static void OnCanIncreaseCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            var numericBox = sender as NumericBox;
            e.CanExecute = (!numericBox.IsReadOnly && numericBox.IsEnabled && DoubleUtil.LessThan(numericBox.Value, numericBox.Maximum));
        }

        private static void OnDecreaseCommand(object sender, RoutedEventArgs e)
        {
            var numericBox = sender as NumericBox;
            numericBox.ContinueChangeValue(false);
        }

        private static void OnCanDecreaseCommand(object sender, CanExecuteRoutedEventArgs e)
        {
            var numericBox = sender as NumericBox;
            e.CanExecute = (!numericBox.IsReadOnly && numericBox.IsEnabled && DoubleUtil.GreaterThan(numericBox.Value, numericBox.Minimum));
        }


        public static readonly DependencyProperty DisabledValueChangedWhileBusyProperty = DependencyProperty.Register("DisabledValueChangedWhileBusy", typeof(bool), _typeofSelf,
           new PropertyMetadata(false));
        public static readonly DependencyProperty IntervalProperty = DependencyProperty.Register("Interval", typeof(double), _typeofSelf,
           new FrameworkPropertyMetadata(DefaultInterval, IntervalChanged, CoerceInterval));
        public static readonly DependencyProperty MinimumProperty = DependencyProperty.Register("Minimum", typeof(double), _typeofSelf,
            new PropertyMetadata(double.MinValue, OnMinimumChanged));
        public static readonly DependencyProperty MaximumProperty = DependencyProperty.Register("Maximum", typeof(double), _typeofSelf,
            new PropertyMetadata(double.MaxValue, OnMaximumChanged, CoerceMaximum));
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), _typeofSelf,
            new FrameworkPropertyMetadata(0d, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, OnValueChanged, CoerceValue));
        public static readonly DependencyProperty PrecisionProperty = DependencyProperty.Register("Precision", typeof(int?), _typeofSelf,
            new PropertyMetadata(null, OnPrecisionChanged, CoercePrecision));
        public static readonly DependencyProperty IsReadOnlyProperty = TextBoxBase.IsReadOnlyProperty.AddOwner(_typeofSelf,
            new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.Inherits, IsReadOnlyPropertyChangedCallback));
        public static readonly DependencyProperty SpeedupProperty = DependencyProperty.Register("Speedup", typeof(bool), _typeofSelf,
           new PropertyMetadata(true));
        public static readonly DependencyProperty TextAlignmentProperty = TextBox.TextAlignmentProperty.AddOwner(_typeofSelf);
        public static readonly DependencyProperty UpDownButtonsWidthProperty = DependencyProperty.Register("UpDownButtonsWidth", typeof(double), _typeofSelf,
           new PropertyMetadata(20d));


        public static readonly RoutedEvent ValueChangedEvent = EventManager.RegisterRoutedEvent("ValueChanged", RoutingStrategy.Bubble, typeof(RoutedPropertyChangedEventHandler<double>), _typeofSelf);

        #region Properties
        public bool DisabledValueChangedWhileBusy
        {
            get { return (bool)GetValue(DisabledValueChangedWhileBusyProperty); }
            set { SetValue(DisabledValueChangedWhileBusyProperty, value); }
        }
        public double Interval
        {
            get { return (double)GetValue(IntervalProperty); }
            set { SetValue(IntervalProperty, value); }
        }
        public double Minimum
        {
            get { return (double)GetValue(MinimumProperty); }
            set { SetValue(MinimumProperty, value); }
        }
        public double Maximum
        {
            get { return (double)GetValue(MaximumProperty); }
            set { SetValue(MaximumProperty, value); }
        }
        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public int? Precision
        {
            get { return (int?)GetValue(PrecisionProperty); }
            set { SetValue(PrecisionProperty, value); }
        }
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
        public bool Speedup
        {
            get { return (bool)GetValue(SpeedupProperty); }
            set { SetValue(SpeedupProperty, value); }
        }
        public TextAlignment TextAlignment
        {
            get { return (TextAlignment)GetValue(TextAlignmentProperty); }
            set { SetValue(TextAlignmentProperty, value); }
        }
        public double UpDownButtonsWidth
        {
            get { return (double)GetValue(UpDownButtonsWidthProperty); }
            set { SetValue(UpDownButtonsWidthProperty, value); }
        }
        #endregion

        #region CallBack
        private static object CoerceInterval(DependencyObject d, object value)
        {
            var interval = (double)value;
            return DoubleUtil.IsNaN(interval) ? 0 : Math.Max(interval, 0);
        }

        private static void IntervalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var numericBox = (NumericBox)d;
            numericBox.ResetInternal();
        }
        private static void OnMinimumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var numericBox = (NumericBox)d;

            numericBox.CoerceValue(MaximumProperty, numericBox.Maximum);
            numericBox.CoerceValue(ValueProperty, numericBox.Value);
        }
        private static void OnMaximumChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var numericBox = (NumericBox)d;
            numericBox.CoerceValue(ValueProperty, numericBox.Value);
        }
        private static object CoerceMaximum(DependencyObject d, object value)
        {
            var minimum = ((NumericBox)d).Minimum;
            var val = (double)value;
            return DoubleUtil.LessThan(val, minimum) ? minimum : val;
        }
        private void CoerceValue(DependencyProperty dp, object localValue)
        {
            SetCurrentValue(dp, localValue);
            CoerceValue(dp);
        }
        private static object CoerceValue(DependencyObject d, object value)
        {
            var numericBox = (NumericBox)d;
            var val = (double)value;

            if (DoubleUtil.LessThan(val, numericBox.Minimum))
                return numericBox.Minimum;

            if (DoubleUtil.GreaterThan(val, numericBox.Maximum))
                return numericBox.Maximum;

            return numericBox.CorrectPrecision(numericBox.Precision, val);
        }
        private static void OnValueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var numericBox = (NumericBox)d;
            numericBox.OnValueChanged((double)e.OldValue, (double)e.NewValue);
        }
        private static void IsReadOnlyPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (e.OldValue == e.NewValue || e.NewValue == null)
                return;

            ((NumericBox)d).ToggleReadOnlyMode((bool)e.NewValue);
        }
        private static void OnPrecisionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var numericBox = (NumericBox)d;
            var newPrecision = (int?)e.NewValue;

            var roundValue = numericBox.CorrectPrecision(newPrecision, numericBox.Value);

            if (DoubleUtil.AreClose(numericBox.Value, roundValue))
                numericBox.InternalSetText(roundValue);
            else
                numericBox.Value = roundValue;
        }
        private static object CoercePrecision(DependencyObject d, object value)
        {
            var precision = (int?)value;
            return (precision.HasValue && precision.Value < 0) ? 0 : precision;
        }
        #endregion

        #region Private
        private void ResetInternal()
        {
            _internalLargeChange = Interval;
            _intervalValueSinceReset = 0;

            _isBusy = false;

            if (_lastOldValue.HasValue)
            {
                _isManual = true;
                OnValueChanged(_lastOldValue.Value, Value);
                _lastOldValue = null;
            }
        }
        private void InternalSetText(double newValue)
        {
            var text = newValue.ToString(GetPrecisionFormat());
            if (_valueTextBox != null && !Equals(text, _valueTextBox.Text))
                _valueTextBox.Text = text;
        }
        private void InvalidateRequerySuggested(double value)
        {
            if (_repeatUp == null || _repeatDown == null)
                return;

            if (DoubleUtil.AreClose(value, Maximum) && _repeatUp.IsEnabled
               || DoubleUtil.AreClose(value, Minimum) && _repeatDown.IsEnabled)
                CommandManager.InvalidateRequerySuggested();
            else
            {
                if (!_repeatUp.IsEnabled || !_repeatDown.IsEnabled)
                    CommandManager.InvalidateRequerySuggested();
            }
        }
        private void ContinueChangeValue(bool isIncrease, bool isContinue = true)
        {
            if (IsReadOnly || !IsEnabled)
                return;

            if (isIncrease && DoubleUtil.LessThan(Value, Maximum))
            {
                if (!_isBusy && isContinue)
                {
                    _isBusy = true;

                    if (DisabledValueChangedWhileBusy)
                        _lastOldValue = Value;
                }

                _isManual = true;
                Value = (double)CoerceValue(this, Value + CalculateInterval(isContinue));
            }

            if (!isIncrease && DoubleUtil.GreaterThan(Value, Minimum))
            {
                if (!_isBusy && isContinue)
                {
                    _isBusy = true;

                    if (DisabledValueChangedWhileBusy)
                        _lastOldValue = Value;
                }

                _isManual = true;
                Value = (double)CoerceValue(this, Value - CalculateInterval(isContinue));
            }
        }
        private double CalculateInterval(bool isContinue = true)
        {
            if (!Speedup || !isContinue)
                return Interval;

            if (DoubleUtil.GreaterThan((_intervalValueSinceReset += _internalLargeChange), _internalLargeChange * 100))
                _internalLargeChange *= 10;

            return _internalLargeChange;
        }
        private double CorrectPrecision(int? precision, double originValue)
        {
            return Math.Round(originValue, precision ?? 0, MidpointRounding.AwayFromZero);
        }
        #endregion

        #region virtual Methods
        protected virtual void OnValueChanged(double oldValue, double newValue)
        {
            InternalSetText(newValue);
            InvalidateRequerySuggested(newValue);

            if ((!_isBusy || !DisabledValueChangedWhileBusy) && !DoubleUtil.AreClose(oldValue, newValue))
            {
                RaiseEvent(new TextBoxValueChangedEventArgs<double>(oldValue, newValue, _isManual, _isBusy, ValueChangedEvent));
            }

            _isManual = false;
        }
        private void ToggleReadOnlyMode(bool isReadOnly)
        {
            if (_valueTextBox == null)
                return;

            if (isReadOnly)
            {
                _valueTextBox.LostFocus -= OnTextBoxLostFocus;
                _valueTextBox.PreviewMouseLeftButtonDown -= OnPreviewMouseLeftButtonDown;
                DataObject.RemovePastingHandler(_valueTextBox, OnValueTextBoxPaste);
            }
            else
            {
                _valueTextBox.LostFocus += OnTextBoxLostFocus;
                _valueTextBox.PreviewMouseLeftButtonDown += OnPreviewMouseLeftButtonDown;
                DataObject.AddPastingHandler(_valueTextBox, OnValueTextBoxPaste);
            }
        }
        private void OnPreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (Focusable && !IsReadOnly && !_valueTextBox.IsKeyboardFocusWithin)
            {
                e.Handled = true;
                Focused();
                SelectAll();
            }
        }
        private void OnTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            var tb = (TextBox)sender;
            DealInputText(tb.Text);
        }
        private void OnValueTextBoxPaste(object sender, DataObjectPastingEventArgs e)
        {
            var textBox = (TextBox)sender;
            var textPresent = textBox.Text;

            if (!e.SourceDataObject.GetDataPresent(DataFormats.Text, true))
                return;

            var text = e.SourceDataObject.GetData(DataFormats.Text) as string;
            var newText = string.Concat(textPresent.Substring(0, textBox.SelectionStart), text, textPresent.Substring(textBox.SelectionStart + textBox.SelectionLength));

            double number;
            if (!double.TryParse(newText, out number))
                e.CancelCommand();
        }
        private void Focused()
        {
            _valueTextBox?.Focus();
        }

        private void SelectAll()
        {
            _valueTextBox?.SelectAll();
        }
        private void DealInputText(string inputText)
        {
            double convertedValue;
            if (double.TryParse(inputText, out convertedValue))
            {
                if (DoubleUtil.AreClose(Value, convertedValue))
                {
                    InternalSetText(Value);
                    return;
                }

                _isManual = true;

                if (convertedValue > Maximum)
                {
                    if (DoubleUtil.AreClose(Value, Maximum))
                        OnValueChanged(Value, Value);
                    else
                        Value = Maximum;
                }
                else if (convertedValue < Minimum)
                {
                    if (DoubleUtil.AreClose(Value, Minimum))
                        OnValueChanged(Value, Value);
                    else
                        Value = Minimum;
                }
                else
                    Value = convertedValue;
            }
            else
                InternalSetText(Value);
        }
        private string GetPrecisionFormat()
        {
            return Precision.HasValue == false
                ? "g"
                : (Precision.Value == 0
                    ? "#0"
                    : ("#0.0" + string.Join("", Enumerable.Repeat("#", Precision.Value - 1))));
        }
        #endregion

        #region RouteEvent
        public event RoutedPropertyChangedEventHandler<double> ValueChanged
        {
            add { AddHandler(ValueChangedEvent, value); }
            remove { RemoveHandler(ValueChangedEvent, value); }
        }
        #endregion
    }
}
