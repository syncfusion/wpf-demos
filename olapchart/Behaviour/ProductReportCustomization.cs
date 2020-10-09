#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace syncfusion.olapchartdemos.wpf
{
    using Syncfusion.Windows.Chart.Olap;
    using Syncfusion.Windows.Chart;
    using System.Windows;
    using Microsoft.Xaml.Behaviors;

    public class ProductReportCustomization : TargetedTriggerAction<OlapChart>
    {
        protected override void Invoke(object parameter)
        {
            for (int i = 0; i < this.Target.Series.Count; i++)
            {
                this.Target.Series[i].AdornmentsInfo = new ChartAdornmentInfo
                {
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top,
                    Visible = true,
                    Symbol = Symbol.Custom,
                    SymbolTemplate = Application.Current.Resources["SeriesPointTemplates" + i.ToString()] as DataTemplate,
                    LabelTemplate = Application.Current.Resources["LabelTemplate" + i.ToString()] as DataTemplate
                };
            }
        }
    }
}
