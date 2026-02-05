#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.weatheranalysis.wpf
{
    internal class AnimatableScrollViewer : ScrollViewer
    {
        internal double AnimatableHorizontalOffset
        {
            get { return (double)this.GetValue(ScrollViewer.HorizontalOffsetProperty); }
            set { this.ScrollToHorizontalOffset(value); }
        }

        // Using a DependencyProperty as the backing store for AnimatableHorizontalOffset.  This enables animation, styling, binding, etc...
        internal static readonly DependencyProperty AnimatableHorizontalOffsetProperty =
            DependencyProperty.Register("AnimatableHorizontalOffset", typeof(double), typeof(AnimatableScrollViewer), new PropertyMetadata(new PropertyChangedCallback(OnHorizontalOffsetChanged)));

        internal static void OnHorizontalOffsetChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            AnimatableScrollViewer animatableScrollViewer = (AnimatableScrollViewer)d;
            animatableScrollViewer.AnimatableHorizontalOffset = (double)e.NewValue;
        }
    }
}
