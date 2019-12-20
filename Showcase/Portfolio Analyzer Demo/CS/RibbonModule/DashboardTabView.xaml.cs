#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows.Controls;
using Microsoft.Practices.Composite.Regions;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Composite.Modularity;
using System.Windows.Input;
using Microsoft.Practices.Composite.Events;
using PortfolioAnalyzer.Infrastructure;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
using System.Windows;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Threading;
using System;
using Syncfusion.Windows.Controls;

namespace PortfolioAnalyzer.RibbonModule
{
    /// <summary>
    /// Interaction logic for EmployeesView.xaml
    /// </summary>
    public partial class DashboardTabView
    {
        #region Members
        IEventAggregator eventAggregator;
        private readonly IModuleManager moduleManager;
        private readonly IRegionManager regionManager;
        private readonly IUnityContainer unityContainer;
       

        #endregion

        /// <summary>
        /// Initializes a new instance of the <see cref="DashboardTabView"/> class.
        /// </summary>
        /// <param name="eventAgg">The event agg.</param>
        /// <param name="moduleManager">The module manager.</param>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="unityContainer">The unity container.</param>
        /// <param name="viewModel">The view model.</param>
        public DashboardTabView(IEventAggregator eventAgg, IModuleManager moduleManager, IRegionManager regionManager, IUnityContainer unityContainer, DashBoardTabViewModel viewModel)
        {
            this.eventAggregator = eventAgg;
            this.moduleManager = moduleManager;
            this.regionManager = regionManager;
            this.unityContainer = unityContainer;
            InitializeComponent();
            this.DataContext = viewModel;
        }

      
        #region Event Handlers

        /// <summary>
        /// Gets the parent ribbon Window
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <returns></returns>
        private FrameworkElement GetParent(FrameworkElement parent)
        {
            while (parent != null)
            {
                parent = (FrameworkElement)parent.Parent;

                if (parent is SfChromelessWindow)
                {
                    break;
                }
            }
            return parent;
        }     
        
        /// <summary>
        /// Handles the custom color setting
        /// </summary>
        /// <param name="d">The d.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        //private void colorBox_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        //{
        //    FrameworkElement parent = d as FrameworkElement;
        //    parent = GetParent(parent);
        //    SolidColorBrush customcolor = new SolidColorBrush(colorBox.Color);
        //    SkinManager.SetActiveColorScheme(parent, customcolor);
        //}
        #endregion
    }
}
