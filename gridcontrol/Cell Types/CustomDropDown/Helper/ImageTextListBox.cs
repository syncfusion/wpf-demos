#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.gridcontroldemos.wpf
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;

    public  class ImageTextListBox : ListBox
    {
        public ImageTextListBox(CustomeDropDown dropDown)
        {
            this.DropDown = dropDown; 
        }

        public CustomeDropDown DropDown
        {
            get;
            private set;
        }

        internal void NotifyListBoxItemEnter(ImageTextListBoxListBoxItem item)
        {
            item.Focus();
            this.HighlightedItem = item;
            this.SelectedIndex = this.ItemContainerGenerator.IndexFromContainer(item);
        }

        internal void NotifyListBoxItemMouseUp(ImageTextListBoxListBoxItem item)
        {
            this.SelectedItem = item;
            this.DropDown.Close();
        }

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            return (item is ImageTextListBoxListBoxItem);
        }

        protected override DependencyObject GetContainerForItemOverride()
        {
            return new ImageTextListBoxListBoxItem();
        }

        private WeakReference highlightedItem = null;
        private ImageTextListBoxListBoxItem HighlightedItem
        {
            get
            {
                if (this.highlightedItem == null)
                {
                    return null;
                }

                return this.highlightedItem.Target as ImageTextListBoxListBoxItem;
            }

            set
            {
                ImageTextListBoxListBoxItem item = (this.highlightedItem != null) ? (this.highlightedItem.Target as ImageTextListBoxListBoxItem) : null;
                if (item != null)
                {
                    item.SetIsHighlighted(false);
                }
                if (value != null)
                {
                    this.highlightedItem = new WeakReference(value);
                    value.SetIsHighlighted(true);
                }
                else
                {
                    this.highlightedItem = null;
                }
            }
        }
    }
}
