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
    public class MultipleScaleBehavior : Behavior<MultipleScale>
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
            AssociatedObject.circularGauge.Scales[0].Pointers[0].ValueChanged += MultipleScaleBehavior_ValueChanged;
            AssociatedObject.circularGauge.Scales[1].Pointers[0].ValueChanged += MultipleScaleBehavior_ValueChanged1;
        }

        private void MultipleScaleBehavior_ValueChanged1(object sender, Syncfusion.UI.Xaml.Gauges.ValueChangedEventArgs e)
        {
            if (AssociatedObject.circularGauge.Scales[1].Pointers[0] != null)
                AssociatedObject.circularGauge.Scales[0].Pointers[0].Value = (e.Value / 160) * 240;
        }

        private void MultipleScaleBehavior_ValueChanged(object sender, Syncfusion.UI.Xaml.Gauges.ValueChangedEventArgs e)
        {
            if (AssociatedObject.circularGauge.Scales[0].Pointers[0] != null)
                AssociatedObject.circularGauge.Scales[1].Pointers[0].Value = (e.Value / 240) * 160;
        }

        internal void Dispose()
        {
            AssociatedObject.Loaded -= new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            AssociatedObject.circularGauge.Scales[0].Pointers[0].ValueChanged -= MultipleScaleBehavior_ValueChanged;
            AssociatedObject.circularGauge.Scales[1].Pointers[0].ValueChanged -= MultipleScaleBehavior_ValueChanged1;
        }
    }
}