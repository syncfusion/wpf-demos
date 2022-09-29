#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
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
