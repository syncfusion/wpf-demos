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
      public class MouseDownBehavior : CommandBehaviorBase<RibbonTab>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ClickBehavior"/> class.
        /// </summary>
        /// <param name="element">The element.</param>
        public MouseDownBehavior(RibbonTab element)
            : base(element)
        {
            element.PreviewMouseLeftButtonDown +=new MouseButtonEventHandler(element_PreviewMouseLeftButtonDown);
        }

        void element_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
           if((e.Source as RibbonTab)!=null)
            base.ExecuteCommand();
        }
    }

     
        public static class TabMouseButtonDown
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
                DependencyProperty.RegisterAttached("Command", typeof(ICommand), typeof(TabMouseButtonDown), new PropertyMetadata(OnSetCommandCallback));

            /// <summary>
            /// Called when [set command callback].
            /// </summary>
            /// <param name="dependencyObject">The dependency object.</param>
            /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
            private static void OnSetCommandCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
            {
                RibbonTab element = dependencyObject as RibbonTab;
                if (element != null)
                {
                    MouseDownBehavior behavior = GetOrCreateBehavior(element);
                    behavior.Command = e.NewValue as ICommand;
                }
            }

            /// <summary>
            /// Gets the or create behavior.
            /// </summary>
            /// <param name="element">The element.</param>
            /// <returns></returns>
            private static MouseDownBehavior GetOrCreateBehavior(RibbonTab element)
            {
                MouseDownBehavior behavior = element.GetValue(ItemClickCommandBehaviorProperty) as MouseDownBehavior;
                if (behavior == null)
                {
                    behavior = new MouseDownBehavior(element);
                    element.SetValue(ItemClickCommandBehaviorProperty, behavior);
                }

                return behavior;
            }



            /// <summary>
            /// Gets the item click command behavior.
            /// </summary>
            /// <param name="obj">The obj.</param>
            /// <returns></returns>
            public static MouseDownBehavior GetItemClickCommandBehavior(DependencyObject obj)
            {
                return (MouseDownBehavior)obj.GetValue(ItemClickCommandBehaviorProperty);
            }

            /// <summary>
            /// Sets the item click command behavior.
            /// </summary>
            /// <param name="obj">The obj.</param>
            /// <param name="value">The value.</param>
            public static void SetItemClickCommandBehavior(DependencyObject obj, MouseDownBehavior value)
            {
                obj.SetValue(ItemClickCommandBehaviorProperty, value);
            }

            public static readonly DependencyProperty ItemClickCommandBehaviorProperty =
                DependencyProperty.RegisterAttached("ItemClickCommandBehavior",
                typeof(MouseDownBehavior), typeof(TabMouseButtonDown), null);
        }
    
}
