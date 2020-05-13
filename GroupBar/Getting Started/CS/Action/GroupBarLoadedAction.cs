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
using System.Windows.Controls;
using System.Windows.Media;

namespace GroupBarDemo
{
    /// <summary>
    /// Represents a loaded action for groupbar.
    /// </summary>
    public class GroupBarLoadedAction : TriggerAction<GroupBar>
    {
        /// <summary>
        /// Notifies the method which invokes the loaded action.
        /// </summary>
        /// <param name="parameter">invokes the loaded action</param>
        protected override void Invoke(object parameter)
        {
            GroupBar GroupBarFields;
            GroupBarFields = Target as GroupBar;
            if (GroupBarFields != null)
            {
                ContextMenu context = GroupBarFields.ContextMenu;
                MenuItem menu = new MenuItem();
                menu.Click += new RoutedEventHandler(menu_Click);
                menu.Header = "Custom MenuItem";
                context.Items.Add(menu);
                GroupBarFields.DragMarkerBrush = Brushes.Red;
            }
        }

        /// <summary>
        /// Notifies the click event.
        /// </summary>
        /// <param name="sender">Invokes the click event</param>
        /// <param name="e"></param>
        void menu_Click(object sender, RoutedEventArgs e)
        {
            ContextMenu contextMenu = (ContextMenu)(e.OriginalSource as MenuItem).Parent;
            if (contextMenu.PlacementTarget is GroupBarItem)
            {
                GroupBarItem groupBarItem = (GroupBarItem)contextMenu.PlacementTarget;
                MessageBox.Show(groupBarItem.HeaderText);
            }
            else if (contextMenu.PlacementTarget is GroupView)
            {
                GroupView groupBarView = (GroupView)contextMenu.PlacementTarget;
                for (int i = 0; i < groupBarView.Items.Count; i++)
                {
                    GroupViewItem groupBarviewItem = (GroupViewItem)groupBarView.Items[i];
                    if (groupBarviewItem.IsSelected)
                    {
                        MessageBox.Show(groupBarviewItem.Text);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Gets and sets the target value.
        /// </summary>
        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for Target.  This enables animation, styling, binding, etc...
        /// </summary>
         public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(FrameworkElement), typeof(GroupBarLoadedAction), new UIPropertyMetadata(null));
    }
}
