using System.Windows;
using System.Windows.Media;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;

namespace VirtualizedCell
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        public Window1()
        {
            InitializeComponent();
            InitializeGridControl();
        }

        private void InitializeGridControl()
        {
            grid.Model.RowCount = 100 + 1;
            grid.Model.ColumnCount = 25 + 1;

            grid.Model.CellModels.Add("VirtualizedCell", new VirtualizedCellModel());
            grid.Model.TableStyle.CellType = "VirtualizedCell";
            grid.Model.TableStyle.CellValue = "Edit Me!";
            grid.Model.HeaderStyle.CellValue = "";
        }
    }
}
