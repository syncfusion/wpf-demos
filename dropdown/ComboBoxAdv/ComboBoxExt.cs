#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;
using System.Windows;

namespace syncfusion.dropdowndemos.wpf
{
    /// <summary>
    /// Class represents the ComboBoxExt.
    /// </summary>
    public class ComboBoxExt : ComboBoxAdv
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ComboBoxExt"/> class.
        /// </summary>
        public ComboBoxExt()
        {
            SetResourceReference(StyleProperty, typeof(ComboBoxAdv));
        }

        /// <summary>
        /// Handle the selected items when the item is checked.
        /// </summary>
        /// <param name="checkedItem">Specifies the checked items in comboBox.</param>
        /// <param name="selectedItems">Specifies the selected items in comboBox.</param>
        /// <returns></returns>
        protected override ObservableCollection<object> OnItemChecked(object checkedItem, ObservableCollection<object> selectedItems)
        {
            var item = ((FrameworkElement)checkedItem).DataContext;
            if (item == this.Items[0])
            {
                AddItem(selectedItems, new int[] { 1, 2 });
            }
            if (item == this.Items[4])
            {
                AddItem(selectedItems, new int[] { 5, 6 });
            }
            if (item == this.Items[7])
            {
                AddItem(selectedItems, new int[] { 8, 9 });
            }
            return base.OnItemChecked(checkedItem, selectedItems);
        }

        /// <summary>
        /// Handle the selected items when the item is unchecked.
        /// </summary>
        /// <param name="unCheckedItem">Specifies the unchecked items in comboBox.</param>
        /// <param name="selectedItems">Specifies the selected items in comboBox.</param>
        /// <returns></returns>
        protected override ObservableCollection<object> OnItemUnchecked(object uncheckedItem, ObservableCollection<object> selectedItems)
        {
            var item = ((FrameworkElement)uncheckedItem).DataContext;
            if (item == this.Items[0])
            {
                RemoveItem(selectedItems, new int[] { 1, 2 });
            }
            if (item == this.Items[4])
            {
                RemoveItem(selectedItems, new int[] { 5, 6 });
            }
            if (item == this.Items[7])
            {
                RemoveItem(selectedItems, new int[] { 8, 9 });
            }
            return base.OnItemUnchecked(uncheckedItem, selectedItems);
        }

        /// <summary>
        /// Method used to check the items in comboBox.
        /// </summary>
        /// <param name="selectedItems">Specifies the selected items in comboBox.</param>
        /// <param name="index">Specifies the index of items.</param>
        public void AddItem(ObservableCollection<object> selectedItems, int[] index)
        {
            foreach (int i in index)
            {
                if (!selectedItems.Contains(this.Items[i]))
                    selectedItems.Add(this.Items[i]);
            }
        }

        /// <summary>
        /// Method used to uncheck the items in comboBox.
        /// </summary>
        /// <param name="selectedItems">Specifies the selected items in comboBox.</param>
        /// <param name="index">Specifies the index of items.</param>
        public void RemoveItem(ObservableCollection<object> selectedItems, int[] index)
        {
            foreach (int i in index)
            {
                if (selectedItems.Contains(this.Items[i]))
                    selectedItems.Remove(this.Items[i]);
            }
        }
    }
}
