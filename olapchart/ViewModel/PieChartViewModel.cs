#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapchartdemos.wpf
{
    using System;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Windows.Shared;

    public class PieChartViewModel : NotificationObject, IDisposable
    {
        #region Field

        /// <summary>
        /// Specifies the connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager dataManager;
        #endregion

        #region Constructor

        public PieChartViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = OlapChartModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = OlapChartModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            if (ConnectionString != String.Empty)
            {
                dataManager = new OlapDataManager(ConnectionString);
                dataManager.SetCurrentReport(SimpleDimensions());
                dataManager.CurrentReport.ChartSettings.LabelsVisibility = true;
            }
        }

        #endregion

        #region Properties


        /// <summary>
        /// Gets or sets the OlapDataManager.
        /// </summary>
        /// <value>The OlapDataManager.</value>
        public OlapDataManager DataManager
        {
            get
            {
                return dataManager;
            }
            set
            {
                dataManager = value;
            }
        }

        #endregion

        #region Helper method

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && this.dataManager != null)
                this.dataManager.Dispose();
        }

        private OlapReport SimpleDimensions()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            //Specifying the Column Name for the Dimension and measure elements
            DimensionElement dimensionElementRow = new DimensionElement();
            dimensionElementRow.Name = "Customer";
            dimensionElementRow.AddLevel("Customer Geography", "Country");

            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            //Specifying the Row Name for the Dimension element
            DimensionElement dimensionElementColumn = new DimensionElement();
            dimensionElementColumn.Name = "Date";
            dimensionElementColumn.AddLevel("Fiscal", "Fiscal Year");
            dimensionElementColumn.Hierarchy.LevelElements["Fiscal Year"].IncludeAvailableMembers = true;
            dimensionElementColumn.Hierarchy.LevelElements["Fiscal Year"].Add("FY 2004");

            // Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            //Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            //Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);
            return olapReport;
        }

        #endregion
    }
}
