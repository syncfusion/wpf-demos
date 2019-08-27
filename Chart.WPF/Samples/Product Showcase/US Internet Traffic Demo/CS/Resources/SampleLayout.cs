#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace ColorPaletteDemo
{
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
    /// <summary>
    /// Interaction logic for SampleLayout.xaml
    /// </summary>
    public partial class SampleLayout : UserControl
    {
        public SampleLayout()
        {
        }

        public static readonly DependencyProperty ControlViewProperty = DependencyProperty.Register(
         "ControlView",
         typeof(object),
         typeof(SampleLayout));

        /// <summary>
        /// Displays the grid.
        /// </summary>
        public object ControlView
        {
            get
            {
                return this.GetValue(SampleLayout.ControlViewProperty);
            }

            set
            {
                this.SetValue(SampleLayout.ControlViewProperty, value);
            }
        }

        public static readonly DependencyProperty UserOptionsProperty = DependencyProperty.Register(
            "UserOptions",
            typeof(object),
            typeof(SampleLayout));

        /// <summary>
        /// Displays User Options panel.
        /// </summary>
        public object UserOptions
        {
            get
            {
                return this.GetValue(SampleLayout.UserOptionsProperty);
            }

            set
            {
                this.SetValue(SampleLayout.UserOptionsProperty, value);
            }
        }


        public static readonly DependencyProperty UserOptionsVisibilityProperty = DependencyProperty.Register(
            "UserOptionsVisibility",
            typeof(Visibility),
            typeof(SampleLayout),
            new FrameworkPropertyMetadata(Visibility.Visible));

        /// <summary>
        /// Gets or sets a value indicating whether to show or hide the User Options panel.
        /// </summary>
        public Visibility UserOptionsVisibility
        {
            get
            {
                return (Visibility)this.GetValue(SampleLayout.UserOptionsVisibilityProperty);
            }

            set
            {
                this.SetValue(SampleLayout.UserOptionsVisibilityProperty, value);
            }
        }

        public static readonly DependencyProperty RowSpanProperty = DependencyProperty.Register(
  "RowSpan",
  typeof(int),
  typeof(SampleLayout));

        internal int RowSpan
        {
            get
            {
                return (int)this.GetValue(SampleLayout.RowSpanProperty);
            }

            set
            {
                this.SetValue(SampleLayout.RowSpanProperty, value);
            }
        }

        public static readonly DependencyProperty TraceVisibilityProperty = DependencyProperty.Register(
                                                                           "TraceVisibility",
                                                                            typeof(Visibility),
                                                                            typeof(SampleLayout),
                                                                            new FrameworkPropertyMetadata(Visibility.Visible, OnTraceVisibilityChanged));

        public Visibility TraceVisibility
        {
            get
            {
                return (Visibility)this.GetValue(SampleLayout.TraceVisibilityProperty);
            }

            set
            {
                this.SetValue(SampleLayout.TraceVisibilityProperty, value);
            }
        }


        private static void OnTraceVisibilityChanged(DependencyObject d, DependencyPropertyChangedEventArgs args)
        {
            SampleLayout layout = d as SampleLayout;
            if (layout.TraceVisibility == Visibility.Collapsed || layout.TraceVisibility == Visibility.Hidden)
            {
                layout.RowSpan = 2;
            }
            else
            {
                layout.RowSpan = 1;
            }
        }




        public object TraceContent
        {
            get { return (object)GetValue(TraceContentProperty); }
            set { SetValue(TraceContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TraceContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TraceContentProperty =
            DependencyProperty.Register("TraceContent", typeof(object), typeof(SampleLayout), new 
                PropertyMetadata(null));



        public string SampleHeader
        {
            get { return (string)GetValue(SampleHeaderProperty); }
            set { SetValue(SampleHeaderProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SampleHeader.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SampleHeaderProperty =
            DependencyProperty.Register("SampleHeader", typeof(string), typeof(SampleLayout), new PropertyMetadata("MapsSample"));

        
        
    }
}
