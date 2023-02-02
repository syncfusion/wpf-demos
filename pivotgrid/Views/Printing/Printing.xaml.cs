#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
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

    public partial class Printing : DemoControl
    {
        public Printing()
        {
            InitializeComponent();
            button1.CommandParameter = this.pivotGrid1;
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            this.chkGroupBar.Click -= chkGroupBar_Click;
            if (this.pivotGrid1 != null)
            {
                this.pivotGrid1.Dispose();
                this.pivotGrid1 = null;
            }
            base.Dispose(disposing);
        }

        private void chkGroupBar_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.ShowGroupingBar = (sender as CheckBox).IsChecked ?? false;
        }
    }
}


