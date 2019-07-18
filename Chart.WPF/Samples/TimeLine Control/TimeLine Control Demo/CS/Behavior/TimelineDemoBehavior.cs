#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Chart;


namespace TimeLineControlSample
{
    class TimelineDemoBehavior:Behavior<MainWindow>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
            
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            DataCollection collection = new DataCollection();
            this.AssociatedObject.timelineControl.HoldUpdate = true;
            this.AssociatedObject.timelineControl.PrimaryAxis.DateTimeInterval = new TimeSpan(268, 0, 0, 0);
            this.AssociatedObject.timelineControl.DataSource = collection.datalist;
            this.AssociatedObject.timelineControl.BindingPathX = "TimeStamp";
            this.AssociatedObject.timelineControl.BindingPathsY = new string[] { "High" };
            this.AssociatedObject.timelineControl.HoldUpdate = false;
            this.AssociatedObject.timelineControl.EndInit();
            this.AssociatedObject.DataContext = collection.datalist;
            this.AssociatedObject.area.MouseMove += new System.Windows.Input.MouseEventHandler(area_MouseMove);
        }

        void area_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if( this.AssociatedObject.series1.Data!=null)
            for (int i = 0; i < this.AssociatedObject.series1.Data.Count; i++)
            {
                if (this.AssociatedObject.series1.Data[i].X == Math.Round((sender as ChartArea).PointToValue((sender as ChartArea).PrimaryAxis, e.GetPosition((sender as ChartArea)))))
                {
                    this.AssociatedObject.date.Text = ((TimeLineControlSample.TimeLineData)(this.AssociatedObject.series1.Data[i].Item)).TimeStamp.ToString("MMM d, yyyy");
                    this.AssociatedObject.vol.Text = ((TimeLineControlSample.TimeLineData)(this.AssociatedObject.series1.Data[i].Item)).High.ToString();
                }
            }
        }

    }
}
