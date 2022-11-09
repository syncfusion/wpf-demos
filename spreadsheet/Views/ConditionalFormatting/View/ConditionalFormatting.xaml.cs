#region Copyright Syncfusion Inc. 2001-2022
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.SfSkinManager;
using System.IO;
using syncfusion.demoscommon.wpf;
using System.ComponentModel;

namespace syncfusion.spreadsheetdemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ConditionalFormattingDemo : RibbonWindow
    {
        public ConditionalFormattingDemo()
        {
            InitializeComponent();
        }
        public ConditionalFormattingDemo(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (spreadsheetControl != null)
            {
                spreadsheetControl.Dispose();
                this.spreadsheetControl = null;
            }
            if(sfSpreadsheetRibbon != null)
            {
                sfSpreadsheetRibbon.Dispose();
                sfSpreadsheetRibbon = null;
            }
            base.OnClosing(e);
        }
    }
}
