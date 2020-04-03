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

namespace AutomaticLayout_RadialTreeLayout
{
    public class Employee
    {
        public string EmpId { get; set; }
        public string Imageurl { get; set; }
        public string ParentId { get; set; }
    }


    public class Employees : ObservableCollection<Employee>
    {

    }
}
