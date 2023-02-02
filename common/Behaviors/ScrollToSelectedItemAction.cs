#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.SfSkinManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.demoscommon.wpf
{
    public class ScrollToSelectedItemAction : Behavior<ListView>
    {
        /// <summary>
        /// Called after the behavior is attached to an AssociatedObject.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SelectionChanged += AssociatedObject_SelectionChanged;
        }

        /// <summary>
        /// Occurs when the selection of product demos
        /// </summary>
        void AssociatedObject_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sender is ListView)
            {
                ListView demolist = (sender as ListView);
                if (demolist.SelectedItem != null)
                {
                    demolist.ScrollIntoView(demolist.SelectedItem);
                }
            }
        }

        /// <summary>
        /// Called when the behavior is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.SelectionChanged -= AssociatedObject_SelectionChanged;

        }
    }
}