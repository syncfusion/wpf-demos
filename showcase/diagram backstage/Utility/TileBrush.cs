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
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace syncfusion.diagrambackstage.wpf
{
    public class TileBrush : Canvas
    {
        public static readonly DependencyProperty ImageSourceProperty = DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(TileBrush), new PropertyMetadata(null, ImageSourceChanged));

        private Size lastActualSize;

        public TileBrush()
        {
            LayoutUpdated += OnLayoutUpdated;
        }

        public ImageSource ImageSource
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }

        private void OnLayoutUpdated(object sender, object o)
        {
            var newSize = new Size(ActualWidth, ActualHeight);
            if (lastActualSize != newSize)
            {
                lastActualSize = newSize;
                Rebuild();
            }
        }

        private static void ImageSourceChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            TileBrush self = (TileBrush)o;
            var src = self.ImageSource;
            if (src != null)
            {
                var image = new Image { Source = src };
                //image.ImageOpened += self.ImageOnImageOpened;

                //add it to the visual tree to kick off ImageOpened
                self.Children.Add(image);
            }
        }

        private void ImageOnImageOpened(object sender, RoutedEventArgs routedEventArgs)
        {
            var image = (Image)sender;
            //image.ImageOpened -= ImageOnImageOpened;
            Rebuild();
        }

        private void Rebuild()
        {
            var bmp = ImageSource as BitmapSource;
            if (bmp == null)
            {
                return;
            }

            var width = bmp.PixelWidth;
            var height = bmp.PixelHeight;

            if (width == 0 || height == 0)
            {
                return;
            }

            Children.Clear();
            for (int x = 0; x < 500; x += width)
            {
                for (int y = 0; y < 200; y += height)
                {
                    Image image = new Image { Source = ImageSource };
                    image.Stretch = Stretch.None;
                    Canvas.SetLeft(image, x);
                    Canvas.SetTop(image, y);
                    Children.Add(image);
                }
            }
                    Clip = new RectangleGeometry { Rect = new Rect(0, 0, ActualWidth, ActualHeight) };
        }
    }

    public interface IDialog
    {
        DialogResult DialogResult { get; set; }

        Task<DialogResult> ShowDialog();

        event EventHandler DialogResultChanged;
    }
}
