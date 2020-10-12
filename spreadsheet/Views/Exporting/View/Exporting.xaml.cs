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
using Syncfusion.ExcelToPdfConverter;
using Syncfusion.Pdf;
using System.IO;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.spreadsheetdemos.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ExportingDemo : DemoControl
    {
        public ExportingDemo()
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            if (this.spreadsheetControl != null)
            {
                this.spreadsheetControl.Dispose();
                this.spreadsheetControl = null;
            }
            base.Dispose(disposing);
        }
    }
}
