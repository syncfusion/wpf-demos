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
using System.Data;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Calculate;
using System.IO;
using System.Xml;
using Syncfusion.Windows.Controls.Grid;

namespace FormulaAnalysisDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    using System.Windows.Shapes;
    using Syncfusion.Windows.Shared;
    using System.Reflection;
    using Syncfusion.Windows.GridCommon;
    using System.ComponentModel;

    public partial class MainWindow : Window
    {
        private Syncfusion.Calculate.CalcEngine engine;
        string xmlfilePath = "CalcEngine.xml";
        List<sample> dt1 = new List<sample>(); 
        List<sample> dbdt = new List<sample>();
        DataTable dt = new DataTable();
        DataTable dbDT = new DataTable();
        List<string> dbfunction = new List<string>();
        CalcGrid gridControl1 = new CalcGrid();
        
        public MainWindow()
        {   
            InitializeComponent();

            
            this.gridpanel.Children.Add(gridControl1);

            Brush headerBrush = ColorHelper.CreateFrozenSolidColorBrush(128, Colors.CadetBlue);
            gridControl1.Model.HeaderStyle.Background = headerBrush;

            gridControl1.Model.HeaderStyle.Borders.All = new Pen(Brushes.White, 1);
            gridControl1.Model.TableStyle.Borders.All = new Pen(Brushes.White, 0);
            gridControl1.Model.HeaderStyle.Font.FontWeight = FontWeights.Bold;           
            gridControl1.Model.TableStyle.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            gridControl1.Model.TableStyle.VerticalAlignment = System.Windows.VerticalAlignment.Center;
            gridControl1.Model.QueryCellInfo += new GridQueryCellInfoEventHandler(Model_QueryCellInfo);

            dt1.Add(new sample { A = "6", B = "58", C = "35", D = "0.01", E = "7/18/2011 7:45:05 AM", F = "7500", G = "-120000" });
            dt1.Add(new sample { A = "25", B = "11", C = "25", D = "6", E = "TRUE", F = "4", G = "39000" });
            dt1.Add(new sample { A = "0.15", B = "10", C = "23", D = "4", E = "FALSE", F = "3.5", G = "30000" });
            dt1.Add(new sample { A = "0.75", B = "45.35", C = "47.65", D = "0.06", E = "8", F = "1.2", G = "21000" });
            dt1.Add(new sample { A = "0.05", B = "17.56", C = "18.44", D = "10", E = "20", F = "0.908789", G = "37000" });
            dt1.Add(new sample { A = "0.85", B = "16.09", C = "16.91", D = "-200", E = "3", F = "40", G = "46000" });
            dt1.Add(new sample { A = "50", B = "2400", C = "15.20", D = "-500", E = "3", F = "1.5", G = "0.1" });
            dt1.Add(new sample { A = "0.09", B = "300", C = "6", D = "0.068094", E = "8000", F = "10", G = "0.12" });
            dt1.Add(new sample { A = "30", B = "10", C = "4", D = "0.01", E = "FLUID FLOW", F = "2", G = "#NULL!" });
            dt1.Add(new sample { A = "125000", B = "STREET", C = "-200", D = "2", E = "$1000", F = "2000", G = "http://en.wikipedia.org/w/api.php?action=query&list=recentchanges&rcnamespace=0&format=xml" });

            dt = ConvertToDatatable<sample>(dt1);


            dbdt.Add(new sample { A = "Tree", B = "Height", C = "Age", D = "Yield", E = "Profit", F = "Height", G = "13" });
            dbdt.Add(new sample { A = "=\"=Apple\"", B = ">10", C = string.Empty, D = string.Empty, E = string.Empty, F = "<16", G = "12" });
            dbdt.Add(new sample { A = "=\"=Pear\"", B = "", C = string.Empty, D = string.Empty, E = string.Empty, F = string.Empty, G = "11" });
            dbdt.Add(new sample { A = "Tree", B = "Height", C = "Age", D = "Yield", E = "Profit", F = string.Empty, G = "8" });
            dbdt.Add(new sample { A = "Apple", B = "18", C = "20", D = "14", E = "105.00", F = "-$10,000", G = "4" });
            dbdt.Add(new sample { A = "Pear", B = "12", C = "12", D = "10", E = "96.00", F = "$2,750", G = "3" });
            dbdt.Add(new sample { A = "Cherry", B = "13", C = "14", D = "9", E = "105.00", F = "4,250", G = "2" });
            dbdt.Add(new sample { A = "Apple", B = "14", C = "15", D = "10", E = "75.00", F = "1-Jan-08", G = "1" });
            dbdt.Add(new sample { A = "Pear", B = "9", C = "8", D = "8", E = "76.80", F = "1-Mar-08", G = "1" });
            dbdt.Add(new sample { A = "Apple", B = "8", C = "9", D = "6", E = "45.00", F = "30-Oct-08", G = "1" });

            dbDT = ConvertToDatatable<sample>(dbdt);


            dbfunction.Add("DCOUNT");
            dbfunction.Add("DCOUNTA");
            dbfunction.Add("DMIN");
            dbfunction.Add("DMAX");
            dbfunction.Add("DSUM");
            dbfunction.Add("DPRODUCT");
            dbfunction.Add("DAVERAGE");
            dbfunction.Add("DSTDEV");
            dbfunction.Add("DSTDEVP");
            dbfunction.Add("DVAR");
            dbfunction.Add("DVARP");
            dbfunction.Add("DGET");
	    dbfunction.Add("FORMULATEXT");
            dbfunction.Add("COUNTBLANK");
            dbfunction.Add("PERCENTRANK.INC");
            dbfunction.Add("PERCENTRANK.EXC");
            dbfunction.Add("PERCENTRANK");
            dbfunction.Add("XIRR");

            gridControl1.Model.RowCount = dt.Rows.Count + 1;
            gridControl1.Model.ColumnCount = dt.Columns.Count + 1;
            gridControl1.Model.BaseStylesMap["Row Header"].StyleInfo.HorizontalAlignment = HorizontalAlignment.Center;
            gridControl1.Model.BaseStylesMap["Row Header"].StyleInfo.VerticalAlignment = VerticalAlignment.Center;          

            Syncfusion.Calculate.CalcEngine.ResetSheetFamilyID();
            engine = new Syncfusion.Calculate.CalcEngine(gridControl1);

            List<string> formulaNameCollection = GetFunctionNames();

            var dpiXProperty = typeof(SystemParameters).GetProperty("DpiX", BindingFlags.NonPublic | BindingFlags.Static);
            var dpiYProperty = typeof(SystemParameters).GetProperty("Dpi", BindingFlags.NonPublic | BindingFlags.Static);

            var dpiX = (int)dpiXProperty.GetValue(null, null);
            var dpiY = (int)dpiYProperty.GetValue(null, null);

            if (dpiX > 100)
            {
                this.desc.Height = 120;
                this.sytx.Height = 60;
                t1.Width = 150;
                this.desc.Width = 300;
                this.sytx.Width = 300;
                this.res.Width = 300;
                this.res.FontSize = 21;
                this.cbx1.Height = this.t1.Height = 40;
                gridControl1.Model.RowHeights.DefaultLineSize = 35;
                gridControl1.Model.ColumnWidths.DefaultLineSize = 75;
            }
            else
            {
                this.desc.Height = 150;
                this.sytx.Height = 90;
                t1.Width = 220;
                this.desc.Width = 500;
                this.sytx.Width = 500;
                this.res.Width = 500;
                this.cbx1.Width = 230;
                this.cbx1.Height = this.t1.Height = 40;
                buttonAdv.Height = 40;
                gridControl1.Model.RowHeights.DefaultLineSize = 45;
                gridControl1.Model.ColumnWidths.DefaultLineSize = 85;
            }

            this.t1.KeyDown += new KeyEventHandler(t1_KeyDown);
            tempTextBlock.Text = "GGGGGGGGGGGGGGGGGGGGGGGGGGGGGGGG";
            this.functionCountLable.Text = "CALCULATE SUPPORTS " + formulaNameCollection.Count.ToString() + " FORMULAS.";
            this.cbx1.ItemsSource = formulaNameCollection;
            this.cbx1.CustomSource = formulaNameCollection;
            this.cbx1.SelectionChanged += new SelectionChangedEventHandler(cbx1_SelectionChanged);
            this.cbx1.SelectedIndex = 0;
            this.cbx1.SelectedIndex = formulaNameCollection.IndexOf("SUM");
            this.t1.LostFocus += new RoutedEventHandler(t1_LostFocus);
            this.t1.GotFocus += new RoutedEventHandler(t1_GotFocus);
            this.t1.TextChanged+=new TextChangedEventHandler(t1_TextChanged);

        }

        void t1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter && !string.IsNullOrEmpty(this.t1.Text))
                {
                    this.engine.UseDependencies = false;

                    this.res.Text = this.engine.ParseAndComputeFormula(this.t1.Text);
                    this.engine.UseDependencies = true;
                    e.Handled = true;
                }
            }
            catch (Exception ex)
            {
                this.res.Text = ex.Message;
            }
        }

        void t1_TextChanged(object sender, TextChangedEventArgs e)
        {
            gridControl1.Model.Selections.Clear();
            if (!string.IsNullOrEmpty(this.t1.Text) && this.t1.Text.IndexOf('(') > -1)
            {
                try
                {
                    string formula = this.t1.Text.Substring(this.t1.Text.IndexOf("("));
                    string[] args = (formula.Substring(1, (this.t1.Text.EndsWith(")") ? formula.Length - 2 : formula.Length - 1)).Replace("(",string.Empty).Replace(")",string.Empty)).Split(new char[] { ',' });
                    foreach (string arg in args)
                    {
                        if (IsCellReference(arg))
                        {
                            string[] cells = engine.GetCellsFromArgs(arg.Replace("\"", ""));
                            int firstRow = engine.RowIndex(cells[0].ToString());
                            int lastRow = engine.RowIndex(cells[cells.Length - 1].ToString());
                            int firstCol = engine.ColIndex(cells[0].ToString());
                            int lastCol = engine.ColIndex(cells[cells.Length - 1].ToString());
                            gridControl1.Model.Selections.Add(GridRangeInfo.Cells(firstRow, firstCol, lastRow, lastCol));
                       }
                    }

                   
                    gridControl1.InvalidateCells();

                }
                catch (Exception )
                {
                  //  MessageBox.Show(ex.Message);
                }
            }
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
        Brush[] colorCollection = new Brush[] { new SolidColorBrush(Color.FromArgb(255, 95, 140, 237)), new SolidColorBrush(Color.FromArgb(255, 235, 94, 96)), new SolidColorBrush(Color.FromArgb(255, 141, 97, 194)), new SolidColorBrush(Color.FromArgb(255, 45, 150, 57)), new SolidColorBrush(Color.FromArgb(255, 191, 76, 145)), new SolidColorBrush(Color.FromArgb(255, 227, 130, 34)) };
        void Model_QueryCellInfo(object sender, GridQueryCellInfoEventArgs e)
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

                e.Style.CellValue = (isDataBaseRelated) ? dbDT.Rows[e.Cell.RowIndex - 1][e.Cell.ColumnIndex - 1] : dt.Rows[e.Cell.RowIndex - 1][e.Cell.ColumnIndex - 1];
            }
        }
        public int GetColorID(GridRangeInfo range)
        {
            int j = 0;
            for (int i = 0; i <  gridControl1.Model.Selections.Count; i++)
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


        public class sample
        {

            public string A
            {
                get;
                set;
            }
            public string B
            {
                get;
                set;
            }
            public string C
            {
                get;
                set;
            }
            public string D
            {
                get;
                set;
            }
            public string E
            {
                get;
                set;
            }
            public string F
            {
                get;
                set;
            }
            public string G
            {
                get;
                set;
            }

        }

        private DataTable ConvertToDatatable<sample>(List<sample> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(sample));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                if (prop.PropertyType.IsGenericType && prop.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>))
                    table.Columns.Add(prop.Name, prop.PropertyType.GetGenericArguments()[0]);
                else
                    table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (sample item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

        private List<string> GetFunctionNames()
        {
            List<string> formulaList = new List<string>();
            foreach (string formula in engine.LibraryFunctions.Keys)
            {
                formulaList.Add(formula);
            }
            formulaList.Sort();
            formulaList.RemoveAt(0);
            formulaList.RemoveAt(0);
            formulaList.RemoveAt(0);
            return formulaList;
        }

        bool isDataBaseRelated = false;
        void cbx1_SelectionChanged(object sender, EventArgs e)
        {
            XmlDocument xmldoc = new XmlDocument();
            XmlNodeList xmlnode;
            int i = 0 ;
            FileStream fs = new FileStream(xmlfilePath, FileMode.Open, FileAccess.Read);
            xmldoc.Load(fs);
            xmlnode = xmldoc.GetElementsByTagName(this.cbx1.SelectedItem.ToString());
            isDataBaseRelated = (dbfunction.IndexOf(this.cbx1.SelectedItem.ToString()) > -1);
            if (xmlnode.Count == 1)
            {
                xmlnode[i].ChildNodes.Item(0).InnerText.Trim();
                this.desc.Text = xmlnode[0].ChildNodes.Item(0).InnerText.Trim();
                this.sytx.Text = xmlnode[i].ChildNodes.Item(1).InnerText.Trim();              
                this.t1.Text = xmlnode[i].ChildNodes.Item(2).InnerText.Trim();
                this.res.Text = engine.ParseAndComputeFormula(this.t1.Text);
            }
            else
            {
                this.desc.Text = "Not available";
                this.sytx.Text = "Not available";
                this.res.Text = "";
            }

        }

        void t1_GotFocus(object sender, RoutedEventArgs e)
        {         
            string s = this.t1.Text;
            this.t1.IsReadOnly= false;
            this.t1.Text = "";
            this.t1.Text = s;
        }

        void t1_LostFocus(object sender, RoutedEventArgs e)
        {
            this.t1.Visibility = Visibility.Visible;
            this.Cursor = Cursors.Arrow;
        }

        private void buttonAdv_Click(object sender, RoutedEventArgs e)
        {
            this.desc.Text = "";
            this.sytx.Text = "";
            this.res.Text = "";
            this.engine.UseDependencies = false;
            this.res.Text = this.engine.ParseAndComputeFormula((this.t1.Text));
            this.engine.UseDependencies = true;

        }
    }
}
