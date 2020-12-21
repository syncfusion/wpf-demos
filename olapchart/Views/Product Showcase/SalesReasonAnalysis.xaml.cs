#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapchartdemos.wpf
{
    using syncfusion.demoscommon.wpf;

    /// <summary>
    /// Interaction logic for SalesReasonAnalysis.xaml
    /// </summary>
    public partial class SalesReasonAnalysis : DemoControl
    {
        public SalesReasonAnalysis()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            (this.DataContext as SalesReasonAnalysisViewModel).Dispose();
            this.olapChart = null;
            base.Dispose(disposing);
        }
    }
}
