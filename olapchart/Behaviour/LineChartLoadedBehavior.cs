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
    using System;

    public class LineChartLoadedBehavior : Behavior<OlapChart>
    {
        private ResourceDictionary CommonResourceDictionary { get; set; }

        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            base.OnDetaching();
        }

        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            CommonResourceDictionary = new ResourceDictionary() { Source = new Uri("/syncfusion.olapchartdemos.wpf;component/Resources/olapchart/OlapChartIcon.xaml", UriKind.RelativeOrAbsolute) };

            for (int i = 0; i < this.AssociatedObject.Series.Count; i++)
            {
                this.AssociatedObject.Series[i].AdornmentsInfo = new ChartAdornmentInfo
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Visible = true,
                    LabelTemplate = CommonResourceDictionary["LineLabelTemplate" + i] as DataTemplate
                };
            }
            if (this.AssociatedObject.OlapDataManager != null && this.AssociatedObject.OlapDataManager.CurrentReport != null)
            {
                this.AssociatedObject.OlapDataManager.CurrentReport.ChartSettings.LabelsVisibility = true;
            }
        }
    }
}
