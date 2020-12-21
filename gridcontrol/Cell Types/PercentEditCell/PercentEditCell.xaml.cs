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
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Globalization;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.GridCommon;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for PercentEditCell.xaml
    /// </summary>
    public partial class PercentEditCell : DemoControl
    {
        GridStyleInfo g = new GridStyleInfo();
        public PercentEditCell()
        {
            InitializeComponent();
            GridSettings();
        }

        public PercentEditCell(string themename) : base(themename)
        {
            InitializeComponent();
            GridSettings();
        }
        void GridSettings()
        {

            grid.Model.RowCount = 50;
            grid.Model.ColumnCount = 25;
            g = grid.Model[7, 2];

            grid.CurrentCellActivated += new GridRoutedEventHandler(grid_CurrentCellActivated);

            int[] sizes = { 2, 3, 4 };

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(1, 1, 3, 5));
            grid.Model[1, 1].CellValue = "Percent Edit";
            grid.Model[1, 1].Foreground = Brushes.Black;
            grid.Model[1, 1].Background = Brushes.LightBlue;
            grid.Model[1, 1].Font.FontSize = 18;
            grid.Model[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
            grid.Model[1, 1].Font.FontWeight = FontWeights.Bold;

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(4, 1, 6, 5));
            var cell = grid.Model[4, 1];
            cell.CellValue = "This cell below shows the percent edit cells behaviour. The number of decimal digits is set to 2 and the mode is set to Percent mode while editing";
            cell.Font.FontWeight = FontWeights.Bold;
            cell.HorizontalAlignment = HorizontalAlignment.Center;


            var percentStyleInfo = this.grid.Model[7, 2];
            percentStyleInfo.CellType = "PercentEdit";

            percentStyleInfo.NumberFormat = new System.Globalization.NumberFormatInfo()
            {
                PercentSymbol = "%",
                PercentGroupSizes = new int[] { 1, 2, 3 },
                PercentDecimalDigits = 2,
                PercentGroupSeparator = ",",
                //PercentDecimalSeparator = "."

            };
            percentStyleInfo.PercentEditMode = Syncfusion.Windows.Shared.PercentEditMode.PercentMode;
            percentStyleInfo.CellValue = 19;

            var percentStyleInfo2 = this.grid.Model[9, 2];
            percentStyleInfo2.CellType = "PercentEdit";
            percentStyleInfo2.NumberFormat = new System.Globalization.NumberFormatInfo()
            {
                PercentSymbol = "%",
                PercentGroupSizes = new int[] { 3 },
                PercentDecimalDigits = 4,
                PercentGroupSeparator = ",",
                //PercentDecimalSeparator = "."

            };
            percentStyleInfo2.PercentEditMode = Syncfusion.Windows.Shared.PercentEditMode.DoubleMode;
            percentStyleInfo2.CellValue = 91;
        }
        void grid_CurrentCellActivated(object sender, SyncfusionRoutedEventArgs args)
        {
            GridControlBase current_cell = args.Source as GridControlBase;
            if (grid.Model[current_cell.CurrentCell.RowIndex, current_cell.CurrentCell.ColumnIndex].CellType == "PercentEdit")
            {
                g = grid.Model[current_cell.CurrentCell.RowIndex, current_cell.CurrentCell.ColumnIndex];
                SetPercentSeperatorText();
                SetNumGroupText();
                SetPercentDecimalDigitsText();
                SetPercentSymbolText();
                setPercentEditModeText();
            }
        }

        private void setPercentEditModeText()
        {
            if (g.PercentEditMode == PercentEditMode.DoubleMode)
                PercentEditCombo.SelectedIndex = 0;
            else
                PercentEditCombo.SelectedIndex = 1;
        }

        private void SetPercentSeperatorText()
        {
            PercentSeparator.Text = g.NumberFormat.PercentGroupSeparator;
        }

        private void SetNumGroupText()
        {
            String s = "";
            foreach (int i in g.NumberFormat.PercentGroupSizes)
                s += i + " ";
            NumberGroup.Text = s;
        }

        private void SetPercentDecimalDigitsText()
        {
            NoOfPercentDigits.Text = Convert.ToString(g.NumberFormat.PercentDecimalDigits);
        }

        private void SetPercentSymbolText()
        {
            PercentSymbol.Text = g.NumberFormat.PercentSymbol;
        }

        private void initialiseNumberFormat(int PDecimalDigit, String Psymbol, int[] PGroup, String PSeperator, PercentEditMode mode)
        {
            g.NumberFormat = new NumberFormatInfo
            {
                PercentSymbol = Psymbol,
                PercentGroupSizes = PGroup,
                PercentDecimalDigits = PDecimalDigit,
                PercentGroupSeparator = PSeperator

            };
            g.PercentEditMode = mode;
            grid.CurrentCell.EndEdit();
        }

        private void SetAll(object sender, RoutedEventArgs e)
        {
            try
            {
                String PSeperator = PercentSeparator.Text;
                int PDecimalDigit = Convert.ToInt32(NoOfPercentDigits.Text);
                String Psymbol = PercentSymbol.Text;
                int[] PGroup = GetNumberGroupSizes();
                PercentEditMode mode = PercentEditMode.DoubleMode;
                if (PercentEditCombo.SelectedIndex == 0)
                    mode = PercentEditMode.DoubleMode;
                else if (PercentEditCombo.SelectedIndex == 1)
                    mode = PercentEditMode.PercentMode;
                initialiseNumberFormat(PDecimalDigit, Psymbol, PGroup, PSeperator, mode);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int[] GetNumberGroupSizes()
        {
            String s = NumberGroup.Text;
            List<int> nos = new List<int>();
            int counter = 0;
            foreach (string subString in s.Split(' '))
            {
                if (subString == "" || subString == " ")
                    break;
                nos.Add(int.Parse(subString));
            }
            int[] size = new int[nos.Count];
            foreach (int no in nos)
            {
                size[counter] = no;
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
