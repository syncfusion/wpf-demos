#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace GroupingBar
{
    using System.Windows;
    using System.Windows.Controls;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void chkBoxShowSubTotalsForChildren_Click(object sender, RoutedEventArgs e)
        {
             CheckBox sourceObject = e.OriginalSource as CheckBox;
             if (sourceObject != null)
             {
                 if (this.pivotGrid1.PivotRows.Count <= 2 && this.pivotGrid1.PivotColumns.Count <= 2)
                 {
                     sourceObject.IsChecked = false;
                     MessageBox.Show(" ShowSubTotalsForChildren enables only when either PivotRows count or PivotColumns count must be greater than two ", "Warning Alert!", MessageBoxButton.OK, MessageBoxImage.Error);
                 }
             }
        }
    }   
}