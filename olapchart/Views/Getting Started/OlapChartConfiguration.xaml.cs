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
    using Syncfusion.Olap.Manager;
    using Syncfusion.Windows.Shared.Olap;
    using System;

    /// <summary>
    /// Interaction logic for OlapChartConfiguration.xaml
    /// </summary>
    public partial class OlapChartConfiguration : DemoControl
    {
        public OlapChartConfiguration()
        {
            InitializeComponent();
            this.designerSettings.ConnectionString = OlapChartModel.Initialize(System.IO.Path.GetFullPath(@"Assets\Config\OLAPSample.config"));
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            if (disposing && this.olapchart1.OlapDataManager != null)
                (this.olapchart1.OlapDataManager as OlapDataManager).Dispose();
            this.designerSettings.ConnectionString = null;
            this.designerSettings.CurrentCubeName = null;
            this.designerSettings.ConnectionMode = ConnectionMode.None;
            this.designerSettings.Report = null;
            base.Dispose(disposing);
        }
    }
}
