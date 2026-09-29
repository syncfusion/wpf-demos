using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace syncfusion.treegriddemos.wpf
{
    /// <summary>
    /// A behavior that connects keyboard actions to the search panel when it is shown or hidden.
    /// </summary>
    public class TreeGridSearchDemoBehavior : Behavior<SearchPanelDemo>
    {
        SfTreeGrid treeGrid;
        TreeGridSearchControl searchControl;

        /// <summary>
        /// Called when the behavior is attached and starts listening for key events on the tree grid.
        /// </summary>
        protected override void OnAttached()
        {
            var window = this.AssociatedObject;
            this.treeGrid = window.FindName("treeGrid") as SfTreeGrid;
            this.treeGrid.KeyDown += OnTreeGridKeyDown;
            this.searchControl = window.FindName("searchControl") as TreeGridSearchControl;
        }

        /// <summary>
        /// Handles key presses on the tree grid to show the search panel for the open shortcut and hide it for the close key.
        /// </summary>
        private void OnTreeGridKeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.F) && (e.KeyboardDevice.Modifiers & ModifierKeys.Control) != ModifierKeys.None)
                searchControl?.UpdateSearchControlVisibility(true);
            else if (e.Key == Key.Escape)
                searchControl?.UpdateSearchControlVisibility(false);
        }

        /// <summary>
        /// Called when the behavior is detached and stops listening for key events.
        /// </summary>
        protected override void OnDetaching()
        {
            this.treeGrid.KeyDown -= OnTreeGridKeyDown;
        }
    }
}
