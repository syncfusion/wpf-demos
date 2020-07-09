#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.TreeView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Interactivity;

namespace SfTreeViewDemo
{
    public class SelectionChangedBehavior : Behavior<SfTreeView>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
            base.OnAttached();
        }

        private void AssociatedObject_SelectionChanged(object sender, ItemSelectionChangedEventArgs e)
        {
            SfTreeView treeView = sender as SfTreeView;
            if(treeView != null)
            {
                if((treeView.SelectedItem as Model).Product != null)
                {
                    (this.AssociatedObject.DataContext as ViewModel).Visibility = Visibility.Visible;
                }
                else
                {
                    (this.AssociatedObject.DataContext as ViewModel).Visibility = Visibility.Collapsed;
                }
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;
            base.OnDetaching();
        }
    }
}
