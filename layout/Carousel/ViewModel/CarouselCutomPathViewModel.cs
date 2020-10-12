#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Syncfusion.Windows.Tools.Controls;
using System.Windows.Shapes;

namespace syncfusion.layoutdemos.wpf
{
    public class CarouselCutomPathViewModel : NotificationObject
    {
        #region Private variables

        private ObservableCollection<CarouselCustomPathModel> itemsCollection;

        private Path customPath;

        #endregion

        #region Public variabels

        public ObservableCollection<CarouselCustomPathModel> ItemsCollection
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

        public Path CustomPath
        {
            get
            {
                return customPath;
            }

            set
            {
                customPath = value;
                RaisePropertyChanged("CustomPath");
            }
        }

        public ICommand SelectioChangedCommand { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes the instance of this class 
        /// </summary>
        public CarouselCutomPathViewModel()
        {
            ItemsCollection = new ObservableCollection<CarouselCustomPathModel>();
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/1.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/2.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/3.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/4.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/5.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/6.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/7.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/8.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/9.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/10.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/11.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/12.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/13.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/14.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/15.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/16.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/17.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/18.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/19.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/20.jpg", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselCustomPathModel() { ImageSource = new BitmapImage(new Uri("/syncfusion.layoutdemos.wpf;component/Assets/Carousel/21.jpg", UriKind.RelativeOrAbsolute)) });

            customPath = new Path();
            customPath.Data = Geometry.Parse("M0,300 L600,300");
            CustomPath = customPath;

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
            if (item.Content.ToString() == "Linear shape")
            {
                customPath = new Path();
                customPath.Data = Geometry.Parse("M0,300 L600,300");
                CustomPath = customPath;
            }
            else if (item.Content.ToString() == "Diagonal shape")
            {
                customPath = new Path();
                customPath.Data = Geometry.Parse("M600,0 L0,300");
                CustomPath = customPath;
            }
            else if (item.Content.ToString() == "S shape")
            {
                customPath = new Path();
                customPath.Data = Geometry.Parse("F1 M 799.443,650.245C 802.926,650.294 806.306,650.444 809.567,650.686C 812.83,650.929 815.974,651.264 818.986,651.685C 822,652.105 824.882,652.611 827.614,653.194C 830.349,653.777 832.935,654.438 835.353,655.168C 837.754,655.906 839.939,656.698 841.882,657.542C 843.83,658.389 845.534,659.286 846.963,660.228C 848.396,661.174 849.554,662.167 850.404,663.199C 851.257,664.236 851.801,665.314 852.004,666.428C 852.192,667.545 852.024,668.627 851.524,669.665C 851.022,670.708 850.189,671.708 849.05,672.66C 847.905,673.614 846.455,674.519 844.723,675.37C 842.985,676.222 840.966,677.018 838.694,677.752C 836.388,678.482 833.874,679.134 831.166,679.7C 828.453,680.267 825.547,680.747 822.469,681.13C 819.386,681.513 816.132,681.799 812.724,681.976C 809.314,682.155 805.754,682.226 802.064,682.179C 785.787,681.965 769.873,682.288 754.454,683.099C 738.976,683.915 723.944,685.225 709.505,686.988C 694.964,688.763 680.979,691.002 667.713,693.665C 654.313,696.353 641.611,699.481 629.785,703.007C 617.784,706.571 606.599,710.568 596.418,714.955C 586.08,719.409 576.754,724.275 568.649,729.505C 560.401,734.829 553.401,740.543 547.882,746.597C 542.254,752.772 538.158,759.31 535.852,766.16C 533.476,773.156 533.071,780.173 534.529,787.123C 536.017,794.219 539.447,801.238 544.697,808.083C 550.051,815.064 557.29,821.851 566.273,828.34C 575.418,834.944 586.349,841.222 598.898,847.058C 611.601,852.995 625.989,858.483 641.848,863.407C 657.907,868.393 675.42,872.785 694.134,876.462C 713.016,880.17 733.044,883.138 753.931,885.247C 774.914,887.366 796.668,888.608 818.872,888.867L 819.022,888.868C 859.785,888.868 877.785,887.853 877.785,887.853");
                CustomPath = customPath;
            }
        }

        #endregion
    }
}
