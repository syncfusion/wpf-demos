#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using System.Windows.Controls;

namespace syncfusion.demoscommon.wpf
{
    public class NavigateHomePageAction : TriggerAction<Button>
    {
        protected override void Invoke(object parameter)
        {
            //if (DemosNavigationService.RootNavigationService.CanGoBack)
            {
                DemosNavigationService.RootNavigationService.Content = null;
            }
        }
    }
}