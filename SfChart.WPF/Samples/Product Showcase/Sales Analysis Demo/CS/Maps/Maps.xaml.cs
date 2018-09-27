#region Copyright Syncfusion Inc. 2001-2016.
// Copyright Syncfusion Inc. 2001-2016. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Maps;
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

namespace SalesAnalysisDemo
{
    /// <summary>
    /// Interaction logic for Maps.xaml
    /// </summary>
    public partial class Maps : UserControl
    {
        public Maps()
        {
            InitializeComponent();
            (this.map.Layers[0] as ShapeFileLayer).ShapesSelected += Maps_ShapesSelected;
        }
        void Maps_ShapesSelected(object sender, SelectionEventArgs args)
        {
            SalesByContinet salesByContinent = ((args.Items as ObservableCollection<MapShape>)[0].DataContext as SalesByContinet);
            if (salesByContinent != null)
            {
                if (salesByContinent.Continent == "Africa")
                {
                    this.map.BaseMapIndex = 6;
                    this.DrillDownButton.Visibility = Visibility.Collapsed;
                    this.DrillUpButton.Visibility = Visibility.Visible;
                }
                else if (salesByContinent.Continent == "Oceania")
                {
                    this.map.BaseMapIndex = 1;
                    this.DrillDownButton.Visibility = Visibility.Collapsed;
                    this.DrillUpButton.Visibility = Visibility.Visible;
                }
                else if (salesByContinent.Continent == "South America")
                {
                    this.map.BaseMapIndex = 2;
                    this.DrillDownButton.Visibility = Visibility.Collapsed;
                    this.DrillUpButton.Visibility = Visibility.Visible;
                }
                else if (salesByContinent.Continent == "North America")
                {
                    this.map.BaseMapIndex = 3;
                    this.DrillDownButton.Visibility = Visibility.Collapsed;
                    this.DrillUpButton.Visibility = Visibility.Visible;
                }
                else if (salesByContinent.Continent == "Europe")
                {
                    this.map.BaseMapIndex = 4;
                    this.DrillDownButton.Visibility = Visibility.Collapsed;
                    this.DrillUpButton.Visibility = Visibility.Visible;
                }
                else if (salesByContinent.Continent == "Antarctica")
                {
                    this.map.BaseMapIndex = 5;
                    this.DrillDownButton.Visibility = Visibility.Collapsed;
                    this.DrillUpButton.Visibility = Visibility.Visible;
                }
                else if (salesByContinent.Continent == "Asia")
                {
                    this.map.BaseMapIndex = 7;
                    this.DrillDownButton.Visibility = Visibility.Collapsed;
                    this.DrillUpButton.Visibility = Visibility.Visible;
                }

                ViewModel VM = (this.DataContext as ViewModel);
                DateTime SelectedStartDate, SelectedEndDate;
                if ((this.DataContext as ViewModel).Selectedindex == 0)
                {
                    SelectedStartDate = new DateTime(2011, 1, 1);
                    SelectedEndDate = new DateTime(2011, 6, 30);
                }
                else
                {
                    SelectedStartDate = new DateTime(2011, 1, 7);
                    SelectedEndDate = new DateTime(2011, 12, 31);
                }
                #region Chart Data
                VM.SalesVsTarget = (object)(SalesDetail.GenerateTotalSalesVsTargetList(SalesDetail.GenerateSalesDetails(SelectedStartDate, SelectedEndDate)));
                #endregion
                #region Maps Data
                VM.Total_Sales = SalesDetail.GenerateSalesDetails(SelectedStartDate, SelectedEndDate);
                VM.Models = (SalesDetail.GenerateTotalSalesVsTargetListByContinent(VM.Total_Sales));


                VM.SalesByCountry = (SalesDetail.GenerateTotalSalesVsTargetListByCountry(VM.Total_Sales));
                for (int i = 0; i < VM.Models.Count; i++)
                {
                    VM.Models[i].DisplaySalesValue = String.Format("{0:C}", Convert.ToInt32(VM.Models[i].Sales.ToString()));
                }
                #endregion
                #region Gauge Data
                VM.SalesVsTarget = SalesDetail.GenerateTotalSalesVsTargetList(SalesDetail.GenerateSalesDetails(SelectedStartDate, SelectedEndDate));
                double saletotal = (VM.SalesVsTarget as ObservableCollection<SalesVsTarget>).Sum(s => s.Sales);
                double saletarget = (VM.SalesVsTarget as ObservableCollection<SalesVsTarget>).Sum(s => s.Target);
                VM.SalesTotal = (Math.Round(saletotal, 0)).ToString();
                VM.SalesTarget = (Math.Round(saletarget, 0)).ToString();
                VM.SalesPercentage = (saletotal / saletarget) * 100;
                #endregion
            }
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DrillUpButton.Visibility = Visibility.Collapsed;
            this.DrillDownButton.Visibility = Visibility.Visible;
            this.map.BaseMapIndex = 0;
        }
    }
}
