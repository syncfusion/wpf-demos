#region Copyright Syncfusion Inc. 2001-2021
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;
using Syncfusion.Windows.Tools.Controls;
using Microsoft.Practices.Composite.Events;

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Shell : RibbonWindow
    {
        public Shell(IEventAggregator eventAggregatorr,AppMenuViewModel viewModel)
        {
            InitializeComponent();
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
