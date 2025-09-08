#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using System.Windows;
    using System.Windows.Controls;

    public partial class HyperlinkCell : DemoControl
    {
        public HyperlinkCell()
        {
            InitializeComponent();
            this.pivotGrid1.Loaded += PivotGrid1_Loaded;
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            this.Clear.Click -= Clear_Click;
            this.ColumnHeaderCellBox.Click -= ColumnHeaderCellBox_Click;
            this.RowHeaderCellBox.Click -= RowHeaderCellBox_Click;
            this.SummaryHeaderSBox.Click -= SummaryHeaderSBox_Click;
            this.SummaryCellBox.Click -= SummaryCellBox_Click;
            this.ValueCellBox.Click -= ValueCellBox_Click;
            if (this.pivotGrid1 != null)
            {
                this.pivotGrid1.Loaded -= PivotGrid1_Loaded;
                this.pivotGrid1.Dispose();
                this.pivotGrid1 = null;
            }
            base.Dispose(disposing);
        }

        private void PivotGrid1_Loaded(object sender, RoutedEventArgs e)
        {
            this.SchemaDesigner.PivotControl = this.pivotGrid1;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {            
            this.LstBoxHyperlinkCellClickEventArgs.Items.Clear();
            this.LstBoxHyperlinkCellClickEventArgs.ItemsSource = null;
        }

        private void ColumnHeaderCellBox_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.ColumnHeaderCellStyle.IsHyperlinkCell = (sender as CheckBox).IsChecked ?? false;
        }

        private void RowHeaderCellBox_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.RowHeaderCellStyle.IsHyperlinkCell = (sender as CheckBox).IsChecked ?? false;
        }

        private void SummaryHeaderSBox_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.SummaryHeaderStyle.IsHyperlinkCell = (sender as CheckBox).IsChecked ?? false;
        }

        private void SummaryCellBox_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.SummaryCellStyle.IsHyperlinkCell = (sender as CheckBox).IsChecked ?? false;
        }

        private void ValueCellBox_Click(object sender, RoutedEventArgs e)
        {
            this.pivotGrid1.ValueCellStyle.IsHyperlinkCell = (sender as CheckBox).IsChecked ?? false;

        }
    }
}