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
using System.Windows.Threading;
using System.Windows.Interactivity;
using System.Windows.Controls;
using Syncfusion.Windows.Shared;
using System.Windows.Media.Animation;
using System.Windows;

namespace DataBindingDemo
{
    public class TileLoadedAction : TargetedTriggerAction<UserControl>
    {
        private DispatcherTimer tiletimer = new DispatcherTimer();
        protected override void Invoke(object parameter)
        {
            ApplicationTile tile = ((TileItemView)TargetObject).DataContext as ApplicationTile;
            if (tile != null && tiletimer != null)
            {
                if (tile.CanSlide)
                {
                    tiletimer.Start();
                    tiletimer.Tick += new EventHandler(tiletimer_Tick);
                }
            }
        }

        private bool slide = false;
        Random rndm = new Random();

        private TileViewItem tileItems;

        public TileViewItem TileItems
        {
            get
            {
                if (tileItems == null)
                {
                    tileItems = VisualUtils.FindAncestor(this.Target, typeof(TileViewItem)) as TileViewItem;
                }
                return tileItems;
            }
        }

        void tiletimer_Tick(object sender, EventArgs e)
        {

            if (TileItems != null && TileItems.TileViewItemState == TileViewItemState.Normal)
            {
                Storyboard storyboard = null;
                if (!slide)
                {
                    storyboard = Application.Current.Resources["Storyboard1"] as Storyboard;
                    slide = true;
                }
                else
                {
                    storyboard = Application.Current.Resources["Storyboard2"] as Storyboard;
                    slide = false;
                }
                try
                {
					if(TargetObject is TileItemView)
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
