using Syncfusion.UI.Xaml.TreeGrid.Cells;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace FileExplorer
{
    class TemplateImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var dataContextHelper = value as TreeGridDataContextHelper;           
            var record = dataContextHelper.Record as FileInfoModel;
            if (record.FileType == "Drive")
                return new BitmapImage(new Uri("pack://application:,,/Images/DriveNode.png"));
            else if (record.FileType == "Directory")
                return new BitmapImage(new Uri("pack://application:,,/Images/folder.png"));
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
