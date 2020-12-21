#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.patientmonitor.wpf
{
    public class DataGridSelectionChangedBehavior : Behavior<PatientMonitorDemo>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += PatientMonitorWindow_Loaded;
            base.OnAttached();
        }

        private void PatientMonitorWindow_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.sfDataGrid.SelectionChanged += DataGrid_SelectionChanged;
        }

        private void DataGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
        {
            if (this.AssociatedObject.currentDetailsDemo != null && this.AssociatedObject.currentDetailsDemo.chartGrid != null
                && this.AssociatedObject.currentDetailsDemo.chartGrid.DataContext != null)
            {
                (this.AssociatedObject.currentDetailsDemo.chartGrid.DataContext as CurrentDetailsViewModel).SwapDataContext();
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= PatientMonitorWindow_Loaded;
            this.AssociatedObject.sfDataGrid.SelectionChanged -= DataGrid_SelectionChanged;
            base.OnDetaching();
        }
    }
}
