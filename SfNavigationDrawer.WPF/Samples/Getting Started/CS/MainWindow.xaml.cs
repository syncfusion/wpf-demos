#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.NavigationDrawer;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GettingStarted
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        public SfNavigationDrawer NavigationDrawer { get; set; }
        Home home = new Home();
        People people = new People();
        Photos photos = new Photos();
        public MainWindow()
        {

            InitializeComponent();
            home.NavigationDrawer = drawer;
            drawer.ContentView = home;
            list.Loaded -= list_Loaded;
            list.Loaded += list_Loaded;
        }
               
        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (NavigationDrawer != null)
            {
                if (NavigationDrawer.IsOpen)
                    NavigationDrawer.ToggleDrawer();

                else
                {
                    NavigationDrawer.ToggleDrawer();
                }
            }
        }
        private void list_Loaded(object sender, RoutedEventArgs e)
        {
            list.SelectionChanged -= list_SelectionChanged;
            list.SelectionChanged += list_SelectionChanged;
        }

        void list_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = sender as ListBox;
            if (listBox != null)
            {
                home.NavigationDrawer = drawer;
                people.NavigationDrawer = drawer;
                photos.NavigationDrawer = drawer;
                switch (listBox.SelectedIndex)
                {
                    case 0:
                        if (drawer.IsOpen)
                        {
                            drawer.ToggleDrawer();
                            drawer.ContentView = home;
                        }
                        break;
                    case 1:
                        if (drawer.IsOpen)
                        {
                            drawer.ToggleDrawer();
                            drawer.ContentView = people;
                        }
                        break;
                    case 2:
                        if (drawer.IsOpen)
                        {
                            drawer.ToggleDrawer();
                            drawer.ContentView = photos;
                        }
                        break;
                }
            }
        }

        

        private void slideposition_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as ComboBox).ItemsSource = Enum.GetValues(typeof(Position));
            (sender as ComboBox).SelectedIndex = 0;
        }

        private void slidetransition_Loaded(object sender, RoutedEventArgs e)
        {
            (sender as ComboBox).ItemsSource = Enum.GetValues(typeof(Transition));
            (sender as ComboBox).SelectedIndex = 2;
        }

        private void slideposition_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var combobox = sender as ComboBox;
            if (combobox.SelectedIndex == 0 || combobox.SelectedIndex == 2)
            {
                name.Text = "Johnson Martin";
                image.Height = 80d;
            }
            else
            {
                name.Text = string.Empty;
                image.Height = 55d;
            }

        }
    }
}