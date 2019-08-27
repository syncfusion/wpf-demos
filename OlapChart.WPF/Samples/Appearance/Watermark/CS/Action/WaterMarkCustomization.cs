#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="WaterMarkCustomization.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace ChartWaterMark.Action
{
    using System;
    using System.Windows.Interactivity;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Controls;
    using System.Windows.Media.Imaging;
    using Syncfusion.Windows.Chart.Olap;
    using Syncfusion.Windows.Chart;
    using SampleUtils;

    public class WaterMarkCustomization : TargetedTriggerAction<OlapChart>
    {
        static AlignmentX horizontalAlignment = AlignmentX.Center;
        private static AlignmentY verticalAlignment = AlignmentY.Center;

        protected override void Invoke(object parameter)
        {
            var visualBrush = Target.GridBackground as VisualBrush;
            var panel = ((this.Target.GridBackground as VisualBrush).Visual as Panel);
            if (panel != null && panel.Children.Count > 1 && panel.Children[0] is Image && panel.Children[1] is TextBlock)
            {
                if (parameter is SelectionChangedEventArgs && ((parameter as SelectionChangedEventArgs).Source as ComboBox).Name == "combo_hralign")
                {
                    string selectedValue = ((parameter as SelectionChangedEventArgs).Source as ComboBox).SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                    switch (selectedValue)
                    {
                        case "Left":
                            visualBrush.AlignmentX = AlignmentX.Left;
                            horizontalAlignment = AlignmentX.Left;
                            break;
                        case "Right":
                            visualBrush.AlignmentX = AlignmentX.Right;
                            horizontalAlignment = AlignmentX.Right;
                            break;
                        case "Center":
                            visualBrush.AlignmentX = AlignmentX.Center;
                            horizontalAlignment = AlignmentX.Center;
                            break;
                    }
                }
                else if (parameter is SelectionChangedEventArgs && ((parameter as SelectionChangedEventArgs).Source as ComboBox).Name == "combo_vralign")
                {
                    string selectedValue = ((parameter as SelectionChangedEventArgs).Source as ComboBox).SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                    switch (selectedValue)
                    {
                        case "Top":
                            visualBrush.AlignmentY = AlignmentY.Top;
                            verticalAlignment = AlignmentY.Top;
                            break;
                        case "Bottom":
                            visualBrush.AlignmentY = AlignmentY.Bottom;
                            verticalAlignment = AlignmentY.Bottom;
                            break;
                        case "Center":
                            visualBrush.AlignmentY = AlignmentY.Center;
                            verticalAlignment = AlignmentY.Center;
                            break;
                    }
                }
                else if (parameter is EventArgs && (parameter as RoutedEventArgs).Source is RadioButton && ((parameter as RoutedEventArgs).Source as RadioButton).Name == "rd_imagewatermark")
                {
                    (panel.Children[0] as Image).Visibility = Visibility.Visible;
                    (panel.Children[1] as TextBlock).Visibility = Visibility.Hidden;
                    visualBrush.AlignmentY = verticalAlignment;
                    visualBrush.AlignmentX = horizontalAlignment;
                    string samplePath = SampleSourceHelper.GetSamplePath() + @"Common\Images\OlapChart";
                    (panel.Children[0] as Image).Source = new BitmapImage(new Uri(samplePath + @"\Watermark.png"));
                }
                else if (parameter is EventArgs && (parameter as RoutedEventArgs).Source is RadioButton && ((parameter as RoutedEventArgs).Source as RadioButton).Name == "rd_textwatermark")
                {
                    (panel.Children[0] as Image).Source = null;
                    (panel.Children[0] as Image).Visibility = Visibility.Hidden;
                    (panel.Children[1] as TextBlock).Visibility = Visibility.Visible;
                    visualBrush.AlignmentY = verticalAlignment;
                    visualBrush.AlignmentX = horizontalAlignment;
                }
                if (parameter is EventArgs)
                {
                    int i = 0;
                    string[] colors = { "Red", "Lime", "Cyan", "Violet", "DeepSkyBlue", "DarkGray", "Blue" };
                    foreach (ChartSeries series in this.Target.Series)
                    {
                        var color = ColorConverter.ConvertFromString(colors[i]);
                        if (color != null)
                        {
                            SolidColorBrush brush = new SolidColorBrush((Color)color);
                            series.StrokeThickness = 3;
                            series.Interior = brush;
                        }
                        i += 1;
                    }
                }
            }
        }
    }
}