using Microsoft.Xaml.Behaviors;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Helpers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Class for representing the trigger to apply the end edit action for sfdatagrid. 
    /// </summary>
    public class ComboBoxCellEndEditTrigger : TargetedTriggerAction<SfDataGrid>
    {
        protected override void Invoke(object parameter)
        {
            CurrentCellEndEditEventArgs args = parameter as CurrentCellEndEditEventArgs;
            var sfDataGrid = this.Target as SfDataGrid;
            if (sfDataGrid.CurrentColumn.MappingName != "ShipCountry")
                return;
            var datarow = sfDataGrid.RowGenerator.Items.FirstOrDefault(dr => dr.RowIndex == args.RowColumnIndex.RowIndex);
            datarow.Element.DataContext = null;
            sfDataGrid.UpdateDataRow(args.RowColumnIndex.RowIndex);
        }
    }
}
