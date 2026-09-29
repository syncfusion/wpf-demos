using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace syncfusion.schedulerdemos.wpf
{
    public class MonthCellTemplateSelector : DataTemplateSelector
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MonthCellTemplateSelector" /> class.
        /// </summary>
        public MonthCellTemplateSelector()
        {

        }

        /// <summary>
        /// Gets or sets Month Appointment Template.
        /// </summary>
        public DataTemplate MonthCellWithoutBestPriceTemplate { get; set; }

        /// <summary>
        /// Gets or sets Month Cell Dates Template.
        /// </summary>
        public DataTemplate MonthCellWithBestPriceTemplate { get; set; }

        /// <summary>
        /// Template selection method
        /// </summary>
        /// <param name="item">return the object</param>
        /// <param name="container">return the bindable object</param>
        /// <returns>return the template</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var appointments = item as List<ScheduleAppointment>;

            foreach(var app in appointments)
            {
                if (app.Notes == "$100.17")
                    return MonthCellWithBestPriceTemplate;
                else
                    return MonthCellWithoutBestPriceTemplate;
            }
            return MonthCellWithoutBestPriceTemplate;
        }
    }
}
