#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.pivotgriddemos.wpf
{
    using System;
    using System.Collections.ObjectModel;
    using System.Windows.Controls;
    using Microsoft.Xaml.Behaviors;
    using System.Windows.Threading;
    using Syncfusion.PivotAnalysis.Base;
    using Syncfusion.Windows.Controls.PivotGrid;
    public class SampleBehavior : Behavior<Grid>
    {
        private PivotGridControl pivotGrid;
        private ScrollViewer scrollViewer;
        private DateTime startIndex = DateTime.Now;
        private int highRowIndex = 0;
        public IComparable ItemObjectLookup(object o, string name)
        {
            IComparable c = null;
            var io = o as ItemObject;
            if (io != null)
            {
                switch (name)
                {
                    case "Date":
                        c = io.Date;
                        break;
                    case "Client":
                        c = io.Client;
                        break;
                    case "Campaign":
                        c = io.Campaign;
                        break;
                    case "Color":
                        c = io.Color;
                        break;
                    case "Shape":
                        c = io.Shape;
                        break;
                    case "Price":
                        c = io.Price;
                        break;
                    case "Spend":
                        c = io.Spend;
                        break;
                    case "ColH":
                        c = io.ColH;
                        break;
                    case "ColI":
                        c = io.ColI;
                        break;
                    case "ColJ":
                        c = io.ColJ;
                        break;
                }
            }

            return c;
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.DataContext = new OnDemandLoadingViewModel();
            pivotGrid =AssociatedObject.Children[0] is Grid ? (AssociatedObject.Children[0] as Grid).Children[0] as PivotGridControl : null;
            scrollViewer = AssociatedObject.Children[0] is Grid ? (AssociatedObject.Children[0] as Grid).Children[1] as ScrollViewer : null;
            if (pivotGrid != null)
            {
                pivotGrid.AutoSizeOption = GridAutoSizeOption.None;
                var m = new MonthComparer("MMM");
                pivotGrid.PivotColumns.Add(new PivotItem
                {
                    FieldHeader = "Month",
                    Comparer = m,
                    FieldMappingName = "Date",
                    TotalHeader = "Total",
                    Format = "MMM"
                });
                pivotGrid.PivotEngine.EnableOnDemandCalculations =
                    pivotGrid.PivotEngine.UseIndexedEngine = true;
                pivotGrid.PivotEngine.GetValue = ItemObjectLookup;
                ObservableCollection<ItemObject> itemsSourceObject =
                    (AssociatedObject.DataContext as OnDemandLoadingViewModel).ItemObjectCollection;
                pivotGrid.PivotEngine.PivotSchemaChanged +=
                    PivotEngine_PivotSchemaChanged;
                pivotGrid.ItemSource = itemsSourceObject;
            }
        }

        private void PivotEngine_PivotSchemaChanged(object sender, PivotSchemaChangedArgs e)
        {
            startIndex = DateTime.Now;
            AssociatedObject.Dispatcher.BeginInvoke(DispatcherPriority.SystemIdle, new Action(() =>
                {
                    if (!pivotGrid.IgnoreRefresh)
                    {
                        if (scrollViewer != null != null && scrollViewer.Content is TextBlock)
                            (scrollViewer.Content as TextBlock).Text = string.Empty;
                        CheckTime(startIndex, "Initial part done in");
                        ContinueLoadingAsynchonolously(
                            pivotGrid.PivotEngine.IndexEngine, startIndex);
                        if (scrollViewer != null != null && scrollViewer.Content is TextBlock)
                            (scrollViewer.Content as TextBlock).Text += "\n" + "The following data represent, number of rows loaded in on demand against the total number of rows. i.e, " + "\n" + "Number of rows loaded / Total number of rows";
                    }
                }));
        }

        private void ContinueLoadingAsynchonolously(IndexEngine engine, DateTime index)
        {
            AssociatedObject.Dispatcher.BeginInvoke(new Action(() =>
                {
                    if (engine != null && engine.HighRowLevel < engine.RowCount - 1)
                    {
                        if (scrollViewer != null && scrollViewer.Content is TextBlock)
                        {
                            (scrollViewer.Content as TextBlock).Text +=
                                string.Format("\n{0}/{1}", (highRowIndex + engine.HighRowLevel), engine.RowCount - 1);
                            highRowIndex += engine.HighRowLevel;
                            ContinueLoadingAsynchonolously(engine, index); //do it again...
                        }
                    }
                    else
                    {
                        CheckTime(index, "Load Completed");
                    }
                }), DispatcherPriority.SystemIdle);
        }

        private void CheckTime(DateTime start, string label)
        {
            if (scrollViewer.Content is TextBlock)
                (scrollViewer.Content as TextBlock).Text += string.Format("\n{0} {1:0.0000} seconds.", label,
                                                                           DateTime.Now.Subtract(start).TotalSeconds);
        }
    }
}