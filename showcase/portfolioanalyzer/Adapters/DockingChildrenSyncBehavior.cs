#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.Generic;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Presentation.Regions.Behaviors;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;
using System.Collections.Specialized;
using System.Windows.Controls;
using Microsoft.Practices.Composite.Regions;
using System.Collections.ObjectModel;

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    /// <summary>
    /// Docking sync behavior that helps to activate the dock windows based on view state.
    /// </summary>
    public class DockingChildrenSourceSyncBehavior : RegionBehavior, IHostAwareRegionBehavior
    {
        /// <summary>
        /// Name that identifies the SelectorItemsSourceSyncBehavior behavior in a collection of RegionsBehaviors. 
        /// </summary>
        public static readonly string BehaviorKey = "DockingChildrenSourceSyncBehavior";
        private DockingManager hostControl;
        ObservableCollection<object> newviews;

        /// <summary>
        /// Gets or sets the <see cref="DependencyObject"/> that the <see cref="IRegion"/> is attached to.
        /// </summary>
        /// <value>
        /// A <see cref="DependencyObject"/> that the <see cref="IRegion"/> is attached to.
        /// </value>
        /// <remarks>For this behavior, the host control must always be a <see cref="Selector"/> or an inherited class.</remarks>
        public DependencyObject HostControl
        {
            get
            {
                return this.hostControl;
            }
            set
            {
                this.hostControl = value as DockingManager;
            }
        }

        /// <summary>
        /// Starts to monitor the <see cref="IRegion"/> to keep it in synch with the items of the <see cref="HostControl"/>.
        /// </summary>
        protected override void OnAttach()
        {
            this.SynchronizeItems();
            this.Region.ActiveViews.CollectionChanged += this.ActiveViews_CollectionChanged;
            this.Region.Views.CollectionChanged += this.Views_CollectionChanged;
            newviews = new ObservableCollection<object>();
        }

        /// <summary>
        /// Handles the CollectionChanged event of the Views control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        private void Views_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (object newItem in e.NewItems)
                {
                    if (newItem is FrameworkElement && !this.hostControl.Children.Contains(newItem as FrameworkElement))
                    {
                        this.hostControl.Children.Add(newItem as FrameworkElement);
                    }
                }
            }
            else if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                foreach (object oldItem in e.OldItems)
                {
                    if (oldItem is FrameworkElement && this.hostControl.Children.Contains(oldItem as FrameworkElement))
                    {
                        this.hostControl.Children.Remove(oldItem as FrameworkElement);
                    }
                }
            }
        }

        /// <summary>
        /// Synchronizes the items.
        /// </summary>
        private void SynchronizeItems()
        {
            List<object> existingItems = new List<object>();

            foreach (object childItem in this.hostControl.Children)
            {
                existingItems.Add(childItem);
            }

            foreach (object view in this.Region.Views)
            {
                if (!this.hostControl.Children.Contains(view as FrameworkElement))
                    this.hostControl.Children.Add(view as FrameworkElement);
            }

            foreach (object existingItem in existingItems)
            {
                this.Region.Add(existingItem as FrameworkElement);
            }
        }

        /// <summary>
        /// Handles the CollectionChanged event of the ActiveViews control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            IViewsCollection newviews = this.Region.ActiveViews;
            foreach (object view in this.Region.Views)
            {
                (view as Control).SetValue(DockingManager.StateProperty, DockState.Hidden);

            }
            foreach (object view in this.Region.ActiveViews)
            {
                if ((view as Control).Tag == null)
                    (view as Control).Tag = DockState.Dock;
                (view as Control).SetValue(DockingManager.StateProperty, (view as Control).Tag);
            }
        }
    }
}
