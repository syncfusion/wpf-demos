#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
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
using Syncfusion.UI.Xaml.Charts;
using System.Windows;

namespace syncfusion.chartdemos.wpf
{
    public class AxisConfigurationViewModel
    {
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

        public ObservableCollection<AxisConfigurationModel> CategoricalDatas
        {
            get;
            set;
        }
    }
}
