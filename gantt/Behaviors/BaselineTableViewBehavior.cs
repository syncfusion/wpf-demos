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

    public class BaselineTableViewBehavior : Behavior<BaselineTableView>
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
            AssociatedObject.VarienceViewButton.Click += VarienceViewButton_Click;
            AssociatedObject.DefaultViewButton.Click += DefaultViewButton_Click;
        }

        private void DefaultViewButton_Click(object sender, RoutedEventArgs e)
        {
            AssociatedObject.Gantt.LoadDefaultTableView();
        }

        private void VarienceViewButton_Click(object sender, RoutedEventArgs e)
        {
            AssociatedObject.Gantt.LoadVarianceTableView();
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            AssociatedObject.Gantt.Loaded -= Gantt_Loaded;
            AssociatedObject.VarienceViewButton.Click -= VarienceViewButton_Click;
            AssociatedObject.DefaultViewButton.Click -= DefaultViewButton_Click;
        }
    }
}
