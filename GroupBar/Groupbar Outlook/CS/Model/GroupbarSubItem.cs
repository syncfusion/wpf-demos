#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace GroupbarOutlookDemo
{
    /// <summary>
    /// Represents groupbar sub item.
    /// </summary>
    public class GroupbarSubItem : INotifyPropertyChanged
    {
        #region Fields
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
        #endregion

        #region Event
        /// <summary>
        /// Initialize the event which notifies when the selected item changes. 
        /// </summary> 
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Methods
        /// <summary>
        /// Event handling method for notified changes.
        /// </summary>
        /// <param name="name">Notifies when changes occured</param>
        private void Notify(string name)
        {
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion
       
        #region Properties
        /// <summary>
        /// Gets or sets the header.
        /// </summary>
        [Category("Summary")]
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                if (header != value)
                    header = value;
            }
        }

        /// <summary>
        /// Gets or sets the source.
        /// </summary>
        [Category("Summary")]
        public ImageSource Source
        {
            get
            {
                return source;
            }
            set
            {
                if (source != value)
                    source = value;
            }
        }

        /// <summary>
        /// Gets or sets the content.
        /// </summary>
        [Category("Summary")]
        public object Content
        {
            get
            {
                return content;
            }
            set
            {
                if (content != value)
                    content = value;
            }
        }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        [Category("Summary")]
        public object Category
        {
            get
            {
                return category;
            }
            set
            {
                if (category != value)
                    category = value;
            }
        }

        /// <summary>
        /// Gets or sets the selected category.
        /// </summary>
        [Category("Summary")]
        public object SelectedCategory
        {
            get { return selectedCategory; }
            set
            {
                selectedCategory = value;
                Notify("SelectedCategory");
            }
        }
        #endregion
    }
}
