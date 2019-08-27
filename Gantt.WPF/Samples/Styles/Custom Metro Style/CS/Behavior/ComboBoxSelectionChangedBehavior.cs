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
using System.Windows;

namespace CustomMetroStyle
{
    class ComboBoxSelectionChangedBehavior: TargetedTriggerAction<GanttControl>
    {

        /// <summary>
        /// Gets or sets the target object.
        /// </summary>
        /// <value>The target object.</value>
        public object GanttTargetObject
        {
            get { return (object)GetValue(GanttTargetObjectProperty); }
            set { SetValue(GanttTargetObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TargetObject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty GanttTargetObjectProperty =
            DependencyProperty.Register("GanttTargetObject", typeof(object), typeof(ComboBoxSelectionChangedBehavior), new PropertyMetadata(null));

        
        /// <summary>
        /// Invokes the specified parameter.
        /// </summary>
        /// <param name="parameter">The parameter.</param>
        protected override void Invoke(object parameter)
        {
            var e = parameter as SelectionChangedEventArgs;
            MetroStyleColor Color = (e.AddedItems[0] as MetroStyleColor);
            GanttControl gantt = GanttTargetObject as GanttControl;
            if (gantt != null)
            {
                if (gantt.GanttGrid != null)
                {
                    gantt.GanttGrid.Model.Options.HighlightSelectionBackground = Color.Brush;
                    gantt.GanttGrid.InternalGrid.InvalidateCell(gantt.GanttGrid.Model.SelectedCells);
                }
            }
        }
    }
}
