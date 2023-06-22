#region Copyright Syncfusion Inc. 2001-2023.
// Copyright Syncfusion Inc. 2001-2023. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.SfSkinManager;
using Syncfusion.Windows.Tools.Controls;

namespace syncfusion.pdfviewerdemos.wpf
{
    /// <summary>
    /// Interaction logic for CustomToolbar.xaml
    /// </summary>
    public partial class CustomToolbar : RibbonWindow
    {
        public CustomToolbar()
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = "Office2019Colorful" });
            InitializeComponent();
        }
    }
}
