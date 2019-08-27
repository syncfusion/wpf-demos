#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Composite.Presentation.Regions;
using Microsoft.Practices.Composite.Presentation.Regions.Behaviors;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;
using System.Windows.Data;
using System.Collections.Specialized;
using System.Windows.Controls;
using Microsoft.Practices.Composite.Regions;
using System.Collections.ObjectModel;

namespace Syncfusion.Composite.WPF
{
    /// <summary>
    /// Ribbon sync behavior that helps to activate and de-activate the view.
    /// </summary>
    public class RibbonSyncBehavior : RegionBehavior, IHostAwareRegionBehavior
    {
        /// <summary>
        /// Name that identifies the SelectorItemsSourceSyncBehavior behavior in a collection of RegionsBehaviors. 
        /// </summary>
        public static readonly string BehaviorKey = "RibbonSyncBehavior";
        private Ribbon hostControl;

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
                this.hostControl = value as Ribbon;
            }
        }

        /// <summary>
        /// Starts to monitor the <see cref="IRegion"/> to keep it in synch with the items of the <see cref="HostControl"/>.
        /// </summary>
        protected override void OnAttach()
        {
            this.Region.ActiveViews.CollectionChanged += this.ActiveViews_CollectionChanged;
        }


        /// <summary>
        /// Handles the CollectionChanged event of the ActiveViews control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        private void ActiveViews_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            foreach (object view in this.Region.ActiveViews)
            {
                (view as RibbonTab).IsChecked = true;
            }

        }
    }
}
