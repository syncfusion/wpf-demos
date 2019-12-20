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
using System.ComponentModel;
using System.Globalization;
using System.IO;
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

namespace Annotation
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
            DataModel = new ObservableCollection<Model>();
            DataModel.Add(new Model() { Over = 1, Runs = 4 });
            DataModel.Add(new Model() { Over = 2, Runs = 8, PlayerName = "CL White", Score = "10 (6)" });
            DataModel.Add(new Model() { Over = 3, Runs = 12 });
            DataModel.Add(new Model() { Over = 4, Runs = 3 });
            DataModel.Add(new Model() { Over = 5, Runs = 10 });
            DataModel.Add(new Model() { Over = 6, Runs = 6 });
            DataModel.Add(new Model() { Over = 7, Runs = 11,PlayerName="AJ Finch",Score="30 (24)" });
            DataModel.Add(new Model() { Over = 8, Runs = 5 });
            DataModel.Add(new Model() { Over = 9, Runs = 4 });
            DataModel.Add(new Model() { Over = 10, Runs = 12});
            DataModel.Add(new Model() { Over = 11, Runs = 8 });
            DataModel.Add(new Model() { Over = 12, Runs = 14, PlayerName = "GJ Smith", Score = "25 (14)" });
            DataModel.Add(new Model() { Over = 13, Runs = 12 });
            DataModel.Add(new Model() { Over = 14, Runs = 15 });
            DataModel.Add(new Model() { Over = 15, Runs = 10 });
            DataModel.Add(new Model() { Over = 16, Runs = 14 });
            DataModel.Add(new Model() { Over = 17, Runs = 16 });
            DataModel.Add(new Model() { Over = 18, Runs = 9 });
            DataModel.Add(new Model() { Over = 19, Runs = 10 ,PlayerName="GJ Bailey",Score="78 (40)"});
            DataModel.Add(new Model() { Over = 20, Runs = 18 });
        }
        public ObservableCollection<Model> DataModel
        {
            get;
            set;
        }
    }

    public class Model
    {
        public double Over
        { 
            get;
            set; 
        }
        public double Runs
        {
            get; 
            set;
        }
        public string PlayerName
        {
            get;
            set;
        }
        public string Score
        {
            get;
            set;
        }
    }
}
