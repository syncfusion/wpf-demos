#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace syncfusion.propertygriddemos.wpf
{
    public class BuiltInEditorViewModel : NotificationObject
    {
        #region Properties
        private BuildInPerson person;

        /// <summary>
        /// Gets or sets a value indicating whether to allow grouping the properties.
        /// </summary>

        public BuildInPerson Person
        {
            get
            {
                return person;
            }
            set
            {
                person = value;
                this.RaisePropertyChanged(() => this.Person);
            }
        }
        #endregion

        public BuiltInEditorViewModel()
        {
            Person = new BuildInPerson();
            Person.EmployeeName = "Carl";
            Person.Mobile = 9848848588;
            Person.Email = "carljohnson@gta.com";
            Person.FavoriteColor = Brushes.Gray;
            Person.IsActive = true;
            Person.DOB = new DateTime(1987, 10, 16);
            Person.Customers = new ObservableCollection<CustomerDetails>()
            {
                new CustomerDetails()
                {
                    CustomerID = "ALFKI",
                    EmployeeID = "0001A",
                    CompanyName = "Alfreds Futterkiste",
                    ContactName = "Maria Anders",
                    Country = "Germany",
                },
                new CustomerDetails()
                {
                    CustomerID = "AROUT",
                    EmployeeID = "0001B",
                    CompanyName = "Around the Horn",
                    ContactName = "Thomas Hardy",
                    Country = "UK",
                }
            };

            Person.Rating = double.Parse("4.5");
            Person.WorkedHours = new TimeSpan(8, 0, 0);
        }
    }
}