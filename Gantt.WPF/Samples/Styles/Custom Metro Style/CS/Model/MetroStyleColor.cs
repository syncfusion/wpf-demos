#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace CustomMetroStyle
{
    /// <summary>
    /// Class contains Metro Style Names and Corrsponding Brushes
    /// </summary>
    public class MetroStyleColor
    {
        public Brush Brush { get; set; }
        public string Name { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MetroStyleColor"/> class.
        /// </summary>
        public MetroStyleColor()
        {
        }
    }
}
