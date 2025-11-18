#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.kanbandemos.wpf
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using System.Windows;
    using System.Windows.Controls;
    using Microsoft.Xaml.Behaviors;
    using Syncfusion.UI.Xaml.Kanban;

    /// <summary>
    /// Represents the behavior for managing sorting cards in a sample view.
    /// </summary>
    public class SortingBehavior : Behavior<Sorting>
    {
        #region Fields

        /// <summary>
        /// The kanban selected card. 
        /// </summary>
        private KanbanCardItem selectedCard;

        /// <summary>
        /// To store initial Kanban SortingMappingPath value
        /// </summary>
        private string sortingMappingPathValue;

        /// <summary>
        /// The kanban control instance
        /// </summary>
        private SfKanban kanban;

        /// <summary>
        /// The sorting index combo box instance.
        /// </summary>
        private ComboBox sortByComboBox;

        /// <summary>
        /// The sorting order combo box instance.
        /// </summary>
        private ComboBox sortingOrderComboBox;

        /// <summary>
        /// The sorting mapping path combo box instance.
        /// </summary>
        private ComboBox mappingPathComboBox;

        #endregion

        #region Override methods

        /// <summary>
        /// Invoked when behavior is attached to a view.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += this.OnAssociatedObjectLoaded;
        }

        /// <summary>
        /// Invoked when behavior is detached from a view.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.Loaded -= this.OnAssociatedObjectLoaded;
            this.UnwireEvents();
        }

        #endregion

        #region Property changed

        /// <summary>
        /// Handles the Loaded event of the AssociatedObject control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void OnAssociatedObjectLoaded(object sender, RoutedEventArgs e)
        {
            this.kanban = this.AssociatedObject.kanban;
            this.sortByComboBox = this.AssociatedObject.sortBySelection;
            this.sortingOrderComboBox = this.AssociatedObject.sortOrderComboBox;
            this.mappingPathComboBox = this.AssociatedObject.mappingPathComboBox;
            this.sortingMappingPathValue = this.kanban.SortingMappingPath;
            if (string.IsNullOrEmpty(this.sortingMappingPathValue) && mappingPathComboBox != null && mappingPathComboBox.SelectedItem != null)
            {
                this.sortingMappingPathValue = mappingPathComboBox.SelectedItem.ToString();
            }

            this.UnwireEvents();
            this.WireEvents();
        }

        /// <summary>
        /// Occurs when a card drag event is started.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The event args.</param>
        private void OnKanbanCardDragStart(object sender, KanbanDragStartEventArgs e)
        {
            this.selectedCard = e.SelectedCard;
        }

        /// <summary>
        /// Occurs when a card is dropped.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The event args.</param>
        private void OnKanbanCardDragEnd(object sender, KanbanDragEndEventArgs e)
        {
            if (this.kanban == null || this.selectedCard == null || e.TargetColumn == null || this.sortByComboBox == null || this.sortByComboBox.SelectedItem == null)
            {
                return;
            }

            this.UpdateProgressOnColumnChange(e);

            string selectedItem = this.sortByComboBox.SelectedItem.ToString() ?? string.Empty;
            
            // Apply mapping path behavior based on SortBy selection
            if (selectedItem == "Index")
            {
                this.ApplySortingWithoutPositionChange(e);
            }
            else if (selectedItem == "Custom")
            {
                this.kanban.RefreshKanbanColumn(e.TargetKey.ToString());
            }
        }

        /// <summary>
        /// Occurs when the sorting order value is changed.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The event args.</param>
        private void OnSortingOrderComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (sender as ComboBox)?.SelectedItem?.ToString();
            if (this.kanban == null || selectedItem == null)
            {
                return;
            }

            if (Enum.TryParse<KanbanSortingOrder>(selectedItem.ToString(), out KanbanSortingOrder sortOrder))
            {
                this.kanban.SortingOrder = sortOrder;
            }
        }

        /// <summary>
        /// Occurs when the sort by value is changed.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The event args.</param>
        private void OnSortByComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.UpdateMappingPathEnabled();
            if (this.kanban == null || this.sortByComboBox == null || this.sortByComboBox.SelectedItem == null || !(sender is ComboBox))
            {
                return;
            }

            string selectedItem = this.sortByComboBox.SelectedItem.ToString() ?? string.Empty;
            switch (selectedItem)
            {
                case "Index":
                    this.kanban.SortingMappingPath = "Index";
                    this.mappingPathComboBox.SelectedIndex = 1;
                    break;

                case "Custom":
                    // Restore original value from XAML (fallback to "Index" if somehow null or empty)
                    var originalValue = string.IsNullOrEmpty(this.sortingMappingPathValue) ? "Index" : this.sortingMappingPathValue;
                    if (!string.Equals(this.kanban.SortingMappingPath, originalValue, StringComparison.Ordinal))
                    {
                        this.kanban.SortingMappingPath = originalValue;
                    }

                    this.mappingPathComboBox.SelectedIndex = 1;
                    break;

                case "ItemSource Order":
                    // Use item source order. So clearing SortingMappingPath value.
                    this.kanban.SortingMappingPath = string.Empty;
                    break;
            }
        }

        /// <summary>
        /// Occurs when the sorting mapping path value is changed.
        /// </summary>
        /// <param name="sender">The object.</param>
        /// <param name="e">The event args.</param>
        public void OnSortMappingPathSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (sender as ComboBox)?.SelectedItem?.ToString();
            if (this.kanban == null || string.IsNullOrEmpty(selectedItem))
            {
                return;
            }

            this.kanban.SortingMappingPath = selectedItem;
            this.sortingMappingPathValue = selectedItem;
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Updates index property with smart positioning based on sorting order.
        /// </summary>
        /// <param name="items">The list of Kanban card items to be reordered.</param>
        /// <param name="droppedIndex">The index position where the card was dropped.</param>
        private void ApplySmartIndexUpdate(List<KanbanCardItem> items, int droppedIndex)
        {
            if (this.kanban == null || items == null || items.Count == 0)
            {
                return;
            }

            if (this.kanban.SortingOrder == KanbanSortingOrder.Ascending)
            {
                this.HandleAscendingIndexSorting(items, droppedIndex);
                return;
            }

            this.HandleDescendingIndexSorting(items, droppedIndex);
        }

        /// <summary>
        /// Applies sorting without changing the position of the cards.
        /// </summary>
        /// <param name="e">The event args.</param>
        private void ApplySortingWithoutPositionChange(KanbanDragEndEventArgs e)
        {
            var cardItems = e.TargetColumn.Items.Cast<KanbanCardItem>().ToList();
            if (this.kanban == null || this.selectedCard == null || this.selectedCard.Content == null || e.TargetColumn == null || e.TargetKey == null || cardItems == null || !cardItems.Any()
                || e.SelectedColumn == null || (e.SelectedColumn == e.TargetColumn && e.SelectedCardIndex == e.TargetCardIndex))
            {
                return;
            }

            // Retrieve sorting configuration
            var sortMappingPath = this.kanban.SortingMappingPath;
            var sortingOrder = this.kanban.SortingOrder;
            CardDetails cardDetails = this.selectedCard.Content as CardDetails;

            // Proceed only if sorting path is defined
            if (cardDetails == null || string.IsNullOrEmpty(sortMappingPath))
            {
                return;
            }

            // Extract items from the target colum
            var targetColumnItems = cardItems.Where(card => card != null && card.Content is CardDetails).ToList();

            // Sort items based on the sorting order
            if (targetColumnItems.Count > 0)
            {
                Func<KanbanCardItem, object> keySelector = item => this.GetPropertyInfo(item.GetType(), sortMappingPath);
                targetColumnItems = sortingOrder == KanbanSortingOrder.Ascending
                    ? targetColumnItems.OrderBy(item => keySelector(item) ?? 0).ToList()
                    : targetColumnItems.OrderByDescending(item => keySelector(item) ?? 0).ToList();
            }

            // Determine the index to insert the dragged card.
            int currentCardIndex = e.TargetCardIndex;

            if (e.SelectedColumn != e.TargetColumn)
            {
                cardDetails.Category = e.TargetKey.ToString();
            }

            if (currentCardIndex >= 0 && currentCardIndex <= targetColumnItems.Count)
            {
                targetColumnItems.Insert(currentCardIndex, this.selectedCard);
            }
            else
            {
                targetColumnItems.Add(this.selectedCard);
                currentCardIndex = targetColumnItems.Count - 1;
            }

            // Update index property of all items using smart positioning logic
            this.ApplySmartIndexUpdate(targetColumnItems, currentCardIndex);
        }

        /// <summary>
        /// Method to handle ascending index sorting with smart positioning.
        /// </summary>
        /// <param name="items">The list of items to update.</param>
        /// <param name="currentCardIndex">The current card index.</param>
        private void HandleAscendingIndexSorting(List<KanbanCardItem> items, int currentCardIndex)
        {
            int afterCardIndex = -1;
            int lastItemIndex = -1;

            // Get the index of the card after the insertion point
            if (currentCardIndex < items.Count - 1)
            {
                var afterCard = items[currentCardIndex + 1];
                afterCardIndex = GetCardIndex(afterCard?.Content) ?? -1;
            }

            for (int i = 0; i < items.Count; i++)
            {
                var item = items[i].Content;
                if (item == null)
                {
                    continue;
                }

                PropertyInfo propertyInfo = this.GetPropertyInfo(item.GetType(), "Index");
                if (propertyInfo == null)
                {
                    continue;
                }

                int itemIndex = Convert.ToInt32(propertyInfo.GetValue(item) ?? 0);
                bool isFirstItem = i == 0;
                if (isFirstItem)
                {
                    // If the inserted card is at the beginning, assign a smart index
                    if (currentCardIndex == 0)
                    {
                        lastItemIndex = afterCardIndex > 1 ? afterCardIndex - 1 : 1;
                        propertyInfo.SetValue(item, lastItemIndex);
                    }
                    else
                    {
                        lastItemIndex = itemIndex;
                    }
                }
                else
                {
                    // Increment index for subsequent items
                    lastItemIndex++;
                    propertyInfo.SetValue(item, lastItemIndex);
                }
            }
        }

        /// <summary>
        /// Method to handle descending index sorting with smart positioning.
        /// </summary>
        /// <param name="items">The list of items to update.</param>
        /// <param name="currentCardIndex">The current card index.</param>
        private void HandleDescendingIndexSorting(List<KanbanCardItem> items, int currentCardIndex)
        {
            int beforeCardIndex = -1;
            int lastItemIndex = -1;

            // Get the index of the card before the insertion point
            if (currentCardIndex > 0 && currentCardIndex < items.Count)
            {
                var cardBefore = items[currentCardIndex - 1];
                beforeCardIndex = GetCardIndex(cardBefore?.Content) ?? -1;
            }

            for (int i = items.Count - 1; i >= 0; i--)
            {
                var item = items[i].Content;
                if (item == null)
                {
                    continue;
                }

                PropertyInfo propertyInfo = this.GetPropertyInfo(item.GetType(), "Index");
                if (propertyInfo == null)
                {
                    continue;
                }

                int itemIndex = Convert.ToInt32(propertyInfo.GetValue(item) ?? 0);
                bool isLastItem = i == items.Count - 1;
                if (isLastItem)
                {
                    // If the inserted card is at the end, assign a smart index
                    if (currentCardIndex == items.Count - 1)
                    {
                        lastItemIndex = beforeCardIndex > 1 ? beforeCardIndex - 1 : 1;
                        propertyInfo.SetValue(item, lastItemIndex);
                    }
                    else
                    {
                        lastItemIndex = itemIndex;
                    }
                }
                else
                {
                    lastItemIndex++;
                    propertyInfo.SetValue(item, lastItemIndex);
                }
            }
        }

        /// <summary>
        /// Method to get the index property value from a card object.
        /// </summary>
        /// <param name="cardDetails">The card object.</param>
        /// <returns>The index value or null if not found.</returns>
        private int? GetCardIndex(object cardDetails)
        {
            if (cardDetails == null)
            {
                return null;
            }

            PropertyInfo propertyInfo = this.GetPropertyInfo(cardDetails.GetType(), "Index");
            if (propertyInfo == null)
            {
                return null;
            }

            var indexValue = propertyInfo.GetValue(cardDetails);
            if (indexValue != null)
            {
                return Convert.ToInt32(indexValue);
            }

            return null;
        }

        /// <summary>
        /// Method to get the property info for the specified property.
        /// </summary>
        /// <param name="type">The property type.</param>
        /// <param name="key">The property name.</param>
        /// <returns>The property info of the specified property.</returns>
        private PropertyInfo GetPropertyInfo(Type type, string key)
        {
            return this.GetPropertyInfoCustomType(type, key);
        }

        /// <summary>
        /// Method to get the property info for the specified property from the given type.
        /// </summary>
        /// <param name="type">The property type.</param>
        /// <param name="key">The property name.</param>
        /// <returns>The property info of the specified property.</returns>
        private PropertyInfo GetPropertyInfoCustomType(Type type, string key)
        {
            return type.GetProperty(key);
        }

        /// <summary>
        /// Method to update card progress value on column changes.
        /// </summary>
        /// <param name="e">The drop event args.</param>
        private void UpdateProgressOnColumnChange(KanbanDragEndEventArgs e)
        {
            if (e == null || this.selectedCard == null || !(this.selectedCard.Content is CardDetails ) || e.SelectedColumn == null || e.TargetColumn == null)
            {
                return;
            }

            // Get source and target category from the column's categories
            string sourceCategory = e.SelectedColumn.Categories;
            string targetCategory = e.TargetColumn.Categories;
            CardDetails cardDetails = this.selectedCard.Content as CardDetails;
            if (string.IsNullOrEmpty(sourceCategory) || string.IsNullOrEmpty(targetCategory)
                || string.Equals(sourceCategory, targetCategory, StringComparison.Ordinal))
            {
                return;
            }

            if (string.Equals(sourceCategory, "In Progress", StringComparison.Ordinal) &&
                    string.Equals(targetCategory, "Code Review", StringComparison.Ordinal))
            {
                cardDetails.Progress = Math.Min(100, cardDetails.Progress + 25);
            }
            else if (string.Equals(sourceCategory, "Open", StringComparison.Ordinal) &&
                     string.Equals(targetCategory, "In Progress", StringComparison.Ordinal))
            {
                cardDetails.Progress = Math.Min(100, cardDetails.Progress + 30);
            }
            else if (string.Equals(sourceCategory, "Open", StringComparison.Ordinal) &&
                     string.Equals(targetCategory, "Code Review", StringComparison.Ordinal))
            {
                cardDetails.Progress = Math.Min(100, cardDetails.Progress + 70);
            }
            else if (string.Equals(sourceCategory, "Code Review", StringComparison.Ordinal) &&
                     string.Equals(targetCategory, "In Progress", StringComparison.Ordinal))
            {
                cardDetails.Progress = Math.Min(100, cardDetails.Progress - 25);
            }
            else if (targetCategory == "Done")
            {
                cardDetails.Progress = 100;
            }
            else if (targetCategory == "Open")
            {
                cardDetails.Progress = 0;
            }
        }

        /// <summary>
        /// Method to enable or disable the mapping path combo box control.
        /// </summary>
        private void UpdateMappingPathEnabled()
        {
            if (this.sortingOrderComboBox == null || this.sortByComboBox == null || this.sortByComboBox.SelectedItem == null || this.mappingPathComboBox == null)
            {
                return;
            }

            var selectedItem = this.sortByComboBox.SelectedItem.ToString() ?? string.Empty;
            bool isIndex = string.Equals(selectedItem, "Index", StringComparison.Ordinal);
            bool isItemSourceOrder = string.Equals(selectedItem, "ItemSource Order", StringComparison.Ordinal);

            // Enable or disable the combo boxes based on the selected sort by option
            this.mappingPathComboBox.IsEnabled = !(isIndex || isItemSourceOrder);
            this.sortingOrderComboBox.IsEnabled = !isItemSourceOrder;
        }

        /// <summary>
        /// Method to unwire the events.
        /// </summary>
        private void UnwireEvents()
        {
            this.kanban.CardDragStart -= this.OnKanbanCardDragStart;
            this.kanban.CardDragEnd -= this.OnKanbanCardDragEnd;

            if (this.sortByComboBox != null)
            {
                this.sortByComboBox.SelectionChanged -= this.OnSortByComboBoxSelectionChanged;
            }

            if (this.mappingPathComboBox != null)
            {
                this.mappingPathComboBox.SelectionChanged -= this.OnSortMappingPathSelectionChanged;
            }

            if (this.sortingOrderComboBox != null)
            {
                this.sortingOrderComboBox.SelectionChanged -= this.OnSortingOrderComboBoxSelectionChanged;
            }
        }

        /// <summary>
        /// Method to wire the events.
        /// </summary>
        private void WireEvents()
        {
            this.kanban.CardDragStart += OnKanbanCardDragStart;
            this.kanban.CardDragEnd += OnKanbanCardDragEnd;

            if (this.sortByComboBox != null)
            {
                this.sortByComboBox.SelectionChanged += this.OnSortByComboBoxSelectionChanged;
            }

            if (this.mappingPathComboBox != null)
            {
                this.mappingPathComboBox.SelectionChanged += this.OnSortMappingPathSelectionChanged;
            }

            if (this.sortingOrderComboBox != null)
            {
                this.sortingOrderComboBox.SelectionChanged += this.OnSortingOrderComboBoxSelectionChanged;
            }
        }

        #endregion
    }
}