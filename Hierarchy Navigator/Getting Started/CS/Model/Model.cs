#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.ComponentModel;

namespace HierarchyNavigator_2008
{
    /// <summary>
    /// Represents a model for the control.
    /// </summary>
    public class Model : INotifyPropertyChanged
    {
        #region Fields
        /// <summary>
        ///  Maintains the content.
        /// </summary>
        private string content;

        /// <summary>
        ///  Maintains the folder image.
        /// </summary>
        private ImageSource folderImage;

        /// <summary>
        /// Maintains the collection of folder items.
        /// </summary>
        private ObservableCollection<Model> folderItems;
        #endregion

        #region Constructor
        /// <summary>
        ///  Initializes a new instance of the <see cref="Model" /> class.
        /// </summary>
        public Model()
        {
            folderItems = new ObservableCollection<Model>();
        }
        #endregion

        #region Events
        /// <summary>
        /// Initialize the event which notifies when the selected item changes. 
        /// </summary>  
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Method
        /// <summary>
        /// Event handling method for notified changes.
        /// </summary>
        /// <param name="name">Notified property changes</param>
        public void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the content details.
        /// </summary>
        [Category("Summary")]
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        /// <summary>
        /// Gets or sets the folder image details.
        /// </summary>
        [Category("Summary")]
        public ImageSource FolderImage
        {
            get
            {
                return folderImage;
            }
            set
            {
                folderImage = value;
                OnPropertyChanged("FolderImage");
            }
        }

        /// <summary>
        /// Gets or sets the folder item details.
        /// </summary>
        [Category("Summary")]
        public ObservableCollection<Model> FolderItems
        {
            get
            {
                return folderItems;
            }
            set
            {
                folderItems = value;
                OnPropertyChanged("FolderItems");
            }
        }
        #endregion
    }

}
