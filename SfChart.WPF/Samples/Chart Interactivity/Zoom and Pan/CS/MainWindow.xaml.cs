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

namespace ZoomPanBehavior
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

    public class LoadDetail
    {
        public DateTime Date { get; set; }
        public double Load { get; set; }
    }

    public class LoadDetailViewModel
    {
        public LoadDetailViewModel()
        {
            GenerateData();
        }

        private void GenerateData()
        {
            LoadDetails = new ObservableCollection<LoadDetail>();
            var randam = new Random();
            var value = 70d;
            var date = new DateTime(2015, 4, 1);

            for (int i = 1; i < 1000; i++)
            {
                if(randam.NextDouble() > 0.5)
                {
                    value += randam.NextDouble();
                }
                else
                {
                    value -= randam.NextDouble();
                }

                var commidity = new LoadDetail() { Load = value, Date = date.AddDays(i) };
                LoadDetails.Add(commidity);
            }
        }

        public ObservableCollection<LoadDetail> LoadDetails { get; set; }
    }
}
