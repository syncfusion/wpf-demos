#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System.Windows.Controls;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace syncfusion.propertygriddemos.wpf
{
    public class FontFamilyComboBox : ComboBox
    {
        public FontFamilyComboBox()
        {
            ObservableCollection<FontFamily> fonts = new ObservableCollection<FontFamily>();
            fonts.Add(new FontFamily("Arial"));
            fonts.Add(new FontFamily("Courier New"));
            fonts.Add(new FontFamily("Times New Roman"));
            fonts.Add(new FontFamily("Batang"));
            fonts.Add(new FontFamily("BatangChe"));
            fonts.Add(new FontFamily("DFKai-SB"));
            fonts.Add(new FontFamily("Dotum"));
            fonts.Add(new FontFamily("DutumChe"));
            fonts.Add(new FontFamily("FangSong"));
            fonts.Add(new FontFamily("GulimChe"));
            fonts.Add(new FontFamily("Gungsuh"));
            fonts.Add(new FontFamily("GungsuhChe"));
            fonts.Add(new FontFamily("KaiTi"));
            fonts.Add(new FontFamily("Malgun Gothic"));
            fonts.Add(new FontFamily("Meiryo"));
            fonts.Add(new FontFamily("Microsoft JhengHei"));
            fonts.Add(new FontFamily("Microsoft YaHei"));
            fonts.Add(new FontFamily("MingLiU"));
            fonts.Add(new FontFamily("MingLiu_HKSCS"));
            fonts.Add(new FontFamily("MingLiu_HKSCS-ExtB"));
            fonts.Add(new FontFamily("MingLiu-ExtB"));
            fonts.Add(new FontFamily("Segoe UI"));
            this.ItemsSource = fonts;
        }
    }
}
