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
    using System;

    /// <summary>
    /// Interaction logic for OlapChartConfiguration.xaml
    /// </summary>
    public partial class OlapChartConfiguration : DemoControl
    {
        public OlapChartConfiguration()
        {
            InitializeComponent();
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                this.designerSettings.ConnectionString = OlapChartModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                this.designerSettings.ConnectionString = OlapChartModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            this.designerSettings.ConnectionString = null;
            this.designerSettings.Report = null;
            base.Dispose(disposing);
        }
    }
}
