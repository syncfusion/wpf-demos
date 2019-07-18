#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace OLAPClientConfiguration
{
    using SampleUtils;

    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : SampleWindow
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            ViewModel.ViewModel.ConnectionString = GetConnectionString();
            InitializeComponent();
        }

        #endregion

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

    }
}