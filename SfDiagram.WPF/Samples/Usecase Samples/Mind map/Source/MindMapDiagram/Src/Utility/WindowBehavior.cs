#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Syncfusion.UI.Xaml.MindMapDiagram.View;
using Syncfusion.UI.Xaml.MindMapDiagram.ViewModel;
using Syncfusion.UI.Xaml.Diagram;

namespace Syncfusion.UI.Xaml.MindMapDiagram.Utility
{
    public class OpenCloseWindowBehavior : DependencyObject
    {
        private Window _windowInstance;
        public MindMapViewModel MindMapViewModel { get; set; }

        #region Open or Close Topic Change Window
        public bool OpenTopicChangeWindow
        {
            get { return (bool)GetValue(OpenTopicChangeWindowProperty); }
            set { SetValue(OpenTopicChangeWindowProperty, value); }
        }
        // Using a DependencyProperty as the backing store for TopicChangeWindow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenTopicChangeWindowProperty =
            DependencyProperty.Register("OpenTopicChangeWindow", typeof(bool), typeof(OpenCloseWindowBehavior), new PropertyMetadata(false, OnOpenTopicChangeWindowChanged));
        private static void OnOpenTopicChangeWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var openCloseBehavior = (OpenCloseWindowBehavior)d;
            if ((bool)e.NewValue)
            {
                object instance = Activator.CreateInstance(typeof(TopicChangeWindow));
                if (instance is Window)
                {
                    Window window = (Window)instance;
                    window.Owner = Application.Current.MainWindow;
                    if (window.DataContext == null)
                    {
                        openCloseBehavior.MindMapViewModel.ChangeTopicViewModel.UpdateTopics();
                        window.DataContext = openCloseBehavior.MindMapViewModel.ChangeTopicViewModel;
                    }
                    window.Closing += (s, ev) =>
                    {
                        if (openCloseBehavior.OpenTopicChangeWindow)
                        {
                            openCloseBehavior._windowInstance = null;
                            openCloseBehavior.OpenTopicChangeWindow = false;
                        }
                    };
                    openCloseBehavior._windowInstance = window;
                    window.ShowDialog();
                }
                else
                {
                    if (openCloseBehavior._windowInstance != null)
                        openCloseBehavior._windowInstance.Close();
                }
            }
            else
            {
                if (openCloseBehavior._windowInstance != null)
                    openCloseBehavior._windowInstance.Close();
            }
        }
        #endregion
        #region Open or  Close Multiple Subtopic Window
        public bool OpenMultipleSubTopicWindow
        {
            get { return (bool)GetValue(OpenMultipleSubTopicWindowProperty); }
            set { SetValue(OpenMultipleSubTopicWindowProperty, value); }
        }
        // Using a DependencyProperty as the backing store for OpenMultipleSubTopicWindow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenMultipleSubTopicWindowProperty =
            DependencyProperty.Register("OpenMultipleSubTopicWindow", typeof(bool), typeof(OpenCloseWindowBehavior), new PropertyMetadata(false, OnOpenMultipleSubTopicWindowChanged));
        private static void OnOpenMultipleSubTopicWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var openCloseBehavior = (OpenCloseWindowBehavior)d;
            if ((bool)e.NewValue)
            {
                object instance = Activator.CreateInstance(typeof(MultipleSubTopicWindow));
                if (instance is Window)
                {
                    Window window = (Window)instance;
                    window.Owner = Application.Current.MainWindow;
                    if (window.DataContext == null)
                    {
                        window.DataContext = openCloseBehavior.MindMapViewModel.MultipleSubTopicViewModel;
                        (window.DataContext as MultipleSubTopicViewModel).SelectedItem = "Topic 1";
                    }
                    window.Closing += (s, ev) =>
                    {
                        if (openCloseBehavior.OpenMultipleSubTopicWindow)
                        {
                            openCloseBehavior._windowInstance = null;
                            openCloseBehavior.OpenMultipleSubTopicWindow = false;
                        }
                    };
                    openCloseBehavior._windowInstance = window;
                    window.ShowDialog();
                }
                else
                {
                    if (openCloseBehavior._windowInstance != null)
                        openCloseBehavior._windowInstance.Close();
                }
            }
            else
            {
                if (openCloseBehavior._windowInstance != null)
                    openCloseBehavior._windowInstance.Close();
            }
        }
        #endregion

        #region Open or Close Diagram Style Window
        public bool OpenDiagramStyleWindow
        {
            get { return (bool)GetValue(OpenDiagramStyleWindowProperty); }
            set { SetValue(OpenDiagramStyleWindowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenDiagramStyleWindow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenDiagramStyleWindowProperty =
            DependencyProperty.Register("OpenDiagramStyleWindow", typeof(bool), typeof(OpenCloseWindowBehavior), new PropertyMetadata(false, OnDiagramStyleWindowChanged));
        private static void OnDiagramStyleWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var openCloseBehavior = (OpenCloseWindowBehavior)d;
            if ((bool)e.NewValue)
            {
                object instance = Activator.CreateInstance(typeof(DiagramStyleWindow));
                if (instance is Window)
                {
                    Window window = (Window)instance;
                    window.Owner = Application.Current.MainWindow;
                    if (window.DataContext == null)
                    {
                        openCloseBehavior.MindMapViewModel.DiagramStyleViewModel.UpdateTopics();
                        window.DataContext = openCloseBehavior.MindMapViewModel.DiagramStyleViewModel;
                        if ((window.DataContext as DiagramStyleViewModel).StyleDiagram == null)
                        {
                            (window.DataContext as DiagramStyleViewModel).StyleDiagram = window.Resources["DiagramVM"] as MindMapViewModel;
                        }
                        if ((window.DataContext as DiagramStyleViewModel).StyleDiagram.Theme != openCloseBehavior.MindMapViewModel.Theme)
                        {
                            (window.DataContext as DiagramStyleViewModel).StyleDiagram.Theme = openCloseBehavior.MindMapViewModel.Theme;
                            (window.DataContext as DiagramStyleViewModel).GenerateThemeStyleCollection();
                        }
                            (window.DataContext as DiagramStyleViewModel).ApplyLevelStyle();
                    }
                    window.Closing += (s, ev) =>
                    {
                        if (openCloseBehavior.OpenDiagramStyleWindow)
                        {
                            openCloseBehavior._windowInstance = null;
                            openCloseBehavior.OpenDiagramStyleWindow = false;
                        }
                    };
                    openCloseBehavior._windowInstance = window;
                    window.ShowDialog();
                }
                else
                {
                    if (openCloseBehavior._windowInstance != null)
                        openCloseBehavior._windowInstance.Close();
                }
            }
            else
            {
                if (openCloseBehavior._windowInstance != null)
                    openCloseBehavior._windowInstance.Close();
            }
        }
        #endregion

        #region Open or Close Message Box Window
        public bool OpenMessageBoxWindow
        {
            get { return (bool)GetValue(OpenMessageBoxWindowProperty); }
            set { SetValue(OpenMessageBoxWindowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for OpenMessageBoxWindow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty OpenMessageBoxWindowProperty =
            DependencyProperty.Register("OpenMessageBoxWindow", typeof(bool), typeof(OpenCloseWindowBehavior), new PropertyMetadata(false, OnMessageBoxWindowChanged));

        private static void OnMessageBoxWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var openCloseBehavior = (OpenCloseWindowBehavior)d;
            if ((bool)e.NewValue)
            {
                object instance = Activator.CreateInstance(typeof(MessageBoxWindow));
                if (instance is Window)
                {
                    Window window = (Window)instance;
                    window.Owner = Application.Current.MainWindow;
                    if (window.DataContext == null)
                    {
                        window.DataContext = new MessageBoxWindowViewModel(openCloseBehavior.MindMapViewModel);
                    }
                    window.Closing += (s, ev) =>
                    {
                        if (openCloseBehavior.OpenMessageBoxWindow)
                        {
                            openCloseBehavior._windowInstance = null;
                            openCloseBehavior.OpenMessageBoxWindow = false;
                        }
                    };
                    openCloseBehavior._windowInstance = window;
                    window.ShowDialog();
                }
                else
                {
                    if (openCloseBehavior._windowInstance != null)
                        openCloseBehavior._windowInstance.Close();
                }
            }
            else
            {
                if (openCloseBehavior._windowInstance != null)
                    openCloseBehavior._windowInstance.Close();
            }
        }
        #endregion

        
    }
}
