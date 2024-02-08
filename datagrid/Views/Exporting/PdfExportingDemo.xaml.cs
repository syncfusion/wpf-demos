#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;


namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for PdfExportingDemo.xaml
    /// </summary>
    public partial class PdfExportingDemo : DemoControl
    {
        public PdfExportingDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.dataGrid != null)
            {
                this.dataGrid.Dispose();
                this.dataGrid = null;
            }

            if (this.DataContext != null)
                this.DataContext = null;

            if (this.ColumnWidth != null)
                this.ColumnWidth = null;

            if (this.RowHeight != null)
                this.RowHeight = null;

            if (this.ExportGroup != null)
                this.ExportGroup = null;

            if (this.ExportGroupSummary != null)
                this.ExportGroupSummary = null;

            if (this.ExportTableSummary != null)
                this.ExportTableSummary = null;

            if (this.RepeatHeader != null)
                this.RepeatHeader = null;

            if (this.FitAllColumns != null)
                this.FitAllColumns = null;

            if (this.Button1 != null)
                this.Button1 = null;

            if (this.Button2 != null)
                this.Button2 = null;

            base.Dispose(disposing);
        }
    }
}
