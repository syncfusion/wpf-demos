#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
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
using Microsoft.Xaml.Behaviors;

namespace syncfusion.chartdemos.wpf
{
    public class DragRegulationBehavior: Behavior<UIElement>
    {
        protected override void OnAttached()
        {
            var series = AssociatedObject as XySegmentDraggingBase;

            series.SegmentEnter += XySegmentDraggingBase_OnSegmentMouseOver;
            series.DragStart += XySegmentDraggingBase_OnDragStart;
            series.DragDelta += XySegmentDraggingBase_OnDragDelta;

            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            var series = AssociatedObject as XySegmentDraggingBase;

            if (series != null)
            {
                series.SegmentEnter -= XySegmentDraggingBase_OnSegmentMouseOver;
                series.DragStart -= XySegmentDraggingBase_OnDragStart;
                series.DragDelta -= XySegmentDraggingBase_OnDragDelta;
            }

            base.OnDetaching();
        }

        private void XySegmentDraggingBase_OnDragDelta(object sender, DragDelta e)
        {
            var info = e as XySegmentDragEventArgs;
            if (info == null) return;
            info.Cancel = info.NewYValue < 1;
        }

        private void XySegmentDraggingBase_OnDragStart(object sender, ChartDragStartEventArgs e)
        {
            e.Cancel = !(ReferenceEquals(e.BaseXValue, "2013")
                       || ReferenceEquals(e.BaseXValue, "2014")
                       || ReferenceEquals(e.BaseXValue, "2015")
                       || ReferenceEquals(e.BaseXValue, "2016"));
        }

        private void XySegmentDraggingBase_OnSegmentMouseOver(object sender, XySegmentEnterEventArgs e)
        {
            e.CanDrag = (ReferenceEquals(e.XValue, "2013")
                        || ReferenceEquals(e.XValue, "2014")
                        || ReferenceEquals(e.XValue, "2015")
                        || ReferenceEquals(e.XValue, "2016"));
        }
    }
}
