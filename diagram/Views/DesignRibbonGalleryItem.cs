#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.diagramdemo.wpf.ViewModel;
using Syncfusion.UI.Xaml.Diagram.Theming;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    ///  Represents a RibbonGalleryItem control.
    /// </summary>
    /// <remarks>RibbonGalleryItem class represents a control that is used to wrap any content inside the Ribbon gallery control.</remarks>
    public class DesignRibbonGalleryItem : RibbonGalleryItem
    {
        /// <summary>
        /// Initializes a new instance of the DesignRibbonGalleryItem class.
        /// </summary>
        public DesignRibbonGalleryItem()
        {
            this.Loaded += DesignRibbonGalleryItem_Loaded;
        }
        /// <summary>
        /// Occurs when the element is laid out, rendered, and ready for interaction.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DesignRibbonGalleryItem_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.Name.ToString().Equals("Custom1_ThemeRibbon"))
            {

            }
            if (this.DataContext != null)
            {
                Theme = (this.DataContext as ThemeStyleViewModel).View.Resources[this.Name.ToString()] as DiagramTheme;
                ContentTemplate = (this.DataContext as ThemeStyleViewModel).View.Resources["ribbonItemTemplate"] as DataTemplate;
            }
        }
        /// <summary>
        /// Represent the theme of the diagram.
        /// </summary>
        internal DiagramTheme Theme
        {
            get { return (DiagramTheme)GetValue(ThemeProperty); }
            set { SetValue(ThemeProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Theme.  This enables animation, styling, binding, etc...
        internal static readonly DependencyProperty ThemeProperty =
            DependencyProperty.Register("Theme", typeof(DiagramTheme), typeof(DesignRibbonGalleryItem), new PropertyMetadata(null, OnThemeChanged));

        private static void OnThemeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DesignRibbonGalleryItem item = d as DesignRibbonGalleryItem;
            if (item.Theme != null)
            {
                item.Content = new GalleryStyle();
                if (item.Theme.NodeStyles != null)
                {
                    (item.Content as GalleryStyle).Variant1 = item.Theme.NodeStyles[StyleId.Variant1];
                    (item.Content as GalleryStyle).Variant2 = item.Theme.NodeStyles[StyleId.Variant2];
                    (item.Content as GalleryStyle).Variant3 = item.Theme.NodeStyles[StyleId.Variant3];
                    (item.Content as GalleryStyle).Variant4 = item.Theme.NodeStyles[StyleId.Variant4];
                }
                if (item.Theme.ConnectorStyles != null)
                {
                    (item.Content as GalleryStyle).ConnectorVariant = (d as DesignRibbonGalleryItem).Theme.ConnectorStyles[StyleId.Subtly | StyleId.Accent1];
                }
            }
        }
    }
}
