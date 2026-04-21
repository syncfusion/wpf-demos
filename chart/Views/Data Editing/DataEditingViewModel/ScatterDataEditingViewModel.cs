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
    /// <summary>Provides two scatter datasets for data editing demos.</summary>
    public class ScatterDataEditingViewModel : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScatterDataEditingViewModel"/> class.
        /// </summary>
        public ScatterDataEditingViewModel()
        {
            var date = new DateTime(2015, 1, 1);

            Data1 = new ObservableCollection<ScatterDataEditingModel>();

            Data1.Add(new ScatterDataEditingModel(date.AddMonths(1), 698));
            Data1.Add(new ScatterDataEditingModel(date.AddMonths(2), 903));
            Data1.Add(new ScatterDataEditingModel(date.AddMonths(3), 807));
            Data1.Add(new ScatterDataEditingModel(date.AddMonths(4), 1058));
            Data1.Add(new ScatterDataEditingModel(date.AddMonths(5), 954));

            Data2 = new ObservableCollection<ScatterDataEditingModel>();

            Data2.Add(new ScatterDataEditingModel(date.AddMonths(1), 948));
            Data2.Add(new ScatterDataEditingModel(date.AddMonths(2), 1203));
            Data2.Add(new ScatterDataEditingModel(date.AddMonths(3), 1107));
            Data2.Add(new ScatterDataEditingModel(date.AddMonths(4), 1408));
            Data2.Add(new ScatterDataEditingModel(date.AddMonths(5), 1154));
        }

        /// <summary>Gets or sets the first dataset.</summary>
        public ObservableCollection<ScatterDataEditingModel> Data1 { get; set; }

        /// <summary>Gets or sets the second dataset.</summary>
        public ObservableCollection<ScatterDataEditingModel> Data2 { get; set; }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if (Data1 != null)
                Data1.Clear();

            if (Data2 != null) 
                Data2.Clear();
        }
    }
}
