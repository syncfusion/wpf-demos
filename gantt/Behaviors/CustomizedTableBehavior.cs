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
using System.Windows.Media.Imaging;

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
            AssociatedObject.Loaded += new RoutedEventHandler(AssociatedObject_Loaded);
        }

        /// <summary>
        /// Handles the Loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            /// Removing resource column from the grid(Table).
            for (int i = 0; i < this.AssociatedObject.GanttGrid.Columns.Count; i++)
            {
                if (this.AssociatedObject.GanttGrid.Columns[i].MappingName == "Complete")
                {
                    /// Fetching the progress column from the grid(Table).
                    TreeGridColumn progColumn = this.AssociatedObject.GanttGrid.Columns[5];

                    /// Removing and reinserting the progress column in position 2.
                    this.AssociatedObject.GanttGrid.Columns.Remove(progColumn);
                    this.AssociatedObject.GanttGrid.Columns.Insert(2, progColumn);
                }

                if (this.AssociatedObject.GanttGrid.Columns[i].MappingName == "Name")
                {
                    TreeGridColumn taskNameColumn = this.AssociatedObject.GanttGrid.Columns[1];

                    this.AssociatedObject.GanttGrid.Columns.Remove(taskNameColumn);

                    /// Method to create task name with image column.
                    this.CreateNameWithImageColumn();
                }

                if (this.AssociatedObject.GanttGrid.Columns[i].MappingName == "Resource")
                {
                    /// Removing Resource Column from the Grid(Table)
                    this.AssociatedObject.GanttGrid.Columns.RemoveAt(i);
                }
            }

            /// Creating a new custom column of Risk.
            this.AddRiskColumn();

            /// Creating a new custom column of IsCompleted.
            this.AddCompletedColumn();

        }

        /// <summary>
        /// Method to add risk column.
        /// </summary>
        private void AddRiskColumn()
        {
            TreeGridTemplateColumn column = new TreeGridTemplateColumn();
            column.MappingName = "RiskPercentage";
            column.HeaderText = "Risk";

            // Create risk data template.
            DataTemplate riskTemplate = new DataTemplate();

            FrameworkElementFactory textBoxFactory = new FrameworkElementFactory(typeof(TextBlock));
            textBoxFactory.SetValue(TextBlock.FontSizeProperty, 13.0);

            // Bind the foreground property.
            var foregroundBinding = new Binding("RiskPercentage")
            {
                Converter = new ColorConverter(),
            };

            textBoxFactory.SetBinding(TextBlock.ForegroundProperty, foregroundBinding);

            // Bind the text property.
            Binding textBinding = new Binding() { Path = new PropertyPath("RiskPercentage"), Mode = BindingMode.TwoWay };
            textBoxFactory.SetBinding(TextBlock.TextProperty, textBinding);
            textBoxFactory.SetValue(TextBlock.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            textBoxFactory.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);

            riskTemplate.VisualTree = textBoxFactory;
            column.CellTemplate = riskTemplate;

            /// Inserting the custom columns to gantt grid(Table).
            this.AssociatedObject.GanttGrid.Columns.Insert(2, column);
        }

        /// <summary>
        /// Method to add completed column.
        /// </summary>
        private void AddCompletedColumn()
        {
            TreeGridCheckBoxColumn column = new TreeGridCheckBoxColumn();
            column.MappingName = "IsComplted";
            column.HeaderText = "IsCompleted";
            column.Width = 100;
            column.HorizontalAlignment = HorizontalAlignment.Center;
            column.VerticalAlignment = VerticalAlignment.Center;

            /// Inserting the custom columns to GanttGrid(Table)
            this.AssociatedObject.GanttGrid.Columns.Insert(2, column);
        }

        /// <summary>
        /// Method to create task name column.
        /// </summary>
        private void CreateNameWithImageColumn()
        {
            TreeGridTemplateColumn taskNameColumn = new TreeGridTemplateColumn();
            taskNameColumn.MappingName = "Name";
            taskNameColumn.HeaderText = "TaskName";
            taskNameColumn.Width = 200;
            /// Create cell template.
            DataTemplate cellTemplate = this.CreateCellTemplate();

            /// Create edit template.
            DataTemplate editTemplate = this.CreateEditTemplate();

            /// Set template value for name with image column.
            taskNameColumn.CellTemplate = cellTemplate;
            taskNameColumn.EditTemplate = editTemplate;

            /// Inserting the custom columns to GanttGrid(Table)
            this.AssociatedObject.GanttGrid.Columns.Insert(1, taskNameColumn);
        }

        /// <summary>
        /// Method to create cell template for task name column.
        /// </summary>
        private DataTemplate CreateCellTemplate()
        {
            DataTemplate cellTemplate = new DataTemplate();
            var stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            stackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

            //// Create image.
            FrameworkElementFactory imageFactory = new FrameworkElementFactory(typeof(Image));
            var imageUri = new Uri("pack://application:,,,/syncfusion.ganttdemos.wpf;component/Images/Resource.png", UriKind.Absolute);
            var bitmapImage = new BitmapImage(imageUri);
            imageFactory.SetValue(Image.SourceProperty, bitmapImage);
            imageFactory.SetValue(Image.VisibilityProperty, Visibility.Collapsed);
            imageFactory.AddHandler(Image.LoadedEvent, new RoutedEventHandler((sender, e) => this.OnImageLoaded(sender, e)));
            stackPanelFactory.AppendChild(imageFactory);

            //// Create text block.
            FrameworkElementFactory textBlockFactory = new FrameworkElementFactory(typeof(TextBlock));

            // Bind the text property.
            Binding displayBinding = new Binding() { Path = new PropertyPath("Name") };
            textBlockFactory.SetValue(TextBlock.TextProperty, displayBinding);
            textBlockFactory.SetValue(TextBlock.VerticalAlignmentProperty, VerticalAlignment.Center);
            textBlockFactory.SetValue(TextBlock.PaddingProperty, new Thickness(3, 0, 0, 0));
            stackPanelFactory.AppendChild(textBlockFactory);

            cellTemplate.VisualTree = stackPanelFactory;
            return cellTemplate;
        }

        /// <summary>
        /// Method to create task name edit template.
        /// </summary>
        private DataTemplate CreateEditTemplate()
        {
            DataTemplate editTemplate = new DataTemplate();
            var stackPanelFactory = new FrameworkElementFactory(typeof(StackPanel));
            stackPanelFactory.SetValue(StackPanel.OrientationProperty, Orientation.Horizontal);

            //// Create image.
            FrameworkElementFactory imageFactory = new FrameworkElementFactory(typeof(Image));
            var imageUri = new Uri("pack://application:,,,/syncfusion.ganttdemos.wpf;component/Images/Resource.png", UriKind.Absolute);
            var bitmapImage = new BitmapImage(imageUri);
            imageFactory.SetValue(Image.SourceProperty, bitmapImage);
            imageFactory.SetValue(Image.VisibilityProperty, Visibility.Collapsed);
            imageFactory.AddHandler(Image.LoadedEvent, new RoutedEventHandler((sender, e) => this.OnImageLoaded(sender, e)));
            stackPanelFactory.AppendChild(imageFactory);

            //// Create text block.
            FrameworkElementFactory textBoxFactory = new FrameworkElementFactory(typeof(TextBox));

            // Bind the text property.
            Binding editBinding = new Binding() { Path = new PropertyPath("Name"), Mode = BindingMode.TwoWay };
            textBoxFactory.SetValue(TextBox.TextProperty, editBinding);
            stackPanelFactory.AppendChild(textBoxFactory);
            editTemplate.VisualTree = stackPanelFactory;
            return editTemplate;
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

            var taskInfo = image.DataContext as CustomizedTableModel;
            var resource = taskInfo.Resource;
            if (resource != null && resource.Count > 0)
            {
                image.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }
    }
}
