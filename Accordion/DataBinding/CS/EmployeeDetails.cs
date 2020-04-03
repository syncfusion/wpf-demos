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
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace DataBinding
{
    /// <summary>
    /// Represents the class of employee details.
    /// </summary>
    public class EmployeeDetails
    {
        #region Fields
        /// <summary>
        ///  Maintains the collection of employee details.
        /// </summary>
        private ObservableCollection<Person> _employee;
        #endregion

        #region Constructor
        /// <summary>
        ///  Initializes a new instance of the <see cref="EmployeeDetails" /> class.
        /// </summary>
        public EmployeeDetails()
        {
            Employees = new ObservableCollection<Person>();
            Employees.Add(new Person("Eric Joplin", new BitmapImage(new Uri("pack://application:,,,/DataBinding;Component/Images/Emp_02.png")), "Chairman", "Management", "27/09/1973", "Boston", "+800 9899 9929", "ericjoplin@syncfusion.com", "#FFA400", "#E78E00"));
            Employees.Add(new Person("Paul Vent", new BitmapImage(new Uri("pack://application:,,,/DataBinding;Component/Images/Emp_04.png")), "Chief Executive Officer", "Management", "27/09/1975", "New York", "+800 9899 9930", "paulvent@syncfusion.com", "#6DA4A3", "#4E7F7D"));
            Employees.Add(new Person("Clara Venus", new BitmapImage(new Uri("pack://application:,,,/DataBinding;Component/Images/Emp_06.png")), "Chief Executive Assistant", "Management", "27/09/1978", "California", "+800 9899 9931", "claravenus@syncfusion.com", "#A45378", "#883F64"));
            Employees.Add(new Person("Maria Even", new BitmapImage(new Uri("pack://application:,,,/DataBinding;Component/Images/Emp_11.png")), "Executive Manager", "Operational Unit", "27/09/1970", "New York", "+800 9899 9932", "mariaeven@syncfusion.com", "#DA9545", "#BB7731"));
            Employees.Add(new Person("Mark Zuen", new BitmapImage(new Uri("pack://application:,,,/DataBinding;Component/Images/Emp_13.png")), "Senior Executive", "Operational Unit", "27/09/1983", "Boston", "+800 9899 9933", "markzuen@syncfusion.com", "#AC3832", "#8B2826"));
                }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the employee details.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<Person> Employees
        {
            get { return _employee; }
            set { _employee = value; }
        }
        #endregion

        #region Helper methods
        /// <summary>
        /// Dispose the employee details.
        /// </summary>
        public void Dispose()
        {
            if (Employees != null)
            {
                Employees.Clear();
            }

        }
        #endregion
    }

    /// <summary>
    /// Represents a person class.
    /// </summary>
    public class Person
    {
        #region Field
        /// <summary>
        ///  Maintains the image details.
        /// </summary>
        private ImageSource image;

        /// <summary>
        ///  Maintains the name details.
        /// </summary>
        private string name;

        /// <summary>
        ///  Maintains the position details.
        /// </summary>
        private string position;

        /// <summary>
        ///  Maintains the organization unit details.
        /// </summary>
        private string organizationUnit;

        /// <summary>
        ///  Maintains the date of birth.
        /// </summary>
        private string dateOfBirth;

        /// <summary>
        ///  Maintains the location details.
        /// </summary>
        private string location;

        /// <summary>
        ///  Maintains the phone number.
        /// </summary>
        private string phone;

        /// <summary>
        ///  Maintains the email address.
        /// </summary>
        private string email;

        /// <summary>
        ///  Maintains the tile Color.
        /// </summary>
        private string tileColor;

        /// <summary>
        ///  Maintains the header color.
        /// </summary>
        private string headerColor;
        #endregion

        #region Constructor
        /// <summary>
        ///  Initializes a new instance of the <see cref="Person" /> class.
        /// </summary>
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
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the image details.
        /// </summary>
        [Category("Summary")]
        public ImageSource Image
        {
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        [Category("Summary")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        /// <summary>
        /// Gets or sets the position.
        /// </summary>
        [Category("Summary")]
        public string Position
        {
            get
            {
                return position;
            }
            set
            {
                position = value;
            }
        }

        /// <summary>
        /// Gets or sets the organization unit.
        /// </summary>
        [Category("Summary")]
        public string OrganizationUnit
        {
            get
            {
                return organizationUnit;
            }
            set
            {
                organizationUnit = value;
            }
        }

        /// <summary>
        /// Gets or sets date of birth.
        /// </summary>
        [Category("Summary")]
        public string DateOfBirth
        {
            get
            {
                return dateOfBirth;
            }
            set
            {
                dateOfBirth = value;
            }
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        [Category("Summary")]
        public string Location
        {
            get
            {
                return location;
            }
            set
            {
                location = value;
            }
        }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [Category("Summary")]
        public string Phone
        {
            get
            {
                return phone;
            }
            set
            {
                phone = value;
            }
        }

        /// <summary>
        /// Gets or sets the email address.
        /// </summary>
        [Category("Summary")]
        public string Email
        {
            get
            {
                return email;
            }
            set
            {
                email = value;
            }
        }

        /// <summary>
        /// Gets or sets the tile color.
        /// </summary>
        [Category("Summary")]
        public string TileColor
        {
            get
            {
                return tileColor;
            }
            set
            {
                tileColor = value;
            }
        }

        /// <summary>
        /// Gets or sets the header color.
        /// </summary>
        [Category("Summary")]
        public string HeaderColor
        {
            get
            {
                return headerColor;
            }
            set
            {
                headerColor = value;
            }
        }
        #endregion
    }
}
   
