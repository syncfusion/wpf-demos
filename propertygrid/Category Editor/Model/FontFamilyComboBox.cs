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
    public class FontFamilyComboBox : ObservableCollection<FontFamily>
    {
        public FontFamilyComboBox()
        {
            Add(new FontFamily("Arial"));
            Add(new FontFamily("Courier New"));
            Add(new FontFamily("Times New Roman"));
            Add(new FontFamily("Batang"));
            Add(new FontFamily("BatangChe"));
            Add(new FontFamily("DFKai-SB"));
            Add(new FontFamily("Dotum"));
            Add(new FontFamily("DutumChe"));
            Add(new FontFamily("FangSong"));
            Add(new FontFamily("GulimChe"));
            Add(new FontFamily("Gungsuh"));
            Add(new FontFamily("GungsuhChe"));
            Add(new FontFamily("KaiTi"));
            Add(new FontFamily("Malgun Gothic"));
            Add(new FontFamily("Meiryo"));
            Add(new FontFamily("Microsoft JhengHei"));
            Add(new FontFamily("Microsoft YaHei"));
            Add(new FontFamily("MingLiU"));
            Add(new FontFamily("MingLiu_HKSCS"));
            Add(new FontFamily("MingLiu_HKSCS-ExtB"));
            Add(new FontFamily("MingLiu-ExtB"));
            Add(new FontFamily("Segoe UI"));
        }
    }
}
