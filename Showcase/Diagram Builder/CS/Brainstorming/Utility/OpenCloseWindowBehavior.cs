// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenCloseWindowBehavior.cs" company="">
//   
// </copyright>
// <summary>
//   The open close window behavior.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Brainstorming.Utility
{
    using System;
    using System.Windows;

    using Brainstorming.View;
    using Brainstorming.ViewModel;

    /// <summary>
    ///     The open close window behavior.
    /// </summary>
    public class OpenCloseWindowBehavior : DependencyObject
    {
        /// <summary>
        ///     The open topic change window property.
        /// </summary>
        public static readonly DependencyProperty OpenTopicChangeWindowProperty = DependencyProperty.Register(
            "OpenTopicChangeWindow",
            typeof(bool),
            typeof(OpenCloseWindowBehavior),
            new PropertyMetadata(false, OnOpenTopicChangeWindowChanged));

        /// <summary>
        ///     The open multiple sub topic window property.
        /// </summary>
        public static readonly DependencyProperty OpenMultipleSubTopicWindowProperty = DependencyProperty.Register(
            "OpenMultipleSubTopicWindow",
            typeof(bool),
            typeof(OpenCloseWindowBehavior),
            new PropertyMetadata(false, OnOpenMultipleSubTopicWindowChanged));

        /// <summary>
        ///     The open diagram style window property.
        /// </summary>
        public static readonly DependencyProperty OpenDiagramStyleWindowProperty = DependencyProperty.Register(
            "OpenDiagramStyleWindow",
            typeof(bool),
            typeof(OpenCloseWindowBehavior),
            new PropertyMetadata(false, OnDiagramStyleWindowChanged));

        /// <summary>
        ///     The open message box window property.
        /// </summary>
        public static readonly DependencyProperty OpenMessageBoxWindowProperty = DependencyProperty.Register(
            "OpenMessageBoxWindow",
            typeof(bool),
            typeof(OpenCloseWindowBehavior),
            new PropertyMetadata(false, OnMessageBoxWindowChanged));

        /// <summary>
        ///     The open export message window property.
        /// </summary>
        public static readonly DependencyProperty OpenExportMessageWindowProperty = DependencyProperty.Register(
            "OpenExportMessageWindow",
            typeof(bool),
            typeof(OpenCloseWindowBehavior),
            new PropertyMetadata(false, OnExportMessageWindowChanged));

        // Using a DependencyProperty as the backing store for OpenExportMessageWindow.  This enables animation, styling, binding, etc...

        // Using a DependencyProperty as the backing store for OpenDiagramStyleWindow.  This enables animation, styling, binding, etc...

        // Using a DependencyProperty as the backing store for OpenMessageBoxWindow.  This enables animation, styling, binding, etc...

        // Using a DependencyProperty as the backing store for OpenMultipleSubTopicWindow.  This enables animation, styling, binding, etc...

        // Using a DependencyProperty as the backing store for TopicChangeWindow.  This enables animation, styling, binding, etc...
        /// <summary>
        ///     The _window instance.
        /// </summary>
        private Window _windowInstance;

        /// <summary>
        ///     Gets or sets the brainstorming builder vm.
        /// </summary>
        public BrainstormingBuilderVM BrainstormingBuilderVM { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether open diagram style window.
        /// </summary>
        public bool OpenDiagramStyleWindow
        {
            get
            {
                return (bool)this.GetValue(OpenDiagramStyleWindowProperty);
            }

            set
            {
                this.SetValue(OpenDiagramStyleWindowProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether open export message window.
        /// </summary>
        public bool OpenExportMessageWindow
        {
            get
            {
                return (bool)this.GetValue(OpenExportMessageWindowProperty);
            }

            set
            {
                this.SetValue(OpenExportMessageWindowProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether open message box window.
        /// </summary>
        public bool OpenMessageBoxWindow
        {
            get
            {
                return (bool)this.GetValue(OpenMessageBoxWindowProperty);
            }

            set
            {
                this.SetValue(OpenMessageBoxWindowProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether open multiple sub topic window.
        /// </summary>
        public bool OpenMultipleSubTopicWindow
        {
            get
            {
                return (bool)this.GetValue(OpenMultipleSubTopicWindowProperty);
            }

            set
            {
                this.SetValue(OpenMultipleSubTopicWindowProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets a value indicating whether open topic change window.
        /// </summary>
        public bool OpenTopicChangeWindow
        {
            get
            {
                return (bool)this.GetValue(OpenTopicChangeWindowProperty);
            }

            set
            {
                this.SetValue(OpenTopicChangeWindowProperty, value);
            }
        }

        /// <summary>
        /// The on diagram style window changed.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnDiagramStyleWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OpenCloseWindowBehavior openCloseBehavior = (OpenCloseWindowBehavior)d;
            if ((bool)e.NewValue)
            {
                object instance = Activator.CreateInstance(typeof(DiagramStyleWindow));
                if (instance is Window)
                {
                    Window window = (Window)instance;
                    window.Owner = Application.Current.MainWindow;
                    if (window.DataContext == null)
                    {
                        openCloseBehavior.BrainstormingBuilderVM.DiagramStyleViewModel.UpdateTopics();
                        window.DataContext = openCloseBehavior.BrainstormingBuilderVM.DiagramStyleViewModel;
                        DiagramStyleViewModel diagramStyleViewModel = window.DataContext as DiagramStyleViewModel;
                        if (diagramStyleViewModel.StyleDiagram == null)
                        {
                            diagramStyleViewModel.StyleDiagram = window.Resources["DiagramVM"] as BrainstormingVM;
                        }

                        if (diagramStyleViewModel.StyleDiagram.Theme
                            != openCloseBehavior.BrainstormingBuilderVM.SelectedDiagram.Theme)
                        {
                            diagramStyleViewModel.StyleDiagram.Theme =
                                openCloseBehavior.BrainstormingBuilderVM.SelectedDiagram.Theme;
                            diagramStyleViewModel.GenerateThemeStyleCollection();
                        }

                        diagramStyleViewModel.ApplyLevelStyle();
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

        /// <summary>
        /// The on export message window changed.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnExportMessageWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OpenCloseWindowBehavior openCloseBehavior = (OpenCloseWindowBehavior)d;
            if ((bool)e.NewValue)
            {
                object instance = Activator.CreateInstance(typeof(ExportMessageWindow));
                if (instance is Window)
                {
                    Window window = (Window)instance;
                    window.Owner = Application.Current.MainWindow;
                    if (window.DataContext == null)
                    {
                        window.DataContext = new ExportMessageViewModel(openCloseBehavior.BrainstormingBuilderVM);
                    }

                    window.Closing += (s, ev) =>
                        {
                            if (openCloseBehavior.OpenExportMessageWindow)
                            {
                                openCloseBehavior._windowInstance = null;
                                openCloseBehavior.OpenExportMessageWindow = false;
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

        /// <summary>
        /// The on message box window changed.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnMessageBoxWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OpenCloseWindowBehavior openCloseBehavior = (OpenCloseWindowBehavior)d;
            if ((bool)e.NewValue)
            {
                object instance = Activator.CreateInstance(typeof(MessageBoxWindow));
                if (instance is Window)
                {
                    Window window = (Window)instance;
                    window.Owner = Application.Current.MainWindow;
                    if (window.DataContext == null)
                    {
                        window.DataContext = new MessageBoxWindowViewModel(openCloseBehavior.BrainstormingBuilderVM);
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

        /// <summary>
        /// The on open multiple sub topic window changed.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnOpenMultipleSubTopicWindowChanged(
            DependencyObject d,
            DependencyPropertyChangedEventArgs e)
        {
            OpenCloseWindowBehavior openCloseBehavior = (OpenCloseWindowBehavior)d;
            if ((bool)e.NewValue)
            {
                object instance = Activator.CreateInstance(typeof(MultipleSubTopicWindow));
                if (instance is Window)
                {
                    Window window = (Window)instance;
                    window.Owner = Application.Current.MainWindow;
                    if (window.DataContext == null)
                    {
                        window.DataContext = openCloseBehavior.BrainstormingBuilderVM.MultipleSubTopicViewModel;
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

        /// <summary>
        /// The on open topic change window changed.
        /// </summary>
        /// <param name="d">
        /// The d.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private static void OnOpenTopicChangeWindowChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            OpenCloseWindowBehavior openCloseBehavior = (OpenCloseWindowBehavior)d;
            if ((bool)e.NewValue)
            {
                object instance = Activator.CreateInstance(typeof(TopicChangeWindow));
                if (instance is Window)
                {
                    Window window = (Window)instance;
                    window.Owner = Application.Current.MainWindow;
                    if (window.DataContext == null)
                    {
                        openCloseBehavior.BrainstormingBuilderVM.ChangeTopicViewModel.UpdateTopics();
                        window.DataContext = openCloseBehavior.BrainstormingBuilderVM.ChangeTopicViewModel;
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
    }
}