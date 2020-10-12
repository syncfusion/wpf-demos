#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using System;
    using Syncfusion.Windows.Shared;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;

    /// <summary>
    /// Interaction logic for OlapClient view.
    /// </summary>
    public class DrillThroughViewModel : NotificationObject, IDisposable
    {
        #region Members
        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="DrillThroughViewModel"/> class.
        /// </summary>
        public DrillThroughViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = DrillThroughModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = DrillThroughModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            this.olapDataManager = new OlapDataManager(ConnectionString);
            this.olapDataManager.SetCurrentReport(CreateOlapReport());
        }
        #endregion

        #region Properties

        public OlapDataManager ClientDataManager
        {
            get { return this.olapDataManager; }
            set { this.olapDataManager = value; }
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && this.olapDataManager != null)
                this.olapDataManager.Dispose();
        }
        #endregion

        #region Methods

        private OlapReport CreateOlapReport()
        {
            OlapReport olapReport = new OlapReport() { Name = "VirtualKPI.Report" };
            olapReport.CurrentCubeName = "Adventure Works";

            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            ///Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);

            ///Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);

            return olapReport;
        }

        #endregion
    }
}
