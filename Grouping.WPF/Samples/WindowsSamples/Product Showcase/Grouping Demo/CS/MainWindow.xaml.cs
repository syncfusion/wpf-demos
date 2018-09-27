#region Copyright Syncfusion Inc. 2001 - 2013
// Copyright Syncfusion Inc. 2001 - 2013. All rights reserved.
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Syncfusion.Grouping;
using ISummary = Syncfusion.Collections.BinaryTree.ITreeTableSummary;
using Syncfusion.Windows.Shared;
using System.Globalization;

namespace GroupingWithDataGrid
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ChromelessWindow
    {
        
        public MainWindow()
        {
            InitializeComponent();
            NumberFormatInfo info = new NumberFormatInfo();
            info.NumberGroupSizes = new int[] { 0 };
            nNum.NumberFormatInfo = info;
        }
    }
}
