#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.PropertyGrid;
using System;
using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.propertygriddemos.wpf
{
    [Editor("Mobile", typeof(MobileNoEditor))]
    public class RuntimePerson
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MaritalStatus { get; set; }
        public Bank Bank { get; set; }
        public string Email { get; set; }
        public int Age { get; set; }
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public Brush FavoriteColor { get; set; }
        public bool IsPermanent { get; set; }
        public string Key { get; set; }
        public string ID { get; set; }
        public Country Country { get; set; }
        public object Mobile { get; set; }

        public RuntimePerson()
        {
            FirstName = "Carl";
            LastName = "Johnson";
            Age = 30;
            Mobile = 91983467382;
            Email = "carljohnson@gmail.com";
            ID = "0005A";
            FavoriteColor = Brushes.Gray;
            IsPermanent = true;
            DOB = new DateTime(1987, 10, 16);
            Key = "dasd798@79hiujodsa';psdoiu9*(Uj0JK)(";
            Bank = new Bank()
            {
                Name = "Centura Banks",
                AccountNumber = 00987453721,
                CustomerID = "carljohnson",
                Password = "nuttertools",
                Address = new Address()
                {
                    State = "New Yark",
                    DoorNo = 87,
                    StreetName = "Martin street"
                }
            };
        }
        public class MobileNoEditor : MaskEditor
        {
            public MobileNoEditor()
            {
                Mask = @"\(\d{3}\) \d{3} - \d{4}";
            }
        }
    }
}
