#region Copyright Syncfusion Inc. 2001-2024.
// Copyright Syncfusion Inc. 2001-2024. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.navigationdemos.wpf
{
    public class Category
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        private object icon;
        public object Icon
        {
            get { return icon; }
            set { icon = value; }
        }
    }
}
