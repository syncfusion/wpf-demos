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
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;
using Syncfusion.Windows.GridCommon;
using System.Windows;

namespace syncfusion.gridcontroldemos.wpf
{
    public class SampleVirtualGrid : GridControl
    {
        public int ScrollTime
        {
            get;
            set;
        }

        public SampleVirtualGrid()
        {
            this.Model.HeaderStyle.HorizontalAlignment = HorizontalAlignment.Center;
            this.Model.HeaderStyle.VerticalAlignment = VerticalAlignment.Center;
            this.Model.RowCount = 1000000;
            this.Model.RowHeights.DefaultLineSize = 32;

            this.Model.ColumnCount = 1000000;
            this.Model.TableStyle.ReadOnly = true;
            this.QueryCellInfo += new GridQueryCellInfoEventHandler(SampleVirtualGrid_QueryCellInfo);
        }

        private void SampleVirtualGrid_QueryCellInfo(object sender, Syncfusion.Windows.Controls.Grid.GridQueryCellInfoEventArgs e)
        {
            if (e.Cell.RowIndex == 0)
            {
                if (e.Cell.ColumnIndex > 0)
                    e.Style.CellValue = e.Cell.ColumnIndex;
            }
            else if (e.Cell.RowIndex > 0)
            {
                if (e.Cell.ColumnIndex == 0)
                    e.Style.CellValue = e.Cell.RowIndex;
                else if (e.Cell.ColumnIndex > 0)
                {
                    e.Style.CellValue = String.Format("{0}/{1}", e.Cell.RowIndex, e.Cell.ColumnIndex);
                }
            }
        }

        int start = 0;
        internal int prevRowIndex;
        protected override void OnArrangeContent(Size arrangeSize)
        {
            this.prevRowIndex = this.TopRowIndex;
            start = DateTime.Now.Millisecond;
            base.OnArrangeContent(arrangeSize);
        }

        public event EventHandler ContentUpdated;
        internal string displayText;
        protected override void OnRender(DrawingContext dc)
        {
            base.OnRender(dc);
            this.ScrollTime = DateTime.Now.Millisecond - start;
            if (ContentUpdated != null)
            {
                this.displayText = string.Format("{0} Rows is scrolled in {1} millisecs.", this.prevRowIndex, this.ScrollTime);
                ContentUpdated(this, EventArgs.Empty);
            }
        }
    }
}
