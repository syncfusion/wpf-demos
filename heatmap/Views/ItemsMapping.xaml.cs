#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.HeatMap;
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

namespace syncfusion.heatmapdemos.wpf
{
    /// <summary>
    /// Interaction logic for ItemsMappingDemo.xaml
    /// </summary>
    public partial class ItemsMappingDemo : DemoControl
    {
        public ItemsMappingDemo()
        {
            InitializeComponent();
        }
        public ItemsMappingDemo(string themename) : base(themename)
        {
            InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if(this.DataContext != null)
            {
                this.DataContext = null;
            }
            if (Legend != null)
            {
                if (Legend.ColorMappingCollection != null)
                {
                    (Legend.ColorMappingCollection as ColorMappingCollection).Clear();
                    Legend.ColorMappingCollection = null;
                }
                Legend = null;
            }
            if (this.heatmap != null)
            {
                if (heatmap.ItemsMapping != null)
                {
                    heatmap.ItemsMapping = null;
                }
                if (heatmap.ItemsSource != null)
                {
                    heatmap.ItemsSource = null;
                }
                if (heatmap.ColorMappingCollection != null)
                {
                    (heatmap.ColorMappingCollection as ColorMappingCollection).Clear();
                    heatmap.ColorMappingCollection = null;
                }            
            }
            base.Dispose(disposing);
        }
    }  
}
