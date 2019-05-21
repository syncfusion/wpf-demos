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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ScaleBreakDemo
{
    public class SampleBehavior:Behavior<MainWindow>
    {
        ChartBreakRangeInfo info1, info2;
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.Loaded += new RoutedEventHandler(AssociatedObject_Loaded);            
            TagEvents();
        }

        void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            info1 = new ChartBreakRangeInfo(this.AssociatedObject.YAxis.BreakRange);
            this.AssociatedObject.YAxis.BreakRange.Union(new DoubleRange(300, 400), info1);
            this.AssociatedObject.cmb_BreakRanges.Items.Add("300-400");
            info2 = new ChartBreakRangeInfo(this.AssociatedObject.YAxis.BreakRange);
            this.AssociatedObject.YAxis.BreakRange.Union(new DoubleRange(600, 2000), info2);
            this.AssociatedObject.cmb_BreakRanges.Items.Add("600-2000");
        }

        private void TagEvents()
        {
            this.AssociatedObject.cmb_BreakModes.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(cmb_BreakModes_SelectionChanged);
            this.AssociatedObject.cmb_BreakRanges.SelectionChanged += new SelectionChangedEventHandler(cmb_BreakRanges_SelectionChanged);
            this.AssociatedObject.btn_InsertBreak.Click += new RoutedEventHandler(btn_InsertBreak_Click);
            this.AssociatedObject.btn_RemoveBreak.Click += new RoutedEventHandler(btn_RemoveBreak_Click);
            this.AssociatedObject.cmb_LineStyles.SelectionChanged += new SelectionChangedEventHandler(cmb_LineStyles_SelectionChanged);
            this.AssociatedObject.cmb_LineTypes.SelectionChanged += new SelectionChangedEventHandler(cmb_LineTypes_SelectionChanged);
            this.AssociatedObject.LineColors.ColorChanged += new PropertyChangedCallback(LineColors_ColorChanged);
            this.AssociatedObject.txt_LineWidth.TextChanged += new TextChangedEventHandler(txt_LineWidth_TextChanged);
            this.AssociatedObject.SpaceColors.ColorChanged += new PropertyChangedCallback(SpaceColors_ColorChanged);
            this.AssociatedObject.txt_SpacingWidth.TextChanged += new TextChangedEventHandler(txt_SpacingWidth_TextChanged);
        }

        void LineColors_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (this.AssociatedObject.cmb_BreakRanges.SelectedValue != null)
            {
                if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "300-400")
                    this.info1.LineColor = this.AssociatedObject.LineColors.Brush;
                else if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "600-2000")
                    this.info2.LineColor = this.AssociatedObject.LineColors.Brush;
            }
            else
                MessageBox.Show("Select a range", "Line Color");
        }

        void SpaceColors_ColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (this.AssociatedObject.cmb_BreakRanges.SelectedValue != null)
            {
                if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "300-400")
                    this.info1.SpacingColor = this.AssociatedObject.SpaceColors.Brush;
                else if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "600-2000")
                    this.info2.SpacingColor = this.AssociatedObject.SpaceColors.Brush;
            }
            else
                MessageBox.Show("Select a range", "Spacing Color");
        }

       

        void cmb_LineTypes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (this.AssociatedObject.cmb_BreakRanges.SelectedValue != null)
            {
                if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "300-400")
                    this.info1.LineType = (ChartBreakLineTypes)this.AssociatedObject.cmb_LineTypes.SelectedValue;
                else if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "600-2000")
                    this.info2.LineType = (ChartBreakLineTypes)this.AssociatedObject.cmb_LineTypes.SelectedValue;
            }
            else
                MessageBox.Show("Select a range", "Line Type");
        }

        void cmb_LineStyles_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.AssociatedObject.cmb_BreakRanges.SelectedValue != null)
            {
                switch (this.AssociatedObject.cmb_LineStyles.SelectedValue.ToString())
                {
                    case "Dash Line":
                        if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "300-400")
                            this.info1.LineStyle = DashStyles.Dash;
                        else if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "600-2000")
                            this.info2.LineStyle = DashStyles.Dash;
                        break;
                    case "DashDotDot Line":
                        if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "300-400")
                            this.info1.LineStyle = DashStyles.DashDotDot;
                        else if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "600-2000")
                            this.info2.LineStyle = DashStyles.DashDotDot;
                        break;
                    case "DashDot Line":
                        if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "300-400")
                            this.info1.LineStyle = DashStyles.DashDot;
                        else if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "600-2000")
                            this.info2.LineStyle = DashStyles.DashDot;
                        break;
                    case "Dot Line":
                        if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "300-400")
                            this.info1.LineStyle = DashStyles.Dot;
                        else if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "600-2000")
                            this.info2.LineStyle = DashStyles.Dot;
                        break;
                    case "Solid Line":
                        if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "300-400")
                            this.info1.LineStyle = DashStyles.Solid;
                        else if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "600-2000")
                            this.info2.LineStyle = DashStyles.Solid;
                        break;
                }
            }
            else
                MessageBox.Show("Select a range", "Line Style");
        }

        void btn_RemoveBreak_Click(object sender, RoutedEventArgs e)
        {
            if (this.AssociatedObject.cmb_BreakRanges.SelectedItem != null)
            {
                string temp = (string)this.AssociatedObject.cmb_BreakRanges.SelectedValue;
                double start = Convert.ToDouble(temp.Substring(0, temp.LastIndexOf('-')));
                double end = Convert.ToDouble(temp.Substring(temp.LastIndexOf('-') + 1));
                this.AssociatedObject.YAxis.BreakRange.Exclude(new DoubleRange(start, end));
                this.AssociatedObject.btn_InsertBreak.Visibility = Visibility.Visible;
            }
        }

        void btn_InsertBreak_Click(object sender, RoutedEventArgs e)
        {
            if (this.AssociatedObject.cmb_BreakRanges.SelectedItem != null)
            {
                string temp = (string)this.AssociatedObject.cmb_BreakRanges.SelectedValue;
                ChartBreakRangeInfo inf = (temp == "300-400") ? info1 : info2;
                double start = Convert.ToDouble(temp.Substring(0, temp.LastIndexOf('-')));
                double end = Convert.ToDouble(temp.Substring(temp.LastIndexOf('-') + 1));
                this.AssociatedObject.YAxis.BreakRange.Union(new DoubleRange(start, end), inf);
            }
        }

        void cmb_BreakRanges_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string text = "Break Range Informations : ";
            this.AssociatedObject.txt_Range.Header = text + this.AssociatedObject.cmb_BreakRanges.SelectedItem.ToString();
        }

        void cmb_BreakModes_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            this.AssociatedObject.YAxis.BreakRange.BreaksMode = (ChartBreaksModes)this.AssociatedObject.cmb_BreakModes.SelectedValue;

        }
       
       

        private void txt_LineWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.AssociatedObject.cmb_BreakRanges.SelectedValue != null)
            {
                if (this.AssociatedObject.txt_LineWidth.Text != string.Empty)
                    if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "300-400")
                        this.info1.LineWidth = double.Parse(this.AssociatedObject.txt_LineWidth.Text);
                    else if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "600-2000")
                        this.info2.LineWidth = double.Parse(this.AssociatedObject.txt_LineWidth.Text);
            }
            else
                MessageBox.Show("Select a range", "Line Width");
        }

        private void txt_SpacingWidth_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.AssociatedObject.cmb_BreakRanges.SelectedValue != null)
            {
                if (this.AssociatedObject.txt_SpacingWidth.Text != string.Empty)
                    if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "300-400")
                        this.info1.SpacingWidth = double.Parse(this.AssociatedObject.txt_SpacingWidth.Text);
                    else if (this.AssociatedObject.cmb_BreakRanges.SelectedValue.ToString() == "600-2000")
                        this.info2.SpacingWidth = double.Parse(this.AssociatedObject.txt_SpacingWidth.Text);
            }
            else
                MessageBox.Show("Select a range", "Spacing Width");
        }
    }
}
