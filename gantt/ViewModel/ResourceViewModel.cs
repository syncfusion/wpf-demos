#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.ganttdemos.wpf
{
   public class ResourceViewModel 
    {
        private ObservableCollection<Item> _teamDetails;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ResourceViewModel()
        {
            _teamDetails = GetTeamInfo();
        }

        /// <summary>
        /// Gets or sets the appointment item source.
        /// </summary>
        /// <value>The appointment item source.</value>
        public ObservableCollection<Item> TeamDetails
        {
            get
            {
                return _teamDetails;
            }
            set
            {
                _teamDetails = value;
            }
        }


        /// <summary>
        /// Gets the team info.
        /// </summary>
        /// <returns></returns>
        public ObservableCollection<Item> GetTeamInfo()
        {
            DateTime dtS = DateTime.Today;

            ObservableCollection<Item> teams = new ObservableCollection<Item>();

            teams.Add(new Item() { Name = "RDU Team" });
            Item Person = new Item() { Name = "Robert" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 07), FinishDate = new DateTime(2012, 01, 11), Name = "Market Analysis", Progress = 50d });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 11, 12, 0, 0), FinishDate = new DateTime(2012, 01, 17), Name = "Competitor Analysis", Progress = 20d });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 17, 12, 0, 0), FinishDate = new DateTime(2012, 01, 21), Name = "Design Spec" });
            teams[0].SubItems.Add(Person);

            Person = new Item() { Name = "Michael" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 14), FinishDate = new DateTime(2012, 01, 19), Name = "Basic Requirement Analysis", Progress = 40 });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 19, 12, 0, 0), FinishDate = new DateTime(2012, 01, 23), Name = "Requirement Spec" });
            teams[0].SubItems.Add(Person);

            Person = new Item() { Name = "Anne" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 21), FinishDate = new DateTime(2012, 01, 25), Name = "Estimation", Progress = 30 });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 25, 12, 0, 0), FinishDate = new DateTime(2012, 01, 29, 12, 0, 0), Name = "Budget & Plan Spec" });
            teams[0].SubItems.Add(Person);


            teams.Add(new Item() { Name = "Graphics Team" });
            Person = new Item() { Name = "Madhan" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 17), FinishDate = new DateTime(2012, 01, 21), Name = "Identifying UI modules", Progress = 40 });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 21, 12, 0, 0), FinishDate = new DateTime(2012, 01, 26), Name = "Defining UI Design" });
            teams[1].SubItems.Add(Person);

            Person = new Item() { Name = "Peter" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 21), FinishDate = new DateTime(2012, 01, 24), Name = "Designing Animagions", Progress = 40 });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 24, 12, 0, 0), FinishDate = new DateTime(2012, 01, 28), Name = "Completing Overall Graphics design" });
            teams[1].SubItems.Add(Person);


            teams.Add(new Item() { Name = "Dev Team" });
            Person = new Item() { Name = "Ruban" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 19), FinishDate = new DateTime(2012, 01, 22), Name = "Analysis", Progress = 30 });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 22, 12, 0, 0), FinishDate = new DateTime(2012, 01, 26), Name = "Defining Modules", Progress = 10 });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 26, 12, 0, 0), FinishDate = new DateTime(2012, 01, 30), Name = "Development Plan", Progress = 10 });
            teams[2].SubItems.Add(Person);

            Person = new Item() { Name = "Karthick" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 20), FinishDate = new DateTime(2012, 01, 22, 12, 0, 0), Name = "Analysis", Progress = 10 });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 23), FinishDate = new DateTime(2012, 1, 29), Name = "Module Development" });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 29, 12, 0, 0), FinishDate = new DateTime(2012, 02, 2), Name = "Self Testing" });
            teams[2].SubItems.Add(Person);

            Person = new Item() { Name = "Suyama" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 21), FinishDate = new DateTime(2012, 01, 24), Name = "Analysis", Progress = 10 });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 24, 12, 0, 0), FinishDate = new DateTime(2012, 01, 31), Name = "Module Development" });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 02, 1), FinishDate = new DateTime(2012, 02, 4), Name = "Self Testing" });
            teams[2].SubItems.Add(Person);

            Person = new Item() { Name = "Albert" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 27), FinishDate = new DateTime(2012, 01, 31), Name = "Modules Integration" });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 31, 12, 0, 0), FinishDate = new DateTime(2012, 02, 4), Name = "Integration Testing" });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 02, 5), FinishDate = new DateTime(2012, 02, 8, 12, 0, 0), Name = "Completeness" });
            teams[2].SubItems.Add(Person);


            teams.Add(new Item() { Name = "Doc Team" });
            Person = new Item() { Name = "Laura" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 02, 02), FinishDate = new DateTime(2012, 02, 07), Name = "User Guide Development", Progress = 10 });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 02, 08), FinishDate = new DateTime(2012, 02, 11), Name = "Publishing User Guide", Progress = 10 });
            teams[3].SubItems.Add(Person);

            Person = new Item() { Name = "Margaret" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 02, 05), FinishDate = new DateTime(2012, 02, 08), Name = "Web Conetent Development", Progress = 10 });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 02, 08, 12, 0, 0), FinishDate = new DateTime(2012, 02, 12), Name = "Publishing Web Conetent", Progress = 10 });
            teams[3].SubItems.Add(Person);


            teams.Add(new Item() { Name = "Sales Team" });
            Person = new Item() { Name = "Steven" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 13), FinishDate = new DateTime(2012, 01, 17), Name = "Defining Target", Progress = 80 });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 18), FinishDate = new DateTime(2012, 01, 22), Name = "Defining Startegy", Progress = 50 });
            teams[4].SubItems.Add(Person);

            Person = new Item() { Name = "Janet" };
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 01, 21), FinishDate = new DateTime(2012, 01, 26), Name = "Collect Customers list", Progress = 50 });
            Person.InLineItems.Add(new Item() { StartDate = new DateTime(2012, 02, 09), FinishDate = new DateTime(2012, 02, 14), Name = "Contacting Customer" });
            teams[4].SubItems.Add(Person);

            return teams;
        }

        internal void Dispose()
        {
            foreach(var teamDetail in TeamDetails)
            {
                teamDetail.Dispose();
            }
        }
    }
}