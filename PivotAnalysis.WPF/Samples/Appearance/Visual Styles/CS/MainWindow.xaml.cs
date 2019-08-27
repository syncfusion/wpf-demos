#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace VisualStyles
{
    using System;
    using System.Windows;
    using System.Windows.Controls;
    using Syncfusion.SfSkinManager;

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ThemeBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SfSkinManager.SetVisualStyle(this.pivotGrid1, (VisualStyles)Enum.Parse(typeof(VisualStyles), (sender as ComboBox).SelectedItem.ToString()));
        }
    }
}