using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;

namespace MarkHiddenSelections
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        public Window1()
        {
            InitializeComponent();
            sampleGrid1.Model.RowCount = 30;
            sampleGrid1.Model.ColumnCount = 25;
            sampleGrid1.Model.ColumnWidths.SetHidden(5, 10, true);
            sampleGrid1.Model.Options.HiddenBorderBrush = Brushes.Black;
            sampleGrid1.Model.Options.HiddenBorderThickness = 2d;
            sampleGrid1.Model.Options.AllowExcelLikeResizing = true;
        }
    }
}
