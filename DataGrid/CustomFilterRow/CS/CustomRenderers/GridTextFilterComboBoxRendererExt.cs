#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
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

namespace CustomFilterRow
{
    /// <summary>
    /// Class represents the GridTextFilterComboBoxRendererExt for customizing the ComboBoxRenderer
    /// </summary>
    public class GridTextFilterComboBoxRendererExt : GridFilterRowComboBoxRenderer, INotifyPropertyChanged
    {
        private List<string> textComboBoxItems;

        public GridTextFilterComboBoxRendererExt()
            : base()
        {
            SetTextComboBoxItemsList();
        }

        /// <summary>
        ///  Generate the Items for TextComboBox
        /// </summary>
        /// <returns></returns>
        public void SetTextComboBoxItemsList()
        {
            textComboBoxItems = new List<string>();
            textComboBoxItems.Add("A to D");
            textComboBoxItems.Add("E to H");
            textComboBoxItems.Add("I to L");
            textComboBoxItems.Add("M to P");
            textComboBoxItems.Add("Q to U");
            textComboBoxItems.Add("V to Z");
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
            uiElement.ItemsSource = textComboBoxItems;
            InitializeTextFilter(dataColumn, selItems);
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
                    ProcessTextFilter(filterPredicates, item);
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
        /// Generate the FiletrPredicates for StringTyped
        /// </summary>
        /// <param name="value"></param>
        /// <param name="filterType"></param>
        /// <param name="predType"></param>
        /// <returns></returns>
        private FilterPredicate GetStringFilterPredicates(object value, FilterType filterType, PredicateType predType)
        {
            return new FilterPredicate()
            {
                FilterBehavior = FilterBehavior.StringTyped,
                FilterType = filterType,
                FilterValue = value,
                IsCaseSensitive = false,
                PredicateType = predType
            };
        }


        /// <summary>
        /// Initialize the TextFilter
        /// </summary>
        /// <param name="dataColumn">Corresponding column</param>
        /// <param name="SelectedItem">SelectedItem for ComboBox</param>
        public void InitializeTextFilter(DataColumnBase dataColumn, ObservableCollection<object> SelectedItem)
        {
            if (dataColumn.GridColumn.FilteredFrom == FilteredFrom.FilterRow && dataColumn.GridColumn.FilterPredicates.Count > 0)
            {
                if (textComboBoxItems != null)
                {
                    textComboBoxItems.ForEach(element =>
                    {
                        //Check if the filter is already applied or not, if applied means again add the filter
                        bool needToAdd = false;
                        switch (element)
                        {
                            case "A to D":
                                needToAdd = this.NeedToAdd(dataColumn.GridColumn.FilterPredicates, "A");
                                break;
                            case "E to H":
                                needToAdd = this.NeedToAdd(dataColumn.GridColumn.FilterPredicates, "E");
                                break;
                            case "I to L":
                                needToAdd = this.NeedToAdd(dataColumn.GridColumn.FilterPredicates, "I");
                                break;
                            case "M to P":
                                needToAdd = this.NeedToAdd(dataColumn.GridColumn.FilterPredicates, "M");
                                break;
                            case "Q to U":
                                needToAdd = this.NeedToAdd(dataColumn.GridColumn.FilterPredicates, "Q");
                                break;
                            case "V to Z":
                                needToAdd = this.NeedToAdd(dataColumn.GridColumn.FilterPredicates, "V");
                                break;

                        }
                        if (needToAdd)
                            SelectedItem.Add(element);
                    });
                }
            }
        }


        /// <summary>
        /// Created the filterpredicates for TextColumn
        /// </summary>
        /// <param name="filterPredicates"></param>
        /// <param name="item"></param>
        public void ProcessTextFilter(List<FilterPredicate> filterPredicates, string item)
        {
            switch (item)
            {
                case "A to D":
                    filterPredicates.Add(GetStringFilterPredicates("A", FilterType.StartsWith, PredicateType.OrElse));
                    filterPredicates.Add(GetStringFilterPredicates("B", FilterType.StartsWith, PredicateType.Or));
                    filterPredicates.Add(GetStringFilterPredicates("C", FilterType.StartsWith, PredicateType.Or));
                    filterPredicates.Add(GetStringFilterPredicates("D", FilterType.StartsWith, PredicateType.Or));
                    break;
                case "E to H":
                    filterPredicates.Add(GetStringFilterPredicates("E", FilterType.StartsWith, PredicateType.OrElse));
                    filterPredicates.Add(GetStringFilterPredicates("F", FilterType.StartsWith, PredicateType.Or));
                    filterPredicates.Add(GetStringFilterPredicates("G", FilterType.StartsWith, PredicateType.Or));
                    filterPredicates.Add(GetStringFilterPredicates("H", FilterType.StartsWith, PredicateType.Or));
                    break;
                case "I to L":
                    filterPredicates.Add(GetStringFilterPredicates("I", FilterType.StartsWith, PredicateType.OrElse));
                    filterPredicates.Add(GetStringFilterPredicates("J", FilterType.StartsWith, PredicateType.Or));
                    filterPredicates.Add(GetStringFilterPredicates("K", FilterType.StartsWith, PredicateType.Or));
                    filterPredicates.Add(GetStringFilterPredicates("L", FilterType.StartsWith, PredicateType.Or));
                    break;
                case "M to P":
                    filterPredicates.Add(GetStringFilterPredicates("M", FilterType.StartsWith, PredicateType.OrElse));
                    filterPredicates.Add(GetStringFilterPredicates("N", FilterType.StartsWith, PredicateType.Or));
                    filterPredicates.Add(GetStringFilterPredicates("O", FilterType.StartsWith, PredicateType.Or));
                    filterPredicates.Add(GetStringFilterPredicates("P", FilterType.StartsWith, PredicateType.Or));
                    break;
                case "Q to U":
                    filterPredicates.Add(GetStringFilterPredicates("Q", FilterType.StartsWith, PredicateType.OrElse));
                    filterPredicates.Add(GetStringFilterPredicates("R", FilterType.StartsWith, PredicateType.Or));
                    filterPredicates.Add(GetStringFilterPredicates("S", FilterType.StartsWith, PredicateType.Or));
                    filterPredicates.Add(GetStringFilterPredicates("T", FilterType.StartsWith, PredicateType.Or));
                    filterPredicates.Add(GetStringFilterPredicates("U", FilterType.StartsWith, PredicateType.Or));
                    break;
                case "V to Z":
                    filterPredicates.Add(GetStringFilterPredicates("V", FilterType.StartsWith, PredicateType.OrElse));
                    filterPredicates.Add(GetStringFilterPredicates("W", FilterType.StartsWith, PredicateType.Or));
                    filterPredicates.Add(GetStringFilterPredicates("X", FilterType.StartsWith, PredicateType.Or));
                    filterPredicates.Add(GetStringFilterPredicates("Y", FilterType.StartsWith, PredicateType.Or));
                    filterPredicates.Add(GetStringFilterPredicates("Z", FilterType.StartsWith, PredicateType.Or));
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
