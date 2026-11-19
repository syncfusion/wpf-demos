using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Shared;
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

namespace syncfusion.treegriddemos.wpf
{
    /// <summary>
    /// The demo view that hosts the tree grid and the search panel and manages their lifecycle.
    /// </summary>
    public partial class SearchPanelDemo : DemoControl
    {
        /// <summary>
        /// Initializes the demo view and loads the associated XAML components.
        /// </summary>
        public SearchPanelDemo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes the demo view with a given theme name and loads the associated XAML components.
        /// </summary>
        public SearchPanelDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        /// <summary>
        /// Cleans up managed resources used by the view, including the grid, view model, and search control.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();

            // Release all managed resources
            if (this.treeGrid != null)
            {
                this.treeGrid.Dispose();
                this.treeGrid = null;
            }

            if (this.DataContext != null)
            {
                var dataContext = this.DataContext as EmployeeInfoViewModel;
                if (dataContext != null)
                {
                    dataContext.Dispose();
                }
                this.DataContext = null;
            }

            if (this.searchControl != null)
            {
                this.searchControl.Dispose();
                this.searchControl = null;
            }

            base.Dispose(disposing);
        }
    }
}
