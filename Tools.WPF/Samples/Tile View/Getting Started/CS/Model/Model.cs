#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.ComponentModel;
using Syncfusion.Windows.Shared;
using System.Windows.Media;
using System.Windows;

namespace TileViewConfigurationDemo
{
    public class Model:NotificationObject
    {
        public Model()
        {

        }

        #region TileViewItem Properties

        

       

        private string header;
        /// <summary>
        /// Gets or sets the TileViewItem's header.
        /// </summary>
        public string Header
        {
            get
            {
                return header;
            }
            set
            {
                header= value;
                this.RaisePropertyChanged("Header");
            }
        }

        private string content;
        /// <summary>
        /// Gets or sets the TileViewItem's Content.
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
                this.RaisePropertyChanged("Content");
            }
        }

        private Brush headerBackground = Brushes.Transparent;
        /// <summary>
        /// Gets or sets the Background color of the TileViewItem's Header.
        /// </summary>
        public Brush HeaderBackground
        {
            get
            {
                return headerBackground;
            }
            set
            {
                headerBackground= value;
                this.RaisePropertyChanged("HeaderBackground");
            }
        }

        private Brush headerBorderBrush= Brushes.Black;
        /// <summary>
        /// Gets or sets the BoderBrush of the TileViewItem's Header.
        /// </summary>
        public Brush HeaderBorderBrush
        {
            get
            {
                return headerBorderBrush;
            }
            set
            {
                headerBorderBrush= value;
                this.RaisePropertyChanged("HeaderBorderBrush");
            }
        }
     
        private Brush headerForeground = Brushes.Black;
        /// <summary>
        /// Gets or sets the Foreground color of the TileViewItem's header.
        /// </summary>
        public Brush HeaderForeground
        {
            get
            {
                return headerForeground;
            }
            set
            {
                headerForeground= value;
                this.RaisePropertyChanged("HeaderForeground");
            }
        }

        private double headerBorderThickness;
        /// <summary>
        /// Gets or sets the BorderThickness of the TileViewItem's header.
        /// </summary>
        public double HeaderBorderThickness
        {
            get
            {
                return headerBorderThickness;
            }
            set
            {
                headerBorderThickness= value;
                this.RaisePropertyChanged("HeaderBorderThickness");
            }
        }


       
      
       

        private Brush contentBackground;
        public Brush ContentBackground
        {
            get
            {
                return contentBackground;
            }
            set
            {
                contentBackground = value;
                this.RaisePropertyChanged("ContentBackground");
            }
        }

        #endregion

    }

    public class BookModel :NotificationObject
    {
        public BookModel()
        {

        }
       

        private string bookID;
        public string BookID 
        { 
            get
            {
                return bookID;
            }
            set
            {
                bookID = value;
                this.RaisePropertyChanged("BookID");
            }
        }

        private Visibility closeButtonVisibility = Visibility.Collapsed;
        /// <summary>
        /// Gets or sets the Visibility of the TileViewItem's Close Button.
        /// </summary>       
        public Visibility CloseButtonVisibility
        {
            get
            {
                return closeButtonVisibility;
            }
            set
            {
                closeButtonVisibility = value;
                this.RaisePropertyChanged("CloseButtonVisibility");
            }
        }

        private Visibility headerVisibility = Visibility.Visible;
        /// <summary>
        /// Gets or sets the Visibility of the TileViewItem's Header.
        /// </summary>
        public Visibility HeaderVisibility
        {
            get
            {
                return headerVisibility;
            }
            set
            {
                headerVisibility = value;
                this.RaisePropertyChanged("HeaderVisibility");
            }
        }

        private bool isSelected;
        /// <summary>
        /// Gets or sets IsSelected property of the TileViewItem.
        /// <value>
        ///<c>true</c> if TileViewItem is selected; otherwise, <c>false</c>.
        /// </value>
        ///</summary>
        public bool IsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                this.RaisePropertyChanged("IsSelected");
            }
        }

        private Visibility minMaxButtonVisibility = Visibility.Visible;
        /// <summary>
        /// Gets or sets the Visibility of the TileViewItem's Minimize and Maximize buttons.
        /// </summary>
        public Visibility MinMaxButtonVisibility
        {
            get
            {
                return minMaxButtonVisibility;
            }
            set
            {
                minMaxButtonVisibility = value;
                this.RaisePropertyChanged("MinMaxButtonVisibility");
            }
        }

        private CloseMode closeMode = CloseMode.Hide;
        /// <summary>
        /// Gets or sets CloseMode of the TileViewItem.
        /// <value>
        /// <c>Hide</c>- When closing the TileViewItem, it will be hided.
        /// <c>Delete</c> - When closing the TileViewItem, it will be deleted.
        /// </value> 
        /// </summary>  
        public CloseMode CloseMode
        {
            get
            {
                return closeMode;
            }
            set
            {
                closeMode = value;
                this.RaisePropertyChanged("CloseMode");
            }
        }

        private string bookName;
        public string BookName
        {
            get
            {
                return bookName;
            }
            set
            {
                bookName = value;
                this.RaisePropertyChanged("BookName");
            }
        }

        private string author;
        public string AuthorName
        {
            get
            {
                return author;
            }
            set
            {
                author = value;
                this.RaisePropertyChanged("AuthorName");
            }
        }


        private string genre;
        public string Genre
        {
            get
            {
                return genre;
            }
            set
            {
                genre = value;
                this.RaisePropertyChanged("Genre");
            }
        }

        private string price;
        public string Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                this.RaisePropertyChanged("Price");
            }
        }

        private string publishdate;
        public string PublishDate
        {
            get
            {
                return publishdate;
            }
            set
            {
                publishdate = value;
                this.RaisePropertyChanged("PublishDate");
            }
        }

        private string description;
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
                this.RaisePropertyChanged("Description");
            }
        }
    }
}
