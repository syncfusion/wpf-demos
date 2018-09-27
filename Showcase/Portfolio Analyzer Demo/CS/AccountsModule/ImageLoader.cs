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
