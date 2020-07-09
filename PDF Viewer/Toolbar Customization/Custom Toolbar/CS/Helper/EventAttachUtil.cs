#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Windows.Controls;

namespace CustomToolbarDemo
{
    public class EventAttachUtil
    {
        public static DependencyProperty WindowLoaded = DependencyProperty.RegisterAttached("WindowLoaded", typeof(bool), typeof(EventAttachUtil), new PropertyMetadata(new PropertyChangedCallback(WindowLoadedChanged)));

        public static void SetWindowLoaded(DependencyObject sender, bool command)
        {
            sender.SetValue(WindowLoaded, command);
        }

        public static void WindowLoadedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Grid grid = sender as Grid;
            if (grid != null)
            {
                Window view = grid.Parent as Window;
                if (view != null)
                {
                    ViewModel viewModel = view.DataContext as ViewModel;
                    if (viewModel != null)
                    {
                        view.Loaded += new RoutedEventHandler(viewModel.Loaded);
                        view.SizeChanged += new SizeChangedEventHandler(viewModel.Window_SizeChanged);
                    }
                }
            }
        }
    }
}
