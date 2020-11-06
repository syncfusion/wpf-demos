#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Syncfusion.Windows.Tools.Controls;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace syncfusion.gridcontroldemos.wpf
{
    [DesignTimeVisible(false)]
    public class FillDropDownItem : Control
    {
        GridFillSeriesMouseController SeriesController = null;
        SplitButtonAdv SplitButton;
        public FillDropDownItem()
        {
            this.DefaultStyleKey = typeof(FillDropDownItem);
        }

        public FillDropDownItem(GridFillSeriesMouseController SeriesController)
            : this()
        {
            this.SeriesController = SeriesController;
            ItemsSource = new ObservableCollection<RadioButton>();


            if ((SeriesController.Filltype & SeriesType.CopySeries) == SeriesType.CopySeries)
            {
                RadioButton CopySeriesButton = new RadioButton() { Content = "CopySeries", GroupName = "FillSeriesGroup" };
                CopySeriesButton.IsChecked = (SeriesController.InnerFillType & SeriesType.CopySeries) == SeriesType.CopySeries;
                CopySeriesButton.Checked += RadioButtonChecked;
                ItemsSource.Add(CopySeriesButton);
            }

            if ((SeriesController.Filltype & SeriesType.FillSeries) == SeriesType.FillSeries)
            {
                RadioButton FillSeriesButton = new RadioButton() { Content = "FillSeries", GroupName = "FillSeriesGroup" };
                FillSeriesButton.IsChecked = (SeriesController.InnerFillType & SeriesType.FillSeries) == SeriesType.FillSeries;
                FillSeriesButton.Checked += RadioButtonChecked;
                ItemsSource.Add(FillSeriesButton);
            }

            if ((SeriesController.Filltype & SeriesType.FillFormatOnly) == SeriesType.FillFormatOnly)
            {
                RadioButton FillFormatOnlyButton = new RadioButton() { Content = "FillFormatOnly", GroupName = "FillSeriesGroup" };
                FillFormatOnlyButton.IsChecked = (SeriesController.InnerFillType & SeriesType.FillFormatOnly) == SeriesType.FillFormatOnly;
                FillFormatOnlyButton.Checked += RadioButtonChecked;
                ItemsSource.Add(FillFormatOnlyButton);
            }

            if ((SeriesController.Filltype & SeriesType.FillWithoutFormat) == SeriesType.FillWithoutFormat)
            {
                RadioButton FillWithoutFormatButton = new RadioButton() { Content = "FillWithoutFormat", GroupName = "FillSeriesGroup" };
                FillWithoutFormatButton.IsChecked = (SeriesController.InnerFillType & SeriesType.FillWithoutFormat) == SeriesType.FillWithoutFormat;
                FillWithoutFormatButton.Checked += RadioButtonChecked;
                ItemsSource.Add(FillWithoutFormatButton);
            }
        }

        public ObservableCollection<RadioButton> ItemsSource
        {
            get { return (ObservableCollection<RadioButton>)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly DependencyProperty ItemsSourceProperty =
            DependencyProperty.Register("ItemsSource", typeof(ObservableCollection<RadioButton>), typeof(FillDropDownItem),new PropertyMetadata());

        public bool IsDropDownOpen
        {
            get { return (bool)GetValue(IsDropDownOpenProperty); }
            set { SetValue(IsDropDownOpenProperty, value); }
        }

        public static readonly DependencyProperty IsDropDownOpenProperty =
            DependencyProperty.Register("IsDropDownOpen", typeof(bool), typeof(FillDropDownItem), new PropertyMetadata(false));

        public override void OnApplyTemplate()
        {
            SplitButton = this.GetTemplateChild("dropdownSplitter") as SplitButtonAdv;
        }

        void RadioButtonChecked(object sender, RoutedEventArgs e)
        {
            if (SeriesController != null)
                SeriesController.FillOptionChanged((sender as RadioButton).Content.ToString());
            SplitButton.IsDropDownOpen = false;
        }
    }
}
