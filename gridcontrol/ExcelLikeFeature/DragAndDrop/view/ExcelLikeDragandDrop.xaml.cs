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
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;
using Syncfusion.Windows.Shared;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for ExcelLikeDragandDrop.xaml
    /// </summary>
    public partial class ExcelLikeDragandDrop : DemoControl
    {
        public ExcelLikeDragandDrop()
        {
            InitializeComponent();
            this.DataContext = new Model(this.grid.Model);
            InitModel();
            this.grid.Model.Options.CopyPasteOption |= CopyPaste.IncludeStyle;
            this.grid1.Model.Options.CopyPasteOption |= CopyPaste.IncludeStyle;
            this.grid.Drop += grid_Drop;
            this.grid1.Drop += grid_Drop;
            grid.AllowDragDrop = false;
        }
        public ExcelLikeDragandDrop(string themename) : base(themename)
        {
            InitializeComponent();
            this.DataContext = new Model(this.grid.Model);
            InitModel();
            this.grid.Model.Options.CopyPasteOption |= CopyPaste.IncludeStyle;
            this.grid1.Model.Options.CopyPasteOption |= CopyPaste.IncludeStyle;
            this.grid.Drop += grid_Drop;
            this.grid1.Drop += grid_Drop;
            grid.AllowDragDrop = false;
        }
        void grid_Drop(object sender, DragEventArgs e)
        {
            grid.InvalidateCells();
            grid1.InvalidateCells();
        }

        void Options_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "DragDropDropTargetFlags")
            {
                InitCheckBoxes();
            }
        }

        private void InitCheckBoxes()
        {
            GridDragDropFlags flags = this.grid.Model.Options.DragDropDropTargetFlags;
            if ((flags & GridDragDropFlags.Styles) != 0)
            {
                this.Styles.IsChecked = true;
            }
            else
            {
                this.Styles.IsChecked = false;
            }

            if ((flags & GridDragDropFlags.Text) != 0)
            {
                this.Text.IsChecked = true;
            }
            else
            {
                this.Text.IsChecked = false;
            }

            if ((flags & GridDragDropFlags.EdgeScroll) != 0)
            {
                this.EdgeScroll.IsChecked = true;
            }
            else
            {
                this.EdgeScroll.IsChecked = false;
            }

            if ((flags & GridDragDropFlags.ColHeader) != 0)
            {
                this.ColHeader.IsChecked = true;
            }
            else
            {
                this.ColHeader.IsChecked = false;
            }

            if ((flags & GridDragDropFlags.RowHeader) != 0)
            {
                this.RowHeader.IsChecked = true;
            }
            else
            {
                this.RowHeader.IsChecked = false;
            }
        }

        private void InitModel()
        {
            SetGridProperties(this.grid);
            this.grid.Model.Options.PropertyChanged += new System.ComponentModel.PropertyChangedEventHandler(Options_PropertyChanged);
            this.grid.Model.Options.DataObjectConsumerOptions = GridDataObjectConsumerOptions.None;
            this.grid1.Model.Options.CopyPasteOption |= CopyPaste.IncludeStyle;
            this.grid1.Model.RowCount = 35;
            this.grid1.Model.ColumnCount = 25;
            this.grid1.Model.RowHeights.DefaultLineSize = 32;
            this.grid1.AllowDrop = true;
            this.grid1.Model.Options.ExcelLikeSelectionFrame = true;
            this.grid1.Model.Options.DataObjectConsumerOptions = GridDataObjectConsumerOptions.Styles;
            InitCheckBoxes();
        }

        private void SetGridProperties(GridControl gridControl)
        {
            gridControl.AllowDrop = true;
            gridControl.Model.Options.ExcelLikeSelectionFrame = true;
            Random r = new Random();
            gridControl.Model.RowCount = 30;
            gridControl.Model.ColumnCount = 25;
            gridControl.Model.RowHeights[1] = 50;
            gridControl.Model.RowHeights.DefaultLineSize = 32;
            gridControl.Model.ColumnWidths[2] = 100;
            for (int row = 1; row < 100; row++)
            {
                for (int col = 1; col <= 8; col++)
                {
                    if (col > 7)
                    {
                        continue;
                    }

                    if (r.Next(1, 4) == 2)
                    {
                        gridControl.Model[row, col].CellValue = r.Next(10, 100);
                    }
                    else if (r.Next(1, 4) == 3)
                    {
                        gridControl.Model[row, col].CellValue = "Text" + r.Next(10, 100).ToString();
                    }
                    else
                    {
                        gridControl.Model[row, col].CellValue = (r.Next(1000, 10000) * .01);
                    }

                    if (r.Next(10, 14) == 12)
                    {
                        gridControl.Model[row, col].Font.FontStyle = FontStyles.Italic;
                        gridControl.Model[row, col].Font.FontWeight = FontWeights.Bold;
                        gridControl.Model[row, col].Font.FontSize = 13;
                    }

                    if (r.Next(10, 14) == 13)
                    {
                        gridControl.Model[row, col].Background = Brushes.Orange;
                        gridControl.Model[row, col].Foreground = Brushes.Blue;
                    }

                    if (r.Next(10, 14) == 13)
                    {
                        gridControl.Model[row, col].HorizontalAlignment = HorizontalAlignment.Right;
                    }
                }
            }

            for (int row = 1; row <= gridControl.Model.RowCount; row++)
            {
                gridControl.Model[row, 7].CellType = "DateTimeEdit";
                gridControl.Model[row, 7].CellValue = DateTime.Now;
            }

            gridControl.Model.CoveredCells.Add(new Syncfusion.Windows.Controls.Cells.CoveredCellInfo(4, 4, 6, 6));
            gridControl.Model.CoveredCells.Add(new Syncfusion.Windows.Controls.Cells.CoveredCellInfo(8, 10, 12, 12));
            gridControl.Model.ColumnWidths[7] = 100;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UpdateDragDropTargets();
        }

        private void UpdateDragDropTargets()
        {
            GridDragDropFlags flags = GridDragDropFlags.Disabled;
            if (this.Styles.IsChecked.Value)
            {
                flags |= GridDragDropFlags.Styles;
            }
            else if ((flags & GridDragDropFlags.Styles) != 0)
            {
                flags = flags | ~GridDragDropFlags.Styles;
            }
            if (this.Text.IsChecked.Value)
            {
                flags |= GridDragDropFlags.Text;
            }
            else if ((flags & GridDragDropFlags.Text) != 0)
            {
                flags = flags | ~GridDragDropFlags.Text;
            }

            if (this.ColHeader.IsChecked.Value)
            {
                flags |= GridDragDropFlags.ColHeader;
            }
            else if ((flags & GridDragDropFlags.ColHeader) != 0)
            {
                flags = flags | ~GridDragDropFlags.ColHeader;
            }
            if (this.RowHeader.IsChecked.Value)
            {
                flags |= GridDragDropFlags.RowHeader;
            }
            else if ((flags & GridDragDropFlags.RowHeader) != 0)
            {
                flags = flags | ~GridDragDropFlags.RowHeader;
            }
            if (this.EdgeScroll.IsChecked.Value)
            {
                flags |= GridDragDropFlags.EdgeScroll;
            }
            else if ((flags & GridDragDropFlags.EdgeScroll) != 0)
            {
                flags = flags | ~GridDragDropFlags.EdgeScroll;
            }

            this.grid.Model.Options.DragDropDropTargetFlags = flags;
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(combo.SelectedIndex==0)
                grid.AllowDragDrop = false;
			else
				grid.AllowDragDrop = true;
        }
    }

    public class Model
    {
        public Model(GridModel model)
        {
            this.model = model;
        }

        GridModel model
        {
            get;
            set;
        }

        public GridDataObjectConsumerOptions ConsumerOptions
        {
            get
            {
                return this.model.Options.DataObjectConsumerOptions;
            }
            set
            {
                this.model.Options.DataObjectConsumerOptions = value;
            }
        }

        public GridDragDropFlags DragDropTagets
        {
            get
            {
                return this.model.Options.DragDropDropTargetFlags;
            }
            set
            {
                this.model.Options.DragDropDropTargetFlags = value;
            }
        }
    }
}
