using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.IO;
using System.Windows.Media.Imaging;

namespace syncfusion.treeviewdemos.wpf
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is DriveInfo)
            {
                DriveInfo info = value as DriveInfo;
                if (info.IsReady)
                {
                    
                    return new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/CD_Drive.png", UriKind.Relative));
                }
                else
                {
                    return new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/dvddrive.png", UriKind.Relative));
                }
            }
            else
            {
                return new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/folder.png", UriKind.Relative));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    } 
}
