#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.ganttdemos.wpf
{
    class CurrentDateLineStyleChangeBehavior : Behavior<GanttStyleProperties>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new RoutedEventHandler(AssociatedObject_Loaded);
        }

        /// <summary>
        /// Handles the Loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleCollection strokeArray;
            strokeArray = new DoubleCollection();
            strokeArray.Add(15);
            strokeArray.Add(15);
            AssociatedObject.Gantt.CurrentDateLine.StrokeDashArray = strokeArray;
            AssociatedObject.Gantt.CurrentDateLine.Stroke = Brushes.Red;
            this.AssociatedObject.CurrentDateLineCB.SelectionChanged += new SelectionChangedEventHandler(CurrentDateLineCB_SelectionChanged);
        }

        /// <summary>
        /// Handles the SelectionChanged event of the CurrentDateLineCB control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Controls.SelectionChangedEventArgs"/> instance containing the event data.</param>
        void CurrentDateLineCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBoxItem item = e.AddedItems[0] as ComboBoxItem;
            DoubleCollection strokeArray;
            switch (item.Content.ToString())
            {
                case "Default":
                    AssociatedObject.Gantt.CurrentDateLine.StrokeDashArray = null;
                    AssociatedObject.Gantt.CurrentDateLine.Stroke = Brushes.Orange;
                    break;
                case "Dashed Lines":
                    strokeArray = new DoubleCollection();
                    strokeArray.Add(15);
                    strokeArray.Add(15);
                    AssociatedObject.Gantt.CurrentDateLine.StrokeDashArray = strokeArray;
                    AssociatedObject.Gantt.CurrentDateLine.Stroke = Brushes.Red;
                    break;
                case "Dotted Lines":
                    strokeArray = new DoubleCollection();
                    strokeArray.Add(5);
                    strokeArray.Add(5);
                    AssociatedObject.Gantt.CurrentDateLine.StrokeDashArray = strokeArray;
                    AssociatedObject.Gantt.CurrentDateLine.Stroke = Brushes.Red;
                    break;
                case "Dashed With Dotted Lines":
                    strokeArray = new DoubleCollection();
                    strokeArray.Add(5);
                    strokeArray.Add(1);
                    strokeArray.Add(5);
                    AssociatedObject.Gantt.CurrentDateLine.StrokeDashArray = strokeArray;
                    AssociatedObject.Gantt.CurrentDateLine.Stroke = Brushes.DarkGreen;
                    AssociatedObject.Gantt.CurrentDateLine.StrokeThickness = 1;
                    break;
            }
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.CurrentDateLineCB.SelectionChanged -= new SelectionChangedEventHandler(CurrentDateLineCB_SelectionChanged);
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }
    }
}
