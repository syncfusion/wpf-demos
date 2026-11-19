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

namespace syncfusion.ganttdemos.wpf
{
    /// <summary>
    /// Interaction logic for CustomizedTable.xaml
    /// </summary>
    public partial class CustomizedTable : DemoControl
    {
        CustomizedTableViewModel customizedTableViewModel;
        public CustomizedTable()
        {
            InitializeComponent();
        }

        public CustomizedTable(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (customizedTableViewModel == null)
                customizedTableViewModel = this.DataContext as CustomizedTableViewModel;

            customizedTableViewModel.Dispose();
            base.Dispose(disposing);
        }
    }
}
