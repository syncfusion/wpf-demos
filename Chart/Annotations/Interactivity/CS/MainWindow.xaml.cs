#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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

namespace AnnotationInteractionDemo
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

    public class ViewModel
    {
        public ViewModel()
        {
            this.power = new ObservableCollection<Entertainment>();
            DateTime yr = new DateTime(2002, 5, 1);

            power.Add(new Entertainment() { Year = yr.AddYears(1), Population = 36});
            power.Add(new Entertainment() { Year = yr.AddYears(2), Population = 32});
            power.Add(new Entertainment() { Year = yr.AddYears(3), Population = 34});
            power.Add(new Entertainment() { Year = yr.AddYears(4), Population = 41});
            power.Add(new Entertainment() { Year = yr.AddYears(5), Population = 42});
            power.Add(new Entertainment() { Year = yr.AddYears(6), Population = 48});
            power.Add(new Entertainment() { Year = yr.AddYears(7), Population = 45});
       }
        public ObservableCollection<Entertainment> power
        {
            get;
            set;
        }
    }

    public class Entertainment
    {
        public DateTime Year { get; set; }     
        public double Population { get; set; }
    }
}
