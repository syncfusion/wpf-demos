#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xaml.Behaviors;

namespace syncfusion.treegriddemos.wpf
{
    public class SfTreeGridBehavior : Behavior<SfTreeGrid>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
            this.AssociatedObject.CurrentCellRequestNavigate += TreeGrid_CurrentCellRequestNavigate;
        }

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = this.AssociatedObject.DataContext as EmployeeInfoViewModel;
            if(viewModel != null)
                viewModel.filterChanged = OnFilterChanged;
        }

        /// <summary>
        /// Occurs when Filter changed.
        /// </summary>
        private void OnFilterChanged()
        {
            var treeGrid = this.AssociatedObject as SfTreeGrid;
            var viewModel = this.AssociatedObject.DataContext as EmployeeInfoViewModel;
            if (treeGrid.View != null)
            {
                treeGrid.View.Filter = viewModel.FilerRecords;
                treeGrid.View.RefreshFilter();
            }
        }

        private void TreeGrid_CurrentCellRequestNavigate(object sender, Syncfusion.UI.Xaml.Grid.CurrentCellRequestNavigateEventArgs args)
        {
            string address = "https://en.wikipedia.org/wiki/" + args.NavigateText;
            Process.Start(new ProcessStartInfo(address));
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            this.AssociatedObject.CurrentCellRequestNavigate -= TreeGrid_CurrentCellRequestNavigate;
        }
    }
}
