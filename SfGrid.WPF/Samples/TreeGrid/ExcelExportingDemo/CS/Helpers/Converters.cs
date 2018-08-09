using Syncfusion.UI.Xaml.TreeGrid.Converter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace ExcelExportingDemo
{
    public class ExcelOptionsConverter : IMultiValueConverter
    {

        private static bool isCutomized = false;
        public bool IsCutomized
        {
            get
            {
                return isCutomized;
            }
            set
            {
                isCutomized = value;
            }
        }
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var options = new TreeGridExcelExportingOptions();

            options.AllowOutliningGroups = (bool)values[0];
            options.AllowIndentColumn = (bool)values[1];
            options.IsGridLinesVisible = (bool)values[2];
            options.CanExportHyperLink = (bool)values[3];

            var value = (int)values[4];
            options.NodeExpandMode = (value == 0 ? NodeExpandMode.Default : (value == 1 ? NodeExpandMode.ExpandAll : NodeExpandMode.CollapseAll));
            isCutomized = (bool)values[5];
            return options;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }
    }
}
