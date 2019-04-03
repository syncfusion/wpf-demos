#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.BulletGraph;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BulletGraphMeasures
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
       Dictionary<string, Color> colorsList = new Dictionary<string, Color>();

       public MainWindow()
        {
            this.InitializeComponent();

            Type colorType = typeof(Colors);
            IEnumerable<PropertyInfo> propInfos = colorType.GetProperties();
            foreach (PropertyInfo propInfo in propInfos)
            {
                colorsList.Add(propInfo.Name, (Color)propInfo.GetValue(propInfo,null));
            }

            cmb_Range1Stroke.ItemsSource = cmb_Range2Stroke.ItemsSource = cmb_Range3Stroke.ItemsSource = colorsList.Keys;
        }

       
        private void cmb_Range1Stroke_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            SfBulletGraph.QualitativeRanges[0].RangeStroke = new SolidColorBrush(colorsList[cmb_Range1Stroke.SelectedItem.ToString()]);
        }

        private void cmb_Range2Stroke_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            SfBulletGraph.QualitativeRanges[1].RangeStroke = new SolidColorBrush(colorsList[cmb_Range2Stroke.SelectedItem.ToString()]);
        }

        private void cmb_Range3Stroke_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            SfBulletGraph.QualitativeRanges[2].RangeStroke = new SolidColorBrush(colorsList[cmb_Range3Stroke.SelectedItem.ToString()]);
        }
    }
}
