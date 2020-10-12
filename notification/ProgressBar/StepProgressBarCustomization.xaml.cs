#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using syncfusion.demoscommon.wpf;
using Syncfusion.UI.Xaml.ProgressBar;
using Syncfusion.Windows.Tools.Controls;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace syncfusion.notificationdemos.wpf
{
    /// <summary>
    /// Represents the StepProgressBar customization class.
    /// </summary>
    public partial class StepProgressBarCustomization : DemoControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StepProgressBarCustomization"/> class.
        /// </summary>
        public StepProgressBarCustomization()
        {
            this.InitializeComponent();
        }

        public StepProgressBarCustomization(string themename) : base(themename)
        {
            InitializeComponent();
            ContentCustomization.AnimationDuration = new TimeSpan(0, 0, 0, 0, 500);
            MarkerCustomization.AnimationDuration = new TimeSpan(0, 0, 0, 0, 500);
        }
    }

    /// <summary>
    /// Method to select the custom data template for Marker.
    /// </summary>
    public class CustomShapeTemplate : DataTemplateSelector
    {
        /// <summary>
        /// Method to select the template based on status and index.
        /// </summary>
        /// <param name="item">stepview item.</param>
        /// <param name="container">step progress bar.</param>
        /// <returns>data template.</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            StepViewItem stepViewItem = item as StepViewItem;
            if (stepViewItem != null)
            {
                ItemsControl itemsControl = ItemsControl.ItemsControlFromItemContainer(stepViewItem);
                int index = itemsControl.ItemContainerGenerator.IndexFromContainer(stepViewItem);
                StepStatus stepStatus = stepViewItem.Status;
                if (stepStatus == StepStatus.Inactive && index == 0)
                {
                    return stepViewItem.FindResource("InactiveFirstStepTemplate") as DataTemplate;
                }
                else if (stepStatus == StepStatus.Indeterminate && index == 0)
                {
                    return stepViewItem.FindResource("IndeterminateFirstStepTemplate") as DataTemplate;
                }
                else if (stepStatus == StepStatus.Active && index == 0)
                {
                    return stepViewItem.FindResource("ActiveFirstStepTemplate") as DataTemplate;
                }
                else if (stepStatus == StepStatus.Inactive && index == 1)
                {
                    return stepViewItem.FindResource("InactiveSecondStepTemplate") as DataTemplate;
                }
                else if (stepStatus == StepStatus.Indeterminate && index == 1)
                {
                    return stepViewItem.FindResource("IndeterminateSecondStepTemplate") as DataTemplate;
                }
                if (stepStatus == StepStatus.Active && index == 1)
                {
                    return stepViewItem.FindResource("ActiveSecondStepTemplate") as DataTemplate;
                }
                else if (stepStatus == StepStatus.Inactive && index == 2)
                {
                    return stepViewItem.FindResource("InactiveThirdStepTemplate") as DataTemplate;
                }
                else if (stepStatus == StepStatus.Indeterminate && index == 2)
                {
                    return stepViewItem.FindResource("IndeterminateThirdStepTemplate") as DataTemplate;
                }
                else if (stepStatus == StepStatus.Active && index == 2)
                {
                    return stepViewItem.FindResource("ActiveThirdStepTemplate") as DataTemplate;
                }
            }
            return null;
        }
    }

    /// <summary>
    /// Method to select the rectangle data template for Marker.
    /// </summary>
    public class CustomRectangleTemplate : DataTemplateSelector
    {
        /// <summary>
        /// Method to select the template based on status and index.
        /// </summary>
        /// <param name="item">stepview item.</param>
        /// <param name="container">step progress bar.</param>
        /// <returns>data template.</returns>
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            StepViewItem stepViewItem = item as StepViewItem;
            if (stepViewItem != null)
            {
                if (stepViewItem.Status == StepStatus.Active)
                {
                    return stepViewItem.FindResource("CompletedTemplate") as DataTemplate;
                }
                else if (stepViewItem.Status == StepStatus.Indeterminate)
                {
                    return stepViewItem.FindResource("InProgressTemplate") as DataTemplate;
                }
                else
                {
                    return stepViewItem.FindResource("NotStartedTemplate") as DataTemplate;
                }
            }

            return null;
        }
    }
}
