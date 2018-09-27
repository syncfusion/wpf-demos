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
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Grid;

namespace ExpenseAnalysisDemo
{
    /// <summary>
    /// Interaction logic for GridView.xaml
    /// </summary>
    public partial class GridView : UserControl
    {
        public GridView()
        {
            InitializeComponent();
            this.Loaded += GridView_Loaded;
            this.Unloaded += GridView_Unloaded;
        }

        void GridView_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Loaded -= GridView_Loaded;
            this.Unloaded -= GridView_Unloaded;
            if (this.DataContext is ViewModel)
                (this.DataContext as ViewModel).PropertyChanged -= GridView_PropertyChanged;
        }

        void GridView_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is ViewModel)
                (this.DataContext as ViewModel).PropertyChanged += GridView_PropertyChanged;
        }

        void GridView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals("Expenses"))
                this.sfDataPager.MoveToFirstPage();
        }
    }
}
