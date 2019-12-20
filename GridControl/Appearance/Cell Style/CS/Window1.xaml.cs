#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Controls.Grid;

namespace CellStyleDemo
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {
        public Window1()
        {
            InitializeComponent();
            
            grid.Model.RowCount = 30;
            grid.Model.ColumnCount = 15;

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(1, 1, 1, 2));           
            SetInterior();
            SetFont();
            setFontWeights();
            setTextColor();
            setBorders();
            setOrientation();
        }

        private void setOrientation()
        {
            this.grid.Model.RowHeights[14] = 80d;
            this.grid.Model[13, 1].CellValue = "Orientation";
            this.grid.Model[13, 1].Font.FontSize = 15;
            this.grid.Model[13, 1].Background = Brushes.BlanchedAlmond;

            this.grid.Model[14, 1].Font.Orientation = 0;
            this.grid.Model[14, 1].CellValue = "Angle 0";
            this.grid.Model[14, 1].VerticalAlignment = VerticalAlignment.Center;
            this.grid.Model[14, 1].HorizontalAlignment = HorizontalAlignment.Center;

            this.grid.Model[14, 2].Font.Orientation = 30;
            this.grid.Model[14, 2].CellValue = "Angle 30";
            this.grid.Model[14, 2].VerticalAlignment = VerticalAlignment.Center;
            this.grid.Model[14, 2].HorizontalAlignment = HorizontalAlignment.Center;

            this.grid.Model[14, 3].Font.Orientation = 60;
            this.grid.Model[14, 3].CellValue = "Angle 60";
            this.grid.Model[14, 3].VerticalAlignment = VerticalAlignment.Center;
            this.grid.Model[14, 3].HorizontalAlignment = HorizontalAlignment.Center;

            this.grid.Model[14, 4].Font.Orientation = 90;
            this.grid.Model[14, 4].CellValue = "Angle 90";
            this.grid.Model[14, 4].VerticalAlignment = VerticalAlignment.Center;
            this.grid.Model[14, 4].HorizontalAlignment = HorizontalAlignment.Center;

            this.grid.Model[14, 5].Font.Orientation = 180;
            this.grid.Model[14, 5].CellValue = "Angle 180";
            this.grid.Model[14, 5].VerticalAlignment = VerticalAlignment.Center;
            this.grid.Model[14, 5].HorizontalAlignment = HorizontalAlignment.Center;

            this.grid.Model[14, 6].Font.Orientation = 270;
            this.grid.Model[14, 6].CellValue = "Angle 270";
            this.grid.Model[14, 6].VerticalAlignment = VerticalAlignment.Center;
            this.grid.Model[14, 6].HorizontalAlignment = HorizontalAlignment.Center;
        }

        private void setBorders()
        {
            int col = grid.Model.ColumnCount / 2;
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(20, 1, 20, grid.Model.ColumnCount));
            this.grid.Model[15, col + 1].CellValue = "Borders";
            this.grid.Model[15, col + 1].Font.FontSize = 15;
            this.grid.Model[15, col + 1].Background = Brushes.BlanchedAlmond;

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(16, col+1, 16, grid.Model.ColumnCount-1));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(17, col+1, 17, grid.Model.ColumnCount-1));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(18, col+1, 18, grid.Model.ColumnCount-1));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(19, col+1, 19, grid.Model.ColumnCount-1));

            this.grid.Model[16, col+1].Borders.Bottom = new Pen(Brushes.Blue, 1);
            this.grid.Model[16, col+1].Borders.Top = new Pen(Brushes.Red, 1);
            this.grid.Model[16, col+1].Borders.Right = new Pen(Brushes.Purple, 3);
            this.grid.Model[16, col+1].Borders.Left = new Pen(Brushes.RoyalBlue, 1);

            this.grid.Model[17, col + 1].Borders.All = new Pen(Brushes.Blue, 1) { DashStyle = DashStyles.Dash};
            this.grid.Model[18, col + 1].Borders.All = new Pen(Brushes.Red, 1) { DashStyle = DashStyles.Dot};
            this.grid.Model[19, col + 1].Borders.All = new Pen(Brushes.Green, 1) { DashStyle = DashStyles.DashDotDot };
        }

        private void setTextColor()
        {
            int col = grid.Model.ColumnCount / 2;

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(16, 1, 16, col));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(17, 1, 17, col));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(18, 1, 18, col));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(19, 1, 19, col));

            this.grid.Model[15, 1].CellValue = "Text Color";
            this.grid.Model[15, 1].Font.FontSize = 15;
            this.grid.Model[15, 1].Background = Brushes.BlanchedAlmond;

            this.grid.Model[16, 1].CellValue = "The quick brown fox jumps over the lazy dog";
            this.grid.Model[16, 1].Foreground = Brushes.Gray;

            this.grid.Model[17, 1].CellValue = "The quick brown fox jumps over the lazy dog";
            this.grid.Model[17, 1].Foreground = Brushes.Red;

            this.grid.Model[18, 1].CellValue = "The quick brown fox jumps over the lazy dog";
            this.grid.Model[18, 1].Foreground = Brushes.Blue;

            this.grid.Model[19, 1].CellValue = "The quick brown fox jumps over the lazy dog";
            this.grid.Model[19, 1].Foreground = Brushes.Green;
        }

        private void setFontWeights()
        {

            this.grid.Model[9, 1].CellValue = "Text Style";
            this.grid.Model[9, 1].Font.FontSize = 15;
            this.grid.Model[9, 1].Background = Brushes.BlanchedAlmond;

            int col = grid.Model.ColumnCount / 2;
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(10, 1, 10, col));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(11, 1, 11, col));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(12, 1, 12, col));

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(9, col + 1, 9, col+2));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(10, col + 1, 10, grid.Model.ColumnCount-1));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(11, col + 1, 11, grid.Model.ColumnCount-1));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(12, col + 1, 12, grid.Model.ColumnCount-1));

            this.grid.Model[10, 1].Font.FontWeight = FontWeights.Bold;
            this.grid.Model[10, 1].HorizontalAlignment = HorizontalAlignment.Center;
            this.grid.Model[10, 1].CellValue = "Font weight is Bold";

            this.grid.Model[11, 1].Font.FontStyle = FontStyles.Italic;
            this.grid.Model[11, 1].HorizontalAlignment = HorizontalAlignment.Center;
            this.grid.Model[11, 1].CellValue = "Font style is Itlaic";

            this.grid.Model[12, 1].Font.FontStyle = FontStyles.Normal;
            this.grid.Model[12, 1].HorizontalAlignment = HorizontalAlignment.Center;
            this.grid.Model[12, 1].CellValue = "Font style is Normal";

            this.grid.Model[9, col + 1].CellValue = "Text Decorations";
            this.grid.Model[9, col + 1].Font.FontSize = 15;
            this.grid.Model[9, col + 1].Background = Brushes.BlanchedAlmond;

            this.grid.Model[10, col + 1].Font.FontStyle = FontStyles.Normal;
            this.grid.Model[10, col + 1].Font.TextDecorations = new TextDecorationCollection(TextDecorations.Underline);
            this.grid.Model[10, col + 1].HorizontalAlignment = HorizontalAlignment.Center;
            this.grid.Model[10, col + 1].CellValue = "Underline Text";

            this.grid.Model[11, col + 1].Font.FontStyle = FontStyles.Normal;
            this.grid.Model[11, col + 1].Font.TextDecorations = new TextDecorationCollection(TextDecorations.Strikethrough);
            this.grid.Model[11, col + 1].HorizontalAlignment = HorizontalAlignment.Center;
            this.grid.Model[11, col + 1].CellValue = "Strikethrough Text";

            this.grid.Model[12, col + 1].Font.FontStyle = FontStyles.Normal;
            this.grid.Model[12, col + 1].Font.TextDecorations = new TextDecorationCollection(TextDecorations.OverLine);
            this.grid.Model[12, col + 1].HorizontalAlignment = HorizontalAlignment.Center;
            this.grid.Model[12, col + 1].CellValue = "OverLine Text";
        }

        private void SetInterior()
        {
            this.grid.Model[1, 1].CellValue = "Interior";
            this.grid.Model[1, 1].Font.FontSize = 15;
            this.grid.Model[1, 1].Background = Brushes.BlanchedAlmond;

            this.grid.Model[1, 1].HorizontalAlignment = HorizontalAlignment.Center;

            var CellBackground = this.grid.Model[2, 1];
            CellBackground.Background = Brushes.Aquamarine;
            this.grid.Model[2, 1].CellValue = "Aquamarine";

            this.grid.Model[2, 2].Background = Brushes.Violet;
            this.grid.Model[2, 2].CellValue = "Violet";

            this.grid.Model[2, 3].Background = Brushes.LavenderBlush;
            this.grid.Model[2, 3].CellValue = "LavenderBlush";

            this.grid.Model[2, 4].Background = GetLinerBrush();
            this.grid.Model[2, 4].CellValue = "Linear Brush";

            this.grid.Model[2, 5].Background = Brushes.CadetBlue;
            this.grid.Model[2, 5].CellValue = "CadetBlue";

            this.grid.Model[2, 6].Background = Brushes.LemonChiffon;
            this.grid.Model[2, 6].CellValue = "LemonChiffon";

        }
        

        private void SetFont()
        {
            this.grid.Model[4, 1].CellValue = "Font";
            this.grid.Model[4, 1].Font.FontSize = 15;
            this.grid.Model[4, 1].Background = Brushes.BlanchedAlmond;

            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(5, 1, 5, grid.Model.ColumnCount));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(6, 1, 6, grid.Model.ColumnCount));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(7, 1, 7, grid.Model.ColumnCount));
            this.grid.Model.CoveredCells.Add(new CoveredCellInfo(8, 1, 8, grid.Model.ColumnCount));

            this.grid.Model[5, 1].Font.FontSize = 10;
            this.grid.Model[5, 1].CellValue = "The quick brown fox jumps over the lazy dog";

            this.grid.Model[6, 1].Font.FontSize = 12;
            this.grid.Model[6, 1].CellValue = "The quick brown fox jumps over the lazy dog";

            this.grid.Model[7, 1].Font.FontSize = 14;
            this.grid.Model[7, 1].CellValue = "The quick brown fox jumps over the lazy dog";

            this.grid.Model[8, 1].Font.FontSize = 16;
            this.grid.RowHeights[8] = 30d;
            this.grid.Model[8, 1].CellValue = "The quick brown fox jumps over the lazy dog";
        }

        public Brush GetLinerBrush()
        {
            LinearGradientBrush brush = new LinearGradientBrush(new GradientStopCollection()
                {
                    new GradientStop(GridUtil.GetXamlConvertedValue<Color>("Red"),0.0d),
                    new GradientStop(GridUtil.GetXamlConvertedValue<Color>("Yellow"),1.0d),
                });
            brush.StartPoint = new Point(0.500006, 1.01436);
            brush.EndPoint = new Point(0.500006, -0.0213787);
            return brush;
        }
    }
}
