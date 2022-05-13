#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.ganttdemos.wpf
{
    using Microsoft.Xaml.Behaviors;
    using Syncfusion.Windows.Controls.Gantt;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Controls;

    public class CalenderCustomizationBehavior : Behavior<CalendarCustomization>
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
            AssociatedObject.weekendsComboBox.SelectedItems.Add(Days.Saturday);
            AssociatedObject.weekendsComboBox.SelectedItems.Add(Days.Sunday);
            AssociatedObject.weekendsComboBox.SelectionChanged += WeekendsComboBox_SelectionChanged;
        }

        private void WeekendsComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ListBox list = sender as ListBox;
            List<Days> days = new List<Days>();
            var value = list.SelectedItems.Cast<Days>();
            if (list.SelectedItems.Count > 0)
            {
                for (int j = 0; j < list.SelectedItems.Count; j++)
                {
                    days.Add(value.ElementAt(j));
                }
            }

            if (days.Count > 0)
            {
                AssociatedObject.Gantt.Weekends = days.Aggregate((i, t) => i | t);
            }
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.weekendsComboBox.SelectionChanged -= WeekendsComboBox_SelectionChanged;
        }
    }
}
