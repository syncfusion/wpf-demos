#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.pdfviewerdemos.wpf
{
    public class PdfViewerEventAttachUtil
    {
        public static DependencyProperty WindowLoaded = DependencyProperty.RegisterAttached("WindowLoaded", typeof(bool), typeof(PdfViewerEventAttachUtil), new PropertyMetadata(new PropertyChangedCallback(WindowLoadedChanged)));

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
                    if (view.ToString().Contains("MultiTabbedViewer"))
                    {
                        MultiTabbedViewerViewModel viewModel = view.DataContext as MultiTabbedViewerViewModel;
                        if (viewModel != null)
                        {
                            view.Loaded += new RoutedEventHandler(viewModel.Loaded);
                            view.Closed += new EventHandler(viewModel.Closed);
                        }
                    }
                    else if (view.ToString().Contains("CustomToolbar"))
                    {
                        CustomToolbarViewModel viewModel = view.DataContext as CustomToolbarViewModel;
                        if (viewModel != null)
                        {
                            view.Loaded += new RoutedEventHandler(viewModel.Loaded);
                            view.Closed += new EventHandler(viewModel.Closed);
                        }
                    }
                }
                else if(grid.Parent is Control)
                {
                    Control control = grid.Parent as Control;
                    EncryptionViewModel viewModel = control.DataContext as EncryptionViewModel;
                    if (viewModel != null)
                    {
                        control.Loaded += new RoutedEventHandler(viewModel.Loaded);
                        control.Unloaded += new RoutedEventHandler(viewModel.Closed);
                    }
                }
            }
        }
    }
}
