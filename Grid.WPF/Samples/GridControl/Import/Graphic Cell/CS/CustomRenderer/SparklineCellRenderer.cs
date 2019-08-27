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
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Diagnostics;
using System.Windows.Controls;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Chart;
using System.Windows;
using System.Windows.Media;
using Syncfusion.Windows.GridCommon;
using System.Globalization;
using System.Collections;
using Syncfusion.XlsIO;

namespace ImportingDemo.CustomRenderer
{
   
    public class SparklineCellModel : GridCellModel<SparklineCellRenderer>
    {

    }

    public class SparklineCellRenderer : GridVirtualizingCellRenderer<SparkLine>
    {

        private SparklinePaint sparklinePaint;        
        
        public SparklineCellRenderer()
        {
            SupportsRenderOptimization = true;
            AllowRecycle = true;
            IsEditable = false;
            IsControlTextShown = false;
            IsFocusable = false;
            AllowKeepAliveOnlyCurrentCell = true;
            sparklinePaint = new SparklinePaint();
        }

        #region Overrides

        public override void CreateRendererElement(SparkLine uiElement, GridRenderStyleInfo style)
        {
            base.CreateRendererElement(uiElement, style);
        }

        public override void OnInitializeContent(SparkLine uiElement, GridRenderStyleInfo style)
        {
            base.OnInitializeContent(uiElement, style);
        }

        protected override void OnRender(System.Windows.Media.DrawingContext dc, RenderCellArgs rca, GridRenderStyleInfo cellInfo)
        {
            if (rca.CellUIElements != null)
                return;

            Rect cellRect = rca.CellRect;
            SparkLine sparkLine = GetSparkLine(cellInfo);

            if (sparkLine != null)
            {
                sparklinePaint.DrawSparkline(dc, cellRect, sparkLine, cellInfo);
                cellInfo.EnableFloatingCell = false;
                // cellInfo.ModelStyle.EnableFloatingCell = false;
            }

            base.OnRender(dc, rca, cellInfo);

        }

        #endregion

        #region Helper Methods

        private SparkLine GetSparkLine(GridRenderStyleInfo cellInfo)
        {
            Syncfusion.XlsIO.ISparklineGroup spGroup = cellInfo.CellValue as Syncfusion.XlsIO.ISparklineGroup;
            SparkLine sparkLine = new SparkLine();

            if (spGroup != null)
            {
                sparkLine.DataMemberPath = "";

                switch (spGroup.SparklineType)
                {
                    case Syncfusion.XlsIO.SparklineType.Column:
                        sparkLine.SparkLineType = SparkLineTypes.Column;
                        break;
                    case Syncfusion.XlsIO.SparklineType.Line:
                        sparkLine.SparkLineType = SparkLineTypes.Line;
                        break;
                    case Syncfusion.XlsIO.SparklineType.ColumnStacked100:
                        sparkLine.SparkLineType = SparkLineTypes.WinLoss;
                        break;
                    default:
                        break;
                }

                sparkLine.ItemsSource = GetSparkLineItemSource(spGroup, cellInfo).AsEnumerable<double>();

                // Hightlinght color.
                sparkLine.FirstPointHighlightBrush = GetSparkLineBrush(spGroup.FirstPointColor);
                sparkLine.HighPointHighlightBrush = GetSparkLineBrush(spGroup.HighPointColor);
                sparkLine.LowPointHighlightBrush = GetSparkLineBrush(spGroup.LowPointColor);
                sparkLine.LastPointHighlightBrush = GetSparkLineBrush(spGroup.LastPointColor);
                sparkLine.NegativePointsHighlightBrush = GetSparkLineBrush(spGroup.NegativePointColor);

                sparkLine.IsLastPointHighlighted = spGroup.ShowLastPoint;
                sparkLine.IsFirstPointHighlighted = spGroup.ShowFirstPoint;
                sparkLine.IsLowPointHighlighted = spGroup.ShowLowPoint;
                sparkLine.IsHighPointHighlighted = spGroup.ShowHighPoint;
                sparkLine.IsNegativePointsHighlighted = spGroup.ShowNegativePoint;

                sparkLine.IsFirstPointHighlighted = true;
                sparkLine.IsLastPointHighlighted = true;



            }
            return sparkLine;
        }

        private SolidColorBrush GetSparkLineBrush(System.Drawing.Color spColor)
        {
            return new SolidColorBrush(Color.FromArgb(spColor.A, spColor.R, spColor.G, spColor.B));
        }

        private List<double> GetSparkLineItemSource(Syncfusion.XlsIO.ISparklineGroup spGroup, GridRenderStyleInfo cellInfo)
        {
            List<double> itemSource = new List<double>();

            // get the sparklines count.
            for (int line = 0; line < spGroup.Count; line++)
            {
                // ISparklineGroup spGroup = spGroups[i];
                ISparklines spLines = spGroup[line];
                for (int j = 0; j < spLines.Count; j++)
                {
                    ISparkline spLine = spGroup[line][j];
                    IRange dataRange = spLine.DataRange;
                    for (int rowInd = dataRange.Row; rowInd <= dataRange.LastRow; rowInd++)
                    {
                        if (spLine.ReferenceRange.Row == cellInfo.RowIndex)
                        {
                            for (int colInd = dataRange.Column; colInd <= dataRange.LastColumn; colInd++)
                            {
                                double cellValue;
                                if (double.TryParse(cellInfo.GridModel[rowInd, colInd].FormattedText, out cellValue))
                                    itemSource.Add(cellValue);

                            }
                        }

                    }
                }

            }

            return itemSource;
        }

        #endregion

    }

    public class SparklinePaint
    {
        private Dictionary<Size, VisualBrush> brushes = new Dictionary<Size, VisualBrush>();

        /// <summary>
        /// Default constructor.
        /// </summary>
        public SparklinePaint()
        {
        }

        #region Helper Methods

        /// <summary>
        /// Draws the SparklinePaint Control in the cell rectangle.
        /// </summary>
        /// <param name="dc">The drawing context.</param>
        /// <param name="rc">Cell rectangle.</param>
        /// <param name="text">Text to be drawn over the SparklinePaint Control.</param>
        /// <param name="style">Cell style information.</param>
        /// <returns>Cell margins.</returns>
        public void DrawSparkline(DrawingContext dc, Rect rc, SparkLine sparkline, GridStyleInfo style)
        {
            VisualBrush vb = this.GetVisualBrush(rc.Size, style, sparkline);
            dc.DrawRectangle(vb, null, rc);
        }

        private VisualBrush GetVisualBrush(Size size, GridStyleInfo style, SparkLine sparkline)
        {
            //if (this.brushes.ContainsKey(size))
            //{
            //    return this.brushes[size];
            //}

            bool wasAnimated = GridUtil.IsAnimated;
            try
            {
                GridUtil.IsAnimated = false;

                VisualBrush visualBrush;
                SparkLine b = sparkline;
                b.BeginInit();
                b.Background = Brushes.Transparent;
                b.BorderThickness = new Thickness(5);
                b.Width = size.Width;
                b.Height = size.Height;
                b.EndInit();
                b.Measure(size);
                b.Arrange(new Rect(size));
                visualBrush = new VisualBrush();
                visualBrush.Visual = b;
                this.brushes[size] = visualBrush;
                return visualBrush;
            }
            finally
            {
                GridUtil.IsAnimated = wasAnimated;
            }
        }

        #endregion

    }

}
