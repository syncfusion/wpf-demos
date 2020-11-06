#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapgriddemos.wpf
{
    using System;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Windows.Shared;

    /// <summary>
    /// Interaction logic for OlapGrid view.
    /// </summary>
    public class DrillTypesViewModel : NotificationObject, IDisposable
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
                ConnectionString = KPIModel.Initialize(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = KPIModel.Initialize(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
            olapDataManager = new OlapDataManager(ConnectionString);
            olapDataManager.SetCurrentReport(CreateOlapReport());
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the grid data manager.
        /// </summary>
        /// <value>The grid data manager.</value>
        public OlapDataManager GridDataManager
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
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposing && this.olapDataManager != null)
                this.olapDataManager.Dispose();
        }

        private void DrillTypeChanged(object parm)
        {
            if (parm != null)
            {
                if (parm.ToString().Equals("Drill Member"))
                {
                    this.GridDataManager.CurrentReport.DrillType = DrillType.DrillMember;
                }
                else
                {
                    this.GridDataManager.SetCurrentReport(CreateOlapReport());
                    this.GridDataManager.CurrentReport.DrillType = DrillType.DrillPosition;
                }
                this.GridDataManager.NotifyElementModified();
            }
        }

        /// <summary>
        /// OlapReport for Gross Profit over Product and Year
        /// </summary>
        /// <returns></returns>
        private OlapReport CreateOlapReport()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElement = new DimensionElement() { Name = "Customer", HierarchyName = "Customer" };
            dimensionElement.AddLevel("Customer Geography", "Country");
            olapReport.SeriesElements.Add(dimensionElement);

            dimensionElement = new DimensionElement() { Name = "Geography", HierarchyName = "Geography" };
            dimensionElement.AddLevel("Geography", "Country");
            olapReport.SeriesElements.Add(dimensionElement);

            dimensionElement = new DimensionElement() { Name = "Date" };
            dimensionElement.AddLevel("Fiscal", "Fiscal Year");
            olapReport.CategoricalElements.Add(dimensionElement);

            return olapReport;
        }

        #endregion
    }
}
