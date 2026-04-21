#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion


namespace syncfusion.olapchartdemos.wpf
{
    using Microsoft.Xaml.Behaviors;
    using Syncfusion.Windows.Tools.Olap;

    class AxisElementLoadedBehaviour : Behavior<AxisElementBuilder>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.OlapDataManager = (this.AssociatedObject.DataContext as OlapChartDemoViewModel).ChartDataManager;
            //Since the AxisElementBuilders Elements are not loading by default 
            if (this.AssociatedObject.Axis == Syncfusion.Olap.Reports.AxisPosition.Slicer)
                this.AssociatedObject.OlapDataManager.NotifyElementModified();
        }
    }
}
