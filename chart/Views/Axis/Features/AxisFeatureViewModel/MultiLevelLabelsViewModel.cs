#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Provides monthly temperature data and styling for multi-level labels.</summary>
    public class MultiLevelLabelsViewModel : IDisposable
    {
        /// <summary>Gets or sets the temperature data collection.</summary>
        public ObservableCollection<MultiLevelLabelsModel> Collection { get; set; }

        /// <summary>Gets the available colors for label styling.</summary>
        public Array ColorArray
        {
            get
            {
                return new String[] { "Gray", "Black", "Red", "Brown" };
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MultiLevelLabelsViewModel"/> class.
        /// </summary>
        public MultiLevelLabelsViewModel()
        {
            Collection = new ObservableCollection<MultiLevelLabelsModel>();

            Collection.Add(new MultiLevelLabelsModel() { Month = "Jan", LowTemperature = 20.2, HighTemperature = 26.1 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Feb", LowTemperature = 20.1, HighTemperature = 25.5 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Mar", LowTemperature = 18.8, HighTemperature = 24.2 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Apr", LowTemperature = 16, HighTemperature = 21.8 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "May", LowTemperature = 12.7, HighTemperature = 19.2 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Jun", LowTemperature = 10.9, HighTemperature = 16.8 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Jul", LowTemperature = 9.6, HighTemperature = 16.4 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Aug", LowTemperature = 10, HighTemperature = 17.5 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Sep", LowTemperature = 12.4, HighTemperature = 20 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Oct", LowTemperature = 14.6, HighTemperature = 21.9 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Nov", LowTemperature = 16.7, HighTemperature = 23.2 });
            Collection.Add(new MultiLevelLabelsModel() { Month = "Dec", LowTemperature = 18.5, HighTemperature = 24.9 });

        }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if(Collection != null)
                Collection.Clear();
        }
    }
}
