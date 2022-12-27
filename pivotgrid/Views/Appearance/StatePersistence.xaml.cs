#region Copyright Syncfusion Inc. 2001 - 2022
// Copyright Syncfusion Inc. 2001 - 2022. All rights reserved.
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

    public partial class StatePersistence : DemoControl
    {
        public StatePersistence()
        {
            InitializeComponent();
            this.pivotGrid1.Loaded += PivotGrid1_Loaded;
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            this.statePersistanceCheckBox.Click -= StatePersistanceCheckBox_Click;
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
            this.refreshButton.CommandTarget = this.pivotGrid1;
            this.SchemaDesigner.PivotControl = this.pivotGrid1;
        }

        private void StatePersistanceCheckBox_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.StatePersistenceEnabled = (sender as CheckBox).IsChecked ?? false;
        }
    }   
}
