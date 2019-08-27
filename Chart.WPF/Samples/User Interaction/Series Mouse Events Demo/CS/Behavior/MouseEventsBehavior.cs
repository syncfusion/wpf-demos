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
using System.Windows.Documents;

namespace ChartSeriesMouseEvents
{
    class MouseEventsBehavior :Behavior<Window1>
    {
        protected override void OnAttached()
        {
            this.AssociatedObject.Loaded += new System.Windows.RoutedEventHandler(AssociatedObject_Loaded);
        }

        void AssociatedObject_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            this.AssociatedObject.button1.Click += new System.Windows.RoutedEventHandler(button1_Click);
            this.AssociatedObject.Series1.MouseClick += new ChartMouseEventHandler(Series1_MouseClick);
            this.AssociatedObject.Series1.MouseDown += new ChartMouseEventHandler(Series1_MouseDown);
            this.AssociatedObject.Series1.MouseEnter += new ChartMouseEventHandler(Series1_MouseEnter);
            this.AssociatedObject.Series1.MouseLeave += new ChartMouseEventHandler(Series1_MouseLeave);
            this.AssociatedObject.Series1.MouseLeftButtonDown += new ChartMouseEventHandler(Series1_MouseLeftButtonDown);
            this.AssociatedObject.Series1.MouseLeftButtonUp += new ChartMouseEventHandler(Series1_MouseLeftButtonUp);
            this.AssociatedObject.Series1.MouseMove += new ChartMouseEventHandler(Series1_MouseMove);
            this.AssociatedObject.Series1.MouseRightButtonDown += new ChartMouseEventHandler(Series1_MouseRightButtonDown);
            this.AssociatedObject.Series1.MouseRightButtonUp += new ChartMouseEventHandler(Series1_MouseRightButtonUp);
            this.AssociatedObject.Series1.MouseUp += new ChartMouseEventHandler(Series1_MouseUp);

            this.AssociatedObject.Series2.MouseClick += new ChartMouseEventHandler(Series2_MouseClick);
            this.AssociatedObject.Series2.MouseDown += new ChartMouseEventHandler(Series1_MouseDown);
            this.AssociatedObject.Series2.MouseEnter += new ChartMouseEventHandler(Series1_MouseEnter);
            this.AssociatedObject.Series2.MouseLeave += new ChartMouseEventHandler(Series1_MouseLeave);
            this.AssociatedObject.Series2.MouseLeftButtonDown += new ChartMouseEventHandler(Series1_MouseLeftButtonDown);
            this.AssociatedObject.Series2.MouseLeftButtonUp += new ChartMouseEventHandler(Series1_MouseLeftButtonUp);
            this.AssociatedObject.Series2.MouseMove += new ChartMouseEventHandler(Series1_MouseMove);
            this.AssociatedObject.Series2.MouseRightButtonDown += new ChartMouseEventHandler(Series1_MouseRightButtonDown);
            this.AssociatedObject.Series2.MouseRightButtonUp += new ChartMouseEventHandler(Series1_MouseRightButtonUp);
            this.AssociatedObject.Series2.MouseUp += new ChartMouseEventHandler(Series1_MouseUp);


        }

        void Series2_MouseClick(object sender, ChartMouseEventArgs e)
        {
            if (this.AssociatedObject.checkBox1.IsChecked == true)
            {
                ChartSeries series = sender as ChartSeries;
                EventLogText("MouseClick on " + series.Label + "\t");

            }
        }

        Paragraph pp = new Paragraph();
        FlowDocument myFlowDoc = new FlowDocument();
        protected void EventLogText(String str)
        {
            pp.Inlines.Add(new Run(str + "\n\n"));

            myFlowDoc.Blocks.Add(pp);
            this.AssociatedObject.richTextBox1.Document = myFlowDoc;
        }

        void button1_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            pp.Inlines.Clear();
            myFlowDoc.Blocks.Remove(pp);
            this.AssociatedObject.richTextBox1.Document = myFlowDoc;
        }

        void Series1_MouseUp(object sender, ChartMouseEventArgs e)
        {
            if (this.AssociatedObject.checkBox10.IsChecked == true)
            {
                ChartSeries series = sender as ChartSeries;
                EventLogText("MouseUp on " + series.Label + "\t");
            }
        }

        void Series1_MouseRightButtonUp(object sender, ChartMouseEventArgs e)
        {
            if (this.AssociatedObject.checkBox8.IsChecked == true)
            {
                ChartSeries series = sender as ChartSeries;
                EventLogText("MouseRightButtonUp on " + series.Label + "\t");
            }
        }

        void Series1_MouseRightButtonDown(object sender, ChartMouseEventArgs e)
        {
            if (this.AssociatedObject.checkBox7.IsChecked == true)
            {
                ChartSeries series = sender as ChartSeries;
                EventLogText("MouseRightButtonDown on " + series.Label + "\t");
            }
        }

        void Series1_MouseMove(object sender, ChartMouseEventArgs e)
        {
            if (this.AssociatedObject.checkBox9.IsChecked == true)
            {
                ChartSeries series = sender as ChartSeries;
                EventLogText("MouseMove on " + series.Label + "\t");

            }
        }

        void Series1_MouseLeftButtonUp(object sender, ChartMouseEventArgs e)
        {
            if (this.AssociatedObject.checkBox6.IsChecked == true)
            {
                ChartSeries series = sender as ChartSeries;
                EventLogText("MouseLeftButtonUp on " + series.Label + "\t");
            }
        }

        void Series1_MouseLeftButtonDown(object sender, ChartMouseEventArgs e)
        {
            if (this.AssociatedObject.checkBox5.IsChecked == true)
            {
                ChartSeries series = sender as ChartSeries;
                EventLogText("MouseLeftButtonDown on " + series.Label + "\t");
            }
        }

        void Series1_MouseLeave(object sender, ChartMouseEventArgs e)
        {
            if (this.AssociatedObject.checkBox4.IsChecked == true)
            {
                ChartSeries series = sender as ChartSeries;
                EventLogText("MouseLeave " + series.Label + "\t");
            }
        }

        void Series1_MouseEnter(object sender, ChartMouseEventArgs e)
        {
            if (this.AssociatedObject.checkBox3.IsChecked == true)
            {
                ChartSeries series = sender as ChartSeries;
                EventLogText("MouseEnter " + series.Label + "\t");
            }
        }

        void Series1_MouseDown(object sender, ChartMouseEventArgs e)
        {
            if (this.AssociatedObject.checkBox2.IsChecked == true)
            {
                ChartSeries series = sender as ChartSeries;
                EventLogText("MouseDown on " + series.Label + "\t");
            }
        }

        void Series1_MouseClick(object sender, ChartMouseEventArgs e)
        {
            if (this.AssociatedObject.checkBox1.IsChecked == true)
            {
                ChartSeries series = sender as ChartSeries;
                EventLogText("MouseClick on " + series.Label + "\t");

            }
        }


       
    }
}
