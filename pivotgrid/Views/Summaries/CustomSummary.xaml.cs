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
    using Syncfusion.PivotAnalysis.Base;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for CustomSummary.xaml
    /// </summary>
    public partial class CustomSummary : DemoControl
    {
        public CustomSummary()
        {
            InitializeComponent();
            this.pivotGrid1.Loaded += PivotGrid1_Loaded;
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            this.customSummaryCheckBox.Click -= customSummaryCheckBox_Click;
            this.displayIfDiscreteValuesEqualSummary.Click -= displayIfDiscreteValuesEqualSummary_Click;
            this.cmbPadString.SelectionChanged -= cmbPadString_SelectionChanged;
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

        private void cmbPadString_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox sourceObject = sender as ComboBox;
            switch (sourceObject.SelectedIndex)
            {
                case 0:
                    this.pivotGrid1.PivotCalculations[1].PadString = "***";
                    break;
                case 1:
                    this.pivotGrid1.PivotCalculations[1].PadString = "999";
                    break;
            }
            if (this.pivotGrid1.InternalGrid != null)
                this.pivotGrid1.InternalGrid.Refresh(true);
        }

        private void displayIfDiscreteValuesEqualSummary_Click(object sender, RoutedEventArgs e)
        {
            cmbPadString.IsEnabled = (sender as CheckBox).IsChecked ?? false;

            if ((sender as CheckBox).IsChecked == true)
            {
                this.pivotGrid1.PivotCalculations.Insert(1, new PivotComputationInfo
                {
                    FieldHeader = "Scrap!",
                    FieldName = "Value3",
                    SummaryType = SummaryType.DisplayIfDiscreteValuesEqual,
                    PadString = cmbPadString.SelectedIndex == 0 ? "***" : "999"
                });
            }
            else
            {
                if (this.pivotGrid1.PivotRows.Any(i => i.FieldMappingName == "Value3"))
                    this.pivotGrid1.PivotRows.Remove(this.pivotGrid1.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Value3"));
                if (this.pivotGrid1.PivotColumns.Any(i => i.FieldMappingName == "Value3"))
                    this.pivotGrid1.PivotColumns.Remove(this.pivotGrid1.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Value3"));
                if (this.pivotGrid1.GroupingBar.Filters.Any(i => i.Name == "Value3"))
                    this.pivotGrid1.GroupingBar.Filters.Remove(this.pivotGrid1.GroupingBar.Filters.FirstOrDefault(x => x.Name == "Value3"));
                if (this.pivotGrid1.PivotCalculations.Any(x => x.FieldName == "Value3"))
                    this.pivotGrid1.PivotCalculations.Remove(this.pivotGrid1.PivotCalculations.FirstOrDefault(x => x.FieldName == "Value3"));
            }
        }

        private void customSummaryCheckBox_Click(object sender, RoutedEventArgs e)
        {
            MyCustomSummaryBase1 myCustomSummaryBase1 = new MyCustomSummaryBase1();
            if ((sender as CheckBox).IsChecked == true)
                this.pivotGrid1.PivotCalculations.Insert(0, new PivotComputationInfo { FieldHeader = "Shipped!", FieldName = "Value1", SummaryType = SummaryType.Custom, Format = "#,##0.00", Summary = myCustomSummaryBase1 });
            else
            {
                if (this.pivotGrid1.PivotRows.Any(i => i.FieldMappingName == "Value1"))
                    this.pivotGrid1.PivotRows.Remove(this.pivotGrid1.PivotRows.FirstOrDefault(x => x.FieldMappingName == "Value1"));
                if (this.pivotGrid1.PivotColumns.Any(i => i.FieldMappingName == "Value1"))
                    this.pivotGrid1.PivotColumns.Remove(this.pivotGrid1.PivotColumns.FirstOrDefault(x => x.FieldMappingName == "Value1"));
                if (this.pivotGrid1.GroupingBar.Filters.Any(i => i.Name == "Value1"))
                    this.pivotGrid1.GroupingBar.Filters.Remove(this.pivotGrid1.GroupingBar.Filters.FirstOrDefault(x => x.Name == "Value1"));
                if (this.pivotGrid1.PivotCalculations.Any(x => x.FieldName == "Value1"))
                    this.pivotGrid1.PivotCalculations.Remove(this.pivotGrid1.PivotCalculations.FirstOrDefault(x => x.FieldName == "Value1"));
            }
        }
    }
}