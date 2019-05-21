#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows.Controls;
using Syncfusion.Windows.Shared;

namespace DataPagingDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OrientationComboBox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (comboBox.SelectedIndex == 0)
            {
                sfDataPager.Height = 60;
                sfDataPager.Margin = new System.Windows.Thickness();
            }
            else
            {
                sfDataPager.Height = 580;
                sfDataPager.Margin = new System.Windows.Thickness(30, -20, 0, 0);
            }
        }
    }
}
