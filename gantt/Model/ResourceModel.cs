#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
    public class Item : NotificationObject
    {
        string _Name;
        DateTime _StartDate;
        DateTime _FinishDate;
        double _progress;
        ObservableCollection<Item> _subItems = new ObservableCollection<Item>();
        ObservableCollection<Item> _inLineItems = new ObservableCollection<Item>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Item"/> class.
        /// </summary>
        public Item()
        {
            _subItems.CollectionChanged += ItemsCollectionChanged;
            _inLineItems.CollectionChanged += ItemsCollectionChanged;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        public string Name
        {
            get
            {
                return _Name;
            }
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }


        /// <summary>
        /// Gets or sets the start date.
        /// </summary>
        /// <value>The start date.</value>
        public DateTime StartDate
        {
            get
            {
                return _StartDate;
            }
            set
            {
                _StartDate = value;
                RaisePropertyChanged("StartDate");
            }
        }

        /// <summary>
        /// Gets or sets the finish date.
        /// </summary>
        /// <value>The finish date.</value>
        public DateTime FinishDate
        {
            get
            {
                return _FinishDate;
            }
            set
            {
                _FinishDate = value;
                RaisePropertyChanged("FinishDate");
            }
        }

        /// <summary>
        /// Gets or sets the progress.
        /// </summary>
        /// <value>The progress.</value>
        public double Progress
        {
            get
            {
                return Math.Round(_progress, 2);
            }
            set
            {
                _progress = value;
                RaisePropertyChanged("Progress");
            }
        }

        /// <summary>
        /// Gets or sets the sub items.
        /// </summary>
        /// <value>The sub items.</value>
        public ObservableCollection<Item> SubItems
        {
            get
            {
                return _subItems;
            }
            set
            {
                _subItems = value;

                _subItems.CollectionChanged += ItemsCollectionChanged;

                if (value.Count > 0)
                {
                    _subItems.ToList().ForEach(n =>
                    {
                        /// To listen the changes occuring in child task.
                        n.PropertyChanged += ItemPropertyChanged;
                    });
                    UpdateDates();
                }

                this.RaisePropertyChanged("SubItems");
            }
        }

        /// <summary>
        /// Gets or sets the in line items.
        /// </summary>
        /// <value>The in line items.</value>
        public ObservableCollection<Item> InLineItems
        {
            get
            {
                return _inLineItems;
            }
            set
            {
                _inLineItems = value;

                _inLineItems.CollectionChanged += ItemsCollectionChanged;

                if (value.Count > 0)
                {
                    _inLineItems.ToList().ForEach(n =>
                    {
                        /// To listen the changes occuring in child task.
                        n.PropertyChanged += ItemPropertyChanged;
                    });
                    UpdateDates();
                }

                this.RaisePropertyChanged("InLineItems");
            }
        }

        /// <summary>
        /// Itemses the collection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        void ItemsCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (Item item in e.NewItems)
                {
                    item.PropertyChanged += ItemPropertyChanged;
                }
            }
            else
            {
                foreach (Item item in e.OldItems)
                    item.PropertyChanged -= ItemPropertyChanged;
            }
            UpdateDates();
        }

        /// <summary>
        /// Items the property changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.ComponentModel.PropertyChangedEventArgs"/> instance containing the event data.</param>
        void ItemPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != null)
                if (e.PropertyName == "StartDate" || e.PropertyName == "FinishDate" || e.PropertyName == "Progress")
                {
                    UpdateDates();
                }
        }

        /// <summary>
        /// Updates the dates.
        /// </summary>
        private void UpdateDates()
        {
            var tempCal = 0d;

            if (_subItems.Count > 0)
            {
                /// Updating the start and end date based on the chagne occur in the date of child task
                StartDate = _subItems.Select(c => c.StartDate).Min();
                FinishDate = _subItems.Select(c => c.FinishDate).Max();
                Progress = (_subItems.Aggregate(tempCal, (cur, task) => cur + task.Progress)) / _subItems.Count;
            }

            if (_inLineItems.Count > 0)
            {
                /// Updating the start and end date based on the chagne occur in the date of child task
                StartDate = _inLineItems.Select(c => c.StartDate).Min();
                FinishDate = _inLineItems.Select(c => c.FinishDate).Max();
                Progress = (_inLineItems.Aggregate(tempCal, (cur, task) => cur + task.Progress)) / _inLineItems.Count;
            }
        }

        internal void Dispose()
        {

            InLineItems.CollectionChanged -= ItemsCollectionChanged;

            if (InLineItems.Count > 0)
            {
                InLineItems.ToList().ForEach(node =>
                {
                    node.PropertyChanged -= ItemPropertyChanged;
                });
            }

            SubItems.CollectionChanged -= ItemsCollectionChanged;

            if (SubItems.Count > 0)
            {
                SubItems.ToList().ForEach(node =>
                {
                    node.PropertyChanged -= ItemPropertyChanged;
                });
            }
        }
    }
}
