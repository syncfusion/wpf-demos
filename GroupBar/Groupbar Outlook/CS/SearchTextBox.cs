#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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
  /// Represents a class of search text box.
  /// </summary>
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
        #region Fields
        /// <summary>
        /// Maintains part watermark text box.
        /// </summary>
        private TextBox PART_WaterMarkTextBox;

        /// <summary>
        /// Maintains part main textbox.
        /// </summary>
        private TextBox PART_MainTextBox;
        #endregion

        #region properties
        /// <summary>
        /// Gets and sets the water mark text properties.
        /// </summary>
        public string WaterMarkText
        {
            get { return (string)GetValue(WaterMarkTextProperty); }
            set { SetValue(WaterMarkTextProperty, value); }
        }

        /// <summary>
        /// Gets and sets a value indicating whether the watermark visible.
        /// </summary>
        internal bool IsWaterMarkTextVisible
        {
            get { return (bool)GetValue(IsWaterMarkTextVisibleProperty); }
            set { SetValue(IsWaterMarkTextVisibleProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for WaterMarkText.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty WaterMarkTextProperty =
            DependencyProperty.Register("WaterMarkText", typeof(string), typeof(SearchTextBox), new PropertyMetadata("search.."));
        #endregion

        #region Healper methods
        /// <summary>
        /// Apply template to main textbox and watermark textbox.
        /// </summary>
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

        /// <summary>
        /// Loaded method for loaded main textbox.
        /// </summary>
        /// <param name="sender">Sender as textbox to load the main text</param>
        /// <param name="e">Event handler for loaded main textbox</param>
        void PART_MainTextBox_Loaded(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
            {
                IsWaterMarkTextVisible = true;
            }
        }

        /// <summary>
        /// Getfocus method for watermark textbox.
        /// </summary>
        /// <param name="sender">Sender as watermark textbox to load the main text</param>
        /// <param name="e">Event handler for loaded main watermark textbox</param>
        void PART_WaterMarkTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.IsWaterMarkTextVisible = false;
            PART_MainTextBox.Focus();
        }

        /// <summary>
        /// Lostfocus method for main textbox.
        /// </summary>
        /// <param name="sender">Sender as main textbox to lost focus</param>
        /// <param name="e">Event handler for lost focus method</param>
        void PART_MainTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty((sender as TextBox).Text))
                this.IsWaterMarkTextVisible = true;
            base.OnLostFocus(e);
        }

        /// <summary>
        /// Getfocus method for main textbox.
        /// </summary>
        /// <param name="sender">Sender as main textbox to got focus</param>
        /// <param name="e">Event handler for lost focus method</param>
        void PART_MainTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            this.IsWaterMarkTextVisible = false;
            base.OnGotFocus(e);
        }

        /// <summary>
        /// Text changes for water marktext.
        /// </summary>
        /// <param name="sender">Sender as main textbox to change the main text></param>
        /// <param name="e">Event handler for the method</param>
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
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for IsWaterMarkTextVisible.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty IsWaterMarkTextVisibleProperty =
            DependencyProperty.Register("IsWaterMarkTextVisible", typeof(bool), typeof(SearchTextBox), new PropertyMetadata(false));

        /// <summary>
        /// Indicates getfocus method for watermark text.
        /// </summary>
        /// <param name="e">Event handler for on got focus method</param>
        protected override void OnGotFocus(RoutedEventArgs e)
        {
            this.IsWaterMarkTextVisible = false;
            base.OnGotFocus(e);
        }

        /// <summary>
        /// Indicates lost focus method for watermark text.
        /// </summary>
        /// <param name="e">Event handler for on lost focus method</param>
        protected override void OnLostFocus(RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.Text))
                this.IsWaterMarkTextVisible = true;
            base.OnLostFocus(e);
        }

        /// <summary>
        /// Indicates text changed method change the text.
        /// </summary>
        /// <param name="e">Event handler for on text changed method</param>
        protected override void OnTextChanged(TextChangedEventArgs e)
        {
            if(string.IsNullOrEmpty(this.Text))
            {
                IsWaterMarkTextVisible = true;
            }
            base.OnTextChanged(e);
        }

        /// <summary>
        /// Indicates to search the mails.
        /// </summary>
        static SearchTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SearchTextBox), new FrameworkPropertyMetadata(typeof(SearchTextBox)));
        }
        #endregion
    }
}
