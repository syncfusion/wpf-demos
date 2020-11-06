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
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using System.Data;
    using Syncfusion.Windows.Shared;
    using Syncfusion.Olap.Engine;

    /// <summary>
    /// Interaction logic for OlapGrid view.
    /// </summary>
    public class TransactionViewModel : NotificationObject, IDisposable
    {
        #region Members

        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private TransactionModel modelObject;
        private OlapDataManager olapDataManager;
        private DataTable dTable;
        private DelegateCommand<object> hyperlinkCellCommand;
        private string descText;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="TransactionViewModel"/> class.
        /// </summary>
        public TransactionViewModel()
        {
            modelObject = new TransactionModel();
            if (AppDomain.CurrentDomain.BaseDirectory.Contains("Binaries_"))
            {
                ConnectionString = KPIModel.InitializeTransaction(System.IO.Path.GetFullPath(@"..\..\common\Assets\Config\OLAPSample.config"));
            }
            else
            {
                ConnectionString = KPIModel.InitializeTransaction(System.IO.Path.GetFullPath(@"..\..\..\common\Assets\Config\OLAPSample.config"));
            }
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
        /// Gets or sets the grid items source.
        /// </summary>
        /// <value>The grid items source.</value>
        public DataTable GridItemsSource
        {
            get { return dTable ?? (dTable = modelObject.GetItemsSource()); }
            set
            {
                dTable = value;
                RaisePropertyChanged("GridItemsSource");
            }
        }


        /// <summary>
        /// Gets or sets the hyperlink cell command.
        /// </summary>
        /// <value>The hyperlink cell command.</value>
        public DelegateCommand<object> HyperlinkCellCommad
        {
            get
            {
                hyperlinkCellCommand = hyperlinkCellCommand ?? new DelegateCommand<object>(DoCellClickProcess);
                return hyperlinkCellCommand;
            }
            set { hyperlinkCellCommand = value; }
        }


        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        /// <value>The description text.</value>
        public string DescriptionText
        {
            get
            {
                descText = descText ?? "Detailed view of the sales quantity across countries each year.";
                return descText;
            }
            set
            {
                descText = value;
                RaisePropertyChanged("DescriptionText");
            }
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
            if (disposing)
            {
                if (this.olapDataManager != null)
                    this.olapDataManager.Dispose();
                if (modelObject != null)
                    modelObject.Dispose();
            }
        }

        private void DoCellClickProcess(object parm)
        {
            if (parm is PivotCellDescriptor)
            {
                string country = string.Empty;
                string state = string.Empty;
                string city = string.Empty;
                string year = string.Empty;
                string semester = string.Empty;
                string quarter = string.Empty;
                string month = string.Empty;
                string date = string.Empty;
                PivotCellDescriptor cellDescriptor = parm as PivotCellDescriptor;
                PivotValueCellData cellData = this.GridDataManager.PivotEngine.GetCellData(cellDescriptor);

                if (cellDescriptor.CellType == PivotCellDescriptorType.Value)
                {
                    if (cellData.Columns.Count == 0 && cellData.Rows.Count == 0)
                    {
                        modelObject.SqlQuery = modelObject.SqlQuery.Append("Select * from [Sheet1$]");
                    }
                    else
                    {
                        modelObject.SqlQuery = modelObject.SqlQuery.Append("Select ");

                        if (cellData.Columns.Count == 0)
                        {
                            modelObject.SqlQuery = modelObject.SqlQuery.Append(" Country,State,City");
                        }
                        for (int i = 0; i < cellData.Columns.Count; i++)
                        {
                            switch (i)
                            {
                                case 0:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(" Country");

                                    break;
                                case 1:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(",State");

                                    break;
                                case 2:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(",City");

                                    break;
                            }
                        }
                        if (cellData.Rows.Count == 0)
                        {
                            modelObject.SqlQuery = modelObject.SqlQuery.Append(" ,Year,Semester,Quarter,Month,Date");
                        }

                        for (int j = 0; j < cellData.Rows.Count; j++)
                        {
                            switch (j)
                            {
                                case 0:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(" ,Year");

                                    break;
                                case 1:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(" ,Semester");

                                    break;
                                case 2:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(" ,Quarter");

                                    break;

                                case 3:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(" ,Month");

                                    break;

                                case 4:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(" ,Date");

                                    break;
                            }
                        }

                        modelObject.SqlQuery = modelObject.SqlQuery.Append(" ,ProductCategory,ProductSubCategory,ProductName,Quantity from [Sheet1$] where ");
                        for (int i = 0; i < cellData.Columns.Count; i++)
                        {
                            if (i > 0)
                            {
                                modelObject.SqlQuery = modelObject.SqlQuery.Append(" And ");
                            }

                            switch (i)
                            {
                                case 0:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(" Country = '" + cellData.Columns[0] + "'");
                                    if (cellData.Columns[0] != string.Empty)
                                        country = " at " + cellData.Columns[0];
                                    break;

                                case 1:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(" State = '" + cellData.Columns[1] + "'");
                                    if (cellData.Columns[1] != string.Empty)
                                        state = " of " + cellData.Columns[1];
                                    break;

                                case 2:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(" City = '" + cellData.Columns[2] + "'");
                                    if (cellData.Columns[2] != string.Empty)
                                        city = " in " + cellData.Columns[2];
                                    break;
                            }
                        }
                        for (int j = 0; j < cellData.Rows.Count; j++)
                        {
                            if (j > 0 || cellData.Columns.Count > 0)
                            {
                                modelObject.SqlQuery = modelObject.SqlQuery.Append(" And ");
                            }

                            switch (j)
                            {
                                case 0:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(" Year='" + cellData.Rows[0] + "' ");
                                    year = " of the year " + cellData.Rows[0].Replace("FY ", string.Empty);
                                    break;

                                case 1:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(" Semester='" + cellData.Rows[1] + "' ");
                                    semester = " during semester " + cellData.Rows[1].Replace(" FY", string.Empty).Replace("H", string.Empty).Replace(cellData.Rows[0].Replace("FY", string.Empty), string.Empty);
                                    break;

                                case 2:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(" Quarter ='" + cellData.Rows[2] + "' ");
                                    if (cellData.Rows[2] != string.Empty)
                                        semester = string.Empty;
                                    quarter = " during quarter " + cellData.Rows[2].Replace(" FY", string.Empty).Replace("Q", string.Empty).Replace(cellData.Rows[0].Replace("FY", string.Empty), string.Empty);
                                    break;

                                case 3:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(" Month ='" + cellData.Rows[3] + "' ");
                                    if (cellData.Rows[3] != string.Empty)
                                    {
                                        year = quarter = semester = string.Empty;
                                    }
                                    month = " on " + cellData.Rows[3];
                                    break;

                                case 4:

                                    modelObject.SqlQuery = modelObject.SqlQuery.Append(" Date ='" + cellData.Rows[4] + "' ");
                                    if (cellData.Rows[4] != string.Empty)
                                    {
                                        month = year = string.Empty;
                                    }
                                    date = " on " + cellData.Rows[4];
                                    break;
                            }
                        }
                    }
                }

                if (modelObject.SqlQuery != null && modelObject.SqlQuery.Length > 0)
                {
                    this.GridItemsSource = modelObject.GetItemsSource();
                }

                this.DescriptionText = "Detailed view of sales quantity" + city + state + country + date + month + quarter + semester + year;
            }
        }
        /// <summary>
        /// Creates the OlapReport.
        /// </summary>
        /// <returns></returns>
        private OlapReport CreateReport()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Sales DB";
            //Defining the categorical dimension element
            DimensionElement dimensionElementColumn = new DimensionElement();
            dimensionElementColumn.Name = "Geography";
            dimensionElementColumn.AddLevel("Geography Hierarchy", "Country");
            ////Specifying the measure element
            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Quantity" });
            //Specifying the series dimension element
            DimensionElement dimensionElementRow = new DimensionElement();
            dimensionElementRow.Name = "Sales Transaction";
            dimensionElementRow.AddLevel("Fiscal Year", "Year");
            // Adding column members to the manager
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            //Adding measure elements to the manager in the column axis
            olapReport.CategoricalElements.Add(measureElementColumn);
            //Adding row members to the manager
            olapReport.SeriesElements.Add(dimensionElementRow);
            return olapReport;
        }

        #endregion
    }
}
