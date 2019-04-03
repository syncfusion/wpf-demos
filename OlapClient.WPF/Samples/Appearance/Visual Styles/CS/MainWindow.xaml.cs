#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace Visual_Styles
{
    using System;
    using System.Windows;
    using SampleUtils;
    using Syncfusion.SfSkinManager;
    using System.Windows.Controls;
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class MainWindow : SampleWindow
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="Window1"/> class.
        /// </summary>
        public MainWindow()
        {
            try
            {
                ViewModel.ViewModel.ConnectionString = GetConnectionString();
            InitializeComponent();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Data will not be loaded properly");
            }
        }

        private void ThemeSelectionBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            SfSkinManager.SetVisualStyle(this, (Syncfusion.SfSkinManager.VisualStyles)Enum.Parse(typeof(Syncfusion.SfSkinManager.VisualStyles), (sender as ComboBox).SelectedItem.ToString()));
        }

        #endregion        
    }
}
