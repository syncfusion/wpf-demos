#region Copyright Syncfusion Inc. 2001-2022
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.SfSkinManager;
using System.Windows;
using System.IO;
using System;
using syncfusion.demoscommon.wpf;
using System.ComponentModel;

namespace syncfusion.spreadsheetdemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class GettingStarted : RibbonWindow
    {
        public GettingStarted()
        {
            InitializeComponent();
        }
        public GettingStarted(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.spreadsheetControl != null)
            {
                this.spreadsheetControl.Dispose();
                this.spreadsheetControl = null;
            }
            if(this.sfSpreadsheetRibbon != null)
            {
                this.sfSpreadsheetRibbon.Dispose();
                this.sfSpreadsheetRibbon = null;
            }
            base.OnClosing(e);
        }
    }
}
