#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.Windows.Controls.Gantt;
using Syncfusion.Windows.Controls.Grid;
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
     public class CustomizedTableBehavior : Behavior<GanttControl>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
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
            /// Removing Resource Column from the Grid(Table)
            for (int i = 0; i < this.AssociatedObject.GanttGrid.Columns.Count; i++)
            {
                if (this.AssociatedObject.GanttGrid.Columns[i].MappingName == "Resource")
                {
                    /// Removing Resource Column from the Grid(Table)
                    this.AssociatedObject.GanttGrid.Columns.RemoveAt(i);
                }
            }

            /// Fetching the Progress Column from the Grid(Table)
            GridTreeColumn progColumn = this.AssociatedObject.GanttGrid.Columns[5];
            /// Changing the cell type of progress Column
            progColumn.StyleInfo = new GridStyleInfo
            {
                CellType = "UpDownEdit",
                UpDownEdit = new GridUpDownEditStyleInfo { MaxValue = 100, MinValue = 0, Step = 5 }
            };

            /// Removing and reinserting the progress column in possition 2
            this.AssociatedObject.GanttGrid.Columns.Remove(progColumn);
            this.AssociatedObject.GanttGrid.Columns.Insert(2, progColumn);

            /// Creating a new custom column of Risk percentage
            GridTreeColumn column = new GridTreeColumn
            {
                MappingName = "RiskPercentage",
                HeaderText = "Risk",
                Width = 100,
                StyleInfo = new GridStyleInfo
                {
                    CellType = "DataBoundTemplate",
                    CellItemTemplateKey = "RiskCell"
                }
            };
            /// Inserting the custom columns to GanttGrid(Table)
            this.AssociatedObject.GanttGrid.Columns.Insert(2, column);

            /// Creating a new custom column of IsCompleted
            GridTreeColumn column1 = new GridTreeColumn
            {
                MappingName = "IsComplted",
                HeaderText = "IsCompleted",
                Width = 40,
                StyleInfo = new GridStyleInfo
                {
                    CellType = "CheckBox",
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                }
            };
            /// Inserting the custom columns to GanttGrid(Table)
            this.AssociatedObject.GanttGrid.Columns.Insert(2, column1);

            this.AssociatedObject.GanttGrid.RequestNodeImage += new GridTreeRequestNodeImageHandler(GanttGrid_RequestNodeImage);
            this.AssociatedObject.GanttGrid.SupportNodeImages = true;
        }

        /// <summary>
        /// Handles the RequestNodeImage event of the GanttGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Grid.GridTreeRequestNodeImageEventArgs"/> instance containing the event data.</param>
        void GanttGrid_RequestNodeImage(object sender, Syncfusion.Windows.Controls.Grid.GridTreeRequestNodeImageEventArgs args)
        {
            CustomizedTableModel task = args.Item as CustomizedTableModel;

            if (task == null || task.Resource.Count <= 0)
                return;

            args.NodeImage = new BitmapImage(new Uri(@"pack://application:,,,/syncfusion.ganttdemos.wpf;component/Images/Resource.png"));
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.GanttGrid.RequestNodeImage -= new Syncfusion.Windows.Controls.Grid.GridTreeRequestNodeImageHandler(GanttGrid_RequestNodeImage);
        }
    }
}
