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
    public class ExportToImageGridCustomizationBehavior : Behavior<GanttControl>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.TemplateApplied += new TemplateAppliedEventHandler(AssociatedObject_TemplateApplied);
        }

        void AssociatedObject_TemplateApplied(object sender, TemplateAppliedEventArgs args)
        {
            this.AssociatedObject.GanttGrid.ReadOnly = true;

            // Customizing the header text of the Grid.
            this.AssociatedObject.GanttGrid.Columns[0].HeaderText = "Resource Name";
            this.AssociatedObject.GanttGrid.Columns[1].HeaderText = "Start Date";
            this.AssociatedObject.GanttGrid.Columns[2].HeaderText = "Finish Date";
            this.AssociatedObject.ScrollGanttChartTo(new DateTime(2012, 01, 06));
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.TemplateApplied -= new TemplateAppliedEventHandler(AssociatedObject_TemplateApplied);
        }
    }
}