#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SfAutoCompleteDemo
{
    public class Person
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public TimeSpan Interval { get; set; }

        public string Position { get; set; }

        public string OrganizationUnit { get; set; }

        public string DateOfBirth { get; set; }

        public string Location { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string TileColor { get; set; }

        public string HeaderColor { get; set; }

        public Person(string name, string image, double seconds, string position, string organizationunit, string dateofbirth, string location, string phone, string email, string color, string headercolor)
        {
            Name = name;
            Image = image;
            Interval = TimeSpan.FromSeconds(seconds);
            Position = position;
            OrganizationUnit = organizationunit;
            DateOfBirth = dateofbirth;
            Location = location;
            Phone = phone;
            Email = email;
            TileColor = color;
            HeaderColor = headercolor;
        }
    }
}
