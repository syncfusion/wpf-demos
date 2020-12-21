#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
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

namespace syncfusion.treegriddemos.wpf
{
    public class DataValidationViewModel
    {
        private static Random random = new Random(123123);
        /// <summary>
        /// Initializes a new instance of the <see cref="DataValidationViewModel"/> class.
        /// </summary>
        public DataValidationViewModel()
        {
            this.PersonDetails = this.CreateGenericPersonData(5, 8);
        }

        private ObservableCollection<DataValidationModel> _PersonDetails;

        /// <summary>
        /// Gets or sets the person details.
        /// </summary>
        /// <value>The person details.</value>
        public ObservableCollection<DataValidationModel> PersonDetails
        {
            get { return _PersonDetails; }
            set { _PersonDetails = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DataValidationViewModel"/> class.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="maxGenerations">The max generations.</param>
        public DataValidationViewModel(int count, int maxGenerations)
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
        public ObservableCollection<DataValidationModel> CreateChildList(int count, int maxGenerations, string lastName)
        {
            ObservableCollection<DataValidationModel> _children = new ObservableCollection<DataValidationModel>();
            if (count > 0 && maxGenerations > 0)
            {
                _children = CreateGenericPersonData(count, maxGenerations - 1);
                foreach (DataValidationModel p in _children)
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
        public ObservableCollection<DataValidationModel> CreateGenericPersonData(int count, int maxGenerations)
        {
            var personList = new ObservableCollection<DataValidationModel>();
            if (count > 0)
            {
                for (int i = 0; i < count; i++)
                {
                    var lastname = names2[random.Next(names2.GetLength(0))];
                    var firstName = names1[random.Next(names1.GetLength(0))];
                    personList.Add(new DataValidationModel()
                    {
                        ID = 1000 + i,
                        FirstName = firstName,
                        LastName = lastname,
                        Children = this.CreateChildList(count, (int)Math.Max(0, maxGenerations - 1), lastname),
                        MyEyeColor = color[random.Next(color.GetLength(0))],
                        DOB = GenerateRandomDate(),
                        Salary = random.Next(9000, 31000),
                        ContactNo = contactNos[random.Next(0, contactNos.Count() - 1)],
                        EMail = firstName + "@" + mail[random.Next(0, mail.Count() - 1)] + ".com"
                    });
                    if (!_comboBoxItemsSource.Contains(personList.FirstOrDefault().LastName))
                        _comboBoxItemsSource.Add(personList.FirstOrDefault().LastName);
                }
            }
            return personList;
        }

        string[] mail = new string[]
        {
            "gmail", "yahoo", "msn", "hotmail","ymail", "live"
        };


        string[] contactNos = new string[] { 
        "(833) 215-6503",
        "(855) 727-4387",
        "(844) 479-2783",
        "(855) 055-5922",
        "(899) 378-8810",
        "(833) 389-76618",
        "(855) 313-1072",
        "(899) 287-1193",
        "(844) 613-4240",
        "(833) 293-9651", 
        "(899) 751-7249",
        "(833) 266-3598",
        "(855) 117-36707",
        "(811) 638-39931",
        "(833) 444-7832",
        "(899) 995-59379",
        "(899) 544-1240",
        "(811) 892-78532",
        "(844) 080-8130",
        "(899) 256-2942"
        };


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
            "George","Dariech Jhon","John","Thomas","James","Andrew","Martin","William","Zachar~y","Tai'aty",
            "Millard","Franklin","Abraham","Ulysses","Rutherford","Chester","Grover","Benjamin","Umm-que",
            "Theodore","Woodrow","Warren","Calvin","Herbert","Franklin","Harry","Dwight","Lyndon",
            "Richard","Gerald","Jimmy","Ronald","George","Bill", "Barack", "Warner","Peter", "Larry"
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
