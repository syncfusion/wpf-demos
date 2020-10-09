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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.GridCommon;
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Gauges;
using Syncfusion.UI.Xaml.Charts;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for GaugeChart.xaml
    /// </summary>
    public partial class GaugeChart : DemoControl
    {

        public GaugeChart()
        {
            InitializeComponent();
            GridSettings();
        }

        public GaugeChart(string themename) : base(themename)
        {
            InitializeComponent();
            GridSettings();
        }

        void GridSettings()
        {
            // InitializeLog();  
            grid.Model.RowCount = 35;
            grid.Model.ColumnCount = 15;
            grid.Model.TableStyle.CellType = "Static";

            var cell = grid.Model[8, 1];
            cell.CellType = "DataBoundTemplate";
            cell.CellItemTemplateKey = "DataGauge";
            cell.CellEditTemplateKey = "DataGauge";
            grid.Model.RowHeights[8] = 400d;
            grid.Model.ColumnWidths[1] = 600d;

            grid.Model[10, 1].CellValue = "Chart reperesenting the sales during the year 2003-2007";
            grid.Model[10, 1].HorizontalAlignment = HorizontalAlignment.Center;
            grid.Model[10, 1].Font.FontWeight = FontWeights.Bold;

            cell = grid.Model[11, 1];
            cell.CellType = "DataBoundTemplate";
            cell.CellItemTemplateKey = "DataChart";
            cell.CellEditTemplateKey = "DataChart";
            grid.Model.RowHeights[11] = 400d;
            //grid.Model.ColumnWidths[1] = 600d;

            grid.Model[7, 3].CellValue = "Chart1: Chart indicating sales per grocery";
            grid.Model[7, 3].Font.FontWeight = FontWeights.Bold;
            grid.Model[7, 3].HorizontalAlignment = HorizontalAlignment.Center;
            cell = grid.Model[8, 3];
            cell.CellType = "DataBoundTemplate";
            cell.CellItemTemplateKey = "BarChart";
            cell.CellEditTemplateKey = "BarChart";
            grid.Model.ColumnWidths[3] = 600d;

            grid.Model[10, 3].CellValue = " Chart indicating company expenses per department";
            grid.Model[10, 3].Font.FontWeight = FontWeights.Bold;
            grid.Model[10, 3].HorizontalAlignment = HorizontalAlignment.Center;
            cell = grid.Model[11, 3];
            cell.CellType = "DataBoundTemplate";
            cell.CellItemTemplateKey = "PieChart";
            cell.CellEditTemplateKey = "PieChart";
            for (int i = 0; i < 7; i++)
                this.grid.Model.CoveredCells.Add(new CoveredCellInfo(i, 2, i, 3));

        }
        private SfCircularGauge _circulargauge;
        private void circularGauge1_Loaded(object sender, RoutedEventArgs e)
        {
            Double sum = 0;
            MyDataCollection coll = this.FindResource("SeriesData1") as MyDataCollection;
            int i = 1;
            grid.Model[i, 1].CellValue = "Year";
            grid.Model[i, 1].HorizontalAlignment = HorizontalAlignment.Center;
            grid.Model[i, 1].Background = Brushes.Pink;
            grid.Model[i, 1].Font.FontWeight = FontWeights.Bold;
            grid.Model[i, 2].CellValue = "Revenue of the Year($ 1000)";
            grid.Model[i, 2].HorizontalAlignment = HorizontalAlignment.Center;
            grid.Model[i, 2].Background = Brushes.Pink;
            grid.Model[i, 2].Font.FontWeight = FontWeights.Bold;

            i++;
            if (coll != null)
                foreach (MyData d in coll)
                {
                    sum += d.Y1;
                    grid.Model[i, 1].CellValue = d.Year;
                    grid.Model[i, 1].HorizontalAlignment = HorizontalAlignment.Center;
                    grid.Model[i, 1].Background = Brushes.Pink;
                    grid.Model[i, 1].Font.FontWeight = FontWeights.Bold;

                    grid.Model[i, 2].CellValue = "$" + d.Y1;
                    grid.Model[i, 2].HorizontalAlignment = HorizontalAlignment.Center;
                    grid.Model[i, 2].Background = Brushes.Pink;
                    grid.Model[i, 2].Font.FontWeight = FontWeights.Bold;

                    i++;
                }
            grid.Model[i, 1].CellValue = "Gauge indicating Average sales during the year 2003-2007";
            grid.Model[i, 1].HorizontalAlignment = HorizontalAlignment.Center;
            grid.Model[i, 1].Font.FontWeight = FontWeights.Bold;

            SfCircularGauge cg = (sender as UserControl).Content as SfCircularGauge;
            _circulargauge = cg;
            CircularScale cs = cg.FindName("m_scale") as CircularScale;
            if (cs != null)
            {
                _circularpointer = cs.Pointers[0];
                cs.Pointers[0].Value = sum / 5;
            }
        }

        CircularPointer _circularpointer = null;
        private void PieChart1_Loaded(object sender, RoutedEventArgs e)
        {
            SfChart piechart = sender as SfChart;
            IList<CompanyExpense> expenditure = new List<CompanyExpense>();
            expenditure.Add(new CompanyExpense() { Expense = "Production", Amount = 20d });
            expenditure.Add(new CompanyExpense() { Expense = "Facilities", Amount = 23d });
            expenditure.Add(new CompanyExpense() { Expense = "Insurance", Amount = 12d });
            expenditure.Add(new CompanyExpense() { Expense = "Licenses", Amount = 3d });
            expenditure.Add(new CompanyExpense() { Expense = "Labour", Amount = 28d });
            expenditure.Add(new CompanyExpense() { Expense = "Legal", Amount = 2d });
            expenditure.Add(new CompanyExpense() { Expense = "Taxes", Amount = 10d });
            piechart.Series[0].ItemsSource = expenditure;
        }

        private void AccumulationChart1_Loaded(object sender, RoutedEventArgs e)
        {
            SfChart AC = sender as SfChart;
            IList<AgriculturalProducts> productlist = new List<AgriculturalProducts>();
            productlist.Add(new AgriculturalProducts() { ProdId = 0, ProductName = "Wheat", GrowthPercentage = 11.23 });
            productlist.Add(new AgriculturalProducts() { ProdId = 1, ProductName = "Rice", GrowthPercentage = 15.78 });
            productlist.Add(new AgriculturalProducts() { ProdId = 2, ProductName = "Maize", GrowthPercentage = 21.62 });
            productlist.Add(new AgriculturalProducts() { ProdId = 3, ProductName = "Barley", GrowthPercentage = 23.28 });
            productlist.Add(new AgriculturalProducts() { ProdId = 4, ProductName = "Oats", GrowthPercentage = 27.99 });
            AC.Series[0].ItemsSource = productlist;
        }

        protected override void Dispose(bool disposing)
        {
            if (this.grid != null)
            {
                this.grid.Dispose();
                this.grid = null;
            }
            base.Dispose(disposing);
        }
    }


    #region Converters
    public class HighlightedToOpacityConverter : IValueConverter
    {

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            bool highlighted = (bool)value;
            if (highlighted)
                return 1;
            else
                return 0.85;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
    #endregion


    public class MyData
    {
        public int Year { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
        public double Y4 { get; set; }
    }

    public class My2007Sales
    {
        public string CategoryName { get; set; }
        public int CategorySales { get; set; }

    }


    public class AgriculturalProducts
    {
        public double ProdId { get; set; }

        public string ProductName { get; set; }

        public double GrowthPercentage { get; set; }
    }

    /// <summary>
    /// Datacollection added with Date, four random Values
    /// </summary>
    public class MyDataCollection : ObservableCollection<MyData>
    {
        public MyDataCollection()
        {
            Random rand = new Random(DateTime.Now.Millisecond);
            DateTime cdate = DateTime.Today.AddYears(-6);
            for (int i = 0; i < 5; i++)
            {
                this.Add(new MyData()
                {
                    Year = cdate.AddYears(i).Year,
                    Y1 = rand.Next(700, 1200),
                });
            }
        }
    }


    #region Category Sales for 2007

    public class My2007SalesCollection : ObservableCollection<My2007Sales>
    {
        public My2007SalesCollection()
        {
            Random rand = new Random();
            this.Add(new My2007Sales() { CategoryName = "Beverages", CategorySales = rand.Next(50000, 100000) });
            this.Add(new My2007Sales() { CategoryName = "Meat/Poultry", CategorySales = rand.Next(50000, 100000) });
            this.Add(new My2007Sales() { CategoryName = "Confections", CategorySales = rand.Next(50000, 100000) });
            this.Add(new My2007Sales() { CategoryName = "Produce", CategorySales = rand.Next(50000, 100000) });
            this.Add(new My2007Sales() { CategoryName = "Seafood", CategorySales = rand.Next(50000, 100000) });
            this.Add(new My2007Sales() { CategoryName = "Dairy Products", CategorySales = rand.Next(50000, 100000) });
            this.Add(new My2007Sales() { CategoryName = "Grains/Cereals", CategorySales = rand.Next(50000, 100000) });
            this.Add(new My2007Sales() { CategoryName = "Condiments", CategorySales = rand.Next(50000, 100000) });
        }
    }
    #endregion



    public class CompanyExpense
    {
        public string Expense { get; set; }
        public double Amount { get; set; }
    }



    public class Labelconvertor : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // This is possible during design time load
            if (!(value is CompanyExpense))
                return String.Empty;

            CompanyExpense info = value as CompanyExpense;

            return String.Format("{0} {1}%", info.Expense, info.Amount);
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

