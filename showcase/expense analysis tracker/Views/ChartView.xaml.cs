#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace syncfusion.expenseanalysis.wpf
{
    /// <summary>
    /// Interaction logic for ChartView.xaml
    /// </summary>
    public partial class ChartView : UserControl
    {
        public ChartView()
        {
            InitializeComponent();
            this.Unloaded += ChartView_Unloaded;
        }

        private void ChartView_Unloaded(object sender, RoutedEventArgs e)
        {
            if (Chart != null)
            {
                Chart.Dispose();
                Chart = null;
            }

            if (sfBadge1 != null)
                sfBadge1 = null;

            if (sfBadge2 != null)
                sfBadge2 = null;

            if (sfBadge3 != null)
                sfBadge3 = null;

            this.Unloaded -= ChartView_Unloaded;
        }
    } 
}
