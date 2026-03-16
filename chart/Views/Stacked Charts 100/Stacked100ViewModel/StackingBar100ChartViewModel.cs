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
    /// <summary>Provides EV market share data for stacked bar 100 charts.</summary>
    public class StackedBar100ViewModel : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StackedBar100ViewModel"/> class.
        /// </summary>
        public StackedBar100ViewModel()
        {
            this.ElectricVehicleShare = new ObservableCollection<StackedBar100Model>();

            ElectricVehicleShare.Add(new StackedBar100Model() { Year = "2022 Q1",BYDAuto = 10, Tesla = 21,  VolkswagenGroup = 7, Others = 62});
            ElectricVehicleShare.Add(new StackedBar100Model() { Year = "2022 Q2",BYDAuto = 12, Tesla = 16,  VolkswagenGroup = 7, Others = 65});
            ElectricVehicleShare.Add(new StackedBar100Model() { Year = "2022 Q3",BYDAuto = 13, Tesla = 17,  VolkswagenGroup = 7, Others = 63});
            ElectricVehicleShare.Add(new StackedBar100Model() { Year = "2022 Q4",BYDAuto = 15, Tesla = 17,  VolkswagenGroup = 8, Others = 60 });
        }

        /// <summary>Gets or sets the EV market share dataset.</summary>
        public ObservableCollection<StackedBar100Model> ElectricVehicleShare { get; set; }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if (ElectricVehicleShare != null)
                ElectricVehicleShare.Clear();
        }
    }
}






