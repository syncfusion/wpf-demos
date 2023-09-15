#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
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
    public class LineSeriesChart3DViewModel
    {
        public LineSeriesChart3DViewModel()
        {
            this.Performance = new ObservableCollection<LineSeriesChart3DModel>();

            Performance.Add(new LineSeriesChart3DModel() { ServerLoad = 2005, Server1 = 13, Server2 = 10 });
            Performance.Add(new LineSeriesChart3DModel() { ServerLoad = 2006, Server1 = 30, Server2 = 14 });
            Performance.Add(new LineSeriesChart3DModel() { ServerLoad = 2007, Server1 = 33, Server2 = 19 });
            Performance.Add(new LineSeriesChart3DModel() { ServerLoad = 2008, Server1 = 15, Server2 = 10 });
            Performance.Add(new LineSeriesChart3DModel() { ServerLoad = 2009, Server1 = 25, Server2 = 15 });
            Performance.Add(new LineSeriesChart3DModel() { ServerLoad = 2010, Server1 = 20, Server2 = 13 });
            Performance.Add(new LineSeriesChart3DModel() { ServerLoad = 2011, Server1 = 25, Server2 = 17 });
            Performance.Add(new LineSeriesChart3DModel() { ServerLoad = 2012, Server1 = 20, Server2 = 13 });
            Performance.Add(new LineSeriesChart3DModel() { ServerLoad = 2013, Server1 = 23, Server2 = 13 });
        }
        public ObservableCollection<LineSeriesChart3DModel> Performance
        {
            get;
            set;
        }
    }
}
