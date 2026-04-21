#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Provides sample categorical data for axis configuration demonstrations.</summary>
    public class AxisConfigurationViewModel : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AxisConfigurationViewModel"/> class.
        /// </summary>
        public AxisConfigurationViewModel()
        {
            CategoricalDatas = new ObservableCollection<AxisConfigurationModel>();
            CategoricalDatas.Add(new AxisConfigurationModel("Metal", 5));
            CategoricalDatas.Add(new AxisConfigurationModel("Copper", 10));
            CategoricalDatas.Add(new AxisConfigurationModel("Silver", 15));
            CategoricalDatas.Add(new AxisConfigurationModel("Iron", 20));
            CategoricalDatas.Add(new AxisConfigurationModel("Zinc", 20));
            CategoricalDatas.Add(new AxisConfigurationModel("Gold", 35));
            CategoricalDatas.Add(new AxisConfigurationModel("Platinum", 20));
            CategoricalDatas.Add(new AxisConfigurationModel("Chromium", 40));
            CategoricalDatas.Add(new AxisConfigurationModel("Titanium", 20));
            CategoricalDatas.Add(new AxisConfigurationModel("Uranium", 15));
            CategoricalDatas.Add(new AxisConfigurationModel("Nickel", 40));
        }

        /// <summary>Gets or sets the collection of categorical data items.</summary>
        public ObservableCollection<AxisConfigurationModel> CategoricalDatas
        {
            get;
            set;
        }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if(CategoricalDatas != null)
                CategoricalDatas.Clear();
        }
    }
}
