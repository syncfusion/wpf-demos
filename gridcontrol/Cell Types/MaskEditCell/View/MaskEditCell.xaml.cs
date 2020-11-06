#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.ComponentModel;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.GridCommon;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for MaskEditCell.xaml
    /// </summary>
    public partial class MaskEditCell : DemoControl
    {
        GridStyleInfo g = new GridStyleInfo();
        public MaskEditCell()
        {
            InitializeComponent();
            GridSettings();
        }

        public MaskEditCell(string themename) : base(themename)
        {
            InitializeComponent();
            GridSettings();
        }

        void GridSettings()
        {
            grid.Model.RowCount = 50;
            grid.Model.ColumnCount = 25;

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(1, 1, 3, 6));
            grid.Model[1, 1].CellValue = "Mask Edit";
            grid.Model[1, 1].Foreground = Brushes.Black;
            grid.Model[1, 1].Background = Brushes.LightBlue;
            grid.Model[1, 1].Font.FontSize = 18;
            grid.Model[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
            grid.Model[1, 1].VerticalAlignment = VerticalAlignment.Center;
            grid.Model[1, 1].Font.FontWeight = FontWeights.Bold;

            grid.CurrentCellActivated += new GridRoutedEventHandler(grid_CurrentCellActivated);

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(4, 1, 5, 6));
            var cell = this.grid.Model[4, 1];
            cell.CellValue = "This sample shows how mask edit cells behave.We can set the mask string for effective masking.";
            cell.HorizontalAlignment = HorizontalAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.Font.FontWeight = FontWeights.Bold;

            var maskStyleInfo = this.grid.Model[6, 2];
            maskStyleInfo.CellType = "MaskEdit";
            maskStyleInfo.MaskEdit = GridMaskEditInfo.Default;
            maskStyleInfo.MaskEdit.Mask = "00/00/0000";
            maskStyleInfo.CellValue = 1232313;

            // g = maskStyleInfo;

            var maskStyleInfo1 = this.grid.Model[8, 2];
            maskStyleInfo1.CellType = "MaskEdit";
            maskStyleInfo1.MaskEdit = GridMaskEditInfo.Default;
            maskStyleInfo1.MaskEdit.Mask = "00:00:00";
            maskStyleInfo1.CellValue = 1232313;

            var maskStyleInfo2 = this.grid.Model[10, 2];
            maskStyleInfo2.CellType = "MaskEdit";
            maskStyleInfo2.MaskEdit = GridMaskEditInfo.Default;
            maskStyleInfo2.MaskEdit.Mask = "00/00/0000";
            maskStyleInfo2.CellValue = "12012007";
        }
        void grid_CurrentCellActivated(object sender, SyncfusionRoutedEventArgs args)
        {
            GridControlBase current_cell = args.Source as GridControlBase;
            if (grid.Model[current_cell.CurrentCell.RowIndex, current_cell.CurrentCell.ColumnIndex].CellType == "MaskEdit")
            {
                g = grid.Model[current_cell.CurrentCell.RowIndex, current_cell.CurrentCell.ColumnIndex];
                SetDateSeparatorText();
                SetTimeSeparatorText();
                SetNumberDecimalSeparatorText();
                //SetNumberGroupSeparatorText();
                //SetCurrencySymbolText();
                SetPromptCharText();
                SetMaskStringText();
            }
        }

        void SetDateSeparatorText()
        {
            DateSeparator.Text = g.MaskEdit.DateSeparator;
        }

        void SetTimeSeparatorText()
        {
            TimeSeparator.Text = g.MaskEdit.TimeSeparator;
        }

        void SetNumberDecimalSeparatorText()
        {
            NumberDecimalSeparator.Text = g.MaskEdit.DecimalSeparator;
        }

        void SetNumberGroupSeparatorText()
        {
            //NumberGroupSeparator.Text = g.MaskEdit.NumberGroupSeparator;
        }

        void SetCurrencySymbolText()
        {
            //CurrencySymbol.Text = g.MaskEdit.CurrencySymbol;
        }

        void SetPromptCharText()
        {
            PromptChar.Text = Convert.ToString(g.MaskEdit.PromptChar);
        }

        void SetMaskStringText()
        {
            MaskString.Text = g.MaskEdit.Mask;
        }

        private void SetAll(object sender, RoutedEventArgs e)
        {
            try
            {
                if (DateSeparator.Text != "" && TimeSeparator.Text != "" && NumberDecimalSeparator.Text != "" && PromptChar.Text != "" && MaskString.Text != "")
                {
                    g.MaskEdit.DateSeparator = DateSeparator.Text;
                    g.MaskEdit.TimeSeparator = TimeSeparator.Text;
                    g.MaskEdit.DecimalSeparator = NumberDecimalSeparator.Text;
                    //g.MaskEdit.NumberGroupSeparator = NumberGroupSeparator.Text;
                    //g.MaskEdit.CurrencySymbol = CurrencySymbol.Text;
                    g.MaskEdit.PromptChar = Convert.ToChar(PromptChar.Text);
                    g.MaskEdit.Mask = MaskString.Text;
                    this.grid.CurrentCell.EndEdit();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (this.grid != null)
            {
                this.grid.Dispose();
                this.grid = null;
            }
            base.Dispose(disposing);
        }
    }
}
