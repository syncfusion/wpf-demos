
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
                viewModel.SampleList.Add(new EmployeeDetailModel() { Header = "New Item", Age = "**", Location = "**** ****", Image = @"/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle14.png" });
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
