#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace MemberProperties.ViewModel
{
    using System;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Windows.Shared;

    /// <summary>
    /// Interaction logic for OlapGrid view.
    /// </summary>
    public class ViewModel : NotificationObject, IDisposable
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
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            olapDataManager = new OlapDataManager(ConnectionString);
            olapDataManager.SetCurrentReport(ReportWithMemberProperties());
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

        /// <summary>
        /// Creates the OlapReport with Member properties.
        /// </summary>
        /// <returns></returns>
        private OlapReport ReportWithMemberProperties()
        {
            OlapReport olapReport = new OlapReport();
            // Specifying the current cube name
            olapReport.CurrentCubeName = "Adventure Works";

            MeasureElements measureElementColumn = new MeasureElements();
            // Specifying the Name for the Measure Element
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Sales Amount Quota" });

            DimensionElement dimensionElementRow = new DimensionElement();
            // Specifying the Dimension Name
            dimensionElementRow.Name = "Employee";
            // Specifying the Hierarchy and level name for the Dimension Element
            dimensionElementRow.AddLevel("Employees", "Employee Level 02");
            dimensionElementRow.Hierarchy.LevelElements["Employee Level 02"].IncludeAvailableMembers = true;

            // Adding the Member properties to the Dimension Element
            dimensionElementRow.MemberProperties.Add(new MemberProperty("Title", "[Employee].[Employees].[Title]"));
            dimensionElementRow.MemberProperties.Add(new MemberProperty("Phone", "[Employee].[Employees].[Phone]"));
            dimensionElementRow.MemberProperties.Add(new MemberProperty("Email Address", "[Employee].[Employees].[Email Address]"));

            DimensionElement dimensionElementColumn = new DimensionElement();
            // Specifying the Dimension Name
            dimensionElementColumn.Name = "Product";
            // Specifying the Hierarchy and level name for the Dimension Element
            dimensionElementColumn.AddLevel("Product Categories", "Category");
            dimensionElementColumn.MemberProperties.Add(new MemberProperty("Dealer Price", "[Product].[Product Categories].[Dealer Price]"));
            dimensionElementColumn.MemberProperties.Add(new MemberProperty("Standard Cost", "[Product].[Product Categories].[Standard Cost]"));

            // Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);

            //Adding Column Members
            //olapReport.CategoricalElements.Add(dimensionElementColumn);
            olapReport.CategoricalElements.Add(measureElementColumn);

            return olapReport;
        }

        #endregion
    }
}