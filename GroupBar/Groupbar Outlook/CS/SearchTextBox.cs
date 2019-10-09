#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GroupbarOutlookDemo
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:GroupbarOutlookDemo"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:GroupbarOutlookDemo;assembly=GroupbarOutlookDemo"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Browse to and select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:SearchTextBox/>
    ///
    /// </summary>
    public class SearchTextBox : TextBox
    {

        private TextBox PART_WaterMarkTextBox;
        private TextBox PART_MainTextBox;

        public string WaterMarkText
        {
            get { return (string)GetValue(WaterMarkTextProperty); }
            set { SetValue(WaterMarkTextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for WaterMarkText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WaterMarkTextProperty =
            DependencyProperty.Register("WaterMarkText", typeof(string), typeof(SearchTextBox), new PropertyMetadata("search.."));



        internal bool IsWaterMarkTextVisible
        {
            get { return (bool)GetValue(IsWaterMarkTextVisibleProperty); }
            set { SetValue(IsWaterMarkTextVisibleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IsWaterMarkTextVisible.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsWaterMarkTextVisibleProperty =
            DependencyProperty.Register("IsWaterMarkTextVisible", typeof(bool), typeof(SearchTextBox), new PropertyMetadata(false));

        protected override void OnGotFocus(RoutedEventArgs e)
        {
            this.IsWaterMarkTextVisible = false;
            base.OnGotFocus(e);
        }

        protected override void OnLostFocus(RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text))
                this.IsWaterMarkTextVisible = true;
            base.OnLostFocus(e);
        }

        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(this.Text))
            {
                IsWaterMarkTextVisible = true;
            }
            base.OnTextChanged(e);
        }

        static SearchTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchTextBox), new FrameworkPropertyMetadata(typeof(SearchTextBox)));
        }
        public override void OnApplyTemplate()
        {
            PART_MainTextBox = base.GetTemplateChild("PART_MainTextBox") as TextBox;
            PART_WaterMarkTextBox = base.GetTemplateChild("PART_WaterMarkTextBox") as TextBox;

            if (PART_MainTextBox != null)
            {
                PART_MainTextBox.Loaded += PART_MainTextBox_Loaded;
                PART_MainTextBox.TextChanged += PART_MainTextBox_TextChanged;
                PART_MainTextBox.GotFocus += PART_MainTextBox_GotFocus;
                PART_MainTextBox.LostFocus += PART_MainTextBox_LostFocus;
            }
            if(PART_WaterMarkTextBox != null)
                PART_WaterMarkTextBox.GotFocus += PART_WaterMarkTextBox_GotFocus;
            base.OnApplyTemplate();
        }

        void PART_MainTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
            {
                IsWaterMarkTextVisible = true;
            }
        }

        void PART_WaterMarkTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.IsWaterMarkTextVisible = false;
            PART_MainTextBox.Focus();
        }

        void PART_MainTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
                this.IsWaterMarkTextVisible = true;
            base.OnLostFocus(e);
        }

        void PART_MainTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.IsWaterMarkTextVisible = false;
            base.OnGotFocus(e);
        }

        void PART_MainTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
            {
                IsWaterMarkTextVisible = true;
            }
            else
            {
                if (IsWaterMarkTextVisible)
                {
                    IsWaterMarkTextVisible = false;
                }
            }
            base.OnTextChanged(e);
            //throw new NotImplementedException();
        }
    }
}
