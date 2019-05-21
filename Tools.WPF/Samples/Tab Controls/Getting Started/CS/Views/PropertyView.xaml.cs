#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows.Controls;
using System.Windows;

namespace TabControlExtConfigurationDemo
{
    /// <summary>
    /// Interaction logic for PropertyView.xaml
    /// </summary>
    public partial class PropertyView : UserControl
    {
        public PropertyView()
        {
            InitializeComponent();            
        }
        private void SelectionChange(object sender,SelectionChangedEventArgs e)
        {
            if (Combo.SelectedItem != null)
            {
                if (Combo.SelectedItem.ToString() == "Top" || Combo.SelectedItem.ToString() == "Bottom")
                {
                    Check.Visibility = Visibility.Collapsed;
                    Text.Visibility = Visibility.Collapsed;
                }
                else
                {
                    Check.Visibility = Visibility.Visible;
                    Text.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
