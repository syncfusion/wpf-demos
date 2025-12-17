using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class ViewModelBar : ObservableCollection<DataValuesBar>
    {
        public ViewModelBar()
        {
            Add(new DataValuesBar("Convertible", 150));
            Add(new DataValuesBar("Sedan", 220));
            Add(new DataValuesBar("Hatchback", 100));
            Add(new DataValuesBar("SUV", 240));
            Add(new DataValuesBar("Truck", 180));
        }
    }
}
