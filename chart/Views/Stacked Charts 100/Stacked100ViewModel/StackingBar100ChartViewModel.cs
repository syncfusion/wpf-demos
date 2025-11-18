using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class StackedBar100ViewModel : IDisposable
    {
        public StackedBar100ViewModel()
        {
            this.ElectricVehicleShare = new ObservableCollection<StackedBar100Model>();

            ElectricVehicleShare.Add(new StackedBar100Model() { Year = "2022 Q1",BYDAuto = 10, Tesla = 21,  VolkswagenGroup = 7, Others = 62});
            ElectricVehicleShare.Add(new StackedBar100Model() { Year = "2022 Q2",BYDAuto = 12, Tesla = 16,  VolkswagenGroup = 7, Others = 65});
            ElectricVehicleShare.Add(new StackedBar100Model() { Year = "2022 Q3",BYDAuto = 13, Tesla = 17,  VolkswagenGroup = 7, Others = 63});
            ElectricVehicleShare.Add(new StackedBar100Model() { Year = "2022 Q4",BYDAuto = 15, Tesla = 17,  VolkswagenGroup = 8, Others = 60 });
        }

        public ObservableCollection<StackedBar100Model> ElectricVehicleShare { get; set; }

        public void Dispose()
        {
            if (ElectricVehicleShare != null)
                ElectricVehicleShare.Clear();
        }
    }
}






