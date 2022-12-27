#region Copyright Syncfusion Inc. 2001-2022.
// Copyright Syncfusion Inc. 2001-2022. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
//Custom Editor for the multiple(Integer type) properties
[Editor(typeof(int), typeof(IntUpDownEditor))]

//CustomEditor for the specfic(EmailID) property
[Editor("EmailID", typeof(CustomMaskEditor))]

//CustomEditor for image property
[Editor(typeof(ImageSource), typeof(ImageEditor))]
public class PrivateEmployee
{
    public string Name { get; set; }

    public int Age { get; set; }

    public string Salary { get; set; }

    public string EmailID { get; set; }

    public int Experience { get; set; }

    public double Height { get; set; }

    public double Weight { get; set; }

    public ImageSource Image { get; set; }
}
