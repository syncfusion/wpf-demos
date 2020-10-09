#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Interactivity;
using Syncfusion.UI.Xaml.TreeGrid;

namespace FilteringDemo
{
    public class TreeGridBehavior : Behavior<SfTreeGrid>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            (this.AssociatedObject as SfTreeGrid).Loaded += OnLoaded;
            base.OnAttached();
        }

        /// <summary>
        /// Occurs when the SfDataGrid is rendered and ready for interaction.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The RoutedEventArgs</param>
        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var viewModel = this.AssociatedObject.DataContext as EmployeeRepository;
            viewModel.filterChanged = OnFilterChanged;
        }

        /// <summary>
        /// Occurs when Filter changed.
        /// </summary>
        private void OnFilterChanged()
        {
            var treeGrid = this.AssociatedObject as SfTreeGrid;
            var viewModel = this.AssociatedObject.DataContext as EmployeeRepository;
            if (treeGrid.View != null)
            {
                treeGrid.View.Filter = viewModel.FilerRecords;
                treeGrid.View.RefreshFilter();
            }
        }


        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            (this.AssociatedObject as SfTreeGrid).Loaded -= OnLoaded;
            base.OnDetaching();
        }
    }
}
