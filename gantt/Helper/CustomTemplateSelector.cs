#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using Syncfusion.Windows.Controls.Gantt.Chart;

namespace syncfusion.ganttdemos.wpf
{
    public class CustomTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            StripLine info = item as StripLine;

            if (info.StartDate == new DateTime(2012, 6, 18))
            {
                info.Content = "Demo about Mareket scope of the Product";
                return GanttDictionaries.GanttStyleDictionary["customTemplate"] as DataTemplate;
            }
            else if (info.StartDate == new DateTime(2012, 7, 16))
            {
                info.Content = "Demo about Infrastructure of Product Planing";
                return GanttDictionaries.GanttStyleDictionary["customTemplate"] as DataTemplate;
            }
            else if (info.StartDate == new DateTime(2012, 9, 3))
            {
                info.Content = "Demo About Product Defination Phase";
                return GanttDictionaries.GanttStyleDictionary["customTemplate"] as DataTemplate;
            }
            else if (info.StartDate == new DateTime(2012, 9, 10))
            {
                info.Content = "Demo About the Customer Requirement";
                return GanttDictionaries.GanttStyleDictionary["customTemplate"] as DataTemplate;
            }
            else if (info.StartDate == new DateTime(2012, 9, 24))
            {
                info.Content = "Demo about Risk Management and Budget of the product";
                return GanttDictionaries.GanttStyleDictionary["customTemplate"] as DataTemplate;
            }
            else if (info.StartDate == new DateTime(2012, 10,8 ))
            {
                info.Content = "Demo about Competitors features";
                return GanttDictionaries.GanttStyleDictionary["customTemplate"] as DataTemplate;
            }
            else if (info.StartDate == new DateTime(2012, 11, 12))
            {
                info.Content = "Demo about the Product Development and Review";
                return GanttDictionaries.GanttStyleDictionary["customTemplate"] as DataTemplate;
            }
            else if (info.StartDate == new DateTime(2012, 12, 3))
            {
                info.Content = "Meeting with testing team about issues is Development";
                return GanttDictionaries.GanttStyleDictionary["customTemplate"] as DataTemplate;
            }
            return base.SelectTemplate(item, container);
        }
    }
}
