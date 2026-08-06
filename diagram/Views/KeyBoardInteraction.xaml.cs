using syncfusion.demoscommon.wpf;
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
    /// Interaction logic for KeyBoardInteraction.xaml
    /// </summary>
    public partial class KeyBoardInteraction : DemoControl
    {
        public KeyBoardInteraction()
        {
            InitializeComponent();
        }

        public KeyBoardInteraction(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            this.Resources.Clear();
            if (this.DataContext != null)
            {
                this.DataContext = null;
            }
            if (this.DiagramControl != null)
            {
                
                this.DiagramControl.SelectedItems = null;
                this.DiagramControl.HorizontalRuler = null;
                this.DiagramControl.VerticalRuler = null;
                this.DiagramControl = null;
            }
            base.Dispose(disposing);
        }
    }
}
