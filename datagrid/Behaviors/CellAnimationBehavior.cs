#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.datagriddemos.wpf
{
    public class CellAnimationBehavior : Behavior<SfDataGrid>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            (this.AssociatedObject as SfDataGrid).RowGenerator = new CellAnimationCustomRowGenerator(this.AssociatedObject as SfDataGrid);
            (this.AssociatedObject as SfDataGrid).Loaded += OnLoaded;
            (this.AssociatedObject as SfDataGrid).Unloaded += OnUnloaded;
            base.OnAttached();
        }

        /// <summary>
        /// Occurs when the SfDataGrid is rendered and ready for interaction.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The RoutedEventArgs</param>
        private void OnLoaded(object sender, System.Windows.RoutedEventArgs e)
        {
            (this.AssociatedObject.DataContext as CellAnimationViewModel).StartTimer();
        }

        /// <summary>
        /// Occurs when the SfDataGrid is removed from the element tree.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="e">The RoutedEventArgs</param>
        private void OnUnloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            (this.AssociatedObject.DataContext as CellAnimationViewModel).StopTimer();
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            (this.AssociatedObject as SfDataGrid).Loaded -= OnLoaded;
            (this.AssociatedObject as SfDataGrid).Unloaded -= OnUnloaded;
            base.OnDetaching();
        }
    }
}
