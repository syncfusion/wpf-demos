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

using Microsoft.Practices.Composite.Presentation.Events;
using System.Windows;
using System.Windows.Input;


namespace PortfolioAnalyzer.Infrastructure
{
    /// <summary>
    /// Represents the Account selected event.
    /// </summary>
    public class Events : CompositePresentationEvent<string>
    {
    }

    /// <summary>
    /// Represents the Stock selected event.
    /// </summary>
    public class StockSelectedEvent : CompositePresentationEvent<string>
    {
    }

    /// <summary>
    /// Represents the Animation Activation event.
    /// </summary>
    public class AnimationEvents : CompositePresentationEvent<bool>
    {
    }

    /// <summary>
    /// Represents the Animation type selected event.
    /// </summary>
    public class AnimationTypesEvents : CompositePresentationEvent<string>
    {
    }

    /// <summary>
    /// Represents the Dashboard View Animation Activation event.
    /// </summary>
    public class DashboardAnimationEvents : CompositePresentationEvent<bool>
    {
    }

    /// <summary>
    /// Represents the ThreeD View Mode Activation event.
    /// </summary>
    public class ThreeDEvent : CompositePresentationEvent<bool>
    {
    }

    /// <summary>
    /// Represents the Selected View Activation event.
    /// </summary>
    public class SelectedViewEvents : CompositePresentationEvent<string>
    {
    }

    /// <summary>
    /// Represents the Stock LiveUpdate event.
    /// </summary>
    public class StartStopUpdateEvent : CompositePresentationEvent<bool>
    {
    }

    /// <summary>
    /// Represents the Stock LiveUpdate event.
    /// </summary>
    public class ShowHideGroupingEvent : CompositePresentationEvent<bool>
    {
    }

    /// <summary>
    /// Represents the SkinChanged event.
    /// </summary>
    public class SkinChangedEvent : CompositePresentationEvent<string>
    {
    }

    /// <summary>
    /// Represents the ChartTypeChanged event.
    /// </summary>
    public class ChartTypesEvent : CompositePresentationEvent<string>
    {
    }

    public static class EventBehaviourFactory
    {
        public static DependencyProperty CreateCommandExecutionEventBehaviour(RoutedEvent routedEvent, string propertyName, Type ownerType)
        {
            DependencyProperty property = DependencyProperty.RegisterAttached(propertyName, typeof(ICommand), ownerType,
                                                               new PropertyMetadata(null,
                                                                   new ExecuteCommandOnRoutedEventBehaviour(routedEvent).PropertyChangedHandler));

            return property;
        }



        /// <summary>
        /// Executes the command when the corresponding event gets fired
        /// </summary>
        private class ExecuteCommandOnRoutedEventBehaviour
        {
            private readonly RoutedEvent routedEvent;

            protected DependencyProperty dproperty;


            protected void HandleEvent(object sender, EventArgs e)
            {
                DependencyObject dp = sender as DependencyObject;
                if (dp == null)
                {
                    return;
                }

                ICommand command = dp.GetValue(dproperty) as ICommand;

                if (command == null)
                {
                    return;
                }

                if (command.CanExecute(e))
                {
                    command.Execute(e);
                }
            }


            /// <summary>
            /// Notifies the property changes.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="System.Windows.DependencyPropertyChangedEventArgs"/> instance containing the event data.</param>
            public void PropertyChangedHandler(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ExecuteCommandOnRoutedEventBehaviour"/> class.
            /// </summary>
            /// <param name="routedEvent">The routed event.</param>
            public ExecuteCommandOnRoutedEventBehaviour(RoutedEvent routedEvent)
            {
                this.routedEvent = routedEvent;
            }

            /// <summary>
            /// Handles the events
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
            protected void EventHandler(object sender, RoutedEventArgs e)
            {
                HandleEvent(sender, e);
            }
        }


    }
}
