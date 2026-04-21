#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Provides data for the watermark chart demo.</summary>
    public class WatermarkChartViewModel : IDisposable
    {
        /// <summary>Gets or sets the annual product data items.</summary>
        public ObservableCollection<WatermarkChartModel> ItemsDetails { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="WatermarkChartViewModel"/> class.
        /// </summary>
        public WatermarkChartViewModel()
        {
            this.ItemsDetails = new ObservableCollection<WatermarkChartModel>()
            {
                new WatermarkChartModel() { Year = "2005", ProductA = 21, ProductB = 28 },
                new WatermarkChartModel() { Year = "2006", ProductA = 24, ProductB = 44 },
                new WatermarkChartModel() { Year = "2007", ProductA = 36, ProductB = 48 },
                new WatermarkChartModel() { Year = "2008", ProductA = 38, ProductB = 50 },
                new WatermarkChartModel() { Year = "2009", ProductA = 54, ProductB = 66 },
                new WatermarkChartModel() { Year = "2010", ProductA = 57, ProductB = 78 },
                new WatermarkChartModel() { Year = "2011", ProductA = 70, ProductB = 84},
            };
        }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if (ItemsDetails != null)
                ItemsDetails.Clear();
        }
    }
}
