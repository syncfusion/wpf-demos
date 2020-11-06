#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using syncfusion.demoscommon.wpf;

namespace syncfusion.chartdemos.wpf
{
    /// <summary>
    /// Interaction logic for CustomSeriesDemo.xaml
    /// </summary>
    public partial class CustomSeriesDemo : DemoControl
    {
        public CustomSeriesDemo()
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }

    
    internal static class ChartDictionary
    {
        internal static ResourceDictionary GenericDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/syncfusion.chartdemos.wpf;component/Resources/CustomTemplate.xaml", UriKind.RelativeOrAbsolute)
        };
    }
}
