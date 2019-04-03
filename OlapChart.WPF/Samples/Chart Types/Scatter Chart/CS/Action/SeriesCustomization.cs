#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="SeriesCustomization.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace SeriesCustomizationDemo.Action
{
    using System.Windows.Interactivity;
    using Syncfusion.Windows.Chart.Olap;
    using System.Windows;
    using System.Windows.Controls;
    using Syncfusion.Windows.Chart;

    public class SeriesCustomization : TargetedTriggerAction<OlapChart>
    {
        #region Methods

        protected override void Invoke(object parameter)
        {
            if (parameter is RoutedEventArgs)
            {
                var radioButton = (parameter as RoutedEventArgs).Source as RadioButton;
                if (radioButton != null)
                {
                    foreach (ChartSeries series in this.Target.Series)
                    {
                        series.Template = Application.Current.Resources["Scatter" + radioButton.Content] as DataTemplate;
                    }
                }
            }
        }

        #endregion
    }
}