#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;

namespace syncfusion.expenseanalysis.wpf
{
    /// <summary>
    /// Represents a generic view model for an item that can be displayed in a list or menu. It encapsulates properties for an icon, a title and associated content.
    /// </summary>
    public class ItemViewModel : BaseViewModel
    {
        private DataTemplate icon;
        private string title;
        private object content;

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate"/> for the icon that represents this item.
        /// </summary>
        public DataTemplate Icon
        {
            get { return icon; }
            set { icon = value; RaisePropertyChanged(nameof(Icon)); }
        }

        /// <summary>
        /// Gets or sets the title or display name for this item.
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(nameof(Title)); }
        }

        /// <summary>
        /// Gets or sets the content associated with this item. This is often a view or viewmodel that will be displayed when the item is selected.
        /// </summary>
        public object Content
        {
            get { return content; }
            set { content = value; RaisePropertyChanged(nameof(Content)); }
        }
    }
}
