#region Copyright Syncfusion® Inc. 2001-2025.
// Copyright Syncfusion® Inc. 2001-2025. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;

namespace syncfusion.weatheranalysis.wpf
{
    /// <summary>
    /// Interaction logic for DayDetailsView.xaml.
    /// </summary>
    public partial class DayDetailsView : UserControl
    {
        public DayDetailsView()
        {
            InitializeComponent();
        }

        public double GetTextBlockExpectedWidth(string text, FontFamily fontFamily, double fontSize, FontStyle fontStyle, FontWeight fontWeight)
        {
            var formattedText = new FormattedText(
                                    text,
                                    CultureInfo.CurrentCulture,
                                    FlowDirection.LeftToRight,
                                    new Typeface(fontFamily, fontStyle, fontWeight, FontStretches.Normal),
                                    fontSize,
                                    Brushes.Black);
            return formattedText.Width;
        }

        void UpdateTextBlockText(TextBlock textBlock, Size size, Run arrowline)
        {
            int margin = 10;
            int offset = 5;
            var newWidth = size.Width - (sunGrid.ActualWidth * 2) - (2 * margin) - offset;
            var text = "-";
            var withArrowHead = text + ">";
            while (newWidth > GetTextBlockExpectedWidth(withArrowHead, textBlock.FontFamily, textBlock.FontSize, textBlock.FontStyle, textBlock.FontWeight))
            {
                text += "-";
                withArrowHead = text + ">";
            }

            arrowline.Text = withArrowHead;
        }

        private void RiseSetTimeDetails_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            UpdateTextBlockText(arrow_textBlock, e.NewSize, arrowRunline);
            UpdateTextBlockText(arrow_textBlock1, e.NewSize, arrowRunline1);
        }

        public void Dispose()
        {
            if (this.DataContext is DayWeatherInfoViewModel dayWeatherInfoViewModel)
            {
                dayWeatherInfoViewModel.Dispose();
            }
        }
    }
}
