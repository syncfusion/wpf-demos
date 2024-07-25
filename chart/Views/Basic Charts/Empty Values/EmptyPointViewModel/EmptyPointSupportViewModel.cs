#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;

namespace syncfusion.chartdemos.wpf
{
    public class EmptyPointSupportViewModel : NotificationObject
    {
        public List<EmptyPointSupportModel> Data { get; set; }
        public List<string> ColorValue { get; set; }

        public EmptyPointSupportViewModel()
        {
            Data = new List<EmptyPointSupportModel>();
            Data.Add(new EmptyPointSupportModel("2007", double.NaN));
            Data.Add(new EmptyPointSupportModel("2008", 2));
            Data.Add(new EmptyPointSupportModel("2009", 1));
            Data.Add(new EmptyPointSupportModel("2010", null));
            Data.Add(new EmptyPointSupportModel("2011", 3));
            Data.Add(new EmptyPointSupportModel("2012", double.NaN));
            Data.Add(new EmptyPointSupportModel("2013", 1));
            Data.Add(new EmptyPointSupportModel("2014", null));
            Data.Add(new EmptyPointSupportModel("2015", 1));
            Data.Add(new EmptyPointSupportModel("2016", 4));

            ColorValue = new List<string>()
            {
                "Blue",
                "Violet",
                "Orange",
                "Pink",
            };
        }
    }
}
