#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Windows;
using System.Windows.Controls;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace PatientDetailsDemo
{
    public sealed partial class HistoryDetailsView : UserControl
    {
        public HistoryDetailsView()
        {
            this.InitializeComponent();
        }

        private void GoBack(object sender, RoutedEventArgs e)
        {
        }

        private void NavigateToCurrentView(object sender, RoutedEventArgs e)
        {
        }

        //protected override void OnNavigatedTo(NavigationEventArgs e)
        //{
        //    this.DataContext = e.Parameter;
        //    base.OnNavigatedTo(e);
        //}

    }
}
