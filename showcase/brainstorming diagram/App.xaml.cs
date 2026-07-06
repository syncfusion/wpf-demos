using Syncfusion.Licensing;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using syncfusion.brainstormingdiagram.wpf;
using Syncfusion.SfSkinManager;

namespace syncfusion.brainstormingdiagram.wpf_47
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            SfSkinManager.ApplyThemeAsDefaultStyle = true;
            var window = Activator.CreateInstance(typeof(BrainstormingDiagramDemo)) as Window;
            window.Show();
            base.OnStartup(e);
        }
    }
}
