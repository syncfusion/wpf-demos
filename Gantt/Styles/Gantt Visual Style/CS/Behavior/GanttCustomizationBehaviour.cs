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
using System.Windows.Interactivity;
using System.Windows.Controls;
using Syncfusion.Windows.Controls.Gantt;

namespace GanttVisualStyle
{
    class GanttCustomizationBehaviour: Behavior<MainWindow>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        /// <summary>
        /// Handles the Loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.Gantt.Loaded += new System.Windows.RoutedEventHandler(Gantt_Loaded);
        }

        /// <summary>
        /// Handles the Loaded event of the Gantt control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void Gantt_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.visualCB.ItemsSource = Enum.GetValues(typeof(VisualStyle)).Cast<VisualStyle>();
            this.AssociatedObject.visualCB.SelectionChanged += new SelectionChangedEventHandler(visualCB_SelectionChanged);
        }

        /// <summary>
        /// Handles the SelectionChanged event of the visualCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        void visualCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.AssociatedObject.Gantt.VisualStyle =(VisualStyle)e.AddedItems[0]; 
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.Gantt.Loaded -= new System.Windows.RoutedEventHandler(Gantt_Loaded);
            this.AssociatedObject.visualCB.SelectionChanged -= new SelectionChangedEventHandler(visualCB_SelectionChanged);
        }
    }
}
