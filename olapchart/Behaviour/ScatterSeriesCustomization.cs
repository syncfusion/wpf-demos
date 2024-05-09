#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapchartdemos.wpf
{
    using Syncfusion.Windows.Chart.Olap;
    using System.Windows;
    using System.Windows.Controls;
    using Syncfusion.Windows.Chart;
    using Microsoft.Xaml.Behaviors;
    using System;

    public class ScatterSeriesCustomization : TargetedTriggerAction<OlapChart>
    {
        private ResourceDictionary CommonResourceDictionary { get; set; }

        #region Methods

        protected override void Invoke(object parameter)
        {
            CommonResourceDictionary = new ResourceDictionary() { Source = new Uri("/syncfusion.olapchartdemos.wpf;component/Resources/olapchart/OlapChartIcon.xaml", UriKind.RelativeOrAbsolute) };

            if (parameter is RoutedEventArgs)
            {
                var radioButton = (parameter as RoutedEventArgs).Source as RadioButton;
                if (radioButton != null)
                {
                    foreach (ChartSeries series in this.Target.Series)
                    {
                        series.Template = CommonResourceDictionary["Scatter" + radioButton.Content] as DataTemplate;
                    }
                }
            }
        }

        #endregion
    }
}
