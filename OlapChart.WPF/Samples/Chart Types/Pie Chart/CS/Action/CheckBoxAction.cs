#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="CheckBoxAction.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace PieChart.Action
{
    using System.Windows.Interactivity;
    using System.Windows;
    using System.Windows.Controls;
    using Syncfusion.Windows.Chart;

    class CheckBoxAction : TargetedTriggerAction<MainWindow>
    {
        #region Methods

        protected override void Invoke(object parameter)
        {
            if (parameter is RoutedEventArgs)
            {
                CheckBox targetBox = (parameter as RoutedEventArgs).OriginalSource as CheckBox;
                if (targetBox != null && targetBox.IsChecked != null)
                {
                    switch (targetBox.Name)
                    {
                        case "checkExplodeAll":
                            foreach (ChartSeries series in this.Target.olapChart1.Series)
                            {
                                ChartPieType.SetExplodedAll(series, targetBox.IsChecked.Value);
                            }
                            if ((bool)targetBox.IsChecked)
                            {
                                this.Target.comboExplodeIndex.IsEnabled = false;
                                this.Target.txtExplodeIndex.IsEnabled = false;
                            }
                            else
                            {
                                this.Target.comboExplodeIndex.IsEnabled = true;
                                this.Target.txtExplodeIndex.IsEnabled = true;
                            }
                            break;
                        case "checkEnableEffects":
                            foreach (ChartSeries series in this.Target.olapChart1.Series)
                            {
                                series.EnableEffects = targetBox.IsChecked.Value;
                            }
                            break;
                    }
                }
            }
        }

        #endregion
    }
}