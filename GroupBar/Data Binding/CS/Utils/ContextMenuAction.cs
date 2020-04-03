#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Windows.Interactivity;
using System.Windows;
using Syncfusion.Windows.Tools.Controls;

namespace ItemsSourceDemo
{
    public class ContextMenuAction : TriggerAction<GroupBar>
	/// <summary>
    /// Represents the action for groupbar.
    /// </summary>
    {
        /// <summary>
        /// Maintains the groupbar.
        /// </summary>
        GroupBar groupBar;

        /// <summary>
        /// Method used to execute the context menu.
        /// </summary>
        /// <param name="parameter">Specifies the parameter of Invoke method.</param>
        protected override void Invoke(object parameter)
        {
            groupBar = Target as GroupBar;         
            if (groupBar != null && ((Syncfusion.Windows.Tools.GroupBarContextMenuItemEventArgs)parameter).MenuItem.Equals("Add Tab"))
            {
                ViewModel viewModel = groupBar.DataContext as ViewModel;
                viewModel.SampleList.Add(new Model() { Name = "New Item", Age = "**", Location = "**** ****", Image = "/Resources/contact_person_icon.jpg" });
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

        /// <summary>
        /// Gets or sets the target value <see cref="ContextMenuAction"/> class.
        /// </summary>
        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Target. This enables animation, styling, binding, etc...
        /// </summary>
         public static readonly DependencyProperty TargetProperty =
         DependencyProperty.Register("Target", typeof(FrameworkElement), typeof(ContextMenuAction), new UIPropertyMetadata(null));
    }
}
