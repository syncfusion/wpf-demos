#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using Syncfusion.UI.Xaml.CellGrid;
using CellTemplate_WPF.Class;
using Syncfusion.UI.Xaml.Spreadsheet;
using Syncfusion.XlsIO.Implementation;
using Syncfusion.UI.Xaml.Spreadsheet.Commands;
using Syncfusion.Windows.Shared;

namespace CellTemplate_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ChromelessWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            this.spreadsheet.Commands.FileClose.Execute(null);
            if (Application.Current.ShutdownMode != ShutdownMode.OnExplicitShutdown)
                e.Cancel = true;
        }
    }
}
