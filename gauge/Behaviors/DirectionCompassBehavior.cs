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

namespace syncfusion.gaugedemos.wpf
{
    public class DirectionCompassBehavior : Behavior<DirectionCompass>
    {
        /// <summary>
        /// Called when [attached].
        /// </summary>
        protected override void OnAttached()
        {
            AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        private void EventsBehavior_LabelCreated(object sender, Syncfusion.UI.Xaml.Gauges.LabelCreatedEventArgs args)
        {
            switch ((string)args.LabelText)
            {
                case "0":
                    args.LabelText = "N";
                    break;
                case "1":
                    args.LabelText = "NE";
                    break;
                case "2":
                    args.LabelText = "E";
                    break;
                case "3":
                    args.LabelText = "SE";
                    break;
                case "4":
                    args.LabelText = "S";
                    break;
                case "5":
                    args.LabelText = "SW";
                    break;
                case "6":
                    args.LabelText = "W";
                    break;
                case "7":
                    args.LabelText = "NW";
                    break;
            }
        }

        /// <summary>
        /// Handles the Loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            AssociatedObject.circularGauge.Scales[0].LabelCreated += EventsBehavior_LabelCreated;
            AssociatedObject.circularGauge.Scales[0].InvalidateMeasure();
            AssociatedObject.circularGauge.Scales[0].ShowLastLabel = false;
        }

        internal void Dispose()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            AssociatedObject.circularGauge.Scales[0].LabelCreated -= EventsBehavior_LabelCreated;
        }
    }
}