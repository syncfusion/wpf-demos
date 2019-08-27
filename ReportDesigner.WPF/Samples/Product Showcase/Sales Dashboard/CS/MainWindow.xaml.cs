#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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

namespace Company_Sales_2008
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {
        public MainWindow()
        {
            //SkinStorage.SetEnableOptimization(this, true);
            InitializeComponent();
            SkinStorage.SetVisualStyle(this, "Office2013");
            this.Title = "Syncfusion Essential Report Designer";
            this.Loaded += MainWindow_Loaded;
            this.Closing += new System.ComponentModel.CancelEventHandler(MainWindow_Closing);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.ReportDesignerControl.EnableMDIDesigner = false;
            string path = @"../../../ReportTemplate/Sales Dashboard.rdl";
            this.ReportDesignerControl.OpenReport(path);

            WindowTitleBarButton HelpButton = null;
            Syncfusion.Windows.Tools.Controls.TitleBar _titlebar = VisualUtils.FindDescendant(this as RibbonWindow, typeof(Syncfusion.Windows.Tools.Controls.TitleBar)) as Syncfusion.Windows.Tools.Controls.TitleBar;
            if (_titlebar != null)
                HelpButton = _titlebar.Template.FindName("HelpButton", _titlebar) as WindowTitleBarButton;

            if (HelpButton != null)
                HelpButton.Click += new RoutedEventHandler(HelpButton_Click);
        }

        private void HelpButton_Click(object sender, RoutedEventArgs e)
        {
            System.Diagnostics.Process.Start("http://help.syncfusion.com/wpf/reportdesigner/getting-started");
        }

        void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            bool IsCanClose = this.ReportDesignerControl.PreCloseApplication();

            if (IsCanClose == false)
            {
                e.Cancel = true;
            }
        }
    }
}
