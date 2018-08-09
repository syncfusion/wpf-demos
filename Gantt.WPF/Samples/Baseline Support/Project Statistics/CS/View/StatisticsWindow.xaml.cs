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
using Syncfusion.Windows.Controls.Gantt;
using Syncfusion.Windows.Controls.Grid;
using System.Threading;

namespace ProjectStatistics
{
    /// <summary>
    /// Interaction logic for StatisticsWindow.xaml
    /// </summary>
    public partial class StatisticsWindow 
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticsWindow"/> class.
        /// </summary>
        public StatisticsWindow(StatisticsViewModel view)
        {
            InitializeComponent();
            this.DataContext = view;
        }
    }   
}

