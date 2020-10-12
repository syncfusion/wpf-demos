#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Microsoft.Xaml.Behaviors;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;

namespace syncfusion.navigationdemos.wpf
{
    public class DataBindingBehavior : TriggerAction<GroupBar>
    {
        /// <summary>
        /// Method used to execute the context menu.
        /// </summary>
        /// <param name="parameter">Specifies the parameter of Invoke method.</param>
        protected override void Invoke(object parameter)
        {
            var groupBar = this.AssociatedObject;
            if (groupBar == null)
                return;

            if (((Syncfusion.Windows.Tools.GroupBarContextMenuItemEventArgs)parameter).MenuItem.Equals("Add Tab"))
            {
                EmployeeDetailViewModel viewModel = groupBar.DataContext as EmployeeDetailViewModel;
                viewModel.SampleList.Add(new EmployeeDetailModel() { Name = "New Item", Age = "**", Location = "**** ****", Image = @"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle14.png" });
            }
            else if (groupBar != null && ((Syncfusion.Windows.Tools.GroupBarContextMenuItemEventArgs)parameter).MenuItem.Equals("Cut"))
            {
                MessageBox.Show("Cut executed.");
            }
            else if (groupBar != null && ((Syncfusion.Windows.Tools.GroupBarContextMenuItemEventArgs)parameter).MenuItem.Equals("Copy"))
            {
                MessageBox.Show("Copy executed.");
            }
            else if (groupBar != null && ((Syncfusion.Windows.Tools.GroupBarContextMenuItemEventArgs)parameter).MenuItem.Equals("Sort Asc"))
            {
                MessageBox.Show("Sort Ascending executed.");
            }
            else if (groupBar != null && ((Syncfusion.Windows.Tools.GroupBarContextMenuItemEventArgs)parameter).MenuItem.Equals("Sort Dec"))
            {
                MessageBox.Show("Sort Descending executed.");
            }
            else if (groupBar != null && ((Syncfusion.Windows.Tools.GroupBarContextMenuItemEventArgs)parameter).MenuItem.Equals("Rename Tab"))
            {
                MessageBox.Show("Rename executed.");
            }
        }
    }
}
