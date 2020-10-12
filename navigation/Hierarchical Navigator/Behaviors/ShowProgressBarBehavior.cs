#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Controls;
using Syncfusion.Windows.Tools.Controls;
using System.Windows;
using Microsoft.Xaml.Behaviors;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represents the show progress bar action. 
    /// </summary>
    public class ShowProgressBarBehavior : TargetedTriggerAction<Button>
    {
        /// <summary>
        /// Method which invokes the show progress bar action.
        /// </summary>
        /// <param name="parameter">Invokes the show progress bar action</param>
        protected override void Invoke(object parameter)
        {
            var hierarchyNavigator = TargetObject as HierarchyNavigator;
            if (hierarchyNavigator == null)
                return;

            hierarchyNavigator.ShowProgressBar(new TimeSpan(0, 0, 0, 0,ShowValue));
        }

        /// <summary>
        /// Gets or sets the show value.
        /// </summary>
        public int ShowValue
        {
            get { return (int)GetValue(ShowValueProperty); }
            set { SetValue(ShowValueProperty, value); }
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for ShowValue.  This enables animation, styling, binding, etc...
        /// </summary>
       public static readonly DependencyProperty ShowValueProperty =
            DependencyProperty.Register("ShowValue", typeof(int), typeof(ShowProgressBarBehavior), new UIPropertyMetadata(null));
    }
}
