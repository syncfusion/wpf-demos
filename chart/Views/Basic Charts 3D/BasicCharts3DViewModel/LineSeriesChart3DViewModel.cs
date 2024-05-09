#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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
        public ObservableCollection<LineSeriesChart3DModel> NetherlandData { get; set; }
        public ObservableCollection<LineSeriesChart3DModel> SwedenData { get; set; }
        public LineSeriesChart3DViewModel()
        {
            NetherlandData = new ObservableCollection<LineSeriesChart3DModel>()
            {
                new LineSeriesChart3DModel(){Year="2004", Value=0.3},
                new LineSeriesChart3DModel(){Year="2005", Value=0.2},
                new LineSeriesChart3DModel(){Year="2006", Value=0.2},
                new LineSeriesChart3DModel(){Year="2007", Value=0.2},
                new LineSeriesChart3DModel(){Year="2008", Value=0.4},
                new LineSeriesChart3DModel(){Year="2009", Value=0.5},
                new LineSeriesChart3DModel(){Year="2010", Value=0.5},
                new LineSeriesChart3DModel(){Year="2011", Value=0.5},
                new LineSeriesChart3DModel(){Year="2012", Value=0.4},
                new LineSeriesChart3DModel(){Year="2013", Value=0.3},
                new LineSeriesChart3DModel(){Year="2014", Value=0.4},
                new LineSeriesChart3DModel(){Year="2015", Value=0.4},
                new LineSeriesChart3DModel(){Year="2016", Value=0.5},
                new LineSeriesChart3DModel(){Year="2017", Value=0.6},
                new LineSeriesChart3DModel(){Year="2018", Value=0.6},
                new LineSeriesChart3DModel(){Year="2019", Value=0.7},
                new LineSeriesChart3DModel(){Year="2020", Value=0.6},
            };

            SwedenData = new ObservableCollection<LineSeriesChart3DModel>()
            {
                 new LineSeriesChart3DModel(){Year="2004", Value=0.4},
                new LineSeriesChart3DModel(){Year="2005", Value=0.4},
                new LineSeriesChart3DModel(){Year="2006", Value=0.6},
                new LineSeriesChart3DModel(){Year="2007", Value=0.7},
                new LineSeriesChart3DModel(){Year="2008", Value=0.8},
                new LineSeriesChart3DModel(){Year="2009", Value=0.9},
                new LineSeriesChart3DModel(){Year="2010", Value=0.9},
                new LineSeriesChart3DModel(){Year="2011", Value=0.8},
                new LineSeriesChart3DModel(){Year="2012", Value=0.7},
                new LineSeriesChart3DModel(){Year="2013", Value=0.8},
                new LineSeriesChart3DModel(){Year="2014", Value=1},
                new LineSeriesChart3DModel(){Year="2015", Value=1.1},
                new LineSeriesChart3DModel(){Year="2016", Value=1.3},
                new LineSeriesChart3DModel(){Year="2017", Value=1.3},
                new LineSeriesChart3DModel(){Year="2018", Value=1.2},
                new LineSeriesChart3DModel(){Year="2019", Value=1},
                new LineSeriesChart3DModel(){Year="2020", Value=0.7},
            };
        }
    }
}
