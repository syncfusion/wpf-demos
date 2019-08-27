#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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

namespace Virtulization
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AddData();
            this.DataContext = dataFlat;
        }       

        Random r = new Random();
        private ObservableCollection<DataModel> dataFlat = new ObservableCollection<DataModel>();

        private void AddData()
        {
            for (int i = 0; i < 1000; i++)
            {
                dataFlat.Add(new DataModel(i.ToString(), r.Next(0,100), r.Next(0,100), r.Next(0,100), r.Next(0,100), r.Next(0,100)));
            }
        }
    }
}
