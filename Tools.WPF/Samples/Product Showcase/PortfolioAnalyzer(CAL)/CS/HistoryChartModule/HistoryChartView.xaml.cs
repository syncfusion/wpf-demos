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
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using System.ComponentModel;
using Syncfusion.Windows.Chart;
using PortfolioAnalyzer.Model;
using System.Globalization;
using Syncfusion.Windows.Shared;
using System.Threading;

namespace PortfolioAnalyzer.HistoryChartModule
{
    /// <summary>
    /// Interaction logic for HistoryChartView.xaml
    /// </summary>
    public partial class HistoryChartView
    {

        HistoryChartViewModel model;

        /// <summary>
        /// Initializes a new instance of the <see cref="HistoryChartView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public HistoryChartView(HistoryChartViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;
            model = viewModel;

        }

        #region Events
        private void series2_DataChanged(object sender, EventArgs e)
        {
            if (model.ApplyAnimation)
            {
                series2.Template = this.Resources["ColumnTemplateWithAnimation"] as DataTemplate;
            }
            else
            {
                series2.Template = this.Resources["ColumnTemplate"] as DataTemplate;
            }
        }

        #endregion        
    }



}
