#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Charts;
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

namespace syncfusion.surfacechartdemos.wpf
{
    class SurfaceandWireframeSurfaceBehavior : Behavior<SurfaceandWireframeSurface>
    {
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
            this.AssociatedObject.surface.Loaded += surface_Loaded;
            this.AssociatedObject.comboBox.SelectionChanged += ComboBox_SelectionChanged;
            this.AssociatedObject.surfaceTypeComboBox.SelectionChanged += SurfaceTypeComboBox_SelectionChanged;
            this.AssociatedObject.surfaceTypeComboBox.SelectedIndex = 0;
            this.AssociatedObject.comboBox.SelectedIndex = 0;
         }

        private void SurfaceTypeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (this.AssociatedObject.surface != null)
            {
                if (comboBox.SelectedIndex == 0)
                    this.AssociatedObject.surface.Type = SurfaceType.Surface;
                else
                    this.AssociatedObject.surface.Type = SurfaceType.WireframeSurface;
            }
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboBox = sender as ComboBox;
            if (this.AssociatedObject.surface != null)
            {
                if (comboBox.SelectedIndex == 0)
                {
                    DataValues = new ObservableCollection<Data>();
                    double inc = 8.0 / 35;
                    for (double x = -4; x < 4; x += inc)
                    {
                        for (double z = -4; z < 4; z += inc)
                        {
                            double y = 2 * (x * x) + 2 * (z * z) - 4;
                            DataValues.Add(new Data() { X = x, Y = y, Z = z });
                        }
                    }
                    this.AssociatedObject.surface.RowSize = 35;
                    this.AssociatedObject.surface.ColumnSize = 35;
                    this.AssociatedObject.surface.ItemsSource = DataValues;
                }

                else if (comboBox.SelectedIndex == 1)
                {
                    DataValues = new ObservableCollection<Data>();
                    double inc = 1.0 / 50;
                    for (double x = 0; x < 1; x += inc)
                    {
                        for (double z = 0; z < 1; z += inc)
                        {
                            double y = Math.Sin((x - 0.5) * 2 * Math.PI) * Math.Sin((z - 0.5) * 2 * Math.PI);
                            DataValues.Add(new Data() { X = x, Y = y, Z = z });
                        }
                    }
                    this.AssociatedObject.surface.RowSize = 50;
                    this.AssociatedObject.surface.ColumnSize = 50;
                    this.AssociatedObject.surface.ItemsSource = DataValues;
                }

                else
                {

                    DataValues = new ObservableCollection<Data>();
                    double inc = 7.0 / 50;
                    for (double x = -3.5; x < 3.5; x += inc)
                    {
                        for (double z = -3.5; z < 3.5; z += inc)
                        {
                            double y = (1 - Math.Cos(x * x + z * z) / (x * x + z * z)) * 1.25;
                            if (y < -3.0) y = 0;
                            DataValues.Add(new Data() { X = x, Y = y, Z = z });
                        }
                    }
                    this.AssociatedObject.surface.RowSize = 50;
                    this.AssociatedObject.surface.ColumnSize = 50;
                    this.AssociatedObject.surface.ItemsSource = DataValues;
                }

            }
        }

        private void surface_Loaded(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.surface.MouseDoubleClick += Surface_OnMouseDoubleClick;
        }

        public ObservableCollection<Data> DataValues { get; set; }

        private void Surface_OnMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            this.AssociatedObject.surface.ZoomLevel = 0.33d;
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            this.AssociatedObject.surface.Loaded -= surface_Loaded;
            this.AssociatedObject.comboBox.SelectionChanged -= ComboBox_SelectionChanged;
            this.AssociatedObject.surfaceTypeComboBox.SelectionChanged -= SurfaceTypeComboBox_SelectionChanged;
        }
    }
}
