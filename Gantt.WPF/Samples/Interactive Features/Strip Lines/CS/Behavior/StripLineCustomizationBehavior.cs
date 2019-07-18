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
using Syncfusion.Windows.Controls.Gantt;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace GanttStripLine
{
    public class StripLineCustomizationBehavior: Behavior<GanttControl>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.StripLineCreated += new StriplineCreatedEventHandler(AssociatedObject_StripLineCreated);
        }

        /// <summary>
        /// Handles the StripLineCreated event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Gantt.StriplineCreatedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_StripLineCreated(object sender, StriplineCreatedEventArgs args)
        {
            if (args.CurrentStripline.StartDate == new DateTime(2012, 12, 10))
            {
                args.CurrentStripline.Content = "Product Development is Completed";
                args.CurrentStripline.ContentTemplate = Application.Current.Resources["customTemplate"] as DataTemplate;
                args.CurrentStripline.Background = Brushes.LawnGreen;
                args.Handled = true;
            }
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.StripLineCreated -= new StriplineCreatedEventHandler(AssociatedObject_StripLineCreated);
        }
    }
}
