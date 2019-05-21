#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
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

namespace StackedGroup
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

    public class StackingGroupViewModel
    {
        public StackingGroupViewModel()
        {
            this.AnnualDetails = new ObservableCollection<ProductDetails>();
            AnnualDetails.Add(new ProductDetails() { Year = "2009", Quarter1 = 34, Quarter2 = 31, Quarter3 = 29, Quarter4 = 30 });
            AnnualDetails.Add(new ProductDetails() { Year = "2010", Quarter1 = 24, Quarter2 = 28, Quarter3 = 32, Quarter4 = 33 });
            AnnualDetails.Add(new ProductDetails() { Year = "2011", Quarter1 = 20, Quarter2 = 25, Quarter3 = 25, Quarter4 = 26 });
            AnnualDetails.Add(new ProductDetails() { Year = "2012", Quarter1 = 19, Quarter2 = 21, Quarter3 = 23, Quarter4 = 26 });
            AnnualDetails.Add(new ProductDetails() { Year = "2013", Quarter1 = 19, Quarter2 = 15, Quarter3 = 17, Quarter4 = 21 });
        }

        public ObservableCollection<ProductDetails> AnnualDetails { get; set; }
    }

    public class ProductDetails
    {

        public string Year { get; set; }

        public double Quarter1 { get; set; }

        public double Quarter2 { get; set; }

        public double Quarter3 { get; set; }

        public double Quarter4 { get; set; }

    }
}
