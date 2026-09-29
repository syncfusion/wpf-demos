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

    public partial class SummaryDisplayOption : DemoControl
    {
        public SummaryDisplayOption()
        {
            InitializeComponent();
            this.pivotGrid1.Loaded += PivotGrid1_Loaded;
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources   
            this.DisplayOptionBox.SelectionChanged -= DisplayOptionBox_SelectionChanged;
            this.DisplayOptionBox1.SelectionChanged -= DisplayOptionBox1_SelectionChanged;
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

        private void DisplayOptionBox1_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string calcName = "";
            int index = (sender as ComboBox).Name == "DisplayOptionBox" ? 1 : 0;
            calcName = index == 0 ? "Amount" : "Quantity";
            index = this.pivotGrid1.PivotCalculations.IndexOf(this.pivotGrid1.PivotCalculations.FirstOrDefault(x => x.FieldName == calcName));
            switch ((sender as ComboBox).SelectedItem.ToString())
            {
                case "None":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.None;
                    break;
                case "All":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.All;
                    break;
                case "Calculations":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.Calculations;
                    break;
                case "Summaries":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.Summary;
                    break;
                case "GrandTotals":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.GrandTotals;
                    break;
                case "Summaries and Calculations":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.Calculations | DisplayOption.Summary;
                    break;
                case "Summaries and GrandTotals":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.Summary | DisplayOption.GrandTotals;
                    break;
                case "Calculations and GrandTotals":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.Calculations | DisplayOption.GrandTotals;
                    break;
            }
            this.pivotGrid1.InternalGrid.Refresh(true);
        }

        private void DisplayOptionBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            string calcName = "";
            int index = (sender as ComboBox).Name == "DisplayOptionBox" ? 1 : 0;
            calcName = index == 0 ? "Amount" : "Quantity";
            index = this.pivotGrid1.PivotCalculations.IndexOf(this.pivotGrid1.PivotCalculations.FirstOrDefault(x => x.FieldName == calcName));
            switch ((sender as ComboBox).SelectedItem.ToString())
            {
                case "None":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.None;
                    break;
                case "All":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.All;
                    break;
                case "Calculations":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.Calculations;
                    break;
                case "Summaries":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.Summary;
                    break;
                case "GrandTotals":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.GrandTotals;
                    break;
                case "Summaries and Calculations":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.Calculations | DisplayOption.Summary;
                    break;
                case "Summaries and GrandTotals":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.Summary | DisplayOption.GrandTotals;
                    break;
                case "Calculations and GrandTotals":
                    this.pivotGrid1.PivotCalculations[index].DisplayOption = DisplayOption.Calculations | DisplayOption.GrandTotals;
                    break;
            }
            this.pivotGrid1.InternalGrid.Refresh(true);
        }
    }
}