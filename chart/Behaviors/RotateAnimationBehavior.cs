#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Xaml.Behaviors;
using System.Windows.Media.Animation;

namespace syncfusion.chartdemos.wpf
{
    public class RotateAnimationBehavior : Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            (AssociatedObject as SfChart3D).Loaded += RotateAnimation_Loaded;
            base.OnAttached();
        }

        private void RotateAnimation_Loaded(object sender, RoutedEventArgs e)
        {
            var sb = new Storyboard();
            var chart = sender as SfChart3D;
            DoubleAnimation animation = new DoubleAnimation() { From = 0, To = chart.Rotation, };
            Storyboard.SetTarget(animation, chart);
            Storyboard.SetTargetProperty(animation, new PropertyPath(SfChart3D.RotationProperty));

            sb.Children.Add(animation);

            animation = new DoubleAnimation() { From = 0, To = chart.Tilt, };
            Storyboard.SetTarget(animation, chart);
            Storyboard.SetTargetProperty(animation, new PropertyPath(SfChart3D.TiltProperty));
            sb.Children.Add(animation);

            EventHandler handler = (object sender2, EventArgs e2) =>
            {
                var rotation = chart.Rotation;
                var tilt = chart.Tilt;
                chart.BeginAnimation(SfChart3D.RotationProperty, null);
                chart.BeginAnimation(SfChart3D.TiltProperty, null);

                chart.Rotation = rotation;
                chart.Tilt = tilt;
            };

            sb.Completed += handler;
            sb.Begin();
        }
    }
}
