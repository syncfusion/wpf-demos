#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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

namespace syncfusion.expenseanalysis.wpf
{
    /// <summary>
    /// Interaction logic for DashboardView.xaml
    /// </summary>
    public partial class DashboardView : UserControl
    {
        public DashboardView()
        {
            InitializeComponent();
        }

        private void NumericalAxis_LabelCreated(object sender, Syncfusion.UI.Xaml.Charts.LabelCreatedEventArgs e)
        {
            var axisLabel = e.AxisLabel;
            axisLabel.LabelContent = axisLabel.Position == 0 ? axisLabel.LabelContent :
                        (double.Parse((string)axisLabel.LabelContent) >= 1000) ?
                        "$" + (Math.Round((double.Parse((string)axisLabel.LabelContent) / 1000), 0)) + "K" :
                        "$" + axisLabel.LabelContent;
        }
    }
}
