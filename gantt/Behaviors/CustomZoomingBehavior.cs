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
   
    public class CustomZoomingBehavior : Behavior<GanttControl>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            AssociatedObject.ZoomChanged += new ZoomChangedEventHandler(AssociatedObject_ZoomChanged);
        }

        /// <summary>
        /// Handles the ZoomChanged event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Gantt.ZoomChangedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_ZoomChanged(object sender, ZoomChangedEventArgs args)
        {
            if (args.ZoomFactor == 100)
            {
                args.ScheduleHeaderInfo = new List<GanttScheduleRowInfo>
                {
                    new GanttScheduleRowInfo{ CellsPerUnit=1, TimeUnit= TimeUnit.Weeks },
                    new GanttScheduleRowInfo{CellsPerUnit=1,TimeUnit = TimeUnit.Days, PixelsPerUnit= 20}
                };
            }
            else if (args.ZoomFactor == 200)
            {
                args.ScheduleHeaderInfo = new List<GanttScheduleRowInfo>
                {
                    new GanttScheduleRowInfo{ CellsPerUnit=1, TimeUnit= TimeUnit.Days, CellTextFormat ="ddd d MMM" },
                    new GanttScheduleRowInfo{CellsPerUnit=12,TimeUnit = TimeUnit.Hours, PixelsPerUnit= 4, CellTextFormat="hh tt"}
                };
            }
            else if (args.ZoomFactor == 300)
            {
                args.ScheduleHeaderInfo = new List<GanttScheduleRowInfo>
                {
                    new GanttScheduleRowInfo{ CellsPerUnit=1, TimeUnit= TimeUnit.Days, CellTextFormat ="ddd d MMM"  },
                    new GanttScheduleRowInfo{CellsPerUnit=6,TimeUnit = TimeUnit.Hours, PixelsPerUnit= 8, CellTextFormat="hh tt"}
                };
            }
            else if (args.ZoomFactor == 400)
            {
                args.ScheduleHeaderInfo = new List<GanttScheduleRowInfo>
                {
                    new GanttScheduleRowInfo{ CellsPerUnit=1, TimeUnit= TimeUnit.Days, CellTextFormat ="ddd d MMM"  },
                    new GanttScheduleRowInfo{CellsPerUnit=1,TimeUnit = TimeUnit.Hours, PixelsPerUnit= 69, CellTextFormat="hh tt"}
                };
            }
            else if (args.ZoomFactor == 600)
            {
                args.ScheduleHeaderInfo = new List<GanttScheduleRowInfo>
                {
                    new GanttScheduleRowInfo{ CellsPerUnit=1, TimeUnit= TimeUnit.Hours, CellTextFormat="hh:mm tt" },
                    new GanttScheduleRowInfo{CellsPerUnit=15,TimeUnit = TimeUnit.Minutes, PixelsPerUnit= 2}
                };
            }
            else if (args.ZoomFactor == 800)
            {
                args.ScheduleHeaderInfo = new List<GanttScheduleRowInfo>
                {
                    new GanttScheduleRowInfo{ CellsPerUnit=1, TimeUnit= TimeUnit.Hours, CellTextFormat="hh:mm tt" },
                    new GanttScheduleRowInfo{CellsPerUnit=5,TimeUnit = TimeUnit.Minutes, PixelsPerUnit= 4}
                };
            }
            else if (args.ZoomFactor == 1000)
            {
                args.ScheduleHeaderInfo = new List<GanttScheduleRowInfo>
                {
                    new GanttScheduleRowInfo{ CellsPerUnit=1, TimeUnit= TimeUnit.Hours, CellTextFormat="hh:mm tt" },
                    new GanttScheduleRowInfo{CellsPerUnit=1,TimeUnit = TimeUnit.Minutes, PixelsPerUnit= 20}
                };
            }

            args.Handled = true;
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            AssociatedObject.ZoomChanged -= new ZoomChangedEventHandler(AssociatedObject_ZoomChanged);
        }
    }
}

