#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Chart;
using SampleLayout.WPF;
using System.Windows.Threading;
using System.Threading;
using Syncfusion.Windows.Shared;
using System.ComponentModel;

namespace TabControlExtDemo
{
    /// <summary>
    /// Interaction logic for TimeConsumingView.xaml
    /// </summary>
    public partial class TimeConsumingView : UserControl
    {
        private bool isloaded;

        public TimeConsumingView()
        {
            InitializeComponent();
            this.Loaded += new RoutedEventHandler(TimeConsumingView_Loaded);
        }

        void TimeConsumingView_Loaded(object sender, RoutedEventArgs e)
        {
            GetViews();
        }

        private void GetViews()
        {
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                SampleLayoutControl samplecontrol = ((this.Parent as TabItemExt).Parent as TabControlExt).Parent as SampleLayoutControl;

                if (samplecontrol != null)
                {
                    if (this.reload.IsChecked.Value)
                    {
                        samplecontrol.IsBusy = true;

                        Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                        {
                            this.Chart1.DataContext = new TestingViewModel();
                            this.Chart2.DataContext = new ChartViewModel();
                            samplecontrol.IsBusy = false;
                            isloaded = true;
                        }));
                    }
                    else
                    {
                        if (!isloaded)
                        {
                            samplecontrol.IsBusy = true;

                            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                            {
                                this.Chart1.DataContext = new TestingViewModel();
                                this.Chart2.DataContext = new ChartViewModel();
                                samplecontrol.IsBusy = false;
                                isloaded = true;
                            }));
                        }
                    }
                }
                this.series1.StartAnimation();
                this.series2.StartAnimation();
            }
        }



    }
}
