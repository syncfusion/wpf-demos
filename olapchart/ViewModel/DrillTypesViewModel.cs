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
    using System.Windows.Media;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Shared;
    using Syncfusion.Olap.Manager;

    class DrillTypesViewModel : NotificationObject, IDisposable
    {
        #region Members
        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;
        private DelegateCommand<object> drillSelectionCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="DrillTypesViewModel"/> class.
        /// </summary>
        public DrillTypesViewModel()
        {
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = OlapChartModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = OlapChartModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            olapDataManager = new OlapDataManager(ConnectionString);
            olapDataManager.SetCurrentReport(CreateOlapReport("Drill Member"));
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the grid data manager.
        /// </summary>
        /// <value>The grid data manager.</value>
        public OlapDataManager DataManager
        {
            get { return olapDataManager; }
            set { olapDataManager = value; }
        }


        /// <summary>
        /// Gets or sets the drill selection command.
        /// </summary>
        /// <value>The drill selection command.</value>
        public DelegateCommand<object> DrillSelectionCommand
        {
            get
            {
                drillSelectionCommand = drillSelectionCommand ?? new DelegateCommand<object>(DrillTypeChanged);
                return drillSelectionCommand;
            }
            set { drillSelectionCommand = value; }
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && olapDataManager != null)
                olapDataManager.Dispose();
        }

        private void DrillTypeChanged(object parameter)
        {
            if (parameter != null)
            {
                DataManager.SetCurrentReport(CreateOlapReport(parameter.ToString()));
                DataManager.NotifyElementModified();
            }
        }

        /// <summary>
        /// OlapReport for Gross Profit over Product and Year
        /// </summary>
        /// <returns></returns>
        private OlapReport CreateOlapReport(string drillType)
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            olapReport.DrillType = drillType.Equals("Drill Member") ? DrillType.DrillMember : DrillType.DrillPosition;
            olapReport.ChartSettings.BorderColor = System.Drawing.Color.FromArgb(255, 204, 204, 204);
            olapReport.ChartSettings.StrokeThickness = 1;
            olapReport.ChartSettings.ChartColorPalette = "Metro";
            olapReport.ChartSettings.LegendVisibility = true;
            olapReport.ChartSettings.XAxisFontFace = "Segoe UI";
            olapReport.ChartSettings.XAxisForeGround = System.Drawing.Color.FromArgb(255, 17, 158, 218);
            olapReport.ChartSettings.XLabelFontWeight = "Normal";
            olapReport.ChartSettings.YAxisFontFace = "Segoe UI";
            olapReport.ChartSettings.YAxisForeGround = System.Drawing.Color.FromArgb(255, 17, 158, 218);
            olapReport.ChartSettings.YLabelFontWeight = "Normal";

            DimensionElement dimensionElement = new DimensionElement { Name = "Customer", HierarchyName = "Customer" };
            dimensionElement.AddLevel("Customer Geography", "Country");
            olapReport.SeriesElements.Add(dimensionElement);

            dimensionElement = new DimensionElement { Name = "Geography", HierarchyName = "Geography" };
            dimensionElement.AddLevel("Geography", "Country");
            dimensionElement.Hierarchy.LevelElements["Country"].IncludeAvailableMembers = true;
            dimensionElement.Hierarchy.LevelElements["Country"].Add("Australia");
            dimensionElement.Hierarchy.LevelElements["Country"].Add("Canada");
            dimensionElement.Hierarchy.LevelElements["Country"].Add("United States");
            olapReport.SeriesElements.Add(dimensionElement);

            dimensionElement = new DimensionElement { Name = "Date" };
            dimensionElement.AddLevel("Fiscal", "Fiscal Year");
            olapReport.CategoricalElements.Add(dimensionElement);

            return olapReport;
        }

        #endregion
    }
}
