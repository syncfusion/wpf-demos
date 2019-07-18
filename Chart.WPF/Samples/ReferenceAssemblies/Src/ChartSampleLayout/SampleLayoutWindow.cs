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
using Syncfusion.Windows.Shared;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Syncfusion.Windows.SampleLayout
{
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
    public class SampleLayoutWindow : ChromelessWindow
    {
        static SampleLayoutWindow()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(SampleLayoutWindow), new FrameworkPropertyMetadata(typeof(SampleLayoutWindow)));
        }

        public SampleLayoutWindow()
        {
            this.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            base.AllowsTransparency = true;
        }

        public override void OnApplyTemplate()
        {
            ContentPresenter cp = this.GetTemplateChild("ControlGrid") as ContentPresenter;
            //ContentControl cc = new ContentControl();
            //cc.Content = this.UserOptionsLayout;
            //ScrollViewer sv = this.GetTemplateChild("UserGrid") as ScrollViewer;
            Binding cpbin = new Binding();
            cpbin.Source = this.Content;
            if(cp != null)
            BindingOperations.SetBinding(cp, ContentPresenter.ContentProperty, cpbin);
            //Binding svbin = new Binding();            
            //svbin.Source = cc;
            //if (sv!= null)
            //BindingOperations.SetBinding(sv,ScrollViewer.ContentProperty, svbin);            
            base.OnApplyTemplate();
        }

        public object ControlLayout
        {
            get { return (object)GetValue(ControlLayoutProperty); }
            set { SetValue(ControlLayoutProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ControlLayout.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ControlLayoutProperty =
            DependencyProperty.Register("ControlLayout", typeof(object), typeof(SampleLayoutWindow), new UIPropertyMetadata(null));




        public object UserOptionsLayout
        {
            get { return (object)GetValue(UserOptionsLayoutProperty); }
            set { SetValue(UserOptionsLayoutProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserOptionsLayout.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserOptionsLayoutProperty =
            DependencyProperty.Register("UserOptionsLayout", typeof(object), typeof(SampleLayoutWindow), new UIPropertyMetadata(null));




        public Visibility UserOptionsVisibility
        {
            get { return (Visibility)GetValue(UserOptionsVisibilityProperty); }
            set { SetValue(UserOptionsVisibilityProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UserOptionsVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UserOptionsVisibilityProperty =
            DependencyProperty.Register("UserOptionsVisibility", typeof(Visibility), typeof(SampleLayoutWindow), new UIPropertyMetadata(Visibility.Visible));

        

    }
}
