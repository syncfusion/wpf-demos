#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Tools.Controls;
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

namespace syncfusion.spreadsheetdemo.wpf
{
    /// <summary>
    /// Interaction logic for SpreadSheetDemo.xaml
    /// </summary>
    public partial class SpreadSheetDemo : RibbonWindow
    {
        public SpreadSheetDemo()
        {
            InitializeComponent();
            this.Unloaded += SpreadSheetDemo_Unloaded;
        }

        private void SpreadSheetDemo_Unloaded(object sender, RoutedEventArgs e)
        {
            if (spreadsheetRibbon != null)
            {
                spreadsheetRibbon.Dispose();
                spreadsheetRibbon = null;
            }

            if (spreadSheetControl != null)
            {
                spreadSheetControl.Dispose();
                spreadSheetControl = null;
            }

            this.Unloaded -= SpreadSheetDemo_Unloaded;
        }
    }
}
