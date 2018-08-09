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
using Syncfusion.XlsIO;
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.Collections.ObjectModel;

namespace FormControls_2008
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : ChromelessWindow
    {

        ExcelEngine excelEngine;
        
        string fileName = "Filters.xlsx";
        ObservableCollection<IconList> iconsList = new ObservableCollection<IconList>();
        public Window1()
        {
            InitializeComponent();
            ImageSourceConverter img = new ImageSourceConverter();
            string file = @"..\..\..\..\..\..\..\Common\Images\XlsIO\xlsio_header.png";
            this.image1.Source = (ImageSource)img.ConvertFromString(file);
            iconsList.Add(new IconList { IconName = "1", Icon = @"image\CF_IS_RedCrossSymbol.png" });
            iconsList.Add(new IconList { IconName = "2", Icon = @"image\CF_IS_YellowExclamationSymbol.png" });
            iconsList.Add(new IconList { IconName = "3", Icon = @"image\CF_IS_GreenCheckSymbol.png" });
            iconsList.Add(new IconList { IconName = "NoIcon", Icon = @"image\NoIcon.png" });

            iconIdComboBox.ItemsSource = iconsList;
            string[] columnNames = { "Custom Filter", "Text Filter", "DateTime Filter", "Dynamic Filter", "Color Filter", "Icon Filter", "Advanced Filter" };
            
            for (int i = 0; i < columnNames.Length; i++)
            {
                cmbAlgorithm.Items.Add(columnNames[i]);
            }
            string[] colors = { "Red", "Blue", "Green", "Yellow", "Empty" };
            for (int i = 0; i < colors.Length; i++)
            {
                comboBox.Items.Add(colors[i]);
            }
            string[] iconSetTypes = { "ThreeSymbols", "FourRating", "FiveArrows" };

            
            cmbAlgorithm.SelectedIndex = 0;
            comboBox.SelectedIndex = 0;
            iconSetType.SelectedIndex = 0;
            
            excelEngine = new ExcelEngine();
        }


        #region Helper Methods
        private void FilterData(string outFileName)
        {
            IWorkbook book;
            if (cmbAlgorithm.SelectedIndex == 6)
            {
                 book = excelEngine.Excel.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\AdvancedFilterData.xlsx", ExcelOpenType.Automatic);
            }
            else if (cmbAlgorithm.SelectedIndex == 5)
            {
                book = excelEngine.Excel.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\IconFilterData.xlsx", ExcelOpenType.Automatic);
            }
            else if (cmbAlgorithm.SelectedIndex == 4)
            {
                book = excelEngine.Excel.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\FilterData_Color.xlsx", ExcelOpenType.Automatic);
            }
            else
            {
                 book = excelEngine.Excel.Workbooks.Open(@"..\..\..\..\..\..\..\Common\Data\XlsIO\FilterData.xlsx", ExcelOpenType.Automatic);
            }
            IWorksheet sheet = book.Worksheets[0];
            if (cmbAlgorithm.SelectedIndex != 6)
            {
                sheet.AutoFilters.FilterRange = sheet.Range[1, 1, 49, 3];
            }

            string sortOn = cmbAlgorithm.SelectedValue as string;
            int columnIndex = GetSelectedIndex(sortOn);

            switch (columnIndex)
            {
                case 0:
                    IAutoFilter filter1 = sheet.AutoFilters[0];
                    filter1.IsAnd = false;
                    filter1.FirstCondition.ConditionOperator = ExcelFilterCondition.Equal;
                    filter1.FirstCondition.DataType = ExcelFilterDataType.String;
                    filter1.FirstCondition.String = "Owner";

                    filter1.SecondCondition.ConditionOperator = ExcelFilterCondition.Equal;
                    filter1.SecondCondition.DataType = ExcelFilterDataType.String;
                    filter1.SecondCondition.String = "Sales Representative";
                    break;

                case 1:
                    IAutoFilter filter2 = sheet.AutoFilters[0];
                    filter2.AddTextFilter(new string[] { "Owner", "Sales Representative", "Sales Associate" });
                    break;

                case 2:
                    IAutoFilter filter3 = sheet.AutoFilters[1];
                    filter3.AddDateFilter(new DateTime(2004, 9, 1, 1, 0, 0, 0), DateTimeGroupingType.month);
                    filter3.AddDateFilter(new DateTime(2011, 1, 1, 1, 0, 0, 0), DateTimeGroupingType.year);
                    break;

                case 3:
                    IAutoFilter filter4 = sheet.AutoFilters[1];
                    filter4.AddDynamicFilter(DynamicFilterType.Quarter1);
                    break;

                case 4:
                    #region Color Filter
                    sheet.AutoFilters.FilterRange = sheet["A1:C49"];
                    System.Drawing.Color color = System.Drawing.Color.Empty;
                    switch(comboBox.SelectedIndex)
                    {
                        case 0:
                            color = System.Drawing.Color.Red;
                            break;
                        case 1:
                            color = System.Drawing.Color.Blue;
                            break;
                        case 2:
                            color = System.Drawing.Color.Green;
                            break;
                        case 3:
                            color = System.Drawing.Color.Yellow;
                            break;
                        case 4:
                            //Do nothing.
                            break;
                    }
                    if (rdb3.IsChecked == true)
                    {
                        IAutoFilter filter = sheet.AutoFilters[2];
                        filter.AddColorFilter(color, ExcelColorFilterType.FontColor);
                    }
                    else
                    {
                        IAutoFilter filter = sheet.AutoFilters[0];
                        filter.AddColorFilter(color, ExcelColorFilterType.CellColor);
                    }
                    #endregion

                    break;

                case 5:
                    #region IconFilter
                    sheet.AutoFilters.FilterRange = sheet["A4:D44"];
                    ExcelIconSetType iconset = ExcelIconSetType.ThreeSymbols;
                    int iconId = 0;
                    int filterIndex = 0;
                    switch (iconSetType.SelectedIndex)
                    {
                        case 0:
                            iconset = ExcelIconSetType.ThreeSymbols;
                            filterIndex = 3;
                            break;
                        case 1:
                            iconset = ExcelIconSetType.FourRating;
                            filterIndex = 1;
                            break;
                        case 2:
                            iconset = ExcelIconSetType.FiveArrows;
                            filterIndex = 2;
                            break;
                    }
                    switch (iconIdComboBox.SelectedIndex)
                    {
                        case 0:
                            //Do nothing
                            break;
                        case 1:
                            iconId = 1;
                            break;
                        case 2:
                            iconId = 2;
                            break;
                        case 3:
                            if (iconSetType.SelectedIndex == 0)
                                iconset = (ExcelIconSetType)(-1);
                            else
                                iconId = 3;
                            break;
                        case 4:
                            if (iconSetType.SelectedIndex == 1)
                                iconset = (ExcelIconSetType)(-1);
                            else
                                iconId = 4;
                            break;
                        case 5:
                            iconset = (ExcelIconSetType)(-1);
                            break;
                    }
                    IAutoFilter filter5 = sheet.AutoFilters[filterIndex];
                    filter5.AddIconFilter(iconset, iconId);
                    #endregion
                    break;

                case 6:
                    #region AdvancedFilter

                    IRange filterRange = sheet.Range["A8:G51"];
                    IRange criteriaRange = sheet.Range["A2:B5"];
                    if (rdb1.IsChecked==true)
                    {
                        sheet.AdvancedFilter(ExcelFilterAction.FilterInPlace, filterRange, criteriaRange, null, checkBox.IsChecked==true);
                    }
                    else if (rdb2.IsChecked==true)
                    {
                        IRange range = sheet.Range["I7:O7"];
                        range.Merge();
                        range.Text = "FilterCopy";
                        range.CellStyle.Font.RGBColor = System.Drawing.Color.FromArgb(0, 112, 192);
                        range.HorizontalAlignment = ExcelHAlign.HAlignCenter;
                        range.CellStyle.Font.Bold = true;
                        IRange copyRange = sheet.Range["I8"];
                        sheet.AdvancedFilter(ExcelFilterAction.FilterCopy, filterRange, criteriaRange, copyRange, checkBox.IsChecked==true);
                    }
                    #endregion
                    break;
            }
            book.SaveAs(outFileName);
            book.Close();

        }
        #endregion


        private void Window_Closing(object sender, CancelEventArgs e)
        {
            excelEngine.Dispose();
        }

        
        private void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                FilterData(fileName);

                //Message box confirmation to view the created spreadsheet.
                if (MessageBox.Show("Do you want to view the workbook?", "Workbook has been created",
                    MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
                {
                    try
                    {
                        //Launching the Excel file using the default Application.[MS Excel Or Free ExcelViewer]
                        System.Diagnostics.Process.Start(fileName);

                        //Exit
                        //this.Close();
                    }
                    catch (Win32Exception ex)
                    {
                        MessageBox.Show("Excel 2007 is not installed in this system");
                        Console.WriteLine(ex.ToString());
                    }
                }
                //else
                    // Exit
                    //this.Close();
            }
            catch
            {
                MessageBox.Show("Sorry, Excel can't open two workbooks with the same name at the same time.\nPlease close the workbook and try again.", "File is already open", MessageBoxButton.OK);
            }
        }


        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if (cmbAlgorithm.SelectedIndex == 6)
            {
                System.Diagnostics.Process.Start(@"..\..\..\..\..\..\..\Common\Data\XlsIO\AdvancedFilterData.xlsx");
            }
            else if (cmbAlgorithm.SelectedIndex == 5)
            {
                System.Diagnostics.Process.Start(@"..\..\..\..\..\..\..\Common\Data\XlsIO\IconFilterData.xlsx");
            }
            else if (cmbAlgorithm.SelectedIndex == 4)
            {
                System.Diagnostics.Process.Start(@"..\..\..\..\..\..\..\Common\Data\XlsIO\FilterData_Color.xlsx");
            }
            else
            {
                System.Diagnostics.Process.Start(@"..\..\..\..\..\..\..\Common\Data\XlsIO\FilterData.xlsx");
            }
        }

        private int GetSelectedIndex(string value)
        {
            switch (value)
            {
                case "Custom Filter": return 0;
                case "Text Filter": return 1;
                case "DateTime Filter": return 2;
                case "Dynamic Filter": return 3;
                case "Color Filter": return 4;
                case "Icon Filter": return 5;
                case "Advanced Filter": return 6;
                default: return 0;
            }
        }

        private void cmbAlgorithm_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cmbAlgorithm.SelectedIndex==6)
            {
                advanced.IsEnabled=true;
                advanced.Visibility = Visibility.Visible;
                colorFilter.IsEnabled = false;
                colorFilter.Visibility = Visibility.Hidden;
                iconFilter.IsEnabled = false;
                iconFilter.Visibility = Visibility.Hidden;
            }
            else if(cmbAlgorithm.SelectedIndex == 4)
            {
                advanced.IsEnabled = false;
                advanced.Visibility = Visibility.Hidden;
                colorFilter.IsEnabled = true;
                colorFilter.Visibility = Visibility.Visible;
                rdb3.IsChecked = true;
                comboBox.SelectedIndex = 0;
                iconFilter.IsEnabled = false;
                iconFilter.Visibility = Visibility.Hidden;
            }
            else if(cmbAlgorithm.SelectedIndex == 5)
            {
                advanced.IsEnabled = false;
                advanced.Visibility = Visibility.Hidden;
                colorFilter.IsEnabled = false;
                colorFilter.Visibility = Visibility.Hidden;
                rdb3.IsChecked = true;
                comboBox.SelectedIndex = 0;
                iconFilter.IsEnabled = true;
                iconFilter.Visibility = Visibility.Visible;
            }
            else
            {
                colorFilter.IsEnabled = false;
                colorFilter.Visibility = Visibility.Hidden;
                advanced.Visibility = Visibility.Visible;
                advanced.IsEnabled=false;
                rdb1.IsChecked = true;
                rdb2.IsChecked = false;
                checkBox.IsChecked = false;
                iconFilter.IsEnabled = false;
                iconFilter.Visibility = Visibility.Hidden;
            }
        }

        private void IconSetChanged(object sender, SelectionChangedEventArgs e)
        {
            if((sender as ComboBox).SelectedIndex == 0)
            {
                iconsList.Clear();
                iconsList.Add(new IconList { IconName = "1", Icon = @"image\CF_IS_RedCrossSymbol.png" });
                iconsList.Add(new IconList { IconName = "2", Icon = @"image\CF_IS_YellowExclamationSymbol.png" });
                iconsList.Add(new IconList { IconName = "3", Icon = @"image\CF_IS_GreenCheckSymbol.png" });
                iconsList.Add(new IconList { IconName = "NoIcon", Icon = @"image\NoIcon.png" });
            }
            else if((sender as ComboBox).SelectedIndex == 1)
            {
                iconsList.Clear();
                iconsList.Add(new IconList { IconName = "1", Icon = @"image\CF_IS_SignalWithOneFillBar.png" });
                iconsList.Add(new IconList { IconName = "2", Icon = @"image\CF_IS_SignalWithTwoFillBars.png" });
                iconsList.Add(new IconList { IconName = "3", Icon = @"image\CF_IS_SignalWithThreeFillBars.png" });
                iconsList.Add(new IconList { IconName = "4", Icon = @"image\CF_IS_SignalWithFourFillBars.png" });
                iconsList.Add(new IconList { IconName = "NoIcon", Icon = @"image\NoIcon.png" });
            }
            else
            {
                iconsList.Clear();
                iconsList.Add(new IconList { IconName = "1", Icon = @"image\CF_IS_RedDownArrow.png" });
                iconsList.Add(new IconList { IconName = "2", Icon = @"image\CF_IS_YellowDownInclineArrow.png" });
                iconsList.Add(new IconList { IconName = "3", Icon = @"image\CF_IS_YellowSideArrow.png" });
                iconsList.Add(new IconList { IconName = "4", Icon = @"image\CF_IS_YellowUpInclineArrow.png" });
                iconsList.Add(new IconList { IconName = "5", Icon = @"image\CF_IS_GreenUpArrow.png" });
                iconsList.Add(new IconList { IconName = "NoIcon", Icon = @"image\NoIcon.png" });
            }
            iconIdComboBox.SelectedIndex = 0;
        }
    }
    
    public class IconList
    {
        public string IconName { get; set; }
        public string Icon { get; set; }
    }
}
