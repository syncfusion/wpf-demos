#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapchartdemos.wpf
{
    using Syncfusion.Windows.Chart.Olap;
    using Syncfusion.Windows.Chart;
    using System.Windows;
    using Microsoft.Xaml.Behaviors;

    public class SalesSeriesCustomization : TargetedTriggerAction<OlapChart>
    {
        protected override void Invoke(object parameter)
        {
            int seriesIndex = 0;
            foreach (ChartSeries series in this.Target.Series)
            {
                ChartPieType.SetExplodedIndex(series, seriesIndex++);
                series.AdornmentsInfo.SegmentShowLine = false;
                series.AdornmentsInfo.HorizontalAlignment = HorizontalAlignment.Center;
                series.AdornmentsInfo.VerticalAlignment = VerticalAlignment.Center;
                series.AdornmentsInfo.LabelTemplate = Application.Current.Resources["LabelTemplate"] as DataTemplate;
                series.StrokeThickness = 0;
            }
        }
    }
}
