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
using System.Globalization;
using Syncfusion.Windows.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.GridCommon;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for CurrencyCell.xaml
    /// </summary>
    public partial class CurrencyCell : DemoControl
    {
        GridStyleInfo g = new GridStyleInfo();
        public CurrencyCell()
        {
            InitializeComponent();
            GridSettings();
        }

        public CurrencyCell(string themename) : base(themename)
        {
            InitializeComponent();
            GridSettings();
        }

        void GridSettings()
        {
            grid.Model.RowCount = 35;
            grid.Model.ColumnCount = 25;
            g = grid.Model[6, 2];
            grid.CurrentCellActivated += new GridRoutedEventHandler(grid_CurrentCellActivated);

            int[] sizes = { 2, 3, 4 };

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(1, 1, 3, 6));
            grid.Model[1, 1].CellValue = "Currency Edit";
            grid.Model[1, 1].Foreground = Brushes.Black;
            grid.Model[1, 1].Background = Brushes.LightBlue;
            grid.Model[1, 1].Font.FontSize = 18;
            grid.Model[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
            grid.Model[1, 1].VerticalAlignment = VerticalAlignment.Center;
            grid.Model[1, 1].Font.FontWeight = FontWeights.Bold;

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(4, 1, 5, 5));
            var cell = grid.Model[4, 1];
            cell.CellValue = "This cell below represents a currency value with \",\" as the decimal separator, \" and represent 4 decimal digits";
            cell.HorizontalAlignment = HorizontalAlignment.Center;
            cell.Font.FontWeight = FontWeights.Bold;
            cell.TextWrapping = TextWrapping.Wrap;

            grid.Model[6, 2].CellType = "CurrencyEdit";
            grid.Model[6, 2].IsEditable = true;
            grid.Model[6, 2].NumberFormat = new NumberFormatInfo { CurrencyDecimalDigits = 4, CurrencyGroupSeparator = ".", CurrencyDecimalSeparator = ",", CurrencyNegativePattern = 0, CurrencyPositivePattern = 0, CurrencySymbol = "$" };
            grid.Model[6, 2].NumberFormat.CurrencyGroupSizes = sizes;
            grid.Model[6, 2].CellValue = 4.0;


            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(8, 1, 9, 5));
            cell = grid.Model[8, 1];
            cell.CellValue = "This cell below represents a currency value with \".\" as the decimal separator and '$' as the currency symbol";
            cell.HorizontalAlignment = HorizontalAlignment.Center;
            cell.Font.FontWeight = FontWeights.Bold;
            cell.TextWrapping = TextWrapping.Wrap;

            grid.Model[10, 2].CellType = "CurrencyEdit";
            grid.Model[10, 2].IsEditable = true;
            grid.Model[10, 2].NumberFormat = new NumberFormatInfo { CurrencyDecimalDigits = 2, CurrencyDecimalSeparator = ".", CurrencyNegativePattern = 5, CurrencyPositivePattern = 1, CurrencySymbol = "$" };
            grid.Model[10, 2].NumberFormat.CurrencyGroupSizes = sizes;
            grid.Model[10, 2].CellValue = 14.0;

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(12, 1, 13, 5));
            cell = grid.Model[12, 1];
            cell.CellValue = "This cell below represents a currency value with \".\" as the decimal separator and '$' as the currency symbol";
            cell.HorizontalAlignment = HorizontalAlignment.Center;
            cell.Font.FontWeight = FontWeights.Bold;
            cell.TextWrapping = TextWrapping.Wrap;

            grid.Model[14, 2].CellType = "CurrencyEdit";
            grid.Model[14, 2].IsEditable = true;
            grid.Model[14, 2].NumberFormat = new NumberFormatInfo { CurrencyDecimalDigits = 4, CurrencyDecimalSeparator = ".", CurrencyNegativePattern = 11, CurrencyPositivePattern = 2, CurrencySymbol = "$" };
            grid.Model[14, 2].NumberFormat.CurrencyGroupSizes = sizes;
            grid.Model[14, 2].CellValue = 36.0;
        }
        void grid_CurrentCellActivated(object sender, SyncfusionRoutedEventArgs args)
        {
            var rowIndex = grid.CurrentCell.RowIndex;
            var colIndex = grid.CurrentCell.ColumnIndex;
            var style = grid.Model[rowIndex, colIndex];
            if (style.CellType == "CurrencyEdit")
            {
                g = style;
                SetPositivePatternCombo();
                SetGroupNumber();
                setDecimalDigits();
                SetSymbol();
            }
        }

        void SetSymbol()
        {
            CurrencySymbol.Text = g.NumberFormat.CurrencySymbol;
        }

        void setDecimalDigits()
        {
            DecimalNo.Text = Convert.ToString(g.NumberFormat.CurrencyDecimalDigits);
        }

        void SetPositivePatternCombo()
        {
            PositivePattern.SelectedIndex = g.NumberFormat.CurrencyPositivePattern;
        }

        void SetGroupNumber()
        {
            String s = "";
            foreach (int i in g.NumberFormat.CurrencyGroupSizes)
                s += i + " ";
            GroupNumber.Text = s;
        }

        private void NegativePatternSelected(object sender, RoutedEventArgs e)
        {
            if (g.NumberFormat != null)
            {
                ComboBoxItem item = sender as ComboBoxItem;
                String symbol = g.NumberFormat.CurrencySymbol;
                int Positive_Pattern = g.NumberFormat.CurrencyPositivePattern;
                int decimals = g.NumberFormat.CurrencyDecimalDigits;
                initialiseNumberFormat(int.Parse(item.Tag.ToString()), Positive_Pattern, decimals, symbol, g.NumberFormat.CurrencyGroupSizes);

            }

        }

        private void initialiseNumberFormat(int negativePattern, int PositivePattern, int decimals, String symbol, int[] size)
        {
            g.NumberFormat = new NumberFormatInfo
            {
                CurrencyPositivePattern = PositivePattern,
                CurrencyDecimalDigits = decimals,
                CurrencyNegativePattern = negativePattern,
                CurrencySymbol = symbol,
                CurrencyDecimalSeparator = g.NumberFormat.CurrencyDecimalSeparator
            };
            g.NumberFormat.CurrencyGroupSizes = size;
        }

        private void PositivePatternSelected(object sender, RoutedEventArgs e)
        {
            if (g.NumberFormat != null)
            {

                String symbol = g.NumberFormat.CurrencySymbol;
                int negative_Pattern = g.NumberFormat.CurrencyNegativePattern;
                int decimals = g.NumberFormat.CurrencyDecimalDigits;
                ComboBoxItem item = sender as ComboBoxItem;

                if (int.Parse(item.Tag.ToString()) == 0)
                    initialiseNumberFormat(negative_Pattern, 0, decimals, symbol, g.NumberFormat.CurrencyGroupSizes);
                else if (int.Parse(item.Tag.ToString()) == 1)
                    initialiseNumberFormat(negative_Pattern, 1, decimals, symbol, g.NumberFormat.CurrencyGroupSizes);
                else if (int.Parse(item.Tag.ToString()) == 2)
                    initialiseNumberFormat(negative_Pattern, 2, decimals, symbol, g.NumberFormat.CurrencyGroupSizes);
                else
                    initialiseNumberFormat(negative_Pattern, 3, decimals, symbol, g.NumberFormat.CurrencyGroupSizes);
            }
        }

        private void SetAll(object sender, RoutedEventArgs e)
        {
            if (!this.grid.CurrentCell.IsEditing)
                this.grid.CurrentCell.BeginEdit();
            int decimals = 0;
            String symbol = "$";
            if (CurrencySymbol.Text != null)
                symbol = CurrencySymbol.Text;
            if (DecimalNo.Text != "")
                try
                {
                    decimals = int.Parse(DecimalNo.Text);
                    int[] IntegerGroup = GetCurrencyGroupSizes();
                    int negative_Pattern = g.NumberFormat.CurrencyNegativePattern;
                    int positive_pattern = g.NumberFormat.CurrencyPositivePattern;
                    initialiseNumberFormat(negative_Pattern, positive_pattern, decimals, symbol, IntegerGroup);
                    //if (this.grid.CurrentCell.Renderer.CurrentCellUIElement != null)
                    //{
                    //    this.grid.CurrentCell.Renderer.RefreshContent();
                    //}
                    this.grid.CurrentCell.EndEdit();
                }
                catch (Exception )
                {
                    MessageBox.Show("Please enter valid input");
                    DecimalNo.Text = "";
                }
        }

        private int[] GetCurrencyGroupSizes()
        {
            if (GroupNumber.Text == "")
                return new int[] { 3 };
            String s = GroupNumber.Text;
            List<int> nos = new List<int>();
            int counter = 0;
            foreach (string subString in s.Split(' '))
            {
                try
                {
                    if (subString == "" || subString == " ")
                        break;
                    nos.Add(int.Parse(subString));
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    GroupNumber.Text = "";
                }
            }
            int[] size = new int[nos.Count];
            foreach (int no in nos)
            {
                if (no != 0)
                    size[counter] = no;
                else
                    size[counter] = no + 2;
                counter++;
            }
            return size;
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
