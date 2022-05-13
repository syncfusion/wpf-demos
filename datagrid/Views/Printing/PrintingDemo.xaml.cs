#region Copyright Syncfusion Inc. 2001-2022
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for PrintingDemo.xaml
    /// </summary>
    public partial class PrintingDemo : DemoControl
    {
        public PrintingDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            if (this.syncgrid != null)
            {

                this.syncgrid.Dispose();
                this.syncgrid = null;
            }

            if (this.DataContext != null)
            {
                var dataContext = this.DataContext as OrderInfoViewModel;
                dataContext.Dispose();
                this.DataContext = null;
            }

            if (this.AllowFitCkb != null)
                this.AllowFitCkb = null;

            if (this.button != null)
                this.button = null;

            if (this.button1 != null)
                this.button1 = null;

            if (this.AllowRepeatHeaderCkb != null)
                this.AllowRepeatHeaderCkb = null;

            if (this.AllowPrintByDrawingCkb != null)
                this.AllowPrintByDrawingCkb = null;

            if (this.PrintStackedHeaderCkb != null)
                this.PrintStackedHeaderCkb = null;


            base.Dispose(disposing);
        }
    }
}
