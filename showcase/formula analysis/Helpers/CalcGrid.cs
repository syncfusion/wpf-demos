#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Calculate;
using Syncfusion.Windows.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Windows.Forms;
using Syncfusion.Windows.Controls.Grid;
using System.Windows.Media;
using Syncfusion.Windows.Shared;

namespace syncfusion.formulaanalysis.wpf
{
    public class CalcGrid : GridControl, ICalcData, ISheetData
    {
        #region Constructor
        public CalcGrid()
        {
            this.Model.TableStyle.Background = Brushes.Transparent;
            this.Model.TableStyle.Foreground = Brushes.White;
            this.BorderStyle = BorderStyle.FixedSingle;
        }

        #endregion

        #region Properties
        public BorderStyle BorderStyle { get; set; }

        private bool locked = false;
        public bool Locked
        {
            get { return locked; }
            set { locked = value; }
        }

        #endregion

        #region Methods
        public int GetColorID(GridRangeInfo range)
        {
            int j = 0;
            for (int i = 0; i < this.Model.Selections.Count; i++)
            {
                j = (j == 5) ? 0 : j;
                if (this.Model.SelectedRanges[i].Contains(range))
                {
                    return j;
                }
                j++;
            }
            return -1;
        } 

        protected override void OnMouseDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.locked)
                return;
            base.OnMouseDown(e);
        }

        #endregion

        #region ICalcData Members

        public void WireParentObject()
        {
            //Use this event to get cell changes:
        }         

        //One based:
        public object GetValueRowCol(int row, int col)
        {
            return this.Model[row, col].Text;
        }

        //One based:
        public void SetValueRowCol(object value, int row, int col)
        {
            this.Model[row - 1, col - 1].Text = value.ToString();
        }

        public event ValueChangedEventHandler ValueChanged;

        #endregion

        #region ISheetData Members

        public int GetFirstRow()
        {
            return 1;
        }
        public int GetLastRow()
        {
            return this.Model.RowCount;
        }


        public int GetRowCount()
        {
            return this.Model.RowCount;
        }

        public int GetFirstColumn()
        {
            return 1;
        }

        public int GetLastColumn()
        {
            return this.Model.ColumnCount;
        }


        public int GetColumnCount()
        {
            return this.Model.ColumnCount;
        }


        #endregion
  
    }
}