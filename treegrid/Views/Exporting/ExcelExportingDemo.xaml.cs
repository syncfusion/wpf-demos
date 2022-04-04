#region Copyright Syncfusion Inc. 2001-2022
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.TreeGrid.Converter;
using Syncfusion.Windows.Shared;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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


namespace syncfusion.treegriddemos.wpf
{
    /// <summary>
    /// Interaction logic for ExcelExportingDemo.xaml
    /// </summary>
    public partial class ExcelExportingDemo : DemoControl
    {
        public ExcelExportingDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all managed resources
            if (this.treeGrid != null)
            {
                this.treeGrid.Dispose();
                this.treeGrid = null;
            }

            if (this.DataContext != null)
            {
                var dataContext = this.DataContext as EmployeeInfoViewModel;
                dataContext.Dispose();
                this.DataContext = null;
            }

            if(this.allowOutlining != null)
                this.allowOutlining = null;

            if (this.allowIndentColumn != null)
                this.allowIndentColumn = null;

            if (this.isGridLinesVisible != null)
                this.isGridLinesVisible = null;

            if (this.textBlock != null)
                this.textBlock = null;

            if (this.nodeexpandMode != null)
                this.nodeexpandMode = null;

            if (this.customizeColumns != null)
                this.customizeColumns = null;

            if (this.button != null)
                this.button = null;

            base.Dispose(disposing);
        }
    }
}
