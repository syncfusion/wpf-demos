#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.SfSkinManager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace syncfusion.spreadsheetdemos.wpf
{
    /// <summary>
    /// Interaction logic for OutliningDemo.xaml
    /// </summary>
    public partial class OutliningDemo : RibbonWindow
    {
        public OutliningDemo()
        {
            InitializeComponent();
        }
        public OutliningDemo(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if(spreadsheetControl != null)
            {
                spreadsheetControl.Dispose();
                spreadsheetControl = null;
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
