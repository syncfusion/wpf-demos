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

namespace syncfusion.mapdemos.wpf
{
    public class HeatMapViewModel
    {
        public ObservableCollection<HeatMapModel> Countries { get; set; }
        public HeatMapViewModel()
        {
            Countries = new ObservableCollection<HeatMapModel>();
            Countries = GetCountriesAndPopulation();
        }
        private ObservableCollection<HeatMapModel> GetCountriesAndPopulation()
        {
            ObservableCollection<HeatMapModel> countries = new ObservableCollection<HeatMapModel>();
            countries.Add(new HeatMapModel() { NAME = "Kazakhstan", Population = 3706690 });
            countries.Add(new HeatMapModel() { NAME = "India", Population = 1210193422 });
            countries.Add(new HeatMapModel() { NAME = "United States", Population = 314623000 });
            countries.Add(new HeatMapModel() { NAME = "Australia", Population = 22789701 });
            countries.Add(new HeatMapModel() { NAME = "Mexico", Population = 112336538 });
            countries.Add(new HeatMapModel() { NAME = "Russia", Population = 143228300 });
            countries.Add(new HeatMapModel() { NAME = "Canada", Population = 34955100 });
            countries.Add(new HeatMapModel() { NAME = "Brazil", Population = 193946886 });
            countries.Add(new HeatMapModel() { NAME = "Algeria", Population = 37100000 });
            return countries;
        }
    }
}
