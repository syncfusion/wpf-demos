#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Diagnostics;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;

namespace Syncfusion.WpfGridSample
{

    public class SampleGridControl : GridControl
    {
        Pen gridLinePen;

        public SampleGridControl()
        {
            GridCellNestedGridModel gridModel = new GridCellNestedGridModel(GridNestedAxisLayout.Normal, GridNestedAxisLayout.Normal);
            GridCellNestedScrollGridModel scrollGridModel = new GridCellNestedScrollGridModel();
            GridCellNestedGridModel shareRowLayoutGridModel = new GridCellNestedGridModel(GridNestedAxisLayout.Shared, GridNestedAxisLayout.Normal);
            GridCellNestedGridModel shareColumnLayoutGridModel = new GridCellNestedGridModel(GridNestedAxisLayout.Normal, GridNestedAxisLayout.Shared);
            GridCellNestedGridModel gridInRowModel = new GridCellNestedGridModel(GridNestedAxisLayout.Nested, GridNestedAxisLayout.Normal);

            Model.CellModels.Add("Grid", gridModel);
            Model.CellModels.Add("ScrollGrid", scrollGridModel);
            Model.CellModels.Add("ShareRowLayoutGrid", shareRowLayoutGridModel);
            Model.CellModels.Add("ShareColumnLayoutGrid", shareColumnLayoutGridModel);
            Model.CellModels.Add("GridInRow", gridInRowModel);


            #region Sample Setup

            RowHeights.DefaultLineSize = 20;
            Model.RowCount = 6000;

            ColumnWidths.DefaultLineSize = 100;
            Model.ColumnCount = 20;

            Random buttonRandom = new Random(23);
            Random orangePenRandom = new Random(2);
            Random backBrushRandom = new Random(18);

            gridLinePen = new Pen(Brushes.DarkGray, 1);
            gridLinePen.Freeze();

            Pen orangePen = new Pen(Brushes.DarkOrange, 5);
            orangePen.EndLineCap = PenLineCap.Triangle;
            orangePen.StartLineCap = PenLineCap.Triangle;
            orangePen.Freeze();

            Pen bgPen = new Pen(Brushes.Gold, 6);
            bgPen.EndLineCap = PenLineCap.Triangle;
            bgPen.StartLineCap = PenLineCap.Triangle;
            bgPen.Freeze();


            SolidColorBrush bg1 = new SolidColorBrush(Color.FromArgb(128, 128, 0, 0));
            SolidColorBrush bg2 = new SolidColorBrush(Color.FromArgb(128, 0, 128, 0));
            SolidColorBrush bg3 = new SolidColorBrush(Color.FromArgb(128, 0, 0, 128));

            GradientBrush bg = new LinearGradientBrush(Color.FromArgb(128, 255, 255, 0), Color.FromArgb(128, 0, 255, 255), 45.0);
            //GradientBrush bg = new LinearGradientBrush(Colors.Gray, Colors.White, 45);
            CellSpanBackgrounds.Add(new CellSpanBackgroundInfo(9, 2, 22, 8, false, false, bg1, bgPen));
            CellSpanBackgrounds.Add(new CellSpanBackgroundInfo(3, 4, 28, 6, false, false, bg2, bgPen));
            CellSpanBackgrounds.Add(new CellSpanBackgroundInfo(25, 2, 30, 4, false, false, bg3, bgPen));
            CellSpanBackgrounds.Add(new CellSpanBackgroundInfo(0, 0, 12, 1, false, false, bg, null));
            CoveredCells.Add(new CoveredCellInfo(4, 0, 6, 1));
            CoveredCells.Add(new CoveredCellInfo(4, 19, 6, 19));
            CoveredCells.Add(new CoveredCellInfo(6, 2, 8, 4));
            CoveredCells.Add(new CoveredCellInfo(4, 2, 5, 3));

            Model.QueryCellInfo += new GridQueryCellInfoEventHandler(Model_QueryCellInfo);

            for (int n = 0; n < Model.RowCount; n++)
            {
                for (int c = 0; c < Model.ColumnCount; c++)
                {
                    GridStyleInfo ci = new GridStyleInfo();

                    if (backBrushRandom.Next(10) == 5)
                        ci.Background = Brushes.Tomato;

                    if (c == 5)//% 4 == 3)// || c == 5)
                    {
                        ci.CellType = "CheckBox";
                        ci.Description = String.Format("Check {0}:{1}", n, c);
                        ci.CellValue = n % 2 == 0;
                    }

                    if (c == 2)
                    {
                        ci.CellType = "TextBox";
                        ci.CellValue = String.Format("Edit {0}:{1}", n, c);
                    }


                    if (buttonRandom.Next(10) == 5)
                    {
                        ci.CellType = "Button";
                        ci.Description = String.Format("Click {0}:{1}", n, c);
                        ci.Background = null;
                    }

                    if (orangePenRandom.Next(10) == 5)
                    {
                        ci.Borders.Right = orangePen;
                        ci.Borders.Bottom = orangePen;
                        ci.Borders.Left = orangePen;
                        ci.Borders.Top = orangePen;
                        //ci.BorderMargins.Right = orangePen.Thickness / 2;
                        //ci.BorderMargins.Bottom = orangePen.Thickness / 2;
                        //ci.BorderMargins.Top = orangePen.Thickness / 2;
                        //ci.BorderMargins.Left = orangePen.Thickness / 2;
                    }

                    if (!ci.IsEmpty)
                    {
                        //if (n == Model.RowCount - 1 && c == Model.ColCount - 1)
                        //    Console.WriteLine("ddd");
                        Model[n, c].Background = Brushes.Red;
                        Model[n, c] = ci;
                    }
                }
            }

            if (true)
            {
                Model[6, 2].CellType = "Grid";
                //Model[6, 2].CellRenderer = gridRenderer;
                Model[6, 2].CellValue = GetSimpleNestedGrid();
            }

            if (true)
            {
                CoveredCellInfo coveredCell1 = new CoveredCellInfo(36, 0, 36, Model.ColumnCount - 1);
                coveredCell1.SpanWholeRow = true;
                CoveredCells.Add(coveredCell1);
                Model[36, 0].CellType = "GridInRow";
                //Model[36, 0].CellRenderer = gridInRowRenderer;
                GridModel m = GetSimpleNestedGrid();
                Model[36, 0].CellValue = m;
                //PixelScrollAxis mb = new PixelScrollAxis(new ScrollInfo(), m.RowHeights);
                RowHeights.SetNestedLines(36, m.RowHeights);//.Distances;//.TotalDistance

                GridModel m2 = GetSimpleNestedGrid();
                m[5, 1].Background = new SolidColorBrush(Colors.LightCoral);
                m[5, 1].CellValue = m2;
                m2.ColumnWidths.DefaultLineSize = 65;
                m[5, 1].CellType = "GridInRow";
                //m[5, 1].CellRenderer = gridInRowRenderer;
                m.RowHeights.SetNestedLines(5, m2.RowHeights);
                m.CoveredCells.Add(new CoveredCellInfo(5, 1, 5, 6));
            }

            if (true)
            {
                Model[40, 2].CellType = "ScrollGrid";
                //Model[40, 2].CellRenderer = scrollGridRenderer;
                Model[40, 2].CellValue = GetScrollNestedGrid();
                CoveredCells.Add(new CoveredCellInfo(40, 2, 49, 5));
            }

            if (true)
            {
                Model[60, 1].CellType = "ShareColumnLayoutGrid";
                //Model[60, 1].CellRenderer = shareColumnLayoutGridRenderer;
                Model[60, 1].BorderMargins.Top = 0;
                Model[60, 1].BorderMargins.Left = 0;
                Model[60, 1].BorderMargins.Right = 0;
                Model[60, 1].BorderMargins.Bottom = 0;
                Model[60, 1].Background = SystemColors.InactiveCaptionBrush;
                GridModel nestedGridWithSharedColumnsModel = GetNestedGridWithSharedColumnsModel();
                Model[60, 1].CellValue = nestedGridWithSharedColumnsModel;
                CoveredCells.Add(new CoveredCellInfo(60, 1, 80, 1 + nestedGridWithSharedColumnsModel.ColumnCount - 1));
            }

            if (true)
            {

                Model[100, 2].CellType = "ShareRowLayoutGrid";
                //Model[100, 2].CellRenderer = shareRowLayoutGridRenderer;
                Model[100, 2].BorderMargins.Top = 0;
                Model[100, 2].BorderMargins.Left = 0;
                Model[100, 2].BorderMargins.Right = 0;
                Model[100, 2].BorderMargins.Bottom = 0;
                Model[100, 2].Background = SystemColors.InactiveCaptionBrush;
                GridModel nestedGridWithSharedRowsModel = GetNestedGridWithSharedRowsModel();
                Model[100, 2].CellValue = nestedGridWithSharedRowsModel;
                CoveredCells.Add(new CoveredCellInfo(100, 2, 100 + nestedGridWithSharedRowsModel.RowCount - 1, 5));

                Random rnd = new Random(120);
                for (int n = 0; n < 100; n++)
                    RowHeights[rnd.Next(Model.RowCount)] = rnd.Next(10, 50);

                for (int n = 0; n < 5; n++)
                    ColumnWidths[rnd.Next(Model.ColumnCount)] = rnd.Next(40, 400);
            }

            RowHeights.SetHidden(10, 20, true);

            FrozenRows = 2;
            FrozenColumns = 1;
            FooterColumns = 1;
            FooterRows = 1;

            Console.WriteLine(FrozenRows);
            Console.WriteLine(FrozenColumns);

            #endregion

            GridStyleInfo tableStyle = Model.TableStyle;
            GridStyleInfo headerStyle = Model.HeaderStyle;
            GridStyleInfo footerStyle = Model.FooterStyle;

            tableStyle.CellType = "TextBox";
            tableStyle.BorderMargins.Top = gridLinePen.Thickness;
            tableStyle.BorderMargins.Left = gridLinePen.Thickness;
            tableStyle.BorderMargins.Right = gridLinePen.Thickness / 2;
            tableStyle.BorderMargins.Bottom = gridLinePen.Thickness / 2;
            tableStyle.Borders.Right = gridLinePen;
            tableStyle.Background = null;// Brushes.White;
            tableStyle.Borders.Bottom = gridLinePen;

            headerStyle.Background = SystemColors.ControlBrush;
            headerStyle.CellType = "Static";

            footerStyle.Background = Brushes.Wheat;
        }

        void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            // Setting CellValue here would overwrite CellData - better is to 
            if (!e.Style.HasCellValue)
                e.Style.CellValue = String.Format("{0}:{1}", e.Cell.RowIndex, e.Cell.ColumnIndex);
        }

        Brush transparentBlanchedAlmond = ColorHelper.CreateFrozenSolidColorBrush(192, Colors.BlanchedAlmond);

        private GridModel GetSimpleNestedGrid()
        {
            GridModel model = new GridModel();

            model.Options.AllowSelection = GridSelectionFlags.Cell;
            model.RowHeights.DefaultLineSize = 20;
            model.RowCount = 30;

            model.ColumnWidths.DefaultLineSize = 50;
            model.ColumnCount = 25;

            model.HeaderRows = 0;
            model.FrozenRows = 0;
            model.HeaderColumns = 1;
            model.FrozenColumns = 1;

            for (int n = 0; n < model.RowCount; n++)
            {
                for (int c = 0; c < model.ColumnCount; c++)
                {
                    GridStyleInfo ci = new GridStyleInfo();
                    ci.CellType = "TextBox";
                    ci.CellValue = String.Format("{0}:{1}", n, c);
                    ci.Background =  transparentBlanchedAlmond;
                    model.Data[n, c] = ci.Store;
                }
            }

            return model;
        }

        private GridModel GetScrollNestedGrid()
        {
            GridModel nestedGrid = new GridModel();

            nestedGrid.Options.AllowSelection = GridSelectionFlags.Cell;
            nestedGrid.RowHeights.DefaultLineSize = 20;
            nestedGrid.RowCount = 50;

            nestedGrid.ColumnWidths.DefaultLineSize = 50;
            nestedGrid.ColumnCount = 12;

            Brush headerBrush = ColorHelper.CreateFrozenSolidColorBrush(128, Colors.DarkGray);
            nestedGrid.BaseStylesMap["Header"].StyleInfo.Background = headerBrush;

            for (int n = 0; n < nestedGrid.RowCount; n++)
            {
                for (int c = 0; c < nestedGrid.ColumnCount; c++)
                {
                    GridStyleInfo ci = new GridStyleInfo();
                    ci.CellType = "TextBox";
                    ci.CellValue = String.Format("{0}:{1}", n, c);
                    nestedGrid.Data[n, c] = ci.Store;
                }
            }

            return nestedGrid;
        }

        private GridModel GetNestedGridWithSharedColumnsModel()
        {
            GridModel model = new GridModel();

            Pen gridLinePen = new Pen(Brushes.DarkGray, 1);
            gridLinePen.Freeze();

            model.Options.AllowSelection = GridSelectionFlags.Cell;
            model.ColumnWidths.HeaderLineCount = 1;
            model.ColumnCount = 10;

            model.RowHeights.HeaderLineCount = 1;
            model.RowHeights.FooterLineCount = 1;
            model.RowCount = 13; // make sure this matched covered cell size ...
            model.RowHeights.DefaultLineSize = 30;

            Color clr = Color.FromArgb(128, 0, 0, 0);
            Brush headerBrush = new SolidColorBrush(clr);
            headerBrush.Freeze();

            Color clr2 = Color.FromArgb(128, 128, 0, 0);
            Brush footerBrush = new SolidColorBrush(clr2);
            footerBrush.Freeze();

            for (int n = 0; n < model.RowCount; n++)
            {
                for (int c = 0; c < model.ColumnCount; c++)
                {
                    GridStyleInfo ci = new GridStyleInfo();
                    ci.CellType = "TextBox";
                    ci.CellValue = String.Format("{0}:{1}", n, c);
                    ci.BorderMargins.Top = gridLinePen.Thickness;
                    ci.BorderMargins.Left = gridLinePen.Thickness;
                    ci.BorderMargins.Right = gridLinePen.Thickness / 2;
                    ci.BorderMargins.Bottom = gridLinePen.Thickness / 2;
                    ci.Borders.Right = gridLinePen;
                    ci.Background = null;// Brushes.White;
                    ci.Borders.Bottom = gridLinePen;
                    model.Data[n, c] = ci.Store;

                    if (c == 0 || n == 0)
                    {
                        ci.CellType = "Static";
                        ci.Background = headerBrush;
                    }

                    if (c == 3 || n == 3)
                    {
                        ci.CellType = "CheckBox";
                        ci.CellValue = false;
                    }
                    if (c == 4 || n == 4)
                    {
                        ci.CellType = "Static";
                        ci.CellValue = "Static";
                    }
                    if (n == model.RowCount - 1)
                    {
                        ci.CellType = "Static";
                        ci.Background = footerBrush;
                    }
                }
            }
            model.SelectedCells = GridRangeInfo.Empty;

            return model;
        }

        private GridModel GetNestedGridWithSharedRowsModel()
        {
            GridModel model = new GridModel();

            Pen gridLinePen = new Pen(Brushes.DarkGray, 1);
            gridLinePen.Freeze();

            model.Options.AllowSelection = GridSelectionFlags.Cell;
            model.ColumnWidths.DefaultLineSize = 50;
            model.ColumnWidths.HeaderLineCount = 1;
            model.ColumnCount = 12;

            model.RowHeights.HeaderLineCount = 1;
            model.RowHeights.FooterLineCount = 1;
            model.RowCount = 601; // make sure this matched covered cell size ...

            Color clr = Color.FromArgb(128, 0, 0, 0);
            Brush headerBrush = new SolidColorBrush(clr);
            headerBrush.Freeze();

            Color clr2 = Color.FromArgb(128, 128, 0, 0);
            Brush footerBrush = new SolidColorBrush(clr2);
            footerBrush.Freeze();

            for (int n = 0; n < model.RowCount; n++)
            {
                for (int c = 0; c < model.ColumnCount; c++)
                {
                    GridStyleInfo ci = new GridStyleInfo();
                    ci.CellType = "TextBox";
                    ci.CellValue = String.Format("{0}:{1}", n, c);
                    ci.BorderMargins.Top = gridLinePen.Thickness;
                    ci.BorderMargins.Left = gridLinePen.Thickness;
                    ci.BorderMargins.Right = gridLinePen.Thickness / 2;
                    ci.BorderMargins.Bottom = gridLinePen.Thickness / 2;
                    ci.Borders.Right = gridLinePen;
                    ci.Background = null;// Brushes.White;
                    ci.Borders.Bottom = gridLinePen;
                    model.Data[n, c] = ci.Store;

                    if (c == 0 || n == 0)
                    {
                        ci.CellType = "Static";
                        ci.Background = headerBrush;
                    }

                    if (n == model.RowCount - 1)
                    {
                        ci.CellType = "Static";
                        ci.Background = footerBrush;
                    }
                }
            }

            GridModel nestedGridWithSharedRowsModel = GetSecondNestedGridWithSharedRowsModel();
            model[10, 2].CellType = "ShareRowLayoutGrid";
            model[10, 2].BorderMargins.Top = 0;
            model[10, 2].BorderMargins.Left = 0;
            model[10, 2].BorderMargins.Right = 0;
            model[10, 2].BorderMargins.Bottom = 0;
            model[10, 2].Background = SystemColors.InactiveCaptionBrush;
            model[10, 2].CellValue = nestedGridWithSharedRowsModel;
            model.CoveredCells.Add(new CoveredCellInfo(10, 2, 10 + nestedGridWithSharedRowsModel.RowCount - 1, 7));
            model.SelectedCells = GridRangeInfo.Empty;

            return model;
        }

        private GridModel GetSecondNestedGridWithSharedRowsModel()
        {
            GridModel model = new GridModel();

            Pen gridLinePen = new Pen(Brushes.DarkGray, 1);
            gridLinePen.Freeze();

            model.Options.AllowSelection = GridSelectionFlags.Cell;
            model.ColumnWidths.DefaultLineSize = 40;
            model.ColumnWidths.HeaderLineCount = 1;
            model.ColumnCount = 8;

            model.RowHeights.HeaderLineCount = 1;
            model.RowHeights.FooterLineCount = 1;
            model.RowCount = 121; // make sure this matched covered cell size ...

            Color clr = Color.FromArgb(128, 0, 0,128);
            Brush headerBrush = new SolidColorBrush(clr);
            headerBrush.Freeze();

            Color clr2 = Color.FromArgb(128, 0, 128, 0);
            Brush footerBrush = new SolidColorBrush(clr2);
            footerBrush.Freeze();

            for (int n = 0; n < model.RowCount; n++)
            {
                for (int c = 0; c < model.ColumnCount; c++)
                {
                    GridStyleInfo ci = new GridStyleInfo();
                    ci.CellType = "TextBox";
                    ci.CellValue = String.Format("{0}:{1}", n, c);
                    ci.BorderMargins.Top = gridLinePen.Thickness;
                    ci.BorderMargins.Left = gridLinePen.Thickness;
                    ci.BorderMargins.Right = gridLinePen.Thickness / 2;
                    ci.BorderMargins.Bottom = gridLinePen.Thickness / 2;
                    ci.Borders.Right = gridLinePen;
                    ci.Background = null;// Brushes.White;
                    ci.Borders.Bottom = gridLinePen;
                    model.Data[n, c] = ci.Store;

                    if (c == 0 || n == 0)
                    {
                        ci.CellType = "Static";
                        ci.Background = headerBrush;
                    }

                    if (n == model.RowCount - 1)
                    {
                        ci.CellType = "Static";
                        ci.Background = footerBrush;
                    }
                }
            }

            GridModel nestedGridWithSharedRowsModel = GetThirdNestedGridWithSharedRowsModel();
            model[15, 2].CellType = "ShareRowLayoutGrid";
            //model[15, 2].CellRenderer = shareRowLayoutGridRenderer;
            model[15, 2].BorderMargins.Top = 0;
            model[15, 2].BorderMargins.Left = 0;
            model[15, 2].BorderMargins.Right = 0;
            model[15, 2].BorderMargins.Bottom = 0;
            model[15, 2].Background = Brushes.Wheat;
            model[15, 2].CellValue = nestedGridWithSharedRowsModel;
            model.CoveredCells.Add(new CoveredCellInfo(15, 2, 15 + nestedGridWithSharedRowsModel.RowCount - 1, 5));
            model.SelectedCells = GridRangeInfo.Empty;


            return model;
        }

        private GridModel GetThirdNestedGridWithSharedRowsModel()
        {
            GridModel model = new GridModel();

            Pen gridLinePen = new Pen(Brushes.DarkGray, 1);
            gridLinePen.Freeze();

            model.Options.AllowSelection = GridSelectionFlags.Cell;
            model.ColumnWidths.DefaultLineSize = 35;
            model.ColumnWidths.HeaderLineCount = 1;
            model.ColumnCount = 4;

            model.RowHeights.HeaderLineCount = 1;
            model.RowHeights.FooterLineCount = 1;
            model.RowCount = 31; // make sure this matched covered cell size ...

            Color clr = Color.FromArgb(128, 0, 128, 128);
            Brush headerBrush = new SolidColorBrush(clr);
            headerBrush.Freeze();

            Color clr2 = Color.FromArgb(128, 128, 128, 0);
            Brush footerBrush = new SolidColorBrush(clr2);
            footerBrush.Freeze();

            for (int n = 0; n < model.RowCount; n++)
            {
                for (int c = 0; c < model.ColumnCount; c++)
                {
                    GridStyleInfo ci = new GridStyleInfo();
                    ci.CellType = "TextBox";
                    ci.CellValue = String.Format("{0}:{1}", n, c);
                    ci.BorderMargins.Top = gridLinePen.Thickness;
                    ci.BorderMargins.Left = gridLinePen.Thickness;
                    ci.BorderMargins.Right = gridLinePen.Thickness / 2;
                    ci.BorderMargins.Bottom = gridLinePen.Thickness / 2;
                    ci.Borders.Right = gridLinePen;
                    ci.Background = null;// Brushes.White;
                    ci.Borders.Bottom = gridLinePen;
                    model.Data[n, c] = ci.Store;

                    if (c == 0 || n == 0)
                    {
                        ci.CellType = "Static";
                        ci.Background = headerBrush;
                    }

                    if (n == model.RowCount - 1)
                    {
                        ci.CellType = "Static";
                        ci.Background = footerBrush;
                    }
                }
            }
            model.SelectedCells = GridRangeInfo.Empty;

            return model;
        }
  
    }

}
