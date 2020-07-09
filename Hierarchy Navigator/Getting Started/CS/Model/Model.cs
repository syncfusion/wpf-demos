#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.Collections.ObjectModel;
using System.Windows.Media;

namespace HierarchyNavigator_2008
{
    /// <summary>
    /// Represents a model for the control.
    /// </summary>
    public class Model
    {
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

        /// <summary>
        ///  Initializes a new instance of the <see cref="Model" /> class.
        /// </summary>
        public Model()
        {
            folderItems = new ObservableCollection<Model>();
        }

        /// <summary>
        /// Gets or sets the content details <see cref="Model"/> class.
        /// </summary>
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }

        /// <summary>
        /// Gets or sets the folder image details <see cref="Model"/> class.
        /// </summary>
        public ImageSource FolderImage
        {
            get
            {
                return folderImage;
            }
            set
            {
                folderImage = value;
            }
        }

        /// <summary>
        /// Gets or sets the folder item details <see cref="Model"/> class.
        /// </summary>
        public ObservableCollection<Model> FolderItems
        {
            get
            {
                return folderItems;
            }
            set
            {
                folderItems = value;
            }
        }
    }
}
