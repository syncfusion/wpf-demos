#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

namespace AutomaticLayout_MultiParentLayout
{
    public class ItemInfo
    {
        public ItemInfo(string name, string color)
        {
            this.Name = name;
            this.RatingColor = color;
        }

        public string RatingColor { get; set; }

        public string Name { get; set; }

        public List<string> ReportingPerson { get; set; }
    }

    public class DataItems : ObservableCollection<ItemInfo>
    {

    }
}
