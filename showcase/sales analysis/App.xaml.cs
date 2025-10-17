using syncfusion.salesanalysis.wpf;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.salesanalysis.wpf_Demo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            var window = Activator.CreateInstance(typeof(SalesAnalysisDemo)) as Window;
            window.Show();

            base.OnStartup(e);
        }
    }
}
