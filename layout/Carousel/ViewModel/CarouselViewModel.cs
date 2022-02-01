#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace syncfusion.layoutdemos.wpf
{
    public class CarouselViewModel : NotificationObject
    {
        private ObservableCollection<CarouselModel> itemsCollection;
        private double rotationSpeed=150;
        private double? radiusX=-300;
        private double? radiusY=-115;
        private double? rotationAngle = 0;
        private double? scaleFraction=0.6;
        private double? opacityFraction = 0.1;
        private double skewAngleYFraction;
        private double skewAngleXFraction;

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
        
        public double RotationSpeed
        {
            get
            {
                return rotationSpeed;
            }
            set
            {
                rotationSpeed = value;
                this.RaisePropertyChanged(nameof(this.RotationSpeed));
            }
        } 
        
        public double? RotationAngle
        {
            get
            {
                return rotationAngle;
            }
            set
            {
                rotationAngle = value;
                this.RaisePropertyChanged(nameof(this.RotationAngle));
            }
        }
        
        public double? OpacityFraction
        {
            get
            {
                return opacityFraction;
            }
            set
            {
                opacityFraction = value;
                this.RaisePropertyChanged(nameof(this.OpacityFraction));
            }
        }
        
        public double SkewAngleXFraction
        {
            get
            {
                return skewAngleXFraction;
            }
            set
            {
                skewAngleXFraction = value;
                this.RaisePropertyChanged(nameof(this.SkewAngleXFraction));
            }
        }
        
        public double SkewAngleYFraction
        {
            get
            {
                return skewAngleYFraction;
            }
            set
            {
                skewAngleYFraction = value;
                this.RaisePropertyChanged(nameof(this.SkewAngleYFraction));
            }
        }
        
        public double? ScaleFraction
        {
            get
            {
                return scaleFraction;
            }
            set
            {
                scaleFraction = value;
                this.RaisePropertyChanged(nameof(this.ScaleFraction));
            }
        } 
        
        public double? RadiusX
        {
            get
            {
                return radiusX;
            }
            set
            {
                radiusX = value;
                this.RaisePropertyChanged(nameof(this.RadiusX));
            }
        }
        
        public double? RadiusY
        {
            get
            {
                return radiusY;
            }
            set
            {
                radiusY = value;
                this.RaisePropertyChanged(nameof(this.RadiusY));
            }
        }

        public ICommand SelectioChangedCommand { get; set; }

        #region Constructor
        /// <summary>
        /// Initializes the instance of this class 
        /// </summary>
        public CarouselViewModel()
        {
            ItemsCollection = new ObservableCollection<CarouselModel>();
            ItemsCollection.Add(new CarouselModel() { Name = "Buchanan", DOB = DateTime.Parse("1984/07/15"), State = "Montana", Age = 25, Designation = "Software Developer", Experience = "2+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle37.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Callahan", DOB = DateTime.Parse("1984/12/20"), State = "Texas", Age = 25, Designation = "Software Tester", Experience = "2+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle28.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Davolio", DOB = DateTime.Parse("1985/04/07"), State = "Alaska", Age = 24, Designation = "Software Developer", Experience = "1.5+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle10.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Dodsworth", DOB = DateTime.Parse("1975/09/21"), State = "Idaho", Age = 34, Designation = "Business Analyst", Experience = "9+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle6.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Fuller", DOB = DateTime.Parse("1970/10/21"), State = "Washington", Age = 37, Designation = "Business Analyst", Experience = "10+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle33.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Leverling", DOB = DateTime.Parse("1985/01/01"), State = "Hawaii", Age = 25, Designation = "Software Tester", Experience = "1+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle17.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "King", DOB = DateTime.Parse("1984/07/15"), State = "Montana", Age = 25, Designation = "Software Developer", Experience = "2+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle34.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Peacock", DOB = DateTime.Parse("1973/11/13"), State = "Washington", Age = 36, Designation = "Business Analyst", Experience = "10+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle25.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Suyama", DOB = DateTime.Parse("1983/12/31"), State = " West Virginia", Age = 26, Designation = "Senior Software Developer", Experience = "3+ Years", ImageSource = new BitmapImage(new Uri("/syncfusion.demoscommon.wpf;component/Assets/People/People_Circle31.png", UriKind.RelativeOrAbsolute)) });

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
            if (item.Content.ToString() == "Slow")
            {
                RotationSpeed = 10;
            }
            else if (item.Content.ToString() == "Medium")
            {
                RotationSpeed = 150;
            }
            else if (item.Content.ToString() == "High")
            {
                RotationSpeed = 500;
            }
        }

        #endregion
    }
}
