#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


namespace syncfusion.olapchartdemos.wpf
{
    using System.Windows;
    using System.Windows.Media;
    using Microsoft.Xaml.Behaviors;
    using Syncfusion.Windows.Chart.Olap;

    public class ExpanderSeriesCustomization : TargetedTriggerAction<OlapChart>
    {
        #region Methods

        protected override void Invoke(object parameter)
        {
            for (int i = 0; i < this.Target.Series.Count; i++)
            {
                // Apply Series Interior to display the series in different colors.
                this.Target.Series[i].Interior = Application.Current.Resources["SeriesInterior" + i] as LinearGradientBrush;
            }
        }

        #endregion
    }
}
