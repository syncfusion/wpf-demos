#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.floorplanner.wpf;
using System;
using System.Windows;

namespace syncfusion.floorplanner.wpf_47
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = Activator.CreateInstance(typeof(FloorPlannerDemo)) as Window;
            window.Show();

            base.OnStartup(e);
        }

    }
}
