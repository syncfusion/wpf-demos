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
    /// Interaction logic for ZoomPanBehavior.xaml
    /// </summary>
    public partial class ZoomPanBehavior : DemoControl
    {
        public ZoomPanBehavior()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            ZoomBehaviorChart.Dispose();
            base.Dispose(disposing);
        }

        private void DateTimeAxis_LabelCreated(object sender, LabelCreatedEventArgs e)
        {
            DateTimeAxisLabel dateTimeLabel = e.AxisLabel as DateTimeAxisLabel;
            bool isTransition = dateTimeLabel.IsTransition;
            switch (dateTimeLabel.IntervalType)
            {
                case DateTimeIntervalType.Days:
                    {
                        if (isTransition)
                            e.AxisLabel.LabelContent = dateTimeLabel.Position.FromOADate().ToString("MMM-dd");
                        else
                            e.AxisLabel.LabelContent = dateTimeLabel.Position.FromOADate().ToString("dd");
                    }
                    break;

                case DateTimeIntervalType.Hours:
                    {
                        if (isTransition)
                            e.AxisLabel.LabelContent =
                            dateTimeLabel.Position.FromOADate().ToString("dd.HH:mm");

                        else
                            e.AxisLabel.LabelContent =
                            dateTimeLabel.Position.FromOADate().ToString("HH");
                    }
                    break;
            }
        }
    }
}
