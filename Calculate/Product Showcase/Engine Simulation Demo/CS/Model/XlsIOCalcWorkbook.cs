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
using System.IO;
using System.Collections;

using Syncfusion.Calculate;
using Syncfusion.XlsIO;


namespace XlsFileUsingXlsIO
{
    /// <summary>
    /// A CalcWorkbook-derived object that uses ExcelRW to read / compute Excel XLS files.
    /// </summary>
    public class XlsIOCalcWorkbook : CalcWorkbook
    {
        #region API Definition
        /// <summary>
        /// The ExcelRW IWorkbook used by this class.
        /// </summary>
        public IWorkbook excelRWWB;
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="calcSheets">Array of ExcelRWCalcSheet objects used in this workbook.</param>
        /// <param name="namedRanges">A hashtable containing named ranges.</param>
        public XlsIOCalcWorkbook(XlsIOCalcSheet[] calcSheets, Hashtable namedRanges)
            : base(calcSheets, namedRanges)
        {

        }
        #endregion

        #region CreateFromXLS
        /// <summary>
        /// Creates a ExceRWCalcWorkbook object from an XLS file.
        /// </summary>
        /// <param name="fileName">Complete pathname of the XLS file.</param>
        /// <returns></returns>
        public static XlsIOCalcWorkbook CreateFromXLS(string fileName)
        {
            IWorkbook wb;
            try
            {
                wb = ExcelUtils.Open(fileName);
                ExcelUtils.ThrowNotSavedOnDestroy = false;
            }
            catch (Exception)
            {
                throw new FileLoadException("XlsIO cannot load the file.", fileName);
            }

            XlsIOCalcSheet[] sheets = new XlsIOCalcSheet[wb.Worksheets.Count];
            string nameList = "!";

            for (int i = 0; i < wb.Worksheets.Count; ++i)
            {
                sheets[i] = new XlsIOCalcSheet(wb.Worksheets[i]);
                sheets[i].Name = wb.Worksheets[i].Name;
                nameList += sheets[i].Name + "!";

            }

            Hashtable ranges = new Hashtable();
            foreach (IName name in wb.Names)
            {
                if (name.Scope.Length > 0 && nameList.IndexOf("!" + name.Scope + "!") > -1)
                {
                    ranges.Add((name.Scope + "!" + name.Name).ToUpper(), name.Value.Replace("'", ""));
                }
                else
                {
                    ranges.Add(name.Name.ToUpper(), name.Value.Replace("'", ""));
                }

                //{
                //    if (!ranges.ContainsKey(name.Name.ToUpper()))
                //    ranges.Add(name.Name.ToUpper(), name.Value.Replace("'", ""));
                //}
            }

            XlsIOCalcWorkbook cwb = new XlsIOCalcWorkbook(sheets, ranges);
            cwb.excelRWWB = wb;
            return cwb;
        }

        #endregion

        #region CalculateAll
        /// <summary>
        /// Performs all calculations in the workbook.
        /// </summary>
        public override void CalculateAll()
        {
            foreach (CalcSheet sheet in this.CalcSheetList)
            {
                sheet.CalculationsSuspended = false;
            }


            foreach (XlsIOCalcSheet sheet in this.CalcSheetList)
            {
                sheet.Engine.UpdateCalcID();
                for (int row = 1; row <= sheet.RowCount; ++row)
                {
                    for (int col = 1; col <= sheet.ColCount; ++col)
                    {
                        object o = sheet[row, col];
                        if (o != null)
                        {
                            string s2 = o.ToString();
                            if (s2.Length > 0 && s2[0] == '=')
                                sheet[row, col] = s2;
                        }
                    }

                }

            }
        }
        #endregion 
    }

    /// <summary>
    /// Specially derived CalcSheet for use with ExcelRW.
    /// </summary>
    public class XlsIOCalcSheet : CalcSheet
    {
        #region API Definition
        IWorksheet excelSheet;

        /// <summary>
        /// Number of rows in this spreadsheet.
        /// </summary>
        public new int RowCount
        {
            get { return this.excelSheet.UsedRange.Rows.GetLength(0); }
        }

        /// <summary>
        /// The number of columns in this spreadsheet.
        /// </summary>
        public new int ColCount
        {
            get { return this.excelSheet.UsedRange.Columns.GetLength(0); }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public XlsIOCalcSheet()
        {
            excelSheet = null;
        }

        /// <summary>
        /// Constuctor
        /// </summary>
        /// <param name="sheet">Underlying ExcelRw IWorksheet object.</param>
        public XlsIOCalcSheet(IWorksheet sheet)
        {
            excelSheet = sheet;
        }

        #endregion

        #region  Method

        /// <summary>
        /// Sets a value into the ExcelRW worksheet.
        /// </summary>
        /// <param name="rowPos">The row index of the changed value.</param>
        /// <param name="colPos">The column index of the changed value.</param>
        /// <param name="val">The new value.</param>
        /// <remarks>
        /// If CalculationsSuspended is not True, a ValueChanged event is raised.
        /// </remarks>
        public override void SetValue(int rowPos, int colPos, string val)
        {

            SetValueRowCol(val, rowPos, colPos);
            if (CalculationsSuspended)
                return;


            ValueChangedEventArgs e1 = new ValueChangedEventArgs(rowPos, colPos, val);
            base.OnValueChanged(e1);
        }

        /// <summary>
        /// Returns the value at the specified row and column.
        /// </summary>
        /// <param name="row">Row index (one-based).</param>
        /// <param name="col">Column index (one-based).</param>
        /// <returns>The value at the specified row and column.</returns>
        public override object GetValueRowCol(int row, int col)
        {
            object o = excelSheet[row, col].Formula;
            if (o == null)
                o = excelSheet[row, col].Value;
            if (o != null)
            {
                return o.ToString();//.Replace("'", ""); //keep the tic defect#541
            }
            return o;
        }

        /// <summary>
        /// Set the value at a specified row and column.
        /// </summary>
        /// <param name="value">The value to be set.</param>
        /// <param name="rowPos">The row index (one-based).</param>
        /// <param name="colPos">The column index (one-based).</param>
        public override void SetValueRowCol(object value, int row, int col)
        {
            excelSheet[row, col].Value = value.ToString();
        }

        #endregion
    }

}
