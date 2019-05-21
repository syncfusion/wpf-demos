#region Copyright Syncfusion Inc. 2001 - 2019
// Copyright Syncfusion Inc. 2001 - 2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace Syncfusion.Windows.SampleLayout
{
    using System;
    using System.Collections.Generic;
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
    using Syncfusion.Windows.Shared;
    using System.Windows.Interop;
    using System.IO;
    using System.Reflection;
    using System.Data;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    using System.Windows.Resources;
    using System.Windows.Controls.Primitives;
    using System.Windows.Media.Effects;

    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Syncfusion.Windows.SampleLayout"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:Syncfusion.Windows.SampleLayout;assembly=Syncfusion.Windows.Chart.SampleLayout"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    /// </summary>
    public class LayoutControl : Control
    {


        static LayoutControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LayoutControl), new FrameworkPropertyMetadata(typeof(LayoutControl)));
        }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public LayoutControl()
        {            
            
        }
        

       

        // Using a DependencyProperty as the backing store for UserOptionsWidth.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserOptionsWidthProperty =
            DependencyProperty.Register("UserOptionsWidth", typeof(double), typeof(LayoutControl), new UIPropertyMetadata(307.2));
       
        public double UserOptionsWidth
        {
            get { return (double)GetValue(LayoutControl.UserOptionsWidthProperty); }
            set { SetValue(LayoutControl.UserOptionsWidthProperty, value); }
        }
        
        public static readonly DependencyProperty ChartViewProperty = DependencyProperty.Register(
            "ChartView",
            typeof(object),
            typeof(LayoutControl));

        /// <summary>
        /// Displays the grid.
        /// </summary>
        public object ChartView
        {
            get
            {
                return this.GetValue(LayoutControl.ChartViewProperty);
            }

            set
            {
                this.SetValue(LayoutControl.ChartViewProperty, value);
            }
        }

        public static readonly DependencyProperty UserOptionsProperty = DependencyProperty.Register(
            "UserOptions",
            typeof(object),
            typeof(LayoutControl));

        /// <summary>
        /// Displays User Options panel.
        /// </summary>
        public object UserOptions
        {
            get
            {
                return this.GetValue(LayoutControl.UserOptionsProperty);
            }

            set
            {
                this.SetValue(LayoutControl.UserOptionsProperty, value);
            }
        }


        public static readonly DependencyProperty UserOptionsVisibilityProperty = DependencyProperty.Register(
            "UserOptionsVisibility",
            typeof(Visibility),
            typeof(LayoutControl),
            new FrameworkPropertyMetadata(Visibility.Visible));

        /// <summary>
        /// Gets or sets a value indicating whether to show or hide the User Options panel.
        /// </summary>
        public Visibility UserOptionsVisibility
        {
            get
            {
                return (Visibility)this.GetValue(LayoutControl.UserOptionsVisibilityProperty);
            }

            set
            {
                this.SetValue(LayoutControl.UserOptionsVisibilityProperty, value);
            }
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
        }


       


        /// <summary>
        /// Retruns true, if the application is in design mode; false otherwise.
        /// </summary>
        public static bool IsInDesignMode
        {
            get
            {
                return DesignerProperties.GetIsInDesignMode(new DependencyObject());
            }
        }
    }

    internal class GridDataStringToVisualStyleConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //if (value != null)
            //    return (VisualStyle)Enum.Parse(typeof(VisualStyle), value.ToString());

            return value;
        }
        #endregion
    }
}