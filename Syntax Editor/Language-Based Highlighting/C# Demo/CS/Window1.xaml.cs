#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Edit;

namespace SyntaxHighlight
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        #region Initialization 

        /// <summary>
        /// Window Constructor - Click Events for menuitem are subscribed
        /// </summary>
        public Window1()
        {
            InitializeComponent();
            Edit1.DocumentLanguage = Languages.CSharp;
#if NETCORE
            Edit1.DocumentSource = "../../../Source.cs";
#else
            Edit1.DocumentSource = "../../Source.cs";
#endif
            fontlst.SelectedItem = new FontFamily("Verdana");
        }

        #endregion

        #region Menu Click Event

        /// <summary>
        /// Helper event to close the window when Exit MenuItem is selected.
        /// </summary>
        /// <param name="sender">represents the MenuItem object</param>
        /// <param name="e">represents RoutedEventArgs</param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #endregion

        /// <summary>
        /// Invoked when color changed
        /// </summary>
        /// <param name="d">DependencyObject</param>
        /// <param name="e">Dependency Property Changed Event Args</param>
        private void colorpicker_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BrushConverter conv = new BrushConverter();
            SolidColorBrush brush = conv.ConvertFromString(colorpicker.SelectedItem.Color.ToString()) as SolidColorBrush;
            Edit1.SetLineBackground(Edit1.LineNumber, true, brush);
            colorpicker.IsExpanded = false;
        }

        /// <summary>
        /// Invoked when DropDown Closed
        /// </summary>
        /// <param name="sender">SplitButton</param>
        /// <param name="e">Routed Event Arguments</param>
        private void linebackcolor_DropDownClosed(object sender, RoutedEventArgs e)
        {
            colorpicker.IsExpanded = true;
        }
    }
}