#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Windows.Interactivity;
using System.Windows.Media;
using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;

namespace CardViewDemo
{
    public enum Gender
    {
        Female,

        Male
    }

    public  class ViewModel : NotificationObject
    {
        private ObservableCollection<Model> contacts;
        public ObservableCollection<Model> Contacts
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

        public ViewModel()
        {
            Contacts = new ObservableCollection<Model>();
            Contacts.Add(new Model() { FirstName = "John", LastName = "Paulin", Age = 26, DOB = DateTime.Parse("1986-10-12"), Gender = Gender.Male, Email = "paulin@hotmail.com" });
            Contacts.Add(new Model() { FirstName = "Mark", LastName = "Waugh", Age = 25, DOB = DateTime.Parse("1986-01-12"), Gender = Gender.Male, Email = "mark@yahoo.com" });
            Contacts.Add(new Model() { FirstName = "Steven", LastName = "Wilkinson", Age = 26, DOB = DateTime.Parse("1985-01-02"), Gender = Gender.Male, Email = "Steven@ymail.com" });
            Contacts.Add(new Model() { FirstName = "Maria", LastName = "Paulin", Age = 35, DOB = DateTime.Parse("1976-02-01"), Gender = Gender.Female, Email = "James@yahoo.com" });
            Contacts.Add(new Model() { FirstName = "Will", LastName = "Smith", Age = 28, DOB = DateTime.Parse("1983-07-01"), Gender = Gender.Male, Email = "Smith@yahoo.com" });
            Contacts.Add(new Model() { FirstName = "John", LastName = "David", Age = 31, DOB = DateTime.Parse("1980-05-17"), Gender = Gender.Male, Email = "Johndav@gmail.com" });
            Contacts.Add(new Model() { FirstName = "David", LastName = "Stephen", Age = 31, DOB = DateTime.Parse("1980-06-2"), Gender = Gender.Male, Email = "david@ymail.com" });
            Contacts.Add(new Model() { FirstName = "Steven", LastName = "Wilkinson", Age = 31, DOB = DateTime.Parse("1980-09-25"), Gender = Gender.Male, Email = "Steven@hotmail.com" });
            Contacts.Add(new Model() { FirstName = "Maria", LastName = "Robert", Age = 28, DOB = DateTime.Parse("1983-01-25"), Gender = Gender.Female, Email = "Mariarb@rediff.com" });
            Contacts.Add(new Model() { FirstName = "Julee", LastName = "Smith", Age = 28, DOB = DateTime.Parse("1983-04-01"), Gender = Gender.Female, Email = "Julee@yahoo.com" });
            Contacts.Add(new Model() { FirstName = "James", LastName = "kelvin", Age = 38, DOB = DateTime.Parse("1973-05-30"), Gender = Gender.Male, Email = "james@hotmail.com" });
            Contacts.Add(new Model() { FirstName = "David", LastName = "Will", Age = 25, DOB = DateTime.Parse("1986-01-12"), Gender = Gender.Male, Email = "david1971@rediff.com" });
            Contacts.Add(new Model() { FirstName = "John", LastName = "David", Age = 26, DOB = DateTime.Parse("1986-11-30"), Gender = Gender.Male, Email = "kelvin@yahoo.com" });
            Contacts.Add(new Model() { FirstName = "Mary", LastName = "Smith", Age = 25, DOB = DateTime.Parse("1986-10-25"), Gender = Gender.Female, Email = "mary@rediff.com" });
            Contacts.Add(new Model() { FirstName = "John", LastName = "David", Age = 25, DOB = DateTime.Parse("1986-03-29"), Gender = Gender.Male, Email = "thomas@gmail.com" });
        }
    }
    /// <summary>
    /// Rule for gender
    /// </summary>
    public class GenderValidationRule : ValidationRule
    {
        public override System.Windows.Controls.ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var result = new System.Windows.Controls.ValidationResult(true, null);
            if (!value.ToString().ToLower().Equals("male") && !value.ToString().ToLower().Equals("female"))
            {
                result = new System.Windows.Controls.ValidationResult(false, "Gender should be Male of Female");
            }
            return result;
        }
    }
    /// <summary>
    /// 
    /// </summary>
   

    public class CancelEditingBehavior : Behavior<UIElement>
    {
      protected override void OnAttached()
      {
         AssociatedObject.PreviewKeyDown += (sender, e) => 
         {
            if (sender is CardView)
            {
                var cardview = sender as CardView;
                if (cardview.SelectedItem != null)
                {
                    var cardviewItem = cardview.ItemsSource != null
                        ? (CardViewItem)cardview.ItemContainerGenerator.ContainerFromItem(cardview.SelectedItem)
                        : (CardViewItem)cardview.SelectedItem;
                    if (cardviewItem != null && cardviewItem.IsInEditMode)
                    {
                        if (e.Key == Key.Escape)
                        {
                            if (cardviewItem.DataContext is Model)
                                e.Handled = !(cardviewItem.DataContext as Model).ValidationSuccess;
                        }
                    }
                }

            }
         };
      }
    }  
}
