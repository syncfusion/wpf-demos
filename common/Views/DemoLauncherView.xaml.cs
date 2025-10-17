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

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Interaction logic for DemoLauncherView.xaml
    /// </summary>
    public partial class DemoLauncherView : UserControl
    {
        Type DemoType;
        public DemoLauncherView(Type DemoViewType)
        {
            InitializeComponent();
            DemoType = DemoViewType;
        }

        /// <summary>
        /// Gets or sets the HyperLinkStyle for the collection of helplinks in the documentation
        /// </summary>
        public Style HyperLinkStyle
        {
            get { return (Style)GetValue(HyperLinkStyleProperty); }
            set { SetValue(HyperLinkStyleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HyperLinkStyle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HyperLinkStyleProperty =
            DependencyProperty.Register("HyperLinkStyle", typeof(Style), typeof(DemoLauncherView), new PropertyMetadata(null));

    }
}
