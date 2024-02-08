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
        public ObservableCollection<AreaChartModel> AreaData { get; }
        public AreaChartViewModel()
        {
            //Default Area
            this.AreaData = new ObservableCollection<AreaChartModel>();
            AreaData.Add(new AreaChartModel() { Name = "2000", ProductA = 0.87, ProductB = 0.72, ProductC = 0.48, ProductD = 0.23 });
            AreaData.Add(new AreaChartModel() { Name = "2001", ProductA = 0.91, ProductB = 0.64, ProductC = 0.43, ProductD = 0.17 });
            AreaData.Add(new AreaChartModel() { Name = "2002", ProductA = 1.01, ProductB = 0.71, ProductC = 0.47, ProductD = 0.17 });
            AreaData.Add(new AreaChartModel() { Name = "2003", ProductA = 0.95, ProductB = 0.63, ProductC = 0.41, ProductD = 0.20 });
            AreaData.Add(new AreaChartModel() { Name = "2004", ProductA = 0.89, ProductB = 0.65, ProductC = 0.43, ProductD = 0.23 });
            AreaData.Add(new AreaChartModel() { Name = "2005", ProductA = 1.09, ProductB = 0.76, ProductC = 0.54, ProductD = 0.36 });
            AreaData.Add(new AreaChartModel() { Name = "2006", ProductA = 1.14, ProductB = 0.89, ProductC = 0.66, ProductD = 0.43 });
            AreaData.Add(new AreaChartModel() { Name = "2007", ProductA = 1.44, ProductB = 1.18, ProductC = 0.83, ProductD = 0.52 });
            AreaData.Add(new AreaChartModel() { Name = "2008", ProductA = 1.66, ProductB = 1.34, ProductC = 1.09, ProductD = 0.72 });
            AreaData.Add(new AreaChartModel() { Name = "2009", ProductA = 1.91, ProductB = 1.59, ProductC = 1.37, ProductD = 1.09 });
            AreaData.Add(new AreaChartModel() { Name = "2010", ProductA = 2.14, ProductB = 1.82, ProductC = 1.62, ProductD = 1.38 });
            AreaData.Add(new AreaChartModel() { Name = "2011", ProductA = 2.73, ProductB = 2.35, ProductC = 2.13, ProductD = 1.82 });
            AreaData.Add(new AreaChartModel() { Name = "2012", ProductA = 3.126, ProductB = 2.69, ProductC = 2.44, ProductD = 2.16 });
            AreaData.Add(new AreaChartModel() { Name = "2013", ProductA = 3.34, ProductB = 3.01, ProductC = 2.77, ProductD = 2.51 });
            AreaData.Add(new AreaChartModel() { Name = "2014", ProductA = 3.58, ProductB = 3.22, ProductC = 2.91, ProductD = 2.61 });
        }
    }
}
