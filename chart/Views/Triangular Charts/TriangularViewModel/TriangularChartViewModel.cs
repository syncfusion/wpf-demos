#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace syncfusion.chartdemos.wpf
{
    public class TriangularChartViewModel : IDisposable
    {
        public IList<TriangularChartModel> PyramidData { get; set; }
        public IList<TriangularChartModel> CustomizedPyramidData { get; set; }
        public IList<TriangularChartModel> FunnelData { get; set; }
        public IList<TriangularChartModel> CustomizedFunnelData { get; set; }

        public Array FunnelMode
        {
            get { return Enum.GetValues(typeof(ChartFunnelMode)); }
        }    

        public Array PyramidMode
        {
            get { return Enum.GetValues(typeof(ChartPyramidMode)); }
        }

        public TriangularChartViewModel()
        {
            // Default Pyramid 
            this.PyramidData = new List<TriangularChartModel>();
            PyramidData.Add(new TriangularChartModel() { Category = "CD/Cassette", Percentage = 18 });
            PyramidData.Add(new TriangularChartModel() { Category = "Digital files", Percentage = 20 });
            PyramidData.Add(new TriangularChartModel() { Category = "Streaming", Percentage = 29 });
            PyramidData.Add(new TriangularChartModel() { Category = "Radio", Percentage = 33 });

            // Customized Pyramid
            this.CustomizedPyramidData = new List<TriangularChartModel>();
            CustomizedPyramidData.Add(new TriangularChartModel() { Category = "Retail", Percentage = 62, Value = 10 });
            CustomizedPyramidData.Add(new TriangularChartModel() { Category = "Manufacturing", Percentage = 85, Value = 14.25 });
            CustomizedPyramidData.Add(new TriangularChartModel() { Category = "Marketing", Percentage = 106, Value = 17.82 });
            CustomizedPyramidData.Add(new TriangularChartModel() { Category = "Shipping", Percentage = 144, Value = 24.51 });
            CustomizedPyramidData.Add(new TriangularChartModel() { Category = "R&D", Percentage = 193, Value = 32.71 });

            //Default Funnel
            this.FunnelData = new List<TriangularChartModel>();
            FunnelData.Add(new TriangularChartModel() { Category = "Renewed", Percentage = 18 });
            FunnelData.Add(new TriangularChartModel() { Category = "Subscribed", Percentage = 34 });
            FunnelData.Add(new TriangularChartModel() { Category = "Contacted Support", Percentage = 52 });
            FunnelData.Add(new TriangularChartModel() { Category = "Downloaded a Trial", Percentage = 68 });
            FunnelData.Add(new TriangularChartModel() { Category = "Visited the Website", Percentage = 100 });

            //Customized Funnel
            this.CustomizedFunnelData = new ObservableCollection<TriangularChartModel>();
            CustomizedFunnelData.Add(new TriangularChartModel() { Category = "Closed Deals", Percentage = 80, PercentageValue = "80% of 100" });
            CustomizedFunnelData.Add(new TriangularChartModel() { Category = "Negotiations", Percentage = 100, PercentageValue = "67% of 150" });
            CustomizedFunnelData.Add(new TriangularChartModel() { Category = "Proposal", Percentage = 150, PercentageValue = "75% of 200" });
            CustomizedFunnelData.Add(new TriangularChartModel() { Category = "Needs Analysis", Percentage = 200, PercentageValue = "50% of 400" });
            CustomizedFunnelData.Add(new TriangularChartModel() { Category = "Qualified Leads", Percentage = 400, PercentageValue = "80% of 500" });
            CustomizedFunnelData.Add(new TriangularChartModel() { Category = "Lead Generation", Percentage = 500, PercentageValue = "100%" });
        }

        public void Dispose()
        {
            if (PyramidData != null)
                PyramidData.Clear();

            if (CustomizedPyramidData != null)
                CustomizedPyramidData.Clear();

            if (FunnelData != null)
                FunnelData.Clear();

            if (CustomizedFunnelData != null)
                CustomizedFunnelData.Clear();
        }
    }
}
