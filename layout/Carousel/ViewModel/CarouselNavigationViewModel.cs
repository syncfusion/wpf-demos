#region Copyright Syncfusion® Inc. 2001-2026.
// Copyright Syncfusion® Inc. 2001-2026. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Controls;

namespace syncfusion.layoutdemos.wpf
{
    public class CarouselNavigationViewModel : NotificationObject
    {
        #region Private variables

        private ObservableCollection<CarouselNavigationModel> itemsCollection;
        private ScrollBarVisibility horizontalScrollBarVisibility= ScrollBarVisibility.Hidden;
        private ScrollBarVisibility verticalScrollBarVisibility= ScrollBarVisibility.Hidden;
        private int selectedIndex = 14;
        private bool enableLooping= false;

        #endregion

        #region Public variabels

        public ObservableCollection<CarouselNavigationModel> ItemsCollection
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
        
        public bool EnableLooping
        {
            get
            {
                return enableLooping;
            }
            set
            {
                enableLooping = value;
                this.RaisePropertyChanged(nameof(this.EnableLooping));
            }
        } 
        
        public int SelectedIndex
        {
            get
            {
                return selectedIndex;
            }
            set
            {
                selectedIndex = value;
                this.RaisePropertyChanged(nameof(this.SelectedIndex));
            }
        }
        
        public ScrollBarVisibility HorizontalScrollBarVisibility
        {
            get
            {
                return horizontalScrollBarVisibility;
            }
            set
            {
                horizontalScrollBarVisibility = value;
                this.RaisePropertyChanged(nameof(this.HorizontalScrollBarVisibility));
            }
        }
        
        public ScrollBarVisibility VerticalScrollBarVisibility
        {
            get
            {
                return verticalScrollBarVisibility;
            }
            set
            {
                verticalScrollBarVisibility = value;
                this.RaisePropertyChanged(nameof(this.VerticalScrollBarVisibility));
            }
        }

        public ICommand SelectioChangedCommand { get; set; }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the instance of this class 
        /// </summary>
        public CarouselNavigationViewModel()
        {
            ItemsCollection = new ObservableCollection<CarouselNavigationModel>();
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/1.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/2.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/3.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/4.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/5.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/6.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/7.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/8.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/9.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/10.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/11.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/12.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/13.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/14.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/15.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/16.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/17.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/18.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/19.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/20.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselNavigationModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/21.jpg", UriKind.RelativeOrAbsolute)) });

            SelectioChangedCommand = new DelegateCommand<object>(PropertyChangedHandler);

        }

        #endregion

        #region Methods

        public void PropertyChangedHandler(object param)
        {
            ComboBoxAdv combo = param as ComboBoxAdv;

            if (combo == null || combo.SelectedItem == null)
                return;

            var item = combo.SelectedItem as ComboBoxItemAdv;
            if (item.Content.ToString() == "Horizontal")
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Auto;
                VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
                
            }
            else if (item.Content.ToString() == "Vertical")
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
                VerticalScrollBarVisibility = ScrollBarVisibility.Visible;
            }
            else if (item.Content.ToString() == "Hidden")
            {
                HorizontalScrollBarVisibility = ScrollBarVisibility.Hidden;
                VerticalScrollBarVisibility = ScrollBarVisibility.Hidden;
            }
        }

        #endregion
    }
}
