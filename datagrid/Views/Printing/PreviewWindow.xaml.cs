#region Copyright Syncfusion Inc. 2001 - 2020
// Copyright Syncfusion Inc. 2001 - 2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Syncfusion.UI.Xaml.Grid;

namespace syncfusion.datagriddemos.wpf
{
    /// <summary>
    /// Interaction logic for PreviewWindow.xaml
    /// </summary>
    public partial class PreviewWindow : Window
    {
        const double cmConst = 37.79527559055;
        private PrintManagerBase printManager;
        private PrintPreviewAreaControl printDataContext;

        public PreviewWindow()
        {
            InitializeComponent();
        }

        void OnDataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            printDataContext = e.NewValue as PrintPreviewAreaControl;
            printManager = printDataContext.PrintManagerBase;
        }

        private void OnPartComboPapersSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if(printDataContext == null) return;
            printManager = printDataContext.PrintManagerBase;

            double width = 0;
            double height = 0;
            switch ((e.AddedItems[0] as ComboBoxItem).Content.ToString())
            {
                case "Letter":
                    width = 29.59;
                    height = 27.94;
                    break;

                case "Legal":
                    width = 29.59;
                    height = 35.56;
                    break;

                case "Executive":
                    width = 18.41;
                    height = 26.67;
                    break;

                case "A4":
                    width = 21;
                    height = 29.7;
                    break;

                case "Envelope #10":
                    width = 10.48;
                    height = 24.13;
                    break;

                case "Envelope DL":
                    width = 11;
                    height = 22;
                    break;

                case "Envelope C5":
                    width = 16.2;
                    height = 22.9;
                    break;

                case "Envelope B5":
                    width = 17.6;
                    height = 25;
                    break;

                case "Envelope Monarch":
                    width = 9.84;
                    height = 19.05;
                    break;

                case "Custom Size":
                    OnPageSizeOkButtonClick(null, null);
                    if (PageHeightUpDown != null && PageHeightUpDown.Value != null) height = (double)PageHeightUpDown.Value;
                    if (PageWidthUpDown != null && PageWidthUpDown.Value != null) width = (double)PageWidthUpDown.Value;
                    break;

            }
            if (PageHeightUpDown != null && PageHeightUpDown.Value != null) PageHeightUpDown.Value = height;
            if (PageWidthUpDown != null && PageWidthUpDown.Value != null) PageWidthUpDown.Value = width;
            height *= cmConst;
            width *= cmConst;

            printManager.PrintPageWidth = width;
            printManager.PrintPageHeight = height;
        }

        void OnPageSizeOkButtonClick(object sender, RoutedEventArgs e)
        {

            if (PageHeightUpDown.Value != null)
            {
                var height = (double)PageHeightUpDown.Value * cmConst;
                if (PageWidthUpDown.Value != null)
                {
                    var width = (double)PageWidthUpDown.Value * cmConst;
                    if (height < (printDataContext.PrintPageMargin.Top + printDataContext.PrintPageMargin.Bottom) || width < (printDataContext.PrintPageMargin.Left + printDataContext.PrintPageMargin.Right))
                        return;

                    printDataContext.PrintPageHeight = height;
                    printDataContext.PrintPageWidth = width;
                }
            }
        }

        void OnMarginCmbBoxSelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (printDataContext == null) return;
            double left = 0;
            double right = 0;
            double top = 0;
            double bottom = 0;
            switch ((e.AddedItems[0] as ComboBoxItem).Content.ToString())
            {
                case "Normal":
                    left = 2.54;
                    right = 2.54;
                    top = 2.54;
                    bottom = 2.54;
                    break;

                case "Narrow":
                    left = 1.27;
                    right = 1.27;
                    top = 1.27;
                    bottom = 1.27;
                    break;

                case "Moderate":
                    left = 1.91;
                    right = 1.91;
                    top = 2.54;
                    bottom = 2.54;
                    break;

                case "Wide":
                    left = 5.08;
                    right = 5.08;
                    top = 2.54;
                    bottom = 2.54;
                    break;

                case "Custom Margin":
                    OnMarginOkButtonClick(null, null);
                    if (LeftUpDown != null && LeftUpDown.Value != null) left = (double)LeftUpDown.Value;
                    if (RightUpDown != null && RightUpDown.Value != null) right = (double)RightUpDown.Value;
                    if (TopUpDown != null && TopUpDown.Value != null) top = (double)TopUpDown.Value;
                    if (BottomUpDown != null && BottomUpDown.Value != null) bottom = (double)BottomUpDown.Value;

                    break;

            }
            if (LeftUpDown != null && LeftUpDown.Value != null) LeftUpDown.Value = left;
            if (RightUpDown != null && RightUpDown.Value != null) RightUpDown.Value = right;
            if (TopUpDown != null && TopUpDown.Value != null) TopUpDown.Value = top;
            if (BottomUpDown != null && BottomUpDown.Value != null) BottomUpDown.Value = bottom;

            var margin = new Thickness(left * cmConst, top * cmConst, right * cmConst, bottom * cmConst);
            printDataContext.PrintPageMargin = margin;
        }

        void OnMarginOkButtonClick(object sender, RoutedEventArgs e)
        {
            if (LeftUpDown.Value != null)
            {
                var left = (double)LeftUpDown.Value * cmConst;
                if (RightUpDown.Value != null)
                {
                    var right = (double)RightUpDown.Value * cmConst;
                    if (TopUpDown.Value != null)
                    {
                        var top = (double)TopUpDown.Value * cmConst;
                        if (BottomUpDown.Value != null)
                        {
                            var bottom = (double)BottomUpDown.Value * cmConst;

                            var margin = new Thickness(left, top, right, bottom);
                            printDataContext.PrintPageMargin = margin;
                        }
                    }
                }
            }
        }

        private void OnPlusZoomBtnClick(object sender, RoutedEventArgs e)
        {
            if (PartZoomSlider.Value + 10 > PartZoomSlider.MaxHeight) return;
            PartZoomSlider.Value += 10;
        }

        private void OnMinusZoomBtnClick(object sender, RoutedEventArgs e)
        {
            if (PartZoomSlider.Value - 10 < PartZoomSlider.Minimum) return;
            PartZoomSlider.Value -= 10;
        }
    }
}
