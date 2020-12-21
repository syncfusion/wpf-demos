#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.cardashboard.wpf.ViewModel;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Controls;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Threading;

namespace syncfusion.cardashboard.wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class CarDashBoardDemo : ChromelessWindow
    {
        public CarDashBoardDemo()
        {
            this.InitializeComponent();
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "MaterialDark" });
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (this.SpeedGauge != null)
            {
                this.SpeedGauge.Dispose();
                this.SpeedGauge = null;
            }

            if (this.RpmGauge != null)
            {
                this.RpmGauge.Dispose();
                this.RpmGauge = null;
            }

            if (this.FuelGauge != null)
            {
                this.FuelGauge.Dispose();
                this.FuelGauge = null;
            }

            if (this.TempGauge != null)
            {
                this.TempGauge.Dispose();
                this.TempGauge = null;
            }

            if (this.TorqueGauge != null)
            {
                this.TorqueGauge.Dispose();
                this.TorqueGauge = null;
            }
            base.OnClosing(e);
        }
    }
}

