using syncfusion.demoscommon.wpf;
using syncfusion.diagramdemo.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Controls;
using Syncfusion.UI.Xaml.Diagram.Stencil;
using Syncfusion.UI.Xaml.Diagram.Theming;
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
using System.Windows.Shapes;
using System.Globalization;


namespace syncfusion.diagramdemo.wpf.Views
{
    /// <summary>
    /// Interaction logic for TicketBookingSystem.xaml
    /// </summary>
    public partial class TicketBookingSystem : DemoControl
    {
        private bool loaded = false;

        public TicketBookingSystem()
        {
            InitializeComponent();
            
        }

        public TicketBookingSystem(string themename) : base(themename)
        {
            InitializeComponent();
            Diagram.ScrollSettings.ScrollLimit = ScrollLimit.Diagram;
            Diagram.Loaded += Diagram_Loaded;
            Diagram.Constraints = Diagram.Constraints.Add(GraphConstraints.Virtualize);
            daybox.Text = DateTime.Now.AddDays(1).ToString("ddd");
            Datebox.Text = DateTime.Now.AddDays(1).ToString("dd MMM");
            (this.DataContext as TicketBookingViewModel).View = this;
            (this.DataContext as TicketBookingViewModel).BuildDiagramNodes();
            SfSkinManager.SetTheme(this, new Syncfusion.SfSkinManager.Theme() { ThemeName = themename });
           
        }

        private void Diagram_Loaded(object sender, RoutedEventArgs e)
        {
            //Fit diagram to show all seats on load
          (Diagram.Info as IGraphInfo).Commands.FitToPage.Execute(new FitToPageParameter
          {
              FitToPage = FitToPage.FitToWidth,
              CanZoomIn = false,
              Margin = new Thickness(70),
          });
            (Diagram.Info as IGraphInfo).ViewPortChangedEvent += TicketBookingSystem_ViewPortChangedEvent;
           
        }

        private void TicketBookingSystem_ViewPortChangedEvent(object sender, ChangeEventArgs<object, ScrollChanged> args)
        {
            if (Diagram != null && Diagram.Info != null && !loaded && Diagram.IsLoaded && args.NewValue.ContentBounds == args.OldValue.ContentBounds)
            {
                Diagram.PageSettings.PageHeight = double.NaN;
                Diagram.PageSettings.PageWidth = double.NaN;
                
                loaded = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            var viewModel = this.DataContext as TicketBookingViewModel;
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

        
    }
}
