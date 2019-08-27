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
using System.ComponentModel;
using Syncfusion.Windows.Controls.Grid;
using System.Text.RegularExpressions;
using System.Windows.Media;
using System.Windows;
using System.Windows.Media.Imaging;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using CellStyleDemo;

namespace CellStyleDemo
{
    class ViewModel
    {
        private static Random random = new Random(123123);
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            this.PersonDetails = this.CreateGenericPersonData(5, 8);
        }

        private ObservableCollection<PersonInfo> _PersonDetails;

        /// <summary>
        /// Gets or sets the person details.
        /// </summary>
        /// <value>The person details.</value>
        public ObservableCollection<PersonInfo> PersonDetails
        {
            get { return _PersonDetails; }
            set { _PersonDetails = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        public ViewModel(int count, int maxGenerations)
        {
            CreateGenericPersonData(count, maxGenerations);
        }

        private List<string> _comboBoxItemsSource = new List<string>();

        public List<string> ComboBoxItemsSource
        {
            get { return _comboBoxItemsSource; }
            set { _comboBoxItemsSource = value; }
        }


        /// <summary>
        /// Creates the child list.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        /// <param name="lastName">The last name.</param>
        /// <returns></returns>
        public ObservableCollection<PersonInfo> CreateChildList(int count, int maxGenerations, string lastName)
        {
            ObservableCollection<PersonInfo> _children = new ObservableCollection<PersonInfo>();
            if (count > 0 && maxGenerations > 0)
            {
                _children = CreateGenericPersonData(count, maxGenerations - 1);
                foreach (PersonInfo p in _children)
                    p.LastName = lastName;
            }
            return _children;
        }

        /// <summary>
        /// Creates the generic person data.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        /// <returns></returns>
        public ObservableCollection<PersonInfo> CreateGenericPersonData(int count, int maxGenerations)
        {
            var personList = new ObservableCollection<PersonInfo>();
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var lastname = names2[random.Next(names2.GetLength(0))];
                    var isAvailable = i % 3 == 0 ? true : false;
                    personList.Add(new PersonInfo()
                    {
                        FirstName = names1[random.Next(names1.GetLength(0))],
                        LastName = lastname,
                        Children = this.CreateChildList(count, (int)Math.Max(0, maxGenerations - 1), lastname),
                        MyEyeColor = color[random.Next(color.GetLength(0))],
                        Salary = 300d + random.Next(9) * 10000,
                        Availability = isAvailable,
                        DOB = GenerateRandomDate(),
                        Hike = hike[random.Next(hike.GetLength(0))],
                    });
                    if (!_comboBoxItemsSource.Contains(personList.FirstOrDefault().LastName))
                        _comboBoxItemsSource.Add(personList.FirstOrDefault().LastName);
                }
            }
            return personList;
        }

        /// <summary>
        /// Generates the random date.
        /// </summary>
        /// <returns></returns>
        private DateTime GenerateRandomDate()
        {
            int randInt = random.Next(4000);
            return DateTime.Now.AddDays(-8000 + randInt);
        }

        #region Array Collection

        private static string[] names1 = new string[]{
            "George","John","Thomas","James","Andrew","Martin","William","Zachary",
            "Millard","Franklin","Abraham","Ulysses","Rutherford","Chester","Grover","Benjamin",
            "Theodore","Woodrow","Warren","Calvin","Herbert","Franklin","Harry","Dwight","Lyndon",
            "Richard","Gerald","Jimmy","Ronald","George","Bill", "Barack", "Warner","Peter", "Larry"
        };

        private static double[] hike = new double[]{
            6,5.5,10,10.2,11, 15, 6.8,14,7.7,9.5,8.2,16
        };


        private static string[] names2 = new string[]{
             "Washington","Adams","Jefferson","Madison","Monroe","Jackson","Van Buren","Harrison","Tyler",
             "Polk","Taylor","Fillmore","Pierce","Buchanan","Lincoln","Johnson","Grant","Hayes","Garfield",
             "Arthur","Cleveland","Harrison","McKinley","Roosevelt","Taft","Wilson","Harding","Coolidge",
             "Hoover","Truman","Eisenhower","Kennedy","Johnson","Nixon","Ford","Carter","Reagan","Bush",
             "Clinton","Bush","Obama","Smith","Jones","Stogner"
        };
        private static string[] color = new string[]{
            "Red", "Blue", "Brown", "Unknown"
        };
        #endregion
    }
}
