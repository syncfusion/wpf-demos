#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
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
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DataBinding
{
     class EmployeeDetails
    {
        public EmployeeDetails()
        {
            Employees = new ObservableCollection<Person>();
            // new BitmapImage(new Uri("pack://application:,,,/TreeMapCustomization;Component/Assets/Soccer.png"))
            Employees.Add(new Person("Eric Joplin", new BitmapImage(new Uri("pack://application:,,,/DataBinding;Component/Images/Emp_02.png")), "Chairman", "Management", "27/09/1973", "Boston", "+800 9899 9929", "ericjoplin@syncfusion.com", "#FFA400", "#E78E00"));
            Employees.Add(new Person("Paul Vent", new BitmapImage(new Uri("pack://application:,,,/DataBinding;Component/Images/Emp_04.png")), "Chief Executive Officer", "Management", "27/09/1975", "New York", "+800 9899 9930", "paulvent@syncfusion.com", "#6DA4A3", "#4E7F7D"));
            Employees.Add(new Person("Clara Venus", new BitmapImage(new Uri("pack://application:,,,/DataBinding;Component/Images/Emp_06.png")), "Chief Executive Assistant", "Management", "27/09/1978", "California", "+800 9899 9931", "claravenus@syncfusion.com", "#A45378", "#883F64"));
            Employees.Add(new Person("Maria Even", new BitmapImage(new Uri("pack://application:,,,/DataBinding;Component/Images/Emp_11.png")), "Executive Manager", "Operational Unit", "27/09/1970", "New York", "+800 9899 9932", "mariaeven@syncfusion.com", "#DA9545", "#BB7731"));
            Employees.Add(new Person("Mark Zuen", new BitmapImage(new Uri("pack://application:,,,/DataBinding;Component/Images/Emp_13.png")), "Senior Executive", "Operational Unit", "27/09/1983", "Boston", "+800 9899 9933", "markzuen@syncfusion.com", "#AC3832", "#8B2826"));
            ////Employees.Add(new Person("Robin Rane", "ms-appx:///Accordion/Images/Emp_16.png", "Manager", "Customer Service", "27/09/1985", "New Jersey", "+800 9899 9934", "robinrane@syncfusion.com", "#31A1FF", "#2394E1"));
            //Employees.Add(new Person("Chris Marker", "ms-appx:///Accordion/Images/Emp_21.png", "Team Manager", "Customer Service", "27/09/1963", "California", "+800 9899 9935", "chrismarker@syncfusion.com", "#5B5BA9", "#484892"));
            //Employees.Add(new Person("Seria Sum", "ms-appx:///Accordion/Images/Emp_23.png", "Coordinator", "Customer Service", "27/09/1961", "New York", "+800 9899 9936", "seriasum@syncfusion.com", "#597C2A", "#46601D"));
           // Employees.Add(new Person("Mathew Fleming", "ms-appx:///Accordion/Images/Emp_25.png", "Recruitment Manager", "Human Resource", "27/09/1986", "Boston", "+800 9899 9937", "mathewfleming@syncfusion.com", "#BCCBD3", "#8BA0A9"));
        }

        private ObservableCollection<Person> _employee;

        public ObservableCollection<Person> Employees
        {
            get { return _employee; }
            set { _employee = value; }
        }
        public void Dispose()
        {
            if (Employees != null)
            {
                Employees.Clear();
            }

        }

    }

    public class Person
    {
        public ImageSource Image { get; set; }
       
        public string Name { get; set; }

     //   public string Image { get; set; }

        public string Position { get; set; }

        public string OrganizationUnit { get; set; }

        public string DateOfBirth { get; set; }

        public string Location { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string TileColor { get; set; }

        public string HeaderColor { get; set; }

        public Person(string name, ImageSource image, string position, string organizationunit, string dateofbirth, string location, string phone, string email, string color, string headercolor)
        {
            Name = name;
            Image = image;
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
   
