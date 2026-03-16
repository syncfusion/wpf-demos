#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.kanbandemos.wpf
{
    using System.Collections.Generic;
    using System.Collections.ObjectModel;

    /// <summary>
    /// Represents the ViewModel responsible for managing a collection of Kanban cards with sorting functionality.
    /// </summary>
    public class SortingViewModel
    {
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SortingViewModel"/> class.
        /// </summary>
        public SortingViewModel()
        {
            this.Cards = this.GetCardDetails();
            this.SortOptions = this.GetSortOptions();
            this.SortOrder = this.GetSortOrder();
            this.SortMappingPath = this.GetSortMappingPath();
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the collection of <see cref="CardDetails"/> objects representing cards in various stages.
        /// </summary>
        public ObservableCollection<CardDetails> Cards { get; set; }

        /// <summary>
        /// Gets or sets the collection of sorting options available for the Kanban cards.
        /// </summary>
        public ObservableCollection<string> SortOptions { get; set; }

        /// <summary>
        /// Gets or sets the collection defining the custom sort order for the Kanban cards.
        /// </summary>
        public ObservableCollection<string> SortOrder { get; set; }

        /// <summary>
        /// Gets or sets the collection defining the mapping paths for sorting the Kanban cards.
        /// </summary>
        public ObservableCollection<string> SortMappingPath { get; set; }

        #endregion

        #region Private methods

        /// <summary>
        /// Method to retrieve a predefined collection of Kanban cards with sorting metadata.
        /// </summary>
        /// <returns>The card collection.</returns>
        private ObservableCollection<CardDetails> GetCardDetails()
        {
            var cardDetails = new ObservableCollection<CardDetails>();

            cardDetails.Add(new CardDetails()
            {
                Index = 5,
                Priority = Priority.Medium,
                Title = "Task - 1",
                Category = "Open",
                Description = "Fix the issue reported in the IE browser",
                Progress = 0,
                Tags = new List<string> { "Analyze", "Bug" },
            });

            cardDetails.Add(new CardDetails()
            {
                Index = 2,
                Title = "Task - 3",
                Priority = Priority.Low,
                Category = "Open",
                Progress = 0,
                Description = "Analyze the new requirements gathered from the customer.",
                Tags = new List<string> { "Trial preparation" }
            });

            cardDetails.Add(new CardDetails()
            {
                Index = 3,
                Title = "Task - 4",
                Priority = Priority.Critical,
                Category = "Open",
                Progress = 0,
                Description = "Arrange a web meeting with the customer to get new requirements.",
                Tags = new List<string> { "Requirements Gathering" }
            });

            cardDetails.Add(new CardDetails()
            {
                Title = "Task - 2",
                Priority = Priority.High,
                Index = 4,
                Category = "In Progress",
                Progress = 40,
                Description = "Test the application in the Edge browser.",
                Tags = new List<string> { "Documentation" }
            });

            cardDetails.Add(new CardDetails()
            {
                Index = 1,
                Title = "Task - 5",
                Priority = Priority.Medium,
                Category = "Open",
                Progress = 0,
                Description = "Enhance editing functionality.",
                Tags = new List<string> { "Analyze" }
            });

            cardDetails.Add(new CardDetails()
            {
                Index = 7,
                Title = "Task - 6",
                Priority = Priority.Low,
                Category = "Open",
                Progress = 0,
                Description = "Arrange web meeting with the customer to show editing demo.",
                Tags = new List<string> { "Bug" }
            });

            cardDetails.Add(new CardDetails()
            {
                Index = 6,
                Title = "Task - 8",
                Priority = Priority.Medium,
                Category = "Done",
                Progress = 100,
                Description = "Improve application performance.",
                Tags = new List<string> { "Enhancement" }
            });

            cardDetails.Add(new CardDetails()
            {
                Index = 10,
                Title = "Task - 7",
                Priority = Priority.Critical,
                Category = "In Progress",
                Progress = 50,
                Description = "Fix cannot open user's default database SQL error.",
                Tags = new List<string> { "Trial preparation" }
            });

            cardDetails.Add(new CardDetails()
            {
                Title = "Task - 9",
                Priority = Priority.Medium,
                Index = 8,
                Category = "In Progress",
                Progress = 55,
                Description = "Improve the performance of the editing functionality.",
                Tags = new List<string> { "Bug" }
            });

            cardDetails.Add(new CardDetails()
            {
                Index = 9,
                Title = "Task - 10",
                Priority = Priority.High,
                Category = "Done",
                Progress = 100,
                Description = "Analyze grid control.",
                Tags = new List<string> { "Documentation" }
            });

            cardDetails.Add(new CardDetails()
            {
                Index = 15,
                Title = "Task - 12",
                Priority = Priority.Low,
                Category = "Done",
                Progress = 100,
                Description = "Analyze stored procedures.",
                Tags = new List<string> { "Trial preparation" }
            });

            cardDetails.Add(new CardDetails()
            {
                Title = "Task - 13",
                Priority = Priority.Medium,
                Index = 20,
                Category = "Code Review",
                Description = "Analyze grid control.",
                Progress = 75,
                Tags = new List<string> { "Documentation" }
            });

            cardDetails.Add(new CardDetails()
            {
                Index = 18,
                Title = "Task - 14",
                Priority = Priority.Critical,
                Category = "Code Review",
                Progress = 85,
                Description = "Stored procedure for initial data binding of the grid.",
                Tags = new List<string> { "Bug" }
            });

            cardDetails.Add(new CardDetails()
            {
                Index = 23,
                Title = "Task - 15",
                Priority = Priority.Low,
                Category = "Code Review",
                Progress = 88,
                Description = "Analyze stored procedures.",
                Tags = new List<string> { "Analyze" }
            });

            return cardDetails;
        }

        /// <summary>
        /// Retrieves a collection of sorting options for the Kanban cards.
        /// </summary>
        /// <returns>The collection of sorting options.</returns>
        private ObservableCollection<string> GetSortOptions()
        {
            return new ObservableCollection<string>()
            {
                "Index",
                "Custom",
                "ItemSource Order"
            };
        }

        /// <summary>
        /// Retrieves a collection defining the custom sort order for the Kanban cards.
        /// </summary>
        /// <returns>The collection of sort order.</returns>
        private ObservableCollection<string> GetSortOrder()
        {
            return new ObservableCollection<string>()
            {
                "Ascending",
                "Descending",
            };
        }

        /// <summary>
        /// Retrieves a collection defining the mapping paths for sorting the Kanban cards.
        /// </summary>
        /// <returns>The collection of mapping paths.</returns>
        private ObservableCollection<string> GetSortMappingPath()
        {
            return new ObservableCollection<string>()
            {
                "Title",
                "Index",              
                "Priority",
            };
        }

        #endregion
    }
}