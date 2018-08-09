using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Practices.Composite.Presentation.Events;
using System.Windows;
using System.Windows.Input;
using Syncfusion.Windows.Chart;

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

    /// <summary>
    /// Class containing events for ChartSeries.
    /// </summary>
    public static class ChartSeriesEvents
    {
        public static readonly DependencyProperty MouseLeaveCommand = EventBehaviourFactory.CreateCommandExecutionEventBehaviour(ChartSeries.MouseLeaveEvent, "MouseLeaveCommand", typeof(ChartSeriesEvents));
        public static readonly DependencyProperty MouseMoveCommand = EventBehaviourFactory.CreateCommandExecutionEventBehaviour(ChartSeries.MouseMoveEvent, "MouseMoveCommand", typeof(ChartSeriesEvents));
        public static void SetMouseLeaveCommand(DependencyObject o, ICommand value)
        {
            o.SetValue(MouseLeaveCommand, value);
        }

        public static ICommand GetMouseLeaveCommand(DependencyObject o)
        {
            return o.GetValue(MouseLeaveCommand) as ICommand;
        }

        public static void SetMouseMoveCommand(DependencyObject o, ICommand value)
        {
            o.SetValue(MouseMoveCommand, value);
        }

        public static ICommand GetMouseMoveCommand(DependencyObject o)
        {
            return o.GetValue(MouseMoveCommand) as ICommand;
        }

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

                if (dproperty == null)
                {
                    dproperty = e.Property;
                }

                object oldValue = e.OldValue;
                object newValue = e.NewValue;

                AdjustEventHandlers(sender, oldValue, newValue);
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
            /// Adjusts the event handlers.
            /// </summary>
            /// <param name="sender">The sender.</param>
            /// <param name="oldValue">The old value.</param>
            /// <param name="newValue">The new value.</param>
            protected void AdjustEventHandlers(DependencyObject sender, object oldValue, object newValue)
            {
                ChartSeries element = sender as ChartSeries;
                if (element == null) { return; }

                if (newValue != null)
                {
                    element.AddHandler(routedEvent, new RoutedEventHandler(EventHandler));
                    if (routedEvent == Mouse.MouseMoveEvent)
                    {
                        element.MouseMove += new ChartMouseEventHandler(element_MouseMove);
                    }
                    else if (routedEvent == Mouse.MouseLeaveEvent)
                    {
                        element.MouseLeave += new ChartMouseEventHandler(element_MouseLeave);
                    }
                }
            }

            /// <summary>
            /// Handles the MouseMove event of the element control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="Syncfusion.Windows.Chart.ChartMouseEventArgs"/> instance containing the event data.</param>
            void element_MouseMove(object sender, ChartMouseEventArgs e)
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
            /// Handles the MouseLeave event of the element control.
            /// </summary>
            /// <param name="sender">The source of the event.</param>
            /// <param name="e">The <see cref="Syncfusion.Windows.Chart.ChartMouseEventArgs"/> instance containing the event data.</param>
            void element_MouseLeave(object sender, ChartMouseEventArgs e)
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
