#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace VisualStyles
{
    using SampleUtils;
    using Syncfusion.SfSkinManager;
    using System;
    using System.Windows.Controls;

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
            this.InitializeComponent();
        }

        #endregion

        #region Event Handlers

        private void ThemeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ComboBox)
                SfSkinManager.SetVisualStyle(this.olapGauge1, (VisualStyles)Enum.Parse(typeof(VisualStyles), (sender as ComboBox).SelectedItem.ToString()));
        }

        #endregion
    }
}