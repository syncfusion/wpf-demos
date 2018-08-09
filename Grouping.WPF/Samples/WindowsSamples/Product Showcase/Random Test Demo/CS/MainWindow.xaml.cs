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
using Syncfusion.Grouping;
using Syncfusion.Windows.Shared;
using System.Globalization;

namespace RandomTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {

        public MainWindow()
        {
            InitializeComponent();
            NumberFormatInfo info = new NumberFormatInfo();
            info.NumberGroupSizes = new int[] { 0 };
            refreshrate.NumberFormatInfo = info;
            timeInTest.NumberFormatInfo = info;
        }
    }
}
