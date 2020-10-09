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
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Shared;
using System.Threading;
using Syncfusion.Windows.ComponentModel;
using System.ComponentModel;
using Syncfusion.Windows.GridCommon;
using System.Windows.Markup;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for DateTimeCell.xaml
    /// </summary>
    public partial class DateTimeCell : DemoControl
    {

        GridStyleInfo g = new GridStyleInfo();
        public DateTimeCell()
        {
            InitializeComponent();
            GridSettings();
        }

        public DateTimeCell(string themename) : base(themename)
        {
            InitializeComponent();
            GridSettings();
        }

        void GridSettings()
        {
            grid.Model.RowCount = 35;
            grid.Model.ColumnCount = 25;

            g = grid.Model[2, 1];

            grid.CurrentCellActivated += new GridRoutedEventHandler(grid_CurrentCellActivated);

            int[] sizes = { 2, 3, 4 };
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(1, 1, 2, 5));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(5, 1, 5, 3));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(7, 1, 7, 3));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(9, 1, 9, 3));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(11, 1, 11, 3));

            grid.Model[1, 1].CellValue = "Date Time Sample";
            grid.Model[1, 1].Foreground = Brushes.Black;
            grid.Model[1, 1].Background = Brushes.LightBlue;
            grid.Model[1, 1].Font.FontSize = 14;
            grid.Model[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
            grid.Model[1, 1].Font.FontWeight = FontWeights.Bold;

            Thread t = Thread.CurrentThread;
            t.CurrentCulture = new CultureInfo("en-US");

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(3, 1, 4, 5));
            var cell = grid.Model[3, 1];
            cell.CellValue = "This sample showcases the different date-time formats that can be set on a Date Time cell type";
            cell.HorizontalAlignment = HorizontalAlignment.Center;
            cell.Font.FontWeight = FontWeights.Bold;

            grid.Model[5, 1].CellType = "DateTimeEdit";
            grid.Model[5, 1].DateTimeEdit.DateTimePattern = DateTimePattern.LongTime;
            grid.Model[5, 1].CultureInfo = new CultureInfo("en-US");
            grid.Model[5, 1].CellValue = DateTime.Now;

            grid.Model[7, 1].CellType = "DateTimeEdit";
            grid.Model[7, 1].DateTimeEdit.DateTimePattern = DateTimePattern.FullDateTime;
            grid.Model[7, 1].CultureInfo = new CultureInfo("en-US");
            grid.Model[7, 1].CellValue = DateTime.Now;

            grid.Model[9, 1].CellType = "DateTimeEdit";
            grid.Model[9, 1].DateTimeEdit.DateTimePattern = DateTimePattern.ShortDate;
            grid.Model[9, 1].CultureInfo = new CultureInfo("en-US");
            grid.Model[9, 1].CellValue = DateTime.Now;

            grid.Model[11, 1].CellType = "DateTimeEdit";
            grid.Model[11, 1].DateTimeEdit.DateTimePattern = DateTimePattern.YearMonth;
            grid.Model[11, 1].CultureInfo = new CultureInfo("en-US");
            grid.Model[11, 1].CellValue = DateTime.Now;
        }

        void grid_CurrentCellActivating(object sender, GridCurrentCellActivatingEventArgs e)
        {
            var style = this.grid.Model[e.CellRowColumnIndex.RowIndex, e.CellRowColumnIndex.ColumnIndex];
            if (style.CellType == "DateTimeEdit")
            {
                Thread.CurrentThread.CurrentCulture = style.CultureInfo;
            }
        }

        public String[] getColors()
        {
            String[] colors = { "Yellow", "Blue", "Green", "Red", "Pink", "Maroon", "Brown", "Black", "Violet" };
            return colors;
        }


        void grid_CurrentCellActivated(object sender, SyncfusionRoutedEventArgs args)
        {
            GridControlBase current_cell = args.Source as GridControlBase;
            if (grid.Model[current_cell.CurrentCell.RowIndex, current_cell.CurrentCell.ColumnIndex].CellType == "DateTimeEdit")
            {
                g = grid.Model[current_cell.CurrentCell.RowIndex, current_cell.CurrentCell.ColumnIndex];
                SetTheDateTimeFormatCombo();
                SetTheCultureInfoFormatCombo();
            }
        }

        private void SetTheDateTimeFormatCombo()
        {
            switch (g.DateTimeEdit.DateTimePattern)
            {
                case DateTimePattern.ShortDate:
                    myCombobox.SelectedIndex = 0;
                    break;
                case DateTimePattern.LongDate:
                    myCombobox.SelectedIndex = 1;
                    break;
                case DateTimePattern.ShortTime:
                    myCombobox.SelectedIndex = 2;
                    break;
                case DateTimePattern.LongTime:
                    myCombobox.SelectedIndex = 3;
                    break;
                case DateTimePattern.FullDateTime:
                    myCombobox.SelectedIndex = 4;
                    break;
                case DateTimePattern.MonthDay:
                    myCombobox.SelectedIndex = 5;
                    break;
                case DateTimePattern.RFC1123:
                    myCombobox.SelectedIndex = 6;
                    break;
                case DateTimePattern.SortableDateTime:
                    myCombobox.SelectedIndex = 7;
                    break;
                case DateTimePattern.UniversalSortableDateTime:
                    myCombobox.SelectedIndex = 8;
                    break;
                case DateTimePattern.YearMonth:
                    myCombobox.SelectedIndex = 9;
                    break;
                case DateTimePattern.CustomPattern:
                    myCombobox.SelectedIndex = 10;
                    break;
            }
        }

        private void SetTheCultureInfoFormatCombo()
        {
            switch (g.CultureInfo.Name)
            {
                case "uk-UA":
                    MyComboBox.SelectedIndex = 0;
                    break;
                case "vi-VN":
                    MyComboBox.SelectedIndex = 1;
                    break;
                case "sq-AL":
                    MyComboBox.SelectedIndex = 2;
                    break;
                case "en-US":
                    MyComboBox.SelectedIndex = 3;
                    break;
                case "mn-MN":
                    MyComboBox.SelectedIndex = 4;
                    break;
                case "is-IS":
                    MyComboBox.SelectedIndex = 5;
                    break;
                case "ar-SA":
                    MyComboBox.SelectedIndex = 6;
                    break;
                case "he-IL":
                    MyComboBox.SelectedIndex = 7;
                    break;
            }
        }

        private void CultureInfoSelected(Object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = sender as ComboBoxItem;
            Thread t = Thread.CurrentThread;
            t.CurrentCulture = new CultureInfo(item.Content.ToString());
            
            g.CultureInfo = t.CurrentCulture;
            grid.CurrentCell.EndEdit();
            grid.CurrentCell.BeginEdit();
            this.grid.Model.InvalidateCell(GridRangeInfo.Cell(g.RowIndex, g.ColumnIndex));
            this.grid.Model.InvalidateVisual(true);
        }

        public void DateTimePattern1(object sender, RoutedEventArgs e)
        {
            ComboBoxItem item = (ComboBoxItem)sender;
            String text = item.Content.ToString();
            switch (text)
            {
                // Set the ShortDateFormat
                case "ShortDateFormat":
                    g.DateTimeEdit.DateTimePattern = DateTimePattern.ShortDate;
                    break;
                // Set the LongDateFormat
                case "LongDateFormat":
                    g.DateTimeEdit.DateTimePattern = DateTimePattern.LongDate;
                    break;
                // Set the ShortTimeFormat
                case "ShortTimeFormat":
                    g.DateTimeEdit.DateTimePattern = DateTimePattern.ShortTime;
                    break;
                // Set the LongTimeFormat
                case "LongTimeFormat":
                    g.DateTimeEdit.DateTimePattern = DateTimePattern.LongTime;
                    break;
                // Set the FullDateTimeFormat
                case "FullDateTimeFormat":
                    g.DateTimeEdit.DateTimePattern = DateTimePattern.FullDateTime;
                    break;
                // Set the MonthDayFormat
                case "MonthDayFormat":
                    g.DateTimeEdit.DateTimePattern = DateTimePattern.MonthDay;
                    break;
                // Set the RFC1123Format
                case "RFC1123Format":
                    g.DateTimeEdit.DateTimePattern = DateTimePattern.RFC1123;
                    break;
                // Set the SortableDateTimeFormat
                case "SortableDateTimeFormat":
                    g.DateTimeEdit.DateTimePattern = DateTimePattern.SortableDateTime;
                    break;
                // Set the UniversalSortableDateTimeFormat
                case "UniversalSortableDateTimeFormat":
                    g.DateTimeEdit.DateTimePattern = DateTimePattern.UniversalSortableDateTime;
                    break;
                // Set the YearMonthFormat
                case "MonthYearFormat":
                    g.DateTimeEdit.DateTimePattern = DateTimePattern.YearMonth;
                    break;
                // Set the Pattern
                case "Custom Pattern":
                    g.DateTimeEdit.DateTimePattern = DateTimePattern.CustomPattern;
                    g.DateTimeEdit.CustomPattern = "MM-dd-yy";
                    break;
            }
            if (grid.CurrentCell.HasCurrentCell)
            {
                grid.CurrentCell.EndEdit();
                grid.CurrentCell.BeginEdit();
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
