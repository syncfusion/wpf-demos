using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace syncfusion.weatheranalysis.wpf
{
    public class AnimateListBoxBehavior : Behavior<UserControl>
    {
        /// <summary>
        /// Maintains scroll viewer refference
        /// </summary>
        private AnimatableScrollViewer scrollViewer;

        private Button NavigateForward;

        private Button NavigateBackward;

        private ListBox ListBoxToAnimate;

        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        /// <summary>
        /// Handles the Loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (AssociatedObject is ForecastView forecastView)
            {
                NavigateBackward = forecastView.NavigateBackward;
                NavigateForward = forecastView.NavigateForward;
                ListBoxToAnimate = forecastView.forecastList;
                scrollViewer = forecastView.scrollViewer;
            }

            if (AssociatedObject is HourlyView hourlyView)
            {
                NavigateBackward = hourlyView.NavigateBackward;
                NavigateForward = hourlyView.NavigateForward;
                ListBoxToAnimate = hourlyView.forecastList;
                scrollViewer = hourlyView.scrollViewer;
            }

            if (AssociatedObject is HourlyDetailView hourlyDetailView)
            {
                NavigateBackward = hourlyDetailView.NavigateBackward;
                NavigateForward = hourlyDetailView.NavigateForward;
                ListBoxToAnimate = hourlyDetailView.forecastList;
                scrollViewer = hourlyDetailView.scrollViewer;
            }

            NavigateForward.Click -= NavigateForward_Click;
            NavigateBackward.Click -= NavigateBackward_Click;
            NavigateForward.Click += NavigateForward_Click;
            NavigateBackward.Click += NavigateBackward_Click;
            if (scrollViewer != null)
            {
                scrollViewer.ScrollChanged -= ScrollViewer_ScrollChanged;
                scrollViewer.ScrollChanged += ScrollViewer_ScrollChanged;
            }
        }

        /// <summary>
        /// Occurs when the mouse wheel of show case demos
        /// </summary>
        private void ShowcaseList_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
        {
            if (scrollViewer != null)
            {
                if (e.Delta > 0)
                    scrollViewer.LineLeft();

                else if (e.Delta < 0)
                    scrollViewer.LineRight();
            }

            e.Handled = true;
        }

        /// <summary>
        /// Occurs when the previous Showcase Demos button is pressed.
        /// </summary>
        private void NavigateBackward_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (scrollViewer != null)
            {
                double scrollOffset = scrollViewer.HorizontalOffset - scrollViewer.ViewportWidth;
                Animate(scrollOffset);
            }
        }

        /// <summary>
        /// Occurs when the next Showcase Demos button is pressed.
        /// </summary>
        private void NavigateForward_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (scrollViewer != null)
            {
                var scrollOffset = scrollViewer.HorizontalOffset + scrollViewer.ViewportWidth;
                Animate(scrollOffset);
            }
        }

        /// <summary>
        /// Helps to perform showcase demo scrolling animation
        /// </summary>
        private void Animate(double scrollOffset)
        {
            DoubleAnimation animation = new DoubleAnimation
            {
                To = Math.Floor(scrollOffset),
                Duration = TimeSpan.FromSeconds(6),
                From = scrollViewer.HorizontalOffset,
                EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut },
            };
            scrollViewer.BeginAnimation(AnimatableScrollViewer.AnimatableHorizontalOffsetProperty, animation);
        }

        /// <summary>
        /// Occurs when changes are detected to the scroll position, extent, or viewport  size.
        /// </summary>
        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var target = sender as ScrollViewer;

            bool isLastItemVisible = scrollViewer.HorizontalOffset + scrollViewer.ViewportWidth >= scrollViewer.ExtentWidth; ;

            if (isLastItemVisible)
            {
                NavigateForward.Visibility = Visibility.Collapsed;
            }
            else
            {
                NavigateForward.Visibility = Visibility.Visible;
            }

            if (target.HorizontalOffset > 0)
            {
                NavigateBackward.Visibility = Visibility.Visible;
            }
            else
            {
                NavigateBackward.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            NavigateForward.Click -= NavigateForward_Click;
            NavigateBackward.Click -= NavigateBackward_Click;
            scrollViewer.ScrollChanged -= ScrollViewer_ScrollChanged;
            scrollViewer = null;
            NavigateForward = null;
            NavigateBackward = null;
            if (ListBoxToAnimate != null)
            {
                ListBoxToAnimate.ItemsSource = null;
                ListBoxToAnimate = null;
            }
        }
    }
}
