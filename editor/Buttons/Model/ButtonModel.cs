#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace syncfusion.editordemos.wpf
{
    public class ButtonModel : NotificationObject
    {
        /// <summary>
        /// Specifies the dropdown item name.
        /// </summary>
        private string name;

        /// <summary>
        /// Specifies the ImageTemplate to add inside the dropdown item. 
        /// </summary>
        private DataTemplate imageTemplate;

        /// <summary>
        /// Gets or sets the name for the dropdown item to be displayed when press the button control <see cref="ButtonModel"/> class.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                {
                    name = value;
                    RaisePropertyChanged("Name");
                }
            }
        }

        /// <summary>
        /// Gets or sets the ImageTemplate for the dropdown item to be displayed when press the button control <see cref="ButtonModel"/> class.
        /// </summary>
        public DataTemplate ImageTemplate
        {
            get
            {
                return imageTemplate;
            }
            set
            {
                if (imageTemplate != value)
                {
                    imageTemplate = value;
                    RaisePropertyChanged("ImageTemplate");
                }
            }
        }
    }
}
