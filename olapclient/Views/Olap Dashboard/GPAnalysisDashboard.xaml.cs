#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using syncfusion.demoscommon.wpf;

    /// <summary>
    /// Interaction logic for GPAnalysisDashboard.xaml
    /// </summary>
    public partial class GPAnalysisDashboard : DemoControl
    {
        public GPAnalysisDashboard()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            (this.DataContext as GPAnalysisDashboardViewModel).Dispose();

            if (this.olapGrid1 != null)
            {
                this.olapGrid1.Dispose();
                this.olapGrid1 = null;
            }

            if (this.olapChart1 != null)
                this.olapChart1 = null;

            if (this.olapGauge1 != null)
            {
                this.olapGauge1.Dispose();
                this.olapGauge1 = null;
            }
           
            base.Dispose(disposing);
        }
    }
}
