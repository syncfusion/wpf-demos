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

namespace LineSeriesDemo
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
        public double Server1
        {
            get;
            set;
        }

        public double Server2
        {
            get;
            set;
        }

        public double ServerLoad
        {
            get;
            set;
        }

    }

    public class ViewModel
    {
        public ViewModel()
        {
            this.Performance = new ObservableCollection<Model>();

            Performance.Add(new Model() { ServerLoad = 2005, Server1 = 13, Server2 = 10 });
            Performance.Add(new Model() { ServerLoad = 2006, Server1 = 30, Server2 = 14 });
            Performance.Add(new Model() { ServerLoad = 2007, Server1 = 33, Server2 = 19 });
            Performance.Add(new Model() { ServerLoad = 2008, Server1 = 15, Server2 = 10 });
            Performance.Add(new Model() { ServerLoad = 2009, Server1 = 25, Server2 = 15 });
            Performance.Add(new Model() { ServerLoad = 2010, Server1 = 20, Server2 = 13 });
            Performance.Add(new Model() { ServerLoad = 2011, Server1 = 25, Server2 = 17 });
            Performance.Add(new Model() { ServerLoad = 2012, Server1 = 20, Server2 = 13 });
            Performance.Add(new Model() { ServerLoad = 2013, Server1 = 23, Server2 = 13 });
        }
        public ObservableCollection<Model> Performance
        {
            get;
            set;
        }
    }
}
