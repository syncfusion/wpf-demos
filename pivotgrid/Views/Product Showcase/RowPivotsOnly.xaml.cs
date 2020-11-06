#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System.Windows;

    public partial class RowPivotsOnly : DemoControl
    {
        public RowPivotsOnly()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            if (this.pivotGridControl1 != null)
            {
                this.pivotGridControl1.Dispose();
                this.pivotGridControl1 = null;
            }
            base.Dispose(disposing);
        }
    }
}
