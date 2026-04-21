#region Copyright Syncfusion Inc. 2001 - 2026
// Copyright Syncfusion Inc. 2001 - 2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Grid.Helpers;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for ExcelStyleSelectionDemo.xaml
    /// </summary>
    public partial class ExcelStyleSelectionDemo : DemoControl
    {
        public ExcelStyleSelectionDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            //Release all managed resources
            if (this.syncgrid != null)
            {
                this.syncgrid.Dispose();
                this.syncgrid = null;
            }
              
            if (this.DataContext != null)
                this.DataContext = null;

            if (this.textBlock1 != null)
                this.textBlock1 = null;

            if (this.cmbColumnHeaderClickAction != null)
                this.cmbColumnHeaderClickAction = null;

            if (this.ckbAllowSorting != null)
                this.ckbAllowSorting = null;

            base.Dispose(disposing);
        }
    }
}
