#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Syncfusion.SfSkinManager;
using System;
using System.ComponentModel;

namespace syncfusion.layoutdemos.wpf
{
    /// <summary>
    /// Interaction logic for ChromelessWindowDemosView.xaml
    /// </summary>
    public partial class GettingStarted
    {
        public GettingStarted()
        {
            InitializeComponent();
        }

        public GettingStarted(string themename)
        {
            SfSkinManager.SetTheme(this, new Theme() { ThemeName = themename });
            InitializeComponent();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            // Release all managed resources
            if (this.cornerRadiusValueTextBlock != null)
                this.cornerRadiusValueTextBlock = null;
            if (this.cornerRadiusSlider != null)
                this.cornerRadiusSlider = null;   
            if (this.cornerRadius != null)
                this.cornerRadius = null;
            if (this.resizeThicknessValueTextBlock != null)
                this.resizeThicknessValueTextBlock = null;
            if(this.resizeThicknessSlider != null)
                this.resizeThicknessSlider = null;
            if (this.resizeThicknessTextBlock != null)
                this.resizeThicknessTextBlock = null;
            if (this.titleBarValueTextBlock != null)
                this.titleBarValueTextBlock = null;
            if (this.titleBarHeight != null)
                this.titleBarHeight = null;
            if (this.titleBarTextBlock != null)
                this.titleBarTextBlock = null;
            if (this.opacityValueTextBlock != null)
                this.opacityValueTextBlock = null;
            if (this.opacityChanger != null)
                this.opacityChanger = null;
            if (this.opacityTextBlock != null)
                this.opacityTextBlock = null;
            base.OnClosing(e);
        }

        private void ResizeThicknessSlider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            resizeThicknessValueTextBlock.Text = Math.Round(resizeThicknessSlider.Value).ToString();
        }

        private void CornerRadiusSlider_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            cornerRadiusValueTextBlock.Text = Math.Round(cornerRadiusSlider.Value).ToString();
        }

        private void TitleBarHeight_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            titleBarValueTextBlock.Text = Math.Round(titleBarHeight.Value).ToString();
        }

        private void OpacityChanger_ValueChanged(object sender, System.Windows.RoutedPropertyChangedEventArgs<double> e)
        {
            opacityValueTextBlock.Text = Math.Round(opacityChanger.Value,1 ).ToString();
        }
    }
}
