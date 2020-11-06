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
    public class ElectionResultDemoBehavior : Behavior<ElectionResultDemo>
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
            if (this.AssociatedObject.map != null)
            {
                var layer = this.AssociatedObject.map.Layers[0] as ShapeFileLayer;
                if (layer != null)
                {
                    layer.ShapesSelected += ElectionResultDemoBehavior_ShapesSelected;
                    layer.ShapesUnSelected += ElectionResultDemoBehavior_ShapesUnSelected;

                }
            }
        }


        private void ElectionResultDemoBehavior_ShapesUnSelected(object sender, SelectionEventArgs args)
        {
            if (this.AssociatedObject.Properties_Panel != null)
            {
                this.AssociatedObject.Properties_Panel.Visibility = Visibility.Collapsed;
            }
        }

        private void ElectionResultDemoBehavior_ShapesSelected(object sender, SelectionEventArgs args)
        {
            if (this.AssociatedObject.Properties_Panel != null && this.AssociatedObject.Properties_Panel.Visibility == Visibility.Collapsed)
            {
                this.AssociatedObject.Properties_Panel.Visibility = Visibility.Visible;
            }
            if (this.AssociatedObject.shapeLayer != null && args.Items is ObservableCollection<MapShape>)
            {
                ObservableCollection<MapShape> mapShapes = (args.Items as ObservableCollection<MapShape>);
                if (mapShapes != null && mapShapes.Count > 0)
                {
                    var selectedShape = (mapShapes[0] as MapShape);
                    if (selectedShape != null && selectedShape.DataContext is ElectionData)
                    {
                        this.AssociatedObject.txt_State.Text = (selectedShape.DataContext as ElectionData).State;
                        this.AssociatedObject.txt_Winner.Text = (selectedShape.DataContext as ElectionData).Candidate;
                        this.AssociatedObject.txt_Electors.Text = (selectedShape.DataContext as ElectionData).Electors.ToString();
                    }
                }
            }
        }


        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            var layer = this.AssociatedObject.map.Layers[0] as ShapeFileLayer;
            if (layer != null)
            {
                layer.ShapesSelected -= ElectionResultDemoBehavior_ShapesSelected;
                layer.ShapesUnSelected -= ElectionResultDemoBehavior_ShapesUnSelected;
            }
        }
    }
}