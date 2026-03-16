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
    /// Interaction logic for OrderDetailsAnalysis.xaml
    /// </summary>
    public partial class OrderDetailsAnalysis : DemoControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OrderDetailsAnalysis"/> class.
        /// </summary>
        public OrderDetailsAnalysis()
        {
            InitializeComponent();
        }

        /// <inheritdoc/>
        protected override void Dispose(bool disposing)
        {
            // Release all resources
            (this.DataContext as OrderDetailsAnalysisViewModel).Dispose();
            this.olapChart = null;
            base.Dispose(disposing);
        }
    }
}
