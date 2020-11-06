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
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Syncfusion.Windows.Controls.Cells;
using Syncfusion.Windows.GridCommon;
using System.Windows.Threading;
using System.Data;
using Syncfusion.Windows.Controls.Grid;
using Syncfusion.Windows.Shared;
using syncfusion.demoscommon.wpf;

namespace syncfusion.gridcontroldemos.wpf
{
    /// <summary>
    /// Interaction logic for ScrollPerformance.xaml
    /// </summary>
    public partial class ScrollPerformance : DemoControl, IDisposable
    {
        DispatcherTimer timer = new DispatcherTimer();

#if !Grid
       // string description = "The below metrics shows the scrolling performance of the GridControl that has been loaded with \n1 Million rows x 1 Million columns.";
#endif
        Random r = new Random();

        #region Constructor
        public ScrollPerformance()
        {
            InitializeComponent();
            timer = new DispatcherTimer(DispatcherPriority.ApplicationIdle);
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(timer_Tick);
            this.vGrid.ContentUpdated += new EventHandler(vGrid_ContentUpdated);
            this.Unloaded += new RoutedEventHandler(VirtualGrid_Unloaded);
        }
        public ScrollPerformance(string themename) : base(themename)
        {
            InitializeComponent();
            timer = new DispatcherTimer(DispatcherPriority.ApplicationIdle);
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(timer_Tick);
            this.vGrid.ContentUpdated += new EventHandler(vGrid_ContentUpdated);
            this.Unloaded += new RoutedEventHandler(VirtualGrid_Unloaded);
        }

        void VirtualGrid_Unloaded(object sender, RoutedEventArgs e)
        {
            this.Unloaded -= new RoutedEventHandler(VirtualGrid_Unloaded);
        }

        void vGrid_ContentUpdated(object sender, EventArgs e)
        {
            //lblScroll.Foreground = Brushes.WhiteSmoke;
            lblScroll.Content = this.vGrid.displayText;
#if !Grid
            if (startLog)
            {

            }
#endif
        }

        string[] actions = new string[]{
            "ScrollLines",
            "MoveVerticalPageDown",
            "MoveVerticalToEnd",
            "MoveVerticalPageUp",
            "MoveVerticalTop"
        };

        int counter0 = 0;
        void timer_Tick(object sender, EventArgs e)
        {
            if (timer.IsEnabled)
            {
                if (counter0 > 5)
                {
                    counter0 = 0;
                }
                var action = actions[counter0 % actions.Length];
                switch (action)
                {
                    case "ScrollLines":
                        for (int i = 0; i < 100; i++)
                        {
                            this.vGrid.LineDown();
                            this.vGrid.InvalidateArrange();
                        }
                        break;
                    case "MoveVerticalPageDown":
                        for (int i = 0; i < 10; i++)
                        {
                            this.vGrid.PageDown();
                            this.vGrid.InvalidateArrange();
                        }
                        break;
                    case "MoveVerticalToEnd":
                        this.vGrid.ScrollToBottom();
                        this.vGrid.InvalidateArrange();
                        break;
                    case "MoveVerticalPageUp":
                        for (int i = 0; i < 3; i++)
                        {
                            this.vGrid.PageRight();
                            this.vGrid.InvalidateArrange();
                        }
                        break;
                    case "MoveVerticalTop":
                        this.vGrid.ScrollToTop();
                        this.vGrid.InvalidateArrange();
                        break;
                }
                counter0 += 1;
            }
        }
        #endregion

        #region Events
        private void rdo1_Checked(object sender, RoutedEventArgs e)
        {
            vGrid.Model.RowHeights.LineCount = 1000000;
            vGrid.InvalidateVisual(true);
        }

        private void rdo2_Checked(object sender, RoutedEventArgs e)
        {
            vGrid.Model.RowHeights.LineCount = 10000000;
            vGrid.InvalidateVisual(true);
        }

        private void rdo3_Checked(object sender, RoutedEventArgs e)
        {
            vGrid.Model.RowHeights.LineCount = 1000000000;
            vGrid.InvalidateVisual(true);
        }

        private void rdoCol1_Checked(object sender, RoutedEventArgs e)
        {
            vGrid.Model.ColumnWidths.LineCount = 1000000;
            vGrid.InvalidateVisual(true);
        }

        private void rdoCol2_Checked(object sender, RoutedEventArgs e)
        {
            vGrid.Model.ColumnWidths.LineCount = 10000000;
            vGrid.InvalidateVisual(true);
        }

        private void rdoCol3_Checked(object sender, RoutedEventArgs e)
        {
            vGrid.Model.ColumnWidths.LineCount = 1000000000;
            vGrid.InvalidateVisual(true);
        }

        private void LineDown()
        {
            int prevTopRow = vGrid.TopRowIndex;
            vGrid.LineDown();
        }

        private void scrollHzntl_Changed(object sender, RoutedEventArgs e)
        {
            if (scrollLeft.IsChecked == true)
            {
                this.vGrid.ScrollToLeftEnd();
            }
            else if (scrollRight.IsChecked == true)
            {
                this.vGrid.ScrollToRightEnd();
            }
        }

        private void scrollVtcl_Changed(object sender, RoutedEventArgs e)
        {
            if (scrollTop.IsChecked == true)
            {
                this.vGrid.ScrollToTop();
            }
            else if (scrollBottom.IsChecked == true)
            {
                this.vGrid.ScrollToBottom();
            }
        }

        bool startLog = false;
        private void btnTimer_Click(object sender, RoutedEventArgs e)
        {
            if (btnTimer.Content.Equals("Start ScrollTimer"))
            {
                timer.Start();
#if !Grid
#endif
                startLog = true;
                btnTimer.Content = "Stop ScrollTimer";

            }
            else
            {
                timer.Stop();
                startLog = false;
                btnTimer.Content = "Start ScrollTimer";

            }
        }

        private void btnReport_Click(object sender, RoutedEventArgs e)
        {
#if !Grid

#endif
        }
        #endregion

        #region IDisposable Members

        protected override void Dispose(bool disposing)
        {
            if (this.timer != null)
            {
                this.timer.Tick -= new EventHandler(timer_Tick);
                this.timer.IsEnabled = false;
                this.timer.Stop();
            }
            if (this.vGrid != null)
                this.vGrid.ContentUpdated -= new EventHandler(vGrid_ContentUpdated);

            this.Unloaded -= new RoutedEventHandler(VirtualGrid_Unloaded);
            vGrid.Dispose();
            base.Dispose(disposing);
        }
        

        #endregion

    }
}
