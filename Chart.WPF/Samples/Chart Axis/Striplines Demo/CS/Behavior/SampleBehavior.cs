#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Interactivity;
using Syncfusion.Windows.Chart;
using System.Windows.Media;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;


namespace StripLinesDemo
{
    public class SampleBehavior : Behavior<Window1>
    {
        public Chart Chart = null;
        private static int initialStripCount=0;
        protected override void OnAttached()
        {
            base.OnAttached();
            this.Chart = this.AssociatedObject.chart1;
            LoadDefaultValuesAndEvents();
        }

        private void LoadDefaultValuesAndEvents()
        {
            this.AssociatedObject.YAxisStripline1.Text = new FormattedText("Moderate Temperature", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 14, Brushes.Green);
            this.AssociatedObject.YAxisStripline2.Text = new FormattedText("High Temperature", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 14, Brushes.CornflowerBlue);
            this.AssociatedObject.YAxisStripline3.Text = new FormattedText("Very High Temperature", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 14, Brushes.Crimson);
            this.AssociatedObject.XAxisStripline1.Text = new FormattedText("Quarter1", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 14, Brushes.Green);
            this.AssociatedObject.XAxisStripline2.Text = new FormattedText("Quarter2", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 14, Brushes.Green);
            this.AssociatedObject.XAxisStripline3.Text = new FormattedText("Quarter3", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 14, Brushes.Green);
            this.AssociatedObject.XAxisStripline4.Text = new FormattedText("Quarter4", CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface("Arial"), 14, Brushes.Green);
            this.AssociatedObject.StripLineInterior.SelectedBrushChanged += new PropertyChangedCallback(XAxisInterior_SelectedBrushChanged);
            this.AssociatedObject.XAxisStripText1.TextChanged += new TextChangedEventHandler(Text_Changed);
            this.AssociatedObject.XAxisStripText2.TextChanged += new TextChangedEventHandler(Text_Changed);
            this.AssociatedObject.XAxisStripText3.TextChanged += new TextChangedEventHandler(Text_Changed);
            this.AssociatedObject.XAxisStripText4.TextChanged += new TextChangedEventHandler(Text_Changed);
            this.AssociatedObject.YAxisStripText1.TextChanged += new TextChangedEventHandler(Text_Changed);
            this.AssociatedObject.YAxisStripText2.TextChanged += new TextChangedEventHandler(Text_Changed);
            this.AssociatedObject.YAxisStripText3.TextChanged += new TextChangedEventHandler(Text_Changed);
        }

        void Text_Changed(object sender, TextChangedEventArgs e)
        {
            ClearStripLines();
            GenerateXStripLines(this.AssociatedObject.XAxisStripText1.Text, this.AssociatedObject.XAxisStripText2.Text, this.AssociatedObject.XAxisStripText3.Text, this.AssociatedObject.XAxisStripText4.Text, this.AssociatedObject.StripLineInterior.Brush);
            GenerateYStripLines(this.AssociatedObject.YAxisStripText1.Text, this.AssociatedObject.YAxisStripText2.Text, this.AssociatedObject.YAxisStripText3.Text, this.AssociatedObject.StripLineInterior.Brush);
        }

        void XAxisInterior_SelectedBrushChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (initialStripCount > 0)
            {
                ClearStripLines();
                GenerateXStripLines(this.AssociatedObject.XAxisStripText1.Text, this.AssociatedObject.XAxisStripText2.Text, this.AssociatedObject.XAxisStripText3.Text, this.AssociatedObject.XAxisStripText4.Text, this.AssociatedObject.StripLineInterior.Brush);
                GenerateYStripLines(this.AssociatedObject.YAxisStripText1.Text, this.AssociatedObject.YAxisStripText2.Text, this.AssociatedObject.YAxisStripText3.Text,this.AssociatedObject.StripLineInterior.Brush);
            }
            initialStripCount++;
        }

        private void GenerateXStripLines(string text1, string text2, string text3, string text4, Brush interior)
        {
            ChartStripLine cs = new ChartStripLine();
            cs.StartFromAxis = true;
            cs.Start = 0;
            cs.Offset = 0;
            cs.Width = 2;
            cs.Interior = interior;
            cs.Text = new FormattedText(text1, CultureInfo.CurrentCulture,
                FlowDirection.LeftToRight, new Typeface("Arial"), 14, Brushes.Green);
            cs.TextRotationAngle = 270;
            cs.Interior = interior;
            this.AssociatedObject.chart1.Areas[1].PrimaryAxis.StripLines.Add(cs);

            cs = new ChartStripLine();
            cs.StartFromAxis = true;
            cs.Start = 0;
            cs.Offset = 3;
            cs.Width = 2;
            cs.Interior = interior;
            cs.Text = new FormattedText(text2, CultureInfo.CurrentCulture,
                            FlowDirection.LeftToRight, new Typeface("Arial"), 14, Brushes.Green);
            cs.TextRotationAngle = 270;
            this.AssociatedObject.chart1.Areas[1].PrimaryAxis.StripLines.Add(cs);


            cs = new ChartStripLine();
            cs.StartFromAxis = true;
            cs.Start = 0;
            cs.Offset = 6;
            cs.Width = 2;
            cs.Interior = interior;
            cs.Text = new FormattedText(text3, CultureInfo.CurrentCulture,
                            FlowDirection.LeftToRight, new Typeface("Arial"), 14, Brushes.Green);
            cs.TextRotationAngle = 270;
            this.AssociatedObject.chart1.Areas[1].PrimaryAxis.StripLines.Add(cs);

            cs = new ChartStripLine();
            cs.StartFromAxis = true;
            cs.Start = 0;
            cs.Offset = 9;
            cs.Width = 2;
            cs.Interior = interior;
            cs.TextRotationAngle = 270;
            cs.Text = new FormattedText(text4, CultureInfo.CurrentCulture,
                            FlowDirection.LeftToRight, new Typeface("Arial"), 14, Brushes.Green);
            this.AssociatedObject.chart1.Areas[1].PrimaryAxis.StripLines.Add(cs);
        }

        private void GenerateYStripLines(string text1, string text2, string text3,Brush interior)
        {
            ChartStripLine cs = new ChartStripLine();
            cs = new ChartStripLine();
            cs.StartFromAxis = true;
            cs.Start = 0;
            cs.Offset = 0;
            cs.Width = 4;
            cs.Interior = interior;
            cs.Text = new FormattedText(text1, CultureInfo.CurrentCulture,
                            FlowDirection.LeftToRight, new Typeface("Arial"), 14, Brushes.Crimson);
            this.AssociatedObject.chart1.Areas[0].SecondaryAxis.StripLines.Add(cs);

            cs = new ChartStripLine();
            cs.StartFromAxis = true;
            cs.Start = 0;
            cs.Offset = 8;
            cs.Width = 4;
            cs.Interior = interior;
            cs.Text = new FormattedText(text2, CultureInfo.CurrentCulture,
                            FlowDirection.LeftToRight, new Typeface("Arial"), 14, Brushes.CornflowerBlue);
            this.AssociatedObject.chart1.Areas[0].SecondaryAxis.StripLines.Add(cs);

            cs = new ChartStripLine();
            cs.StartFromAxis = true;
            cs.Start = 0;
            cs.Offset = 16;
            cs.Width = 4;
            cs.Interior = interior;
            cs.Text = new FormattedText(text3, CultureInfo.CurrentCulture,
                            FlowDirection.LeftToRight, new Typeface("Arial"), 14, Brushes.Green);
            this.AssociatedObject.chart1.Areas[0].SecondaryAxis.StripLines.Add(cs);
        }
        private void ClearStripLines()
        {
            foreach (var item in Chart.Areas)
            {
                item.PrimaryAxis.StripLines.Clear();
                item.SecondaryAxis.StripLines.Clear();
            }
        }

    }
}
