#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
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

namespace EmptyPointSupportDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            var viewModel = (this.DataContext as ViewModel);
            if(viewModel != null)
            {
                EmptyPointStyles.ItemsSource = viewModel.EmptyPointStyles;
                EmptyPointStyles.SelectedIndex = 1;

                EmptyPointValues.ItemsSource = viewModel.EmptyPointValues;
                EmptyPointValues.SelectedIndex = 0;
            }
        }

        private void EmptyPointInterior_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            e.Handled = true;
        }
    }

    public class ViewModel
    {
        public List<Model> Data { get; set; }

        public Array EmptyPointStyles
        {
            get
            {
                return Enum.GetValues(typeof(EmptyPointStyle));
            }
        }

        public Array EmptyPointValues
        { 
            get
            { 
                return Enum.GetValues(typeof(EmptyPointValue)); 
            }
        }

        public ViewModel()
        {
            Data = new List<Model>();
            Data.Add(new Model("1984", double.NaN));
            Data.Add(new Model("1985", 2));
            Data.Add(new Model("1986", 1));
            Data.Add(new Model("1987", null));
            Data.Add(new Model("1988", 3));
            Data.Add(new Model("1989", double.NaN));
            Data.Add(new Model("1990", 1));
            Data.Add(new Model("1991", null));
            Data.Add(new Model("1992", 1));
            Data.Add(new Model("1993", 4));

        }
    }

    public class Model
    {
        public string Year { get; set; }

        public double? Count { get; set; }

        public Model(string year, double? count)
        {
            Year = year;
            Count = count;
        }
    }
}
