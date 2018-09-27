using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;
using Syncfusion.UI.Xaml.Grid.Helpers;
using Syncfusion.UI.Xaml.ScrollAxis;

namespace FilterRow
{
    public class DataGridBehaviour : Behavior<SfDataGrid>
    {
        /// <summary>
        /// Called when behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += OnAssociatedObjectLoaded;
        }

        /// <summary>
        /// Called when the AssociatedObject is loaded.
        /// </summary>
        /// <param name="sender">The Associated object.</param>
        /// <param name="e">The event args.</param>
        void OnAssociatedObjectLoaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.MoveCurrentCell(new RowColumnIndex(this.AssociatedObject.GetFilterRowIndex(), this.AssociatedObject.GetFirstColumnIndex()));
            this.AssociatedObject.SelectionController.CurrentCellManager.BeginEdit();
        }

        /// <summary>
        /// Called when the behavior has been detached from the AssociatedObject.
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= OnAssociatedObjectLoaded;
        }
    }
    
}
