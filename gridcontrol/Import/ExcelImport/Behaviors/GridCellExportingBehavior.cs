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
using System.Windows.Documents;
using Syncfusion.Windows.Controls.Cells;
using Microsoft.Xaml.Behaviors;
using Syncfusion.XlsIO;
using Syncfusion.Windows.Controls.Grid.Converter;

namespace syncfusion.gridcontroldemos.wpf
{
    public class GridCellExportingBehavior : Behavior<GridControl>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Model.CommittedCellInfo += new GridCommitCellInfoEventHandler(Model_CommittedCellInfo);
        }

        void Model_CommittedCellInfo(object sender, GridCommitCellInfoEventArgs e)
        {
            var dataContext = AssociatedObject.DataContext as ExcelImportViewModel;
            if (dataContext != null && e.Sip != null && e.Sip.PropertyName == "CellValue")
            {
                GridModel gridModel = sender as GridModel;
                int index = dataContext.ActiveTabIndex;
                IWorksheet Worksheet = dataContext.Workbook.Worksheets[index];
                ExportHelper(Worksheet, gridModel, e.Style, e.Cell);
            }
        }

        private void ExportHelper(IWorksheet Sheet, GridModel gridModel, GridStyleInfo Style, RowColumnIndex RowColIndex)
        {
            if (Sheet != null)
            {
                int ivalue; double dvalue; bool bvalue;
                try
                {
                    IRange range = Sheet.Range[RowColIndex.RowIndex, RowColIndex.ColumnIndex];
                    if (!range.HasFormula || Style.Text.Length == 0 || (Style.Text.Length > 0 && Style.Text[0] != '='))
                    {
                        //To new Save Formula
                        if (Style.CellValue != null && Style.CellValue.ToString() != string.Empty && Style.CellValue.ToString()[0] == '=')
                        {
                            if (Style.CellValue.ToString().Contains('!'))
                                range.Formula = ExcelLikeFormula(gridModel, Style.CellValue.ToString());
                            else
                                range.Formula = Style.CellValue.ToString().ToUpper();
                            if (int.TryParse(Style.FormattedText, out ivalue))
                            {
                                Style.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                                range.CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;
                            }
                            else if (double.TryParse(Style.FormattedText, out dvalue))
                            {
                                Style.HorizontalAlignment = System.Windows.HorizontalAlignment.Right;
                                range.CellStyle.HorizontalAlignment = ExcelHAlign.HAlignRight;
                            }
                        }
                        else
                        {
                            string cellvalue = string.Empty;
                            if (Style.CellValue != null)
                                cellvalue = Style.CellValue.ToString();
                            if (Style.CellType == "FormulaCell" && !string.IsNullOrEmpty(Style.Text) && Style.Text[0] == '=')
                            {
                                cellvalue = Style.FormattedText;
                            }
                            //To Save RichText
                            else if (Style.CellType == "RichText")
                            {
                                RichTextBoxHelper.SetRichTextValue(range, Style.CellValue as FlowDocument, Style.FormattedText);
                                return;
                            }
                            //To Save Number
                            if (int.TryParse(cellvalue, out ivalue))
                                range.Number = ivalue;
                            else if (double.TryParse(cellvalue, out dvalue))
                                range.Number = dvalue;
                            //To Save Boolean value
                            else if (bool.TryParse(cellvalue, out bvalue))
                            {
                                range.Boolean = bvalue;
                                if (bvalue)
                                    Style.CellValue = "TRUE";
                                else
                                    Style.CellValue = "FALSE";
                            }
                            //To Save other value
                            else
                                range.Value = cellvalue;
                        }
                    }
                    //To Save Formula
                    else
                    {
                        if (Style.FormulaTag != null && Style.CellValue != null && Style.CellValue.ToString() != string.Empty && Style.CellValue.ToString()[0] == '=')
                        {
                            if (!range.HasFormula)
                            {
                                if (Style.CellValue.ToString().Contains('!'))
                                    range.Formula = ExcelLikeFormula(gridModel, Style.CellValue.ToString());
                                else
                                    range.Formula = Style.CellValue.ToString().ToUpper();
                            }
                            else
                            {
                                range.Formula = ExcelLikeFormula(gridModel, Style.CellValue.ToString());
                            }
                        }
                        else if (!range.HasFormula)
                        {
                            range.Text = Style.FormattedText;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private string ExcelLikeFormula(GridModel model, string text)
        {
            var dataContext = AssociatedObject.DataContext as ExcelImportViewModel;
            if (dataContext != null)
            {
                GridSheetFamilyItem f = GridFormulaEngine.GetSheetFamilyItem(model);
                if (text.Contains('!'))
                {
                    for (int i = 0; i < dataContext.Workbook.Worksheets.Count; i++)
                    {
                        string s = "'" + dataContext.Workbook.Worksheets[i].Name + "'!";
                        string sheetname = dataContext.Workbook.Worksheets[i].Name + '!';
                        if (text.Contains(sheetname))
                        {
                            text = text.Replace(sheetname, s);
                        }
                    }
                }
            }
            return text;
        }


        protected override void OnDetaching()
        {
            this.AssociatedObject.Model.CommittedCellInfo -= new GridCommitCellInfoEventHandler(Model_CommittedCellInfo);
        }
    }
}
