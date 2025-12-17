using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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

namespace syncfusion.dropdowndemos.wpf
{
    public class GroupDescriptionCollection : ObservableCollection<GroupDescription>
    {

    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CheckListBoxDemo : DemoControl
    {
        public CheckListBoxDemo()
        {
            InitializeComponent();
        }

        public CheckListBoxDemo(string themename): base(themename)
        {
            InitializeComponent();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            this.CheckListBoxGrid.Children.Clear();
            this.CheckListBoxGrid = null;
        }
    }

}
