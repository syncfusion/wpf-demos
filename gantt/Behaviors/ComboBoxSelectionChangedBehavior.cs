using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            this.AssociatedObject.metroStyleComboBox.SelectionChanged += this.OnMetroStyleComboBoxSelectionChanged;
            this.AssociatedObject.metroStyleComboBox.SelectedIndex = 3;
        }

        private void OnMetroStyleComboBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            GanttControl gantt = AssociatedObject.Gantt;
            MetroStyleColor Color = (e.AddedItems[0] as MetroStyleColor);
            if (gantt != null)
            {
                if (gantt.GanttGrid != null)
                {
                    gantt.GanttGrid.SelectionBackground = Color.Brush;
                }
            }
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.Gantt.Loaded -= Gantt_Loaded;
            this.AssociatedObject.metroStyleComboBox.SelectionChanged -= this.OnMetroStyleComboBoxSelectionChanged;
        }
    }
}
