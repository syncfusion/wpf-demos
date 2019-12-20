#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Schedule;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ResourceDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    #region MainWindow Class

    public partial class MainWindow : Window
    {
        #region Constructor

        public MainWindow()
        {
            this.InitializeComponent();
            (this.Schedule1.ScheduleResourceTypeCollection[0].ResourceCollection[0] as CustomResource).ResourceImageUri = new BitmapImage(new Uri("pack://application:,,,/ResourceDemo;Component/Assets/emp1.png"));
            (this.Schedule1.ScheduleResourceTypeCollection[0].ResourceCollection[1] as CustomResource).ResourceImageUri = new BitmapImage(new Uri("pack://application:,,,/ResourceDemo;Component/Assets/emp2.png"));
        }

        #endregion
    }

    #endregion

    
}
