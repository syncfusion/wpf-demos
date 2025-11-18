using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;

namespace syncfusion.formulaanalysis.wpf
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
            var window = Activator.CreateInstance(typeof(FormulaAnalysisDemo)) as Window;
            window.Show();
            base.OnStartup(e);
        }
    } 
}
