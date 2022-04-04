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
    public class NumericGridCustomizationBehavior : Behavior<GanttControl>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.ScheduleCellCreated += new ScheduleCellCreatedEventHandler(AssociatedObject_ScheduleCellCreated);
        }

        void AssociatedObject_ScheduleCellCreated(object sender, ScheduleCellCreatedEventArgs args)
        {
            args.CurrentCell.Foreground = new SolidColorBrush(Colors.Black);
        }

        /// <summary>
        /// Handles the Loaded event of the Gantt control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.GanttGrid.Loaded += new System.Windows.RoutedEventHandler(GanttGrid_Loaded);
            this.AssociatedObject.ScrollGanttChartTo(0);
        }

        /// <summary>
        /// Handles the Loaded event of the GanttGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void GanttGrid_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.GanttGrid.RequestNodeImage -= new GridTreeRequestNodeImageHandler(GanttGrid_RequestNodeImage);
            this.AssociatedObject.GanttGrid.RequestNodeImage += new GridTreeRequestNodeImageHandler(GanttGrid_RequestNodeImage);
            this.AssociatedObject.GanttGrid.SupportNodeImages = true;

            if (GetColumnIndex("Start") >= 0)
            {
                // Removing the Additional columns
                this.AssociatedObject.GanttGrid.InternalGrid.Columns.RemoveAt(GetColumnIndex("Start"));

                // Adding a new column Called Rank
                this.AssociatedObject.GanttGrid.InternalGrid.Columns.Add(new GridTreeColumn("Rank"));
                this.AssociatedObject.GanttGrid.Model.ColumnWidths[4] = 120;
                this.AssociatedObject.GanttGrid.InternalGrid.Columns[GetColumnIndex("Rank")].StyleInfo = new GridStyleInfo { HorizontalAlignment = System.Windows.HorizontalAlignment.Right, VerticalAlignment = System.Windows.VerticalAlignment.Center };
            }

            // Renaming the Existing columns
            this.AssociatedObject.GanttGrid.InternalGrid.Columns[GetColumnIndex("Name")].HeaderText = "Country Name";
            this.AssociatedObject.GanttGrid.Model.ColumnWidths[1] = 312;

            this.AssociatedObject.GanttGrid.InternalGrid.Columns[GetColumnIndex("End")].HeaderText = "GDP Growth";
            this.AssociatedObject.GanttGrid.Model.ColumnWidths[3] = 120;

            this.AssociatedObject.GanttGrid.InternalGrid.Columns[GetColumnIndex("End")].StyleInfo = new GridStyleInfo { CellType = "PercentEdit", PercentEditMode = Syncfusion.Windows.Shared.PercentEditMode.DoubleMode, HorizontalAlignment = System.Windows.HorizontalAlignment.Right, VerticalAlignment = System.Windows.VerticalAlignment.Center };


        }

        /// <summary>
        /// Gets the index of the column.
        /// </summary>
        /// <param name="colName">Name of the col.</param>
        /// <returns></returns>
        int GetColumnIndex(string colName)
        {
            return this.AssociatedObject.GanttGrid.InternalGrid.ColumnNameToPosition(colName);
        }

        /// <summary>
        /// Handles the RequestNodeImage event of the GanttGrid control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The <see cref="Syncfusion.Windows.Controls.Grid.GridTreeRequestNodeImageEventArgs"/> instance containing the event data.</param>
        void GanttGrid_RequestNodeImage(object sender, GridTreeRequestNodeImageEventArgs args)
        {
            string countryName = (args.Item as TopCountries).Name;
            args.NodeImage = this.GetBitMapImage(countryName);
        }

        /// <summary>
        /// Gets the bit map image of the given country name
        /// </summary>
        /// <param name="cntryName">Name of the cntry.</param>
        /// <returns></returns>
        BitmapImage GetBitMapImage(string cntryName)
        {
            try
            {
                return new BitmapImage((new Uri("pack://application:,,/Images/" + CustomNumericScheduleViewModel.CountryNamesandFlags[cntryName])));
            }
            catch (Exception)
            {
                return null;
            }
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.GanttGrid.Loaded -= new System.Windows.RoutedEventHandler(GanttGrid_Loaded);
            this.AssociatedObject.GanttGrid.RequestNodeImage -= new GridTreeRequestNodeImageHandler(GanttGrid_RequestNodeImage);
        }
    }
}
