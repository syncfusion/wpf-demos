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
using System.Windows.Interactivity;
using Syncfusion.Windows.Controls.Map;
using System.Text;
using System.Windows;

namespace USInternetTrafficDemo
{
    class MapBehaviour:Behavior<ShapeFileLayer>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(AssociatedObject_SelectionChanged);            
        }

        void AssociatedObject_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            double lat = (sender as ShapeFileLayer).LatLonPoint.X;
            double lon = (sender as ShapeFileLayer).LatLonPoint.Y;
            Point point;
            Random rand = new Random();
            point = (sender as ShapeFileLayer).LatitudeLongitudeToPoint(new Point(lat, lon));

            FrameworkElement element = (sender as ShapeFileLayer).PointToElement(point);
            if (element == null)
                return;
            (sender as ShapeFileLayer).Tag = element.Tag as StateWiseWebPageUsageModel;           
        }      
    }
}
