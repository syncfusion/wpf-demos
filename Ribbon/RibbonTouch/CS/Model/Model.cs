#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace RibbonSample
{
    /// <summary>
    /// Class represents the model for ribbon touch.
    /// </summary>
    public class Model
    {
        /// <summary>
        /// Maintains the slide number.
        /// </summary>
        private int slideNumber;

        /// <summary>
        /// Maintains the text inside the slide item.
        /// </summary>
        private string itemText;

        /// <summary>
        /// Maintains the description of each slide item.
        /// </summary>
        private string description;

        /// <summary>
        /// Maintains the font family for RibbonComboBox Control.
        /// </summary>
        private string fontFamily;

        /// <summary>
        /// Maintains the font size for RibbonComboBox Control.
        /// </summary>
        private int fontSize;

        /// <summary>
        /// Gets or sets the value for slide number <see cref="Model"/> class.
        /// </summary>
        public int SlideNumber
        {
            get
            {
                return slideNumber;
            }
            set
            {
                slideNumber = value;
            }
        }

        /// <summary>
        /// Gets and sets the value for item text <see cref="Model"/> class.
        /// </summary>
        public string ItemText
        {
            get
            {
                return itemText;
            }
            set
            {
                itemText = value;
            }
        }

        /// <summary>
        /// Gets and sets the value for description <see cref="Model"/> class.
        /// </summary>
        public string Description
        {
            get
            {
                return description;
            }
            set
            {
                description = value;
            }
        }

        /// <summary>
        /// Gets or sets the font family of the <see cref="Model"/> class.
        /// </summary>     
        public string FontFamily
        {
            get
            {
                return fontFamily;
            }
            set
            {
                fontFamily = value;
            }
        }

        /// <summary>
        /// Gets or sets the font size of the <see cref="Model"/> class.
        /// </summary>     
        public int FontSize
        {
            get
            {
                return fontSize;
            }
            set
            {
                fontSize = value;
            }
        }
    }
}
