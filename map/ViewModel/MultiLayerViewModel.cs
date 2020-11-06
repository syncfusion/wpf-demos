#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using System.Windows;

namespace syncfusion.mapdemos.wpf
{
    public class MultiLayerViewModel
    {
        public ObservableCollection<MultiLayerModel> MuliLayerList { get; set; }
        public ObservableCollection<MultiLayerModel> AfricaList { get; set; }
        public ObservableCollection<MultiLayerModel> OceaniaList { get; set; }
        public MultiLayerViewModel()
        {
            this.OceaniaList = new ObservableCollection<MultiLayerModel>();
            this.OceaniaList.Add(new MultiLayerModel() { NAME = "New South Wales", Weather = 26 });
            this.OceaniaList.Add(new MultiLayerModel() { NAME = "Queensland", Weather = 30 });
            this.OceaniaList.Add(new MultiLayerModel() { NAME = "Tasmania", Weather = 21 });
            this.OceaniaList.Add(new MultiLayerModel() { NAME = "Western Australia", Weather = 32 });
            this.AfricaList = new ObservableCollection<MultiLayerModel>();
            this.AfricaList.Add(new MultiLayerModel() { NAME = "Algeria", Weather = 47 });
            this.AfricaList.Add(new MultiLayerModel() { NAME = "Congo (Brazzaville)", Weather = 45 });
            this.AfricaList.Add(new MultiLayerModel() { NAME = "Ethiopia", Weather = 50 });
            this.AfricaList.Add(new MultiLayerModel() { NAME = "South Africa", Weather = 30 });
            this.MuliLayerList = new ObservableCollection<MultiLayerModel>();
            this.MuliLayerList.Add(new MultiLayerModel() { NAME = "Asia", Weather = 40 });
            this.MuliLayerList.Add(new MultiLayerModel() { NAME = "South America", Weather = 45 });
            this.MuliLayerList.Add(new MultiLayerModel() { NAME = "North America", Weather = 52 });
            this.MuliLayerList.Add(new MultiLayerModel() { NAME = "Antarctica", ItemsVisibility = Visibility.Collapsed });
            this.MuliLayerList.Add(new MultiLayerModel() { NAME = "Oceania", ItemsVisibility = Visibility.Collapsed });
            this.MuliLayerList.Add(new MultiLayerModel() { NAME = "Europe", ItemsVisibility = Visibility.Collapsed });
            this.MuliLayerList.Add(new MultiLayerModel() { NAME = "Africa", ItemsVisibility = Visibility.Collapsed });
        }
    }
}
