#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace CardViewDemo
{
    class Model : NotificationObject
    {
        private ObservableCollection<ViewModel> contacts;
        public ObservableCollection<ViewModel> Contacts
        {
            get
            {
                return contacts;
            }
            set
            {
                contacts = value;
                this.RaisePropertyChanged("Contacts");
            }
        }
        public Model()
        {
            Contacts = new ObservableCollection<ViewModel>();
            Contacts.Add(new ViewModel() { FirstName = "John", LastName = "Paulin", Age = 26, DOB = DateTime.Parse("1986-10-12"), Gender = Gender.Male, Email = "paulin@hotmail.com" });
            Contacts.Add(new ViewModel() { FirstName = "Mark", LastName = "Waugh", Age = 25, DOB = DateTime.Parse("1986-01-12"), Gender = Gender.Male, Email = "mark@yahoo.com" });
            Contacts.Add(new ViewModel() { FirstName = "Steven", LastName = "Wilkinson", Age = 26, DOB = DateTime.Parse("1985-01-02"), Gender = Gender.Male, Email = "Steven@ymail.com" });
            Contacts.Add(new ViewModel() { FirstName = "Maria", LastName = "Paulin", Age = 35, DOB = DateTime.Parse("1976-02-01"), Gender = Gender.Female, Email = "James@yahoo.com" });
            Contacts.Add(new ViewModel() { FirstName = "Will", LastName = "Smith", Age = 28, DOB = DateTime.Parse("1983-07-01"), Gender = Gender.Male, Email = "Smith@yahoo.com" });
            Contacts.Add(new ViewModel() { FirstName = "John", LastName = "David", Age = 31, DOB = DateTime.Parse("1980-05-17"), Gender = Gender.Male, Email = "Johndav@gmail.com" });
            Contacts.Add(new ViewModel() { FirstName = "David", LastName = "Stephen", Age = 31, DOB = DateTime.Parse("1980-06-2"), Gender = Gender.Male, Email = "david@ymail.com" });
            Contacts.Add(new ViewModel() { FirstName = "Steven", LastName = "Wilkinson", Age = 31, DOB = DateTime.Parse("1980-09-25"), Gender = Gender.Male, Email = "Steven@hotmail.com" });
            Contacts.Add(new ViewModel() { FirstName = "Maria", LastName = "Robert", Age = 28, DOB =DateTime.Parse("1983-01-25"), Gender = Gender.Female, Email = "Mariarb@rediff.com" });
            Contacts.Add(new ViewModel() { FirstName = "Julee", LastName = "Smith", Age = 28, DOB = DateTime.Parse("1983-04-01"), Gender = Gender.Female, Email = "Julee@yahoo.com" });
            Contacts.Add(new ViewModel() { FirstName = "James", LastName = "kelvin", Age = 38, DOB = DateTime.Parse("1973-05-30"), Gender = Gender.Male, Email = "james@hotmail.com" });
            Contacts.Add(new ViewModel() { FirstName = "David", LastName = "Will", Age = 25, DOB = DateTime.Parse("1986-01-12"), Gender = Gender.Male, Email = "david1971@rediff.com" });
            Contacts.Add(new ViewModel() { FirstName = "John", LastName = "David", Age = 26, DOB = DateTime.Parse("1986-11-30"), Gender = Gender.Male, Email = "kelvin@yahoo.com" });
            Contacts.Add(new ViewModel() { FirstName = "Mary", LastName = "Smith", Age = 25, DOB = DateTime.Parse("1986-10-25"), Gender = Gender.Female, Email = "mary@rediff.com" });
            Contacts.Add(new ViewModel() { FirstName = "John", LastName = "David", Age = 25, DOB = DateTime.Parse("1986-03-29"), Gender = Gender.Male, Email = "thomas@gmail.com" }); 
        }
    }
}
