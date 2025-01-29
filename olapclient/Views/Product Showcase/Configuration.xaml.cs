#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion

namespace syncfusion.olapclientdemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for Configuration.xaml
    /// </summary>
    public partial class Configuration : DemoControl
    {
        public Configuration()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Triggered when checkbox state is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void chk_AxisElementBuilder_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (chk_ColumnAxisElementBuilder.IsChecked == true || chk_RowAxisElementBuilder.IsChecked == true)
                chk_SubsetFilter.IsEnabled = true;
            else
                chk_SubsetFilter.IsEnabled = false;
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            (this.DataContext as ConfigurationViewModel).Dispose();

            if (this.olapClient1 != null)
                this.olapClient1 = null;
          
            base.Dispose(disposing);
        }
    }
}
