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
using System.Windows.Input;

namespace syncfusion.layoutdemos.wpf
{
    public class CancelEditingBehavior : Behavior<CardView>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.PreviewKeyDown += AssociatedObject_PreviewKeyDown;
        }

        private void AssociatedObject_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var cardview = AssociatedObject;
            if (cardview.SelectedItem != null)
            {
                var cardviewItem = cardview.ItemsSource != null
                    ? (CardViewItem)cardview.ItemContainerGenerator.ContainerFromItem(cardview.SelectedItem)
                    : (CardViewItem)cardview.SelectedItem;
                if (cardviewItem != null && cardviewItem.IsInEditMode)
                {
                    if (e.Key == Key.Escape)
                    {
                        if (cardviewItem.DataContext is CardViewModel)
                            e.Handled = !(cardviewItem.DataContext as CardViewModel).ValidationSuccess;
                    }
                }
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.PreviewKeyDown -= AssociatedObject_PreviewKeyDown;
        }
    }
}
