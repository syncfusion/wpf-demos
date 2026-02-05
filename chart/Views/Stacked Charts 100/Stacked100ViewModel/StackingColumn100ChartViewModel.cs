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
    public class StackedColumn100ViewModel : IDisposable
    {
        public StackedColumn100ViewModel()
        {
            this.ElectricityConsumption = new ObservableCollection<StackedColumn100Model>();

            ElectricityConsumption.Add(new StackedColumn100Model() { CountryName = "US", Industry = 19.9, PublicServices = 35.2, Residential = 37.4, Others = 7.5 });
            ElectricityConsumption.Add(new StackedColumn100Model() { CountryName = "Iran", Industry = 24, PublicServices = 37, Residential = 25, Others = 14 });
            ElectricityConsumption.Add(new StackedColumn100Model() { CountryName = "Mexico", Industry = 29, PublicServices = 33, Residential = 30, Others = 8 });
            ElectricityConsumption.Add(new StackedColumn100Model() { CountryName = "Italy", Industry = 30, PublicServices = 32, Residential = 30, Others = 8 });
            ElectricityConsumption.Add(new StackedColumn100Model() { CountryName = "Russia", Industry = 44.8, PublicServices = 20.4, Residential = 21.1, Others = 13.7 });
            ElectricityConsumption.Add(new StackedColumn100Model() { CountryName = "Arabia", Industry = 33.7, PublicServices = 28.3, Residential = 25, Others = 13 });

        }

        public ObservableCollection<StackedColumn100Model> ElectricityConsumption { get; set; }

        public void Dispose()
        {
            if (ElectricityConsumption != null)
                ElectricityConsumption.Clear();
        }
    } 
}
