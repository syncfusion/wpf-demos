#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace DrillThrough
{
    using System.Windows;
    using PivotEngineImpt.ViewModel;
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new ViewModel();
            this.pivotGridControl1.ValueCellStyle.IsHyperlinkCell = true;
            this.pivotGridControl1.SummaryCellStyle.IsHyperlinkCell = true;

        }
  }
}
