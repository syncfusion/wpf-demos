#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace ExportingGrid.ViewModel
{
    using Syncfusion.Olap.Reports;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Engine;
    using Syncfusion.Windows.Grid.Olap.Common;
    using Syncfusion.Windows.Shared;
    using Microsoft.Win32;
    using Syncfusion.Windows.Grid.Olap.Converter;
    using System.Windows;
    using System;

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
        private ExportingGridStyleInfo exportSytleInfo;
        private DelegateCommand<object> exportCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            olapDataManager = new OlapDataManager(ConnectionString);
            olapDataManager.SetCurrentReport(LoadReports());
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
        /// Gets or sets the grid layout.
        /// </summary>
        /// <value>The grid layout.</value>
        public GridLayout GridLayout { get; set; }

        /// <summary>
        /// Gets or sets the export style info.
        /// </summary>
        /// <value>The export style info.</value>
        public ExportingGridStyleInfo ExportGridStyleInfo
        {
            get
            {
                exportSytleInfo = exportSytleInfo ?? new ExportingGridStyleInfo();
                return exportSytleInfo;
            }
            set
            { 
                exportSytleInfo = value;
                RaisePropertyChanged("ExportGridStyleInfo");
            }
        }

        /// <summary>
        /// Gets or sets the export command.
        /// </summary>
        /// <value>The export command.</value>
        public DelegateCommand<object> ExportCommand
        {
            get
            {
                exportCommand = exportCommand ?? new DelegateCommand<object>(DoExport);
                return exportCommand;
            }
            set { exportCommand = value; }
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

        private void DoExport(object parm)
        {
            if (parm != null)
            {
                if (parm.ToString().Equals("Export to Excel"))
                {
                    try
                    {
                        SaveFileDialog savedialog = new SaveFileDialog();
                        savedialog.AddExtension = true;
                        savedialog.FileName = "Sample";
                        savedialog.DefaultExt = "xls";
                        savedialog.Filter = "Excel file (.xls)|*.xls";

                        if (savedialog.ShowDialog() == true)
                        {
                            GridExcelExport gridExcelExport = new GridExcelExport(this.GridDataManager.PivotEngine, this.ExportGridStyleInfo, this.GridLayout, savedialog.DefaultExt, false);
                            gridExcelExport.Export(savedialog.FileName);
                            MessageBox.Show("Exported successfully!.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error on Excel export.\nException Message: " + ex.Message + "\nStack Trace: " + ex.StackTrace, "Export error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (parm.ToString().Equals("Export to Word"))
                {
                    try
                    {
                        SaveFileDialog savedialog = new SaveFileDialog();
                        savedialog.AddExtension = true;
                        savedialog.FileName = "Sample";
                        savedialog.DefaultExt = "Doc";
                        savedialog.Filter = "Word file (.Doc)|*.Doc";
                        if (savedialog.ShowDialog() == true)
                        {
                            GridWordExport gridWordExport = new GridWordExport(this.GridDataManager.PivotEngine, this.GridLayout);
                            gridWordExport.Export(savedialog.FileName, this.ExportGridStyleInfo);
                            MessageBox.Show("Exported successfully!.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error on Word export.\nException Message: " + ex.Message + "\nStack Trace: " + ex.StackTrace, "Export error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (parm.ToString().Equals("Export to Pdf"))
                {
                    try
                    {
                        SaveFileDialog savedialog = new SaveFileDialog();
                        savedialog.AddExtension = true;
                        savedialog.FileName = "Sample";
                        savedialog.DefaultExt = "pdf";
                        savedialog.Filter = "Pdf file (.pdf)|*.pdf";

                        if (savedialog.ShowDialog() == true)
                        {
                            GridPdfExport gridPdfExport = new GridPdfExport(this.GridDataManager.PivotEngine, this.ExportGridStyleInfo);
                            gridPdfExport.Export(savedialog.FileName);
                            MessageBox.Show("Exported successfully!.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error on PDF export.\nException Message: " + ex.Message + "\nStack Trace: " + ex.StackTrace, "Export error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else if (parm.ToString().Equals("Export to CSV"))
                {
                    try
                    {
                        SaveFileDialog savedialog = new SaveFileDialog();
                        savedialog.AddExtension = true;
                        savedialog.FileName = "Sample";
                        savedialog.DefaultExt = "CSV";
                        savedialog.Filter = "Csv file (.csv)|*.csv";
                        if (savedialog.ShowDialog() == true)
                        {
                            GridCsvExport gridCsvExport = new GridCsvExport(this.GridDataManager.PivotEngine);
                            gridCsvExport.Export(savedialog.FileName);
                            MessageBox.Show("CSV document exported successfully!.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error on CSV export.\nException Message: " + ex.Message + "\nStack Trace: " + ex.StackTrace, "Export error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }

            }
        }

        /// <summary>
        /// Creates the OlapReport.
        /// </summary>
        /// <returns></returns>
        OlapReport LoadReports()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            // Specifying the Name for the Dimension Element
            dimensionElementColumn.Name = "Customer";
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            DimensionElement dimensionElementRow = new DimensionElement();
            // Specifying the Dimension Name
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");
            DimensionElement dimensionElementRow1 = new DimensionElement();
            // Specifying the Dimension Name
            dimensionElementRow1.Name = "Product";
            dimensionElementRow1.AddLevel("Product Categories", "Category");
            // Adding Column Members
            olapReport.CategoricalElements.Add(dimensionElementColumn);
            // Adding Measure Element
            olapReport.CategoricalElements.Add(measureElementColumn);
            // Adding Row Members
            olapReport.SeriesElements.Add(dimensionElementRow);
            olapReport.SeriesElements.Add(dimensionElementRow1);

            return olapReport;
        }

        #endregion
    }
}