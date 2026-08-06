using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
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
    /// Interaction logic for Constraints.xaml
    /// </summary>
    public partial class Constraints : DemoControl
    {
        public Constraints()
        {
            InitializeComponent();
        }

        public Constraints(string themename) : base(themename)
        {
            InitializeComponent();
            this.DataContext = new ConstraintsViewModel(this);
        }

        private void SfDiagram_Loaded(object sender, RoutedEventArgs e)
        {
            FitToPageParameter fitToPage = new FitToPageParameter() { FitToPage = FitToPage.FitToPage };
            (Diagram.Info as IGraphInfo).Commands.FitToPage.Execute(fitToPage);
        }

        protected override void Dispose(bool disposing)
        {
            if (this.DataContext != null)
            {
                this.DataContext = null;
            }
            if (this.Diagram != null)
            {
                this.Diagram = null;
            }
            base.Dispose(disposing);
        }
    }
}
