#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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
using Syncfusion.Windows.Tools;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Events;
using System.Collections.ObjectModel;
using System.Timers;
using Microsoft.Practices.Composite.Presentation.Commands;
using Microsoft.Practices.Composite.Modularity;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using PortfolioAnalyzer.Infrastructure;
using PortfolioAnalyzer.RibbonModule;
using Syncfusion.Windows.Controls;

namespace PortfolioAnalyzer
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Shell : RibbonWindow
    {
        /// <summary>
        /// The IEventAggregator object. 
        /// </summary>
        IEventAggregator eventAgg;
        public Shell(IEventAggregator eventAggregatorr,AppMenuViewModel viewModel)
        {
            InitializeComponent();
        //    SkinStorage.SetVisualStyle(this, "Metro");
            this.eventAgg = eventAggregatorr;
            //Subscribe to the skin changed event.
            this.DataContext = viewModel;
           
        }

        /// <summary>
        /// Represnts the DockingManager State changed event handler
        /// </summary>
        /// <param name="sender">The child control</param>
        /// <param name="e">DockStateEventArgs</param>
        private void DockingManager_DockStateChanged(FrameworkElement sender, DockStateEventArgs e)
        {
            if (e.NewState != DockState.Hidden)
                (sender as Control).Tag = e.NewState;
        }

        private void BackStageCommandButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MyRibbon.HideBackStage();
            
        }
    }
}
