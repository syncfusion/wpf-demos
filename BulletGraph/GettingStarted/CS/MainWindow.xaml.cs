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

namespace BulletGraphDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            cmb_FlowDirection.ItemsSource = Enum.GetValues(typeof(FlowDirection));
            cmb_TickPosition.ItemsSource = Enum.GetValues(typeof(BulletGraphTicksPosition));
            cmb_LabelPosition.ItemsSource = Enum.GetValues(typeof(BulletGraphLabelsPosition));
            cmb_CaptionPosition.ItemsSource = Enum.GetValues(typeof(BulletGraphCaptionPosition));
            //Binding FlowDirectionBinding = new Binding() { Source = cmb_FlowDirection, Path = new PropertyPath("SelectedItem"), Mode = BindingMode.TwoWay };
            //BindingOperations.SetBinding(SfBulletGraph1, SfBulletGraph.FlowDirectionProperty, FlowDirectionBinding);
            //BindingOperations.SetBinding(SfBulletGraph2, SfBulletGraph.FlowDirectionProperty, FlowDirectionBinding);
            //BindingOperations.SetBinding(SfBulletGraph3, SfBulletGraph.FlowDirectionProperty, FlowDirectionBinding);
            cmb_LabelPosition.SelectedIndex = cmb_TickPosition.SelectedIndex = 1;
            cmb_FlowDirection.SelectedIndex = cmb_CaptionPosition.SelectedIndex = 0;

        }
        
        

    }
}
