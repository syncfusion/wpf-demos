using Syncfusion.SfSkinManager;
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

namespace syncfusion.patientmonitor.wpf
{
    /// <summary>
    /// Interaction logic for PatientMonitorDemo.xaml
    /// </summary>
    public partial class PatientMonitorDemo : ChromelessWindow
    {
        public PatientMonitorDemo()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            if (this.sfDataGrid != null)
            {
                this.sfDataGrid.Dispose();
                this.sfDataGrid = null;
            }

            base.OnClosed(e);
        }
    }
}
