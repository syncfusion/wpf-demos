#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Xaml.Behaviors;
using Syncfusion.Calculate;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.GridCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Xml;

namespace syncfusion.formulaanalysis.wpf
{
    public class FormulaAnalysisBehavior : Behavior<FormulaAnalysisDemo>
    {
        private ViewModel viewModel;
        string xmlfilePath = @"/syncfusion.formulaanalysis.wpf;component/Resources/CalcEngine.xml";
        bool isDataBaseRelated = false;
        CalcGrid gridControl1 = new CalcGrid(); 
        protected override void OnAttached()
        {
            viewModel = this.AssociatedObject.DataContext as ViewModel;
            this.AssociatedObject.Loaded += AssociatedObject_Loaded;
            base.OnAttached();
        }

        private void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.gridpanel.Children.Add(gridControl1);

            Brush headerBrush = ColorHelper.CreateFrozenSolidColorBrush(128, Colors.CadetBlue);
            gridControl1.Model.HeaderStyle.Background = headerBrush;

            gridControl1.Model.HeaderStyle.Borders.All = new Pen(Brushes.White, 1);
            gridControl1.Model.TableStyle.Borders.All = new Pen(Brushes.White, 0);
            gridControl1.Model.HeaderStyle.Font.FontWeight = FontWeights.Bold;
            gridControl1.Model.TableStyle.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            gridControl1.Model.TableStyle.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            gridControl1.Model.QueryCellInfo += new GridQueryCellInfoEventHandler(Model_QueryCellInfo);

            this.viewModel.PopulateDataTableValues();

            gridControl1.Model.RowCount = this.viewModel.dt.Rows.Count + 1;
            gridControl1.Model.ColumnCount = this.viewModel.dt.Columns.Count + 1;
            gridControl1.Model.BaseStylesMap["Row Header"].StyleInfo.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            gridControl1.Model.BaseStylesMap["Row Header"].StyleInfo.VerticalAlignment = VerticalAlignment.Center;

            CalcEngine.ResetSheetFamilyID();
            this.viewModel.engine = new CalcEngine(gridControl1);

            List<string> formulaNameCollection = GetFunctionNames();

            var dpiXProperty = typeof(SystemParameters).GetProperty("DpiX", BindingFlags.NonPublic | BindingFlags.Static);
            var dpiYProperty = typeof(SystemParameters).GetProperty("Dpi", BindingFlags.NonPublic | BindingFlags.Static);

            var dpiX = (int)dpiXProperty.GetValue(null, null);
            var dpiY = (int)dpiYProperty.GetValue(null, null);

            if (dpiX > 100)
            {
                this.AssociatedObject.desc.Height = 120;
                this.AssociatedObject.sytx.Height = 60;
                this.AssociatedObject.t1.Width = 150;
                this.AssociatedObject.desc.Width = 300;
                this.AssociatedObject.sytx.Width = 300;
                this.AssociatedObject.res.Width = 300;
                this.AssociatedObject.res.FontSize = 21;
                this.AssociatedObject.cbx1.Height = this.AssociatedObject.t1.Height = 30;
                gridControl1.Model.RowHeights.DefaultLineSize = 35;
                gridControl1.Model.ColumnWidths.DefaultLineSize = 75;
            }
            else
            {
                this.AssociatedObject.desc.Height = 150;
                this.AssociatedObject.sytx.Height = 90;
                this.AssociatedObject.t1.Width = 220;
                this.AssociatedObject.desc.Width = 500;
                this.AssociatedObject.sytx.Width = 500;
                this.AssociatedObject.res.Width = 500;
                this.AssociatedObject.cbx1.Width = 200;
                this.AssociatedObject.cbx1.Height = this.AssociatedObject.t1.Height = 30;
                this.AssociatedObject.buttonAdv.Height = 30;
                gridControl1.Model.RowHeights.DefaultLineSize = 45;
                gridControl1.Model.ColumnWidths.DefaultLineSize = 85;
            }

             
            this.AssociatedObject.t1.KeyDown += new KeyEventHandler(t1_KeyDown);           
            this.AssociatedObject.tempTextBlock.Text = "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG";
            this.AssociatedObject.functionCountLable.Text = "CALCULATE SUPPORTS " + formulaNameCollection.Count.ToString() + " FORMULAS.";
            this.AssociatedObject.cbx1.ItemsSource = formulaNameCollection;
            this.AssociatedObject.cbx1.CustomSource = formulaNameCollection;
            this.AssociatedObject.cbx1.SelectionChanged += new SelectionChangedEventHandler(cbx1_SelectionChanged);
            this.AssociatedObject.cbx1.SelectedIndex = 0;
            this.AssociatedObject.t1.TextChanged += new TextChangedEventHandler(t1_TextChanged);
            this.AssociatedObject.cbx1.SelectedIndex = formulaNameCollection.IndexOf("SUM");
            this.AssociatedObject.t1.LostFocus += new RoutedEventHandler(t1_LostFocus);
            this.AssociatedObject.t1.GotFocus += new RoutedEventHandler(t1_GotFocus);  
        }

        private List<string> GetFunctionNames()
        {
            List<string> formulaList = new List<string>();
            foreach (string formula in this.viewModel.engine.LibraryFunctions.Keys)
            {
                formulaList.Add(formula);
            }
            formulaList.Sort();
            formulaList.RemoveAt(0);
            formulaList.RemoveAt(0);
            formulaList.RemoveAt(0);
            return formulaList;
        }
        public bool IsCellReference(string args)
        {
            bool containsBoth = false;
            bool isAlpha = false, isNum = false;
            if (args.IndexOf(':') != args.LastIndexOf(':'))
            {
                return false;
            }

            foreach (char c in args.ToCharArray())
            {
                if (char.IsLetter(c))
                {
                    isAlpha = true;
                }

                if (char.IsDigit(c))
                {
                    isNum = true;
                }

                if (char.Equals(c, ':'))
                {
                    if (isAlpha && isNum)
                    {
                        containsBoth = true;
                    }
                    isAlpha = false;
                    isNum = false;
                }
            }
            if (args.Contains(":") && !args.Contains("\""))
            {
                if (containsBoth && isAlpha && isNum)
                    return true;
                else if (((isAlpha && !isNum) || (!isAlpha && isNum)) && !containsBoth)
                {
                    return true;
                }
                else
                    return false;
            }
            if (isAlpha && isNum && !args.Contains("\""))
            {
                return true;
            }

            return false;
        }
        public int GetColorID(GridRangeInfo range)
        {
            int j = 0;
            for (int i = 0; i < gridControl1.Model.Selections.Count; i++)
            {
                j = (j == 5) ? 0 : j;
                if (gridControl1.Model.SelectedRanges[i].Contains(range))
                {
                    return j;
                }
                j++;
            }
            return -1;
        }        

        Brush[] colorCollection = new Brush[] { new SolidColorBrush(Color.FromArgb(255, 95, 140, 237)), new SolidColorBrush(Color.FromArgb(255, 235, 94, 96)), new SolidColorBrush(Color.FromArgb(255, 141, 97, 194)), new SolidColorBrush(Color.FromArgb(255, 45, 150, 57)), new SolidColorBrush(Color.FromArgb(255, 191, 76, 145)), new SolidColorBrush(Color.FromArgb(255, 227, 130, 34)) };
        private void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
        {
            if (e.Cell.RowIndex > 0 && e.Cell.ColumnIndex > 0)
            {
                int j = GetColorID(GridRangeInfo.Cell(e.Cell.RowIndex, e.Cell.ColumnIndex));
                e.Style.Background = (j == -1) ? e.Style.Background = new SolidColorBrush(Color.FromArgb(255, 00, 59, 81)) : colorCollection[j];
            }
            for (int i = 1; i < 8; i++)
            {
                if (e.Style.RowIndex == 0 && e.Style.ColumnIndex == i)
                {
                    int n = 64;
                    String s = ((char)((int)n + i)).ToString();
                    e.Style.CellValue = s;
                }
            }

            for (int i = 1; i < 11; i++)
            {
                if (e.Style.RowIndex == i && e.Style.ColumnIndex == 0)
                {
                    e.Style.CellValue = i;
                }
            }

            if (e.Style.RowIndex > 0 && e.Style.ColumnIndex > 0)
            {

                e.Style.CellValue = (isDataBaseRelated) ? this.viewModel.dbDT.Rows[e.Cell.RowIndex - 1][e.Cell.ColumnIndex - 1] : this.viewModel.dt.Rows[e.Cell.RowIndex - 1][e.Cell.ColumnIndex - 1];
            }
        }

        void t1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter && !string.IsNullOrEmpty(this.viewModel.SumText))
                {
                    this.viewModel.engine.UseDependencies = false;

                    this.viewModel.ResultText = this.viewModel.engine.ParseAndComputeFormula(this.viewModel.SumText);
                    this.viewModel.engine.UseDependencies = true;
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                this.viewModel.ResultText = ex.Message;
            }
        }

        void t1_TextChanged(object sender, TextChangedEventArgs e)
        {
            gridControl1.Model.Selections.Clear();
            if (!string.IsNullOrEmpty(this.viewModel.SumText) && this.viewModel.SumText.IndexOf('(') > -1)
            {
                try
                {
                    string formula = this.viewModel.SumText.Substring(this.viewModel.SumText.IndexOf("("));
                    string[] args = (formula.Substring(1, (this.viewModel.SumText.EndsWith(")") ? formula.Length - 2 : formula.Length - 1)).Replace("(", string.Empty).Replace(")", string.Empty)).Split(new char[] { ',' });
                    foreach (string arg in args)
                    {
                        if (IsCellReference(arg))
                        {
                            string[] cells =this.viewModel.engine.GetCellsFromArgs(arg.Replace("\"", ""));
                            int firstRow = this.viewModel.engine.RowIndex(cells[0].ToString());
                            int lastRow = this.viewModel.engine.RowIndex(cells[cells.Length - 1].ToString());
                            int firstCol = this.viewModel.engine.ColIndex(cells[0].ToString());
                            int lastCol = this.viewModel.engine.ColIndex(cells[cells.Length - 1].ToString());
                            gridControl1.Model.Selections.Add(GridRangeInfo.Cells(firstRow, firstCol, lastRow, lastCol));
                        }
                    }

                    gridControl1.InvalidateCells();

                }
                catch (Exception)
                {
                    //  MessageBox.Show(ex.Message);
                }
            }
        }

        void cbx1_SelectionChanged(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;
            int i = 0;
            FileStream fs = new FileStream(@"Resources\\CalcEngine.xml", FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName(this.AssociatedObject.cbx1.SelectedItem.ToString());
            isDataBaseRelated = (this.viewModel.dbfunction.IndexOf(this.AssociatedObject.cbx1.SelectedItem.ToString()) > -1);
            if (xmlnode.Count == 1)
            {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                this.viewModel.DescriptionText = xmlnode[0].ChildNodes.Item(0).InnerText.Trim();
                this.viewModel.SyntaxText = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();
                this.viewModel.SumText = xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                this.viewModel.ResultText = this.viewModel.engine.ParseAndComputeFormula(this.viewModel.SumText);
            }
            else
            {
                this.viewModel.DescriptionText = "Not available";
                this.viewModel.SyntaxText = "Not available";
                this.viewModel.ResultText = "";
            }

        }

        void t1_GotFocus(object sender, RoutedEventArgs e)
        {
            string s = this.viewModel.SumText;
            this.AssociatedObject.t1.IsReadOnly = false;
            this.viewModel.SumText = "";
            this.viewModel.SumText = s;
        }

        void t1_LostFocus(object sender, RoutedEventArgs e)
        {
            this.AssociatedObject.t1.Visibility = Visibility.Visible;
            this.AssociatedObject.Cursor = Cursors.Arrow;
        }

        protected override void OnDetaching()
        {
            this.AssociatedObject.Loaded -= AssociatedObject_Loaded;
            gridControl1.Model.QueryCellInfo -= new GridQueryCellInfoEventHandler(Model_QueryCellInfo);
            this.AssociatedObject.t1.KeyDown -= new KeyEventHandler(t1_KeyDown);
            this.AssociatedObject.cbx1.SelectionChanged -= new SelectionChangedEventHandler(cbx1_SelectionChanged);
            this.AssociatedObject.t1.TextChanged -= new TextChangedEventHandler(t1_TextChanged);
            this.AssociatedObject.t1.LostFocus -= new RoutedEventHandler(t1_LostFocus);
            this.AssociatedObject.t1.GotFocus -= new RoutedEventHandler(t1_GotFocus);
            base.OnDetaching();
        }
    }
}
