#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ViewModel.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace VisualStyles.ViewModel
{
    using System;
    using System.Collections.Generic;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Shared;

    public class ViewModel : NotificationObject, IDisposable
    {
        #region Fields

        /// <summary>
        /// Specifies the connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager dataManager;
        #endregion

        #region Constructor

        public ViewModel()
        {
            if (ConnectionString != String.Empty)
            {
                dataManager = new OlapDataManager(ConnectionString);
                dataManager.SetCurrentReport(SimpleDimensions());
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

        public IEnumerable<String> OlapChartVisualStyles
        {
            get
            {
                return new List<string>() { "Blend", "Metro", "Office2010Black", "Office2010Blue", "Office2010Silver", "Office2013LightGray", "Office2013DarkGray", "Office2013White", "VisualStudio2013", "Office365", "Office2016White", "Office2016DarkGray", "Office2016Colorful", "VisualStudio2015", "SystemTheme" };
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
            if (disposing)
            {
                if (this.dataManager != null)
                    this.dataManager.Dispose();
            }
        }

        private OlapReport SimpleDimensions()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";
            DimensionElement dimensionElementColumn = new DimensionElement();

            //Specifying the Column Name for the Dimension and measure elements
            dimensionElementColumn.Name = "Customer";
            dimensionElementColumn.AddLevel("Customer Geography", "Country");
            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            //Specifying the Row Name for the Dimension element
            DimensionElement dimensionElementRow = new DimensionElement();
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            // Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            // Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            // Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);
            return olapReport;
        }

        #endregion
    }
}