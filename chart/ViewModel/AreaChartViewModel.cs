#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class AreaChartViewModel
    {
        public AreaChartViewModel()
        {
            this.Performance = new ObservableCollection<AreaChartModel>();

            Performance.Add(new AreaChartModel() { Load = 2005, Server1 = 23, Server2 = 16, Server3 = 5 });
            Performance.Add(new AreaChartModel() { Load = 2006, Server1 = 40, Server2 = 25, Server3 = 13 });
            Performance.Add(new AreaChartModel() { Load = 2007, Server1 = 15, Server2 = 22, Server3 = 43 });
            Performance.Add(new AreaChartModel() { Load = 2008, Server1 = 10, Server2 = 55, Server3 = 25 });
            Performance.Add(new AreaChartModel() { Load = 2009, Server1 = 62, Server2 = 6,  Server3 = 39 });
            Performance.Add(new AreaChartModel() { Load = 2010, Server1 = 10, Server2 = 40, Server3 = 19 });
            Performance.Add(new AreaChartModel() { Load = 2011, Server1 = 29, Server2 = 22, Server3 = 59 });
            Performance.Add(new AreaChartModel() { Load = 2012, Server1 = 74, Server2 = 54, Server3 = 40 });
            Performance.Add(new AreaChartModel() { Load = 2013, Server1 = 20, Server2 = 62, Server3 = 45 });
        }

        public ObservableCollection<AreaChartModel> Performance
        {
            get;
            set;
        }
    }
}
