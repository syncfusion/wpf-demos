using Microsoft.Xaml.Behaviors;
using Syncfusion.SfSkinManager;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace syncfusion.demoscommon.wpf
{
    public class ProductsListBehavior : Behavior<HomePage>
    {
        /// <summary>
        /// Maintains view model refference
        /// </summary>
        private DemoBrowserViewModel sampleBrowserViewModel;

        /// <summary>
        /// Maintains scroll viewer refference
        /// </summary>
        private ScrollViewer scrollViewer;

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
            sampleBrowserViewModel = AssociatedObject.DataContext as DemoBrowserViewModel;
            AssociatedObject.NavigateForward.Click += NavigateForward_Click;
            AssociatedObject.NavigateBackward.Click += NavigateBackward_Click;
            AssociatedObject.ShowcaseList.PreviewMouseWheel += ShowcaseList_PreviewMouseWheel;
            scrollViewer = Syncfusion.Windows.Shared.VisualUtils.FindDescendant(AssociatedObject.ShowcaseList, typeof(ScrollViewer)) as ScrollViewer;
            if (scrollViewer != null)
            {
                scrollViewer.ScrollChanged += ScrollViewer_ScrollChanged;
                var totalWidth = AssociatedObject.ShowcaseList.Items.Count * 308;
                if (totalWidth <= scrollViewer.ViewportWidth)
                {
                    AssociatedObject.NavigateForward.Visibility = Visibility.Collapsed;
                }
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
                Animate(scrollViewer, -Math.Floor(scrollViewer.ViewportWidth / 2));
            }
        }

        /// <summary>
        /// Occurs when changes are detected to the scroll position, extent, or viewport  size.
        /// </summary>
        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            var target = sender as ScrollViewer;

            if ((e.HorizontalOffset + e.ViewportWidth) == e.ExtentWidth)
            {
                AssociatedObject.NavigateForward.Visibility = Visibility.Collapsed;
            }
            else
            {
                AssociatedObject.NavigateForward.Visibility = Visibility.Visible;
            }
            if (target.HorizontalOffset > 0)
            {
                AssociatedObject.NavigateBackward.Visibility = Visibility.Visible;
            }
            else
            {
                AssociatedObject.NavigateBackward.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Occurs when the next Showcase Demos button is pressed.
        /// </summary>
        private void NavigateForward_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (scrollViewer != null)
            {
                Animate(scrollViewer, Math.Floor(scrollViewer.ViewportWidth / 2));
            }
        }

        /// <summary>
        /// Helps to perform showcase demo scrolling animation
        /// </summary>
        private void Animate(ScrollViewer target, double speed)
        {
            double startOffset = target.HorizontalOffset;
            double animationTime = 2;
            Stopwatch startTime = new Stopwatch();
            startTime.Start();
            EventHandler renderHandler = null;
            renderHandler = (sender, args) =>
            {
                double elapsed = startTime.Elapsed.TotalSeconds;

                if (elapsed >= animationTime)
                {
                    CompositionTarget.Rendering -= renderHandler;
                    startTime.Stop();
                }

                target.ScrollToHorizontalOffset(startOffset + (elapsed * speed));
            };
            CompositionTarget.Rendering += renderHandler;
        }

        /// <summary>
        ///  Occurs when navigation events are requested.
        /// </summary>
        private void LinkedInlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            var process = new ProcessStartInfo
            {
                FileName = e.Uri.AbsoluteUri,
                UseShellExecute = true
            };
            Process.Start(process);
            e.Handled = true;
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            AssociatedObject.NavigateForward.Click -= NavigateForward_Click;
            AssociatedObject.NavigateBackward.Click -= NavigateBackward_Click;
            AssociatedObject.ShowcaseList.PreviewMouseWheel -= ShowcaseList_PreviewMouseWheel;
            scrollViewer.ScrollChanged -= ScrollViewer_ScrollChanged;
            if(scrollViewer != null)
            {
                scrollViewer = null;
            }
        }
    }
}
