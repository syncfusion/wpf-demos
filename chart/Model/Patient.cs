#region Copyright Syncfusion Inc. 2001 - 2023
// Copyright Syncfusion Inc. 2001 - 2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace syncfusion.chartdemos.wpf
{
    public class Patient
    {
        public Patient(string currentName, double currentHeight)
        {
            Name = currentName;
            Height = currentHeight;
        }

        public string Name { get; set; }

        public double Height { get; set; }        
    } 
}
