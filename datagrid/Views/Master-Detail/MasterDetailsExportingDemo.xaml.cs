#region Copyright Syncfusion Inc. 2001-2021
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
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
    /// Interaction logic for MasterDetailsExportingDemo.xaml
    /// </summary>
    public partial class MasterDetailsExportingDemo : DemoControl
    {
        public MasterDetailsExportingDemo(string themename) : base(themename)
        {
            InitializeComponent();           
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            //Release all managed resources
            if (this.dataGrid != null)
            {
                this.dataGrid.Dispose();
                this.dataGrid = null;
            }

            if (this.DataContext != null)
                this.DataContext = null;

            if (this.textBlock1 != null)
                this.textBlock1 = null;

            if (this.customizeColumns != null)
                this.customizeColumns = null;

            if (this.button1 != null)
                this.button1 = null;

            if (this.textBlock2 != null)
                this.textBlock2 = null;

            if (this.customizeSelectedRow != null)
                this.customizeSelectedRow = null;

            if (this.button2 != null)
                this.button2 = null;

            base.Dispose(disposing);
        }
    }
}
