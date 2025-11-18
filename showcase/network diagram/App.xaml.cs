using syncfusion.networkdiagram.wpf.Views;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.networkdiagram.wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var window = Activator.CreateInstance(typeof(NetworkDiagramDemo)) as Window;
            window.Show();

            base.OnStartup(e);
        }
    }
}
