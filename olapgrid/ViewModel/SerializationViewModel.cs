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
    using System.Collections.Generic;
    using Syncfusion.Olap.Reports;
    using Syncfusion.Olap.Manager;
    using System.Windows;
    using System.Windows.Media;
    using Syncfusion.Windows.Shared;
    using Microsoft.Win32;
    using System.Reflection;

    /// <summary>
    /// Interaction logic for OlapGrid view.
    /// </summary>
    public class SerializationViewModel : NotificationObject, IDisposable
    {
        #region Members
        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;
        private DelegateCommand<object> loadButtonCommand;
        private DelegateCommand<object> expanderVisibilityCommand;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SerializationViewModel"/> class.
        /// </summary>
        public SerializationViewModel()
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
            olapDataManager.SetCurrentReport(OlapReport());
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
        /// Gets the grid layouts.
        /// </summary>
        /// <value>The grid layouts.</value>
        public List<Syncfusion.Olap.Engine.GridLayout> GridLayouts
        {
            get
            {
                return new List<Syncfusion.Olap.Engine.GridLayout> { Syncfusion.Olap.Engine.GridLayout.Normal, Syncfusion.Olap.Engine.GridLayout.ExcelLikeLayout, Syncfusion.Olap.Engine.GridLayout.NoSummaries, Syncfusion.Olap.Engine.GridLayout.NormalTopSummary };
            }
        }

        /// <summary>
        /// Gets the color list.
        /// </summary>
        /// <value>The color list.</value>
        public List<string> ColorList
        {
            get { return GetColors(); }
        }

        /// <summary>
        /// Gets the value cell alignments.
        /// </summary>
        /// <value>The value cell alignments.</value>
        public List<HorizontalAlignment> ValueCellAlignments
        {
            get
            {
                return new List<HorizontalAlignment> { HorizontalAlignment.Left, HorizontalAlignment.Center, HorizontalAlignment.Right };
            }
        }


        public DelegateCommand<object> LoadCommand
        {
            get
            {
                loadButtonCommand = loadButtonCommand ?? new DelegateCommand<object>(LoadReport);
                return loadButtonCommand;
            }
            set { loadButtonCommand = value; }
        }

        /// <summary>
        /// Gets or sets the expander visibility command.
        /// </summary>
        /// <value>The expander visibility command.</value>
        public DelegateCommand<object> ExpanderVisibilityCommand
        {
            get
            {
                expanderVisibilityCommand = expanderVisibilityCommand ?? new DelegateCommand<object>(ToggleExpanderVisibility);
                return expanderVisibilityCommand;
            }
            set { expanderVisibilityCommand = value; }
        }

        #endregion

        #region Methods

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Gets the colors.
        /// </summary>
        /// <returns></returns>
        internal List<string> GetColors()
        {
            List<string> colorList = new List<string>();
            Type brush = typeof(Brushes);
            foreach (MemberInfo info in brush.GetMembers())
            {
                if (info is PropertyInfo)
                {
                    PropertyInfo pi = info as PropertyInfo;
                    colorList.Add(pi.Name);
                }
            }
            return colorList;
        }

        private void LoadReport(object parm)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.AddExtension = true;
                openFileDialog.DefaultExt = "xml";
                openFileDialog.Filter = "Report Set (.xml)|*.xml";
                if (openFileDialog.ShowDialog() == true)
                {
                    this.GridDataManager.LoadReportDefinitionFile(openFileDialog.FileName);
                    if (this.GridDataManager.Reports.Count > 0)
                        this.GridDataManager.SetCurrentReport(this.GridDataManager.Reports[0]);
                    this.GridDataManager.NotifyElementModified();

                    MessageBox.Show("Report has been loaded successfully.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while De-serializing.\nException Message:" + ex.Message, "Error on De-serialization.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        /// <summary>
        /// Toggles the expander visibility.
        /// </summary>
        /// <param name="parm">The parameter.</param>
        private void ToggleExpanderVisibility(object parm)
        {
            if (parm is bool && this.GridDataManager != null && this.GridDataManager.CurrentReport != null)
            {
                this.GridDataManager.CurrentReport.ShowExpanders = (bool)parm;
                this.GridDataManager.NotifyElementModified();
            }
        }

        /// <summary>
        /// Creates the OlapReport.
        /// </summary>
        /// <returns></returns>
        private OlapReport OlapReport()
        {
            OlapReport olapReport1 = new OlapReport();
            olapReport1.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Name for the Dimension Element
            dimensionElementColumn.Name = "Customer";
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            MeasureElements measureElementColumn = new MeasureElements();
            //Specifying the Name for the Measure Element
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow.Name = "Product";
            dimensionElementRow.AddLevel("Product Categories", "Category");
            DimensionElement dimensionElementRow1 = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow1.Name = "Date";
            dimensionElementRow1.AddLevel("Fiscal", "Fiscal Year");
            //Adding Column Members
            olapReport1.CategoricalElements.Add(dimensionElementColumn);
            //Adding Measure Element
            olapReport1.CategoricalElements.Add(measureElementColumn);
            //Adding Row Members
            olapReport1.SeriesElements.Add(dimensionElementRow);
            olapReport1.SeriesElements.Add(dimensionElementRow1);

            return olapReport1;
        }

        private void Dispose(bool disposing)
        {
            if (disposing && this.olapDataManager != null)
                this.olapDataManager.Dispose();
        }

        #endregion
    }
}
