#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Globalization;
using System.IO;
using System.Xml;
using Syncfusion.Windows.Controls.Cells;

namespace syncfusion.gridcontroldemos.wpf
{
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
    using Syncfusion.Windows.Shared;
    using System.Reflection;
    using Syncfusion.Windows.GridCommon;
    using syncfusion.demoscommon.wpf;

    /// <summary>
    /// Interaction logic for CopyToClipboard.xaml
    /// </summary>
    public partial class CopyToClipboard : DemoControl
    {

        Brush[] colors = new Brush[] { Brushes.Red, Brushes.Yellow, Brushes.Gray, Brushes.Honeydew, Brushes.Pink, Brushes.Orange };

        private string[] fontfamilys = new string[] { "Calibri", "Algerian", "Times New Roman", "Arial", "Brush Script MT", "Comic Sans MS" };
        Pen[] colors1 = new Pen[] {
                                new Pen(Brushes.Firebrick ,2) ,new Pen(Brushes.Khaki,2) ,new Pen( Brushes.Ivory ,2) ,new Pen( Brushes.DarkOliveGreen,2) ,new Pen(Brushes.DarkSlateGray,2) ,new Pen( Brushes.Firebrick  ,2),new Pen( Brushes.ForestGreen   ,2),new Pen( Brushes.LemonChiffon   ,2),new Pen( Brushes.LightSalmon    ,2),new Pen( Brushes.MediumPurple    ,2)
        };

        private List<string> Instructions = new List<string>();



        int rowIndex = 4;
        int colIndex = 1;
        int[] sizes = { 2, 3, 4 };
        Itemsource source = new Itemsource();
        public CopyToClipboard()
        {
            InitializeComponent();
            GridSettings();
        }
        public CopyToClipboard(string themename) : base(themename)
        {
            InitializeComponent();
            GridSettings();
        }

        void GridSettings()
        {

            Random r = new Random();
            grid.Model.RowCount = 62;
            grid.Model.ColumnCount = 25;
            gridControl1.Model.RowCount = 62;
            gridControl1.Model.ColumnCount = 25;

            grid.Model.CoveredCells.Add(new CoveredCellInfo(2, 2, 3, 6));
            grid.Model[2, 2].CellValue = "Grid Control 1";
            grid.Model[2, 2].Font.FontSize = 21;
            grid.Model[2, 2].Font.FontWeight = FontWeights.Bold;
            grid.Model[2, 2].Font.FontFamily = new FontFamily(fontfamilys[2]);

            grid_DateTimeEdit();
            grid_CurrencyCellType();
            grid_DoubleCellType();
            grid_IntegerCellType();
            grid_MaskEdit();
            grid_PercentEdit();
            grid_UpDownEdit();
            AddComboBoxes();
            AddDropDownLists();
            rowIndex += 6;
            AddInstructions();
            grid.Model[rowIndex, colIndex].Text = "Static Cells - cannot be edited";
            rowIndex++;
            grid.Model[rowIndex, colIndex].Text = "Static";
            grid.Model[rowIndex, colIndex].CellType = "Static";
            grid.Model[rowIndex, colIndex + 1].Text = "Static2";
            grid.Model[rowIndex, colIndex + 1].CellType = "Static";

            grid.Model.CoveredCells.Add(new CoveredCellInfo(7, 1, 7, 4));
            rowIndex += 2;
            grid.Model[rowIndex, colIndex].Text = "Header Cells - used as row and column headers";
            rowIndex++;
            grid.Model[rowIndex, colIndex].Text = "HeaderText";
            grid.Model[rowIndex, colIndex].CellType = "Header";
            grid.Model[rowIndex, colIndex].Background = Brushes.LightCyan;
            grid.Model[rowIndex, colIndex + 2].Text = "HeaderText2";
            grid.Model[rowIndex, colIndex + 2].CellType = "Header";
            grid.Model[rowIndex, colIndex + 2].Background = Brushes.LightCyan;

            grid.Model.CoveredCells.Add(new CoveredCellInfo(10, 1, 10, 2));
            rowIndex += 2;
            grid.Model[rowIndex, colIndex].Text = "Checkbox Cells ";
            rowIndex++;
            grid.Model[rowIndex, colIndex].CellValue = false;
            grid.Model[rowIndex, colIndex].Description = "Click Me";
            grid.Model[rowIndex, colIndex].CellType = "CheckBox";

            grid.Model[rowIndex, colIndex + 1].CellValue = true;
            grid.Model[rowIndex, colIndex + 1].CellType = "CheckBox";
            grid.Model[rowIndex, colIndex + 1].Description = "TriState";

            grid.Model[rowIndex, colIndex + 2].Text = "True";
            grid.Model[rowIndex, colIndex + 2].CellType = "CheckBox";
            grid.Model[rowIndex, colIndex + 2].Description = "Disabled";
            grid.Model[rowIndex, colIndex + 2].Enabled = false;
            grid.Model[rowIndex, colIndex + 2].CellValue = true;

            rowIndex += 2;
            grid.Model[rowIndex, colIndex].Text = "Button Cells ";
            rowIndex++;
            grid.Model[rowIndex, colIndex].Description = "Button1";
            grid.Model[rowIndex, colIndex].CellType = "Button";
            grid.Model[rowIndex, colIndex + 2].Description = "Button2";
            grid.Model[rowIndex, colIndex + 2].CellType = "Button";
            grid.Model[rowIndex, colIndex + 4].Description = "Button3";
            grid.Model[rowIndex, colIndex + 4].CellType = "Button";


            rowIndex += 2;
            grid.Model[rowIndex, colIndex].Text = "Image Cells";
            rowIndex++;
            grid.Model.RowHeights[rowIndex] = 100;
            grid.Model[rowIndex, colIndex].CellValue = new BitmapImage(new Uri(@"/syncfusion.gridcontroldemos.wpf;component/Assets/GridControl/Flowers/Sunset.jpg", UriKind.Relative));
            grid.Model[rowIndex, colIndex].CellType = "ImageCell";
            grid.Model[rowIndex, colIndex + 2].CellValue = new BitmapImage(new Uri(@"/syncfusion.gridcontroldemos.wpf;component/Assets/GridControl/Flowers/Water lilies.jpg", UriKind.Relative));
            grid.Model[rowIndex, colIndex + 2].CellType = "ImageCell";
            grid.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;
            rowIndex = rowIndex + 2;
            grid.Model[rowIndex, colIndex].CellValue = "Formula Cells";
            grid.Model[rowIndex, colIndex].CellType = "Static";
            rowIndex++;
            grid.Model[rowIndex, colIndex].CellValue = "Currency";
            grid.Model[rowIndex, colIndex].CellType = "Static";
            grid.Model[rowIndex, colIndex + 2].CellValue = "Rate";
            grid.Model[rowIndex, colIndex + 2].CellType = "Static";
            grid.Model[rowIndex, colIndex + 1].CellValue = "Formula value";
            grid.Model[rowIndex, colIndex + 1].CellType = "Static";
            rowIndex++;
            grid.Model[rowIndex, colIndex].CellValue = "USD";
            grid.Model[rowIndex, colIndex].CellType = "Static";
            grid.Model[rowIndex, colIndex + 2].CellValue = 100;
            grid.Model[rowIndex, colIndex + 2].CellType = "TextBox";
            rowIndex++;
            grid.Model[rowIndex, colIndex].CellValue = "AUD";
            grid.Model[rowIndex, colIndex].CellType = "Static";
            grid.Model[rowIndex, colIndex + 1].CellValue = "=" + GridRangeInfo.GetAlphaLabel(colIndex + 2).ToString() + GridRangeInfo.GetNumericLabel(rowIndex - 1).ToString() + " * 0.95";
            grid.Model[rowIndex, colIndex + 1].CellType = "TextBox";
            grid.Model[rowIndex, colIndex + 2].Text = grid.Model[rowIndex, colIndex + 1].CellValue.ToString();
            grid.Model[rowIndex, colIndex + 2].CellType = "FormulaCell";

            rowIndex++;
            grid.Model[rowIndex, colIndex].CellValue = "INR";
            grid.Model[rowIndex, colIndex].CellType = "Static";
            grid.Model[rowIndex, colIndex + 1].CellValue = "=" + GridRangeInfo.GetAlphaLabel(colIndex + 2).ToString() + GridRangeInfo.GetNumericLabel(rowIndex - 2).ToString() + " * 0.45";
            grid.Model[rowIndex, colIndex + 1].CellType = "TextBox";
            grid.Model[rowIndex, colIndex + 2].Text = grid.Model[rowIndex, colIndex + 1].CellValue.ToString();
            grid.Model[rowIndex, colIndex + 2].CellType = "FormulaCell";
            rowIndex++;

            gridControl1.Model.CoveredCells.Add(new CoveredCellInfo(2, 2, 3, 6));
            gridControl1.Model[2, 2].CellValue = "Grid Control 2";
            gridControl1.Model[2, 2].Font.FontSize = 21;
            gridControl1.Model[2, 2].Font.FontWeight = FontWeights.Bold;
            gridControl1.Model[2, 2].Font.FontFamily = new FontFamily(fontfamilys[2]);

            int row;
            for (row = 6; row < 60; row++)
            {
                for (var col = 1; col < 10; col++)
                {
                    var v = r.Next(100);
                    if (v < 80) continue;

                    if (v % 2 == 0)
                    {
                        gridControl1.Model[row, col].Text = (r.Next(1000, 5000) * .002).ToString();
                        gridControl1.Model[row, col].Background = this.colors[v % colors.Length];

                        gridControl1.Model[row, col].Font.FontWeight = FontWeights.Bold;
                    }
                    if (v % 3 == 0)
                    {
                        gridControl1.Model[row, col].HorizontalAlignment = HorizontalAlignment.Right;
                        gridControl1.Model[row, col].Font.FontStyle = FontStyles.Italic;
                    }
                    if (v % 4 == 0)
                    {

                        gridControl1.Model[row, col].Font.FontSize = 18;

                    }
                    if (v % 5 == 0)
                    {
                        gridControl1.Model[row, col].Foreground = colors[v % colors.Length];
                        gridControl1.Model[row, col].Text = "Text :" + (r.Next(1000, 5000) * .002);
                        gridControl1.Model[row, col].Font.FontFamily = new FontFamily(fontfamilys[v % fontfamilys.Length]);

                    }
                    if (v % 6 == 0)
                    {
                        gridControl1.Model[row, col].Text = "Static";
                        gridControl1.Model[row, col].CellType = "Static";
                        gridControl1.Model[row, col + 1].Text = "Static2";
                        gridControl1.Model[row, col + 1].CellType = "Static";
                    }
                    if (v % 7 == 0)
                    {
                        gridControl1.Model[row, col].Text = (r.Next(1000, 5000) * .002).ToString();
                        gridControl1.Model[row, col].Font.FontSize = 24;
                    }
                }
            }
            grid.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;
            gridControl1.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;
            grid.Model.Options.CopyPasteOption = CopyPaste.CopyText | CopyPaste.CutText | CopyPaste.PasteText;
            gridControl1.Model.Options.CopyPasteOption = CopyPaste.CopyText | CopyPaste.CutText | CopyPaste.PasteText;
            CopyButton1.CommandTarget = grid;
            CutButton1.CommandTarget = grid;
            PasteButton1.CommandTarget = grid;
            CopyButton2.CommandTarget = gridControl1;
            CutButton2.CommandTarget = gridControl1;
            PasteButton2.CommandTarget = gridControl1;
            grid.Model.Options.ActivateCurrentCellBehavior = GridCellActivateAction.DblClickOnCell;
            grid.QueryCellInfo += new GridQueryCellInfoEventHandler(gridControl_QueryCellInfo);
            gridControl1.QueryCellInfo += new GridQueryCellInfoEventHandler(gridControl1_QueryCellInfo);
            Clipboard.Clear();
            Instructionbox.Text = Instructions[0];
            this.textBox1.Text = Clipboard.GetText();
        }
        void gridControl1_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if ((e.Cell.RowIndex == 0 || e.Cell.ColumnIndex == 0) && (e.Cell.ColumnIndex != e.Cell.RowIndex))
            {
                e.Style.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                if (e.Cell.RowIndex == 0)
                {
                    e.Style.CellValue = GridRangeInfo.GetAlphaLabel(e.Cell.ColumnIndex);

                }
                if (e.Cell.ColumnIndex == 0)
                {
                    e.Style.CellValue = GridRangeInfo.GetNumericLabel(e.Cell.RowIndex);
                }
            }
        }

        void gridControl_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if ((e.Cell.RowIndex == 0 || e.Cell.ColumnIndex == 0) && (e.Cell.ColumnIndex != e.Cell.RowIndex))
            {
                e.Style.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
                if (e.Cell.RowIndex == 0)
                {
                    e.Style.CellValue = GridRangeInfo.GetAlphaLabel(e.Cell.ColumnIndex);
                }
                if (e.Cell.ColumnIndex == 0)
                {
                    e.Style.CellValue = GridRangeInfo.GetNumericLabel(e.Cell.RowIndex);
                }
            }
        }

        private void AddComboBoxes()
        {
            List<String> list = new List<string>();

            list.Add("One");
            list.Add("Two");
            list.Add("Three");
            list.Add("Four");
            list.Add("Five");
            this.grid.Model[5, 6].CellValue = "Combo Box types";
            this.grid.Model[6, 6].CellValue = "Editable";
            this.grid.Model[7, 6].CellValue = "AutoComplete";
            this.grid.Model[8, 6].CellValue = "Exclusive";
            var combo1 = this.grid.Model[6, 7];

            combo1.CellType = "ComboBox";
            combo1.ItemsSource = list;
            combo1.DropDownStyle = GridDropDownStyle.Editable;

            var combo2 = this.grid.Model[7, 7];
            combo2.CellType = "ComboBox";
            combo2.ItemsSource = list;
            combo2.DropDownStyle = GridDropDownStyle.AutoComplete;

            var combo3 = this.grid.Model[8, 7];
            combo3.CellType = "ComboBox";
            combo3.ItemsSource = list;
            combo3.DropDownStyle = GridDropDownStyle.Exclusive;


            this.grid.Model[10, 6].CellValue = "Combo Box For Customers Table";
            this.grid.Model[11, 6].CellValue = "Editable";
            this.grid.Model[12, 6].CellValue = "AutoComplete";
            this.grid.Model[13, 6].CellValue = "Exclusive";

            var combo5 = this.grid.Model[11, 7];
            combo5.CellType = "DropDownList";
            combo5.ItemsSource = list;
            combo5.DropDownStyle = GridDropDownStyle.Editable;

            var combo6 = this.grid.Model[12, 7];
            combo6.CellType = "DropDownList";
            combo6.ItemsSource = list;
            combo6.DropDownStyle = GridDropDownStyle.AutoComplete;

            var combo7 = this.grid.Model[13, 7];
            combo7.CellType = "DropDownList";
            combo7.ItemsSource = list;
            combo7.DropDownStyle = GridDropDownStyle.Exclusive;
        }

        private void AddDropDownLists()
        {
            this.grid.Model[10, 6].CellValue = "Drop-down List Control types";
            this.grid.Model[11, 6].CellValue = "Editable";
            this.grid.Model[12, 6].CellValue = "AutoComplete";
            this.grid.Model[13, 6].CellValue = "Exclusive";

            var dropdown1 = this.grid.Model[11, 7];
            dropdown1.CellType = "DropDownList";
            dropdown1.ItemsSource = source;
            dropdown1.DisplayMember = "FirstName";
            dropdown1.ValueMember = "";
            dropdown1.DropDownStyle = GridDropDownStyle.Editable;

            var dropdown2 = this.grid.Model[12, 7];
            dropdown2.CellType = "DropDownList";
            dropdown2.ItemsSource = source;
            dropdown2.DisplayMember = "FirstName";
            dropdown2.DropDownStyle = GridDropDownStyle.AutoComplete;

            var dropdown3 = this.grid.Model[13, 7];
            dropdown3.CellType = "DropDownList";
            dropdown3.ItemsSource = source;
            dropdown3.DisplayMember = "FirstName";
            dropdown3.ValueMember = "";
            dropdown3.DropDownStyle = GridDropDownStyle.Exclusive;
        }

        public void grid_DateTimeEdit()
        {

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(4, 1, 4, 3));
            grid.Model[rowIndex, colIndex].Text = "DateTimeEdit";
            grid.Model[rowIndex, colIndex].Font.FontWeight = FontWeights.Bold;
            rowIndex++;

            grid.Model[rowIndex, colIndex].CellType = "DateTimeEdit";
            grid.Model[rowIndex, colIndex].DateTimeEdit.DateTimePattern = DateTimePattern.ShortDate;
            grid.Model[rowIndex, colIndex].CultureInfo = new CultureInfo("en-US");
            grid.Model[rowIndex, colIndex].CellValue = DateTime.Now;

            grid.Model[rowIndex + 1, colIndex].CellType = "DateTimeEdit";
            grid.Model[rowIndex + 1, colIndex].DateTimeEdit.DateTimePattern = DateTimePattern.ShortDate;
            grid.Model[rowIndex + 1, colIndex].CultureInfo = new CultureInfo("en-US");
            grid.Model[rowIndex + 1, colIndex].CellValue = DateTime.Now;

            grid.Model[rowIndex + 2, colIndex].CellType = "DateTimeEdit";
            grid.Model[rowIndex + 2, colIndex].DateTimeEdit.DateTimePattern = DateTimePattern.ShortDate;
            grid.Model[rowIndex + 2, colIndex].CultureInfo = new CultureInfo("en-US");
            grid.Model[rowIndex + 2, colIndex].CellValue = DateTime.Now;

            grid.Model[rowIndex, colIndex + 1].CellType = "DateTimeEdit";
            grid.Model[rowIndex, colIndex + 1].DateTimeEdit.DateTimePattern = DateTimePattern.ShortDate;
            grid.Model[rowIndex, colIndex + 1].CultureInfo = new CultureInfo("en-US");
            grid.Model[rowIndex, colIndex + 1].CellValue = DateTime.Now;

            grid.Model[rowIndex + 1, colIndex + 1].CellType = "DateTimeEdit";
            grid.Model[rowIndex + 1, colIndex + 1].DateTimeEdit.DateTimePattern = DateTimePattern.ShortDate;
            grid.Model[rowIndex + 1, colIndex + 1].CultureInfo = new CultureInfo("en-US");
            grid.Model[rowIndex + 1, colIndex + 1].CellValue = DateTime.Now;

            grid.Model[rowIndex + 2, colIndex + 1].CellType = "DateTimeEdit";
            grid.Model[rowIndex + 2, colIndex + 1].DateTimeEdit.DateTimePattern = DateTimePattern.ShortDate;
            grid.Model[rowIndex + 2, colIndex + 1].CultureInfo = new CultureInfo("en-US");
            grid.Model[rowIndex + 2, colIndex + 1].CellValue = DateTime.Now;

            grid.Model[rowIndex, colIndex + 2].CellType = "DateTimeEdit";
            grid.Model[rowIndex, colIndex + 2].DateTimeEdit.DateTimePattern = DateTimePattern.MonthDay;
            grid.Model[rowIndex, colIndex + 2].CultureInfo = new CultureInfo("en-US");
            grid.Model[rowIndex, colIndex + 2].CellValue = DateTime.Now;

            grid.Model[rowIndex + 1, colIndex + 2].CellType = "DateTimeEdit";
            grid.Model[rowIndex + 1, colIndex + 2].DateTimeEdit.DateTimePattern = DateTimePattern.MonthDay;
            grid.Model[rowIndex + 1, colIndex + 2].CultureInfo = new CultureInfo("en-US");
            grid.Model[rowIndex + 1, colIndex + 2].CellValue = DateTime.Now;

            grid.Model[rowIndex + 2, colIndex + 2].CellType = "DateTimeEdit";
            grid.Model[rowIndex + 2, colIndex + 2].DateTimeEdit.DateTimePattern = DateTimePattern.MonthDay;
            grid.Model[rowIndex + 2, colIndex + 2].CultureInfo = new CultureInfo("en-US");
            grid.Model[rowIndex + 2, colIndex + 2].CellValue = DateTime.Now;


        }

        public void grid_CurrencyCellType()
        {

            rowIndex += 4;
            grid.Model[rowIndex, colIndex].Text = "Currency Cells ";
            grid.Model[rowIndex, colIndex].Font.FontWeight = FontWeights.Bold;
            rowIndex++;


            grid.Model[rowIndex, colIndex].CellType = "CurrencyEdit";
            grid.Model[rowIndex, colIndex].IsEditable = true;
            grid.Model[rowIndex, colIndex].NumberFormat = new NumberFormatInfo { CurrencyDecimalDigits = 4, CurrencyDecimalSeparator = ",", CurrencyNegativePattern = 0, CurrencyPositivePattern = 0, CurrencySymbol = "$" };
            grid.Model[rowIndex, colIndex].NumberFormat.CurrencyGroupSizes = sizes;
            grid.Model[rowIndex, colIndex].CellValue = 4.0;

            grid.Model[rowIndex + 1, colIndex].CellType = "CurrencyEdit";
            grid.Model[rowIndex + 1, colIndex].IsEditable = true;
            grid.Model[rowIndex + 1, colIndex].NumberFormat = new NumberFormatInfo { CurrencyDecimalDigits = 4, CurrencyDecimalSeparator = ",", CurrencyNegativePattern = 0, CurrencyPositivePattern = 0, CurrencySymbol = "$" };
            grid.Model[rowIndex + 1, colIndex].NumberFormat.CurrencyGroupSizes = sizes;
            grid.Model[rowIndex + 1, colIndex].CellValue = 4.0;

            grid.Model[rowIndex + 2, colIndex].CellType = "CurrencyEdit";
            grid.Model[rowIndex + 2, colIndex].IsEditable = true;
            grid.Model[rowIndex + 2, colIndex].NumberFormat = new NumberFormatInfo { CurrencyDecimalDigits = 4, CurrencyDecimalSeparator = ",", CurrencyNegativePattern = 0, CurrencyPositivePattern = 0, CurrencySymbol = "$" };
            grid.Model[rowIndex + 2, colIndex].NumberFormat.CurrencyGroupSizes = sizes;
            grid.Model[rowIndex + 2, colIndex].CellValue = 4.0;

            grid.Model[rowIndex, colIndex + 1].CellType = "CurrencyEdit";
            grid.Model[rowIndex, colIndex + 1].IsEditable = true;
            grid.Model[rowIndex, colIndex + 1].NumberFormat = new NumberFormatInfo { CurrencyDecimalDigits = 4, CurrencyDecimalSeparator = ",", CurrencyNegativePattern = 0, CurrencyPositivePattern = 0, CurrencySymbol = "$" };
            grid.Model[rowIndex, colIndex + 1].NumberFormat.CurrencyGroupSizes = sizes;
            grid.Model[rowIndex, colIndex + 1].CellValue = 5.0;


            grid.Model[rowIndex + 1, colIndex + 1].CellType = "CurrencyEdit";
            grid.Model[rowIndex + 1, colIndex + 1].IsEditable = true;
            grid.Model[rowIndex + 1, colIndex + 1].NumberFormat = new NumberFormatInfo { CurrencyDecimalDigits = 4, CurrencyDecimalSeparator = ",", CurrencyNegativePattern = 0, CurrencyPositivePattern = 0, CurrencySymbol = "$" };
            grid.Model[rowIndex + 1, colIndex + 1].NumberFormat.CurrencyGroupSizes = sizes;
            grid.Model[rowIndex + 1, colIndex + 1].CellValue = 5.0;

            grid.Model[rowIndex + 2, colIndex + 1].CellType = "CurrencyEdit";
            grid.Model[rowIndex + 2, colIndex + 1].IsEditable = true;
            grid.Model[rowIndex + 2, colIndex + 1].NumberFormat = new NumberFormatInfo { CurrencyDecimalDigits = 4, CurrencyDecimalSeparator = ",", CurrencyNegativePattern = 0, CurrencyPositivePattern = 0, CurrencySymbol = "$" };
            grid.Model[rowIndex + 2, colIndex + 1].NumberFormat.CurrencyGroupSizes = sizes;
            grid.Model[rowIndex + 2, colIndex + 1].CellValue = 5.0;

            grid.Model[rowIndex, colIndex + 2].CellType = "CurrencyEdit";
            grid.Model[rowIndex, colIndex + 2].IsEditable = true;
            grid.Model[rowIndex, colIndex + 2].NumberFormat = new NumberFormatInfo { CurrencyDecimalDigits = 4, CurrencyDecimalSeparator = ",", CurrencyNegativePattern = 0, CurrencyPositivePattern = 0, CurrencySymbol = "$" };
            grid.Model[rowIndex, colIndex + 2].NumberFormat.CurrencyGroupSizes = sizes;
            grid.Model[rowIndex, colIndex + 2].CellValue = 6.0;

            grid.Model[rowIndex + 1, colIndex + 2].CellType = "CurrencyEdit";
            grid.Model[rowIndex + 1, colIndex + 2].IsEditable = true;
            grid.Model[rowIndex + 1, colIndex + 2].NumberFormat = new NumberFormatInfo { CurrencyDecimalDigits = 4, CurrencyDecimalSeparator = ",", CurrencyNegativePattern = 0, CurrencyPositivePattern = 0, CurrencySymbol = "$" };
            grid.Model[rowIndex + 1, colIndex + 2].NumberFormat.CurrencyGroupSizes = sizes;
            grid.Model[rowIndex + 1, colIndex + 2].CellValue = 5.0;

            grid.Model[rowIndex + 2, colIndex + 2].CellType = "CurrencyEdit";
            grid.Model[rowIndex + 2, colIndex + 2].IsEditable = true;
            grid.Model[rowIndex + 2, colIndex + 2].NumberFormat = new NumberFormatInfo { CurrencyDecimalDigits = 4, CurrencyDecimalSeparator = ",", CurrencyNegativePattern = 0, CurrencyPositivePattern = 0, CurrencySymbol = "$" };
            grid.Model[rowIndex + 2, colIndex + 2].NumberFormat.CurrencyGroupSizes = sizes;
            grid.Model[rowIndex + 2, colIndex + 2].CellValue = 7.0;


        }

        public void grid_DoubleCellType()
        {
            rowIndex += 4;
            grid.Model[rowIndex, colIndex].Text = "DubleEdit";
            grid.Model[rowIndex, colIndex].Font.FontWeight = FontWeights.Bold;
            rowIndex++;

            grid.Model[rowIndex, colIndex].CellType = "DoubleEdit";

            grid.Model[rowIndex, colIndex].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = ",", NumberDecimalSeparator = ".", NumberDecimalDigits = 4 };
            grid.Model[rowIndex, colIndex].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex, colIndex].CellValue = 4.0;

            grid.Model[rowIndex + 1, colIndex].CellType = "DoubleEdit";

            grid.Model[rowIndex + 1, colIndex].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = ",", NumberDecimalSeparator = ".", NumberDecimalDigits = 4 };
            grid.Model[rowIndex + 1, colIndex].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex + 1, colIndex].CellValue = 2345.00;

            grid.Model[rowIndex + 2, colIndex].CellType = "DoubleEdit";

            grid.Model[rowIndex + 2, colIndex].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = ",", NumberDecimalSeparator = ".", NumberDecimalDigits = 4 };
            grid.Model[rowIndex + 2, colIndex].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex + 2, colIndex].CellValue = 4.0;

            grid.Model[rowIndex, colIndex + 1].CellType = "DoubleEdit";

            grid.Model[rowIndex, colIndex + 1].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = ",", NumberDecimalSeparator = ".", NumberDecimalDigits = 4 };
            grid.Model[rowIndex, colIndex + 1].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex, colIndex + 1].CellValue = 5.0;


            grid.Model[rowIndex + 1, colIndex + 1].CellType = "DoubleEdit";

            grid.Model[rowIndex + 1, colIndex + 1].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = ",", NumberDecimalSeparator = ".", NumberDecimalDigits = 4 };
            grid.Model[rowIndex + 1, colIndex + 1].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex + 1, colIndex + 1].CellValue = 5.0;

            grid.Model[rowIndex + 2, colIndex + 1].CellType = "DoubleEdit";

            grid.Model[rowIndex + 2, colIndex + 1].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = ",", NumberDecimalSeparator = ".", NumberDecimalDigits = 4 };
            grid.Model[rowIndex + 2, colIndex + 1].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex + 2, colIndex + 1].CellValue = 5.0;

            grid.Model[rowIndex, colIndex + 2].CellType = "DoubleEdit";

            grid.Model[rowIndex, colIndex + 2].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = ",", NumberDecimalSeparator = ".", NumberDecimalDigits = 4 };
            grid.Model[rowIndex, colIndex + 2].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex, colIndex + 2].CellValue = 6.0;

            grid.Model[rowIndex + 1, colIndex + 2].CellType = "DoubleEdit";

            grid.Model[rowIndex + 1, colIndex + 2].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = ",", NumberDecimalSeparator = ".", NumberDecimalDigits = 4 };
            grid.Model[rowIndex + 1, colIndex + 2].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex + 1, colIndex + 2].CellValue = 5.0;

            grid.Model[rowIndex + 2, colIndex + 2].CellType = "DoubleEdit";

            grid.Model[rowIndex + 2, colIndex + 2].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = ",", NumberDecimalSeparator = ".", NumberDecimalDigits = 4 };
            grid.Model[rowIndex + 2, colIndex + 2].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex + 2, colIndex + 2].CellValue = 100.0;


        }

        public void grid_IntegerCellType()
        {
            rowIndex += 4;
            grid.Model[rowIndex, colIndex].Text = "Integer Edit";
            grid.Model[rowIndex, colIndex].Font.FontWeight = FontWeights.Bold;
            rowIndex++;


            grid.Model[rowIndex, colIndex].CellType = "IntegerEdit";

            grid.Model[rowIndex, colIndex].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = "," };
            grid.Model[rowIndex, colIndex].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex, colIndex].CellValue = 4;

            grid.Model[rowIndex + 1, colIndex].CellType = "IntegerEdit";

            grid.Model[rowIndex + 1, colIndex].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = "," };
            grid.Model[rowIndex + 1, colIndex].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex + 1, colIndex].CellValue = 2345;

            grid.Model[rowIndex + 2, colIndex].CellType = "IntegerEdit";

            grid.Model[rowIndex + 2, colIndex].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = "," };
            grid.Model[rowIndex + 2, colIndex].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex + 2, colIndex].CellValue = 4;

            grid.Model[rowIndex, colIndex + 1].CellType = "IntegerEdit";

            grid.Model[rowIndex, colIndex + 1].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = "," };
            grid.Model[rowIndex, colIndex + 1].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex, colIndex + 1].CellValue = 5;


            grid.Model[rowIndex + 1, colIndex + 1].CellType = "IntegerEdit";

            grid.Model[rowIndex + 1, colIndex + 1].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = "," };
            grid.Model[rowIndex + 1, colIndex + 1].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex + 1, colIndex + 1].CellValue = 5;

            grid.Model[rowIndex + 2, colIndex + 1].CellType = "IntegerEdit";

            grid.Model[rowIndex + 2, colIndex + 1].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = "," };
            grid.Model[rowIndex + 2, colIndex + 1].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex + 2, colIndex + 1].CellValue = 5;

            grid.Model[rowIndex, colIndex + 2].CellType = "IntegerEdit";

            grid.Model[rowIndex, colIndex + 2].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = "," };
            grid.Model[rowIndex, colIndex + 2].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex, colIndex + 2].CellValue = 6;

            grid.Model[rowIndex + 1, colIndex + 2].CellType = "IntegerEdit";
            grid.Model[rowIndex + 1, colIndex + 2].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = "," };
            grid.Model[rowIndex + 1, colIndex + 2].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex + 1, colIndex + 2].CellValue = 5;

            grid.Model[rowIndex + 2, colIndex + 2].CellType = "IntegerEdit";
            grid.Model[rowIndex + 2, colIndex + 2].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = "," };
            grid.Model[rowIndex + 2, colIndex + 2].NumberFormat.NumberGroupSizes = sizes;
            grid.Model[rowIndex + 2, colIndex + 2].CellValue = 100;



        }

        public void grid_MaskEdit()
        {
            rowIndex += 4;
            grid.Model[rowIndex, colIndex].Text = "Mask Edit";
            grid.Model[rowIndex, colIndex].Font.FontWeight = FontWeights.Bold;
            rowIndex++;


            grid.Model[rowIndex, colIndex].CellType = "MaskEdit";
            grid.Model[rowIndex, colIndex].MaskEdit = GridMaskEditInfo.Default;
            grid.Model[rowIndex, colIndex].MaskEdit.Mask = "00:00:00";
            grid.Model[rowIndex, colIndex].CellValue = 1232313;

            grid.Model[rowIndex + 1, colIndex].CellType = "MaskEdit";
            grid.Model[rowIndex + 1, colIndex].MaskEdit = GridMaskEditInfo.Default;
            grid.Model[rowIndex + 1, colIndex].MaskEdit.Mask = "00:00:00";
            grid.Model[rowIndex + 1, colIndex].CellValue = 1232313;

            grid.Model[rowIndex + 2, colIndex].CellType = "MaskEdit";
            grid.Model[rowIndex + 2, colIndex].MaskEdit = GridMaskEditInfo.Default;
            grid.Model[rowIndex + 2, colIndex].MaskEdit.Mask = "00:00:00";
            grid.Model[rowIndex + 2, colIndex].CellValue = 1232313;

            grid.Model[rowIndex, colIndex + 1].CellType = "MaskEdit";
            grid.Model[rowIndex, colIndex + 1].MaskEdit = GridMaskEditInfo.Default;
            grid.Model[rowIndex, colIndex + 1].MaskEdit.Mask = "00:00:00";
            grid.Model[rowIndex, colIndex + 1].CellValue = 1232313;

            grid.Model[rowIndex + 1, colIndex + 1].CellType = "MaskEdit";
            grid.Model[rowIndex + 1, colIndex + 1].MaskEdit = GridMaskEditInfo.Default;
            grid.Model[rowIndex + 1, colIndex + 1].MaskEdit.Mask = "00:00:00";
            grid.Model[rowIndex + 1, colIndex + 1].CellValue = 1232313;

            grid.Model[rowIndex + 2, colIndex + 1].CellType = "MaskEdit";
            grid.Model[rowIndex + 2, colIndex + 1].MaskEdit = GridMaskEditInfo.Default;
            grid.Model[rowIndex + 2, colIndex + 1].MaskEdit.Mask = "00:00:00";
            grid.Model[rowIndex + 2, colIndex + 1].CellValue = 1232313;

            grid.Model[rowIndex, colIndex + 2].CellType = "MaskEdit";
            grid.Model[rowIndex, colIndex + 2].MaskEdit = GridMaskEditInfo.Default;
            grid.Model[rowIndex, colIndex + 2].MaskEdit.Mask = "00:00:00";
            grid.Model[rowIndex, colIndex + 2].CellValue = 1232313;

            grid.Model[rowIndex + 1, colIndex + 2].CellType = "MaskEdit";
            grid.Model[rowIndex + 1, colIndex + 2].MaskEdit = GridMaskEditInfo.Default;
            grid.Model[rowIndex + 1, colIndex + 2].MaskEdit.Mask = "00:00:00";
            grid.Model[rowIndex + 1, colIndex + 2].CellValue = 1232313;

            grid.Model[rowIndex + 2, colIndex + 2].CellType = "MaskEdit";
            grid.Model[rowIndex + 2, colIndex + 2].MaskEdit = GridMaskEditInfo.Default;
            grid.Model[rowIndex + 2, colIndex + 2].MaskEdit.Mask = "00:00:00";
            grid.Model[rowIndex + 2, colIndex + 2].CellValue = 1232313;




        }

        public void grid_PercentEdit()
        {
            rowIndex += 4;
            grid.Model[rowIndex, colIndex].Text = "Percent Edit";
            grid.Model[rowIndex, colIndex].Font.FontWeight = FontWeights.Bold;
            rowIndex++;

            grid.Model[rowIndex, colIndex].CellType = "PercentEdit";
            grid.Model[rowIndex, colIndex].NumberFormat = new System.Globalization.NumberFormatInfo()
            {
                PercentSymbol = "%",
                PercentGroupSizes = new int[] { 1, 2, 3 },
                PercentDecimalDigits = 2,
                PercentGroupSeparator = ",",

            };
            grid.Model[rowIndex, colIndex].PercentEditMode = Syncfusion.Windows.Shared.PercentEditMode.PercentMode;
            grid.Model[rowIndex, colIndex].CellValue = 19;

            grid.Model[rowIndex + 1, colIndex].CellType = "PercentEdit";
            grid.Model[rowIndex + 1, colIndex].NumberFormat = new System.Globalization.NumberFormatInfo()
            {
                PercentSymbol = "%",
                PercentGroupSizes = new int[] { 1, 2, 3 },
                PercentDecimalDigits = 2,
                PercentGroupSeparator = ",",

            };
            grid.Model[rowIndex + 1, colIndex].PercentEditMode = Syncfusion.Windows.Shared.PercentEditMode.PercentMode;
            grid.Model[rowIndex + 1, colIndex].CellValue = 19;

            grid.Model[rowIndex + 2, colIndex].CellType = "PercentEdit";
            grid.Model[rowIndex + 2, colIndex].NumberFormat = new System.Globalization.NumberFormatInfo()
            {
                PercentSymbol = "%",
                PercentGroupSizes = new int[] { 1, 2, 3 },
                PercentDecimalDigits = 2,
                PercentGroupSeparator = ",",

            };
            grid.Model[rowIndex + 2, colIndex].PercentEditMode = Syncfusion.Windows.Shared.PercentEditMode.PercentMode;
            grid.Model[rowIndex + 2, colIndex].CellValue = 19;



            grid.Model[rowIndex, colIndex + 1].CellType = "PercentEdit";
            grid.Model[rowIndex, colIndex + 1].NumberFormat = new System.Globalization.NumberFormatInfo()
            {
                PercentSymbol = "%",
                PercentGroupSizes = new int[] { 1, 2, 3 },
                PercentDecimalDigits = 2,
                PercentGroupSeparator = ",",

            };
            grid.Model[rowIndex, colIndex + 1].PercentEditMode = Syncfusion.Windows.Shared.PercentEditMode.PercentMode;
            grid.Model[rowIndex, colIndex + 1].CellValue = 19;

            grid.Model[rowIndex + 1, colIndex + 1].CellType = "PercentEdit";
            grid.Model[rowIndex + 1, colIndex + 1].NumberFormat = new System.Globalization.NumberFormatInfo()
            {
                PercentSymbol = "%",
                PercentGroupSizes = new int[] { 1, 2, 3 },
                PercentDecimalDigits = 2,
                PercentGroupSeparator = ",",

            };
            grid.Model[rowIndex + 1, colIndex + 1].PercentEditMode = Syncfusion.Windows.Shared.PercentEditMode.PercentMode;
            grid.Model[rowIndex + 1, colIndex + 1].CellValue = 19;

            grid.Model[rowIndex + 2, colIndex + 1].CellType = "PercentEdit";
            grid.Model[rowIndex + 2, colIndex + 1].NumberFormat = new System.Globalization.NumberFormatInfo()
            {
                PercentSymbol = "%",
                PercentGroupSizes = new int[] { 1, 2, 3 },
                PercentDecimalDigits = 2,
                PercentGroupSeparator = ",",

            };
            grid.Model[rowIndex + 2, colIndex + 1].PercentEditMode = Syncfusion.Windows.Shared.PercentEditMode.PercentMode;
            grid.Model[rowIndex + 2, colIndex + 1].CellValue = 19;

            grid.Model[rowIndex, colIndex + 2].CellType = "PercentEdit";
            grid.Model[rowIndex, colIndex + 2].NumberFormat = new System.Globalization.NumberFormatInfo()
            {
                PercentSymbol = "%",
                PercentGroupSizes = new int[] { 1, 2, 3 },
                PercentDecimalDigits = 2,
                PercentGroupSeparator = ",",

            };
            grid.Model[rowIndex, colIndex + 2].PercentEditMode = Syncfusion.Windows.Shared.PercentEditMode.PercentMode;
            grid.Model[rowIndex, colIndex + 2].CellValue = 19;

            grid.Model[rowIndex + 1, colIndex + 2].CellType = "PercentEdit";
            grid.Model[rowIndex + 1, colIndex + 2].NumberFormat = new System.Globalization.NumberFormatInfo()
            {
                PercentSymbol = "%",
                PercentGroupSizes = new int[] { 1, 2, 3 },
                PercentDecimalDigits = 2,
                PercentGroupSeparator = ",",

            };
            grid.Model[rowIndex + 1, colIndex + 2].PercentEditMode = Syncfusion.Windows.Shared.PercentEditMode.PercentMode;
            grid.Model[rowIndex + 1, colIndex + 2].CellValue = 19;

            grid.Model[rowIndex + 2, colIndex + 2].CellType = "PercentEdit";
            grid.Model[rowIndex + 2, colIndex + 2].NumberFormat = new System.Globalization.NumberFormatInfo()
            {
                PercentSymbol = "%",
                PercentGroupSizes = new int[] { 1, 2, 3 },
                PercentDecimalDigits = 2,
                PercentGroupSeparator = ",",

            };
            grid.Model[rowIndex + 2, colIndex + 2].PercentEditMode = Syncfusion.Windows.Shared.PercentEditMode.PercentMode;
            grid.Model[rowIndex + 2, colIndex + 2].CellValue = 19;



        }


        public void grid_UpDownEdit()
        {
            rowIndex += 4;
            grid.Model[rowIndex, colIndex].Text = "Updown Edit";
            grid.Model[rowIndex, colIndex].Font.FontWeight = FontWeights.Bold;
            rowIndex++;

            grid.Model[rowIndex, colIndex].CellType = "UpDownEdit";
            grid.Model[rowIndex, colIndex].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalDigits = 3 };
            grid.Model[rowIndex, colIndex].UpDownEdit.FocusedBackground = Brushes.Tan;
            grid.Model[rowIndex, colIndex].UpDownEdit.FocusedBorderBrush = Brushes.Red;
            grid.Model[rowIndex, colIndex].UpDownEdit.FocusedForeground = Brushes.Yellow;
            grid.Model[rowIndex, colIndex].UpDownEdit.MaxValue = 10.00;
            grid.Model[rowIndex, colIndex].UpDownEdit.MinValue = 0;
            grid.Model[rowIndex, colIndex].CellValue = 10.000;

            grid.Model[rowIndex + 1, colIndex].CellType = "UpDownEdit";
            grid.Model[rowIndex + 1, colIndex].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalDigits = 3 };
            grid.Model[rowIndex + 1, colIndex].UpDownEdit.FocusedBackground = Brushes.Tan;
            grid.Model[rowIndex + 1, colIndex].UpDownEdit.FocusedBorderBrush = Brushes.Red;
            grid.Model[rowIndex + 1, colIndex].UpDownEdit.FocusedForeground = Brushes.Yellow;
            grid.Model[rowIndex + 1, colIndex].UpDownEdit.MaxValue = 10.00;
            grid.Model[rowIndex + 1, colIndex].UpDownEdit.MinValue = 0;
            grid.Model[rowIndex + 1, colIndex].CellValue = 10.000;

            grid.Model[rowIndex + 2, colIndex].CellType = "UpDownEdit";
            grid.Model[rowIndex + 2, colIndex].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalDigits = 3 };
            grid.Model[rowIndex + 2, colIndex].UpDownEdit.FocusedBackground = Brushes.Tan;
            grid.Model[rowIndex + 2, colIndex].UpDownEdit.FocusedBorderBrush = Brushes.Red;
            grid.Model[rowIndex + 2, colIndex].UpDownEdit.FocusedForeground = Brushes.Yellow;
            grid.Model[rowIndex + 2, colIndex].UpDownEdit.MaxValue = 10.00;
            grid.Model[rowIndex + 2, colIndex].UpDownEdit.MinValue = 0;
            grid.Model[rowIndex + 2, colIndex].CellValue = 10.000;

            grid.Model[rowIndex, colIndex + 1].CellType = "UpDownEdit";
            grid.Model[rowIndex, colIndex + 1].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalDigits = 3 };
            grid.Model[rowIndex, colIndex + 1].UpDownEdit.FocusedBackground = Brushes.Tan;
            grid.Model[rowIndex, colIndex + 1].UpDownEdit.FocusedBorderBrush = Brushes.Red;
            grid.Model[rowIndex, colIndex + 1].UpDownEdit.FocusedForeground = Brushes.Yellow;
            grid.Model[rowIndex, colIndex + 1].UpDownEdit.MaxValue = 10.00;
            grid.Model[rowIndex, colIndex + 1].UpDownEdit.MinValue = 0;
            grid.Model[rowIndex, colIndex + 1].CellValue = 10.000;

            grid.Model[rowIndex + 1, colIndex + 1].CellType = "UpDownEdit";
            grid.Model[rowIndex + 1, colIndex + 1].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalDigits = 3 };
            grid.Model[rowIndex + 1, colIndex + 1].UpDownEdit.FocusedBackground = Brushes.Tan;
            grid.Model[rowIndex + 1, colIndex + 1].UpDownEdit.FocusedBorderBrush = Brushes.Red;
            grid.Model[rowIndex + 1, colIndex + 1].UpDownEdit.FocusedForeground = Brushes.Yellow;
            grid.Model[rowIndex + 1, colIndex + 1].UpDownEdit.MaxValue = 10.00;
            grid.Model[rowIndex + 1, colIndex + 1].UpDownEdit.MinValue = 0;
            grid.Model[rowIndex + 1, colIndex + 1].CellValue = 10.000;

            grid.Model[rowIndex + 2, colIndex + 1].CellType = "UpDownEdit";
            grid.Model[rowIndex + 2, colIndex + 1].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalDigits = 3 };
            grid.Model[rowIndex + 2, colIndex + 1].UpDownEdit.FocusedBackground = Brushes.Tan;
            grid.Model[rowIndex + 2, colIndex + 1].UpDownEdit.FocusedBorderBrush = Brushes.Red;
            grid.Model[rowIndex + 2, colIndex + 1].UpDownEdit.FocusedForeground = Brushes.Yellow;
            grid.Model[rowIndex + 2, colIndex + 1].UpDownEdit.MaxValue = 10.00;
            grid.Model[rowIndex + 2, colIndex + 1].UpDownEdit.MinValue = 0;
            grid.Model[rowIndex + 2, colIndex + 1].CellValue = 10.000;

            grid.Model[rowIndex, colIndex + 2].CellType = "UpDownEdit";
            grid.Model[rowIndex, colIndex + 2].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalDigits = 3 };
            grid.Model[rowIndex, colIndex + 2].UpDownEdit.FocusedBackground = Brushes.Tan;
            grid.Model[rowIndex, colIndex + 2].UpDownEdit.FocusedBorderBrush = Brushes.Red;
            grid.Model[rowIndex, colIndex + 2].UpDownEdit.FocusedForeground = Brushes.Yellow;
            grid.Model[rowIndex, colIndex + 2].UpDownEdit.MaxValue = 10.00;
            grid.Model[rowIndex, colIndex + 2].UpDownEdit.MinValue = 0;
            grid.Model[rowIndex, colIndex + 2].CellValue = 10.000;

            grid.Model[rowIndex + 1, colIndex + 2].CellType = "UpDownEdit";
            grid.Model[rowIndex + 1, colIndex + 2].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalDigits = 3 };
            grid.Model[rowIndex + 1, colIndex + 2].UpDownEdit.FocusedBackground = Brushes.Tan;
            grid.Model[rowIndex + 1, colIndex + 2].UpDownEdit.FocusedBorderBrush = Brushes.Red;
            grid.Model[rowIndex + 1, colIndex + 2].UpDownEdit.FocusedForeground = Brushes.Yellow;
            grid.Model[rowIndex + 1, colIndex + 2].UpDownEdit.MaxValue = 10.00;
            grid.Model[rowIndex + 1, colIndex + 2].UpDownEdit.MinValue = 0;
            grid.Model[rowIndex + 1, colIndex + 2].CellValue = 10.000;

            grid.Model[rowIndex + 2, colIndex + 2].CellType = "UpDownEdit";
            grid.Model[rowIndex + 2, colIndex + 2].NumberFormat = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalDigits = 3 };
            grid.Model[rowIndex + 2, colIndex + 2].UpDownEdit.FocusedBackground = Brushes.Tan;
            grid.Model[rowIndex + 2, colIndex + 2].UpDownEdit.FocusedBorderBrush = Brushes.Red;
            grid.Model[rowIndex + 2, colIndex + 2].UpDownEdit.FocusedForeground = Brushes.Yellow;
            grid.Model[rowIndex + 2, colIndex + 2].UpDownEdit.MaxValue = 10.00;
            grid.Model[rowIndex + 2, colIndex + 2].UpDownEdit.MinValue = 0;
            grid.Model[rowIndex + 2, colIndex + 2].CellValue = 10.000;


        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.textBox1.Text = Clipboard.GetText();
            if (Clipboard.ContainsData("XML Spreadsheet") && Combobox1.SelectedIndex == 2)
            {
                MemoryStream xmlStream = new MemoryStream();
                xmlStream = Clipboard.GetData("Xml Spreadsheet") as MemoryStream;
                XmlDocument xDocument = new XmlDocument();
                xDocument.Load(xmlStream);
                StringWriter sw = new StringWriter();
                XmlTextWriter xw = new XmlTextWriter(sw);
                xDocument.WriteTo(xw);
                this.textBox1.Text = sw.ToString();

            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            Clipboard.Clear();
            this.textBox1.Text = Clipboard.GetText();
        }

        private void Combobox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int select = Combobox1.SelectedIndex;
            grid.Model.TextDataExchange.TabDelimiter = string.Empty;
            gridControl1.Model.TextDataExchange.TabDelimiter = string.Empty;
            switch (select)
            {
                case 0:
                    {
                        grid.Model.Options.CopyPasteOption = CopyPaste.CopyText | CopyPaste.CutText | CopyPaste.PasteText;
                        gridControl1.Model.Options.CopyPasteOption = CopyPaste.CopyText | CopyPaste.CutText | CopyPaste.PasteText;
                    }
                    break;

                case 1:
                    {
                        this.grid.Model.Options.CopyPasteOption = CopyPaste.CutCell | CopyPaste.CopyCellData |
                                                                        CopyPaste.PasteCell | CopyPaste.IncludeStyle;
                        this.gridControl1.Model.Options.CopyPasteOption = CopyPaste.CutCell | CopyPaste.CopyCellData | CopyPaste.PasteCell | CopyPaste.IncludeStyle;
                    }
                    break;
                case 2:
                    {
                        grid.Model.Options.CopyPasteOption = CopyPaste.XmlCopyPaste;
                        gridControl1.Model.Options.CopyPasteOption = CopyPaste.XmlCopyPaste;
                    }
                    break;
                case 3:
                    {
                        grid.Model.TextDataExchange.TabDelimiter = ",";
                        grid.Model.Options.CopyPasteOption = CopyPaste.CopyText | CopyPaste.CutText | CopyPaste.PasteText;
                        gridControl1.Model.TextDataExchange.TabDelimiter = ",";
                        gridControl1.Model.Options.CopyPasteOption = CopyPaste.CopyText | CopyPaste.CutText | CopyPaste.PasteText;
                    }
                    break;

            }

            if (Instructionbox != null) Instructionbox.Text = Instructions[select];
        }

        private void AddInstructions()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Copy Paste Option : Text\r\n\r\n");
            sb.Append("Object Used           : Clipboard\r\n\r\n");
            sb.Append("Description:\r\n\r\n");
            sb.Append("This supports to copy the cell value without any formatting (Plain text). \r\n\r\n");
            sb.Append("Use case:\r\n \r\n");
            sb.Append("Select some cells, the copy the selected ranges (CTRL +c) and paste in the same Grid Control (GridControl1). \r\n\r\n");
            sb.Append("Select some cells, the copy the selected ranges (CTRL +c) and paste in the other Grid Control (GridControl2). \r\n\r\n");
            sb.Append("Copy some cells in GridControl1 and paste in Microsoft Excel. \r\n\r\n");
            sb.Append("Copy some cells in Microsoft Excel and Paste in GridControl. \r\n\r\n");
            Instructions.Add(sb.ToString());
            sb = new StringBuilder();
            sb.Append("Copy Paste Option : Cells \r\n\r\n");
            sb.Append("Object Used           : GridDataObject          \r\n\r\n");
            sb.Append("Description:          \r\n\r\n");
            sb.Append("This will support copy paste operation only inside the GridControl. This will copy the Entire cell styles including CellTypes, Foreground and Background etc.          \r\n\r\n");
            sb.Append("Use case:           \r\n\r\n");
            sb.Append(" Copy Some cells in GridControl1 and Paste in GridControl 1. The Entire cell style will be copied.           \r\n\r\n");
            Instructions.Add(sb.ToString());
            sb = new StringBuilder();
            sb.Append("Copy Paste Option : Excel  \r\n\r\n");
            sb.Append("Object Used           : Clipboard  \r\n\r\n");
            sb.Append("Description:  \r\n\r\n");
            sb.Append("This supports copy paste operation from GridControl to Microsoft Excel and vice versa with some Basic Styles.  \r\n\r\n");
            sb.Append("Styles Supported:  \r\n\r\n");
            sb.Append("Cell Value, Background, Foreground, Font Family, Font Size, Bold, Italic, Underline and Formula Value.   \r\n\r\n");
            sb.Append("Use case:   \r\n\r\n");
            sb.Append("Copy some cells in GridControl1 and Paste in Microsoft Excel.   \r\n\r\n");
            sb.Append("Copy some formatted cells in Microsoft Excel and Paste in Grid Control.  \r\n\r\n");
            Instructions.Add(sb.ToString());
            sb = new StringBuilder();
            sb.Append("Copy Paste Option : CSV Format.  \r\n\r\n");
            sb.Append("Object Used           : Clipboard  \r\n\r\n");
            sb.Append("Description:  \r\n\r\n");
            sb.Append("This supports to copy the cell value without any formatting (Plain text) with the delimiter as “,”.  \r\n\r\n");
            sb.Append("Use case:   \r\n\r\n");
            sb.Append("Select some cells, the copy the selected ranges (CTRL +c) and paste in the same Grid Control (GridControl1).   \r\n\r\n");
            sb.Append("Select some cells, the copy the selected ranges (CTRL +c) and paste in the other Grid Control (GridControl2).   \r\n\r\n");
            sb.Append("Copy some cells in GridControl1 and paste in Microsoft Excel.   \r\n\r\n");
            sb.Append("Copy some cells in Microsoft Excel and Paste in GridControl.   \r\n\r\n");
            Instructions.Add(sb.ToString());
        }

        protected override void Dispose(bool disposing)
        {
            if (this.grid != null)
            {
                this.grid.Dispose();
                this.grid = null;
            }
            if (this.gridControl1 != null)
            {
                this.gridControl1.Dispose();
                this.gridControl1 = null;
            }
            base.Dispose(disposing);
        }
    }

    public class Itemsource : List<emplist>
        {
        public Itemsource()
            {
            for (int i = 0; i < 10; i++)
                {
                emplist emp = new emplist() { FirstName = "Employee" + i.ToString(), EmployeeID = 1000 + i, RollNo = 30 + i, Designation = "Dept" + i.ToString() };
                this.Add(emp);


                }
            }
        }

    public class emplist
        {
        public emplist()
            {

            }
        public string FirstName { get; set; }
        public int EmployeeID { get; set; }
        public int RollNo { get; set; }
        public string Designation { get; set; }
        }

    class HtmlCopy : IGridCopyPaste
    {
        public void Copy(GridCellData gridData, GridRangeInfoList rangeList)
        {

            IDataObject iData = null;
            iData = Clipboard.GetDataObject();
            string buffer = iData.GetData(DataFormats.UnicodeText) as string;
            int top = rangeList[0].Top;
            int left = rangeList[0].Left;
            int right = rangeList[0].Right;
            int bottom = rangeList[0].Bottom;
            string stylesheet = string.Empty;


            StringBuilder sb = new StringBuilder();
            GridStyleInfoStore gsis;
            GridStyleInfo style;

            sb.Append("<html><body><table border=1>");
            for (int row = top; row <= bottom; row++)
            {
                sb.Append("<tr>");
                for (int col = left; col <= right; col++)
                {

                    gsis = gridData[row - top, col - left];
                    style = new GridStyleInfo(gsis);

                    stylesheet = "\"";
                    if (style.HasBackground)
                    {
                        string backgroundColor = style.Background.ToString();
                        backgroundColor = backgroundColor.Substring(3, backgroundColor.Length - 3);
                        stylesheet = "\"background-color:" + backgroundColor;
                    }

                    if (style.HasForeground)
                    {
                        string foregroundColor = style.Foreground.ToString();
                        foregroundColor = foregroundColor.Substring(3, foregroundColor.Length - 3);
                        stylesheet = stylesheet + ";color:" + foregroundColor;
                    }

                    if (style.HasHorizontalAlignment)
                    {
                        stylesheet = stylesheet + ";text-align:" + style.HorizontalAlignment;
                    }

                    if (style.HasVerticalAlignment)
                    {
                        stylesheet = stylesheet + ";vertical-align:" + style.VerticalAlignment;
                    }

                    if (style.HasBorders)
                    {
                        string borderBrush;

                        borderBrush = style.Borders.Left.Brush.ToString();
                        borderBrush = borderBrush.Substring(3, borderBrush.Length - 3);
                        stylesheet = stylesheet + ";border-left:solid  #" + borderBrush;

                        borderBrush = style.Borders.Right.Brush.ToString();
                        borderBrush = borderBrush.Substring(3, borderBrush.Length - 3);
                        stylesheet = stylesheet + ";border-right:solid  #" + borderBrush;

                        borderBrush = style.Borders.Bottom.Brush.ToString();
                        borderBrush = borderBrush.Substring(3, borderBrush.Length - 3);
                        stylesheet = stylesheet + ";border-bottom:solid  #" + borderBrush;

                        borderBrush = style.Borders.Top.Brush.ToString();
                        borderBrush = borderBrush.Substring(3, borderBrush.Length - 3);
                        stylesheet = stylesheet + ";border-top:solid  #" + borderBrush;
                    }


                    stylesheet = stylesheet + "\"";

                    if (!stylesheet.Equals("\"\""))
                    {
                        sb.Append(@"<td style=" + stylesheet + ">");
                    }

                    else
                    {
                        sb.Append(@"<td>");
                    }

                    if (!style.CellValue.ToString().Equals(""))
                    {
                        sb.Append(style.CellValue.ToString());
                    }

                    else
                    {
                        sb.Append("<pre>       </pre>");
                    }

                    sb.Append("</td>");
                    stylesheet = string.Empty;
                }
                sb.Append("</tr>");
            }
            sb.Append("</table></body></html>");
            DataObject dataObject = new DataObject();
            dataObject.SetData(DataFormats.UnicodeText, sb.ToString());
            Clipboard.SetDataObject(dataObject);

        }

        public void Cut(GridCellData grodCellData, GridRangeInfoList rangeList)
        {
        }
        public DataObject Paste(GridRangeInfoList rangeList)
        {
            return new DataObject();
        }
    }
}