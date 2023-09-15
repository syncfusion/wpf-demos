#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls; 
using System.Windows.Data;
using System.Windows.Media; 
using System.Windows.Media.Imaging; 
using Microsoft.Win32; 
using Syncfusion.Data.Extensions;
using Syncfusion.UI.Xaml.Charts;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.UI.Xaml.Grid.Converter; 
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.XlsIO; 

namespace syncfusion.stockanalysisdemo.wpf
{
    /// <summary>
    /// Interaction logic for StockAnalysisView.xaml
    /// </summary>
    public partial class StockAnalysisView : UserControl
    {
        DataGridView gridView = new DataGridView();
        LineSeries lineSeries = new LineSeries();
        HiLoSeries hiLoSeries = new HiLoSeries();
        HiLoOpenCloseSeries hiLoOpenClose = new HiLoOpenCloseSeries();
        CandleSeries hollowSeries = new CandleSeries();
        int SelectedIndex;
        public ObservableCollection<ChartSeries> indicatorsCollection = new ObservableCollection<ChartSeries>();
        DateTime Today = DateTime.Now;
        public ListView listView;
        Window parentWindow = new Window();
        public StockAnalysisView()
        {
            InitializeComponent(); 
        }

        private void UpdateDayViewItemsSource()
        {
            if (PastText != null)
                PastText.Text = "After Hours as of ";

            if (this.PrimaryAxis != null)
            {
                this.PrimaryAxis.LabelFormat = "hh:mm tt";
                this.PrimaryAxis.IntervalType = DateTimeIntervalType.Hours;
                this.PrimaryAxis.Interval = 1; 
            }
           
            if (DayButton != null)
                DayButton.IsChecked = true;
            if (WeekButton != null)
                WeekButton.IsChecked = false;
            if (MonthButton != null)
                MonthButton.IsChecked = false; 
            if (OneYearButton != null)
                OneYearButton.IsChecked = false; 
            if (FiveYearButton != null)
                FiveYearButton.IsChecked = false;
            if (SelectedIndex == 0)
            {
                if (candleSeries != null)
                    candleSeries.ItemsSource = (this.DataContext as StockViewModel).StockDatas;
                if (columnSeries != null)
                    columnSeries.ItemsSource = (this.DataContext as StockViewModel).StockDatas;
            }
            else if (SelectedIndex == 1)
            {
                lineSeries.ItemsSource = columnSeries.ItemsSource = (this.DataContext as StockViewModel).StockDatas;
            }
            else if (SelectedIndex == 2)
            {
                hiLoSeries.ItemsSource = columnSeries.ItemsSource = (this.DataContext as StockViewModel).StockDatas;
            }
            else if (SelectedIndex == 3)
            {
                hiLoOpenClose.ItemsSource = columnSeries.ItemsSource = (this.DataContext as StockViewModel).StockDatas;
            }
            else  
            {
                hollowSeries.ItemsSource = columnSeries.ItemsSource = (this.DataContext as StockViewModel).StockDatas;
            }
            RemoveIndicators();
            UpdateHeaderValue();
        }
        private void MyWatchListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {  
            var listview = sender as ListView;
            if (listview.SelectedIndex == -1)
                return;
            var name = (listview.SelectedItem as Stock).StockName;
             
            switch (name)
            {
                case "AAPL":
                    SuggestedListView.SelectedIndex= 0;
                    break;
                case "MSFT":
                    SuggestedListView.SelectedIndex = 1;
                    break;
                case "GOOG":
                    SuggestedListView.SelectedIndex = 2;
                    break;
                case "AMZN":
                    SuggestedListView.SelectedIndex = 3;
                    break;
                case "TSLA":
                    SuggestedListView.SelectedIndex = 4;
                    break;
                case "META":
                    SuggestedListView.SelectedIndex = 5;
                    break;
                case "IBM":
                    SuggestedListView.SelectedIndex = 6;
                    break;
                case "ADBE":
                    SuggestedListView.SelectedIndex = 7;
                    break;
                case "TWTR":
                    SuggestedListView.SelectedIndex = 8;
                    break;
                case "TCS":
                    SuggestedListView.SelectedIndex = 9;
                    break;
                case "INTC":
                    SuggestedListView.SelectedIndex = 10;
                    break;
                case "HDB":
                    SuggestedListView.SelectedIndex = 11;
                    break;
                case "WIPRO":
                    SuggestedListView.SelectedIndex = 12;
                    break;
                case "BEL":
                    SuggestedListView.SelectedIndex = 13;
                    break;
            }
              
        }
        private void SuggestedListView_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (financialChart != null)
                financialChart.TechnicalIndicators.Clear();
            listView = sender as ListView;

            (this.DataContext as StockViewModel).ListViewIndex = listView.SelectedIndex;

            if (listView.SelectedIndex == 0)
            {
                (this.DataContext as StockViewModel).StockDetails = (this.DataContext as StockViewModel).AAPLStockDetails;
                (this.DataContext as StockViewModel).StockDatas= (this.DataContext as StockViewModel).AAPL;
            }
            else if (listView.SelectedIndex == 1)
            {
                (this.DataContext as StockViewModel).StockDetails = (this.DataContext as StockViewModel).MSFTStockDetails;
                (this.DataContext as StockViewModel).StockDatas = (this.DataContext as StockViewModel).MSFT;
            }
            else if (listView.SelectedIndex == 2)
            {
                (this.DataContext as StockViewModel).StockDetails = (this.DataContext as StockViewModel).GOOGStockDetails; 
                (this.DataContext as StockViewModel).StockDatas = (this.DataContext as StockViewModel).GOOG;
            }
            else if (listView.SelectedIndex == 3)
            {
                (this.DataContext as StockViewModel).StockDetails = (this.DataContext as StockViewModel).AMZNStockDetails; 
                (this.DataContext as StockViewModel).StockDatas = (this.DataContext as StockViewModel).AMZN;
            }
            else if (listView.SelectedIndex == 4)
            {
                (this.DataContext as StockViewModel).StockDetails = (this.DataContext as StockViewModel).TSLAStockDetails; 
                (this.DataContext as StockViewModel).StockDatas = (this.DataContext as StockViewModel).TSLA;
            }
            else if (listView.SelectedIndex == 5)
            {
                (this.DataContext as StockViewModel).StockDetails = (this.DataContext as StockViewModel).METAStockDetails; 
                (this.DataContext as StockViewModel).StockDatas = (this.DataContext as StockViewModel).META;
            }
            else if (listView.SelectedIndex == 6)
            {
                (this.DataContext as StockViewModel).StockDetails = (this.DataContext as StockViewModel).IBMStockDetails; 
                (this.DataContext as StockViewModel).StockDatas = (this.DataContext as StockViewModel).IBM;
            }
            else if (listView.SelectedIndex == 7)
            {
                (this.DataContext as StockViewModel).StockDetails = (this.DataContext as StockViewModel).ADBEStockDetails; 
                (this.DataContext as StockViewModel).StockDatas = (this.DataContext as StockViewModel).ADBE;
            }
            else if (listView.SelectedIndex == 8)
            {
                (this.DataContext as StockViewModel).StockDetails = (this.DataContext as StockViewModel).TWTRStockDetails; 
                (this.DataContext as StockViewModel).StockDatas = (this.DataContext as StockViewModel).TWTR; 
            }
            else if (listView.SelectedIndex == 9)
            {
                (this.DataContext as StockViewModel).StockDetails = (this.DataContext as StockViewModel).TCSStockDetails;
                (this.DataContext as StockViewModel).StockDatas = (this.DataContext as StockViewModel).TCS;
            }
            else if (listView.SelectedIndex == 10)
            {
                (this.DataContext as StockViewModel).StockDetails = (this.DataContext as StockViewModel).INTCStockDetails;
                (this.DataContext as StockViewModel).StockDatas = (this.DataContext as StockViewModel).INTC;
            }
            else if (listView.SelectedIndex == 11)
            {
                (this.DataContext as StockViewModel).StockDetails = (this.DataContext as StockViewModel).HDBStockDetails;
                (this.DataContext as StockViewModel).StockDatas = (this.DataContext as StockViewModel).HDB;
            }
            else if (listView.SelectedIndex == 12)
            {
                (this.DataContext as StockViewModel).StockDetails = (this.DataContext as StockViewModel).WIPROStockDetails;
                (this.DataContext as StockViewModel).StockDatas = (this.DataContext as StockViewModel).WIPRO;
            }
            else if (listView.SelectedIndex == 13)
            {
                (this.DataContext as StockViewModel).StockDetails = (this.DataContext as StockViewModel).BELStockDetails;
                (this.DataContext as StockViewModel).StockDatas = (this.DataContext as StockViewModel).BEL;
            }
            UpdateDayViewItemsSource();
        }

        private void OnSeriesComboBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (financialChart != null)
                financialChart.TechnicalIndicators.Clear(); 

            ComboBoxAdv comboBox = sender as ComboBoxAdv; 
            SelectedIndex = comboBox.SelectedIndex; 
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    {
                        if (candleSeries != null)
                            candleSeries.ItemsSource = (this.DataContext as StockViewModel).StockCollection;
                        if (columnSeries != null)
                            columnSeries.ItemsSource = (this.DataContext as StockViewModel).StockCollection;
                       
                        if (financialChart != null)
                        {
                            PrimaryAxis.PlotOffset = 0;
                            financialChart.Series[0] = candleSeries;
                        } 
                    }
                    break;
                case 1:
                    {
                        lineSeries.EnableAnimation = true;
                        lineSeries.AnimationDuration = new TimeSpan(00, 00, 03);
                        lineSeries.XBindingPath = "Date";
                        lineSeries.YBindingPath = "Low";
                        lineSeries.ShowTooltip = true;
                        lineSeries.ItemsSource = columnSeries.ItemsSource = (this.DataContext as StockViewModel).StockCollection; 
                        PrimaryAxis.PlotOffset= 10;
                        financialChart.Series[0] = lineSeries;
                    }
                    break;
                case 2:
                    {
                        hiLoSeries.XBindingPath = "Date";
                        hiLoSeries.High = "High";
                        hiLoSeries.Low = "Low";
                        hiLoSeries.ShowTooltip = true;
                        hiLoSeries.ItemsSource = columnSeries.ItemsSource = (this.DataContext as StockViewModel).StockCollection;
                        PrimaryAxis.PlotOffset = 8;
                        financialChart.Series[0] = hiLoSeries;
                    }
                    break;
                case 3:
                    {
                        hiLoOpenClose.XBindingPath = "Date";
                        hiLoOpenClose.High = "High";
                        hiLoOpenClose.Low = "Low";
                        hiLoOpenClose.Open = "Open";
                        hiLoOpenClose.Close = "Close";
                        hiLoOpenClose.ShowTooltip = true;
                        hiLoOpenClose.ItemsSource = columnSeries.ItemsSource = (this.DataContext as StockViewModel).StockCollection;
                        PrimaryAxis.PlotOffset = 0;
                        financialChart.Series[0] = hiLoOpenClose;
                    }
                    break;
                case 4:
                    {
                        hollowSeries.XBindingPath = "Date";
                        hollowSeries.High = "High";
                        hollowSeries.Low = "Low";
                        hollowSeries.Open = "Open";
                        hollowSeries.Close = "Close";
                        hollowSeries.ShowTooltip = true;
                        hollowSeries.ComparisonMode = FinancialPrice.Close;
                        hollowSeries.ItemsSource = columnSeries.ItemsSource = (this.DataContext as StockViewModel).StockCollection;
                        PrimaryAxis.PlotOffset = 0;
                        financialChart.Series[0] = hollowSeries;
                    }
                    break;
            }
            RemoveIndicators(); 
        }
         
        private void IndicatorComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBoxAdv comboBox = sender as ComboBoxAdv;
             if (comboBox.SelectedIndex == -1)
                 return;

            FinancialTechnicalIndicator indicator = null;
            switch (comboBox.SelectedIndex)
            {
                case 0:
                    indicator = new AccumulationDistributionIndicator();
                    break;
                case 1:
                    indicator = new BollingerBandIndicator();
                    break;
                case 2:
                    {
                        indicator = new MACDTechnicalIndicator()
                        {
                            Period = 3,
                            ShortPeriod = 2,
                            LongPeriod = 6, 
                            Type = MACDType.Line 
                        }; 
                    }
                    break;
                case 3:
                    {
                        indicator = new StochasticTechnicalIndicator()
                        {
                            Period = 3,
                            KPeriod = 8,
                            DPeriod = 5,
                            SignalLineColor = new SolidColorBrush(Colors.Black),

                            PeriodLineColor = new SolidColorBrush(Colors.Red),

                            UpperLineColor = new SolidColorBrush(Colors.Blue),

                            LowerLineColor = new SolidColorBrush(Colors.Purple)

                        };
                    } 
                    break;
                case 4:
                    indicator = new RSITechnicalIndicator();
                    break; 
            }
            indicatorsCollection.Clear();
            financialChart.TechnicalIndicators.Clear(); 
            indicator.XBindingPath = "Date";
            indicator.Open = "Open";
            indicator.Close = "Close";
            indicator.High = "High";
            indicator.Low = "Low";
            indicator.Volume = "Volume";
            indicator.ItemsSource = financialChart.Series[0].ItemsSource; 
            indicator.YAxis = financialChart.SecondaryAxis; 
            if (indicator != null)
            {
                indicatorsCollection.Add(indicator);
            } 
            foreach (var item in indicatorsCollection)
            {
                ISupportAxes2D indicatorAxis = item as ISupportAxes2D;
                var index = SfChart.GetRow(indicatorAxis.YAxis);
                if (index == 1)
                { 
                    financialChart.TechnicalIndicators.Add(item);
                    NumericalAxis axis = new NumericalAxis(); 
                    axis.ShowGridLines = false;
                    axis.Visibility = Visibility.Collapsed;
                    indicatorAxis.YAxis = axis;
                    SfChart.SetRow(indicatorAxis.YAxis, 1);
                }
            } 
        }

        private void GridViewButton_Click(object sender, RoutedEventArgs e)
        {
            DropDownMenuItem Excel = new DropDownMenuItem() { Header = "Export to Excel", Margin = new Thickness(-10, 0, 0, 0), Width = 118, Height = 35 };
            DropDownMenuItem PDF = new DropDownMenuItem() { Header = "Export to PDF", Margin = new Thickness(-10, 0, 0, 0), Width = 118, Height = 35 };
            DropDownMenuItem Image = new DropDownMenuItem() { Header = "Export to Image", Margin = new Thickness(-10, 0, 0, 0), Width = 118, Height = 35 };

            if (this.FilterButton.Visibility == Visibility.Collapsed)
            {
                Image.Click -= Image_Click;
                this.GridViewButton.Content = "Chart View";
                this.financialChart.Visibility = Visibility.Collapsed;
                this.DayButton.Visibility = Visibility.Collapsed;
                this.WeekButton.Visibility = Visibility.Collapsed;
                this.MonthButton.Visibility = Visibility.Collapsed;
                this.OneYearButton.Visibility = Visibility.Collapsed;
                this.FiveYearButton.Visibility = Visibility.Collapsed;
                this.SeriesComboBox.Visibility = Visibility.Collapsed;
                this.IndicatorComboBox.Visibility = Visibility.Collapsed; 
                this.FilterButton.Visibility = Visibility.Visible;
                dataGridArea.Visibility = Visibility.Visible;
                this.gridView.DataContext = this.DataContext;
                this.dataGridArea.Content = gridView; 
                menu.Items.Clear();
                Excel.Click += Excel_Click;
                PDF.Click += PDF_Click;
                menu.Items.Add(Excel);
                menu.Items.Add(PDF); 
            }
            else
            {
                Excel.Click -= Excel_Click;
                PDF.Click -= PDF_Click;
                this.GridViewButton.Content = "Grid View";
                this.financialChart.Visibility = Visibility.Visible;
                this.DayButton.Visibility = Visibility.Visible;
                this.WeekButton.Visibility = Visibility.Visible;
                this.MonthButton.Visibility = Visibility.Visible;
                this.OneYearButton.Visibility = Visibility.Visible;
                this.FiveYearButton.Visibility = Visibility.Visible;
                this.SeriesComboBox.Visibility = Visibility.Visible;
                this.IndicatorComboBox.Visibility = Visibility.Visible;
                this.FilterButton.Visibility = Visibility.Collapsed;
                dataGridArea.Visibility = Visibility.Collapsed; 
                menu.Items.Clear();
                Image.Click += Image_Click;
                menu.Items.Add(Image);
            } 
        }

        private void DayButton_Click(object sender, RoutedEventArgs e)
        {
            if (DayButton.IsChecked == false)
            {
                DayButton.IsChecked = true;
                return;
            }
            PastText.Text = "After Hours as of ";
            WeekButton.IsChecked = MonthButton.IsChecked = OneYearButton.IsChecked = FiveYearButton.IsChecked = false;  
            financialChart.TechnicalIndicators.Clear();
            this.PrimaryAxis.LabelFormat = "hh:mm tt"; 
            this.PrimaryAxis.IntervalType = DateTimeIntervalType.Hours;
            if (parentWindow.WindowState == WindowState.Maximized)
            {
                this.PrimaryAxis.Interval = 1;
            }
            else if (parentWindow.WindowState == WindowState.Normal)
            {
                this.PrimaryAxis.Interval = 2;
            } 
            financialChart.Series[0].ItemsSource = financialChart.Series[1].ItemsSource = (this.DataContext as StockViewModel).StockDatas;
            RemoveIndicators();
            UpdateHeaderValue();
        }

        private void WeekButton_Click(object sender, RoutedEventArgs e)
        {
            if (WeekButton.IsChecked == false)
            {
                WeekButton.IsChecked = true;
                return;
            }
            PastText.Text = "Past Week as of ";
            DayButton.IsChecked = MonthButton.IsChecked = OneYearButton.IsChecked = FiveYearButton.IsChecked = false; 
            financialChart.TechnicalIndicators.Clear();
            this.PrimaryAxis.LabelFormat = "MMM dd";
            this.PrimaryAxis.IntervalType = DateTimeIntervalType.Days;
            this.PrimaryAxis.Interval = 1;  
            var sortedCollection = (this.DataContext as StockViewModel).StockDetails.OrderBy(item => item.Date).ToObservableCollection();  
            financialChart.Series[0].ItemsSource = financialChart.Series[1].ItemsSource = sortedCollection.Where(item => item != null && item.Date >= Today.AddDays(-7)).ToObservableCollection();
            RemoveIndicators();
            UpdateHeaderValue();
        } 

        private void MonthButton_Click(object sender, RoutedEventArgs e)
        {
            if (MonthButton.IsChecked == false)
            {
                MonthButton.IsChecked = true;
                return;
            }

            PastText.Text = "Past Month as of ";
            DayButton.IsChecked = WeekButton.IsChecked = OneYearButton.IsChecked = FiveYearButton.IsChecked = false; 
            this.PrimaryAxis.IntervalType = DateTimeIntervalType.Days;
            this.PrimaryAxis.Interval = 5;
            financialChart.TechnicalIndicators.Clear(); 
            this.PrimaryAxis.LabelFormat = "MMM dd"; 
            var sortedCollection = (this.DataContext as StockViewModel).StockDetails.OrderBy(item => item.Date).ToObservableCollection();
            financialChart.Series[0].ItemsSource = financialChart.Series[1].ItemsSource = sortedCollection.Where(item => item != null && (item.Date.Month == Today.Month || (item.Date.Month == Today.Month - 1 && item.Date.Day > Today.Day)) && item.Date.Year == Today.Year).ToObservableCollection();
            RemoveIndicators();
            UpdateHeaderValue();
        }
         
        private void OneYearButton_Click(object sender, RoutedEventArgs e)
        {
            if (OneYearButton.IsChecked == false)
            {
                OneYearButton.IsChecked = true;
                return;
            }
            PastText.Text = "Past Year as of ";
            DayButton.IsChecked = WeekButton.IsChecked = MonthButton.IsChecked = FiveYearButton.IsChecked = false;
            financialChart.TechnicalIndicators.Clear(); 
            this.PrimaryAxis.LabelFormat = "MMM yyyy";
            this.PrimaryAxis.IntervalType = DateTimeIntervalType.Months;
            this.PrimaryAxis.Interval = 2; 
            var sortedCollection = (this.DataContext as StockViewModel).StockDetails.OrderBy(item => item.Date).ToObservableCollection();
            var filteredCollection = GetRecordsWithFirstAvailableDays(sortedCollection);
            filteredCollection = filteredCollection.Where(item => (item.Date.Year == DateTime.Now.Year || (item.Date.Year == (DateTime.Now.Year - 1) && item.Date.Month >= DateTime.Now.Month))).ToObservableCollection();
            financialChart.Series[0].ItemsSource = financialChart.Series[1].ItemsSource = null;
            financialChart.Series[0].ItemsSource = financialChart.Series[1].ItemsSource = filteredCollection; 
            RemoveIndicators();
            UpdateHeaderValue();
        }
         
        private void FiveYearButton_Click(object sender, RoutedEventArgs e)
        {
            if (FiveYearButton.IsChecked == false)
            {
                FiveYearButton.IsChecked = true;
                return;
            }
            PastText.Text = "Past 5 Years as of ";
            DayButton.IsChecked = WeekButton.IsChecked = MonthButton.IsChecked = OneYearButton.IsChecked = false; 
            financialChart.TechnicalIndicators.Clear();
            this.PrimaryAxis.LabelFormat = "MMM yyyy";
            this.PrimaryAxis.IntervalType = DateTimeIntervalType.Months;
            this.PrimaryAxis.Interval = 10;   
            var sortedCollection = (this.DataContext as StockViewModel).StockDetails.OrderBy(item => item.Date).ToObservableCollection();
            var filteredCollection = GetRecordsWithFirstAvailableDays(sortedCollection); 
            financialChart.Series[0].ItemsSource = financialChart.Series[1].ItemsSource = null;
            financialChart.Series[0].ItemsSource = financialChart.Series[1].ItemsSource = filteredCollection; 
            RemoveIndicators();
            UpdateHeaderValue();
        }

        public ObservableCollection<StockData> GetRecordsWithFirstAvailableDays(ObservableCollection<StockData> data)
        { 
            var recordsWithFirstAvailableDays = data
                .GroupBy(item => new { item.Date.Year, item.Date.Month })  
                .Select(group =>
                {
                    var firstRecord = group.OrderBy(item => item.Date.Day).First();  
                    return firstRecord;
                })
                .ToObservableCollection();

            return recordsWithFirstAvailableDays;
        }

        private void SplitterButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.SuggestedTabItem.Width > 58)
            {
                VisualStateManager.GoToState(gridSplitter, "Collapsed", false);
                gridSplitter.MoveSplitter(-214);
                this.SuggestedTabItem.Width = 58;
                this.WatchListTabItem.Width = 58;
                this.SuggestedListView.Width = 130;
                this.MyWatchListView.Width = 130;
            }
            else
            {
                VisualStateManager.GoToState(gridSplitter, "Expanded", false);
                gridSplitter.MoveSplitter(214);
                this.SuggestedTabItem.Width = 172;
                this.WatchListTabItem.Width = 172;
                this.SuggestedListView.Width = 343;
                this.MyWatchListView.Width = 343;
            }
        }

        private void FilterButton_Click(object sender, RoutedEventArgs e)
        {
            if (!gridView.datagrid.AllowFiltering)
                gridView.datagrid.AllowFiltering = true;
            else
                gridView.datagrid.AllowFiltering = false;
        }
 
        private void NumericalAxis_LabelCreated(object sender, LabelCreatedEventArgs e)
        {
            e.AxisLabel.LabelContent = string.Empty;
        }

        private void PrintButton_Click(object sender, RoutedEventArgs e)
        {
            if (financialChart.Visibility == Visibility.Visible)
                financialChart.Print();
            else
            {
                gridView.datagrid.PrintSettings = new PrintSettings();
                gridView.datagrid.PrintSettings.AllowPrintByDrawing = false;
                gridView.datagrid.PrintSettings.AllowPrintStyles = true;
                gridView.datagrid.PrintSettings.PrintHeaderRowHeight = 47;
                gridView.datagrid.PrintSettings.PrintRowHeight = 64; 
                gridView.datagrid.PrintSettings.PrintPageMargin = new Thickness(76, 96, 76, 96); 
                gridView.datagrid.PrintSettings.PrintManagerBase = new CustomPrintManager(this.gridView.datagrid);
                gridView.datagrid.ShowPrintPreview(); 
            }
        } 
         
        private void Image_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog { FileName = "Image1" };

            sfd.Filter = "Bitmap(*.bmp)|*.bmp|JPEG(*.jpg,*.jpeg)|*.jpg;*.jpeg|Gif (*.gif)|*.gif|PNG(*.png)|*.png|TIFF(*.tif,*.tiff)|*.tif|All files (*.*)|*.*";
            if (sfd.ShowDialog() == true)
            {
                using (Stream fs = sfd.OpenFile())
                { 
                    financialChart.Save(fs, new PngBitmapEncoder());
                    if (MessageBox.Show("Do you want to view the image?", "Image has been created",
                                   MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                    { 
                        System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(sfd.FileName);
                        info.UseShellExecute = true;
                        System.Diagnostics.Process.Start(info);
                    }
                } 
            }
        }

        private void PDF_Click(object sender, RoutedEventArgs e)
        {
            PdfExportingOptions options = new PdfExportingOptions();
            options.AutoColumnWidth = false;
            options.FitAllColumnsInOnePage = true;
            var document = gridView.datagrid.ExportToPdf(options);
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "PDF Files(*.pdf)|*.pdf",
                FileName = "Document1"
            };
            if (sfd.ShowDialog() == true)
            {
                using (Stream stream = sfd.OpenFile())
                {
                    document.Save(stream);
                }
                if (MessageBox.Show("Do you want to view the Pdf file?", "Pdf file has been created",
                                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.Process.Start(sfd.FileName);
                }
            }
        }

        private void Excel_Click(object sender, RoutedEventArgs e)
        {
            var options = new ExcelExportingOptions();
            options.ExportMode = ExportMode.Value;
            options.ExportMergedCells = true;
            var excelEngine = gridView.datagrid.ExportToExcel(gridView.datagrid.View, options);
            var workBook = excelEngine.Excel.Workbooks[0];
            SaveFileDialog sfd = new SaveFileDialog
            {
                FilterIndex = 2,
                Filter = "Excel 97 to 2003 Files(*.xls)|*.xls|Excel 2007 to 2010 Files(*.xlsx)|*.xlsx",
                FileName = "Book1"
            };

            if (sfd.ShowDialog() == true)
            {
                using (Stream stream = sfd.OpenFile())
                {
                    if (sfd.FilterIndex == 1)
                        workBook.Version = ExcelVersion.Excel97to2003;
                    else
                        workBook.Version = ExcelVersion.Excel2010;
                    workBook.SaveAs(stream);
                }

                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo(sfd.FileName);
                    info.UseShellExecute = true;
                    System.Diagnostics.Process.Start(info);
                }
            }
        }
  
        private void UpdateHeaderValue()
        {
            StockViewModel stockViewModel = this.DataContext as StockViewModel;
            string sign;
            double high; 
            stockViewModel.MySuggestedStockCollection[stockViewModel.ListViewIndex].PreviousClose = stockViewModel.StockCollection[stockViewModel.StockCollection.Count - 1].Close;

            high = stockViewModel.StockCollection[stockViewModel.StockCollection.Count - 1].Close - stockViewModel.StockCollection[0].Open;
            sign = high >= 0 ? "+" : "-";
            stockViewModel.MySuggestedStockCollection[stockViewModel.ListViewIndex].PreviousHigh = sign + Math.Abs(high).ToString("0.##");
            stockViewModel.MySuggestedStockCollection[stockViewModel.ListViewIndex].PreviousChange = sign + Math.Abs((high / stockViewModel.StockCollection[0].Open) * 100).ToString("0.##");
        }

        private void RemoveIndicators()
        {
            if (this.IndicatorComboBox != null)
            {
                IndicatorComboBox.SelectedIndex = -1;
                foreach (var item in IndicatorComboBox.Items)
                {
                    (item as ComboBoxItemAdv).IsSelected = false;
                }
            }
        }

        private void ParentWindow_StateChanged(object sender, EventArgs e)
        {
            if (DayButton.IsChecked == false)
                return;
            if (parentWindow.WindowState == WindowState.Maximized)
            {
                this.PrimaryAxis.Interval = 1;
            }
            else if (parentWindow.WindowState == WindowState.Normal)
            {
                this.PrimaryAxis.Interval = 2;
            }
        }
        private void root_Loaded(object sender, RoutedEventArgs e)
        {
            parentWindow = Window.GetWindow(this); 
            parentWindow.StateChanged += ParentWindow_StateChanged; 
        }

        private void TabControl_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        { 
            TabControl tabControl = sender as TabControl;
            if (tabControl != null)
            {
                TabItem selectedTab = tabControl.SelectedItem as TabItem;
                if (selectedTab != null)
                {
                    (this.DataContext as StockViewModel).needToRemove = false;
                    string selectedTabItem = selectedTab.Name.ToString();
                    if (selectedTabItem== "SuggestedTabItem" && MyWatchListView.Items.Count>0)
                        MyWatchListView.SelectedIndex = -1;
                    if (selectedTabItem != "SuggestedTabItem" && MyWatchListView.Items.Count > 0)
                        (this.DataContext as StockViewModel).needToRemove = true;
                }
            }
        }

        private void Secondary_AxisBoundsChanged(object sender, ChartAxisBoundsEventArgs e)
        {
            var axis = sender as NumericalAxis;
            if (axis != null)
            {
                annotation.Y1 = (axis.VisibleRange.End);
            }
        }

        private void Primary_AxisBoundsChanged(object sender, ChartAxisBoundsEventArgs e)
        {
            var axis = sender as DateTimeCategoryAxis;
            if (axis != null)
            {
                annotation.X1 = (axis.VisibleRange.End);
            }
        }

        public double MinMax(double value, double min, double max)
        {
            return value > max ? max : (value < min ? min : value);
        }

        private void ZoomIn1_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in financialChart.Axes)
            {
                var axis = item as ChartAxisBase2D;
                var origin = 0.5;

                if (axis != null)
                {
                    double currentScale = Math.Max(1 / MinMax(axis.ZoomFactor, 0, 1), 1);
                    double cumulativeScale = Math.Max(currentScale + (0.25 * 1), 1);
                    zoom.Zoom(cumulativeScale, origin > 1d ? 1d : origin < 0d ? 0d : origin, axis); 
                }
            }
        }

        private void ZoomOut1_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in financialChart.Axes)
            {
                var axis = item as ChartAxisBase2D;
                var origin = 0.5;

                if (axis != null)
                {
                    double currentScale = Math.Max(1 / MinMax(axis.ZoomFactor, 0, 1), 1);
                    double cumulativeScale = Math.Max(currentScale + (0.25 * -1), 1);
                    zoom.Zoom(cumulativeScale, origin > 1d ? 1d : origin < 0d ? 0d : origin, axis); 
                }
            }
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            zoom.Reset();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (PrimaryAxis.ZoomPosition < 1 && PrimaryAxis.ZoomPosition > 0.1)
            {
                PrimaryAxis.ZoomPosition = PrimaryAxis.ZoomPosition - 0.1;
            } 
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (PrimaryAxis.ZoomPosition < 0.9 && PrimaryAxis.ZoomPosition >= 0)
            {
                PrimaryAxis.ZoomPosition = PrimaryAxis.ZoomPosition + 0.1;
            } 
        }

        public class CustomPrintManager : GridPrintManager
        {
            public CustomPrintManager(SfDataGrid grid)
                : base(grid)
            {
            }

            protected override double GetColumnWidth(string mappingName)
            {
                if (mappingName == "StockItemName")
                    return 130;
                else if (mappingName == "StockChange")
                    return 90;
                else if (mappingName == "StockPercent")
                    return 90;
                else if (mappingName == "StockClose")
                    return 90;
                else if (mappingName == "Rating")
                    return 110;
                else
                    return base.GetColumnWidth(mappingName);
            }
        } 
    }
}
