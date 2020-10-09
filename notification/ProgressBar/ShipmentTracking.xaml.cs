#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.ProgressBar;
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
using System.Windows.Threading;
namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Interaction logic for ShipmentTracking.xaml
    /// </summary>
    public partial class ShipmentTracking : DemoControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShipmentTracking"/> class.
        /// </summary>
        public ShipmentTracking()
        {
            this.InitializeComponent();
        }

        public ShipmentTracking(string themename) : base(themename)
        {
            InitializeComponent();
            StepProgressBar.AnimationDuration = new TimeSpan(0, 0, 0, 0, 500);
        }
    }
}
