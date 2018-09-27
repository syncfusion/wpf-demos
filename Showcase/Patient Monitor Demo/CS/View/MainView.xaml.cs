using System;
using System.Collections.Generic;
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
using System.Windows.Threading;
using Syncfusion.UI.Xaml.Charts;

namespace PatientDetailsDemo
{
    /// <summary>
    /// Interaction logic for HistoryDetailsView.xaml
    /// </summary>
    public partial class MainView : UserControl
    {
     
        
        public MainView()
        {
            InitializeComponent();
           
        }

        private void syncgrid_SelectionChanged(object sender, Syncfusion.UI.Xaml.Grid.GridSelectionChangedEventArgs e)
        {
            if (currentDetailsDemo != null)
            {
                var curr = (currentDetailsDemo.DataContext as PatientDetails);
                currentDetailsDemo.SwapDataContext();
            }

           
        }

       
    }
}
