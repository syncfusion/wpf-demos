#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
using System.Windows.Controls;
using System.Windows.Documents;

namespace syncfusion.chartdemos.wpf
{
    public class StackedChart3DViewModel
    {
        public ObservableCollection<StackedChart3DModel> PatentsData { get; set; }
        public ObservableCollection<StackedChart3DModel> AnnualDetails { get; set; }
        public ObservableCollection<StackedChart3DModel> ProductData { get; set; }
        public ObservableCollection<StackedChart3DModel> Group1 {  get; set; }
        public ObservableCollection<StackedChart3DModel> Group2 {  get; set; }

        public StackedChart3DViewModel()
        {
            //Stacked Column
            PatentsData = new ObservableCollection<StackedChart3DModel>();
            PatentsData.Add(new StackedChart3DModel() { Year = "2017", Machine = 8714, Storage = 17668, Management = 5297, Communication = 3289, Charging= 15417});
            PatentsData.Add(new StackedChart3DModel() { Year = "2018", Machine = 10696, Storage =19507 , Management = 5393, Communication =3910 , Charging= 20928});
            PatentsData.Add(new StackedChart3DModel() { Year = "2019", Machine = 11365 , Storage = 22334, Management = 5008, Communication = 4145, Charging= 24769});
            PatentsData.Add(new StackedChart3DModel() { Year = "2020", Machine = 6605, Storage = 15237, Management = 2717, Communication = 2396, Charging= 17480});

            //Cluster Stacked Column
            this.AnnualDetails = new ObservableCollection<StackedChart3DModel>();
            AnnualDetails.Add(new StackedChart3DModel() { Year = "2009", Quarter1 = 34, Quarter2 = 31, Quarter3 = 29, Quarter4 = 30 });
            AnnualDetails.Add(new StackedChart3DModel() { Year = "2010", Quarter1 = 24, Quarter2 = 28, Quarter3 = 32, Quarter4 = 33 });
            AnnualDetails.Add(new StackedChart3DModel() { Year = "2011", Quarter1 = 20, Quarter2 = 25, Quarter3 = 25, Quarter4 = 26 });
            AnnualDetails.Add(new StackedChart3DModel() { Year = "2012", Quarter1 = 19, Quarter2 = 21, Quarter3 = 23, Quarter4 = 26 });
            AnnualDetails.Add(new StackedChart3DModel() { Year = "2013", Quarter1 = 19, Quarter2 = 15, Quarter3 = 17, Quarter4 = 21 });
         
            //Stacked Bar
            ProductData = new ObservableCollection<StackedChart3DModel>();
            ProductData.Add(new StackedChart3DModel() { Name = "Eyebrow pencil", High = 3.932, Low = 3.987, Value = 5.067, Size = 13.012 });
            ProductData.Add(new StackedChart3DModel() { Name = "Eyeliner", High = 5.432, Low = 3.417, Value = 15.067, Size = 12.321 });
            ProductData.Add(new StackedChart3DModel() { Name = "Nail polish", High = 4.229, Low = 4.376, Value = 3.504, Size = 12.814 });
            ProductData.Add(new StackedChart3DModel() { Name = "Lipstick", High = 9.256, Low = 4.376, Value = 9.054, Size = 8.814 });
            ProductData.Add(new StackedChart3DModel() { Name = "Rouge", High = 5.221, Low = 3.574, Value = 7.004, Size = 11.624 });
            ProductData.Add(new StackedChart3DModel() { Name = "Powder", High = 8.012, Low = 8.034, Value = 10.919, Size = 7.861 });

            // Cluster Stacked Bar
            Group1 = new ObservableCollection<StackedChart3DModel>();
            Group1.Add(new StackedChart3DModel() { Year = "2018", Europe = 1042, CIS = 1922, North = 2703, Latin = 935 });
            Group1.Add(new StackedChart3DModel() { Year = "2020", Europe = 976, CIS = 1840, North = 2686 , Latin = 847 });
            Group1.Add(new StackedChart3DModel() { Year = "2022", Europe = 963, CIS = 1859, North = 2878, Latin = 888 });

            Group2 = new ObservableCollection<StackedChart3DModel>();
            Group2.Add(new StackedChart3DModel() { Year = "2018", Asia = 4209, Pacific = 441, Africa = 1148, Middle = 2060 });
            Group2.Add(new StackedChart3DModel() { Year = "2020", Asia = 4374, Pacific = 483, Africa = 1065, Middle = 1883 });
            Group2.Add(new StackedChart3DModel() { Year = "2022", Asia = 4850, Pacific = 468, Africa = 1101, Middle =  2117});
        }
    }
}
