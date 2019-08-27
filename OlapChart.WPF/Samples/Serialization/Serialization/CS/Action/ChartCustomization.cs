#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ChartCustomization.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright> 
#endregion

namespace Serialization.Action
{
    using System;
    using System.Windows.Interactivity;
    using Syncfusion.Windows.Chart.Olap;
    using System.Windows.Media;
    using Syncfusion.Windows.Chart;
    using System.Windows;
    using System.Windows.Controls;
    using Microsoft.Win32;

    public class AppearanceChart : TargetedTriggerAction<OlapChart>
    {
        #region Methods

        protected override void Invoke(object parameter)
        {
            if ((parameter is SelectionChangedEventArgs) && (parameter as SelectionChangedEventArgs).Source is ComboBox)
            {
                var comboBox = (parameter as SelectionChangedEventArgs).Source as ComboBox;
                if (comboBox.Name == "comboChartWidth")
                {
                    string selectedValue = comboBox.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                    Target.BorderThickness = new Thickness(double.Parse(selectedValue));
                }
                else if (comboBox.Name == "comboSeriesBorderWidth")
                {
                    string selectedValue = comboBox.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                    foreach (ChartSeries series in Target.Series)
                    {
                        series.StrokeThickness = double.Parse(selectedValue);

                    }
                }
                else if (comboBox.Name == "comboChartColor")
                {
                    string selectedValue = comboBox.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                    var color = ColorConverter.ConvertFromString(selectedValue);
                    if (color != null)
                    {
                        SolidColorBrush brush = new SolidColorBrush((Color)color);
                        Target.BorderBrush = brush;
                    }
                }
                else if (comboBox.Name == "comboSeriesborderColor")
                {
                    string selectedValue = comboBox.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                    foreach (ChartSeries series in Target.Series)
                    {
                        var color = ColorConverter.ConvertFromString(selectedValue);
                        if (color != null)
                        {
                            SolidColorBrush brush = new SolidColorBrush((Color)color);
                            series.Stroke = brush;
                        }
                    }
                }
                else if (comboBox.Name == "combo_palette")
                {
                    string selectedValue = comboBox.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                    if (selectedValue == "Custom")
                    {
                        Target.ColorModel.CustomPalette = new Brush[]
                        {
                            new SolidColorBrush(Colors.Violet),
                            new SolidColorBrush(Colors.Indigo),
                            new SolidColorBrush(Colors.Blue),
                            new SolidColorBrush(Colors.Green),
                            new SolidColorBrush(Colors.Yellow),
                            new SolidColorBrush(Colors.Orange),
                            new SolidColorBrush(Colors.Red)
                        };
                        Target.ColorModel.Palette = ChartColorPalette.Custom;
                    }
                    else
                    {
                        Target.ColorModel.Palette = (ChartColorPalette)comboBox.SelectedItem;
                    }
                }
                else if (comboBox.Name == "combo_FontColor")
                {
                    string selectedValue = comboBox.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");

                    var color = ColorConverter.ConvertFromString(selectedValue);
                    if (color != null)
                    {
                        SolidColorBrush brush = new SolidColorBrush((Color)color);
                        Target.PrimaryAxis.LabelForeground = brush;
                        if (Target.SecondaryAxis != null)
                            Target.SecondaryAxis.LabelForeground = brush;
                    }
                }
                else if(comboBox.Name == "combo_fontStyle")
                {
                    string selectedValue = comboBox.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                    FontFamily family = new FontFamily(selectedValue);

                    Target.PrimaryAxis.LabelFontFamily = family;
                    if (Target.SecondaryAxis != null)
                        Target.SecondaryAxis.LabelFontFamily = family;
                }
                else if(comboBox.Name == "ExcelChartPalette")
                {
                    string selectedValue = comboBox.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                    Target.ColorModel.Palette = (ChartColorPalette)Enum.Parse(typeof(ChartColorPalette), selectedValue);
                }
            }
            else if (parameter is RoutedEventArgs)
            {
                if ((parameter as RoutedEventArgs).Source is CheckBox)
                {
                    var checkBox = (parameter as RoutedEventArgs).Source as CheckBox;
                    if (checkBox.Name == "checkBox_ShowLegend" && checkBox.IsChecked != null)
                    {
                        bool selectedValue = (bool)checkBox.IsChecked;
                        if (selectedValue)
                        {
                            Target.Legend.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            Target.Legend.Visibility = Visibility.Collapsed;
                            Target.Legend.CheckBoxVisibility = Visibility.Collapsed;
                        }
                    }
                    if (checkBox.Name == "checkBox_ShowCheck" && checkBox.IsChecked != null)
                    {
                        bool selectedValue = (bool)checkBox.IsChecked;
                        Target.Legend.CheckBoxVisibility = selectedValue ? Visibility.Visible : Visibility.Collapsed;
                    }
                }
                else if (((parameter as RoutedEventArgs).Source as Button).Name == "saveBtn")
                {
                    if (Target.OlapDataManager != null)
                    {
                        try
                        {
                            SaveFileDialog saveFileDialog = new SaveFileDialog();
                            saveFileDialog.AddExtension = true;
                            saveFileDialog.FileName = "Report";
                            saveFileDialog.DefaultExt = "xml";
                            saveFileDialog.Filter = "Report (.xml)|*.xml";

                            if (saveFileDialog.ShowDialog() == true)
                            {
                                string fileName = saveFileDialog.FileName;
                                Target.OlapDataManager.CurrentReport.ChartSettings = Target.ChartAppearance;
                                Target.OlapDataManager.SaveReport(fileName);
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error occurred while saving the report");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data manager not yet bind to chart control.", "Serialization Demo");
                    }
                }
                else if (((parameter as RoutedEventArgs).Source as Button).Name == "loadBtn")
                {
                    if (Target.OlapDataManager != null)
                    {
                        try
                        {
                            OpenFileDialog openFileDialog = new OpenFileDialog();
                            openFileDialog.AddExtension = true;
                            openFileDialog.DefaultExt = "xml";
                            openFileDialog.Filter = "Report Set (.xml)|*.xml";
                            if (openFileDialog.ShowDialog() == true)
                            {
                                Target.OlapDataManager.LoadReportDefinitionFile(openFileDialog.FileName);
                                if (Target.OlapDataManager.Reports.Count > 0)
                                    Target.OlapDataManager.SetCurrentReport(Target.OlapDataManager.Reports[0]);
                                Target.DataBind();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error occurred while saving the report");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Data manager not yet bind to chart control.", "Serialization Demo");
                    }
                }
            }
        }

        #endregion
    }
}
