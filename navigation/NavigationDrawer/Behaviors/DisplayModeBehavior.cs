#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.NavigationDrawer;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace syncfusion.navigationdemos.wpf
{
    public class DisplayModeBehavior : Behavior<DisplayMode>
    {
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (AssociatedObject.navigationDrawer != null)
            {
                AssociatedObject.navigationDrawer.ItemClicked += NavigationDrawer_ItemClicked;
            }
        }

        private void NavigationDrawer_ItemClicked(object sender, NavigationItemClickedEventArgs e)
        {
            if ((e.Item as NavigationItem).Header.ToString() == "Menu Item1")
            {
                AssociatedObject.contentViewFrame.NavigationService.Navigate(new SamplePage1());
            }
            else if ((e.Item as NavigationItem).Header.ToString() == "Menu Item2")
            {
                AssociatedObject.contentViewFrame.NavigationService.Navigate(new SamplePage2());
            }
            else if ((e.Item as NavigationItem).Header.ToString() == "Menu Item3")
            {
                AssociatedObject.contentViewFrame.NavigationService.Navigate(new SamplePage3());
            }
            else if ((e.Item as NavigationItem).Header.ToString() == "Menu Item4")
            {
                AssociatedObject.contentViewFrame.NavigationService.Navigate(new SamplePage4());
            }
            else if ((e.Item as NavigationItem).Header.ToString() == "Settings")
            {
                AssociatedObject.contentViewFrame.NavigationService.Navigate(new SampleSettingsPage());
            }
        }

        protected override void OnDetaching()
        {
            if (AssociatedObject.navigationDrawer != null)
            {
                AssociatedObject.navigationDrawer.ItemClicked -= NavigationDrawer_ItemClicked;
            }
        }
    }
}
