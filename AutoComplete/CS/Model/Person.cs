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

namespace SfAutoCompleteDemo
{
    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Image { get; set; }

        public string Designation { get; set; }
      

        public Person(string name, int age, string image, string designation)
        {
            Name = name;
            Age = age;
            Image = image;
            Designation = designation;            
        }
    }
}
