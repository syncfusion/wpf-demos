using System;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>Gets or sets the stacked bar sales dataset.</summary>
    public class StackingBarChartViewModel : IDisposable
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StackingBarChartViewModel"/> class.
        /// </summary>
        public StackingBarChartViewModel()
        {
            SalesRate = new ObservableCollection<StackingBarChartModel>()
             {
                 new StackingBarChartModel("2010",9.05,14.1,4.19),
                 new StackingBarChartModel("2011",6.62,17.07,11.12),
                 new StackingBarChartModel("2012",5.34,26.91,14.04),
                 new StackingBarChartModel("2013",3.5,33.8,14.08),
                 new StackingBarChartModel("2014",2.64,39.27,12.32)
             };
        }

        /// <summary>Gets or sets the stacked bar sales dataset.</summary>
        public ObservableCollection<StackingBarChartModel> SalesRate { get; set; }

        /// <summary>Releases resources and performs cleanup operations.</summary>
        public void Dispose()
        {
            if(SalesRate != null)
                SalesRate.Clear();
        }
    }
}






