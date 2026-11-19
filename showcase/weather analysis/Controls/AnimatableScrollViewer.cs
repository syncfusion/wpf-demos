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
