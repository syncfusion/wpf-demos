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
    /// Interaction logic for AdventureWorksDashboard.xaml
    /// </summary>
    public partial class AdventureWorksDashboard : DemoControl
    {
        public AdventureWorksDashboard()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            (this.DataContext as AdventureWorksDashboardViewModel).Dispose();
            if (this.olapGauge1 != null)
            {
                this.olapGauge1.Dispose();
                this.olapGauge1 = null;
            }

            if (this.olapGrid1 != null)
            {
                this.olapGrid1.Dispose();
                this.olapGrid1 = null;
            }

            if (this.olapChart1 != null)
                this.olapChart1 = null;

            if (this.olapChart2 != null)
                this.olapChart2 = null;

            if (this.olapChart4 != null)
                this.olapChart4 = null;

            base.Dispose(disposing);
        }
    }
}
