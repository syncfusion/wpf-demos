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
