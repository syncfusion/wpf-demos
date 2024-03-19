#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for BubbleChartDemo.xaml
    /// </summary>
    public partial class DefaultBubble : DemoControl
    {
        public DefaultBubble()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            BubbleChart.Dispose();
            base.Dispose(disposing);
        }

        private void LabelCreated(object sender, LabelCreatedEventArgs e)
        {
            double position = e.AxisLabel.Position;
            if (position >= 1000 && position <= 999999)
            {
                string text = (position / 1000).ToString("C0");
                e.AxisLabel.LabelContent = $"{text}K";
            }
            else
            {
                e.AxisLabel.LabelContent = $"{position:C0}K";
            }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start(new ProcessStartInfo("https://ourworldindata.org/grapher/literacy-rate-vs-gdp-per-capita?zoomToSelection=true&time=2018&country=IND~IDN~ITA~CHN~MYS~ROU~RUS~MEX~UGA~NGA~DZA~GRC~JOR~COL~MNG~BRA~NPL~SDN") { UseShellExecute = true });
        }
    }
}
