#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using System;
using System.Windows;
using System.Windows.Controls;

namespace SfTreeNavigator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            SfSkinManager.SetVisualStyle(this, VisualStyles.Office2016Colorful);
            InitializeComponent();
            (this.DataContext as TreeViewModel).SelectedItem = tree.Items[4];
        }

        void _Loaded(object sender, RoutedEventArgs e)
        {
            navigation.Items.Add(Syncfusion.Windows.Controls.Navigation.NavigationMode.Default);
            navigation.Items.Add(Syncfusion.Windows.Controls.Navigation.NavigationMode.Extended);
            navigation.SelectedIndex = 1;
            navigation.SelectionChanged -= navigation_SelectionChanged;
            navigation.SelectionChanged += navigation_SelectionChanged;
        }

        void navigation_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            (this.DataContext as TreeViewModel).Navigationmode = (Syncfusion.Windows.Controls.Navigation.NavigationMode)navigation.SelectedItem;
        }

    }
}
