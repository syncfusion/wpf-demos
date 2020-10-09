#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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

namespace CarouselDemo
{
    public class ViewModel : NotificationObject
    {
        #region Private variables

        private ObservableCollection<CarouselModel> itemsCollection;
        private double radiusX = 300;
        private double radiusY = -200;
        private int rotationSpeed = 150;
        private int angle = 0;
        private double scaleFraction = 0.6;

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

        public double RadisuX
        {
            get
            {
                return radiusX;
            }
            set
            {
                radiusX = value;
                RaisePropertyChanged("RadisuX");
            }
        }

        public double RadisuY
        {
            get
            {
                return radiusY;
            }
            set
            {
                radiusY = value;
                RaisePropertyChanged("RadisuY");
            }
        }

        public int RotationSpeed
        {
            get
            {
                return rotationSpeed;
            }
            set
            {
                rotationSpeed = value;
                RaisePropertyChanged("RotationSpeed");
            }
        }

        public int RotationAngle
        {
            get
            {
                return angle;
            }
            set
            {
                angle = value;
                RaisePropertyChanged("RotationAngle");
            }
        }

        public double ScaleFraction
        {
            get
            {
                return scaleFraction;
            }
            set
            {
                scaleFraction = value;
                RaisePropertyChanged("ScaleFraction");
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
            ItemsCollection.Add(new CarouselModel() { Name = "Buchanan", DOB = DateTime.Parse("1984/07/15"), State = "Montana", Age = 25, Designation = "Software Developer", Experience = "2+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/Buchanan.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Callahan", DOB = DateTime.Parse("1984/12/20"), State = "Texas", Age = 25, Designation = "Software Tester", Experience = "2+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/Callahan.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Davolio", DOB = DateTime.Parse("1985/04/07"), State = "Alaska", Age = 24, Designation = "Software Developer", Experience = "1.5+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/Davolio-1.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Dodsworth", DOB = DateTime.Parse("1975/09/21"), State = "Idaho", Age = 34, Designation = "Business Analyst", Experience = "9+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/dodsworth.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Fuller", DOB = DateTime.Parse("1970/10/21"), State = "Washington", Age = 37, Designation = "Business Analyst", Experience = "10+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/Fuller.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Leverling", DOB = DateTime.Parse("1985/01/01"), State = "Hawaii", Age = 25, Designation = "Software Tester", Experience = "1+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/Leverling.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "King", DOB = DateTime.Parse("1984/07/15"), State = "Montana", Age = 25, Designation = "Software Developer", Experience = "2+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/King.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Peacock", DOB = DateTime.Parse("1973/11/13"), State = "Washington", Age = 36, Designation = "Business Analyst", Experience = "10+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/Leverling.png", UriKind.RelativeOrAbsolute)) });
            ItemsCollection.Add(new CarouselModel() { Name = "Suyama", DOB = DateTime.Parse("1983/12/31"), State = " West Virginia", Age = 26, Designation = "Senior Software Developer", Experience = "3+ Years", ImageSource = new BitmapImage(new Uri(@"/Images/Suyama.png", UriKind.RelativeOrAbsolute)) });
        }

        #endregion 
    }
  
}
