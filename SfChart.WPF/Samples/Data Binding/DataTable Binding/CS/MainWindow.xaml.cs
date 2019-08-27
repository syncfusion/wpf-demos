#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.Windows.SampleLayout;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataTableBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
    
    public class ViewModel
    {
        public DataTable ChartDataTable { get; set; }
        public DataTable ChartDataTable2 { get; set; }

        public ViewModel()
        {
            ChartDataTable = new DataTable();

            ChartDataTable.Columns.Add("Product", typeof(string));
            ChartDataTable.Columns.Add("Percentage", typeof(double));

            ChartDataTable.Rows.Add("Data Cable", 65);
            ChartDataTable.Rows.Add("Charger", 60);
            ChartDataTable.Rows.Add("Smartwatch", 75);
            ChartDataTable.Rows.Add("Earphone", 80);
            ChartDataTable.Rows.Add("Cellphone",90);
                       
            ChartDataTable2 = new DataTable();

            ChartDataTable2.Columns.Add("Product", typeof(string));
            ChartDataTable2.Columns.Add("Percentage", typeof(double));

            ChartDataTable2.Rows.Add("Data Cable", 60);
            ChartDataTable2.Rows.Add("Charger", 55);
            ChartDataTable2.Rows.Add("Smartwatch", 70);
            ChartDataTable2.Rows.Add("Earphone", 77);
            ChartDataTable2.Rows.Add("Cellphone", 93);
        }
    }    
}
