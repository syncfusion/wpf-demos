#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
using Syncfusion.SfSkinManager;
using syncfusion.demoscommon.wpf;
using System.ComponentModel;

namespace syncfusion.spreadsheetdemos.wpf
{
    /// <summary>
    /// Interaction logic for CellCustomizationDemo.xaml
    /// </summary>
    public partial class CellCustomizationDemo : ChromelessWindow
    {        
        public CellCustomizationDemo()
        {
            InitializeComponent();
        }
        public CellCustomizationDemo(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
        }

        private void ChromelessWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.spreadsheet.Commands.FileClose.Execute(null);
            if (Application.Current.ShutdownMode != ShutdownMode.OnExplicitShutdown)
                e.Cancel = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (spreadsheet != null)
            {
                spreadsheet.Dispose();
                spreadsheet = null;
            }
            base.OnClosing(e);
        }
    }
}
