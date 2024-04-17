using Mumu.UI.Wpf.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Mumu.UI.Wpf
{
    public class TextBoxHelper
    {
        #region IsNumericOnly 只能输入正整数
        public static bool GetIsNumericOnly(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsNumericOnlyProperty);
        }
        public static void SetIsNumericOnly(DependencyObject obj, bool value)
        {
            obj.SetValue(IsNumericOnlyProperty, value);
        }

        public static readonly DependencyProperty IsNumericOnlyProperty =
            DependencyProperty.RegisterAttached("IsNumericOnly", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(false, OnIsNumericOnlyChanged));

        private static void OnIsNumericOnlyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBox;
            if (textBox != null)
            {
                if ((bool)e.NewValue)
                {
                    DataObject.AddPastingHandler(textBox, TextBox_Pasting);
                    textBox.PreviewTextInput += TextBox_PreviewTextInput;
                    textBox.PreviewKeyDown += TextBox_PreviewKeyDown;
                }
                else
                {
                    DataObject.RemovePastingHandler(textBox, TextBox_Pasting);
                    textBox.PreviewTextInput -= TextBox_PreviewTextInput;
                    textBox.PreviewKeyDown -= TextBox_PreviewKeyDown;
                }
            }
        }

        private static void TextBox_Pasting(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var pastedText = e.DataObject.GetData(typeof(string)) as string;
                if (!IsTextAllowed(pastedText))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private static void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private static bool IsTextAllowed(string text)
        {
            return int.TryParse(text, out _);
        }
        #endregion

        #region IsNumericWithDecimal 只能输入正小数
        public static bool GetIsNumericWithDecimal(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsNumericWithDecimalProperty);
        }

        public static void SetIsNumericWithDecimal(DependencyObject obj, bool value)
        {
            obj.SetValue(IsNumericWithDecimalProperty, value);
        }

        public static readonly DependencyProperty IsNumericWithDecimalProperty =
            DependencyProperty.RegisterAttached("IsNumericWithDecimal", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(false, OnIsNumericWithDecimalChanged));

        private static void OnIsNumericWithDecimalChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBox;
            if (textBox != null)
            {
                if ((bool)e.NewValue)
                {
                    DataObject.AddPastingHandler(textBox, TextBox_Pasting_D);
                    textBox.PreviewTextInput += TextBox_PreviewTextInput_D;
                    textBox.PreviewKeyDown += TextBox_PreviewKeyDown_D;
                }
                else
                {
                    DataObject.RemovePastingHandler(textBox, TextBox_Pasting_D);
                    textBox.PreviewTextInput -= TextBox_PreviewTextInput_D;
                    textBox.PreviewKeyDown -= TextBox_PreviewKeyDown_D;
                }
            }
        }

        private static void TextBox_Pasting_D(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var pastedText = e.DataObject.GetData(typeof(string)) as string;
                if (!IsTextAllowedWithDecimal(pastedText))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private static void TextBox_PreviewTextInput_D(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                // 如果输入是小数点且已经包含小数点，或者输入不是数字或小数点，则阻止输入
                if ((e.Text == "." && textBox.Text.Contains(".")) || !IsTextAllowedWithDecimal(e.Text))
                {
                    e.Handled = true;
                }
            }
        }

        private static void TextBox_PreviewKeyDown_D(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private static bool IsTextAllowedWithDecimal(string text)
        {
            // 使用正则表达式来验证输入是否是数字或小数点
            return Regex.IsMatch(text, @"^[0-9.]*$");
        }
        #endregion

        #region IsNumericWithDecimalAndMinus 只能输入数字
        public static bool GetIsNumericWithDecimalAndMinus(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsNumericWithDecimalAndMinusProperty);
        }
        public static void SetIsNumericWithDecimalAndMinus(DependencyObject obj, bool value)
        {
            obj.SetValue(IsNumericWithDecimalAndMinusProperty, value);
        }

        public static readonly DependencyProperty IsNumericWithDecimalAndMinusProperty =
            DependencyProperty.RegisterAttached("IsNumericWithDecimalAndMinus", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(false, OnIsNumericWithDecimalAndMinusChanged));

        private static void OnIsNumericWithDecimalAndMinusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBox;
            if (textBox != null)
            {
                if ((bool)e.NewValue)
                {
                    DataObject.AddPastingHandler(textBox, TextBox_Pasting_DM);
                    textBox.PreviewTextInput += TextBox_PreviewTextInput_DM;
                    textBox.PreviewKeyDown += TextBox_PreviewKeyDown_DM;
                }
                else
                {
                    DataObject.RemovePastingHandler(textBox, TextBox_Pasting_DM);
                    textBox.PreviewTextInput -= TextBox_PreviewTextInput_DM;
                    textBox.PreviewKeyDown -= TextBox_PreviewKeyDown_DM;
                }
            }
        }

        private static void TextBox_Pasting_DM(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var pastedText = e.DataObject.GetData(typeof(string)) as string;
                if (!IsTextAllowedWithDecimalAndMinus(pastedText))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private static void TextBox_PreviewTextInput_DM(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                // 如果输入是小数点且已经包含小数点，或者输入是负号且已经包含负号，或者小数点是第一位或者负号不是第一位，或者输入不是数字或小数点，则阻止输入
                if ((e.Text == "." && (textBox.Text.Contains(".") || textBox.SelectionStart == 0)) || 
                    (e.Text == "-" && (textBox.Text.Contains("-") || textBox.SelectionStart != 0)) ||
                    !IsTextAllowedWithDecimalAndMinus(e.Text))
                {
                    e.Handled = true;
                }
            }
        }

        private static void TextBox_PreviewKeyDown_DM(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private static bool IsTextAllowedWithDecimalAndMinus(string text)
        {
            //只能输入正数，负数和0
            return Regex.IsMatch(text, @"^[-]?[0-9.]*$");
        }


        #endregion

        #region IsName 汉字、字母、数字、下划线、中划线
        public static bool GetIsName(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsNameProperty);
        }

        public static void SetIsName(DependencyObject obj, bool value)
        {
            obj.SetValue(IsNameProperty, value);
        }

        public static readonly DependencyProperty IsNameProperty =
            DependencyProperty.RegisterAttached("IsName", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(false, OnIsNameChanged));

        private static void OnIsNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textbox = d as TextBox;
            if (textbox != null)
            {
                if ((bool)e.NewValue)
                {
                    DataObject.AddPastingHandler(textbox, TextBox_Pasting_Name);
                    textbox.PreviewTextInput += TextBox_PreviewTextInput_Name;
                    textbox.PreviewKeyDown += TextBox_PreviewKeyDown_Name;
                }
                else
                {
                    DataObject.RemovePastingHandler(textbox, TextBox_Pasting_Name);
                    textbox.PreviewTextInput -= TextBox_PreviewTextInput_Name;
                    textbox.PreviewKeyDown -= TextBox_PreviewKeyDown_Name;
                }
            }
        }

        private static void TextBox_Pasting_Name(object sender, DataObjectPastingEventArgs e)
        {
            if (e.DataObject.GetDataPresent(typeof(string)))
            {
                var pastedText = e.DataObject.GetData(typeof(string)) as string;
                if (!IsNameAllowed(pastedText))
                {
                    e.CancelCommand();
                }
            }
            else
            {
                e.CancelCommand();
            }
        }

        private static void TextBox_PreviewTextInput_Name(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsNameAllowed(e.Text);
        }

        private static void TextBox_PreviewKeyDown_Name(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Space)
            {
                e.Handled = true;
            }
        }

        private static bool IsNameAllowed(string text)
        {
            return Regex.IsMatch(text, @"^[\u4e00-\u9fa5_a-zA-Z0-9-]*$");
        }

        #endregion

        #region LoseFocusOnEnter 按下回车键时失去焦点

        public static bool GetLoseFocusOnEnter(DependencyObject obj)
        {
            return (bool)obj.GetValue(LoseFocusOnEnterProperty);
        }

        public static void SetLoseFocusOnEnter(DependencyObject obj, bool value)
        {
            obj.SetValue(LoseFocusOnEnterProperty, value);
        }

        public static readonly DependencyProperty LoseFocusOnEnterProperty =
            DependencyProperty.RegisterAttached("LoseFocusOnEnter", typeof(bool), typeof(TextBoxHelper), new PropertyMetadata(false, OnLoseFocusOnEnterChanged));

        private static void OnLoseFocusOnEnterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var textBox = d as TextBox;
            if (textBox != null)
            {
                if ((bool)e.NewValue)
                {
                    textBox.KeyDown += TextBox_KeyDown;
                }
                else
                {
                    textBox.KeyDown -= TextBox_KeyDown;
                }
            }
        }

        private static void TextBox_KeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox != null)
            {
                if (e.Key == Key.Enter)
                {
                    // Kill logical focus
                    FocusManager.SetFocusedElement(FocusManager.GetFocusScope(textBox), null);
                    // Kill keyboard focus
                    Keyboard.ClearFocus();
                }
            }
        }
        #endregion

    }
}
