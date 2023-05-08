#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using syncfusion.demoscommon.wpf;
    using Syncfusion.PivotAnalysis.Base;
    using Syncfusion.Windows.Controls.PivotGrid;
    using System.Linq;
    using System.Windows;
    using System.Windows.Controls;

    public partial class Filtering : DemoControl
    {
        public Filtering()
        {
            InitializeComponent();
            this.pivotGrid1.Loaded += PivotGrid1_Loaded;
        }

        protected override void Dispose(bool disposing)
        {
            // Release all resources
            this.button1.Click -= button1_Click;
            this.button2.Click -= button2_Click;
            this.button3.Click -= button3_Click;
            this.button4.Click -= button4_Click;
            this.button5.Click -= button5_Click;
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

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).IsEnabled)
               this.pivotGrid1.Filters.Add(new FilterExpression("Product"));
           this.pivotGrid1.InvalidateCells();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).IsEnabled)
                this.pivotGrid1.Filters.Remove(this.pivotGrid1.Filters.FirstOrDefault(i => i.DimensionName == "Product"));
           this.pivotGrid1.Filters.Remove(this.pivotGrid1.Filters.FirstOrDefault(i => i.Name == "Product"));
           this.pivotGrid1.InvalidateCells();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).IsEnabled)
            {
                if (this.pivotGrid1.Filters.Count > 1)
                {
                   this.pivotGrid1.Filters.RemoveAt(1);
                }
                else if (this.pivotGrid1.GroupingBar.Filters.Count > 1)
                {
                   this.pivotGrid1.GroupingBar.Filters.RemoveAt(1);
                }
                else
                    MessageBox.Show("Please add the item before remove", "Warning!");
            }
           this.pivotGrid1.InvalidateCells();
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).IsEnabled)
            {
                if (this.pivotGrid1.GroupingBar != null &&this.pivotGrid1.GroupingBar.AllowMultiFunctionalSortFilter)
                {
                    FilterConverter filterconv = new FilterConverter();
                    for (int i = 0; i <this.pivotGrid1.Filters.Count; i++)
                    {
                        filterconv.UpdateDictionary(this.pivotGrid1.Filters[i].DimensionName);
                    }
                }
                else
                {
                    ImageConverter imgconv = new ImageConverter();
                    for (int i = 0; i <this.pivotGrid1.Filters.Count; i++)
                    {
                        imgconv.UpdateDictionary(this.pivotGrid1.Filters[i].DimensionName);
                    }
                }
               this.pivotGrid1.Filters.Clear();
               this.pivotGrid1.InternalGrid.Refresh(true);
            }
           this.pivotGrid1.InvalidateCells();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            if ((sender as Button).IsEnabled)
                this.pivotGrid1.Filters.Insert(0, new FilterExpression("State"));
           this.pivotGrid1.InvalidateCells();
        }
    }
}
