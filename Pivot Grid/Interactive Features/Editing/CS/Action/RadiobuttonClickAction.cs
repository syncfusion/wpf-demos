#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace PivotEditing.Action
{
    using Syncfusion.Windows.Controls.PivotGrid;
    using System.Windows.Interactivity;
    using System.Windows;
    using System.Windows.Controls;
    using Syncfusion.PivotAnalysis.Base;
    using Model;

    public class RadiobuttonClickAction : TargetedTriggerAction<PivotGridControl>
    {
        protected override void Invoke(object parameter)
        {
            if (parameter is RoutedEventArgs)
            {
                RoutedEventArgs eventArgs = parameter as RoutedEventArgs;
                RadioButton sourceBtn = eventArgs.OriginalSource as RadioButton;
                if (sourceBtn != null)
                {
                    switch (sourceBtn.Content.ToString())
                    {
                        case "Custom Manager":
                            //User derived EditManager.
                            this.Target.EditManager.Dispose(); //dispose the current one...
                            this.Target.EditManager = new CustomEditManager(this.Target) { HideExpanders = this.Target.EditManager.HideExpanders }; //set the derived one...
                            break;
                        case "Built-In Manager":
                            //User built-in EditManager.
                            this.Target.EditManager.Dispose(); //dispose the current one...
                            this.Target.EditManager = new PivotEditingManager(this.Target) { HideExpanders = this.Target.EditManager.HideExpanders }; //set the derived one...
                            break;
                        case "List":
                            LoadList();
                            break;
                        case "DataTable":
                            LoadDataTable();
                            break;
                    }
                }
            }
        }

        #region DataSource
        /// <summary>
        /// Loads the DataTable as DataSource for PivotGridControl
        /// </summary>
        private void LoadDataTable()
        {
            this.Target.ItemSource = null;
            this.Target.ResetPivotData();
            this.Target.ItemSource = BusinessObjectsDataView.GetDataTable(200);

            this.Target.PivotRows.Add(new PivotItem() { FieldMappingName = "Fruit", FieldHeader = "Fruit", TotalHeader = "Total" });
            this.Target.PivotRows.Add(new PivotItem() { FieldMappingName = "Color", FieldHeader = "Color", TotalHeader = "Total" });

            this.Target.PivotColumns.Add(new PivotItem() { FieldMappingName = "Shape", FieldHeader = "Shape", TotalHeader = "Total" });
            this.Target.PivotColumns.Add(new PivotItem() { FieldMappingName = "Even", FieldHeader = "Even", TotalHeader = "Total" });

            this.Target.PivotCalculations.Add(new PivotComputationInfo() { FieldName = "Count", FieldHeader = "Count", SummaryType = SummaryType.DoubleTotalSum });
            this.Target.PivotCalculations.Add(new PivotComputationInfo() { FieldName = "Section", FieldHeader = "Section", SummaryType = SummaryType.DoubleTotalSum });
            this.Target.PivotCalculations.Add(new PivotComputationInfo() { FieldName = "Weight", FieldHeader = "Weight", SummaryType = SummaryType.DoubleTotalSum });
        }

        /// <summary>
        /// Loads the List as DataSource for PivotGridControl
        /// </summary>
        private void LoadList()
        {
            this.Target.ItemSource = null;
            this.Target.ResetPivotData();
            this.Target.ItemSource = BusinessObjectCollection.GetList(200);

            this.Target.PivotRows.Add(new PivotItem() { FieldMappingName = "Fruit", FieldHeader = "Fruit", TotalHeader = "Total" });
            this.Target.PivotRows.Add(new PivotItem() { FieldMappingName = "Color", FieldHeader = "Color", TotalHeader = "Total" });

            this.Target.PivotColumns.Add(new PivotItem() { FieldMappingName = "Shape", FieldHeader = "Shape", TotalHeader = "Total" });
            this.Target.PivotColumns.Add(new PivotItem() { FieldMappingName = "Even", FieldHeader = "Even", TotalHeader = "Total" });

            this.Target.PivotCalculations.Add(new PivotComputationInfo() { FieldName = "Count", FieldHeader = "Count", SummaryType = SummaryType.DoubleTotalSum });
            this.Target.PivotCalculations.Add(new PivotComputationInfo() { FieldName = "Section", FieldHeader = "Section", SummaryType = SummaryType.DoubleTotalSum });
            this.Target.PivotCalculations.Add(new PivotComputationInfo() { FieldName = "Weight", FieldHeader = "Weight", SummaryType = SummaryType.DoubleTotalSum });

        }
        #endregion
    }
}