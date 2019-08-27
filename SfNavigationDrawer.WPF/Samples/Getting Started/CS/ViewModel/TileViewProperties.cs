#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NavigationDrawer
{
    public class TileViewProperties : NotificationObject
    {
        private Random rndm;

        private double GetInterval()
        {
            return rndm.Next(18, 25);
        }

        public TileViewProperties()
        {
            rndm = new Random();
            Images = new ObservableCollection<Person>();
            Images.Add(new Person("Eric Joplin", "/Assets/Emp_02.png", GetInterval(), "Chairman", "Management", "27/09/1973", "Boston", "+800 9899 9929", "ericjoplin@syncfusion.com", "#FFA400","#E78E00"));
            Images.Add(new Person("Paul Vent", "/Assets/Emp_04.png", GetInterval(), "CEO", "Management", "27/09/1975", "New York", "+800 9899 9930", "paulvent@syncfusion.com", "#6DA4A3", "#4E7F7D"));
            Images.Add(new Person("Clara Venus", "/Assets/Emp_06.png", GetInterval(), "CEA", "Management", "27/09/1978", "California", "+800 9899 9931", "claravenus@syncfusion.com", "#A45378", "#883F64"));
            Images.Add(new Person("Maria Even", "/Assets/Emp_11.png", GetInterval(), "Senior Manager", "Operational Unit", "27/09/1970", "New York", "+800 9899 9932", "mariaeven@syncfusion.com", "#DA9545", "#BB7731"));
            Images.Add(new Person("Mark Zuen", "/Assets/Emp_13.png", GetInterval(), "Senior Executive", "Operational Unit", "27/09/1983", "Boston", "+800 9899 9933", "markzuen@syncfusion.com", "#AC3832", "#8B2826"));
            Images.Add(new Person("Robin Rane", "/Assets/Emp_16.png", GetInterval(), "Manager", "Customer Service", "27/09/1985", "New Jersey", "+800 9899 9934", "robinrane@syncfusion.com", "#31A1FF", "#2394E1"));
            Images.Add(new Person("Chris Marker", "/Assets/Emp_21.png", GetInterval(), "Team Manager", "Customer Service", "27/09/1963", "California", "+800 9899 9935", "chrismarker@syncfusion.com", "#5B5BA9", "#484892"));
            Images.Add(new Person("Seria Sum", "/Assets/Emp_23.png", GetInterval(), "Coordinator", "Customer Service", "27/09/1961", "New York", "+800 9899 9936", "seriasum@syncfusion.com", "#597C2A", "#46601D"));
            Images.Add(new Person("Mathew Fleming", "/Assets/Emp_25.png", GetInterval(), "HR Manager", "Human Resource", "27/09/1986", "Boston", "+800 9899 9937", "mathewfleming@syncfusion.com", "#BCCBD3", "#8BA0A9"));
        }

        private ObservableCollection<Person> images;

        public ObservableCollection<Person> Images
        {
            get { return images; }
            set { images = value; }
        }

        private Orientation orientation = Orientation.Horizontal;

        public Orientation Orientation
        {
            get { return orientation; }
            set { orientation = value; RaisePropertyChanged("Orientation"); }
        }

        private MinimizedItemsOrientation minOrientation = MinimizedItemsOrientation.Right;

        public MinimizedItemsOrientation MinOrientation
        {
            get { return minOrientation; }
            set { minOrientation = value; RaisePropertyChanged("MinOrientation"); }
        }

        private bool allowDragging = false;

        public bool AllowDragging
        {
            get { return allowDragging; }
            set { allowDragging = value; RaisePropertyChanged("AllowDragging"); }
        }

    }

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

        public Person(string name, string image, double seconds,string position,string organizationunit,string dateofbirth,string location,string phone,string email,string color,string headercolor)
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

    public enum TileOrientation
    {
        Vertical,
        Horizontal
    }
}
