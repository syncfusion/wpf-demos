#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.SfSkinManager;
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

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Interaction logic for TouchStyle.xaml
    /// </summary>
    public partial class TouchStyleDemosView : Window
    {
        public TouchStyleDemosView()
        {
            InitializeComponent();
        }
        public TouchStyleDemosView(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme { ThemeName = themename });
            InitializeComponent();
            this.LayoutUpdated += TouchStyleDemosView_LayoutUpdated;
        }

        private void TouchStyleDemosView_LayoutUpdated(object sender, EventArgs e)
        {
            Theme theme = SfSkinManager.GetTheme(this);
            if (theme != null && theme.ToString() != "Default")
            {
                var Style = this.TryFindResource("TouchWindowStyle");
                if (Style != null)
                {
                    this.Style = (Style)Style;
                }
                this.LayoutUpdated -= TouchStyleDemosView_LayoutUpdated;
            }
        }
    }
}
