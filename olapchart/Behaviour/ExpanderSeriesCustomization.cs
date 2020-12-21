#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


namespace syncfusion.olapchartdemos.wpf
{
    using System;
    using System.Windows;
    using System.Windows.Media;
    using Microsoft.Xaml.Behaviors;
    using Syncfusion.Windows.Chart.Olap;

    public class ExpanderSeriesCustomization : TargetedTriggerAction<OlapChart>
    {
        private ResourceDictionary CommonResourceDictionary { get; set; }

        #region Methods

        protected override void Invoke(object parameter)
        {
            CommonResourceDictionary = new ResourceDictionary() { Source = new Uri("/syncfusion.olapchartdemos.wpf;component/Resources/olapchart/OlapChartIcon.xaml", UriKind.RelativeOrAbsolute) };

            for (int i = 0; i < this.Target.Series.Count; i++)
            {
                // Apply Series Interior to display the series in different colors.
                this.Target.Series[i].Interior = CommonResourceDictionary["SeriesInterior" + i] as LinearGradientBrush;
            }
        }

        #endregion
    }
}
