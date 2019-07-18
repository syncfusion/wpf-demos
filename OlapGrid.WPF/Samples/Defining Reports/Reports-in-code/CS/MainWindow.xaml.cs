#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Olap.Model;
using Syncfusion.Olap.MDXQueryBuilder;
using System.IO;
using Syncfusion.Windows.Shared;
using System.Threading;
using SampleUtils;
using Syncfusion.Olap.ReportBuilder;

namespace ComplexMultipleMembers
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : SampleWindow
    {

        #region Fields
        OlapDataManager olapDataManager = null;
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();            
            try
            {
                string connectionString = GetConnectionString();
                if (connectionString != "")
                    olapDataManager = new OlapDataManager(connectionString);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data will not be loaded properly");
            }

            foreach (RadioButton rbutton in this.rBtnGrid.Children)
            {
                if (rbutton != null)
                {
                    rbutton.Checked += new RoutedEventHandler(rbutton_Checked);
                }
            }
            
        }
       
        #endregion 

        #region Helper method

        #region SimpleDimensions
        OlapReport SimpleDimensions()
        {

            // CubeModel cubeModel = new CubeModel(ConnectionString);
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Name for the Dimension Element
            dimensionElementColumn.Name = "Customer";

            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow.Name = "Date";

            /// Adding Column Members
            olapReport.CategoricalElements.Add(new Item { ElementValue = dimensionElementColumn });
            ///Adding Measure Element
            olapReport.CategoricalElements.Add(new Item { ElementValue = measureElementColumn });
            ///Adding Row Members
            olapReport.SeriesElements.Add(new Item { ElementValue = dimensionElementRow });

            return olapReport;
        }
        #endregion

        #region  HierarchyandLevels
        OlapReport HierarchyandLevels()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();

            dimensionElementColumn.Name = "Sales Channel";
            dimensionElementColumn.HierarchyName = "Sales Channel";

            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            DimensionElement dimensionElementRow = new DimensionElement();
            //Specifying the dimension name
            dimensionElementRow.Name = "Date";

            //Adding the level with the Hierarchy Name
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Semester");

            olapReport.CategoricalElements.Add(new Item { ElementValue = dimensionElementColumn });
            olapReport.CategoricalElements.Add(new Item { ElementValue = measureElementColumn });
            olapReport.SeriesElements.Add(new Item { ElementValue = dimensionElementRow });

            return olapReport;
        }
        #endregion

        #region MultipleSeriesDimensions
        OlapReport MultipleSeriesDimensions()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementColumn.Name = "Customer";

            //Specifying the Hierarchy Name
            dimensionElementColumn.HierarchyName = "Customer Geography";

            MeasureElements measureElementColumn = new MeasureElements();
            measureElementColumn.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });

            DimensionElement dimensionElementRow1 = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow1.Name = "Date";

            //Adding the level Elemnet along with the Hierarchy Name
            dimensionElementRow1.AddLevel("Fiscal", "Fiscal Year");

            DimensionElement dimensionElementRow2 = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementRow2.Name = "Sales Channel";

            //Specifying the Hierarchy Name
            dimensionElementRow2.AddLevel("Sales Channel", "Sales Channel");

            olapReport.CategoricalElements.Add(new Item { ElementValue = dimensionElementColumn });
            olapReport.CategoricalElements.Add(new Item { ElementValue = measureElementColumn });
            olapReport.SeriesElements.Add(new Item { ElementValue = dimensionElementRow1 });
            olapReport.SeriesElements.Add(new Item { ElementValue = dimensionElementRow2 });

            return olapReport;
        }
        #endregion

        #region MultipleMeasuresInSeries
        OlapReport MultipleMeasuresInSeries()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();
            //Specifying the Dimension Name
            dimensionElementColumn.Name = "Customer";

            //Adding the Level Element along with the Hierarchy name in the Dimension
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            MeasureElements measureElementRow = new MeasureElements();
            measureElementRow.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });
            measureElementRow.Elements.Add(new MeasureElement { Name = "Internet Total Product Cost" });

            DimensionElement dimensionElementRow = new DimensionElement();

            //Specifying the dimension Name
            dimensionElementRow.Name = "Date";

            //Adding the level Element along with the Hierarchy Element
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            olapReport.CategoricalElements.Add(new Item { ElementValue = dimensionElementColumn });
            olapReport.SeriesElements.Add(new Item { ElementValue = measureElementRow });
            olapReport.SeriesElements.Add(new Item { ElementValue = dimensionElementRow });

            return olapReport;
        }
        #endregion

        #region Slicing by Measures
        OlapReport SlicingByMeasures()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();

            //Specifying the dimension Name
            dimensionElementColumn.Name = "Customer";

            //Adding the Level Name along with the Hierarchy Name
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            DimensionElement dimensionElementRow = new DimensionElement();

            //Specifying the dimension Name
            dimensionElementRow.Name = "Date";

            //Adding the Level Name along with the Hierarchy Name
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            olapReport.CategoricalElements.Add(new Item { ElementValue = dimensionElementColumn });
            olapReport.SeriesElements.Add(new Item { ElementValue = dimensionElementRow });

            MeasureElements measureElementSlicer = new MeasureElements();
            measureElementSlicer.Elements.Add(new MeasureElement { Name = "Internet Sales Amount" });
            olapReport.SlicerElements.Add(new Item { ElementValue = measureElementSlicer });

            return olapReport;
        }
        #endregion

        #region Slicing by Dimensions
        OlapReport SlicingByDimensions()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();

            //Specifying the dimension Name
            dimensionElementColumn.Name = "Customer";

            //Adding the Level Name along with the Hierarchy Name
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            DimensionElement dimensionElementRow = new DimensionElement();

            //Specifying the dimension Name
            dimensionElementRow.Name = "Date";

            //Adding the Level Name along with the Hierarchy Name
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");

            DimensionElement dimensionElementSlicer = new DimensionElement();
            dimensionElementSlicer.Name = "Sales Channel";
            dimensionElementSlicer.AddLevel("Sales Channel", "Sales Channel");

            olapReport.CategoricalElements.Add(new Item { ElementValue = dimensionElementColumn });
            olapReport.SeriesElements.Add(new Item { ElementValue = dimensionElementRow });
            olapReport.SlicerElements.Add(new Item { ElementValue = dimensionElementSlicer });

            return olapReport;
        }
        #endregion

        #region Filtered Dimensions
        OlapReport FilteredDimensions()
        {
            OlapReport olapReport = new OlapReport();
            olapReport.CurrentCubeName = "Adventure Works";

            DimensionElement dimensionElementColumn = new DimensionElement();

            //Specifying the dimension Name
            dimensionElementColumn.Name = "Customer";

            //Adding the Level Name along with the Hierarchy Name
            dimensionElementColumn.AddLevel("Customer Geography", "Country");

            DimensionElement dimensionElementRow = new DimensionElement();
            dimensionElementRow.Name = "Date";
            dimensionElementRow.AddLevel("Fiscal", "Fiscal Year");
            dimensionElementRow.Hierarchy.LevelElements["Year"].Add("FY 2002");
            dimensionElementRow.Hierarchy.LevelElements["Year"].IncludeAvailableMembers = true;


            olapReport.CategoricalElements.Add(new Item { ElementValue = dimensionElementColumn });
            olapReport.SeriesElements.Add(new Item { ElementValue = dimensionElementRow });

            return olapReport;
        }
        #endregion

        #endregion

        #region Events
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                if (olapDataManager != null)
                {
                    this.ShowWaitingDialog();
                    olapDataManager.SetCurrentReport(SimpleDimensions());
                    olapgrid1.OlapDataManager = olapDataManager;               
                    olapgrid1.DataBind();
                    this.CloseWaitingDialog();
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }

        private void SampleWindow_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            this.olapgrid1.Height = e.NewSize.Height - 140;
            this.olapgrid1.Width = e.NewSize.Width - 240;
        }

        void rbutton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rButton = sender as RadioButton;
            try
            {
                if (olapDataManager != null)
                {
                    this.ShowWaitingDialog();
                    switch (rButton.Content.ToString())
                    {
                        case "Simple Dimensions":
                           olapgrid1.OlapDataManager.SetCurrentReport(SimpleDimensions());
                            break;
                        case "Hierarchy and Levels":
                           olapgrid1.OlapDataManager.SetCurrentReport(HierarchyandLevels());
                            break;
                        case "Multiple Series Dimensions":
                           olapgrid1.OlapDataManager.SetCurrentReport(MultipleSeriesDimensions());
                            break;
                        case "Multiple Measures in Series":
                           olapgrid1.OlapDataManager.SetCurrentReport(MultipleMeasuresInSeries());
                            break;
                        case "Slicing by Measures":
                           olapgrid1.OlapDataManager.SetCurrentReport(SlicingByMeasures());
                            break;
                        case "Slicing by Dimensions":
                           olapgrid1.OlapDataManager.SetCurrentReport(SlicingByDimensions());
                            break;
                        case "Filtered Dimensions":
                           olapgrid1.OlapDataManager.SetCurrentReport(FilteredDimensions());
                            break;
                    }
                    olapgrid1.DataBind();
                    this.CloseWaitingDialog();
                }
            }
            catch (Exception ex)
            {
                ShowExceptionMessage(ex);
            }
        }
        #endregion
    }
}
