#region Copyright Syncfusion Inc. 2001 - 2024
// Copyright Syncfusion Inc. 2001 - 2024. All rights reserved.
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

namespace syncfusion.patientmonitor.wpf
{
    public sealed partial class HistoryDetailsView : UserControl
    {
        public HistoryDetailsView()
        {
            this.InitializeComponent();
            this.Unloaded += HistoryDetailsView_Unloaded;
        }

        private void HistoryDetailsView_Unloaded(object sender, RoutedEventArgs e)
        {
            if(this.HistoryDetails != null)
            {
                this.HistoryDetails.Dispose();
                this.HistoryDetails = null;
            }

            this.Unloaded -= HistoryDetailsView_Unloaded;
        }
    }
}
