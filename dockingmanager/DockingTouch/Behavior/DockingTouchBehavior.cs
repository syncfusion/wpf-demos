#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xaml.Behaviors;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.dockingmanagerdemos.wpf
{
    public class DockingTouchBehavior :Behavior<DockingTouch>
    {
        protected override void OnAttached()
        {            
            AssociatedObject.MouseLeftButtonDown += (sender, e) =>
                {
                    if (e.Source.GetType() == typeof(MainWindow))
                        AssociatedObject.DragMove();
                }; 
        }
    }
}
