#region Copyright Syncfusion Inc. 2001 - 2026
// Copyright Syncfusion Inc. 2001 - 2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws.
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Controls.DataPager;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.treegriddemos.wpf
{ 
    public class TreeGridPagingBehavior : Behavior<TreeGridPagingDemo>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.treeGridViewTypeComboBox.SelectionChanged += TreeGridViewTypeComboBox_SelectionChanged;
            this.AssociatedObject.expandButton.Click += ExpandButton_Click;
            this.AssociatedObject.collapseButton.Click += CollapseButton_Click;
            this.AssociatedObject.orientationComboBox.SelectionChanged += OrientationComboBox_SelectionChanged;
        }

        private void OrientationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.AssociatedObject.orientationComboBox.SelectedItem is ComboBoxItem item)
            {
                switch (this.AssociatedObject.treeGridArea.Content)
                {
                    case SelfRelationalPagingView selfView:
                        ApplyOrientation(selfView.sfDataPager, item.Content.ToString());
                        break;
                    case NestedPagingView nestedView:
                        ApplyOrientation(nestedView.sfDataPager, item.Content.ToString());
                        break;
                }
            }
        }

        private void ApplyOrientation(SfDataPager pager, string orientation)
        {
            if (orientation.Equals("Horizontal"))
            {
                pager.Orientation = Orientation.Horizontal;
                Grid.SetRow(pager, 1);
                Grid.SetColumn(pager, 0);
            }
            else
            {
                pager.Orientation = Orientation.Vertical;
                Grid.SetRow(pager, 0);
                Grid.SetColumn(pager, 1);
            }
        }

        private void CollapseButton_Click(object sender, RoutedEventArgs e)
        {
            HandleExpandCollapse(false);
        }

        private void ExpandButton_Click(object sender, RoutedEventArgs e)
        {
            HandleExpandCollapse(true);
        }

        private void HandleExpandCollapse(bool expand)
        {
            switch (this.AssociatedObject.treeGridArea.Content)
            {
                case SelfRelationalPagingView selfView:
                    {
                        if (expand) selfView.treeGrid.ExpandAllNodes();
                        else selfView.treeGrid.CollapseAllNodes();
                        break;
                    }
                case NestedPagingView nestedView:
                    {
                        if (expand) nestedView.treeGrid.ExpandAllNodes();
                        else nestedView.treeGrid.CollapseAllNodes();
                        break;
                    }
            }
        }

        private void TreeGridViewTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.AssociatedObject.treeGridViewTypeComboBox.SelectedItem is ComboBoxItem item)
            {
                string content = item.Content.ToString();
                if (content.Equals("Self Relational View") && !(this.AssociatedObject.treeGridArea.Content is SelfRelationalPagingView))
                    this.AssociatedObject.treeGridArea.Content = new SelfRelationalPagingView();
                else if (content.Equals("Nested Collection View") && !(this.AssociatedObject.treeGridArea.Content is NestedPagingView))
                    this.AssociatedObject.treeGridArea.Content = new NestedPagingView();

                this.AssociatedObject.orientationComboBox.SelectedIndex = 0;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            this.AssociatedObject.treeGridViewTypeComboBox.SelectionChanged -= TreeGridViewTypeComboBox_SelectionChanged;
            this.AssociatedObject.expandButton.Click -= ExpandButton_Click;
            this.AssociatedObject.collapseButton.Click -= CollapseButton_Click;
            this.AssociatedObject.orientationComboBox.SelectionChanged -= OrientationComboBox_SelectionChanged;
        }
    }
}