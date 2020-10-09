#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System.Windows;
    using System.Windows.Controls;

    public partial class GroupingBar : DemoControl
    {
        public GroupingBar()
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

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            if (this.pivotGrid1 != null)
            {
                this.pivotGrid1.Dispose();
                this.pivotGrid1 = null;
            }
            base.Dispose(disposing);
        }
    }   
}