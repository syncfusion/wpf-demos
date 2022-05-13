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
    public class TopCountries : NotificationObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="TopCountries"/> class.
        /// </summary>
        public TopCountries()
        {
            ChildTopCountries = new ObservableCollection<TopCountries>();
        }

        private int id;
        private string name;
        private int _rank;
        private ObservableCollection<TopCountries> childTopCountries;
        private double _end;
        private int _complete = 100;
        private double _start;

        /// <summary>
        /// Gets or sets the start.
        /// </summary>
        /// <value>
        /// The start.
        /// </value>
        public double Start
        {
            get
            {
                return _start;
            }
            set
            {
                // if the TopCountries is parent TopCountries it selects the minimum start date of the childTopCountriess
                if (childTopCountries != null && childTopCountries.Count >= 1)
                {
                    if (_start != value)
                    {
                        _start = childTopCountries.Min(s => s.Start);
                    }
                }
                else
                {
                    _start = value;
                }
                RaisePropertyChanged("Start");
            }
        }

        /// <summary>
        /// Gets or sets the end.
        /// </summary>
        /// <value>
        /// The end.
        /// </value>
        public double End
        {
            get
            {
                return _end;
            }
            set
            {
                // if the TopCountries is parent TopCountries it selects the maximum end date of the childTopCountriess
                if (childTopCountries != null && childTopCountries.Count >= 1)
                {
                    if (_end != value)
                    {
                        _end = childTopCountries.Max(s => s.End);
                    }
                }
                else
                {
                    _end = value;
                }
                RaisePropertyChanged("End");
            }
        }


        /// <summary>
        /// Gets or sets the complete.
        /// </summary>
        /// <value>
        /// The complete.
        /// </value>
        public int Rank
        {
            get
            {
                return _rank;
            }
            set
            {
                _rank = value;
                RaisePropertyChanged("Rank");
            }
        }

        /// <summary>
        /// Gets or sets the complete.
        /// </summary>
        /// <value>
        /// The complete.
        /// </value>
        public int Complete
        {
            get { return _complete; }
            set { _complete = value; }
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
                RaisePropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the id.
        /// </summary>
        /// <value>
        /// The id.
        /// </value>
        public int Id
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
                RaisePropertyChanged("Id");
            }
        }

        #region ChildTopCountries Collection

        /// <summary>
        /// Gets or sets the child top countries.
        /// </summary>
        /// <value>The child top countries.</value>
        public ObservableCollection<TopCountries> ChildTopCountries
        {
            get
            {
                if (childTopCountries == null)
                {
                    childTopCountries = new ObservableCollection<TopCountries>();
                    /// Collection changed of child TopCountriess are hooked to listen and refresh the parent node based on the changes made in Child.
                    childTopCountries.CollectionChanged += ChildNodesCollectionChanged;
                }
                return childTopCountries;
            }
            set
            {
                childTopCountries = value;
                ///Collection changed of child TopCountriess are hooked to listen and refresh the parent node based on the changes made in Child.

                childTopCountries.CollectionChanged += ChildNodesCollectionChanged;

                if (value.Count > 0)
                {
                    childTopCountries.ToList().ForEach(n =>
                    {
                        /// To listen the changes occuring in child TopCountries.
                        n.PropertyChanged += ChildNodePropertyChanged;

                    });
                    UpdateData();
                }
                RaisePropertyChanged("ChildTopCountries");
            }
        }

        /// <summary>
        /// The following does the calculations to update the Parent TopCountries, when child collection property changes.
        /// </summary>
        /// <param name="sender">The source</param>
        /// <param name="e">Property changed event args</param>
        void ChildNodePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != null)
                if (e.PropertyName == "Start" || e.PropertyName == "End")
                {
                    UpdateData();
                }
        }

        /// <summary>
        /// Updates the data.
        /// </summary>
        private void UpdateData()
        {
            /// Updating the start and end  based on the chagne occur in the date of child TopCountries

            Start = childTopCountries.Select(s => s.Start).Min();
            End = childTopCountries.Select(s => s.End).Max();
        }

        /// <summary>
        /// Childs the nodes collection changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Collections.Specialized.NotifyCollectionChangedEventArgs"/> instance containing the event data.</param>
        public void ChildNodesCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (TopCountries node in e.NewItems)
                {
                    node.PropertyChanged += ChildNodePropertyChanged;
                }
            }
            else
            {
                foreach (TopCountries node in e.OldItems)
                    node.PropertyChanged -= ChildNodePropertyChanged;
            }
            UpdateData();
        }

        #endregion

        internal void Dispose()
        {
            ChildTopCountries.CollectionChanged -= ChildNodesCollectionChanged;

            if (ChildTopCountries.Count > 0)
            {
                ChildTopCountries.ToList().ForEach(node =>
                {
                    node.PropertyChanged -= ChildNodePropertyChanged;
                });
            }
        }
    }
}
