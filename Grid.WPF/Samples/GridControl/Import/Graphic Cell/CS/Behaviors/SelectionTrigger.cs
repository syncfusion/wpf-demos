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
using System.Windows.Controls;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Tools.Controls;

namespace ImportingDemo.Behaviors
{
    public class SelectionTrigger : TargetedTriggerAction<TabControlExt>
    {
        private bool isChecked = false;
        private TabControlExt tabControl;
        protected override void Invoke(object parameter)
        {
            var selectionchkbox = this.AssociatedObject as CheckBox;
            selectionchkbox.Checked += new System.Windows.RoutedEventHandler(selectionchkbox_Checked);
            selectionchkbox.Unchecked += new System.Windows.RoutedEventHandler(selectionchkbox_Unchecked);
            tabControl = ((this.AssociatedObject as CheckBox).DataContext as TabControlExt);
            for (int i = 0; i < tabControl.Items.Count; i++)
            {
                var tabItem = tabControl.Items[i] as TabItemExt;
                var grid = (tabItem.Content as ScrollViewer).Content as GridControl;
                if (grid != null)
                    grid.Model.GraphicModel.GraphicQueryCellInfo += new GraphicQueryCellInfoEventHandler(GraphicModel_GraphicQueryCellInfo);
                grid.Model.GraphicModel.InvalidateGraphicCells();
            }
        }

        void GraphicModel_GraphicQueryCellInfo(object sender, GraphicQueryCellInfoEventArgs e)
        {
            e.Style.Enabled = isChecked;
            if (!e.Style.Enabled)
            {
                if (e.Style.GraphicCellControl != null && e.Style.GraphicCellControl.IsSelected)
                {
                    e.Style.GraphicCellControl.IsSelected = false;
                    var spanInfo = GraphicCellHelper.GetCellSpanInfo(e.Style.GraphicCellControl);
                    (sender as GraphicModel).SelectedGraphicCells.Remove(spanInfo);
                    e.Style.GraphicCellControl.InvalidateVisual();
                }
            }
        }

        void selectionchkbox_Unchecked(object sender, System.Windows.RoutedEventArgs e)
        {
            isChecked = false;
            for (int i = 0; i < tabControl.Items.Count; i++)
            {
                var tabItem = tabControl.Items[i] as TabItemExt;
                var grid = (tabItem.Content as ScrollViewer).Content as GridControl;
                if (grid != null)
                    grid.Model.GraphicModel.InvalidateGraphicCells();
            }
        }

        void selectionchkbox_Checked(object sender, System.Windows.RoutedEventArgs e)
        {
            isChecked = true;
            for (int i = 0; i < tabControl.Items.Count; i++)
            {
                var tabItem = tabControl.Items[i] as TabItemExt;
                var grid = (tabItem.Content as ScrollViewer).Content as GridControl;
                if (grid != null)
                    grid.Model.GraphicModel.InvalidateGraphicCells();
            }
        }
    }
}
