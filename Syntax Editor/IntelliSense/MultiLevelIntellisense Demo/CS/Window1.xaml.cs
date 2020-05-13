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
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Shared;
using System.Reflection;
using Microsoft.Win32;
using System.Collections.ObjectModel;
using System.IO;

namespace MultiLevelIntellisenseDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        /// <summary>
        /// Window Constructor and events initialization
        /// </summary>
        public Window1()
        {

            InitializeComponent();

            EditControl1.DocumentLanguage = Languages.CSharp;

            if (this.EditControl1.ShowLineNumber)
                this.ShowLineNumber.IsChecked = true;

            if (this.EditControl1.ShowDefaultContextMenu)
                this.ShowContextMenu.IsChecked = true;

            EditControl1.Text = @"/* To see how the intellisense popup works, type ""this."" or ""this.editControl1."" 

In an intellisense popup, you can see controls such as Edit Control, TextBox, and Button along with 
their properties, methods and events.

In Context Prompt[Intellisense Popup] you can see the controls[Edit Control, TextBox, Button]  and 
their classes are available in it. 

If you have closed the popup, you can re-open it with the CTRL+Space shortcut key.

To see how the intellisense works,*/

// Examples:  
this. //<- Press CTRL+Space to display an intellisense popup with a choice..

this.editControl1. /*Press '. ' after ""EditControl"" and you will see that the intellisense popup 
will be opened with a list of properties, methods and events that are available in the ""EdiControl"" class.*/";

            fontlst.SelectedItem = new FontFamily("Verdana");
            EditControl1.IntellisensePopupHeight = 98;            
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void MenuItem_LineNumber_Click(object sender, RoutedEventArgs e)
        {
            if(this.ShowLineNumber.IsChecked)
            {
                this.EditControl1.ShowLineNumber = true;
            }
            else
            {
                this.EditControl1.ShowLineNumber = false;
            }
        }

        private void MenuItem_ContextMenu_Click(object sender, RoutedEventArgs e)
        {
            if (this.ShowContextMenu.IsChecked)
            {
                this.EditControl1.ShowDefaultContextMenu = true;
            }
            else
            {
                this.EditControl1.ShowDefaultContextMenu = false;
            }
        }
    }
}



