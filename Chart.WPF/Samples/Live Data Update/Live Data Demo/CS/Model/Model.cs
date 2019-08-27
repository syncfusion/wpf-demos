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
using System.Diagnostics;
using System.ComponentModel;

namespace LiveDataDemo
{
    #region Measure
    /// <summary>
    /// Data collection with Time and Stock of Measurement
    /// </summary>
    /// <returns></returns>

    public class Measure:INotifyPropertyChanged
    {
        PerformanceCounter cpuPerformance;
        PerformanceCounter ramPerformance;

        double time = 12d;
        static double angle = 0;
        public Measure()
        {
            this.cpuPerformance = new PerformanceCounter();
            this.cpuPerformance.CategoryName = "Processor";
            this.cpuPerformance.CounterName = "% Processor Time";
            this.cpuPerformance.InstanceName = "_Total";

            this.ramPerformance = new PerformanceCounter("Memory", "Available MBytes");
            this.X1 = (Math.Sin(Math.Abs(angle)) * 10) + 50;// r.Next(10, 99); //(double)this.cpuPerformance.Container.Components.Count;
            angle += 0.05;
            this.X2 = this.ramPerformance.RawValue;
            this.Time = time;
            time+=5;
        }
        public double Time
        {
            get;
            set;
        }
        private double _X1;
        public double X1
        {
            get
            {
                return _X1;
            }
            set
            {
                _X1 = value;
                this.OnPropertyChanged(X1);
            }
            
        }
        private double _X2;
        public double X2
        {
            get
            {
                return _X2;
            }
            set
            {
                _X2 = value;
                this.OnPropertyChanged(X2);
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(object Property)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("Property"));
            }
        }
    }
    #endregion
}
