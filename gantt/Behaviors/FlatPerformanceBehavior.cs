#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class FlatPerformanceBehavior : Behavior<FlatPerformanceCheck>
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
            ObservableCollection<Product> DataCollection;

            var view = AssociatedObject.DataContext as FlatPerformanceCheckViewModel;
            DateTime t = DateTime.Now;
            DataCollection = view.GetData(view.NoOfItems);
            view.TimeTaken = Math.Round((DateTime.Now - t).TotalSeconds, 4).ToString() + "  Sec";

            view.ProductCollection = DataCollection;
            view.LoadedTime = Math.Round((DateTime.Now - t).TotalSeconds, 4).ToString() + "  Sec";
            AssociatedObject.gantt.GanttGrid.Columns[1].Width = 198;
            AssociatedObject.gantt.ItemsSourceChanged += new System.Windows.DependencyPropertyChangedEventHandler(gantt_ItemsSourceChanged);
        }

        /// <summary>
        /// Handles the ItemsSourceChanged event of the gantt control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        void gantt_ItemsSourceChanged(object sender, System.Windows.DependencyPropertyChangedEventArgs e)
        {
            AssociatedObject.gantt.GanttGrid.Columns[1].Width= 198;
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            AssociatedObject.gantt.ItemsSourceChanged -= new System.Windows.DependencyPropertyChangedEventHandler(gantt_ItemsSourceChanged);
        }
    }
}
