#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace CarouselCustomPathDemo
{
    public class ViewModel : NotificationObject
    {
        #region Private variables

        private ObservableCollection<CarouselModel> itemsCollection;

        #endregion

        #region Public variabels

        public ObservableCollection<CarouselModel> ItemsCollection
        {
            get
            {
                return itemsCollection;
            }
            set
            {
                itemsCollection = value;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the instance of this class 
        /// </summary>
        public ViewModel()
        {
            ItemsCollection = new ObservableCollection<CarouselModel>();
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/1.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/2.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/3.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/4.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/5.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/6.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/7.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/8.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/9.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/10.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/11.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/12.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/13.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/14.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/15.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/16.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/17.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/18.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/19.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/20.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { ImageSource = new BitmapImage(new Uri(@"Images/21.jpg", UriKind.RelativeOrAbsolute)) });
        }

        #endregion 
    }

    /// <summary>
    /// Carousel model class 
    /// </summary>
    public class CarouselModel
    {
        private ImageSource imageSource;

        public ImageSource ImageSource
        {
            get
            {
                return imageSource;
            }
            set
            {
                imageSource = value;
            }
        }

    }

}
