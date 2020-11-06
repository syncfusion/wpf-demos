#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using Syncfusion.Windows.Shared;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;

namespace syncfusion.layoutdemos.wpf
{
    public class StateChangeBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Click += new RoutedEventHandler(AssociatedObject_Click);
            base.OnAttached();
        }

        void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            TileViewItem tileitem = Target.ItemContainerGenerator.ContainerFromIndex(Target.SelectedIndex) as TileViewItem;

            if (tileitem.TileViewItemState == TileViewItemState.Normal)
            {
                tileitem.TileViewItemState = TileViewItemState.Maximized;
            }
            else
            {
                tileitem.TileViewItemState = TileViewItemState.Normal;
            }
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Click -= new RoutedEventHandler(AssociatedObject_Click);
            base.OnDetaching();
        }

        public TileViewControl Target
        {
            get { return (TileViewControl)GetValue(TargetProperty); }
            set { SetValue(TargetProperty, value); }
        }

        public static readonly DependencyProperty TargetProperty =
            DependencyProperty.Register("Target", typeof(TileViewControl), typeof(StateChangeBehavior), new UIPropertyMetadata(null));
    }
}
