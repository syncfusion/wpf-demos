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
using Syncfusion.Windows.Controls.Grid;

namespace PortfolioAnalyzer.PortfolioGridModule
{
    /// <summary>
    /// Interaction logic for PortfolioGridView.xaml
    /// </summary>
    public partial class PortfolioGridView 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PortfolioGridView"/> class.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        public PortfolioGridView(PortfolioGridViewModel viewModel)
        {
            InitializeComponent();
            this.DataContext = viewModel;

            this.IsVisibleChanged += delegate(object sender, DependencyPropertyChangedEventArgs e)
            {
                viewModel.IsVisible = (bool)e.NewValue;
            };        
        }        
    }
}