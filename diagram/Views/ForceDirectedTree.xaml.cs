using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for ForceDirectedTree.xaml
    /// </summary>
    public partial class ForceDirectedTree : DemoControl
    {
        public ForceDirectedTree()
        {
            InitializeComponent();
        }

        public ForceDirectedTree(string themename) : base(themename)
        {
            InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            this.sfdiagram.Loaded += sfdiagram_Loaded;
        }
        private void sfdiagram_Loaded(object sender, RoutedEventArgs e)
        {
              (this.sfdiagram.Info as IGraphInfo).Commands.FitToPage.Execute(null);
        }

        protected override void Dispose(bool disposing)
        {
            if (this.DataContext != null)
            {
                this.DataContext = null;
            }
            if (this.sfdiagram != null)
            {
                this.sfdiagram = null;
            }
            base.Dispose(disposing);
        }
    }
}
