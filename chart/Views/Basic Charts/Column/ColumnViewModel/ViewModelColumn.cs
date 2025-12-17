using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class ViewModelColumn : ObservableCollection<DataValuesColumn>
    {
        public ViewModelColumn()
        {
            Add(new DataValuesColumn("State 1", "2009", 100, 18));
            Add(new DataValuesColumn("State 2", "2010", 100, 23));
            Add(new DataValuesColumn("State 3", "2011", 100, 26));
            Add(new DataValuesColumn("State 4", "2013", 100, 24));
        }
    }
}
