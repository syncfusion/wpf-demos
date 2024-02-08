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

namespace syncfusion.chartdemos.wpf
{
    public class StackedArea100ViewModel
    {
        public ObservableCollection<StackedArea100Model> EmissionData { get; set; }
        public StackedArea100ViewModel()
        {
            this.EmissionData = new ObservableCollection<StackedArea100Model>()
       {
       new StackedArea100Model() { Year = "2000", Peru = 20, Canada = 32, Ethiopia = 16, Mali = 24 },
       new StackedArea100Model() { Year = "2001", Peru = 13, Canada = 34, Ethiopia = 17, Mali = 32 },
       new StackedArea100Model() { Year = "2002", Peru = 14, Canada = 38, Ethiopia = 31, Mali = 27 },
       new StackedArea100Model() { Year = "2003", Peru = 17, Canada = 44, Ethiopia = 27, Mali = 34 },
       new StackedArea100Model() { Year = "2004", Peru = 16, Canada = 48, Ethiopia = 28, Mali = 43 },
       new StackedArea100Model() { Year = "2005", Peru = 23, Canada = 41, Ethiopia = 32, Mali = 45 },
       new StackedArea100Model() { Year = "2006", Peru = 23, Canada = 40, Ethiopia = 46, Mali = 51 },
       new StackedArea100Model() { Year = "2007", Peru = 27, Canada = 40, Ethiopia = 47, Mali = 76 },
       new StackedArea100Model() { Year = "2008", Peru = 27, Canada = 40, Ethiopia = 51, Mali = 85 },
       new StackedArea100Model() { Year = "2009", Peru = 32, Canada = 35, Ethiopia = 55, Mali = 86 },
       new StackedArea100Model() { Year = "2010", Peru = 40, Canada = 35, Ethiopia = 58, Mali = 87 },
          };
        }
    }
}
