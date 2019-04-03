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
using System.ComponentModel;

namespace CallCenterDemo
{
    public class MonthlyCallModel
    {
        Random rand = new Random();
        public MonthlyCallModel()
        { 
            
        }

        private double _TotalCalls;
        public double TotalCalls
        {
            get
            {
                return _TotalCalls;
            }
            set
            {
                _TotalCalls = value;
            }
        }

        private string _Monthname;
        public string Monthname
        {
            get
            {
                return _Monthname;
            }
            set
            {
                _Monthname = value;
            }
        }

        public double ResolvedCalls
        {
            get;
            set;
        }

        public double EmployeeRetention
        {
            get;
            set;
        }

        public double EmployeeRetention2
        {
            get;
            set;
        }

        public double ScheduleEfficiency
        {
            get;
            set;
        }

        public double ScheduleEfficiency2
        {
            get;
            set;
        }

        public double ServiceUtilization
        {
            get;
            set;
        }

        public double ServiceUtilization2
        {
            get;
            set;
        }


    }
}
