
using syncfusion.demoscommon.wpf;
using System.Collections.ObjectModel;
using System.Windows.Media;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represents a model for the control.
    /// </summary>
    public class HierarchyNavigatorModel : NotificationObject
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
        private ObservableCollection<HierarchyNavigatorModel> folderItems;

        /// <summary>
        ///  Initializes a new instance of the <see cref="HierarchyNavigatorModel" /> class.
        /// </summary>
        public HierarchyNavigatorModel()
        {
            folderItems = new ObservableCollection<HierarchyNavigatorModel>();
        }

        /// <summary>
        /// Gets or sets the content details <see cref="HierarchyNavigatorModel"/> class.
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
                RaisePropertyChanged("Content");
            }
        }

        /// <summary>
        /// Gets or sets the folder image details <see cref="HierarchyNavigatorModel"/> class.
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
                RaisePropertyChanged("FolderImage");
            }
        }

        /// <summary>
        /// Gets or sets the folder item details <see cref="HierarchyNavigatorModel"/> class.
        /// </summary>
        public ObservableCollection<HierarchyNavigatorModel> FolderItems
        {
            get
            {
                return folderItems;
            }
            set
            {
                folderItems = value;
                RaisePropertyChanged("FolderItems");
            }
        }
    }
}
