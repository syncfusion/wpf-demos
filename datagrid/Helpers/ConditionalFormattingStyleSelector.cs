#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.Data;
using Syncfusion.UI.Xaml.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace syncfusion.datagriddemos.wpf
{
    public class ConditionalFormattingStyleSelector : StyleSelector
    {
        ConditionalFormattingDemo conditionalFormattingDemo;
        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (conditionalFormattingDemo == null)
                conditionalFormattingDemo = (ConditionalFormattingDemo)Activator.CreateInstance(typeof(ConditionalFormattingDemo));

            return conditionalFormattingDemo.Resources["normaltableSummaryCell"] as Style;
        }
    }
}
