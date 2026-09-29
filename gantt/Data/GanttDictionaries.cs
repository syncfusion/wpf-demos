using System;
using System.Windows;

namespace syncfusion.ganttdemos.wpf
{
    internal static class GanttDictionaries
    {
        private static ResourceDictionary ganttStyleDictionary;

        internal static ResourceDictionary GanttStyleDictionary
        {
            get
            {
                if (ganttStyleDictionary == null)
                {
                    ganttStyleDictionary = new ResourceDictionary()
                    {
                        Source = new Uri("/syncfusion.ganttdemos.wpf;component/Data/GanttStyle.xaml", UriKind.RelativeOrAbsolute)
                    };
                }

                return ganttStyleDictionary;
            }
        }
    }
}
