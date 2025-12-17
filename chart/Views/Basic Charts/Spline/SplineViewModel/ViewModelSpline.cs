using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class ViewModelSpline : ObservableCollection<DataValuesSpline>
    {
        public ViewModelSpline()
        {
            DateTime date = new DateTime(2014, 1, 1);

            Add(new DataValuesSpline(date.AddMonths(0), 6, -5, 64));
            Add(new DataValuesSpline(date.AddMonths(1), 7, 0.1, 30));
            Add(new DataValuesSpline(date.AddMonths(2), 8, 10, 22));
            Add(new DataValuesSpline(date.AddMonths(3), 10, 15, 19));
            Add(new DataValuesSpline(date.AddMonths(4), 13, 20, 20));
            Add(new DataValuesSpline(date.AddMonths(5), 17, 25, 34));
            Add(new DataValuesSpline(date.AddMonths(6), 18, 20, 45));
            Add(new DataValuesSpline(date.AddMonths(7), 17, 15, 47));
            Add(new DataValuesSpline(date.AddMonths(8), 14, 10, 55));
            Add(new DataValuesSpline(date.AddMonths(9), 12, 0, 60));
            Add(new DataValuesSpline(date.AddMonths(10), 8, -4, 64));
            Add(new DataValuesSpline(date.AddMonths(11), 8, -8, 68));
        }
    }
}
