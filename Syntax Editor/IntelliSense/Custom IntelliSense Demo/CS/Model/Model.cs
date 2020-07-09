#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Edit;
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CustomIntellisenseDemo
{
    public class CustomIntellisenseItem : NotificationObject, IIntellisenseItem
    {
        /// <summary>
        /// MAintains the icon of the intellisense item
        /// </summary>
        private ImageSource icon;

        /// <summary>
        /// MAintains the text of the intellisense item
        /// </summary>
        private string text;

        /// <summary>
        /// Maintains the enumerable collection of items
        /// </summary>
        private IEnumerable<IIntellisenseItem> nestedItems;

        /// <summary>
        /// Gets or sets the icon of the intellisense item
        /// </summary>
        public ImageSource Icon
        {
            get
            {
                return icon;
            }
            set
            {
                icon = value;
                RaisePropertyChanged("Icon");
            }
        }

        /// <summary>
        /// Gets or sets the text of the intellisense item
        /// </summary>
        public string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                RaisePropertyChanged("Text");
            }
        }

        /// <summary>
        /// Gets or sets the enumerable collection of items
        /// </summary>
        public IEnumerable<IIntellisenseItem> NestedItems
        {
            get
            {
                return nestedItems;
            }
            set
            {
                nestedItems = value;
                RaisePropertyChanged("NestedItems");
            }
        }
    }
}
