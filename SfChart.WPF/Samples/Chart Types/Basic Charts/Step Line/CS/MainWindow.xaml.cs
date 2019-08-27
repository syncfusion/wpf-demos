#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace StepLineChart
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

    public class Intensity
    {
        public DateTime Year { get; set; }
        public double jp { get; set; }
        public double kp { get; set; }
        public double uk { get; set; }
    }

    public class StepLineChartViewModel
    {
        public StepLineChartViewModel()
        {
            this.Intensity = new ObservableCollection<Intensity>();
            DateTime yr = new DateTime(2006, 5, 1);
            Intensity.Add(new Intensity() { Year = yr.AddYears(0), uk = 519, jp = 378, kp = 463 });
            Intensity.Add(new Intensity() { Year = yr.AddYears(1), uk = 508, jp = 416, kp = 449 });
            Intensity.Add(new Intensity() { Year = yr.AddYears(2), uk = 502, jp = 404, kp = 458 });
            Intensity.Add(new Intensity() { Year = yr.AddYears(3), uk = 495, jp = 390, kp = 450 });
            Intensity.Add(new Intensity() { Year = yr.AddYears(4), uk = 485, jp = 376, kp = 425 });
            Intensity.Add(new Intensity() { Year = yr.AddYears(5), uk = 470, jp = 365, kp = 430 });

        }

        public ObservableCollection<Intensity> Intensity
        {
            get;
            set;
        }
    }
}
