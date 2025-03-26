#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapgriddemos.wpf
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    using Microsoft.Xaml.Behaviors;

    class CheckBoxUncheckedTriggerAction : TargetedTriggerAction<Appearance>
    {
        #region Fields

        private Brush summaryRowBG, summaryColumnBG, rowHeaderBG, columnHeaderBG, valueCellBG;

        #endregion

        protected override void Invoke(object parameter)
        {
            var eventArgs = parameter as RoutedEventArgs;
            if (eventArgs != null && eventArgs.OriginalSource is CheckBox)
            {
                var checkBox = eventArgs.OriginalSource as CheckBox;
                if (checkBox.Name == "chkclr")
                {
                    if (checkBox.IsChecked.HasValue && checkBox.IsChecked.Value)
                    {
                        this.summaryColumnBG = this.Target.olapGrid.SummaryColumnStyle.Background;
                        this.summaryRowBG = this.Target.olapGrid.SummaryRowStyle.Background;
                        this.rowHeaderBG = this.Target.olapGrid.RowHeaderStyle.Background;
                        this.columnHeaderBG = this.Target.olapGrid.ColumnHeaderStyle.Background;
                        this.valueCellBG = this.Target.olapGrid.ValueCellStyle.Background;
                    }
                    else
                    {
                        this.Target.cmbbox_ColumnHeader.SelectedIndex = this.Target.cmbbox_RowHeader.SelectedIndex = this.Target.cmbbox_SummaryColumn.SelectedIndex = -1;
                        this.Target.cmbbox_SummaryRow.SelectedIndex = this.Target.cmbbox_ValueCell.SelectedIndex = -1;
                        this.Target.olapGrid.SummaryRowStyle.Background = this.summaryRowBG;
                        this.Target.olapGrid.SummaryColumnStyle.Background = this.summaryColumnBG;
                        this.Target.olapGrid.RowHeaderStyle.Background = this.rowHeaderBG;
                        this.Target.olapGrid.ColumnHeaderStyle.Background = this.columnHeaderBG;
                        this.Target.olapGrid.ValueCellStyle.Background = this.valueCellBG;
                        this.Target.olapGrid.Background = null;
                    }
                }
                else
                {
                    this.Target.chkBoxHeaderTooltip.IsChecked = false;
                }
            }
        }
    }
}
