#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ChartLoadedBehavior.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace LineChart.Behavior
{
    using Syncfusion.Windows.Chart.Olap;
    using System.Windows.Interactivity;
    using Syncfusion.Windows.Chart;
    using System.Windows;

    public class ChartLoadedBehavior : Behavior<OlapChart>
    {
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
            for (int i = 0; i < this.AssociatedObject.Series.Count; i++)
            {
                this.AssociatedObject.Series[i].AdornmentsInfo = new ChartAdornmentInfo
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Visible = true,
                    LabelTemplate = Application.Current.Resources["LabelTemplate" + i] as DataTemplate
                };
            }
            if (this.AssociatedObject.OlapDataManager != null && this.AssociatedObject.OlapDataManager.CurrentReport != null)
            {
                this.AssociatedObject.OlapDataManager.CurrentReport.ChartSettings.LabelsVisibility = true;
            }
        }
    }
}