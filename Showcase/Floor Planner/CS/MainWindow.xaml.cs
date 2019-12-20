#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Shared;

namespace FloorPlanner
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            FloorPlannerViewModel floor = new FloorPlannerViewModel();
            floor.GoBack = new DiagramFrontPageUtility.DelegateCommand<object>(OnGoBack);
            this.DataContext = floor;


         
            //this.MouseDown += MainWindow_MouseDown;
        }

        //void MainWindow_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (e.RightButton == MouseButtonState.Pressed)
        //    {
        //        if (bar.Visibility == Visibility.Visible)
        //        {
        //            bar.Visibility = Visibility.Collapsed;
        //        }
        //        else
        //        {
        //            bar.Visibility = Visibility.Visible;
        //        }
        //    }
        //    else
        //    {
        //        bar.Visibility = Visibility.Collapsed;
        //    }
        //}

        //private void Close(object sender, RoutedEventArgs e)
        //{
        //    this.Close();
        //    bar.Visibility = Visibility.Collapsed;
        //}
        private void OnGoBack(object parameter)
        {
            FloorPlannerViewModel VM = this.DataContext as FloorPlannerViewModel;
            VM.GoBack = null;
            this.DataContext = null;
            //Frame.GoBack();
        }

      
    }
}
