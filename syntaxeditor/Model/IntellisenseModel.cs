#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Edit;
using System.Collections.Generic;
using System.Windows.Media;

namespace syncfusion.syntaxeditordemos.wpf
{
    public class IntellisenseModel : NotificationObject, IIntellisenseItem
    {
        /// <summary>
        /// Maintains a value indicating Icon to be displayed in the IntelliSenseListBox
        /// </summary>
        private ImageSource icon;

        /// <summary>
        /// Maintains a value indicating Text to be displayed in the IntelliSenseListBox
        /// </summary>
        private string text;

        /// <summary>
        /// Maintains a collection of sub-items to be displayed
        /// </summary>
        private IEnumerable<IIntellisenseItem> nestedItems;

        /// <summary>
        /// Gets or sets a value indicating Icon to be displayed in the IntelliSenseListBox
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
        /// Gets or sets a value indicating Text to be displayed in the IntelliSenseListBox
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
        /// Gets or sets a collection of sub-items to be displayed
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
