#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
namespace syncfusion.diagrambuilder.wpf
{
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Input;
    using DiagramBuilder;
    using DiagramBuilder.Utility;
    using DiagramBuilder.ViewModel;

    using Syncfusion.Windows.Shared;
    using Syncfusion.Windows.Tools.Controls;

    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class DiagramBuilderDemo : RibbonWindow
    {
        /// <summary>
        ///     The exit property.
        /// </summary>
        public static readonly DependencyProperty ExitProperty = DependencyProperty.Register(
            "Exit",
            typeof(ICommand),
            typeof(DiagramBuilderDemo),
            new PropertyMetadata(null));

        /// <summary>
        ///     The zoom in property.
        /// </summary>
        public static readonly DependencyProperty ZoomInProperty = DependencyProperty.Register(
            "ZoomIn",
            typeof(ICommand),
            typeof(DiagramBuilderDemo),
            new PropertyMetadata(null));

        /// <summary>
        ///     The zoom out property.
        /// </summary>
        public static readonly DependencyProperty ZoomOutProperty = DependencyProperty.Register(
            "ZoomOut",
            typeof(ICommand),
            typeof(DiagramBuilderDemo),
            new PropertyMetadata(null));

        /// <summary>
        ///     Initializes a new instance of the <see cref="MainWindow" /> class.
        /// </summary>
        public DiagramBuilderDemo()
        {
            this.InitializeComponent();
            Binding exitBinding = new Binding();
            exitBinding.Path = new PropertyPath("Exit");
            exitBinding.Mode = BindingMode.TwoWay;
            this.SetBinding(ExitProperty, exitBinding);
            Binding zoomInBinding = new Binding();
            zoomInBinding.Path = new PropertyPath("ZoomIn");
            this.SetBinding(ZoomInProperty, zoomInBinding);
            Binding zoomOutBinding = new Binding();
            zoomOutBinding.Path = new PropertyPath("ZoomOut");
            this.SetBinding(ZoomOutProperty, zoomOutBinding);
            this.Exit = new Command(this.OnExitCommand);
            this.ZoomIn = new Command(this.OnZoomInCommand);
            this.ZoomOut = new Command(this.OnZoomOutCommand);

            SkinStorage.SetVisualStyle(this, "Office2013");
            this.Closing += this.MainWindowClosing;
            this.DataContextChanged += this.MainWindow_DataContextChanged;
            this.Loaded += this.MainWindowLoaded;
        }

        /// <summary>
        ///     Gets or sets the exit.
        /// </summary>
        public ICommand Exit
        {
            get
            {
                return (ICommand)this.GetValue(ExitProperty);
            }

            set
            {
                this.SetValue(ExitProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the zoom in.
        /// </summary>
        public ICommand ZoomIn
        {
            get
            {
                return (ICommand)this.GetValue(ZoomInProperty);
            }

            set
            {
                this.SetValue(ZoomInProperty, value);
            }
        }

        /// <summary>
        ///     Gets or sets the zoom out.
        /// </summary>
        public ICommand ZoomOut
        {
            get
            {
                return (ICommand)this.GetValue(ZoomOutProperty);
            }

            set
            {
                this.SetValue(ZoomOutProperty, value);
            }
        }

        /// <summary>
        /// The on exit command.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public async void OnExitCommand(object value)
        {
            IDiagramBuilderVM viewModel = this.DataContext as IDiagramBuilderVM;
            await viewModel.PrepareExit();
            this.Exit = null;
        }

        /// <summary>
        /// The on zoom in command.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        public void OnZoomInCommand(object param)
        {
            IDiagramBuilderVM vm = this.DataContext as IDiagramBuilderVM;
            if (vm != null)
            {
                vm.ZoomIn.Execute(null);
            }
        }

        /// <summary>
        /// The on zoom out command.
        /// </summary>
        /// <param name="param">
        /// The param.
        /// </param>
        public void OnZoomOutCommand(object param)
        {
            IDiagramBuilderVM vm = this.DataContext as IDiagramBuilderVM;
            vm.ZoomOut.Execute(null);
        }

        /// <summary>
        /// The close button_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void CloseButtonClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// The main window_ data context changed.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MainWindow_DataContextChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
        }

        /// <summary>
        /// The main window_ closing.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MainWindowClosing(object sender, CancelEventArgs e)
        {
            DiagramBuilderVM vm = this.DataContext as DiagramBuilderVM;
            if (vm != null && vm.SelectedDiagram != null)
            {
                MessageBoxResult messageBoxResult = MessageBox.Show(
                    "Do you want to save Diagram?",
                    "Diagram Builder",
                    MessageBoxButton.YesNoCancel);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    vm.Save.Execute(null);
                }
                else if (messageBoxResult == MessageBoxResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }

        /// <summary>
        /// The main window_ loaded.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void MainWindowLoaded(object sender, RoutedEventArgs e)
        {
            this.ribbon.ShowBackStage();
        }

        private void Ribbon_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            DiagramBuilderVM vm = this.DataContext as DiagramBuilderVM;
            if (vm != null && vm.SelectedDiagram != null && e.AddedItems.Count != 0)
            {
                var selecteditem = e.AddedItems[0] as DiagramTabViewModel;
                if (selecteditem != null)
                {
                    if (selecteditem.Header == "ORGANIZATIONCHART")
                    {
                        vm.SelectedDiagram.OrgChart = Visibility.Visible;
                    }
                    else
                    {
                        vm.SelectedDiagram.OrgChart = Visibility.Collapsed;
                    }
                }
            }
        }

        private void HideBackstage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}