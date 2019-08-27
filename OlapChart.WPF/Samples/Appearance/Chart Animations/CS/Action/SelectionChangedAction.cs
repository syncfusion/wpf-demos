#region Copyright
// <copyright file="SelectionChangedAction.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace ChartAnimations.Action
{
    using System.Windows.Controls;
    using System.Windows.Interactivity;
    using Syncfusion.Windows.Chart.Olap;
    using Syncfusion.Windows.Chart;

    public class SelectionChangedAction : TargetedTriggerAction<OlapChart>
    {
        #region Methods

        protected override void Invoke(object parameter)
        {
            if (parameter is SelectionChangedEventArgs)
            {
                SelectionChangedEventArgs args = parameter as SelectionChangedEventArgs;
                ComboBox box = args.OriginalSource as ComboBox;
                if (box != null && box.Name.Equals("seriesTypeBox"))
                {
                    if (box.SelectedIndex == 0)
                    {
                        Target.ChartType = ChartTypes.Column;
                    }
                    else if (box.SelectedIndex == 1)
                    {
                        Target.ChartType = ChartTypes.Bar;
                        Target.Series.Clear();
                        Target.OlapDataManager.NotifyElementModified();
                    }
                    else
                    {
                        Target.ChartType = ChartTypes.Line;
                    }
                }
                else if (box != null && box.Name.Equals("animationBox"))
                {
                    if (box.SelectedIndex == 0)
                    {
                        Target.SeriesAnimateOption = AnimationOptions.Top;
                    }
                    else if (box.SelectedIndex == 1)
                    {
                        Target.SeriesAnimateOption = AnimationOptions.Left;
                    }
                    else if (box.SelectedIndex == 2)
                    {
                        Target.SeriesAnimateOption = AnimationOptions.Right;
                    }
                    else if (box.SelectedIndex == 3)
                    {
                        Target.SeriesAnimateOption = AnimationOptions.Bottom;
                    }
                    else if (box.SelectedIndex == 4)
                    {
                        Target.SeriesAnimateOption = AnimationOptions.Rotate;
                    }
                    else if (box.SelectedIndex == 5)
                    {
                        Target.SeriesAnimateOption = AnimationOptions.Fade;
                    }
                    else
                    {
                        Target.SeriesAnimateOption = AnimationOptions.Scaling;
                    }
                }
            }
        }

        #endregion
    }
}