#region Copyright Syncfusion Inc. 2001 - 2010
// Copyright Syncfusion Inc. 2001 - 2010. All rights reserved.
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
			SkinStorage.SetVisualStyle(this, "Blend");
            this.eventAgg = eventAggregatorr;
            //Subscribe to the skin changed event.
            this.DataContext = viewModel;
           this.eventAgg.GetEvent<SkinChangedEvent>().Subscribe(SkinChangedHandler);
           
        }

        
       /// <summary>
       /// Represents the Skin changed event handler. Selects the appropriate skin based on the parameter passed while publishing the event.
       /// </summary>
       /// <param name="SkinName">The Skin Name</param>
        void SkinChangedHandler(string SkinName)
        {
            switch (SkinName)
            {
                case "Blue":
                    SkinStorage.SetVisualStyle(this, "Office2007Blue");
                    break;
                case "Black":
                    SkinStorage.SetVisualStyle(this, "Office2007Black");
                    break;
                case "Silver":
                    SkinStorage.SetVisualStyle(this, "Office2007Silver");
                    break;
                case "Blend":
                    SkinStorage.SetVisualStyle(this, "Blend");
                    break;
            }
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
    }
}
