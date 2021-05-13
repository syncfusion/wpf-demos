#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Syncfusion.Zugferd
{
    /// <summary>
    /// User Details
    /// </summary>
    public class UserDetails
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string ContactName { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public CountryCodes Country { get; set; }
        public string Street { get; set; }
    }
}
