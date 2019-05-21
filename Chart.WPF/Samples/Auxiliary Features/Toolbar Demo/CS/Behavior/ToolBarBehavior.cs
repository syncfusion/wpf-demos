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
using Syncfusion.Windows.Chart;

namespace ToolBarDemo
{
    class ToolBarBehavior : Behavior<Window1>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.btn_show.Click += new RoutedEventHandler(btn_show_Click);
            this.AssociatedObject.btn_close.Click += new RoutedEventHandler(btn_close_Click);
            this.AssociatedObject.btn_addTBItem.Click += new RoutedEventHandler(btn_addTBItem_Click);
            this.AssociatedObject.chartToolbar.SelectedItemChanged += new ChartToolBarEventHandler(chartToolbar_SelectedItemChanged);
            base.OnAttached();
        }

        private void btn_show_Click(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.Chart1.ShowToolBar();
        }

        private void btn_close_Click(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.Chart1.CloseToolBar();
        }

        private void chartToolbar_SelectedItemChanged(object sender, ChartToolBarArgs e)
        {
            ToolBarItem oldItem = (ToolBarItem)e.OldValue;
            ToolBarItem newItem = (ToolBarItem)e.NewValue;
            this.AssociatedObject.txt_oldValue.Text = oldItem.ToolTip.ToString();
            this.AssociatedObject.txt_newValue.Text = newItem.ToolTip.ToString();         
        }

        private void btn_addTBItem_Click(object sender, RoutedEventArgs e)
        {
            ToolBarItem toolBarItem = new ToolBarItem();
            toolBarItem.Text = "New";
            toolBarItem.IsDropDown = false;
            toolBarItem.ToolTip = "New Item";
            this.AssociatedObject.Chart1.ToolBar.Items.Add(toolBarItem);
        }
    }
}
