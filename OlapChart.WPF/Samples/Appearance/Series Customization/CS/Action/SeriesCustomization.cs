#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="SeriesCustomization.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace SeriesCustomization.Action
{
    using System.Windows;
    using System.Windows.Interactivity;
    using System.Windows.Media;
    using Syncfusion.Windows.Chart.Olap;

    public class SeriesCustomization : TargetedTriggerAction<OlapChart>
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