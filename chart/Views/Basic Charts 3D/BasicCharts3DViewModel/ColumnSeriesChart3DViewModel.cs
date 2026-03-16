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
    /// <summary>Provides datasets for 3D column chart demonstrations.</summary>
    public class ColumnSeriesChart3DViewModel : IDisposable
    {
        /// <summary>Gets or sets the fruit quantity dataset.</summary>
        public ObservableCollection<ColumnSeriesChart3DModel> FruitsData { get; set; }

        /// <summary>Gets or sets the military dataset for spacing demo.</summary>
        public ObservableCollection<ColumnSeriesChart3DModel> MilitaryData { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ColumnSeriesChart3DViewModel"/> class.
        /// </summary>
        public ColumnSeriesChart3DViewModel()
        {
            //Default Column
            FruitsData = new ObservableCollection<ColumnSeriesChart3DModel>();
            FruitsData.Add(new ColumnSeriesChart3DModel() { Name = "Apple", Value = 130 });
            FruitsData.Add(new ColumnSeriesChart3DModel() { Name = "Grapes", Value = 90 });
            FruitsData.Add(new ColumnSeriesChart3DModel() { Name = "Peach", Value = 60 });
            FruitsData.Add(new ColumnSeriesChart3DModel() { Name = "Banana", Value = 110 });
            FruitsData.Add(new ColumnSeriesChart3DModel() { Name = "Plums", Value = 70 });
            FruitsData.Add(new ColumnSeriesChart3DModel() { Name = "Kiwi", Value = 90 });

            // Column Spacing
            MilitaryData = new ObservableCollection<ColumnSeriesChart3DModel>();
            MilitaryData.Add(new ColumnSeriesChart3DModel() { Year = "2016", Sudan = 2.3, Togo = 1.8 });
            MilitaryData.Add(new ColumnSeriesChart3DModel() { Year = "2017", Sudan = 3.3, Togo = 1.9 });
            MilitaryData.Add(new ColumnSeriesChart3DModel() { Year = "2018", Sudan = 1.8, Togo = 2 });
            MilitaryData.Add(new ColumnSeriesChart3DModel() { Year = "2019", Sudan = 1.6, Togo = 3.1 });
            MilitaryData.Add(new ColumnSeriesChart3DModel() { Year = "2020", Sudan = 1, Togo = 2.8 });
        }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if(FruitsData  != null) 
                FruitsData.Clear();

            if(MilitaryData != null)
                MilitaryData.Clear();
        }
    }
}
