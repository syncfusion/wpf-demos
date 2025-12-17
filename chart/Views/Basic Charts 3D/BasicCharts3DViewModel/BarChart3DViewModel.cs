using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class BarChart3DViewModel : IDisposable
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

        public void Dispose()
        {
            if(EmployeeData != null)
                EmployeeData.Clear();

            if(MetalData != null)
                MetalData.Clear();
        }
    }
}
