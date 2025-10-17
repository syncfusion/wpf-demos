using Microsoft.Xaml.Behaviors;
using Syncfusion.SfSkinManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.demoscommon.wpf
{
    public class ScrollToSelectedItemAction : Behavior<ListView>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
            this.AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
        }

        /// <summary>
        /// Occurs when the demolist is loaded
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            ScrollSelectedIntoView(sender);
        }

        /// <summary>
        /// Occurs when the selection of product demos changes
        /// </summary>
        void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ScrollSelectedIntoView(sender);
        }

        /// <summary>
        /// Scrolls the selected item into view for a ListView control if it exists.
        /// </summary>
        /// <param name="sender"></param>
        private void ScrollSelectedIntoView(object sender)
        {
            if (sender is ListView demolist && demolist.SelectedItem != null)
            {
                demolist.ScrollIntoView(demolist.SelectedItem);
            }
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            this.AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;

        }
    }
}