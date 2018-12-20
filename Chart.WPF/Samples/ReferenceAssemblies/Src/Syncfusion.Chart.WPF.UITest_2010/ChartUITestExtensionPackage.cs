#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using System.Windows;

[assembly: Microsoft.VisualStudio.TestTools.UITest.Extension.UITestExtensionPackage(
                "ChartUITestExtensionPackage",
                typeof(Syncfusion.Chart.WPF.UITest.ChartUITestExtensionPackage))]

namespace Syncfusion.Chart.WPF.UITest
{
    internal class ChartUITestExtensionPackage : UITestExtensionPackage
    {
        public override object GetService(Type serviceType)
        {
            if (serviceType == typeof(UITestPropertyProvider))
            {
                if (propertyProvider == null) { propertyProvider = new ChartPropertyProvider(); }
                return propertyProvider;
            }            
            return null;
        }

        public override void Dispose() { }
        public override string PackageDescription { get { return "Plugin for VSTT Reocrd and Playback support on Chart applications"; } }
        public override string PackageName { get { return "VSTT Chart Plugin"; } }
        public override string PackageVendor { get { return "Syncfusion Inc.,"; } }
        public override Version PackageVersion { get { return new Version(1, 0); } }
        public override Version VSVersion { get { return new Version(10, 0); } }

        private UITestPropertyProvider propertyProvider; 
    }
}
