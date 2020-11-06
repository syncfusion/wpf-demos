#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.PropertyGrid;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;
using System;
using System.CodeDom;

namespace syncfusion.propertygriddemos.wpf
{
    public class PropertyGridExpandModeAction : TargetedTriggerAction<PropertyGrid>
    {
        protected override void Invoke(object parameter)
        {
            var propertygrid = TargetObject as PropertyGrid;
            if (propertygrid != null)
            {
                var args = parameter as SelectionChangedEventArgs;
                if (args == null || args.AddedItems.Count <= 0)
                    return;

                PropertyExpandModes expandmode;
                if (Enum.TryParse(args.AddedItems[0].ToString(), out expandmode))
                {
                    propertygrid.PropertyExpandMode = expandmode;
                    propertygrid.RefreshPropertygrid();
                }
            }
        }
    }
}
