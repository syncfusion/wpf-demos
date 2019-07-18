#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using Syncfusion.Samples.ViewModel;

namespace Syncfusion.Samples.Util
{
    class EventAttachUtil
    {
        public static DependencyProperty AddWindowLoaded = DependencyProperty.RegisterAttached("AddWindowLoaded", typeof(bool), typeof(EventAttachUtil), new PropertyMetadata(new PropertyChangedCallback(AddWindowLoadedChanged)));

        public static void SetAddWindowLoaded(DependencyObject sender, bool command)
        {
            sender.SetValue(AddWindowLoaded, command);
        }

        public static void AddWindowLoadedChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            Grid grid = sender as Grid;

            if (grid != null)
            {
                Window view = grid.Parent as Window;
                if (view != null)
                {
                    ReportViewModel viewModel = view.DataContext as ReportViewModel;
                    if (viewModel != null)
                    {
                        view.Loaded += new RoutedEventHandler(viewModel.Loaded);
                    }
                }
            }
        }
    }
}
