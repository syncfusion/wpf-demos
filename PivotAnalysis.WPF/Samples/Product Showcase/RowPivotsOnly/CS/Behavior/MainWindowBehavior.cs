#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace RowPivotsOnly
{
    using System.Windows.Interactivity;
    using Syncfusion.Windows.Controls.PivotGrid;

    class MainWindowBehavior : Behavior<PivotGridControl>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to RowPivotsOnlyModelhook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {

            base.OnAttached();
            AssociatedObject.Loaded += (s, e) =>
                {
                    RowPivotsOnlyModel vm = this.AssociatedObject.DataContext as RowPivotsOnlyModel;
                    AssociatedObject.ItemSource = vm.Data;
                };
        }
    }
}