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

    public partial class PivotUpdating : DemoControl
    {

        #region Constructor
        public PivotUpdating()
        {
            InitializeComponent();
            this.pivotGrid1.Loaded += PivotGrid1_Loaded;
        }
        #endregion

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            this.chkEnableUpdate.Click -= chkEnableUpdate_Click;
            this.cmbUpdateRate.SelectionChanged -= cmbUpdateRate_SelectionChanged;
            if (this.pivotGrid1 != null)
            {
                this.pivotGrid1.Loaded -= PivotGrid1_Loaded;
                this.pivotGrid1.Dispose();
                this.pivotGrid1 = null;
            }
            base.Dispose(disposing);
        }

        private void PivotGrid1_Loaded(object sender, RoutedEventArgs e)
        {            
            this.btnAddTop.CommandParameter = this.btnAddTop.Content.ToString();
            this.btnAddMid.CommandParameter = this.btnAddMid.Content.ToString();
            this.btnAddBot.CommandParameter = this.btnAddBot.Content.ToString();
            this.chkTimerUpdate.CommandParameter = chkTimerUpdate.IsChecked ?? false;
            this.SchemaDesigner.PivotControl = this.pivotGrid1;
            this.SchemaDesigner.VisualStyle = Syncfusion.Windows.Controls.PivotGrid.PivotGridVisualStyle.Metro;
        }

        private void chkEnableUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.EnableUpdating = (sender as CheckBox).IsChecked ?? false;
            this.chkTimerUpdate.IsEnabled = (sender as CheckBox).IsChecked ?? false;
            this.cmbUpdateRate.IsEnabled = (sender as CheckBox).IsChecked ?? false;
            this.btnAddTop.IsEnabled = (sender as CheckBox).IsChecked ?? false;
            this.btnAddMid.IsEnabled = (sender as CheckBox).IsChecked ?? false;
            this.btnAddBot.IsEnabled = (sender as CheckBox).IsChecked ?? false;
        }

        private void cmbUpdateRate_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.pivotGrid1.UpdateManager.ThrottleUpdateRate = int.Parse((sender as ComboBox).SelectedItem.ToString());
        }

        private void chkTimerUpdate_Click(object sender, RoutedEventArgs e)
        {
            this.chkTimerUpdate.CommandParameter = (sender as CheckBox).IsChecked ?? false;
        }
    }
}