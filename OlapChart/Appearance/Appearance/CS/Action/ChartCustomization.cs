#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="ChartCustomization.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace ChartAppearance.Action
{
    using Microsoft.Win32;
    using System;
    using System.Windows.Interactivity;
    using Syncfusion.Windows.Chart.Olap;
    using System.Windows.Media;
    using System.Windows;
    using System.Windows.Media.Imaging;
    using System.Windows.Controls;
    using Syncfusion.Windows.Chart;

    public class AppearanceChart : TargetedTriggerAction<OlapChart>
    {
        #region Members

        static Color startColor = Colors.AliceBlue, endColor = Colors.PapayaWhip, startInteriorColor = Colors.Cyan, endInteriorColor = Colors.Khaki;
        static string gradientAngle = "Horizontal";

        #endregion

        #region Methods

        protected override void Invoke(object parameter)
        {
            if ((parameter as SelectionChangedEventArgs) != null && (parameter as SelectionChangedEventArgs).Source is ComboBox)
            {
                var comboBox = (parameter as SelectionChangedEventArgs).Source as ComboBox;
                if (comboBox != null)
                {
                    if (comboBox.Name == "comboChartWidth")
                    {
                        string selectedValue = comboBox.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                        Target.BorderThickness = new Thickness(double.Parse(selectedValue));
                    }
                    if (comboBox.Name == "comboSeriesBorderWidth")
                    {
                        string selectedValue = comboBox.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                        foreach (ChartSeries series in Target.Series)
                        {
                            series.StrokeThickness = double.Parse(selectedValue);
                        }
                    }
                    if (comboBox.Name == "comboChartColor")
                    {
                        string selectedValue = comboBox.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                        var color = ColorConverter.ConvertFromString(selectedValue);
                        if (color != null)
                        {
                            SolidColorBrush brush = new SolidColorBrush((Color)color);
                            Target.BorderBrush = brush;
                        }
                    }
                    if (comboBox.Name == "comboSeriesborderColor")
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
                    if (comboBox.Name == "combo_FontColor")
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
                    if (comboBox.Name == "SeriesPalette")
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
                            new SolidColorBrush(Colors.Red),
                            };
                            Target.ColorModel.Palette = ChartColorPalette.Custom;
                        }
                        else
                        {
                            Target.ColorModel.Palette = (ChartColorPalette)comboBox.SelectedItem;
                        }
                    }
                    var gradientSetting = comboBox.Name;
                    if (gradientSetting == "combo_StartColor" || gradientSetting == "combo_EndColor" || gradientSetting == "combo_InteriorStartColor" || gradientSetting == "combo_InteriorEndColor" || gradientSetting == "combo_GradientStyle")
                    {
                        string selectedValue = comboBox.SelectedItem.ToString().Replace("System.Windows.Controls.ComboBoxItem: ", "");
                        if (gradientSetting == "combo_StartColor")
                        {
                            var color = ColorConverter.ConvertFromString(selectedValue);
                            if (color != null)
                                startColor = (Color)color;
                        }
                        else if (gradientSetting == "combo_EndColor")
                        {
                            var color = ColorConverter.ConvertFromString(selectedValue);
                            if (color != null)
                                endColor = (Color)color;
                        }
                        else if (gradientSetting == "combo_InteriorStartColor")
                        {
                            var color = ColorConverter.ConvertFromString(selectedValue);
                            if (color != null)
                                startInteriorColor = (Color)color;
                        }
                        else if (gradientSetting == "combo_InteriorEndColor")
                        {
                            var color = ColorConverter.ConvertFromString(selectedValue);
                            if (color != null)
                                endInteriorColor = (Color)color;
                        }
                        else if (gradientSetting == "combo_GradientStyle")
                        {
                            gradientAngle = selectedValue;
                        }
                        Target.Background = gradientAngle == "Horizontal" ? new LinearGradientBrush(startColor, endColor, 0) : new LinearGradientBrush(startColor, endColor, 90);
                        Target.GridBackground = gradientAngle == "Horizontal" ? new LinearGradientBrush(startInteriorColor, endInteriorColor, 0) : new LinearGradientBrush(startInteriorColor, endInteriorColor, 90);
                    }
                }
            }
            else if (parameter is RoutedEventArgs)
            {
                if ((parameter as RoutedEventArgs).Source is CheckBox)
                {
                    var checkBox = (parameter as RoutedEventArgs).Source as CheckBox;
                    if (checkBox != null)
                    {
                        if (checkBox.Name == "GridHorizontalCheckBox1" && checkBox.IsChecked != null)
                        {
                            bool selectedValue = (bool)checkBox.IsChecked;
                            Target.Series[0].Area.SecondaryAxis.SetValue(ChartArea.ShowGridLinesProperty, selectedValue);
                        }
                        if (checkBox.Name == "GridVerticalCheckBox1" && checkBox.IsChecked != null)
                        {
                            bool selectedValue = (bool)checkBox.IsChecked;
                            Target.Series[0].Area.PrimaryAxis.SetValue(ChartArea.ShowGridLinesProperty, selectedValue);
                        }
                        if (checkBox.Name == "chkclr" && checkBox.IsChecked != null)
                        {
                            bool selectedvalue = (bool)checkBox.IsChecked;
                            if (selectedvalue == false)
                            {
                                Target.Background = new SolidColorBrush(Colors.White);
                                Target.GridBackground = new SolidColorBrush(Colors.White);
                            }
                            else
                            {
                                Target.Background = gradientAngle == "Horizontal" ? new LinearGradientBrush(startColor, endColor, 0) : new LinearGradientBrush(startColor, endColor, 90);
                                Target.GridBackground = gradientAngle == "Horizontal" ? new LinearGradientBrush(startInteriorColor, endInteriorColor, 0) : new LinearGradientBrush(startInteriorColor, endInteriorColor, 90);
                            }
                        }
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
                }
                else if ((parameter as RoutedEventArgs).Source is Button)
                {
                    OpenFileDialog ofd = new OpenFileDialog();
                    ofd.Filter = "BackGround files (*.jpg)|*.jpg|All files (*.*)|*.*";
                    bool validate;
                    do
                    {
                        validate = true;
                        if (ofd.ShowDialog() == true)
                        {
                            System.Drawing.Imaging.ImageFormat imageFormat = null;
                            string extension = System.IO.Path.GetExtension(ofd.FileName);
                            if (extension != null && (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg"))
                                imageFormat = System.Drawing.Imaging.ImageFormat.Jpeg;
                            validate = imageFormat != null;
                            if (!validate)
                            {
                                MessageBox.Show("*" + extension + " is not a valid image format", "Appearance", MessageBoxButton.OK, MessageBoxImage.Error);
                            }
                            else
                            {
                                ImageBrush myBrush = new ImageBrush();
                                myBrush.ImageSource = new BitmapImage(new Uri(ofd.FileName, UriKind.RelativeOrAbsolute));
                                Target.GridBackground = myBrush;
                            }
                        }
                    } while (!validate);
                }
            }
        }
        #endregion
    }
}