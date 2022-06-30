#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.Windows.Controls.Gantt;
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
   
    public class ScheduleCellCreatedBehavior : Behavior<GanttControl>
    {
        /// <summary>
        /// Called after the behavior is attached to an GanttControl.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the GanttControl.</remarks>
        protected override void OnAttached()
        {
            this.AssociatedObject.ScheduleCellCreated += new ScheduleCellCreatedEventHandler(AssociatedObject_ScheduleCellCreated);
        }

        /// <summary>
        /// Handles the ScheduleCellCreated event of the GanttControl 
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Gantt.ScheduleCellCreatedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_ScheduleCellCreated(object sender, ScheduleCellCreatedEventArgs args)
        {
            DateTime currentDate = args.CurrentCell.CellDate;

            if (args.CurrentCell.CellTimeUnit == TimeUnit.Months)
            {
                args.CurrentCell.Foreground = new SolidColorBrush(Colors.White);
                // Quarter 1 dates contains months below 3. since we are cheking the cell dates and changing the Content of the cell.
                if (currentDate.Month <= 3)
                {
                    args.CurrentCell.Content = "Q 1";
                    args.CurrentCell.CellToolTip = "Quarter 1";
                    args.CurrentCell.Background = (Brush)new BrushConverter().ConvertFrom("#119EDA");
                }

                // Quarter 2 dates contains months between 4 - 6. since we are cheking the cell dates and changing the Content of the cell.
                else if (currentDate.Month > 3 && currentDate.Month <= 6)
                {
                    args.CurrentCell.Content = "Q 2";
                    args.CurrentCell.CellToolTip = "Quarter 2";
                    args.CurrentCell.Background = (Brush)new BrushConverter().ConvertFrom("#79B4F9");
                }

                // Quarter 3 dates contains months  between 6 - 9. since we are cheking the cell dates and changing the Content of the cell.
                else if (currentDate.Month > 6 && currentDate.Month <= 9)
                {
                    args.CurrentCell.Content = "Q 3";
                    args.CurrentCell.CellToolTip = "Quarter 3";
                    args.CurrentCell.Background = (Brush)new BrushConverter().ConvertFrom("#119EDA");
                }

                // Quarter 4 dates contains months below 9 - 12. since we are cheking the cell dates and changing the Content of the cell.
                else if (currentDate.Month > 9 && currentDate.Month <= 12)
                {
                    args.CurrentCell.Content = "Q 4";
                    args.CurrentCell.CellToolTip = "Quarter 4";
                    args.CurrentCell.Background = (Brush)new BrushConverter().ConvertFrom("#79B4F9");
                }
            }
        }

        /// <summary>
        /// Called when the behavior is being detached from its GanttControl, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the GanttControl.</remarks>
        protected override void OnDetaching()
        {
            this.AssociatedObject.ScheduleCellCreated -= new ScheduleCellCreatedEventHandler(AssociatedObject_ScheduleCellCreated);
        }
    }
}

