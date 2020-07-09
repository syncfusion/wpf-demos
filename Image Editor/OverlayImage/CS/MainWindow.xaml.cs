#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.ImageEditor;
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

namespace OverlayImage
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        CustomViewSettings selectedViewSettings;

        private bool isReplace;
        public MainWindow()
        {
            InitializeComponent();

            editor.ToolbarSettings.ToolbarItems.Clear();
            editor.ToolbarSettings.ToolbarItems.Add(new ToolbarItem() { Name = "Add", IconTemplate = grid.Resources["add"] as DataTemplate });
            editor.ToolbarSettings.ToolbarItems.Add(new ToolbarItem() { Name = "Replace", IconTemplate = grid.Resources["replace"] as DataTemplate });
            editor.ToolbarSettings.ToolbarItems.Add(new ToolbarItem() { Name = "Front", IconTemplate = grid.Resources["front"] as DataTemplate });
            editor.ToolbarSettings.ToolbarItems.Add(new ToolbarItem() { Name = "Back", IconTemplate = grid.Resources["back"] as DataTemplate });
        }

        private void ToolbarSettings_ToolbarItemSelected(object sender, ToolbarItemSelectedEventArgs e)
        {
            isReplace = false;
            var name = e.ToolbarItem.Name;
            if (name == "Add")
            {
                notePanel.Visibility = Visibility.Collapsed;
                ImagePanel.Visibility = Visibility.Visible;
            }
            else if (name == "Replace")
            {
                notePanel.Visibility = Visibility.Collapsed;
                ImagePanel.Visibility = Visibility.Visible;
                isReplace = true;
            }
            else if (name == "Front")
            {
                editor.BringToFront();
            }
            else if (name == "Back")
            {
                editor.SendToBack();
            }
        }

        private void Image1_Click(object sender, RoutedEventArgs e)
        {
            if (isReplace)
            {
                if (editor.IsSelected)
                    editor.Delete();
                else
                    return;
            }

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(@"Assets/Type1.png", UriKind.Relative);
            bitmapImage.EndInit();

            CustomViewSettings customViewSettings = new CustomViewSettings();
            customViewSettings.CanMaintainAspectRatio = false;

            if (isReplace && selectedViewSettings != null)
            {
                customViewSettings.Bounds = selectedViewSettings.Bounds;
            }

            Image image = new Image();
            image.Height = 100;
            image.Width = 100;
            image.Stretch = Stretch.Fill;
            image.Source = bitmapImage;
            editor.AddCustomView(image, customViewSettings);

            notePanel.Visibility = Visibility.Visible;
            ImagePanel.Visibility = Visibility.Collapsed;
        }

        private void Image2_Click(object sender, RoutedEventArgs e)
        {
            if (isReplace)
            {
                if (editor.IsSelected)
                    editor.Delete();
                else
                    return;
            }

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(@"Assets/Type2.png", UriKind.Relative);
            bitmapImage.EndInit();

            CustomViewSettings customViewSettings = new CustomViewSettings();
            customViewSettings.CanMaintainAspectRatio = false;

            if (isReplace && selectedViewSettings != null)
            {
                customViewSettings.Bounds = selectedViewSettings.Bounds;
            }

            Image image = new Image();
            image.Height = 100;
            image.Width = 100;
            image.Stretch = Stretch.Fill;
            image.Source = bitmapImage;
            editor.AddCustomView(image, customViewSettings);

            notePanel.Visibility = Visibility.Visible;
            ImagePanel.Visibility = Visibility.Collapsed;
        }

        private void Image3_Click(object sender, RoutedEventArgs e)
        {
            if (isReplace)
            {
                if (editor.IsSelected)
                    editor.Delete();
                else
                    return;
            }

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(@"Assets/Type3.png", UriKind.Relative);
            bitmapImage.EndInit();

            CustomViewSettings customViewSettings = new CustomViewSettings();
            customViewSettings.CanMaintainAspectRatio = false;

            if (isReplace && selectedViewSettings != null)
            {
                customViewSettings.Bounds = selectedViewSettings.Bounds;
            }

            Image image = new Image();
            image.Height = 100;
            image.Width = 100;
            image.Stretch = Stretch.Fill;
            image.Source = bitmapImage;
            editor.AddCustomView(image, customViewSettings);

            notePanel.Visibility = Visibility.Visible;
            ImagePanel.Visibility = Visibility.Collapsed;
        }

        private void Image4_Click(object sender, RoutedEventArgs e)
        {
            if (isReplace)
            {
                if (editor.IsSelected)
                    editor.Delete();
                else
                    return;
            }

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(@"Assets/Type4.png", UriKind.Relative);
            bitmapImage.EndInit();

            CustomViewSettings customViewSettings = new CustomViewSettings();
            customViewSettings.CanMaintainAspectRatio = false;

            if (isReplace && selectedViewSettings != null)
            {
                customViewSettings.Bounds = selectedViewSettings.Bounds;
            }

            Image image = new Image();
            image.Height = 100;
            image.Width = 100;
            image.Stretch = Stretch.Fill;
            image.Source = bitmapImage;
            editor.AddCustomView(image, customViewSettings);

            notePanel.Visibility = Visibility.Visible;
            ImagePanel.Visibility = Visibility.Collapsed;
        }

        private void Editor_ItemSelected(object sender, ItemSelectedEventArgs e)
        {
            if (e.Settings != null && e.Settings is CustomViewSettings)
            {
                selectedViewSettings = e.Settings as CustomViewSettings;
            }

        }
    }
}
