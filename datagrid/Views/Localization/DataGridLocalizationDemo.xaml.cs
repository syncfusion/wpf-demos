#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Windows.Shared;
namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for DataGridLocalizationDemo.xaml
    /// </summary>
    public partial class DataGridLocalizationDemo : DemoControl
    {

        public DataGridLocalizationDemo()
        {
            InitializeComponent();
        }

        public DataGridLocalizationDemo(string themename) : base(themename)
        {
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("de-DE");
            // Update the demo assembly resources to our control resources, using resource wrapper class setresources method.
            
            GridLocalizationResourceAccessor.Instance.SetResources(this.GetType().Assembly, "syncfusion.datagriddemos.wpf");
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            //Release all managed resources
            System.Threading.Thread.CurrentThread.CurrentUICulture = DemoBrowserViewModel.AppCulture;
            GridLocalizationResourceAccessor.Instance.SetResources(null, string.Empty);

            //Release all managed resources
            if (this.syncgrid != null)
            {
                this.syncgrid.Dispose();
                this.syncgrid = null;
            }

            if (this.DataContext != null)
                this.DataContext = null;

            if (this.button != null)
                this.button = null;

            base.Dispose(disposing);
        }
    }
}
