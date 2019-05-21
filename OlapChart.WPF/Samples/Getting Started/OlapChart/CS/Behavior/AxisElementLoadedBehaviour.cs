#region Copyright Syncfusion Inc. 2001 - 2019
// <copyright file="AxisElementLoadedBehaviour.cs" company="syncfusion">
//  Copyright (c) Syncfusion Inc. 2001 - 2019. All rights reserved.
//  Use of this code is subject to the terms of our license.
//  A copy of the current license can be obtained at any time by e-mailing
//  licensing@syncfusion.com. Re-distribution in any form is strictly
//  prohibited. Any infringement will be prosecuted under applicable laws. 
// </copyright>
#endregion

namespace OlapChart.Behavior
{
    using System.Windows.Interactivity;
    using Syncfusion.Windows.Tools.Olap;

    class AxisElementLoadedBehaviour : Behavior<AxisElementBuilder>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.OlapDataManager = (this.AssociatedObject.DataContext as ViewModel.ViewModel).ChartDataManager;
            //Since the AxisElementBuilders Elements are not loading by default 
            if (this.AssociatedObject.Axis == Syncfusion.Olap.Reports.AxisPosition.Slicer)
                this.AssociatedObject.OlapDataManager.NotifyElementModified();
        }
    }
}
