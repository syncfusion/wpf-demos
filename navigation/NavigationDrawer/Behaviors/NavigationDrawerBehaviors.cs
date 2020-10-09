#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
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
    public class NavigationDrawerBehaviors : Behavior<NavigationDrawerView>
    {
        private NavigationDrawerViewModel navigationDrawerViewModel;

        ObservableCollection<Message> messageContent = new ObservableCollection<Message>();
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (AssociatedObject.DataContext is NavigationDrawerViewModel)
            {
                navigationDrawerViewModel = AssociatedObject.DataContext as NavigationDrawerViewModel;
            }

            AssociatedObject.list.Loaded += List_Loaded;
            AssociatedObject.list.SelectionChanged += List_SelectionChanged;
            AssociatedObject.button.Click += Button_Click;

            AssociatedObject.contentView.Children.Add(new DrawerContentView(navigationDrawerViewModel.MenuCollection[0].MessageContent, "Inbox"));
            AssociatedObject.list.ItemsSource = navigationDrawerViewModel.MenuCollection;

            for (int i = 0; i < 7; i++)
            {
                messageContent.Add(navigationDrawerViewModel.MenuCollection[0].MessageContent[i]);
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (AssociatedObject.drawer != null)
            {
                AssociatedObject.drawer.ToggleDrawer();
                AssociatedObject.button.Visibility = Visibility.Visible;
            }
        }

        private void List_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            for (int i = 0; i < 8; i++)
            {
                var tempItem = (listBox.ItemsSource as ObservableCollection<MenuCollectionModel>)[i];
                if ((listBox.SelectedItem as MenuCollectionModel) == tempItem)
                {
                    tempItem.FontColor = tempItem.TextColor = new SolidColorBrush(Color.FromRgb(43, 87, 154));
                }
                else
                {
                    tempItem.TextColor = new SolidColorBrush(Colors.Black);
                    tempItem.FontColor = new SolidColorBrush(Color.FromRgb(117, 117, 117));
                }
            }

            var temp = listBox.SelectedItem as MenuCollectionModel;
            AssociatedObject.contentView.Children.Clear();
            AssociatedObject.contentView.Children.Add(new DrawerContentView(temp.MessageContent, (listBox.SelectedItem as MenuCollectionModel).MenuItem));
            AssociatedObject.headerLabel.Content = temp.MenuItem;
            AssociatedObject.drawer.ToggleDrawer();
        }

        private void List_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            var listBox = sender as ListBox;
            var tempItem = (listBox.ItemsSource as ObservableCollection<MenuCollectionModel>)[0];
            tempItem.FontColor = tempItem.TextColor = new SolidColorBrush(Color.FromRgb(43, 87, 154));
        }

        protected override void OnDetaching()
        {
            AssociatedObject.list.Loaded -= List_Loaded;
            AssociatedObject.list.SelectionChanged -= List_SelectionChanged;
            AssociatedObject.button.Click -= Button_Click;

            if (messageContent != null)
            {
                messageContent.Clear();
                messageContent = null;
            }
        }
    }
}
