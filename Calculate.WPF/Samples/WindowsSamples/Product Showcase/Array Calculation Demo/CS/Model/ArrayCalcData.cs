#region Copyright Syncfusion Inc. 2001 - 2019
//
//  Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
//
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Any infringement will be prosecuted under
//  applicable laws. 
//
#endregion

using System;
using Syncfusion.Calculate;

namespace ArrayICalcData
{
    /// <summary>
    /// Wrapper class for a double array.
    /// </summary>
    /// <remarks> Wrapper class for a double array that adds an extra column
    /// to hold the sum of each row, and also adds an extra row
    /// to hold the sum of the columns.
    /// </remarks>
    public class ArrayCalcData : ICalcData
    {
        #region API Definitions

        /// <summary>
        /// original double array
        /// </summary>
        private double[,] dValues;

        /// <summary>
        /// vector holding the sum of the rows.
        /// </summary>
        /// <remarks>
        /// Serves as the last column.
        /// </remarks>
        private object[] rowSums;

        /// <summary>
        /// Vector holding the sum of the columns.
        /// </summary>
        /// <remarks>
        /// Serves as the last row.
        /// </remarks>
        private object[] colSums;

        int rowCount;
        int colCount;

        /// <summary>
        /// Gets or sets the value of this ArrayCalcData object.
        /// </summary>
        /// <remarks>
        /// Since this class wraps a double array, the indexing is zero-based. But 
        /// the ICalcData methods require one-based indexing by convention. So, 
        /// one is added to the indexes when the ICalcData methods are called.
        /// </remarks>
        public object this[int row, int col]
        {
            get { return GetValueRowCol(row + 1, col + 1); }
            set { SetValueRowCol(value, row + 1, col + 1); }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Wraps the double array with an extra row and column that holds calculated sums.
        /// </summary>
        /// <param name="dValues"></param>
        public ArrayCalcData(double[,] dValues)
        {
            this.dValues = dValues;
            rowCount = dValues.GetLength(0);
            colCount = dValues.GetLength(1);
            rowSums = new object[rowCount + 1];
            colSums = new object[colCount + 1];

            //initialize the formulas for the row sums
            // eg. "=Sum(A5:D5)"  to sum row 5
            for (int row = 0; row <= rowCount; ++row)
            {
                rowSums[row] = string.Format("=Sum(A{1}:{0}{1})",
                    RangeInfo.GetAlphaLabel(colCount), row + 1);
            }

            //initialize the formulas for the columns sums
            // eg. "=Sum(B1:B5)"  to sum column 2
            for (int col = 0; col <= colCount; ++col)
            {
                colSums[col] = string.Format("=Sum({0}1:{0}{1})",
                    RangeInfo.GetAlphaLabel(col + 1), rowCount);
            }
        }

        #endregion

        #region ICalcData Members

        /// <summary>
        /// Gets the value into either the double array or column vector 
        /// or row vector.
        /// </summary>
        /// <param name="row">one-based row index.</param>
        /// <param name="col">one-based column index.</param>
        /// <returns>The value.</returns>
        /// <remarks> By convention, ICalcData uses one-based indexes.</remarks>
        public object GetValueRowCol(int row, int col)
        {
            if (row - 1 == rowCount)
            {
                return colSums[col - 1];
            }
            else if (col - 1 == colCount)
            {
                return rowSums[row - 1];

            }
            else
                return this.dValues[row - 1, col - 1];
        }

        /// <summary>
        /// Sets the value into either the double array or column vector 
        /// or row vector.
        /// </summary>
        /// <param name="row">one-based row index.</param>
        /// <param name="col">one-based column index.</param>
        /// <param name="value">The value to be set.</param>
        /// <remarks> This setter raises the ICalcData.ValueChanged event which 
        /// is listened to by the CalcEngine to manage the calculations.
        /// 
        /// By convention, ICalcData uses one-based indexes.
        /// </remarks>
        public void SetValueRowCol(object value, int row, int col)
        {

            if (row - 1 == rowCount)
            {
                colSums[col - 1] = value;
            }
            else if (col - 1 == colCount)
            {
                rowSums[row - 1] = value;
            }
            else
                this.dValues[row - 1, col - 1] = double.Parse(value.ToString());

            ValueChangedEventArgs e1 = new ValueChangedEventArgs(row, col, value.ToString());
            ValueChanged(this, e1);
        }

        /// <summary>
        /// Used in the SetValueRowCol implementation
        /// </summary>
        public event Syncfusion.Calculate.ValueChangedEventHandler ValueChanged;

        /// <summary>
        /// Unused in this implementation.
        /// </summary>
        public void WireParentObject()
        {
            //empty
        }

        #endregion
    }
}
