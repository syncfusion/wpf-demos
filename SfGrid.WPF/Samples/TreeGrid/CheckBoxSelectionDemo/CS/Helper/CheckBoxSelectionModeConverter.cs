using Syncfusion.UI.Xaml.TreeGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CheckBoxSelection
{
    internal class CheckBoxSelectionModeConverter : IValueConverter
    {     
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int? index = value as int?;
            switch (index)
            {
                case 0:
                    return CheckBoxSelectionMode.Default;
                case 1:
                    return CheckBoxSelectionMode.SelectOnCheck;
                case 2:
                    return CheckBoxSelectionMode.SynchronizeSelection;

                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
