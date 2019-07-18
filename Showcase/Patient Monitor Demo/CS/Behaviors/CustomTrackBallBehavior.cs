#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Charts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace PatientDetailsDemo
{
    public class CustomTrackBallBehavior: ChartTrackBallBehavior
    {
        public DataTemplate CustomLabelTemplate
        {
            get { return (DataTemplate)GetValue(CustomLabelTemplateProperty); }
            set { SetValue(CustomLabelTemplateProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CustomLabelTemplate.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CustomLabelTemplateProperty =
            DependencyProperty.Register("CustomLabelTemplate", typeof(DataTemplate), typeof(CustomTrackBallBehavior), new PropertyMetadata(null));

        protected override void GenerateLabels()
        {
            if (PointInfos.Count>3)
            {
                AddLabel(PointInfos[0], LabelVerticalAlignment, LabelHorizontalAlignment,
                    PointInfos[0].Series.TrackBallLabelTemplate);
                AddLabel(PointInfos[1], LabelVerticalAlignment, LabelHorizontalAlignment,
                    PointInfos[1].Series.TrackBallLabelTemplate);

                ChartPointInfo pointInfo1 = PointInfos[2];
                ChartPointInfo pointInfo2 = PointInfos[3];

                CustomLabel label = new CustomLabel();
                label.Value1 = pointInfo2.ValueY;
                label.Value2 = pointInfo1.ValueY;

                var actualYAxis = (pointInfo1.Series as ISupportAxes).ActualYAxis;
                if (actualYAxis != null)
                {
                    Rect rect = actualYAxis.ArrangeRect;
                    label.Axis = actualYAxis;
                    AddLabel(label, LabelVerticalAlignment, LabelHorizontalAlignment, CustomLabelTemplate, pointInfo1.X,
                        rect.Bottom);
                }
            }
        }
    }

    public class CustomLabel : ChartPointInfo
    {
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
}
