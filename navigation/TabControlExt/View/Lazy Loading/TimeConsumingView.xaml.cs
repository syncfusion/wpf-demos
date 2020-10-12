#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace syncfusion.navigationdemos.wpf
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
                DemoBrowserViewModel viewModel= null;
                if ((System.Windows.Application.Current.MainWindow.DataContext is DemoBrowserViewModel))
                {
                    viewModel = (System.Windows.Application.Current.MainWindow.DataContext as DemoBrowserViewModel);
                }

                if (viewModel != null)
                {
                    if (this.reload.IsChecked.Value)
                    {
                        viewModel.IsProductDemoBusy = true;

                        Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                        {
                            this.Chart1.DataContext = new TestingViewModel();
                            this.Chart2.DataContext = new ChartViewModel();
                            viewModel.IsProductDemoBusy = false;
                            isloaded = true;
                        }));
                    }
                    else
                    {
                        if (!isloaded)
                        {
                            viewModel.IsProductDemoBusy = true;

                            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                            {
                                this.Chart1.DataContext = new TestingViewModel();
                                this.Chart2.DataContext = new ChartViewModel();
                                viewModel.IsProductDemoBusy = false;
                                isloaded = true;
                            }));
                        }
                    }
                }
            }
        }

    }
}
