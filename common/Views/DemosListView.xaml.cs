#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
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

namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// Interaction logic for DemoView.xaml
    /// </summary>
    public partial class DemosListView : UserControl
    {
        public DemosListView()
        {
            InitializeComponent();
            DemosNavigationService.DemoNavigationService = this.DEMOSFRAME.NavigationService;
            this.DEMOSFRAME.Navigated += DEMOSFRAME_Navigated;
            this.Unloaded += DemosListView_Unloaded;
        }

        private void DemosListView_Unloaded(object sender, RoutedEventArgs e)
        {
            this.DEMOSFRAME.Navigated -= DEMOSFRAME_Navigated;
            this.Unloaded -= DemosListView_Unloaded;
        }

        /// <summary>
        ///  Occurs when the content that is being navigated to has been found
        /// </summary>
        private void DEMOSFRAME_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            this.DEMOSFRAME.RemoveBackEntry();
        }
    }
}
