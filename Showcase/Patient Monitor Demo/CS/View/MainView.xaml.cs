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
using System.Windows.Threading;
using Syncfusion.UI.Xaml.Charts;

namespace PatientDetailsDemo
{
    /// <summary>
    /// Interaction logic for HistoryDetailsView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
     
        
        public MainView()
        {
            InitializeComponent();
           
        }

        private void syncgrid_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            if (currentDetailsDemo != null)
            {
                var curr = (currentDetailsDemo.DataContext as PatientDetails);
                currentDetailsDemo.SwapDataContext();
            }

           
        }

       
    }
}
