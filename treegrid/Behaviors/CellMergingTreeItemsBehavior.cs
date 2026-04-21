#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace syncfusion.treegriddemos.wpf
{
    public class CellMergingTreeItemsBehavior : Behavior<SfTreeGrid>
    {
        private EmployeeInfoViewModel viewModel;

        protected override void OnAttached()
        {
            base.OnAttached();
            this.viewModel = this.AssociatedObject.DataContext as EmployeeInfoViewModel;
            this.AssociatedObject.RequestTreeItems += AssociatedObject_RequestTreeItems;
        }

        void AssociatedObject_RequestTreeItems(object sender, TreeGridRequestTreeItemsEventArgs args)
        {
            if (args.ParentItem == null)
            {
                //get the root list - get all employees who have no boss 
                args.ChildItems = EmployeeInfoViewModel.GetEmployees().Where(x => x.ReportsTo == -1); //get all employees whose boss's id is -1 (no boss)
            }
            else //if ParentItem not null, then set args.ChildList to the child items for the given ParentItem.
            {
                //get the children of the parent object
                EmployeeInfo emp = args.ParentItem as EmployeeInfo;
                if (emp != null)
                {
                    //get all employees that report to the parent employee
                    args.ChildItems = EmployeeInfoViewModel.GetEmployees().Where(x => x.ReportsTo == emp.ID);
                }
            }
        }       

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.RequestTreeItems -= AssociatedObject_RequestTreeItems;
        }
    }
}
