#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class BoxWhiskerChartViewModel
    {
        public ObservableCollection<BoxWhiskerChartModel> DataSets { get; set; }
        public Array BoxPlotMode
        {
            get { return Enum.GetValues(typeof(BoxPlotMode)); }
        }

        public BoxWhiskerChartViewModel()
        {
            DataSets = new ObservableCollection<BoxWhiskerChartModel>
            {
             new BoxWhiskerChartModel("1", new List<double>{ 67.4,
 65.5,
 72.0,
 73.6,
 65.2,
 67.0,
 66.3,
 67.9,
 65.8,
 69.9,
 64.5,
 66.0,
 66.8,
 67.0,
 69.9,
 70.1,
 69.7,
 68.3,
 67.0,
 68.2,
 65.0,
 66.6,
 65.4,
 68.1,
}),
             new BoxWhiskerChartModel("2", new List<double>{69.0,
 66.2,
 70.0,
 68.5,
 66.0,
 67.5,
 68.5,
 66.5,
 73.0,
 69.0,
 69.0,
 74.5,
 68.0,
 68.5,
 67.5,
 70.0,
 69.0,
 72.5,
 68.0,
 69.0,
 69.0,
 71.0,
 68.0,
 75.0,
 67.0, }),
              new BoxWhiskerChartModel("3",new List<double>{73.0,
 78.9,
 75.0,
 72.3,
 72.4,
 74.1,
 72.0,
 72.0,
 70.9,
 74.5,
 72.0,
 72.5,
 72.4,
 74.0,
 75.0,
 70.9,
 70.9,
 76.6,
 74.2,
 69.5,
 68.8,
 68.5,
 70.1,
 73.0,
 70.9,}),
               new BoxWhiskerChartModel("4",new List<double>{67.6,
 64.2,
 65.9,
 65.9,
 68.2,
 71.1,
 67.6,
 71.6,
 72.8,
 68.2,
 67.6,
 67.1,
 67.1,
 68.2,
 65.4,
 66.5,
 67.6,
 67.1,
 71.1,
 67.1,
 65.4,
 67.6,
 67.6,
 70.5,
 70.5, }),
            };
        }
    }
}
