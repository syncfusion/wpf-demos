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
using System.Globalization;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.ComponentModel;
using Syncfusion.Windows.GridCommon;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for UpDownCell.xaml
    /// </summary>
    public partial class UpDownCell : DemoControl
    {
        GridStyleInfo g = new GridStyleInfo();

        public UpDownCell()
        {
            InitializeComponent();
            GridSettings();
        }
        public UpDownCell(string themename) : base(themename)
        {
            InitializeComponent();
            GridSettings();
        }
        void GridSettings()
        {

            grid.Model.RowCount = 50;
            grid.Model.ColumnCount = 25;

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(1, 1, 3, 6));
            grid.Model[1, 1].CellValue = "UpDown Edit";
            grid.Model[1, 1].Foreground = Brushes.Black;
            grid.Model[1, 1].Background = Brushes.LightBlue;
            grid.Model[1, 1].Font.FontSize = 18;
            grid.Model[1, 1].HorizontalAlignment = HorizontalAlignment.Center;
            grid.Model[1, 1].VerticalAlignment = VerticalAlignment.Center;
            grid.Model[1, 1].Font.FontWeight = FontWeights.Bold;

            grid.CurrentCellActivated += new GridRoutedEventHandler(grid_CurrentCellActivated);

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(4, 1, 5, 6));
            var cell = this.grid.Model[4, 1];
            cell.CellValue = "This sample shows how UpDown edit cells behave. We can set the range for the spin buttons.";
            cell.HorizontalAlignment = HorizontalAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.Font.FontWeight = FontWeights.Bold;

            var updownStyleInfo = this.grid.Model[6, 2];
            updownStyleInfo.CellType = "UpDownEdit";
            updownStyleInfo.NumberFormat = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalDigits = 3 };
            updownStyleInfo.UpDownEdit.FocusedBackground = Brushes.Tan;
            updownStyleInfo.UpDownEdit.FocusedBorderBrush = Brushes.Red;
            updownStyleInfo.UpDownEdit.FocusedForeground = Brushes.Yellow;
            updownStyleInfo.UpDownEdit.MaxValue = 10.00;
            updownStyleInfo.UpDownEdit.MinValue = 0;
            updownStyleInfo.CellValue = 10.000;

            var updownStyleInfo1 = this.grid.Model[8, 2];
            updownStyleInfo1.CellType = "UpDownEdit";
            updownStyleInfo1.NumberFormat = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalDigits = 3 };
            updownStyleInfo1.UpDownEdit.FocusedBackground = Brushes.BlueViolet;
            updownStyleInfo1.UpDownEdit.FocusedBorderBrush = Brushes.Red;
            updownStyleInfo1.UpDownEdit.FocusedForeground = Brushes.Bisque;
            updownStyleInfo1.UpDownEdit.MaxValue = 10.00;
            updownStyleInfo1.UpDownEdit.MinValue = 0;
            updownStyleInfo1.CellValue = 10.000;

            var updownStyleInfo2 = this.grid.Model[10, 2];
            updownStyleInfo2.CellType = "UpDownEdit";
            updownStyleInfo2.NumberFormat = new NumberFormatInfo { NumberGroupSeparator = " ", NumberDecimalDigits = 3 };
            updownStyleInfo2.UpDownEdit.FocusedBackground = Brushes.BurlyWood;
            updownStyleInfo2.UpDownEdit.FocusedBorderBrush = Brushes.Red;
            updownStyleInfo2.UpDownEdit.FocusedForeground = Brushes.Yellow;
            updownStyleInfo2.UpDownEdit.MaxValue = 10.00;
            updownStyleInfo2.UpDownEdit.MinValue = 0;
            updownStyleInfo2.CellValue = 10.000;
        }
        void grid_CurrentCellActivated(object sender, SyncfusionRoutedEventArgs args)
        {
            GridControlBase current_cell = args.Source as GridControlBase;
            if (grid.Model[current_cell.CurrentCell.RowIndex, current_cell.CurrentCell.ColumnIndex].CellType == "UpDownEdit")
            {
                g = grid.Model[current_cell.CurrentCell.RowIndex, current_cell.CurrentCell.ColumnIndex];
                SetNumberGroupSeparatorText();
                SetNumberGroupSizeText();
                SetFocusedBackgroundText();
                SetNumberDecimalDigitsText();
                SetMaxValueText();
                SetMinValueText();
                SetFocusedBorderBrushText();
                SetFocusedForegroundText();
            }
        }

        private void SetNumberGroupSeparatorText()
        {
            NumberGroup.Text = g.NumberFormat.NumberGroupSeparator;
        }

        private void SetNumberGroupSizeText()
        {
            String s = "";
            foreach (int i in g.NumberFormat.NumberGroupSizes)
                s += i + " ";
            NumberGroupSize.Text = s;
        }

        private void SetFocusedBackgroundText()
        {
            FocusedBackground.Text = g.UpDownEdit.FocusedBackground.ToString();
        }

        private void SetNumberDecimalDigitsText()
        {
            NumberDecimalDigits.Text = Convert.ToString(g.NumberFormat.NumberDecimalDigits);
        }

        private void SetMaxValueText()
        {
            MaxValue.Text = Convert.ToString(g.UpDownEdit.MaxValue);
        }

        private void SetMinValueText()
        {
            MinValue.Text = Convert.ToString(g.UpDownEdit.MinValue);
        }

        private void SetFocusedBorderBrushText()
        {
            FocusedBorderBrush.Text = g.UpDownEdit.FocusedBorderBrush.ToString();
        }

        private void SetFocusedForegroundText()
        {
            FocusedForeground.Text = g.UpDownEdit.FocusedForeground.ToString();
        }

        private void initialiseNumberFormat(int DecimalDigit, int[] GroupSize, String Separator)
        {
            try
            {
                g.NumberFormat = new NumberFormatInfo
                {
                    NumberDecimalDigits = DecimalDigit,
                    NumberGroupSeparator = Separator,
                    NumberGroupSizes = GroupSize
                };
                this.grid.CurrentCell.EndEdit();
            }
            catch (Exception)
            {
            }
        }

        private void SetAll(object sender, RoutedEventArgs e)
        {
            int count = NumberGroup.Text.Count();
            int count1 = NumberGroupSize.Text.Count();
            int count2 = NumberDecimalDigits.Text.Count();
            int count3 = MaxValue.Text.Count();
            int count4 = MinValue.Text.Count();
            int DecimalDigit = 0;
            String Separator = ".";
            int[] group = GetNumberGroupSizes();
            if (NumberGroup.Text != "" && count < 4)
                Separator = NumberGroup.Text;
            else
            {
              NumberGroup.Text = "";
            }
            if (NumberGroupSize.Text != "" && count1 < 6)
                group = GetNumberGroupSizes();
            else
            {
              
                NumberGroupSize.Text = "";
            }
            if (NumberDecimalDigits.Text != "" && count2 < 2)

                DecimalDigit = Convert.ToInt32(NumberDecimalDigits.Text);

            else
            {
                NumberDecimalDigits.Text = "";
            }
            if (MaxValue.Text != "" && count3 < 4)

                g.UpDownEdit.MaxValue = Convert.ToDouble(MaxValue.Text);

            else
            {
                MaxValue.Text = "";
            }
            if (MinValue.Text != "" && count4 < 3)

                g.UpDownEdit.MinValue = Convert.ToDouble(MinValue.Text);
            else
            {
                MinValue.Text = "";
            }
            if (FocusedBorderBrush.Text != "")
            {
                try
                {
                    g.UpDownEdit.FocusedBorderBrush = new SolidColorBrush(GridUtil.GetXamlConvertedValue<Color>(FocusedBorderBrush.Text));
                }

                catch (Exception )
                {
                   
                    FocusedBorderBrush.Text = "";
                }
            }
            else
                MessageBox.Show("Please enter input for BorderBrush ");
           

            if (FocusedForeground.Text != "")
            {
                try
                {
                    g.UpDownEdit.FocusedForeground = new SolidColorBrush(GridUtil.GetXamlConvertedValue<Color>(FocusedForeground.Text));
                }

                catch (Exception)
                {
                    //MessageBox.Show(c.Message);
                    FocusedForeground.Text = "";
                }
            }
            else
                MessageBox.Show("Please enter input for Foreground ");
            if (FocusedBackground.Text != "")
            {
                try
                {
                    g.UpDownEdit.FocusedBackground = new SolidColorBrush(GridUtil.GetXamlConvertedValue<Color>(FocusedBackground.Text));
                }

                catch (Exception )
                {
                    FocusedBackground.Text = "";
                }
            }
            else
            initialiseNumberFormat(DecimalDigit, group, Separator);
            if ((NumberGroup.Text == "") || (NumberGroupSize.Text == "") || (NumberDecimalDigits.Text == "") || (MaxValue.Text == "") || (MinValue.Text == "") || (FocusedBorderBrush.Text == "") || (FocusedForeground.Text == "") || (FocusedBackground.Text == ""))
            {
                MessageBox.Show("Please enter proper input");
            }

        }
        private int[] GetNumberGroupSizes()
        {
            String s = NumberGroupSize.Text;
            List<int> nos = new List<int>();
            int counter = 0;
            int[] size = new int[nos.Count];
            try
            {

                foreach (string subString in s.Split(' '))
                {
                    if (subString == "" || subString == " ")
                        break;
                    nos.Add(int.Parse(subString));
                }

                foreach (int no in nos)
                {
                    size[counter] = no;
                    counter++;
                }
            }
            catch (Exception)
            {

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
