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
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.SampleLayout;

namespace Scalebreak_Demo_2015
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        ScalebreakViewModel vm = new ScalebreakViewModel();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = vm;
        }

        private void brk_position_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combo = sender as ComboBox;
            if (combo.SelectedIndex == 2)
            {
                axis2.BreakPosition = ScaleBreakPosition.Percent;
                brk_percent.Visibility = Visibility.Visible;
                brk_percentText.Visibility = Visibility.Visible;
                brk_percent1.Visibility = Visibility.Visible;
                brk_percentText1.Visibility = Visibility.Visible;
            }
            else if(combo.SelectedIndex==1)
            {
                axis2.BreakPosition = ScaleBreakPosition.Scale;
                if (brk_percent != null && brk_percentText != null)
                {
                    brk_percent.Visibility = Visibility.Collapsed;
                    brk_percentText.Visibility = Visibility.Collapsed;
                    brk_percent1.Visibility = Visibility.Collapsed;
                    brk_percentText1.Visibility = Visibility.Collapsed;
                }
            }
            else
            {
                axis2.BreakPosition = ScaleBreakPosition.DataCount;
                if(brk_percent!=null && brk_percentText!=null)
                {
                    brk_percent.Visibility = Visibility.Collapsed;
                    brk_percentText.Visibility = Visibility.Collapsed;
                    brk_percent1.Visibility = Visibility.Collapsed;
                    brk_percentText1.Visibility = Visibility.Collapsed;
                }               
            }               
        }       
    }   
}
