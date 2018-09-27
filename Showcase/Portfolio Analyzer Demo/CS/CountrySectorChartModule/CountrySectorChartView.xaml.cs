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
using Syncfusion.UI.Xaml.Charts;

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
            model = viewModel;
            this.DataContext = viewModel;

            this.IsVisibleChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
            {
                viewModel.IsVisible = (bool)e.NewValue;
            };            
        }
    }
   
}
