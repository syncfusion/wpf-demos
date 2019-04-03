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
using System.Collections.ObjectModel;

namespace RightToLeftSupport
{
    public class RightToLeftSupportViewModel
    {
        public RightToLeftSupportViewModel()
        {
            this.RTLModel = new ObservableCollection<RTLDataViewModel>();
            RTLModel.Add(new RTLDataViewModel() { YEAR = 2002, EXPORT = 50, IMPORT = 80 });
            RTLModel.Add(new RTLDataViewModel() { YEAR = 2003, EXPORT = 88, IMPORT = 50 });
            RTLModel.Add(new RTLDataViewModel() { YEAR = 2004, EXPORT = 66, IMPORT = 78 });
            RTLModel.Add(new RTLDataViewModel() { YEAR = 2005, EXPORT = 35, IMPORT = 85 });
            RTLModel.Add(new RTLDataViewModel() { YEAR = 2006, EXPORT = 67, IMPORT = 90 });
            RTLModel.Add(new RTLDataViewModel() { YEAR = 2007, EXPORT = 70, IMPORT = 95 });
            RTLModel.Add(new RTLDataViewModel() { YEAR = 2008, EXPORT = 40, IMPORT = 67 });
        }

        public ObservableCollection<RTLDataViewModel> RTLModel { get; set; }


    }
}
