#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.kanbandemos.wpf
{
    using System.Collections.Generic;
    using System.ComponentModel;

    /// <summary>
    /// Represents a Kanban card with sorting related information such as title, category, priority, and index.
    /// </summary>
    public class CardDetails : INotifyPropertyChanged
    {
        #region Fields

        /// <summary>
        /// The title of the card.
        /// </summary>
        private string _title;

        /// <summary>
        /// The description of the card.
        /// </summary>
        private string _description;

        /// <summary>
        /// The category of the card. This property is used for column mapping in the Kanban board.
        /// </summary>
        private string _category;

        /// <summary>
        /// The list of tags associated with the card.
        /// </summary>
        private List<string> _tags;

        /// <summary>
        /// The index of the card. This property is used for sorting the cards within a column.
        /// </summary>
        private int _index;

        /// <summary>
        /// The priority of the card. This property can be used for additional sorting or filtering.
        /// </summary>
        private Priority _priority;

        /// <summary>
        /// The value of the progress bar on each card item.
        /// </summary>
        private double _progress;

        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets the title of the card.
        /// </summary>
        public string Title
        {
            get { return this._title; }
            set
            {
                this._title = value;
                this.OnPropertyChanged(nameof(Title));
            }
        }

        /// <summary>
        /// Gets or sets the description of the card.
        /// </summary>
        public string Description
        {
            get { return this._description; }
            set
            {
                this._description = value;
                this.OnPropertyChanged(nameof(Description));
            }
        }

        /// <summary>
        /// Gets or sets the category of the card. This property is used for column mapping in the Kanban board.
        /// </summary>
        public string Category
        {
            get { return this._category; }
            set
            {
                this._category = value;
                this.OnPropertyChanged(nameof(Category));
            }
        }

        /// <summary>
        /// Gets or sets the list of tags associated with the card.
        /// </summary>
        public List<string> Tags
        {
            get { return this._tags; }
            set
            {
                this._tags = value;
                this.OnPropertyChanged(nameof(Tags));
            }
        }

        /// <summary>
        /// Gets or sets the index of the card. This property is used for sorting the cards within a column.
        /// </summary>
        public int Index
        {
            get { return this._index; }
            set
            {
                this._index = value;
                this.OnPropertyChanged(nameof(Index));
            }
        }

        /// <summary>
        /// Gets or sets the priority of the card. This property can be used for additional sorting or filtering.
        /// </summary>
        public Priority Priority
        {
            get { return this._priority; }
            set
            {
                this._priority = value;
                this.OnPropertyChanged(nameof(Priority));
            }
        }

        /// <summary>
        /// Gets or sets the ProgressBar value associated with the card.
        /// </summary>
        public double Progress
        {
            get { return this._progress; }
            set
            {
                if (this._progress != value)
                {
                    this._progress = value;
                }
            }
        }

        #endregion

        #region Event

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Methods

        /// <summary>
        /// Invokes the event when the value of a property has changed.
        /// </summary>
        /// <param name="propertyName">The name of the property that has changed.</param>
        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}