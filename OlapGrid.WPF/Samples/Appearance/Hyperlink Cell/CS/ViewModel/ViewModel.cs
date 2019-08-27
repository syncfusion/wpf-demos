#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ViewModel.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace HyperlinkCell.ViewModel
{
    using System;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Windows.Shared;
    using System.Collections.ObjectModel;
    using Syncfusion.Olap.Engine;

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
        private ObservableCollection<string> argumentList;
        private DelegateCommand<object> clearCommand;
        private DelegateCommand<object> hyperlinkCellClick;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            olapDataManager = new OlapDataManager(ConnectionString);
            olapDataManager.SetCurrentReport(CreateReport());
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
        /// Gets or sets the list of arguments.
        /// </summary>
        /// <value>The list of arguments.</value>
        public ObservableCollection<string> ListOfArguments
        {
            get
            {
                argumentList = argumentList ?? new ObservableCollection<string>();
                return argumentList;
            }
        }


        /// <summary>
        /// Gets or sets the clear command.
        /// </summary>
        /// <value>The clear command.</value>
        public DelegateCommand<object> ClearCommand
        {
            get
            {
                clearCommand = clearCommand ?? new DelegateCommand<object>(ClearListBox);
                return clearCommand;
            }
            set { clearCommand = value; }
        }

        public DelegateCommand<object> HyperlinkCellClick
        {
            get
            {
                hyperlinkCellClick = new DelegateCommand<object>(HyperlinkCellClicked);
                return hyperlinkCellClick;
            }
            set { hyperlinkCellClick = value; }
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
            if (disposing && olapDataManager != null)
                olapDataManager.Dispose();
        }

        private void HyperlinkCellClicked(object parm)
        {
            if (parm is PivotCellDescriptor)
            {
                this.ListOfArguments.Add((parm as PivotCellDescriptor).CellValue);
            }
        }

        /// <summary>
        /// Clears the list box.
        /// </summary>
        /// <param name="parm">The parm.</param>
        private void ClearListBox(object parm)
        {
            this.ListOfArguments.Clear();
        }

        /// <summary>
        /// Creates the OlapReport.
        /// </summary>
        /// <returns></returns>

        #region Creating OLAP Reports
        private OlapReport CreateReport()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Name for the Dimension Element
            dimensionElementColumn.Name = "Customer";
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            MeasureElements measureElementColumn = new MeasureElements();
            //Specifying the Name for the Measure Element
            measureElementColumn.Elements.Add(new MeasureElement {Name = "Internet Sales Amount"});

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow.Name = "Employee";
            dimensionElementRow.AddLevel("Employee Department", "Department");

            //Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            //Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            //Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);

            return olapReport;
        }

        #endregion

        #endregion
    }
}