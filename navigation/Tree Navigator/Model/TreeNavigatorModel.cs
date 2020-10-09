#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using syncfusion.demoscommon.wpf;
using System.Collections.ObjectModel;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Class represents the model for MainWindow.xaml.
    /// </summary>
    public class TreeNavigatorModel : NotificationObject
    {
        /// <summary>
        /// Maintains the header of tree navigator.
        /// </summary>
        private string header;

        /// <summary>
        /// Maintains the collection of toolKits
        /// </summary>
        private ObservableCollection<TreeNavigatorModel> toolKits;

        /// <summary>
        /// Maintains the collection of Description for tree navigator.
        /// </summary>
        private string description;

        /// <summary>
        /// Maintains the count for tree navigator.
        /// </summary>
        private string navigatorCount;

        /// <summary>
        /// Initializes the new instances of <see cref="TreeNavigatorModel"/> class.
        /// </summary>
        public TreeNavigatorModel()
        {
            ToolKits = new ObservableCollection<TreeNavigatorModel>();
            ToolKits.CollectionChanged += Models_CollectionChanged;
        }

        /// <summary>
        /// Gets or sets the header for tree navigator <see cref="TreeNavigatorModel"/> class.
        /// </summary>
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header = value;
                RaisePropertyChanged("Header");
            }
        }

        /// <summary>
        /// Gets or sets the collection of toolKits for tree navigator <see cref="TreeNavigatorModel"/> class.
        /// </summary>
        public ObservableCollection<TreeNavigatorModel> ToolKits
        {
            get
            {
                return toolKits;
            }
            set
            {
                toolKits = value;
                RaisePropertyChanged("ToolKits");
            }
        }

        /// <summary>
        /// Gets or sets the toolsDescription for tree navigator <see cref="TreeNavigatorModel"/> class.
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                RaisePropertyChanged("Description");
            }
        }

        /// <summary>
        /// Gets or sets the count of tree <see cref="TreeNavigatorModel"/> class. 
        /// </summary>
        public string NavigatorCount
        {
            get { return navigatorCount; }
            set
            {
                navigatorCount = value;
                RaisePropertyChanged("NavigatorCount");
            }
        }

        /// <summary>
        /// Specifies the count of tree navigator.
        /// </summary>
        /// <param name="sender">Specifies the object parameter.</param>
        /// <param name="e">Specifies the event.</param>
        void Models_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (ToolKits.Count > 0)
                NavigatorCount = "( " + ToolKits.Count.ToString() + " )";
        }
    }
}
