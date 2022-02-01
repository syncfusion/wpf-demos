#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
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

namespace syncfusion.ganttdemos.wpf
{
   public class NumericGanttNodeCustomizationBehavior : Behavior<Border>
    {

        public static Random r = new Random();
        public static string[] nodeColors = new string[] { "#FFFF0094", "#FFA500FF", "#FF00AAAD", "#FF8CBE21", "#FFA55100", "#FFE771BD", "#FFF79608", "#FF18A2E7", "#FFE71400", "#FF319A31" };
        static string prevColor = " ";

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
            Border node = sender as Border;
            node.Background = (Brush)new BrushConverter().ConvertFromString(GetColor());
            node.BorderBrush = node.Background;

        }

        /// <summary>
        /// Gets the color.
        /// </summary>
        /// <returns></returns>
        public static string GetColor()
        {
            string color = nodeColors[r.Next(0, 9)];
            while (prevColor == color)
            {
                color = nodeColors[r.Next(0, 9)];
            }
            prevColor = color;
            return color;
        }

        /// <summary>
        /// Called when [detaching].
        /// </summary>
        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= new RoutedEventHandler(AssociatedObject_Loaded);
        }
    }
}