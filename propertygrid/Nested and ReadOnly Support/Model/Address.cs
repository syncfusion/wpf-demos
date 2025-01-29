#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace syncfusion.propertygriddemos.wpf
{
    public class Address
    {
        [Display(Description ="State where the employee home is located")]
        public string State { get; set; }

        [Display(Description = "StreetName where the employee home is located")]
        public string StreetName { get; set; }

        [Display(Description = "Door number of the employee home")]
        public int DoorNo { get; set; }
        public override string ToString()
        {
            return DoorNo.ToString() + ", " + StreetName + ", " + State;
        }
    }
}
