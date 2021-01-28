#region Copyright Syncfusion Inc. 2001 - 2021
// Copyright Syncfusion Inc. 2001 - 2021. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using Syncfusion.Windows.PropertyGrid;
using System.Windows.Data;
using Syncfusion.Windows.Shared;
using System.Reflection;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace syncfusion.propertygriddemos.wpf
{
    //Custom Editor for the multiple(Integer type) properties
    [Editor(typeof(int), typeof(IntUpDownEditor))]

    //CustomEditor for the specfic(EmailID) property
    [Editor("EmailID", typeof(CustomMaskEditor))]

    //CustomEditor for image property
    [Editor(typeof(ImageSource), typeof(ImageEditor))]
    public class PrivateEmployee
    { 
        [Display(Description ="Name of the Employee")]
        public string Name { get; set; }

        [ReadOnly(true)]
        [Display(Description = "Age of the Employee")]
        public int Age { get; set; }

        [Display(Description = "Monthly salary of the Employee")]
        public string Salary { get; set; }

        [Display(Description = "Email-ID of the Employee")]
        public string EmailID { get; set; }

        [Display(Description = "Work Experience of the Employee")]
        public int Experience { get; set; }

        [Description("Height of the Employee")]
        [Display(Name= "Height (cm)")]
        public double Height { get; set; }

        [Description("Weight of the Employee")]
        [Display(Name = "Weight (kg)")]
        public double Weight { get; set; }

        [Display(Description = "Profile picture of the Employee")]
        public ImageSource Image { get; set; }       
    }
}
