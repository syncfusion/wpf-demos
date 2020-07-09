#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Threading;
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Shared;

namespace PDFViewerRTL
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
     
        # region Constructor
        public MainWindow()
        {
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ar-AE");
            InitializeComponent();
        }
        # endregion

    }
}
