#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
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

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Class for representing the trigger for apply the filters to the datagrid and  refersh the filters once filter applied.
    /// </summary>
    public class DataGridFilterTrigger : TargetedTriggerAction<SfDataGrid>
    {
        protected override void Invoke(object parameter)
        {
            var viewModel = this.Target.DataContext as EmployeeInfoViewModel;
            viewModel.filterChanged += OnFilterChanged;
        }

        /// <summary>
        /// occurs when filter changed.
        /// </summary>
        private void OnFilterChanged()
        {
            var viewModel = this.Target.DataContext as EmployeeInfoViewModel;
            if (this.Target.View != null)
            {
                this.Target.View.Filter = viewModel.FilerRecords;
                this.Target.View.RefreshFilter();
            }
        }
    }
}
