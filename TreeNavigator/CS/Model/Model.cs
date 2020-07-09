#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Collections.ObjectModel;

namespace SfTreeNavigator
{
    /// <summary>
    /// Class represents the model for MainWindow.xaml.
    /// </summary>
    public class Model 
    {
        /// <summary>
        /// Maintains the header of tree navigator.
        /// </summary>
        private string header;

        /// <summary>
        /// Maintains the collection of toolKits
        /// </summary>
        private ObservableCollection<Model> toolKits;

        /// <summary>
        /// Maintains the collection of toolsDescription for tree navigator.
        /// </summary>
        private string toolsDescription;

        /// <summary>
        /// Maintains the count for tree navigator.
        /// </summary>
        private string navigatorCount;

        /// <summary>
        /// Initializes the new instances of <see cref="Model"/> class.
        /// </summary>
        public Model()
        {
            ToolKits = new ObservableCollection<Model>();
            ToolKits.CollectionChanged += Models_CollectionChanged;
        }

        /// <summary>
        /// Gets or sets the header for tree navigator <see cref="Model"/> class.
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
            }
        }

        /// <summary>
        /// Gets or sets the collection of toolKits for tree navigator <see cref="Model"/> class.
        /// </summary>
        public ObservableCollection<Model> ToolKits
        {
            get
            {
                return toolKits;
            }
            set
            {
                toolKits = value;
            }
        }

        /// <summary>
        /// Gets or sets the toolsDescription for tree navigator <see cref="Model"/> class.
        /// </summary>
        public string ToolsDescription
        {
            get
            {
                return toolsDescription;
            }
            set
            {
                toolsDescription = value;
            }
        }

        /// <summary>
        /// Gets or sets the count of tree <see cref="Model"/> class. 
        /// </summary>
        public string NavigatorCount
        {
            get { return navigatorCount; }
            set
            {
                navigatorCount = value;
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
