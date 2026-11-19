#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Data;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Provides series-selection and time-series data for selection interactions.</summary>
    public class SelectionChartViewModel : NotificationObject, IDisposable
    {
        /// <summary>Gets or sets the dataset used for series selection.</summary>
        public ObservableCollection<SelectionChartModel> SeriesSelectionData { get; set; }

        /// <summary>Gets or sets the time-series selection dataset.</summary>
        public ObservableCollection<PerformanceData> SelectionData { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="SelectionChartViewModel"/> class.
        /// </summary>
        public SelectionChartViewModel()
        {
            SeriesSelectionData = new ObservableCollection<SelectionChartModel>()
            {
                new SelectionChartModel() {Country="CHN",Children=17.5,Adults=68.3,Elders=14.2},
                new SelectionChartModel() {Country="IND",Children=25.8,Adults=67.4,Elders=6.8},
                new SelectionChartModel() {Country="PAK",Children=34.6,Adults=61,Elders=4.4},
                new SelectionChartModel() {Country="IDN",Children=25.6,Adults=67.9,Elders=6.5},
                new SelectionChartModel() {Country="BGD",Children=26.3,Adults=68.4,Elders=5.3},
            };

            DateTime date = new DateTime(2017, 3, 01);
            Random r = new Random();
            SelectionData = new ObservableCollection<PerformanceData>();
            for (int i = 0; i < 10; i++)
            {
                SelectionData.Add(new PerformanceData(date, r.Next(10, 65)));
                date = date.AddHours(1);
            }
        }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
           if(SeriesSelectionData != null)
                SeriesSelectionData.Clear();

           if(SelectionData != null)
                SelectionData.Clear();
        }
    }

    /// <summary>Represents a performance data point with date and value.</summary>
    public class PerformanceData
    {
        /// <summary>Gets or sets the date of the performance data point.</summary>
        public DateTime Date { get; set; }

        /// <summary>Gets or sets the numeric value of the performance data point.</summary>
        public double Value { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PerformanceData"/> class.
        /// </summary>
        /// <param name="date">Represents the date of the performance data point.</param>
        /// <param name="value">Represents the numeric value of the performance data point.</param>
        public PerformanceData(DateTime date, double value)
        {
            Date = date;
            Value = value;
        }
    }

    /// <summary>Converts DateTime values to formatted strings for chart selection display.</summary>
    public class SelectionValueConverter : IValueConverter
    {
        /// <summary>Converts a source value to a value suitable for the binding target.</summary>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ((DateTime)value).ToString("ddd-hh:mm");
        }

        /// <summary>Converts a binding target value back to a value suitable for the source.</summary>
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }
    }
}
