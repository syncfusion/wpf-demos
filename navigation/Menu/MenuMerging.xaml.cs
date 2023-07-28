#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.SfSkinManager;
using System;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for MenuMerging.xaml
    /// </summary>
    public partial class MenuMerging
    {
        public MenuMerging()
        {
            InitializeComponent();
            this.Unloaded += MenuMerging_Unloaded;
        }

        public MenuMerging(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
        }

        private void MenuMerging_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.menuGrid != null)
            {
                this.menuGrid.Children.Clear();
                this.menuGrid = null;
            }

            if (this.DataContext != null)
            {
                this.DataContext = null;
            }
            
            this.Unloaded -= MenuMerging_Unloaded;
        }
    }
}
