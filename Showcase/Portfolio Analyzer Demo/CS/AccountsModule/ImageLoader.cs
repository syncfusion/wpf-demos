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
using System.Windows.Media.Imaging;
using System.IO;


namespace PerformanceAnalyzer.AccountsModule
{
    public static class ImageLoader
    {
        public static List<BitmapImage> LoadImages()
        {
            List<BitmapImage> Images = new List<BitmapImage>();
            DirectoryInfo ImageDir = new DirectoryInfo(@"..\..\..\AccountsModule\Images");
            foreach (FileInfo ImageFile in ImageDir.GetFiles("*.jpg"))
            {
                Uri uri = new Uri(ImageFile.FullName);
                Images.Add(new BitmapImage(uri));
            }
            return Images;
        }
    }
}
