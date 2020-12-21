#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;
using Syncfusion.SfSkinManager;

namespace syncfusion.stockanalysisdemo.wpf
{
    /// <summary>
    /// Interaction logic for StockAnalysisView.xaml
    /// </summary>
    public partial class StockAnalysisView : UserControl
    {
        public StockAnalysisView()
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "Office2019Colorful" });
            InitializeComponent();
        }
    }
}
