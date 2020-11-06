#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.TreeMap;
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

namespace syncfusion.treemapdemos.wpf
{

    public class RadioButtonBehavior : Behavior<GettingStarted>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        /// <remarks>Override this to hook up functionality to the AssociatedObject.</remarks>
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += AssociatedObject_Loaded;
        }

        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {

            AssociatedObject.Squarified.Checked += Squarified_Checked;
            AssociatedObject.SliceAndDiceAuto.Checked += Squarified_Checked;
            AssociatedObject.SliceAndDiceAuto.IsChecked = true;
            AssociatedObject.SliceAndDiceHorizontal.Checked += Squarified_Checked;
            AssociatedObject.SliceAndDiceVertical.Checked += Squarified_Checked;
        }

        private void Squarified_Checked(object sender, RoutedEventArgs e)
        {
            switch ((sender as RadioButton).Name)
            {
                case "Squarified":
                    AssociatedObject.treeMap.ItemsLayoutMode = TreeMapLayoutMode.Squarified;
                    break;
                case "SliceAndDiceAuto":
                    AssociatedObject.treeMap.ItemsLayoutMode = TreeMapLayoutMode.SliceAndDiceAuto;
                    break;
                case "SliceAndDiceHorizontal":
                    AssociatedObject.treeMap.ItemsLayoutMode = TreeMapLayoutMode.SliceAndDiceHorizontal;
                    break;
                case "SliceAndDiceVertical":
                    AssociatedObject.treeMap.ItemsLayoutMode = TreeMapLayoutMode.SliceAndDiceVertical;
                    break;
            }
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        /// <remarks>Override this to unhook functionality from the AssociatedObject.</remarks>
        protected override void OnDetaching()
        {
            AssociatedObject.Loaded -= AssociatedObject_Loaded;
            AssociatedObject.Squarified.Checked -= Squarified_Checked;
            AssociatedObject.SliceAndDiceAuto.Checked -= Squarified_Checked;
            AssociatedObject.SliceAndDiceHorizontal.Checked -= Squarified_Checked;
            AssociatedObject.SliceAndDiceVertical.Checked -= Squarified_Checked;
        }
    }
}

