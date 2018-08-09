using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using System.Windows.Controls;
using System.Windows;
using Syncfusion.Windows.Shared;

namespace DataBindingDemo
{
    public class RestoreBehavior : Behavior<Button>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Click += new RoutedEventHandler(AssociatedObject_Click);
            base.OnAttached();
        }

        void AssociatedObject_Click(object sender, RoutedEventArgs e)
        {
            TileViewControl tileControl = ((MainWindow)App.Current.MainWindow).Tiles;
            TileViewItem tileitem = tileControl.ItemContainerGenerator.ContainerFromIndex(tileControl.SelectedIndex) as TileViewItem;
            tileitem.TileViewItemState = TileViewItemState.Normal;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Click -= new RoutedEventHandler(AssociatedObject_Click);
            base.OnDetaching();
        }
    }
}