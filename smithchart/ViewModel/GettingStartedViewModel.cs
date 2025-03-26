#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.SmithChart;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.smithchartdemos.wpf
{
    public class GettingStartedViewModel :NotificationObject
    {
        public GettingStartedViewModel()
        {
            Trace1 = new List<SmithChartModel>();
            Trace1.Add(new SmithChartModel() { Resistance = 0, Reactance = 0.05 });
            Trace1.Add(new SmithChartModel() { Resistance = 0.3, Reactance = 0.1 });
            Trace1.Add(new SmithChartModel() { Resistance = 0.5, Reactance = 0.2 });
            Trace1.Add(new SmithChartModel() { Resistance = 1.0, Reactance = 0.4 });
            Trace1.Add(new SmithChartModel() { Resistance = 1.5, Reactance = 0.5 });
            Trace1.Add(new SmithChartModel() { Resistance = 2.0, Reactance = 0.5 });
            Trace1.Add(new SmithChartModel() { Resistance = 2.5, Reactance = 0.4 });
            Trace1.Add(new SmithChartModel() { Resistance = 3.5, Reactance = 0.0 });
            Trace1.Add(new SmithChartModel() { Resistance = 4.5, Reactance = -0.5 });
            Trace1.Add(new SmithChartModel() { Resistance = 5, Reactance = -1.0 });
            Trace1.Add(new SmithChartModel() { Resistance = 6, Reactance = -1.5 });
            Trace1.Add(new SmithChartModel() { Resistance = 7, Reactance = -2.5 });
            Trace1.Add(new SmithChartModel() { Resistance = 8, Reactance = -3.5 });
            Trace1.Add(new SmithChartModel() { Resistance = 9, Reactance = -4.5 });
            Trace1.Add(new SmithChartModel() { Resistance = 10, Reactance = -10 });
            Trace1.Add(new SmithChartModel() { Resistance = 20, Reactance = -50 });

            Trace2 = new List<SmithChartModel>();
            Trace2.Add(new SmithChartModel() { Resistance = 0, Reactance = 0.15 });
            Trace2.Add(new SmithChartModel() { Resistance = 0.3, Reactance = 0.2 });
            Trace2.Add(new SmithChartModel() { Resistance = 0.5, Reactance = 0.4 });
            Trace2.Add(new SmithChartModel() { Resistance = 1.0, Reactance = 0.8 });
            Trace2.Add(new SmithChartModel() { Resistance = 1.5, Reactance = 1.0 });
            Trace2.Add(new SmithChartModel() { Resistance = 2.0, Reactance = 1.2 });
            Trace2.Add(new SmithChartModel() { Resistance = 2.5, Reactance = 1.3 });
            Trace2.Add(new SmithChartModel() { Resistance = 3.5, Reactance = 1.6 });
            Trace2.Add(new SmithChartModel() { Resistance = 4.5, Reactance = 2.0 });
            Trace2.Add(new SmithChartModel() { Resistance = 6, Reactance = 4.5 });
            Trace2.Add(new SmithChartModel() { Resistance = 8, Reactance = 6 });
            Trace2.Add(new SmithChartModel() { Resistance = 10, Reactance = 25 });

            ChartRenderingType = RenderingType.Admittance;
        }

        public List<SmithChartModel> Trace1 { get; set; }
        public List<SmithChartModel> Trace2 { get; set; }

        private RenderingType chartRenderingType;

        public RenderingType ChartRenderingType
        {
            get { return chartRenderingType; }
            set 
            {
                chartRenderingType = value;
                RaisePropertyChanged("ChartRenderingType");
            }
        }
    }
}
