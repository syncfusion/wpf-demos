#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapgriddemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for Serialization.xaml
    /// </summary>
    public partial class Serialization : DemoControl
    {
        public Serialization()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            chkShowExpander.Unchecked -= chkShowExpander_Unchecked;
            (this.DataContext as SerializationViewModel).Dispose();
            this.DataContext = null;
            if (this.olapGrid != null)
            {
                this.olapGrid.Dispose();
                this.olapGrid = null;
            }
        }

        private void chkShowExpander_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            this.chkBoxHeaderTooltip.IsChecked = false;

        }
    }
}
