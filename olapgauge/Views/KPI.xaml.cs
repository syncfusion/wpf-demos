#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapgaugedemos.wpf
{
    using syncfusion.demoscommon.wpf;

    /// <summary>
    /// Interaction logic for KPI.xaml
    /// </summary>
    public partial class KPI : DemoControl
    {
        public KPI()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            (this.DataContext as KPIViewModel).Dispose();
            this.DataContext = null;

            if (this.olapGauge1 != null)
            {
                this.olapGauge1.Dispose();
                this.olapGauge1 = null;
            }

            base.Dispose(disposing);
        }
    }
}
