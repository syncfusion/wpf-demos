#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ViewModel.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace Serialization.ViewModel
{
    using System;
    using System.Collections.Generic;
    using Syncfusion.Windows.Shared;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using System.Drawing;
    using System.Reflection;
    using System.Collections;

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
            olapDataManager.SetCurrentReport(SimpleDimensions());
            
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

        public List<string> ColorCollection
        {
            get
            {
                List<string> lst = new List<string>();
                Type br = typeof(Brushes);
                foreach (MemberInfo info in br.GetMembers())
                {
                    if (info is PropertyInfo)
                    {
                        PropertyInfo pi = info as PropertyInfo;
                        lst.Add(pi.Name);
                    }
                }
                return lst;
            }
        }

        public IEnumerable PaletteCollection
        {
            get
            {
               return Enum.GetValues(typeof(Syncfusion.Windows.Chart.ChartColorPalette));
            }
        }


        #endregion

        #region Helper Methods
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

        private OlapReport SimpleDimensions()
        {
            OlapReport olapReport = new OlapReport();
            //Selecting the cube to analyze
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

            //Adding Column Members
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