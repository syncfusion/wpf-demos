#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Syncfusion.UI.Xaml.Diagram;
using Syncfusion.UI.Xaml.Diagram.Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace OrganizationalChartDemo
{
    //Event to Commands Wrapper
    class ComboBoxCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
        typeof(ComboBoxCommand), new PropertyMetadata(null, PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            ComboBox comboBox = depObj as ComboBox;
            if (comboBox != null)
            {              
                comboBox.SelectionChanged += comboBox_SelectionChanged;              
            }
        }

        static void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {
                if (comboBox.SelectedItem != null)
                {
                    if ((comboBox.SelectedItem as ComboBoxItem).Tag is TextBox)
                        ((comboBox.SelectedItem as ComboBoxItem).Tag as TextBox).Text = string.Empty;
                    else if ((comboBox.SelectedItem as ComboBoxItem).Tag is ComboBox)
                        ((comboBox.SelectedItem as ComboBoxItem).Tag as ComboBox).SelectedIndex = -1;
                }
                ICommand command = comboBox.GetValue(CommandProperty) as ICommand;
                if (command != null)
                {
                    command.Execute(comboBox);
                }
            }
        }
        public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }
    }

    class SalaryComboBoxCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
        typeof(SalaryComboBoxCommand), new PropertyMetadata(null, PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            ComboBox comboBox = depObj as ComboBox;
            if (comboBox != null)
            {
                comboBox.SelectionChanged += comboBox_SelectionChanged;
            }
        }

        static void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {    
                    ICommand command = comboBox.GetValue(CommandProperty) as ICommand;
                    if (command != null)
                    {
                        if (comboBox.SelectedItem != null)
                        {
                            ComboBoxItem cb = comboBox.SelectedItem as ComboBoxItem; ;
                            command.Execute(cb.Content);
                        }
                    }
                }
            }
         public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }
    }

    class DesignationComboBoxCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
        typeof(DesignationComboBoxCommand), new PropertyMetadata(null, PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            ComboBox comboBox = depObj as ComboBox;
            if (comboBox != null)
            {
                comboBox.SelectionChanged += comboBox_SelectionChanged;
            }
        }

        static void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            if (comboBox != null)
            {

                ICommand command = comboBox.GetValue(CommandProperty) as ICommand;
                if (command != null)
                {
                    if (comboBox.SelectedItem != null)
                    {
                        ComboBoxItem cb = comboBox.SelectedItem as ComboBoxItem; ;

                        command.Execute(cb.Content);
                    }
                }
            }
        }
        public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }
    }

    class TextBoxCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
        typeof(TextBoxCommand), new PropertyMetadata(null, PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            TextBox textBox = depObj as TextBox;
            if (textBox != null)
            {
                textBox.TextChanged += textBox_TextChanged;
            }
        }

        static void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (sender as TextBox);
            if (textBox != null)
            {
            
                ICommand command = textBox.GetValue(CommandProperty) as ICommand;
                if (command != null)
                {
                    command.Execute(textBox.Text);
                }
            }
        }

        public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }
    }

    class DiagramCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
        typeof(DiagramCommand), new PropertyMetadata(null, PropertyChangedCallback));

        private static OrgChartDiagram diagram = null;
        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            diagram = depObj as OrgChartDiagram;
            if (args.NewValue == null)
            {
                (diagram.Info as IGraphInfo).ItemTappedEvent -= diagram_ItemTappedEvent;
                diagram.Loaded -= sfdiagram_Loaded;
                diagram = null;
            }
            if (diagram != null)
            {
                (diagram.Info as IGraphInfo).ItemTappedEvent += diagram_ItemTappedEvent;
                diagram.Loaded += sfdiagram_Loaded;
            }
        }

        static void diagram_ItemTappedEvent(object sender, DiagramEventArgs args)
        {           
        }

        static void sfdiagram_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var item in (sender as SfDiagram).Page.Children.OfType<Node>())
            {
                if (item.GetType() != typeof(Syncfusion.UI.Xaml.Diagram.Selector))
                {
                    if (((item as Node).DataContext as OrgNodeViewModel).Content is Employee)
                    {
                        if ((((item as Node).DataContext as OrgNodeViewModel).Content as Employee).IsExpand == State.Collapse)
                        {
                            (((item as Node).DataContext as OrgNodeViewModel).Content as Employee).IsExpand = State.Collapse;
                            ((item as Node).DataContext as OrgNodeViewModel).IsExpanded = false;
                            Hide(((item as Node).DataContext as OrgNodeViewModel));                                                      
                        } 
                    }
                    else
                    {
                        (item as Node).IsHitTestVisible = false;
                    }
                }
            }
            (sender as OrgChartDiagram).LayoutManager.Layout.UpdateLayout();
        }

       
        //Collapses the Child Nodes
        private static void Hide(OrgNodeViewModel n)
        {
            foreach (OrgNodeViewModel node in diagram.Page.Children.OfType<Connector>()
                                  .Where(connector => (connector.SourceNode as OrgNodeViewModel) == n)
                                  .Select(connector => (connector.TargetNode as OrgNodeViewModel)))
            {
                foreach (Connector line in diagram.Page.Children.OfType<Connector>()
                                  .Where(connector => connector.TargetNode == node || connector.SourceNode == node))
                {
                    (line.DataContext as OrgConnectorViewModel).Visible = false;
                    CollapseAnimation(line);
                }            
                foreach (Node v in diagram.Page.Children.OfType<Node>())
                {
                    if (v.DataContext == node)
                    {
                        CollapseAnimation(v);
                        (v.DataContext as OrgNodeViewModel).Visible = false;
                    }

                }
                Hide(node);
            }
        }

      

        //Fade out animation
        static void CollapseAnimation(DependencyObject obj)
        {
            Duration duration = new Duration(TimeSpan.FromMilliseconds(300));
            // Create two DoubleAnimations and set their properties.
            DoubleAnimation myDoubleAnimation1 = new DoubleAnimation();
            myDoubleAnimation1.Duration = duration;
            Storyboard sb = new Storyboard();
            sb.Duration = duration;
            sb.Children.Add(myDoubleAnimation1);
            Storyboard.SetTarget(myDoubleAnimation1, obj);
            Storyboard.SetTargetProperty(myDoubleAnimation1,new PropertyPath("Opacity"));
            myDoubleAnimation1.From = 1d;
            myDoubleAnimation1.To = 0d;
            // Begin the animation.
            sb.Begin();
        }
        static void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (sender as TextBox);
            if (textBox != null)
            {
                ICommand command = textBox.GetValue(CommandProperty) as ICommand;
                if (command != null)
                {
                    command.Execute(textBox.Text);
                }
            }
        }

        public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }
    }

    class PathCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
        typeof(PathCommand), new PropertyMetadata(null, PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            FrameworkElement p = (depObj as FrameworkElement);
            if (p != null)
            {
                p.MouseLeftButtonDown += p_Tapped;
            }

        }

        static void p_Tapped(object sender, MouseButtonEventArgs e)
        {
            FrameworkElement button = sender as FrameworkElement;
            if (button != null)
            {
                ICommand command = (button.DataContext as Employee).PathClickCommand;
                if (command != null)
                {
                    command.Execute(button);
                }
            }
            e.Handled = true;
        }
      
        public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }
    }

    class ButtonCommand
    {
        public static readonly DependencyProperty CommandProperty = DependencyProperty.RegisterAttached("Command", typeof(ICommand),
        typeof(ButtonCommand), new PropertyMetadata(null, PropertyChangedCallback));

        public static void PropertyChangedCallback(DependencyObject depObj, DependencyPropertyChangedEventArgs args)
        {
            Grid button = depObj as Grid;
            if (button != null)
            {
                button.MouseLeftButtonUp += button_Tapped;
            }
        }

        static void button_Tapped(object sender, MouseButtonEventArgs e)
        {
            Grid button = sender as Grid;
            if (button != null)
            {
                ICommand command = button.GetValue(CommandProperty) as ICommand;
                if (command != null)
                {
                    command.Execute(button.Name);
                }
            }
        }

        public static ICommand GetCommand(UIElement element)
        {
            return (ICommand)element.GetValue(CommandProperty);
        }

        public static void SetCommand(UIElement element, ICommand command)
        {
            element.SetValue(CommandProperty, command);
        }
    }
    
}
