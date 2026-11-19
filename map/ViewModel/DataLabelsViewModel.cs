#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Maps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.mapdemos.wpf
{
    public class DataLabelsViewModel
    {
        public ObservableCollection<AgricultureData> DataSource { get; set; }

        public DataLabelsViewModel()
        {
            DataSource = new ObservableCollection<AgricultureData>();
            DataSource.Add(new AgricultureData("Alabama", "Vegetables", 42));
            DataSource.Add(new AgricultureData("Alaska", "Vegetables", 0));
            DataSource.Add(new AgricultureData("Arizona", "Rice", 36));
            DataSource.Add(new AgricultureData("Arkansas", "Vegetables", 46));
            DataSource.Add(new AgricultureData("California", "Rice", 24));
            DataSource.Add(new AgricultureData("Colorado", "Rice", 31));
            DataSource.Add(new AgricultureData("Connecticut", "Grains", 18));
            DataSource.Add(new AgricultureData("Delaware", "Grains", 28));
            DataSource.Add(new AgricultureData("District of Columbia", "Grains", 27));
            DataSource.Add(new AgricultureData("Florida", "Rice", 48));
            DataSource.Add(new AgricultureData("Georgia", "Oats", 44));
            DataSource.Add(new AgricultureData("Hawaii", "Grains", 49));
            DataSource.Add(new AgricultureData("Idaho", "Grains", 8));
            DataSource.Add(new AgricultureData("Illinois", "Vegetables", 26));
            DataSource.Add(new AgricultureData("Indiana", "Grains", 21));
            DataSource.Add(new AgricultureData("Iowa", "Vegetables", 13));
            DataSource.Add(new AgricultureData("Kansas", "Rice", 33));
            DataSource.Add(new AgricultureData("Kentucky", "Grains", 32));
            DataSource.Add(new AgricultureData("Louisiana", "Oats", 47));
            DataSource.Add(new AgricultureData("Maine", "Oats", 3));
            DataSource.Add(new AgricultureData("Maryland", "Grains", 30));
            DataSource.Add(new AgricultureData("Massachusetts", "Grains", 14));
            DataSource.Add(new AgricultureData("Michigan", "Grains", 50));
            DataSource.Add(new AgricultureData("Minnesota", "Wheat", 10));
            DataSource.Add(new AgricultureData("Mississippi", "Vegetables", 43));
            DataSource.Add(new AgricultureData("Missouri", "Oats", 35));
            DataSource.Add(new AgricultureData("Montana", "Grains", 2));
            DataSource.Add(new AgricultureData("Nebraska", "Rice", 15));
            DataSource.Add(new AgricultureData("Nevada", "Wheat", 22));
            DataSource.Add(new AgricultureData("New Hampshire", "Grains", 12));
            DataSource.Add(new AgricultureData("New Jersey", "Vegetables", 20));
            DataSource.Add(new AgricultureData("New Mexico", "Oats", 41));
            DataSource.Add(new AgricultureData("New York", "Vegetables", 16));
            DataSource.Add(new AgricultureData("North Carolina", "Rice", 38));
            DataSource.Add(new AgricultureData("North Dakota", "Grains", 4));
            DataSource.Add(new AgricultureData("Ohio", "Vegetables", 25));
            DataSource.Add(new AgricultureData("Oklahoma", "Rice", 37));
            DataSource.Add(new AgricultureData("Oregon", "Wheat", 11));
            DataSource.Add(new AgricultureData("Pennsylvania", "Oats", 17));
            DataSource.Add(new AgricultureData("Rhode Island", "Grains", 19));
            DataSource.Add(new AgricultureData("South Carolina", "Rice", 45));
            DataSource.Add(new AgricultureData("South Dakota", "Grains", 5));
            DataSource.Add(new AgricultureData("Tennessee", "Vegetables", 39));
            DataSource.Add(new AgricultureData("Texas", "Vegetables", 40));
            DataSource.Add(new AgricultureData("Utah", "Rice", 23));
            DataSource.Add(new AgricultureData("Vermont", "Grains", 9));
            DataSource.Add(new AgricultureData("Virginia", "Rice", 34));
            DataSource.Add(new AgricultureData("Washington", "Vegetables", 1));
            DataSource.Add(new AgricultureData("West Virginia", "Grains", 29));
            DataSource.Add(new AgricultureData("Wisconsin", "Oats", 7));
            DataSource.Add(new AgricultureData("Wyoming", "Wheat", 6));
        }
    }
}
