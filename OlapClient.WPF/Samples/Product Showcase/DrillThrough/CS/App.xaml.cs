#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


namespace DrillThrough
{
    using System.Windows;
    using SampleUtils;
    using Syncfusion.Licensing;

    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {            
            SyncfusionLicenseProvider.RegisterLicense(DemoCommon.FindLicenseKey());
        }

    }
}
