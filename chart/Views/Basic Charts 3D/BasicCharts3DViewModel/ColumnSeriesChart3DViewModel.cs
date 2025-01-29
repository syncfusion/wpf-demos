#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class ColumnSeriesChart3DViewModel
    {
        public ObservableCollection<ColumnSeriesChart3DModel> FruitsData { get; set; }
        public ObservableCollection<ColumnSeriesChart3DModel> MilitaryData { get; set; }

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
    }
}
