#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Edit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace MultiLevelIntellisenseDemo
{
    public class Model : IIntellisenseItem
    {
        public Model()
        {

        }

        /// <summary>
        /// Gets or sets a value indicating Icon to be displayed in the IntelliSenseListBox
        /// </summary>
        public ImageSource Icon
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a value indicating Text to be displayed in the IntelliSenseListBox
        /// </summary>
        public string Text
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets a collection of sub-items to be displayed
        /// </summary>
        public IEnumerable<IIntellisenseItem> NestedItems
        {
            get;
            set;
        }
    }
}
