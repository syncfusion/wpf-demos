using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Provides sample data for the bar chart demo.</summary>
    public class ViewModelBar : ObservableCollection<DataValuesBar>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModelBar"/> class.
        /// </summary>
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
