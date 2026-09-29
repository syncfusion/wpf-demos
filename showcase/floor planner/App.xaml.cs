using syncfusion.floorplanner.wpf;
using System;
using System.Windows;
using Syncfusion.SfSkinManager;

namespace syncfusion.floorplanner.wpf_47
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Syncfusion.Telemetry.Telemetry.Disable();
            SfSkinManager.ApplyThemeAsDefaultStyle = true;
            var window = Activator.CreateInstance(typeof(FloorPlannerDemo)) as Window;
            window.Show();

            base.OnStartup(e);
        }

    }
}
