#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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

namespace syncfusion.chartdemos.wpf
{
    public class BarChart3DViewModel
    {
        public ObservableCollection<BarChart3DModel> EmployeeData { get; set; }
        public ObservableCollection<BarChart3DModel> MetalData { get; set; }

        public BarChart3DViewModel()
        {
            //Default Bar
            EmployeeData = new ObservableCollection<BarChart3DModel>();
            EmployeeData.Add(new BarChart3DModel() { Energy = "Solar Photovoltaics", Value = 4.90 });
            EmployeeData.Add(new BarChart3DModel() { Energy = "Bioenergy", Value = 3.58 });
            EmployeeData.Add(new BarChart3DModel() { Energy = "Hydropower", Value = 2.49 });
            EmployeeData.Add(new BarChart3DModel() { Energy = "Wind Energy", Value = 1.40 });
            EmployeeData.Add(new BarChart3DModel() { Energy = "Solar Heating & Cooling", Value = 0.71 });
            EmployeeData.Add(new BarChart3DModel() { Energy = "Others", Value = 0.64 });

            //Bar Spacing
            MetalData = new ObservableCollection<BarChart3DModel>();
            MetalData.Add(new BarChart3DModel() { Year = "2020", Brazil = 16.2,Bolivia=27 });
            MetalData.Add(new BarChart3DModel() { Year = "2021", Brazil = 19.8,Bolivia=30.7 });
            MetalData.Add(new BarChart3DModel() { Year = "2022", Brazil = 11.9,Bolivia=26.8 });
        }
    }
}
