#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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

namespace FormulaAnalysisDemo
{
        public class CalcGrid : GridControl, Syncfusion.Calculate.ICalcData, ISheetData
        {
           public CalcGrid()
           {
               
              // this.Model.QueryCellInfo += CalcGrid_QueryCellInfo;
                this.Model.TableStyle.Background = Brushes.Transparent;
                this.Model.TableStyle.Foreground = Brushes.White;

                this.Model.TableStyle.Foreground = Brushes.White;
              
                this.BorderStyle = BorderStyle.FixedSingle;

        
        }


           Brush[] colorCollection = new Brush[] { new SolidColorBrush(Color.FromArgb(255, 95, 140, 237)), new SolidColorBrush(Color.FromArgb(255, 235, 94, 96)), new SolidColorBrush(Color.FromArgb(255, 141, 97, 194)), new SolidColorBrush(Color.FromArgb(255, 45, 150, 57)), new SolidColorBrush(Color.FromArgb(255, 191, 76, 145)), new SolidColorBrush(Color.FromArgb(255, 227, 130, 34)) };
           void CalcGrid_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
           {
               if (e.Cell.RowIndex>0 && e.Cell.ColumnIndex > 0)
               {
                   int j = GetColorID(GridRangeInfo.Cell(e.Cell.RowIndex, e.Cell.ColumnIndex));
                   e.Style.Background = (j == -1) ? e.Style.Background = new SolidColorBrush(Color.FromArgb(255, 00, 59, 81)) : colorCollection[j];
               }
           }

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


    private bool locked = false;
        public bool Locked
        {
            get { return locked; }
            set { locked = value; }
        }
        //protected override void OnMouseDown(MouseEventArgs e)
        //{
        //    if (this.locked)
        //        return;
        //    base.OnMouseDown(e);
        //}

        protected override void OnMouseDown(System.Windows.Input.MouseButtonEventArgs e)
        {
            if (this.locked)
              return;
            base.OnMouseDown(e);
        }

           #region ICalcData Members

            public void WireParentObject()
            {
                //Use this event to get cell changes:
            }

            private int changeCol = -1;
            private void defaultView_ListChanged(object sender, ListChangedEventArgs e)
            {
                if (e.ListChangedType == ListChangedType.ItemChanged && changeCol > -1)
                {
                    int row = e.NewIndex;
                    int col = this.changeCol;
                    
                    string val = this.Model[row + 1 , col + 1].Text;
                    Syncfusion.Calculate.ValueChangedEventArgs e1 = new Syncfusion.Calculate.ValueChangedEventArgs(row + 1, col + 1, val);
                    ValueChanged(this, e1);
                }
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

            public event Syncfusion.Calculate.ValueChangedEventHandler ValueChanged;

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

            public BorderStyle BorderStyle { get; set; }
        }
}