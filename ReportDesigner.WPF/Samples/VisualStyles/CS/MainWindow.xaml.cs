#region Copyright Syncfusion Inc. 2001-2015.
// Copyright Syncfusion Inc. 2001-2015. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
using System.Windows.Shapes;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Reports.Designer;
using Syncfusion.Windows.Shared;
using System.IO;
using Syncfusion.SfSkinManager;

namespace Company_Sales_2008
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, VisualStyles.Metro);
            this.Title = "Syncfusion Essential Report Designer";
            this.Loaded += MainWindow_Loaded;
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            string path = @"../../../ReportTemplate/Sales Dashboard.rdl";
            this.ReportDesignerControl.OpenReport(path);
            this.ReportDesignerControl.ShowProperties = false;
        }

        private void ComboBoxAdv_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            ComboBoxItemAdv item;
            WindowCollection windows = Application.Current.Windows;
            if (windows.Count > 0)
            {
                Window samplewindow = windows[0];
                ComboBoxAdv combo = sender as ComboBoxAdv;
                if (combo != null)
                {
                    if (combo.SelectedItem != null)
                    {
                        item = combo.SelectedItem as ComboBoxItemAdv;
                        if (this.ReportDesignerControl != null)
                        {
                            Syncfusion.SfSkinManager.SfSkinManager.SetVisualStyle(this, (VisualStyles)Enum.Parse(typeof(VisualStyles), item.Content.ToString()));
                            this.ReportDesignerControl.VisualStyle = Syncfusion.SfSkinManager.SfSkinManager.GetVisualStyle(this).ToString();
                        }
                    }

                }
            }
        }
    }
}
