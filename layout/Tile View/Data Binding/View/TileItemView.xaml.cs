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
using Syncfusion.Windows.Shared;

namespace syncfusion.layoutdemos.wpf
{
    /// <summary>
    /// Interaction logic for TileViewItem.xaml
    /// </summary>
    public partial class TileItemView : UserControl
    {
        public TileItemView()
        {
            InitializeComponent();
        }

        public TileViewItemState TileViewItemState { get; internal set; }
    }
}
