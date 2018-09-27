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
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Chart;

namespace PortfolioAnalyzer.CountrySectorChartModule
{
    /// <summary>
    /// Interaction logic for CountrySectorChartView.xaml
    /// </summary>
    public partial class CountrySectorChartView 
    {
        CountrySectorChartViewModel model;
        /// <summary>
        /// Initializes a new instance of the <see cref="CountrySectorChartView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public CountrySectorChartView(CountrySectorChartViewModel viewModel)
        {
            InitializeComponent();
            ApplySeriesInterior();
            model = viewModel;
            this.DataContext = viewModel;

            this.IsVisibleChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
            {
                viewModel.IsVisible = (bool)e.NewValue;
            };            
        }

         
        #region ApplySeriesInterior

        /// <summary>
        /// Setting Pie segments interior
        /// </summary>
        private void ApplySeriesInterior()
        {
            this.exchangeChart.Areas[0].ColorModel.CustomPalette = new Brush[]{
                  //this.Resources["Series7Interior"] as Brush,
                  //this.Resources["Series5Interior"] as Brush,
                  //this.Resources["Series3Interior"] as Brush,
                  //this.Resources["Series1Interior"] as Brush,
                  //this.Resources["Series2Interior"] as Brush,
                  //this.Resources["Series4Interior"] as Brush,
                  //this.Resources["Series6Interior"] as Brush,
                  //this.Resources["Series8Interior"] as Brush,
                  this.Resources["Metro1"] as Brush,
                  this.Resources["Metro2"] as Brush,
                  this.Resources["Metro3"] as Brush,
                  this.Resources["Metro4"] as Brush,
                  this.Resources["Metro5"] as Brush,
                 };
            this.exchangeChart.Areas[0].ColorModel.Palette = ChartColorPalette.Custom;
        
            this.exchangeChart.Areas[1].ColorModel.CustomPalette = new Brush[]{
                  //this.Resources["Series14Interior"] as Brush,
                  //this.Resources["Series12Interior"] as Brush,
                  //this.Resources["Series11Interior"] as Brush,
                  //this.Resources["Series10Interior"] as Brush,
                  //this.Resources["Series13Interior"] as Brush,
                  //this.Resources["Series9Interior"] as Brush,
                  //this.Resources["Series16Interior"] as Brush,
                  //this.Resources["Series18Interior"] as Brush,
                  //this.Resources["Series15Interior"] as Brush,
                  //this.Resources["Series17Interior"] as Brush,
                       this.Resources["Metro3"] as Brush,
                  this.Resources["Metro2"] as Brush,
                  this.Resources["Metro1"] as Brush,
                  this.Resources["Metro5"] as Brush,
                  this.Resources["Metro4"] as Brush,
                 };
            this.exchangeChart.Areas[1].ColorModel.Palette = ChartColorPalette.Custom;
        }
        #endregion

        /// <summary>
        /// Handles the DataChanged event of the Chart. Appropriate templates are assigned based on ApplyAnimation property of the model .
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void series1_DataChanged(object sender, EventArgs e)
        {
            if (model.ApplyAnimation)
            {
                series.Template = this.Resources["PieTemplateWithAnimation"] as DataTemplate;
                series1.Template = this.Resources["PieTemplateWithAnimation"] as DataTemplate;
                Adornments1.LabelTemplate = this.Resources["LabelsTemplate1WithAnimation"] as DataTemplate;
                Adornments2.LabelTemplate = this.Resources["LabelsTemplate2WithAnimation"] as DataTemplate;
            }
            else
            {
                series.Template = this.Resources["PieTemplate"] as DataTemplate;
                series1.Template = this.Resources["PieTemplate"] as DataTemplate;
                Adornments1.LabelTemplate = this.Resources["LabelsTemplate1"] as DataTemplate;
                Adornments2.LabelTemplate = this.Resources["LabelsTemplate2"] as DataTemplate;
            }
        }

        /// <summary>
        /// Handles the LayoutUpdated event of the ChartArea control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void ChartArea_LayoutUpdated(object sender, EventArgs e)
        {
            //this.exchangeChart.Areas[0].ColorModel.Palette = model.Palette;
            //this.exchangeChart.Areas[1].ColorModel.Palette = model.Palette;
        }

    }
   
}
