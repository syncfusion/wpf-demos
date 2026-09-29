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
    /// <summary>Provides smartphone market share data for 100% stacked line charts.</summary>
    public class StackedLine100ViewModel : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StackedLine100ViewModel"/> class.
        /// </summary>
        public StackedLine100ViewModel()
        {
            this.SmartPhoneSalesRate = new ObservableCollection<StackedLine100Model>();

            SmartPhoneSalesRate.Add(new StackedLine100Model() { Year = "2013", Samsung = 25.47, Apple = 24.01, Nokia = 21.4, Others = 29.1 });
            SmartPhoneSalesRate.Add(new StackedLine100Model() { Year = "2014", Samsung = 32.26, Apple = 23.93, Nokia = 13.33, Others = 30.5 });
            SmartPhoneSalesRate.Add(new StackedLine100Model() { Year = "2015", Samsung = 31.94, Apple = 20.2, Nokia = 9.19, Others = 38.67 });
            SmartPhoneSalesRate.Add(new StackedLine100Model() { Year = "2016", Samsung = 32.38, Apple = 19.29, Nokia = 5.48, Others = 42.84 });
            SmartPhoneSalesRate.Add(new StackedLine100Model() { Year = "2017", Samsung = 32.99, Apple = 19.65, Nokia = 2.54, Others = 44.8 });
            SmartPhoneSalesRate.Add(new StackedLine100Model() { Year = "2018", Samsung = 30.77, Apple = 20.47, Nokia = 1.5, Others = 47.27 });
        }

        /// <summary>Gets or sets the smartphone sales rate dataset.</summary>
        public ObservableCollection<StackedLine100Model> SmartPhoneSalesRate { get; set; }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if (SmartPhoneSalesRate != null)
                SmartPhoneSalesRate.Clear();
        }
    }
}
