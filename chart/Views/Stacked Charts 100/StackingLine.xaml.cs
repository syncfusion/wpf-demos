#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;


namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for StackingLine100Chart.xaml
    /// </summary>
    public partial class StackingLine100Chart : DemoControl
    {
        public StackingLine100Chart()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            StackingAreaChart.Dispose();
            base.Dispose(disposing);
        }
    }
}
