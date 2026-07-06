#region Copyright Syncfusion Inc. 2001 - 2026
// Copyright Syncfusion Inc. 2001 - 2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.treegriddemos.wpf
{
    /// <summary>
    /// Interaction logic for NestedPagingView.xaml
    /// </summary>
    public partial class NestedPagingView : Page
    {
        public NestedPagingView()
        {
            InitializeComponent();
            this.Unloaded += NestedPagingView_Unloaded;
        }

        private void NestedPagingView_Unloaded(object sender, RoutedEventArgs e)
        {
            if (this.treeGrid != null)
            {
                this.treeGrid.Dispose();
                this.treeGrid = null;
            }

            if (this.sfDataPager != null)
            {
                this.sfDataPager.Dispose();
                this.sfDataPager = null;
            }

            this.Unloaded -= NestedPagingView_Unloaded;
        }
    }
}