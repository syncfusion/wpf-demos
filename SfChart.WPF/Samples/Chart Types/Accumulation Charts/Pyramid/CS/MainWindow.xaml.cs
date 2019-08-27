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

namespace PyramidChart
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

    public class Model
    {
        public string Category { get; set; }
        public double Percentage { get; set; }
    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Tax = new List<Model>();


            Tax.Add(new Model() { Category = "Total License", Percentage = 15d });
            Tax.Add(new Model() { Category = "Other", Percentage = 18d });
            Tax.Add(new Model() { Category = "Sales and Gross Receipt", Percentage = 14d });
            Tax.Add(new Model() { Category = "Corporation Net Income", Percentage = 16d });
            Tax.Add(new Model() { Category = "Individual Income", Percentage = 14d });
            Tax.Add(new Model() { Category = "Sales", Percentage = 15d });
        }

        public IList<Model> Tax
        {
            get;
            set;
        }
    }
}
