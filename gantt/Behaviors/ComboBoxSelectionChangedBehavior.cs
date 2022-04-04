#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using Syncfusion.Windows.Controls.Gantt;
using System.Windows;
using Microsoft.Xaml.Behaviors;
using System.Windows.Media;

namespace syncfusion.ganttdemos.wpf
{

    public class ComboBoxSelectionChangedBehavior : Behavior<CustomMetroStyle>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        /// <summary>
        /// Handles the Loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            AssociatedObject.Gantt.Loaded += Gantt_Loaded;
        }

        private void Gantt_Loaded(object sender, RoutedEventArgs e)
        {
            AssociatedObject.metroStyleComboBox.SelectionChanged += MetroStyleComboBox_SelectionChanged;
            AssociatedObject.metroStyleComboBox.SelectedIndex = 3;
        }

        private void MetroStyleComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           GanttControl gantt = AssociatedObject.Gantt;
            MetroStyleColor Color = (e.AddedItems[0] as MetroStyleColor);
            if (gantt != null)
            {
                if (gantt.GanttGrid != null)
                {
                    gantt.GanttGrid.Model.Options.HighlightSelectionBackground = Color.Brush;
                    gantt.GanttGrid.InternalGrid.InvalidateCell(gantt.GanttGrid.Model.SelectedCells);
                }
            }
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            AssociatedObject.Gantt.Loaded -= Gantt_Loaded;
            AssociatedObject.metroStyleComboBox.SelectionChanged -= MetroStyleComboBox_SelectionChanged;
        }
    }
}
