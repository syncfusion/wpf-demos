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
    /// Interaction logic for VennDiagram.xaml
    /// </summary>
    public partial class VennDiagram : DemoControl
    {
        private bool loaded = false;
        public VennDiagram()
        {
            InitializeComponent();
        }

        public VennDiagram(string themename) : base(themename)
        {
            InitializeComponent();
            Diagram.ScrollSettings.ScrollLimit = ScrollLimit.Diagram;
            if (this.DataContext != null)
            {
                (this.DataContext as VennDiagramViewModel).View = this;
                (this.DataContext as VennDiagramViewModel).InitializeDiagram();
            }
            SfSkinManager.SetTheme(this, new Syncfusion.SfSkinManager.Theme() { ThemeName = themename });
        }

        protected override void Dispose(bool disposing)
        {
            var viewModel = this.DataContext as VennDiagramViewModel;
            if (viewModel != null)
            {
                viewModel.View = null;
            }
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

        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
            (Diagram.Info as IGraphInfo).ViewPortChangedEvent += VennDiagram_ViewPortChangedEvent;
        }

        private void VennDiagram_ViewPortChangedEvent(object sender, ChangeEventArgs<object, ScrollChanged> args)
        {
            if (Diagram != null && Diagram.Info != null && !loaded && Diagram.IsLoaded && args.NewValue.ContentBounds == args.OldValue.ContentBounds)
            {
              //  (Diagram.Info as IGraphInfo).BringIntoCenter(args.NewValue.ContentBounds);
                Diagram.PageSettings.PageHeight = double.NaN;
                Diagram.PageSettings.PageWidth = double.NaN;
                (Diagram.Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter()
                {
                    Margin = new Thickness(25),
                    FitToPage = FitToPage.FitToPage
                });
                loaded = true;
            }
        }
    }
}
