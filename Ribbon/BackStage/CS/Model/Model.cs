#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

namespace BackStageSample
{
    class Model
    {
        /// <summary>
        ///  Maintains the collection of font family for RinnobComboBox control.
        /// </summary>
        private string fontFamily;

        /// <summary>
        ///  Maintains the collection of font size for RinnobComboBox control.
        /// </summary>
        private int fontSize;

        /// <summary>
        ///  Gets or sets the font family for the RibbonComboBox Control <see cref="Model"/> class.
        /// </summary>
        public string FontFamily
        {
            get { return fontFamily; }
            set { fontFamily = value; }
        }

        /// <summary>
        ///  Gets or sets the font size for RibbonComboBox <see cref="Model"/> class.
        /// </summary>
        public int FontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }
    }
}
