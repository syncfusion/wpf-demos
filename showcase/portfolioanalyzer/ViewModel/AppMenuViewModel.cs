#region Copyright Syncfusion Inc. 2001-2021.
// Copyright Syncfusion Inc. 2001-2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel;
using Microsoft.Practices.Composite.Events;
using Microsoft.Practices.Composite.Presentation.Commands;

namespace syncfusion.portfolioanalyzerdemo.wpf
{
    public class AppMenuViewModel : INotifyPropertyChanged
    {
        IEventAggregator eventAggregator;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppMenuViewModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public AppMenuViewModel(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;
            this.SelectDashboardView = new DelegateCommand<object>(SelectDashboardViewHandler);
            this.SelectContributionAnalyzerView = new DelegateCommand<object>(SelectContributionAnalyzerViewHandler);
        }

        #region EventHandlers
        /// <summary>
        /// Publishes the Dashboard View selected event.
        /// </summary>
        /// <param name="o">The o.</param>
        void SelectDashboardViewHandler(object o)
        {
            this.eventAggregator.GetEvent<SelectedViewEvents>().Publish("Dashboard");            
        }

        /// <summary>
        /// Publishes the Dashboard View selected event.
        /// </summary>
        /// <param name="o"></param>
        void SelectContributionAnalyzerViewHandler(object o)
        {
            this.eventAggregator.GetEvent<SelectedViewEvents>().Publish("ContributionAnalyzer");
        }


        #endregion

        #region Delegate Commands
        /// <summary>
        /// Gets or sets the select dashboard view .
        /// </summary>
        /// <value>The select dashboard view.</value>
        public DelegateCommand<object> SelectDashboardView { get; set; }

        /// <summary>
        /// Gets or sets the select contribution analyzer view.
        /// </summary>
        /// <value>The select contribution analyzer view.</value>
        public DelegateCommand<object> SelectContributionAnalyzerView { get; set; }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        #endregion
    }
}
