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
    using System.Collections.Generic;
    using Syncfusion.Windows.Shared;
    using Syncfusion.Olap.Manager;
    using Syncfusion.Olap.Reports;
    using System.Windows;
    using System.Drawing;
    using System.Reflection;
    using System.Collections;
    using System.Windows.Data;

    public class ChartAppearanceViewModel : NotificationObject, IDisposable
    {
        #region Members

        /// <summary>
        /// Shared connection string.
        /// </summary>
        public static string ConnectionString;
        private OlapDataManager olapDataManager;
        private Visibility showLegend = Visibility.Visible;
        private Visibility showLegendCheckBox = Visibility.Collapsed;
        private DelegateCommand<object> legendDelegateCommand;
        private DelegateCommand<object> legendCheckBoxDelegateCommand;

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ChartAppearanceViewModel"/> class.
        /// </summary>
        public ChartAppearanceViewModel()
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


        /// <summary>
        /// Gets or sets the legend visibility.
        /// </summary>
        /// <value>The legend visibility.</value>
        public Visibility ShowLegend
        {
            get { return showLegend; }
            set { showLegend = value; RaisePropertyChanged("ShowLegend"); }
        }

        /// <summary>
        /// Gets or sets the delegate command to show legend.
        /// </summary>
        /// <value>The delegate command to show legend.</value>
        public DelegateCommand<object> LegendDelegateCommand
        {
            get
            {
                return legendDelegateCommand ?? new DelegateCommand<object>(LegendOption);
            }
            set
            {
                legendDelegateCommand = value;
            }
        }


        /// <summary>
        /// Gets or sets the legend visibility.
        /// </summary>
        /// <value>The legend visibility.</value>
        public Visibility ShowLegendCheckBox
        {
            get { return showLegendCheckBox; }
            set { showLegendCheckBox = value; RaisePropertyChanged("ShowLegendCheckBox"); }
        }


        /// <summary>
        /// Gets or sets the delegate command to show legend.
        /// </summary>
        /// <value>The delegate command to show legend.</value>
        public DelegateCommand<object> LegendCheckBoxDelegateCommand
        {
            get
            {
                return legendCheckBoxDelegateCommand ?? new DelegateCommand<object>(LegendCheckBoxOption);
            }
            set
            {
                legendCheckBoxDelegateCommand = value;
            }
        }

        #endregion

        #region Helper Method

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
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

        /// <summary>
        /// Shows the legend of the control.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        private void LegendOption(object parameter)
        {
            if (parameter.ToString() == "True")
                this.ShowLegend = Visibility.Visible;
            else
            {
                this.ShowLegend = Visibility.Collapsed;
                this.ShowLegendCheckBox = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Shows the legend check box.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        private void LegendCheckBoxOption(object parameter)
        {
            this.ShowLegendCheckBox = parameter.ToString() == "True" ? Visibility.Visible : Visibility.Collapsed;
        }

        private void Dispose(bool disposing)
        {
            if (disposing && this.olapDataManager != null)
                this.olapDataManager.Dispose();
        }
        #endregion
    }

    public class VisiblityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value != null && Visibility.Visible == (Visibility)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return false;
        }
    }
}
