using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace syncfusion.treeviewdemos.wpf
{
    public class ImageTruncater : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value == null)
            {
                return new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/CD_Drive.png", UriKind.Relative));
            }
            else if (value is BitmapImage)
            {
                if (value.ToString().Contains("folder"))
                {
                    return new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/folderopen.png",UriKind.Relative));
                }
                return value;
            }
            else
            {
                return new BitmapImage(new Uri(@"/syncfusion.treeviewdemos.wpf;component/Assets/treeview/folderopen.png", UriKind.Relative));
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
