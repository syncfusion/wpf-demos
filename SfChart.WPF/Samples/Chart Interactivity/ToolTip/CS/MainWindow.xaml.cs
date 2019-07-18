#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using Syncfusion.Windows.SampleLayout;

namespace CustomTooltip
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            CompanyDetails = new ObservableCollection<CompanyDetail>();

            CompanyDetails.Add(new CompanyDetail()
            {
                CompanyName = "Mercedes",
                YTD = 983.502,
                Rank = 16,
                ImagePath = new Uri(@"\Image\benz.png", UriKind.RelativeOrAbsolute)
            });
            CompanyDetails.Add(new CompanyDetail()
            {
                CompanyName = "Audi",
                YTD = 1030.393,
                Rank = 12,
                ImagePath = new Uri(@"\Image\audi.png", UriKind.RelativeOrAbsolute)
            });
            CompanyDetails.Add(new CompanyDetail()
            {
                CompanyName = "BMW",
                YTD = 1061.330,
                Rank = 11,
                ImagePath = new Uri(@"\Image\bmw.png", UriKind.RelativeOrAbsolute)
            });
            CompanyDetails.Add(new CompanyDetail()
            {
                CompanyName = "Skoda",
                YTD = 590.897,
                Rank = 24,
                ImagePath = new Uri(@"\Image\skoda.png", UriKind.RelativeOrAbsolute)
            });
            CompanyDetails.Add(new CompanyDetail()
            {
                CompanyName = "Volvo",
                YTD = 250.758,
                Rank = 43,
                ImagePath = new Uri(@"\Image\volvo.png", UriKind.RelativeOrAbsolute)
            });

            InitializeComponent();

            this.DataContext = this;
        }

        public ObservableCollection<CompanyDetail> CompanyDetails { get; set; }

        private void horizontalAlign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    this.sampleChart.Series[0].SetValue(ChartTooltip.HorizontalAlignmentProperty, HorizontalAlignment.Left);
                    break;

                case 1:
                    this.sampleChart.Series[0].SetValue(ChartTooltip.HorizontalAlignmentProperty, HorizontalAlignment.Center);
                    break;

                case 2:
                    this.sampleChart.Series[0].SetValue(ChartTooltip.HorizontalAlignmentProperty, HorizontalAlignment.Right);
                    break;
            }
        }

        private void verticalAlign_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch ((sender as ComboBox).SelectedIndex)
            {
                case 0:
                    this.sampleChart.Series[0].SetValue(ChartTooltip.VerticalAlignmentProperty, VerticalAlignment.Top);
                    break;

                case 1:
                    this.sampleChart.Series[0].SetValue(ChartTooltip.VerticalAlignmentProperty, VerticalAlignment.Center);
                    break;

                case 2:
                    this.sampleChart.Series[0].SetValue(ChartTooltip.VerticalAlignmentProperty, VerticalAlignment.Bottom);
                    break;
            }
        }

        private void horizOffset_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric(e);
        }
        private void VerizOffset_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            CheckIsNumeric(e);
        }   
        private void CheckIsNumeric(TextCompositionEventArgs e)
        {
            double result;
            if (!(double.TryParse(e.Text, out result) || e.Text == "."))
            {
                e.Handled = true;
            }   
        }         
    }

    public class CompanyDetail
    {
        public Uri ImagePath { get; set; }
        public string CompanyName { get; set; }
        public double YTD { get; set; }
        public int Rank { get; set; }
    }
}
