#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.SampleLayout;
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

namespace FastHiloOpenCloseChart
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : SampleLayoutWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }

    public class TestingValues
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public class TestingValuesCollection
    {
        public TestingValuesCollection()
        {
            this.TestingModel = new ObservableCollection<TestingValues>();
            Random rd = new Random();

            for (int i = 0; i < 100; i++)
            {
                this.TestingModel.Add(new TestingValues() { X = i + 1000,
                    Y = rd.Next(40, 50), 
                    Y1 = rd.Next(0, 10), 
                    Y2 = rd.Next(10, 40), 
                    Y3 = rd.Next(20, 40) });               
            }
        }

        public ObservableCollection<TestingValues> TestingModel { get; set; }
    }
}
