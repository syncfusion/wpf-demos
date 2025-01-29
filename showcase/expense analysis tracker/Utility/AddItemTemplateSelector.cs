#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows;
using System.Windows.Controls;

namespace syncfusion.expenseanalysis.wpf
{
    public class AddItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ViewTemplate { get; set; }

        public DataTemplate AddTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is AddBudget || item is AddGoal)
            {
                return AddTemplate;
            }
            else
            {
                return ViewTemplate;
            }
        }
    }

    public class IncomeExpenseTemplateSelector : DataTemplateSelector
    {
        public DataTemplate IncomeTemplate { get; set; }

        public DataTemplate ExpenseTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is double)
            {
                if ((double)item > 0)
                {
                    return IncomeTemplate;
                }
                else
                {
                    return ExpenseTemplate;
                }
            }
            return null;
        }
    }

}