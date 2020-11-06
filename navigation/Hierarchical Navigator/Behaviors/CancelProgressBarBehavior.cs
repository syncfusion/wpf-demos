#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Controls;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represents the progress bar cancel action.
    /// </summary>
    public class CancelProgressBarBehavior : TargetedTriggerAction<Button>
    {
        /// <summary>
        /// Gets or sets a cancel value.
        /// </summary>
        public int CancelValue
        {
            get { return (int)GetValue(CancelValueProperty); }
            set { SetValue(CancelValueProperty, value); }
        }

        /// <summary>
        /// Method which is used to invoke the cancel progress.
        /// </summary>
        /// <param name="parameter">Invokes cancel progress</param>
        protected override void Invoke(object parameter)
        {
            var hierarchyNavigator = TargetObject as HierarchyNavigator;
            if (hierarchyNavigator == null)
                return;

            hierarchyNavigator.CancelProgressBar(new TimeSpan(0, 0, 0, 0,CancelValue));
        }      

        /// <summary>
        ///  Using a DependencyProperty as the backing store for CancelValue.  This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty CancelValueProperty =
            DependencyProperty.Register("CancelValue", typeof(int), typeof(CancelProgressBarBehavior), new UIPropertyMetadata(null));
    }
}
