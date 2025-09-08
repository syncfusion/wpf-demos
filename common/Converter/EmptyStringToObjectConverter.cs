#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.demoscommon.wpf
{
    /// <summary>
    /// This class converts a string value into a an object (if the value is null or empty returns the false value).
    /// Can be used to bind a visibility, a color or an image to the value of a string.
    /// </summary>
    public class EmptyStringToObjectConverter : EmptyObjectToObjectConverter
    {
        /// <summary>
        /// Checks string for emptiness.
        /// </summary>
        /// <param name="value">Value to be checked.</param>
        /// <returns>True if value is null or empty string, false otherwise.</returns>
        protected override bool CheckValueIsEmpty(object value)
        {
            return string.IsNullOrEmpty(value?.ToString());
        }
    }
}