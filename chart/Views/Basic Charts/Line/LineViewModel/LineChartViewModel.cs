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
    public class LineChartViewModel
    {
        public ObservableCollection<LineChartModel> RomaniaData { get; }
        public ObservableCollection<LineChartModel> NorwayData { get; }
        public ObservableCollection<LineChartModel> DashedLine { get; set; }

        public LineChartViewModel()
        {
            //Default Line
            this.RomaniaData = new ObservableCollection<LineChartModel>();
            RomaniaData.Add(new LineChartModel() { Name = "2005", Value = 9 });
            RomaniaData.Add(new LineChartModel() { Name = "2006", Value = 6.6 });
            RomaniaData.Add(new LineChartModel() { Name = "2007", Value = 4.8 });
            RomaniaData.Add(new LineChartModel() { Name = "2008", Value = 7.9 });
            RomaniaData.Add(new LineChartModel() { Name = "2009", Value = 5.6 });
            RomaniaData.Add(new LineChartModel() { Name = "2010", Value = 6.1 });
            RomaniaData.Add(new LineChartModel() { Name = "2011", Value = 5.8 });

            this.NorwayData = new ObservableCollection<LineChartModel>();
            NorwayData.Add(new LineChartModel() { Name = "2005", Value = 1.5 });
            NorwayData.Add(new LineChartModel() { Name = "2006", Value = 2.3 });
            NorwayData.Add(new LineChartModel() { Name = "2007", Value = 0.7 });
            NorwayData.Add(new LineChartModel() { Name = "2008", Value = 3.8 });
            NorwayData.Add(new LineChartModel() { Name = "2009", Value = 2.2 });
            NorwayData.Add(new LineChartModel() { Name = "2010", Value = 2.4 });
            NorwayData.Add(new LineChartModel() { Name = "2011", Value = 1.3 });

            //Dashed Line
            this.DashedLine = new ObservableCollection<LineChartModel>();
            DashedLine.Add(new LineChartModel() { Name = "2010", Singapore = 6.6, SaudiArabia = 9.0, Spain = 15.1 });
            DashedLine.Add(new LineChartModel() { Name = "2011", Singapore = 6.3, SaudiArabia = 9.3, Spain = 15.5 });
            DashedLine.Add(new LineChartModel() { Name = "2012", Singapore = 6.7, SaudiArabia = 10.2, Spain = 14.5 });
            DashedLine.Add(new LineChartModel() { Name = "2013", Singapore = 6.7, SaudiArabia = 10.2, Spain = 13.9 });
            DashedLine.Add(new LineChartModel() { Name = "2014", Singapore = 6.4, SaudiArabia = 10.9, Spain = 13 });
            DashedLine.Add(new LineChartModel() { Name = "2015", Singapore = 6.8, SaudiArabia = 9.3, Spain = 13.4 });
            DashedLine.Add(new LineChartModel() { Name = "2016", Singapore = 7.7, SaudiArabia = 10.1, Spain = 14.2 });
        }
    }
}
