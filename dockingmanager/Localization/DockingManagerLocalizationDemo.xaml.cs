#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Controls.Input.Resources;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System.Reflection;

namespace syncfusion.dockingmanagerdemos.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>

    public partial class DockingManagerLocalizationDemo : DemoControl
    {
        public DockingManagerLocalizationDemo()
        {
            InitializeComponent();
        }

        public DockingManagerLocalizationDemo(string themename) : base(themename)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr-FR");
            ToolsLocalizationResourceAccessor.Instance.SetResources(this.GetType().Assembly, "syncfusion.dockingmanagerdemos.wpf");
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            System.Threading.Thread.CurrentThread.CurrentUICulture = DemoBrowserViewModel.AppCulture;
            ToolsLocalizationResourceAccessor.Instance.SetResources(null, string.Empty);
            if (this.dockingManager != null)
            {
                this.dockingManager.Dispose();
                this.dockingManager = null;
            }
            base.Dispose(disposing);
        }
    }
}
