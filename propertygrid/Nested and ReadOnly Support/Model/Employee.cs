#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace syncfusion.propertygriddemos.wpf
{
    public class Employee
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public Address Address { get; set; }
        public override string ToString()
        {
            return GetType().Name;
        }
    }
}
