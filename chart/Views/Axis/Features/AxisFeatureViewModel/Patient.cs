#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.chartdemos.wpf
{
    /// <summary>Represents a patient with a name and height.</summary>
    public class Patient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Patient"/> class.
        /// </summary>
        /// <param name="currentName">Represents the patient's name.</param>
        /// <param name="currentHeight">Represents the patient's height.</param>
        public Patient(string currentName, double currentHeight)
        {
            Name = currentName;
            Height = currentHeight;
        }

        /// <summary>Gets or sets the patient's name.</summary>
        public string Name { get; set; }

        /// <summary>Gets or sets the patient's height.</summary>
        public double Height { get; set; }
    } 
}
