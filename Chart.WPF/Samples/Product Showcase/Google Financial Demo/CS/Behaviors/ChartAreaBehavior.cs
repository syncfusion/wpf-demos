#region Copyright Syncfusion Inc. 2001-2018.
// Copyright Syncfusion Inc. 2001-2018. All rights reserved.
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

namespace GoogleFinanceDemo
{
    class ChartAreaBehavior : Behavior<Window1>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.area.MouseMove += new System.Windows.Input.MouseEventHandler(area_MouseMove);
        }

        void area_MouseMove(object sender, System.Windows.Input.MouseEventArgs e)
        {
            if (this.AssociatedObject.series1.Data != null)
            {
                for (int i = 0; i < this.AssociatedObject.series1.Data.Count; i++)
                {
                    if (this.AssociatedObject.series1.Data[i].X == Math.Round((sender as ChartArea).PointToValue((sender as ChartArea).PrimaryAxis, e.GetPosition((sender as ChartArea)))))
                    {
                        this.AssociatedObject.date.Text = ((GoogleFinanceDemo.GoogleData)(this.AssociatedObject.series1.Data[i].Item)).TimeStamp.ToString("MMM d, yyyy");
                        this.AssociatedObject.vol.Text = ((GoogleFinanceDemo.GoogleData)(this.AssociatedObject.series1.Data[i].Item)).High.ToString();
                    }
                }
            }
        }

      }
}
