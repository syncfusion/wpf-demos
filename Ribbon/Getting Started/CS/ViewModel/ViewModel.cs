#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using RibbonSample;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace RibbonSample
{
    /// <summary>
    /// Represents the behaviour code for Window1.xaml
    /// </summary>
    class ViewModel
    {
        #region Fields
        /// <summary>
        /// Maintains the collection of font family.
        /// </summary>
        private ObservableCollection<Model> fontfamilyList = new ObservableCollection<Model>();

        /// <summary>
        /// Maintains the collection of font size.
        /// </summary>
        private ObservableCollection<Model> fontsizeList = new ObservableCollection<Model>();
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            Model model = new Model();
            FontSizeAndFamily();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the font.family for the ItemSource of RibbonComboBox Control <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> FontFamilyList
        {
            get { return fontfamilyList; }
            set { fontfamilyList = value; }
        }
        /// <summary>
        /// Gets or sets the font.size for the ItemSource of the RibbonComboBox Control <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> FontSizeList
        {
            get { return fontsizeList; }
            set { fontsizeList = value; }
        }
        #endregion

        #region Methods
        /// <summary>
        /// Adding Font size and family to the collections.
        /// </summary>
        /// <remarks>
        /// The font family is added to the list by <see cref="System.Windows.Media.FontFamily"/> class.
        /// </remarks>
        public void FontSizeAndFamily()
        {
            int[] sizes = new int[15] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 28, 36, 48, 72 };
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                FontFamilyList.Add(new Model() { FontFamily = fontFamily.ToString() });
            }
            for (int i = 0; i < sizes.Length; i++)
            {
                FontSizeList.Add(new Model() { FontSize = sizes[i] });
            }
        }
        #endregion
    }
}
