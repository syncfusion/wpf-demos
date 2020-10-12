#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
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

namespace syncfusion.imageeditordemos.wpf
{
    class OverlayImageBehavior : Behavior<OverlayImage>
    {
        CustomViewSettings selectedViewSettings;

        private bool isReplace;
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new RoutedEventHandler(AssociatedObject_Loaded);
        }

        /// <summary>
        /// Handles the Loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.editor.Loaded += Editor_Loaded;
            this.AssociatedObject.image1.Click += Image1_Click;
            this.AssociatedObject.image2.Click += Image2_Click;
            this.AssociatedObject.image3.Click += Image3_Click;
            this.AssociatedObject.image4.Click += Image4_Click;
        }
      
        private void Editor_Loaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.editor.ToolbarSettings.ToolbarItems.Clear();
            this.AssociatedObject.editor.ToolbarSettings.ToolbarItems.Add(new ToolbarItem() { Name = "Add", IconTemplate = this.AssociatedObject.grid.Resources["add"] as DataTemplate });
            this.AssociatedObject.editor.ToolbarSettings.ToolbarItems.Add(new ToolbarItem() { Name = "Replace", IconTemplate = this.AssociatedObject.grid.Resources["replace"] as DataTemplate });
            this.AssociatedObject.editor.ToolbarSettings.ToolbarItems.Add(new ToolbarItem() { Name = "Front", IconTemplate = this.AssociatedObject.grid.Resources["front"] as DataTemplate });
            this.AssociatedObject.editor.ToolbarSettings.ToolbarItems.Add(new ToolbarItem() { Name = "Back", IconTemplate = this.AssociatedObject.grid.Resources["back"] as DataTemplate });
            this.AssociatedObject.editor.ToolbarSettings.ToolbarItemSelected += ToolbarSettings_ToolbarItemSelected;
            this.AssociatedObject.editor.ItemSelected += Editor_ItemSelected;
        }

        private void ToolbarSettings_ToolbarItemSelected(object sender, ToolbarItemSelectedEventArgs e)
        {
            isReplace = false;
            var name = e.ToolbarItem.Name;
            if (name == "Add")
            {
                this.AssociatedObject.notePanel.Visibility = Visibility.Collapsed;
                this.AssociatedObject.ImagePanel.Visibility = Visibility.Visible;
            }
            else if (name == "Replace")
            {
                this.AssociatedObject.notePanel.Visibility = Visibility.Collapsed;
                this.AssociatedObject.ImagePanel.Visibility = Visibility.Visible;
                isReplace = true;
            }
            else if (name == "Front")
            {
                this.AssociatedObject.editor.BringToFront();
            }
            else if (name == "Back")
            {
                this.AssociatedObject.editor.SendToBack();
            }
        }

        private void Image1_Click(object sender, RoutedEventArgs e)
        {
            AddImage("Type1.png");
        }

        private void Image2_Click(object sender, RoutedEventArgs e)
        {
            AddImage("Type2.png");
        }

        private void Image3_Click(object sender, RoutedEventArgs e)
        {
            AddImage("Type3.png");
        }

        private void Image4_Click(object sender, RoutedEventArgs e)
        {
            AddImage("Type4.png");
        }

        private void AddImage(string imageName)
        {
            if (isReplace)
            {
                if (this.AssociatedObject.editor.IsSelected)
                    this.AssociatedObject.editor.Delete();
                else
                    return;
            }

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri("..\\Assets\\ImageEditor\\Overlay Image\\" + imageName, UriKind.Relative);
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
            this.AssociatedObject.editor.AddCustomView(image, customViewSettings);

            this.AssociatedObject.notePanel.Visibility = Visibility.Visible;
            this.AssociatedObject.ImagePanel.Visibility = Visibility.Collapsed;
        }

        private void Editor_ItemSelected(object sender, ItemSelectedEventArgs e)
        {
            if (e.Settings != null && e.Settings is CustomViewSettings)
            {
                selectedViewSettings = e.Settings as CustomViewSettings;
            }

        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()

        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.editor.Loaded -= Editor_Loaded;
            this.AssociatedObject.image1.Click -= Image1_Click;
            this.AssociatedObject.image2.Click -= Image2_Click;
            this.AssociatedObject.image3.Click -= Image3_Click;
            this.AssociatedObject.image4.Click -= Image4_Click;
            this.AssociatedObject.editor.ToolbarSettings.ToolbarItemSelected -= ToolbarSettings_ToolbarItemSelected;
            this.AssociatedObject.editor.ItemSelected -= Editor_ItemSelected;
        }
    }
}
