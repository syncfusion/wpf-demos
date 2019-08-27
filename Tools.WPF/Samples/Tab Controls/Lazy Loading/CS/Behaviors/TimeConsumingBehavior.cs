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
using System.Windows;
using System.Windows.Interactivity;
using System.Windows.Controls;
using System.ComponentModel;
using SampleLayout.WPF;
using System.Windows.Threading;
using System.Threading;
using Syncfusion.Windows.Tools.Controls;
using Syncfusion.Windows.Shared;
using System.Windows.Media;

namespace TabControlExtDemo
{
    public class TimeConsumingBehavior : Behavior<UserControl>
    {
        private bool isloaded;

        protected override void OnAttached()
        {
            AssociatedObject.Loaded += (sender, e) =>
                {
                    TimeConsumingView control = sender as TimeConsumingView;

                    TabControlExt tabcontrol = VisualUtils.FindAncestor(control as Visual, typeof(TabControlExt)) as TabControlExt;

                    if (tabcontrol != null)
                    {
                        int index = tabcontrol.Items.IndexOf(control);

                        if (index > -1 && index < tabcontrol.Items.Count && index==0)
                        {
                            for (int i = 0; i < tabcontrol.Items.Count; i++)
                            {
                                TabItemExt item = tabcontrol.ItemContainerGenerator.ContainerFromIndex(i) as TabItemExt;
                                if (item != null)
                                {
                                    switch (i)
                                    {
                                        case 0:
                                            item.Header = "2006-2007";
                                            break;
                                        case 1:
                                            item.Header = "2007-2008";
                                            break;
                                        case 2:
                                            item.Header = "2008-2009";
                                            break;
                                        case 3:
                                            item.Header = "2009-2010";
                                            break;
                                        case 4:
                                            item.Header = "2010-2011";
                                            break;
                                        case 5:
                                            item.Header = "2011-2012";
                                            break;
                                        default:
                                            break;
                                    }
                                }
                            }
                        }
                    }

                    if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
                    {
                        SampleLayoutControl samplecontrol = TimeConsumingBehavior.GetHost(control) as SampleLayoutControl;
                        if (control.reload.IsChecked.Value)
                        {
                            samplecontrol.IsBusy = true;

                            Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                            {
                                control.Chart1.DataContext = new TestingViewModel();
                                control.Chart2.DataContext = new ChartViewModel();
                                samplecontrol.IsBusy = false;
                                isloaded = true;
                            }));
                        }
                        else
                        {
                            if (!isloaded)
                            {
                                samplecontrol.IsBusy = true;

                                Dispatcher.BeginInvoke(DispatcherPriority.Normal, new ThreadStart(() =>
                                {
                                    control.Chart1.DataContext = new TestingViewModel();
                                    control.Chart2.DataContext = new ChartViewModel();
                                    samplecontrol.IsBusy = false;
                                    isloaded = true;
                                }));
                            }
                        }
                    }
                    control.series1.StartAnimation();
                    control.series2.StartAnimation();
                };
        }

        public static FrameworkElement GetHost(DependencyObject obj)
        {
            return (FrameworkElement)obj.GetValue(HostProperty);
        }

        public static void SetHost(DependencyObject obj, FrameworkElement value)
        {
            obj.SetValue(HostProperty, value);
        }

        // Using a DependencyProperty as the backing store for Host.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HostProperty =
            DependencyProperty.RegisterAttached("Host", typeof(FrameworkElement), typeof(TimeConsumingBehavior), new UIPropertyMetadata(null));
    }
}
