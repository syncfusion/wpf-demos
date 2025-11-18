using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.chartdemos.wpf
{
    public class BarTopConverter : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var itemData = (item as BarSegment).XData;

            if (itemData == 0.0)
                return ChartDictionary.GenericDictionary["carTemplate1"] as DataTemplate;
            else if (itemData == 1.0)
                return ChartDictionary.GenericDictionary["carTemplate2"] as DataTemplate;
            else if (itemData == 2.0)
                return ChartDictionary.GenericDictionary["carTemplate3"] as DataTemplate;
            else if (itemData == 3.0)
                return ChartDictionary.GenericDictionary["carTemplate4"] as DataTemplate;
            return ChartDictionary.GenericDictionary["carTemplate5"] as DataTemplate;
        }
    }

    internal static class ChartDictionary
    {
        internal static ResourceDictionary GenericDictionary = new ResourceDictionary()
        {
            Source = new Uri(@"/syncfusion.chartdemos.wpf;component/Resources/CustomTemplate.xaml", UriKind.RelativeOrAbsolute)
        };
    }
}
