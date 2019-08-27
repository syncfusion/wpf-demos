#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Controls;
using System.Windows.Media;

namespace GroupBarDemo
{
    public class GroupBarLoadedAction:TriggerAction<Syncfusion.Windows.Tools.Controls.GroupBar>
    {
        Syncfusion.Windows.Tools.Controls.GroupBar myGroupBar;

        protected override void Invoke(object parameter)
        {
            myGroupBar = Target as Syncfusion.Windows.Tools.Controls.GroupBar;
            if (myGroupBar != null)
            {
                ContextMenu c = myGroupBar.ContextMenu;
                MenuItem m = new MenuItem();
                m.Click += new RoutedEventHandler(m_Click);
                m.Header = "Custom MenuItem";
                c.Items.Add(m);
                myGroupBar.DragMarkerBrush = Brushes.Red;
            }
        }

        void m_Click(object sender, RoutedEventArgs e)
        {
            //Context Menu
            ContextMenu c = (ContextMenu)(e.OriginalSource as MenuItem).Parent;
            if (c.PlacementTarget is GroupBarItem)
            {
                GroupBarItem g = (GroupBarItem)c.PlacementTarget;
                MessageBox.Show(g.HeaderText);
            }
            else if (c.PlacementTarget is GroupView)
            {
                GroupView gview = (GroupView)c.PlacementTarget;
                for (int i = 0; i < gview.Items.Count; i++)
                {
                    GroupViewItem gitem = (GroupViewItem)gview.Items[i];
                    if (gitem.IsSelected)
                    {
                        MessageBox.Show(gitem.Text);
                        break;
                    }
                }
            }
        }

        public FrameworkElement Target
        {
            get { return (FrameworkElement)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Target.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(FrameworkElement), typeof(GroupBarLoadedAction), new UIPropertyMetadata(null));
    }
}
