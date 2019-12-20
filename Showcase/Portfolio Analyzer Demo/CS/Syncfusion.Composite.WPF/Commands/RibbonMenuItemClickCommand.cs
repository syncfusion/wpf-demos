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
using System.Windows.Controls;
using System.Windows.Input;
using Microsoft.Practices.Composite.Presentation.Commands;
using Syncfusion.Windows.Tools.Controls;

namespace Syncfusion.Composite.WPF
{
    /// <summary>
    /// ClickBehavior that support handling Click event for control that inherits from MenuItem 
    /// </summary>
    public class ClickBehavior : CommandBehaviorBase<MenuItem>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickBehavior"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        public ClickBehavior(MenuItem element)
            : base(element)
        {
            element.Click += new RoutedEventHandler(element_Click);
        }

        /// <summary>
        /// Handles the Click event of the element control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        void element_Click(object sender, RoutedEventArgs e)
        {
            base.ExecuteCommand();
        }
    }

    /// <summary>
    /// Static Class that helps to attach the command.
    /// </summary>
    public static class ItemClick
    {
        /// <summary>
        /// Gets the command.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static ICommand GetCommand(DependencyObject obj)
        {
            return (ICommand)obj.GetValue(CommandProperty);
        }

        /// <summary>
        /// Sets the command.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="value">The value.</param>
        public static void SetCommand(DependencyObject obj, ICommand value)
        {
            obj.SetValue(CommandProperty, value);
        }

        /// <summary>
        /// Command Dependency property.
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(ItemClick), new PropertyMetadata(OnSetCommandCallback));

        /// <summary>
        /// Called when [set command callback].
        /// </summary>
        /// <param name="dependencyObject">The dependency object.</param>
        /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
        private static void OnSetCommandCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            MenuItem element = dependencyObject as MenuItem;
            if (element != null)
            {
                ClickBehavior behavior = GetOrCreateBehavior(element);
                behavior.Command = e.NewValue as ICommand;
            }
        }

        /// <summary>
        /// Gets the or create behavior.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        private static ClickBehavior GetOrCreateBehavior(MenuItem element)
        {
            ClickBehavior behavior = element.GetValue(ItemClickCommandBehaviorProperty) as ClickBehavior;
            if (behavior == null)
            {
                behavior = new ClickBehavior(element);
                element.SetValue(ItemClickCommandBehaviorProperty, behavior);
            }

            return behavior;
        }



        /// <summary>
        /// Gets the item click command behavior.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <returns></returns>
        public static ClickBehavior GetItemClickCommandBehavior(DependencyObject obj)
        {
            return (ClickBehavior)obj.GetValue(ItemClickCommandBehaviorProperty);
        }

        /// <summary>
        /// Sets the item click command behavior.
        /// </summary>
        /// <param name="obj">The obj.</param>
        /// <param name="value">The value.</param>
        public static void SetItemClickCommandBehavior(DependencyObject obj, ClickBehavior value)
        {
            obj.SetValue(ItemClickCommandBehaviorProperty, value);
        }

        public static readonly DependencyProperty ItemClickCommandBehaviorProperty =
            DependencyProperty.RegisterAttached("ItemClickCommandBehavior",
            typeof(ClickBehavior), typeof(ItemClick), null);
    }
    
}
