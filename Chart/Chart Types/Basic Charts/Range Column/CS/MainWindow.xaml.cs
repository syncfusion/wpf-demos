#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.SampleLayout;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace RangeColumnChart
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

    public class FinancialDataViewModel
    {
        public FinancialDataViewModel()
        {
            FinancialDatas = new ObservableCollection<FinancialData>();
            FinancialDatas.Add(new FinancialData(new DateTime(2010, 7, 1), 604, 595));
            FinancialDatas.Add(new FinancialData(new DateTime(2011, 7, 1), 602, 595));
            FinancialDatas.Add(new FinancialData(new DateTime(2012, 7, 1), 608, 594));
            FinancialDatas.Add(new FinancialData(new DateTime(2013, 7, 1), 619, 604));
            FinancialDatas.Add(new FinancialData(new DateTime(2014, 7, 1), 608, 594));
        }

        public ObservableCollection<FinancialData> FinancialDatas
        {
            get;
            set;
        }
    }

    public class FinancialData
    {
        public FinancialData(DateTime time,double high, double low)
        {
            Time = time;
            High = high;
            Low = low;
        }
       
        public DateTime Time
        {
            get;
            set;
        }

        public double High
        {
            get;
            set;
        }

        public double Low
        {
            get;
            set;
        }
    } 
}
