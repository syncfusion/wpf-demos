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
using System.Windows.Threading;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.ComponentModel;
using Syncfusion.Windows.Shared;

namespace DataLoadingDemo
{
    public class Model :NotificationObject
    {
        private ImageSource image;

        public ImageSource Image
        {
            get { return image; }
            set { image = value;
            this.RaisePropertyChanged("Image");
            }
        }

        private bool isBusy = true;

        public bool IsBusy
        {
            get { return isBusy; }
            set { isBusy = value; 
                this.RaisePropertyChanged("IsBusy"); }
        }


        private DispatcherTimer timer;
        private Random rndm;

        public Model(int seconds)
        {
            Randomize(seconds);
        }

        public void Randomize(int seconds)
        {
            Image = null;
            IsBusy = true;
            timer = new DispatcherTimer();
            timer.Tick += new EventHandler(timer_Tick);
            rndm = new Random();
            timer.Interval = new TimeSpan(0, 0, 0, seconds, 0);
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            SetRandomImage();
            timer.Stop();
            IsBusy = false;
        }

        private void SetRandomImage()
        {
            rndm = new Random();
            string str = "/DataLoadingDemo;component/Images/" + rndm.Next(1, 31) + ".jpg";
            BitmapImage img = new BitmapImage(new Uri(str, UriKind.Relative));
            Image = img;
        }
    }
}
