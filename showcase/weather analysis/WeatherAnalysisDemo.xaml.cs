#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;
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

namespace syncfusion.weatheranalysis.wpf
{
    /// <summary>
    /// Interaction logic for WeatherAnalysisDemo.xaml
    /// </summary>
    public partial class WeatherAnalysisDemo : ChromelessWindow
    {
        public WeatherAnalysisDemo()
        {
            InitializeComponent();
        }

        protected override void OnClosed(EventArgs e)
        {
            if(this.comboBoxAdv1 != null)
            {
                this.comboBoxAdv1.Dispose();
                this.comboBoxAdv1 = null;
            }

            base.OnClosed(e);
        }
    }
}
