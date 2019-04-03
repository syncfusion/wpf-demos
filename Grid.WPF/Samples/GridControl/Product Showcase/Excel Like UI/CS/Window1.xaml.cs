#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;
using System.ComponentModel;
using EXCEL.Helpers;
using EXCEL.ViewModel;
using System.Windows.Interactivity;
using EXCEL.Behaviors;
using Syncfusion.Windows.Controls.Cells;


namespace EXCEL
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : RibbonWindow, IMainView
    {
        SampleGridControl currentGrid = new SampleGridControl();

        public Window1()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel(this);
            this.ForegroundColorPicker.ColorChanged += new PropertyChangedCallback(ForegroundColorPicker_ColorChanged);
            this.BackgroundColorPicker.ColorChanged += new PropertyChangedCallback(BackgroundColorPicker_ColorChanged);
            this.ForeColorSplitButton.Click += new RoutedEventHandler(ForeColorSplitButton_Click);
            this.BGColorSplitButton.Click += new RoutedEventHandler(BGColorSplitButton_Click);
            BackgroundColorPicker.MoreColorWindowOpening += BackgroundColorPicker_MoreColorWindowOpening;
            ForegroundColorPicker.MoreColorWindowOpening += ForegroundColorPicker_MoreColorWindowOpening;
        }

        void ForegroundColorPicker_MoreColorWindowOpening(object sender, MoreColorCancelEventArgs args)
        {
            this.ForeColorSplitButton.IsDropDownOpen = false;
        }

        void BackgroundColorPicker_MoreColorWindowOpening(object sender, MoreColorCancelEventArgs args)
        {
            this.BGColorSplitButton.IsDropDownOpen = false;
        }
        void BGColorSplitButton_Click(object sender, RoutedEventArgs e)
        {
            var color = this.BackgroundColorPicker.Color;
            SampleGridControl ActiveGrid = ((Tab1.SelectedItem as TabItem).Content as ScrollViewer).Content as SampleGridControl;
            if (ActiveGrid != null)
            {
                GridRangeInfoList rangeList = ActiveGrid.Model.SelectedRanges;
                foreach (GridRangeInfo range in rangeList)
                {
                    for (int row = range.Top; row <= range.Bottom; row++)
                    {
                        for (int col = range.Left; col <= range.Right; col++)
                        {
                            ActiveGrid.Model[row, col].Background = new SolidColorBrush(color);
                        }
                    }
                    ActiveGrid.InvalidateCell(range);
                }
                ActiveGrid.InvalidateVisual();
            }
            this.BGColorSplitButton.IsDropDownOpen = false;
        }

        void ForeColorSplitButton_Click(object sender, RoutedEventArgs e)
        {
            var color = this.ForegroundColorPicker.Color;
            SampleGridControl ActiveGrid = ((Tab1.SelectedItem as TabItem).Content as ScrollViewer).Content as SampleGridControl;
            if (ActiveGrid != null)
            {
                GridRangeInfoList rangeList = ActiveGrid.Model.SelectedRanges;
                foreach (GridRangeInfo range in rangeList)
                {
                    for (int row = range.Top; row <= range.Bottom; row++)
                    {
                        for (int col = range.Left; col <= range.Right; col++)
                        {
                            ActiveGrid.Model[row, col].Foreground = new SolidColorBrush(color);
                        }
                    }
                    ActiveGrid.InvalidateCell(range);
                }
                ActiveGrid.InvalidateVisual();
            }
            this.ForeColorSplitButton.IsDropDownOpen = false;
        }

        void BackgroundColorPicker_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var color = this.BackgroundColorPicker.Color;
            SampleGridControl ActiveGrid = ((Tab1.SelectedItem as TabItem).Content as ScrollViewer).Content as SampleGridControl;
            if (ActiveGrid != null)
            {
                GridRangeInfoList rangeList = ActiveGrid.Model.SelectedRanges;
                foreach (GridRangeInfo range in rangeList)
                {
                    for (int row = range.Top; row <= range.Bottom; row++)
                    {
                        for (int col = range.Left; col <= range.Right; col++)
                        {
                            ActiveGrid.Model[row, col].Background = new SolidColorBrush(color);
                        }
                    }
                    ActiveGrid.InvalidateCell(range);
                }
                ActiveGrid.InvalidateVisual();
            }
            this.BGColorSplitButton.IsDropDownOpen = false;
        }

        void ForegroundColorPicker_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var color = this.ForegroundColorPicker.Color;
            SampleGridControl ActiveGrid = ((Tab1.SelectedItem as TabItem).Content as ScrollViewer).Content as SampleGridControl;
            if (ActiveGrid != null)
            {
                GridRangeInfoList rangeList = ActiveGrid.Model.SelectedRanges;
                foreach (GridRangeInfo range in rangeList)
                {
                    for (int row = range.Top; row <= range.Bottom; row++)
                    {
                        for (int col = range.Left; col <= range.Right; col++)
                        {
                            ActiveGrid.Model[row, col].Foreground = new SolidColorBrush(color);
                        }
                    }
                    ActiveGrid.InvalidateCell(range);
                }
                ActiveGrid.InvalidateVisual();
            }
            this.ForeColorSplitButton.IsDropDownOpen = false;
        }

        public void Initialize()
        {
            GridExcelMarkerMouseController controller = new GridExcelMarkerMouseController(this.grid1);
            GridExcelMarkerMouseController controller2 = new GridExcelMarkerMouseController(this.grid2);
            GridExcelMarkerMouseController controller3 = new GridExcelMarkerMouseController(this.grid3);
            this.grid1.Model.CommandStack.Enabled = true;
            this.grid2.Model.CommandStack.Enabled = true;
            this.grid3.Model.CommandStack.Enabled = true;
            this.grid1.MouseControllerDispatcher.Add(controller);
            this.grid2.MouseControllerDispatcher.Add(controller2);
            this.grid3.MouseControllerDispatcher.Add(controller3);
            this.grid1.Model.Options.CopyPasteOption = CopyPaste.CutCell | CopyPaste.CopyCellData | CopyPaste.PasteCell | CopyPaste.IncludeStyle;
            this.grid2.Model.Options.CopyPasteOption = CopyPaste.CutCell | CopyPaste.CopyCellData | CopyPaste.PasteCell | CopyPaste.IncludeStyle;
            this.grid3.Model.Options.CopyPasteOption = CopyPaste.CutCell | CopyPaste.CopyCellData | CopyPaste.PasteCell | CopyPaste.IncludeStyle;
            GridTextBoxBinder binder = new GridTextBoxBinder();
            binder.Wire(new GridControlBase[] { grid1, grid2, grid3 }, Formulacell);
            BehaviorCollection grid1Behaviors = Interaction.GetBehaviors(grid1);
            BehaviorCollection grid2Behaviors = Interaction.GetBehaviors(grid2);
            BehaviorCollection grid3Behaviors = Interaction.GetBehaviors(grid3);
            grid1Behaviors.Add(new CurrentCellSyncBehavior());
            grid2Behaviors.Add(new CurrentCellSyncBehavior());
            grid3Behaviors.Add(new CurrentCellSyncBehavior());
            grid1Behaviors.Add(new CellLocationSyncBehavior());
            grid2Behaviors.Add(new CellLocationSyncBehavior());
            grid3Behaviors.Add(new CellLocationSyncBehavior());
        }

        public void ExecuteUndoCommand(int ActiveTabIndex)
        {
            SampleGridControl ActiveGrid = ((Tab1.Items[ActiveTabIndex] as TabItem).Content as ScrollViewer).Content as SampleGridControl;

            if (!ActiveGrid.Model.CommandStack.InTransaction)
            {
                ActiveGrid.Model.CommandStack.Undo();
            }
        }

        public void ExecuteRedoCommand(int ActiveTabIndex)
        {
            SampleGridControl ActiveGrid = ((Tab1.Items[ActiveTabIndex] as TabItem).Content as ScrollViewer).Content as SampleGridControl;

            if (!ActiveGrid.Model.CommandStack.InTransaction)
            {
                ActiveGrid.Model.CommandStack.Redo();
            }
            
        }

        public void ExecutePrintCommand(int ActiveTabIndex)
        {
            SampleGridControl ActiveGrid = ((Tab1.Items[ActiveTabIndex] as TabItem).Content as ScrollViewer).Content as SampleGridControl;
            ActiveGrid.Print();
        }

        public void ExecuteCopyCommand(int ActiveTabIndex)
        {
            SampleGridControl ActiveGrid = ((Tab1.Items[ActiveTabIndex] as TabItem).Content as ScrollViewer).Content as SampleGridControl;
            if (ActiveGrid != null)
            {
                string CliboardText;
                int row, col;
                ActiveGrid.Model.TextDataExchange.CopyTextToBuffer(out CliboardText, ActiveGrid.Model.SelectedRanges, out row, out col, false);
                Clipboard.SetText(CliboardText);
            }
        }

        public void ExecuteCutCommand(int ActiveTabIndex)
        {
            SampleGridControl ActiveGrid = ((Tab1.Items[ActiveTabIndex] as TabItem).Content as ScrollViewer).Content as SampleGridControl;
            if (ActiveGrid != null)
            {
                string CliboardText;
                int row, col;
                ActiveGrid.Model.TextDataExchange.CopyTextToBuffer(out CliboardText, ActiveGrid.Model.SelectedRanges, out row, out col, true);
                Clipboard.SetText(CliboardText);
            }
        }

        public void ExecutePasteCommand(int ActiveTabIndex)
        {
            SampleGridControl ActiveGrid = ((Tab1.Items[ActiveTabIndex] as TabItem).Content as ScrollViewer).Content as SampleGridControl;
            if (ActiveGrid != null)
            {
                string CliboardText = Clipboard.GetText();
                ActiveGrid.Model.TextDataExchange.PasteTextFromBuffer(CliboardText, ActiveGrid.Model.SelectedRanges);
            }
        }

        public void ExecuteFontSizeCommand(int ActiveTabIndex, bool IsIncrement)
        {
            SampleGridControl ActiveGrid = ((Tab1.Items[ActiveTabIndex] as TabItem).Content as ScrollViewer).Content as SampleGridControl;

            // Skip if the current cell is not set.
            if (!ActiveGrid.CurrentCell.HasCurrentCell)
                return;

            if (ActiveGrid != null && !ActiveGrid.Model.CurrentCellState.GridControl.CurrentCell.IsInMoveTo)
            {
                foreach (GridRangeInfo range in ActiveGrid.Model.SelectedRanges)
                {
                    for (int row = range.Top; row <= range.Bottom; row++)
                    {
                        for (int col = range.Left; col <= range.Right; col++)
                        {
                            if (IsIncrement)
                                ActiveGrid.Model[row, col].Font.FontSize += 1;
                            else
                                ActiveGrid.Model[row, col].Font.FontSize -= 1;
                        }
                    }
                    ActiveGrid.Model.InvalidateCell(range);
                }
            }
        }

        public void CurrentCellStyleChanged(int ActiveTabIndex, string propertyName, object value)
        {
            SampleGridControl ActiveGrid = ((Tab1.Items[ActiveTabIndex] as TabItem).Content as ScrollViewer).Content as SampleGridControl;

            if (!ActiveGrid.CurrentCell.HasCurrentCell)
                return;

            if (ActiveGrid != null && !ActiveGrid.Model.CurrentCellState.GridControl.CurrentCell.IsInMoveTo)
            {
                foreach (GridRangeInfo range in ActiveGrid.Model.SelectedRanges)
                {
                    for (int row = range.Top; row <= range.Bottom; row++)
                    {
                        for (int col = range.Left; col <= range.Right; col++)
                        {
                            switch (propertyName)
                            {
                                case "FontFamily":
                                    ActiveGrid.Model[row, col].Font.FontFamily = (FontFamily)value;
                                    break;
                                case "FontSize":
                                    {
                                        ActiveGrid.Model[row, col].Font.FontSize = (double)value;
                                        ActiveGrid.Model.ResizeRowsToFit(GridRangeInfo.Cell(row, col), GridResizeToFitOptions.None);         
                                    }
                                    break;
                                case "FontWeight":
                                    ActiveGrid.Model[row, col].Font.FontWeight = (FontWeight)value;
                                    break;
                                case "FontStyle":
                                    ActiveGrid.Model[row, col].Font.FontStyle = (FontStyle)value;
                                    break;
                                case "TextDecorations":
                                    ActiveGrid.Model[row, col].Font.TextDecorations = (TextDecorationCollection)value;
                                    break;
                                case "Background":
                                    ActiveGrid.Model[row, col].Background = new SolidColorBrush(BackgroundColorPicker.Color);
                                    break;
                                case "Foreground":
                                    ActiveGrid.Model[row, col].Foreground = new SolidColorBrush(ForegroundColorPicker.Color);
                                    break;
                                case "HorizontalAlignment":
                                    ActiveGrid.Model[row, col].HorizontalAlignment = (HorizontalAlignment)value;
                                    break;
                                case "VerticalAlignment":
                                    ActiveGrid.Model[row, col].VerticalAlignment = (VerticalAlignment)value;
                                    break;
                                default:
                                    break;
                            }
                        }
                    }
                    ActiveGrid.Model.InvalidateCell(range);
                }
            }
        }

        public void ExecuteIndentCommand(int ActiveTabIndex, bool IsIncrement)
        {
            SampleGridControl ActiveGrid = ((Tab1.Items[ActiveTabIndex] as TabItem).Content as ScrollViewer).Content as SampleGridControl;

            if (!ActiveGrid.CurrentCell.HasCurrentCell)
                return;

            if (ActiveGrid != null && !ActiveGrid.Model.CurrentCellState.GridControl.CurrentCell.IsInMoveTo)
            {
                foreach (GridRangeInfo range in ActiveGrid.Model.SelectedRanges)
                {
                    for (int row = range.Top; row <= range.Bottom; row++)
                    {
                        for (int col = range.Left; col <= range.Right; col++)
                        {
                            GridStyleInfo cell = ActiveGrid.Model[row, col];
                            double left = 0.0;
                            if (cell.HasTextMargins)
                                left = cell.TextMargins.Left;
                            if (IsIncrement)
                                cell.TextMargins = new CellMarginsInfo(left + 10, 0, 0, 0);
                            else if (left >= 10)
                                cell.TextMargins = new CellMarginsInfo(left - 10, 0, 0, 0);
                        }
                    }
                    ActiveGrid.Model.InvalidateCell(range);
                }
            }
        }

        public void ExecuteOrientationCommand(int ActiveTabIndex)
        {
            SampleGridControl ActiveGrid = ((Tab1.Items[ActiveTabIndex] as TabItem).Content as ScrollViewer).Content as SampleGridControl;

            if (!ActiveGrid.CurrentCell.HasCurrentCell)
                return;

            if (ActiveGrid != null && !ActiveGrid.Model.CurrentCellState.GridControl.CurrentCell.IsInMoveTo)
            {
                foreach (GridRangeInfo range in ActiveGrid.Model.SelectedRanges)
                {
                    for (int row = range.Top; row <= range.Bottom; row++)
                    {
                        for (int col = range.Left; col <= range.Right; col++)
                        {
                            GridStyleInfo cell = ActiveGrid.Model[row, col];
                            cell.Font.Orientation += 90;
                        }
                    }
                    ActiveGrid.Model.InvalidateCell(range);
                }
            }
        }
    }
}
