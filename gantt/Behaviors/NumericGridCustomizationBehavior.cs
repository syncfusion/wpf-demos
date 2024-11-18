#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.TreeGrid;
using Syncfusion.Windows.Controls.Gantt;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

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
            if (GetColumnIndex("Start") >= 0)
            {
                // Removing the Additional columns
                this.AssociatedObject.GanttGrid.Columns.RemoveAt(GetColumnIndex("Start"));

                // Adding a new column Called Rank
                TreeGridColumn treeGridColumn = new TreeGridTextColumn();
                treeGridColumn.MappingName = "Rank";
                treeGridColumn.Width = 100;
                this.AssociatedObject.GanttGrid.Columns.Add(treeGridColumn);

                int columnIndex = GetColumnIndex("Rank");
                this.AssociatedObject.GanttGrid.Columns[columnIndex].TextAlignment = TextAlignment.Right;
                this.AssociatedObject.GanttGrid.Columns[columnIndex].VerticalAlignment = VerticalAlignment.Center;
            }

            //Remove and Add country column with image

            TreeGridTemplateColumn countryColumn = new TreeGridTemplateColumn();
            countryColumn.MappingName = "Name";
            countryColumn.HeaderText = "Country Name";
            countryColumn.Width = 200;

            DataTemplate countryNameTemplate;
            FrameworkElementFactory stackPanelFactory, imageFactory, textBoxFactory;
            this.CreateCellTemplate(out countryNameTemplate, out stackPanelFactory, out imageFactory, out textBoxFactory);

            stackPanelFactory.AppendChild(imageFactory);
            stackPanelFactory.AppendChild(textBoxFactory);
            countryColumn.CellTemplate = countryNameTemplate;

            this.AssociatedObject.GanttGrid.Columns.RemoveAt(1);
            this.AssociatedObject.GanttGrid.Columns.Insert(1, countryColumn);


            int index = GetColumnIndex("End");
            var treeGridPercentColumn = new TreeGridPercentColumn();
            treeGridPercentColumn.HeaderText = "GDP Growth";
            treeGridPercentColumn.MappingName = "End";
            treeGridPercentColumn.Width = 100;
            treeGridPercentColumn.AllowEditing = true;
            treeGridPercentColumn.PercentEditMode = Syncfusion.Windows.Shared.PercentEditMode.DoubleMode;
            treeGridPercentColumn.TextAlignment = TextAlignment.Right;
            treeGridPercentColumn.VerticalAlignment = VerticalAlignment.Center;

            this.AssociatedObject.GanttGrid.Columns[index] = treeGridPercentColumn;
        }

        /// <summary>
        /// Method to create cell template for country name column.
        /// </summary>
        /// <param name="countryNameTemplate">The date template.</param>
        /// <param name="stackPanelFactory">The stack panel.</param>
        /// <param name="imageFactory"></param>
        /// <param name="textBoxFactory"></param>
        private void CreateCellTemplate(out DataTemplate countryNameTemplate, out FrameworkElementFactory stackPanelFactory, out FrameworkElementFactory imageFactory, out FrameworkElementFactory textBoxFactory)
        {
            countryNameTemplate = new DataTemplate();
            stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            stackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

            //// Create image.
            imageFactory = new FrameworkElementFactory(typeof(Image));
            imageFactory.SetValue(Image.HorizontalAlignmentProperty, HorizontalAlignment.Left);
            imageFactory.AddHandler(Image.LoadedEvent, new RoutedEventHandler((sender, e) => this.OnImageLoaded(sender, e)));

            //// Create text block.
            textBoxFactory = new FrameworkElementFactory(typeof(TextBlock));

            // Bind the text property.
            Binding displayBinding = new Binding() { Path = new PropertyPath("Name") };
            textBoxFactory.SetValue(TextBlock.TextProperty, displayBinding);
            textBoxFactory.SetValue(TextBlock.PaddingProperty, new Thickness(3, 0, 0, 0));
            countryNameTemplate.VisualTree = stackPanelFactory;
        }

        /// <summary>
        /// Method to wire the image loaded event.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The event args.</param>
        private void OnImageLoaded(object sender, RoutedEventArgs e)
        {
            var image = sender as Image;
            if (image == null)
            {
                return;
            }

            var taskInfo = image.DataContext as TopCountries;
            var imageUri = new Uri("pack://application:,,/Images/" + CustomNumericScheduleViewModel.CountryNamesandFlags[taskInfo.Name]);
            //var bitmapImage = new BitmapImage(imageUri);
            //image.SetValue(Image.SourceProperty, bitmapImage);
        }

        /// <summary>
        /// Gets the index of the column.
        /// </summary>
        /// <param name="columnName">The column name.</param>
        /// <returns>The column index.</returns>
        int GetColumnIndex(string columnName)
        {
            foreach (TreeGridColumn column in this.AssociatedObject.GanttGrid.Columns)
            {
                if (column.MappingName == columnName)
                {
                    return this.AssociatedObject.GanttGrid.Columns.IndexOf(column);
                }
            }

            return -1;
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.GanttGrid.Loaded -= new RoutedEventHandler(GanttGrid_Loaded);
        }
    }
}