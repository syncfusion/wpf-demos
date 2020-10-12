#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Windows.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Xml.Linq;

namespace syncfusion.layoutdemos.wpf
{
    public class TileViewViewModel : NotificationObject
    {
        private ObservableCollection<BookModel> bookModelItems;
        public ObservableCollection<BookModel> BookModelItems
        {
            get
            {
                return bookModelItems;
            }

            set
            {
                bookModelItems = value;
            }
        }

        #region TileView Properties
        private bool enableTileAnimation = true;
        /// <summary>
        /// Gets or sets EnableTileAnimation property of the TileViewControl.
        /// <value>
        ///<c>true</c> if TileViewItems reordering allowed; otherwise, <c>false</c>.
        /// </value>
        ///</summary>
        public bool EnableTileAnimation
        {
            get
            {
                return enableTileAnimation;
            }

            set
            {
                enableTileAnimation = value;
                this.RaisePropertyChanged("EnableTileAnimation");
            }
        }

        private TimeSpan animationDuration = TimeSpan.FromMilliseconds(700);
        /// <summary>
        /// Gets or sets EnableTileAnimation property of the TileViewControl.
        /// <value>
        ///<c>true</c> if TileViewItems reordering allowed; otherwise, <c>false</c>.
        /// </value>
        ///</summary>
        public TimeSpan AnimationDuration
        {
            get
            {
                return animationDuration;
            }

            set
            {
                animationDuration = value;
                this.RaisePropertyChanged("AnimationDuration");
            }
        }
        #endregion

        #region Implementation

        public TileViewViewModel()
        {
            bookModelItems = new ObservableCollection<BookModel>();
            PopulateCollection();
        }

        private void PopulateCollection()
        {
            XDocument xDocument = XDocument.Load(@"Assets/TileView/Books.xml");
            IEnumerable<XElement> query = from xElement in xDocument.Descendants("book")
                                          select xElement;
            foreach (XElement xElement in query)
            {
                BookModel bookModel = new BookModel
                {
                    BookID = xElement.FirstAttribute.Value,
                    BookName = xElement.Element("title").Value,
                    AuthorName = xElement.Element("author").Value,
                    Genre = xElement.Element("genre").Value,
                    Price = xElement.Element("price").Value,
                    PublishDate = xElement.Element("publish_date").Value,
                    Description = xElement.Element("description").Value
                };
                bookModelItems.Add(bookModel);
            }
        }

        #endregion
    }
}
