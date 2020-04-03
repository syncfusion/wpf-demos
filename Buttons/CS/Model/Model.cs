#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using System.ComponentModel;

namespace Button_Controls
{
    /// <summary>
    /// Represents a standard button control model.
    /// </summary>
    public class Model
    {
        /// <summary>
        /// Specifies the dropdown item name.
        /// </summary>
        private string name;

        /// <summary>
        /// Specifies the path of the image to add inside the dropdown item. 
        /// </summary>
        private string imagePath;

        /// <summary>
        /// Gets or sets the name for the dropdown item to be displayed when press the button control.
        /// </summary>
        [Description("Specifies the name for the dropdown item to be displayed when press the button control")]
        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                if (name != value)
                    name = value;
            }
        }

        /// <summary>
        /// Gets or sets the image path for the dropdown item to be displayed when press the button control.
        /// </summary>
        [Description("Specifies the image path for the dropdown item to be displayed when press the button control")]
        public string ImagePath
        {
            get
            {
                return imagePath;
            }
            set
            {
                if (imagePath != value)
                    imagePath = value;
            }
        }
    }
}
