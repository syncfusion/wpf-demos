#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualStyle
{
    using System.Collections.ObjectModel;

    class SmithChartViewModel
    {
        public ObservableCollection<SmithChartModel> Trace1 { get; set; }
        public ObservableCollection<SmithChartModel> Trace2 { get; set; }

        public SmithChartViewModel()
        {
            this.Trace1 = new ObservableCollection<SmithChartModel>();
            this.Trace1.Add(new SmithChartModel { Resistance = 0, Reactance = 0.05 });
            this.Trace1.Add(new SmithChartModel { Resistance = 0.3, Reactance = 0.1 });
            this.Trace1.Add(new SmithChartModel { Resistance = 0.5, Reactance = 0.2 });
            this.Trace1.Add(new SmithChartModel { Resistance = 1.0, Reactance = 0.4 });
            this.Trace1.Add(new SmithChartModel { Resistance = 1.5, Reactance = 0.5 });
            this.Trace1.Add(new SmithChartModel { Resistance = 2.0, Reactance = 0.5 });
            this.Trace1.Add(new SmithChartModel { Resistance = 2.5, Reactance = 0.4 });
            this.Trace1.Add(new SmithChartModel { Resistance = 3.5, Reactance = 0.0 });
            this.Trace1.Add(new SmithChartModel { Resistance = 4.5, Reactance = -0.5 });
            this.Trace1.Add(new SmithChartModel { Resistance = 5, Reactance = -1.0 });
            this.Trace1.Add(new SmithChartModel { Resistance = 6, Reactance = -1.5 });
            this.Trace1.Add(new SmithChartModel { Resistance = 7, Reactance = -2.5 });
            this.Trace1.Add(new SmithChartModel { Resistance = 8, Reactance = -3.5 });
            this.Trace1.Add(new SmithChartModel { Resistance = 9, Reactance = -4.5 });
            this.Trace1.Add(new SmithChartModel { Resistance = 10, Reactance = -10 });
            this.Trace1.Add(new SmithChartModel { Resistance = 20, Reactance = -50 });

            this.Trace2 = new ObservableCollection<SmithChartModel>();
            this.Trace2.Add(new SmithChartModel { Resistance = 0, Reactance = 0.15 });
            this.Trace2.Add(new SmithChartModel { Resistance = 0.3, Reactance = 0.2 });
            this.Trace2.Add(new SmithChartModel { Resistance = 0.5, Reactance = 0.4 });
            this.Trace2.Add(new SmithChartModel { Resistance = 1.0, Reactance = 0.8 });
            this.Trace2.Add(new SmithChartModel { Resistance = 1.5, Reactance = 1.0 });
            this.Trace2.Add(new SmithChartModel { Resistance = 2.0, Reactance = 1.2 });
            this.Trace2.Add(new SmithChartModel { Resistance = 2.5, Reactance = 1.3 });
            this.Trace2.Add(new SmithChartModel { Resistance = 3.5, Reactance = 1.6 });
            this.Trace2.Add(new SmithChartModel { Resistance = 4.5, Reactance = 2.0 });
            this.Trace2.Add(new SmithChartModel { Resistance = 6, Reactance = 4.5 });
            this.Trace2.Add(new SmithChartModel { Resistance = 8, Reactance = 6 });
            this.Trace2.Add(new SmithChartModel { Resistance = 10, Reactance = 25 });
        }
    }
}
