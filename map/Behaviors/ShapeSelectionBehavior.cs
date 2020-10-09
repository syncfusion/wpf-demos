#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Maps;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace syncfusion.mapdemos.wpf
{
    public class ShapeSelectionBehavior : Behavior<ShapeSelection>
    {
        /// <summary>
        /// Called when [attached].
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
            var map = this.AssociatedObject.map;
            if (map != null)
            {
                map.MouseLeftButtonUp += Map_MouseLeftButtonUp;
                map.MouseLeave += Map_MouseLeave;
                (map.Layers[0] as ShapeFileLayer).ShapesSelected += ShapeSelectionBehavior_ShapesSelected;
            }
            AssociatedObject.listbox.SelectionChanged += Listbox_SelectionChanged;
        }

        private void Listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender != null && (sender as ListBox).SelectedValue != null)
            {
                string str = (sender as ListBox).SelectedValue.ToString();
                foreach (MapShape item in (this.AssociatedObject.map.Layers[0] as ShapeFileLayer).SelectedMapShapes)
                {
                    if (item.ShapeValue != null)
                    {
                        if (item.ShapeValue.ToString().Equals(str))
                        {
                            item.Shape.Fill = new SolidColorBrush(Color.FromArgb(0xFF, 0x8A, 0xC6, 0x3C));
                        }
                        else
                        {
                            item.Shape.Fill = (this.AssociatedObject.map.Layers[0] as ShapeFileLayer).ShapeSettings.SelectedShapeColor;
                        }
                    }
                }
            }
        }

        private void ShapeSelectionBehavior_ShapesSelected(object sender, SelectionEventArgs args)
        {
            ShapeFileLayer shapefilelayer1 = sender as ShapeFileLayer;
            if (shapefilelayer1.SelectedMapShapes.Count == 1 && shapefilelayer1.SelectedMapShapes[0].ShapeValue != null)
            {
                this.AssociatedObject.textblock.Visibility = Visibility.Visible;
                this.AssociatedObject.listbox.Items.Clear();
                this.AssociatedObject.listbox.Items.Add(new ListBoxItem() { Content = shapefilelayer1.SelectedMapShapes[0].ShapeValue.ToString() });
            }
        }

        private void Map_MouseLeave(object sender, MouseEventArgs e)
        {
            this.AssociatedObject.listbox.Items.Clear();

            ShapeFileLayer shapefilelayer1 = (sender as SfMap).Layers[0] as ShapeFileLayer;

            if (shapefilelayer1.SelectedMapShapes.Count > 0)
            {
                var selectedshapes = shapefilelayer1.SelectedMapShapes;
                foreach (MapShape mapshape in selectedshapes)
                {
                    if (mapshape.ShapeValue != null)
                    {
                        this.AssociatedObject.listbox.Items.Add(mapshape.ShapeValue.ToString());
                    }
                }

            }
            if (this.AssociatedObject.listbox.Items != null && this.AssociatedObject.listbox.Items.Count > 0)
            {
                this.AssociatedObject.textblock.Visibility = Visibility.Visible;
            }
            else
            {
                this.AssociatedObject.textblock.Visibility = Visibility.Collapsed;
            }
        }

        private void Map_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            this.AssociatedObject.listbox.Items.Clear();

            ShapeFileLayer shapefilelayer1 = (sender as SfMap).Layers[0] as ShapeFileLayer;

            if (shapefilelayer1.SelectedMapShapes.Count > 0)
            {
                var selectedshapes = shapefilelayer1.SelectedMapShapes;
                foreach (MapShape mapshape in selectedshapes)
                {
                    if (mapshape.ShapeValue != null)
                    {
                        this.AssociatedObject.listbox.Items.Add(mapshape.ShapeValue.ToString());
                    }
                }

            }
            if (this.AssociatedObject.listbox.Items != null && this.AssociatedObject.listbox.Items.Count > 0)
            {
                this.AssociatedObject.textblock.Visibility = Visibility.Visible;
            }
            else
            {
                this.AssociatedObject.textblock.Visibility = Visibility.Collapsed;
            }
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            AssociatedObject.map.MouseLeftButtonUp -= Map_MouseLeftButtonUp;
            AssociatedObject.map.MouseLeave -= Map_MouseLeave;
            (AssociatedObject.map.Layers[0] as ShapeFileLayer).ShapesSelected -= ShapeSelectionBehavior_ShapesSelected;
            AssociatedObject.listbox.SelectionChanged -= Listbox_SelectionChanged;

        }
    }
}