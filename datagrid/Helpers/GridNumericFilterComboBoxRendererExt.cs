#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

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
using Syncfusion.UI.Xaml.Grid.RowFilter;
using System.Collections.ObjectModel;
using Syncfusion.UI.Xaml.Grid;
using Syncfusion.Data;
using System.Collections;
using System.ComponentModel;
using Syncfusion.Windows.Tools.Controls;
using System;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Class represents the GridNumericFilterComboBoxRendererExt for customizing the ComboBoxRenderer
    /// </summary>
    public class GridNumericFilterComboBoxRendererExt : GridFilterRowComboBoxRenderer, INotifyPropertyChanged
    {
        private List<string> numericComboBoxItems;

        public GridNumericFilterComboBoxRendererExt()
            : base()
        {
            SetNumericComboBoxItemsList();
        }

        /// <summary>
        /// Generate the Items for NumericComboBox
        /// </summary>
        /// <returns></returns>
        public void SetNumericComboBoxItemsList()
        {
            numericComboBoxItems = new List<string>();
            numericComboBoxItems.Add("Between 10001 and 10020");
            numericComboBoxItems.Add("Between 10030 and 10050");
            numericComboBoxItems.Add("Between 10060 and 10080");
            numericComboBoxItems.Add("Between 10090 and 10110");
            numericComboBoxItems.Add("Between 10120 and 10150");
            numericComboBoxItems.Add(">10200");
        }

        /// <summary>
        /// Set the Margin for a ContentControl 
        /// </summary>
        /// <param name="dataColumn"></param>
        /// <param name="uiElement"></param>
        /// <param name="dataContext"></param>
        public override void OnInitializeDisplayElement(DataColumnBase dataColumn, ContentControl uiElement, object dataContext)
        {
            base.OnInitializeDisplayElement(dataColumn, uiElement, dataContext);
            uiElement.Margin = new Thickness(5, 0, 0, 0);
        }

        /// <summary>
        /// InitializeEditBinding based on our item, set the SelectedItem and set the ItemSource.
        /// </summary>
        /// <param name="uiElement">Corresponding uiElement</param>
        /// <param name="dataColumn">Corresponding Column</param>
        protected override void InitializeEditBinding(Syncfusion.Windows.Tools.Controls.ComboBoxAdv uiElement, DataColumnBase dataColumn)
        {
            ObservableCollection<object> selItems = new ObservableCollection<object>();
            //Generate the items for FilterRow                 
            uiElement.ItemsSource = numericComboBoxItems;
            InitializeNumericFilter(dataColumn, selItems);

            if (selItems.Count > 0)
                uiElement.SelectedItems = selItems;
            else if (uiElement.SelectedItems != null)
                uiElement.SelectedItems = null;
            uiElement.AllowMultiSelect = true;
            uiElement.AllowSelectAll = true;
            uiElement.EnableOKCancel = true;
            uiElement.IsEditable = false;
        }

        /// <summary>
        /// Check whether the column having a filterperdicates or not
        /// </summary>
        /// <param name="filterPredicate">FilterPredicates for a column</param>
        /// <param name="filterValue">FilterValue for a column</param>
        /// <returns></returns>
        private bool NeedToAdd(ObservableCollection<FilterPredicate> filterPredicate, string filterValue)
        {
            bool needToAdd = false;
            foreach (var item in filterPredicate)
            {
                if ((item as FilterPredicate).FilterValue.ToString() == filterValue)
                {
                    needToAdd = true;
                    break;
                }
            }
            return needToAdd;
        }

        /// <summary>
        /// Generate the FilterPredicates and apply the filter for a corresponding column
        /// </summary>
        /// <param name="filterValues">Corresponding FilterValue</param>
        /// <param name="totalItems">Corresponding FilterItems</param>
        public override void ProcessMultipleFilters(List<object> filterValues, List<object> totalItems)
        {
            var selectedItems = filterValues.Cast<string>().ToList();
            var total = totalItems.Cast<string>().ToList();
            if (selectedItems == null || total == null || filterValues == null)
                return;

            if (selectedItems.Count == total.Count)
            {
                this.ApplyFilters(null, string.Empty);
                this.IsValueChanged = false;
                return;
            }
            var filterPredicates = new List<FilterPredicate>();
            if (filterValues.Count > 0)
            {
                selectedItems.ForEach(item =>
                {
                    //Create the FilterPredicates and Apply the filter
                    ProcessNumericFilter(filterPredicates, item);
                });
            }
            string _filterText = string.Empty;
            //Creates the FilterText
            if (filterPredicates.Count > 0)
            {
                var selectItems = ((IList)filterValues).Cast<string>().ToList();
                for (int i = 0; i < selectedItems.Count; i++)
                {
                    _filterText += selectedItems[i];
                    if (i != selectedItems.Count - 1)
                        _filterText += " - ";
                }
            }
            if (filterPredicates != null)
                this.ApplyFilters(filterPredicates, _filterText);
            this.IsValueChanged = false;
        }

        /// <summary>
        /// Generate the FiletrPredicates for StronglyTyped
        /// </summary>
        /// <param name="value"></param>
        /// <param name="filterType"></param>
        /// <param name="predType"></param>
        /// <returns></returns>
        private FilterPredicate GetFilterPredicates(object value, FilterType filterType, PredicateType predType)
        {
            return new FilterPredicate()
            {
                FilterBehavior = FilterBehavior.StronglyTyped,
                FilterType = filterType,
                FilterValue = value,
                IsCaseSensitive = false,
                PredicateType = predType
            };
        }

        /// <summary>
        /// Initialize the NumericFilter
        /// </summary>
        /// <param name="dataColumn">Corresponding column</param>
        /// <param name="SelectedItem">SelectedItem for ComboBox</param>
        public void InitializeNumericFilter(DataColumnBase dataColumn, ObservableCollection<object> SelectedItem)
        {
            if (dataColumn.GridColumn.FilteredFrom == FilteredFrom.FilterRow && dataColumn.GridColumn.FilterPredicates.Count > 0)
            {
                if (numericComboBoxItems != null)
                {
                    numericComboBoxItems.ForEach(element =>
                    {
                        //Check if the filter is already applied or not, if applied means again add the filter
                        bool needToAdd = false;
                        switch (element)
                        {
                            case "Between 10001 and 10020":
                                needToAdd = this.NeedToAdd(dataColumn.GridColumn.FilterPredicates, "10001");
                                break;
                            case "Between 10030 and 10050":
                                needToAdd = this.NeedToAdd(dataColumn.GridColumn.FilterPredicates, "10030");
                                break;
                            case "Between 10060 and 10080":
                                needToAdd = this.NeedToAdd(dataColumn.GridColumn.FilterPredicates, "10060");
                                break;
                            case "Between 10090 and 10110":
                                needToAdd = this.NeedToAdd(dataColumn.GridColumn.FilterPredicates, "10090");
                                break;
                            case "Between 10120 and 10150":
                                needToAdd = this.NeedToAdd(dataColumn.GridColumn.FilterPredicates, "10120");
                                break;
                            case ">10200":
                                needToAdd = this.NeedToAdd(dataColumn.GridColumn.FilterPredicates, "10200");
                                break;
                        }
                        if (needToAdd)
                            SelectedItem.Add(element);
                    });
                }
            }
        }

        /// <summary>
        /// Created the filterpredicates for NumericColumn
        /// </summary>
        /// <param name="filterPredicates"></param>
        /// <param name="item"></param>
        public void ProcessNumericFilter(List<FilterPredicate> filterPredicates, string item)
        {
            switch (item)
            {
                case "Between 10001 and 10020":
                    filterPredicates.Add(GetFilterPredicates((int)10001, FilterType.GreaterThan, PredicateType.OrElse));
                    filterPredicates.Add(GetFilterPredicates((int)10020, FilterType.LessThan, PredicateType.And));
                    break;
                case "Between 10030 and 10050":
                    filterPredicates.Add(GetFilterPredicates((int)10030, FilterType.GreaterThan, PredicateType.OrElse));
                    filterPredicates.Add(GetFilterPredicates((int)10050, FilterType.LessThan, PredicateType.And));
                    break;
                case "Between 10060 and 10080":
                    filterPredicates.Add(GetFilterPredicates((int)10060, FilterType.GreaterThan, PredicateType.OrElse));
                    filterPredicates.Add(GetFilterPredicates((int)10080, FilterType.LessThan, PredicateType.And));
                    break;
                case "Between 10090 and 10110":
                    filterPredicates.Add(GetFilterPredicates((int)10090, FilterType.GreaterThan, PredicateType.OrElse));
                    filterPredicates.Add(GetFilterPredicates((int)10110, FilterType.LessThan, PredicateType.And));
                    break;
                case "Between 10120 and 10150":
                    filterPredicates.Add(GetFilterPredicates((int)10120, FilterType.GreaterThan, PredicateType.OrElse));
                    filterPredicates.Add(GetFilterPredicates((int)10150, FilterType.LessThan, PredicateType.And));
                    break;
                case ">10200":
                    filterPredicates.Add(GetFilterPredicates((int)10200, FilterType.GreaterThan, PredicateType.Or));
                    break;
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(String prop)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
            }
        }
    }
}
