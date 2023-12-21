#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.logicalcircuitdesigner.wpf.Model;
using System;
using System.Windows;
using System.Windows.Threading;

namespace syncfusion.logicalcircuitdesigner.wpf.ViewModel
{
    public class ClockViewModel : BaseGateViewModel
    {
        private int? mTimerValue = null;
        private DispatcherTimer Timer;

        public ClockViewModel() : base()
        {
            this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources["ClockNode"] as DataTemplate;
        } 

        /// <summary>
        /// Gets or sets select value of Textbox.
        /// </summary>
        public int? TimerValue
        {
            get
            {
                return mTimerValue;
            }
            set
            {
                if (mTimerValue != value)
                {
                    mTimerValue = value;
                    OnPropertyChanged("TimerValue");
                }
            }
        }

        protected override void OnPropertyChanged(string name)
        {
            base.OnPropertyChanged(name);
            if (name == "TimerValue")
            {
                if (this.mTimerValue.HasValue && this.mTimerValue.Value > 0)
                {
                    this.Timer = new DispatcherTimer();
                    this.Timer.Interval = new TimeSpan(0, 0, 0, 0, mTimerValue.Value);
                    this.Timer.Tick += this.ClockTimer_Tick;
                    this.Timer.Start();
                }
                else if (this.Timer != null)
                {
                    this.Timer.Tick -= this.ClockTimer_Tick;
                    this.Timer.Stop();
                    this.Timer = null;
                }
            }
        }

        protected override void RefreshTemplate()
        {
            var resourceName = this.State == BinaryState.Zero ? Constants.DefaultClockSwitch : Constants.ActiveClockSwitch;
            this.ContentTemplate = this.DiagramModel == null || this.DiagramModel.View == null ? null : this.DiagramModel.View.Resources[resourceName] as DataTemplate;
        }

        public override void Dispose()
        {
            base.Dispose();
            if (this.Timer != null)
            {
                this.Timer.Tick -= this.ClockTimer_Tick;
                this.Timer.Stop();
                this.Timer = null;
            }
        }

        private void ClockTimer_Tick(object sender, object e)
        {
            this.State = this.State == BinaryState.Zero ? BinaryState.One : BinaryState.Zero;
        }
    }
}
