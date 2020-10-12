#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Windows.Media;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represents groupbar sub item.
    /// </summary>
    public class SubItemModel : NotificationObject
    {
        /// <summary>
        ///  Maintains the header of the groupbar.
        /// </summary>
        private string header;

        /// <summary>
        ///  Maintains the source of the groupbar.
        /// </summary>
        private ImageSource source;

        /// <summary>
        ///  Maintains the content of the groupbar.
        /// </summary>
        private Object content;

        /// <summary>
        ///  Maintains the category of the groupbar.
        /// </summary>
        private object category;

        /// <summary>
        ///  Maintains the selected category for groupbar.
        /// </summary>
        private Object selectedCategory;

        /// <summary>
        /// Gets or sets the header <see cref="SubItemModel"/> class.
        /// </summary>
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                if (header != value)
                {
                    header = value;
                    RaisePropertyChanged("Header");
                }
            }
        }

        /// <summary>
        /// Gets or sets the source <see cref="SubItemModel"/> class.
        /// </summary>
        public ImageSource Source
        {
            get
            {
                return source;
            }
            set
            {
                if (source != value)
                {
                    source = value;
                    RaisePropertyChanged("Source");
                }
            }
        }

        /// <summary>
        /// Gets or sets the content <see cref="SubItemModel"/> class.
        /// </summary>
        public object Content
        {
            get
            {
                return content;
            }
            set
            {
                if (content != value)
                {
                    content = value;
                    RaisePropertyChanged("Content");
                }
            }
        }

        /// <summary>
        /// Gets or sets the category <see cref="SubItemModel"/> class.
        /// </summary>
        public object Category
        {
            get
            {
                return category;
            }
            set
            {
                if (category != value)
                {
                    category = value;
                    RaisePropertyChanged("Category");
                }
            }
        }

        /// <summary>
        /// Gets or sets the selected category <see cref="SubItemModel"/> class.
        /// </summary>
        public object SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                RaisePropertyChanged("SelectedCategory");
            }
        }
    }
}
