#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Threading;
using System.Windows.Controls;
using Syncfusion.Windows.Shared;
using System.Windows.Media.Animation;
using System.Windows;
using Microsoft.Xaml.Behaviors;
using syncfusion.demoscommon.wpf;

namespace syncfusion.layoutdemos.wpf
{
    public class TileLoadedAction : TargetedTriggerAction<UserControl>
    {
        private DispatcherTimer tiletimer = new DispatcherTimer();
        protected override void Invoke(object parameter)
        {
            var tileitemview = TargetObject as TileItemView;
            if (tileitemview != null)
            {
                ApplicationTile tile = tileitemview.DataContext as ApplicationTile;
                tileitemview.Unloaded += TileLoadedAction_Unloaded;
                if (tile != null && tiletimer != null && tile.CanSlide)
                {
                    tiletimer.Start();
                    tiletimer.Tick += tiletimer_Tick;
                }
            }
        }

        private void TileLoadedAction_Unloaded(object sender, RoutedEventArgs e)
        {
            tiletimer.Stop();
            tiletimer.Tick -= tiletimer_Tick;
            (sender as TileItemView).Unloaded -= TileLoadedAction_Unloaded;
        }

        private bool slide = false;
        Random rndm = new Random();

        private TileViewItem tileItems;

        public TileViewItem GetTileItem()
        {
            if (tileItems == null)
            {
                tileItems = VisualUtils.FindAncestor(this.Target, typeof(TileViewItem)) as TileViewItem;
            }
            return tileItems;
        }

        void tiletimer_Tick(object sender, EventArgs e)
        {

            if (GetTileItem() != null && GetTileItem().TileViewItemState == TileViewItemState.Normal)
            {
                Storyboard storyboard = null;
                if (!slide)
                {
                    foreach (Window win in Application.Current.Windows)
                    {
                        if (win is ProductDemosWindow)
                        {
                            DataBindingDemo demo = VisualUtils.FindDescendant(win as System.Windows.Media.Visual, typeof(DataBindingDemo)) as DataBindingDemo;
                            if (demo != null)
                                storyboard = demo.Resources["Storyboard1"] as Storyboard;
                            slide = false;
                            break;
                        }
                    }
                }
                else
                {
                    foreach (Window win in Application.Current.Windows)
                    {
                        if (win is ProductDemosWindow)
                        {
                            DataBindingDemo demo = VisualUtils.FindDescendant(win as System.Windows.Media.Visual, typeof(DataBindingDemo)) as DataBindingDemo;
                            if (demo != null)
                                storyboard = demo.Resources["Storyboard2"] as Storyboard;
                            slide = false;
                            break;
                        }
                    }

                }
                try
                {
                    if (TargetObject is TileItemView && storyboard != null)
                        storyboard.Begin((TileItemView)TargetObject);

                }
                catch (Exception)
                {

                }

                tiletimer.Interval = new TimeSpan(0, 0, rndm.Next(3, 10));
            }
        }

    }
}
