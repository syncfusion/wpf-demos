#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace syncfusion.visualstudiodemo.wpf
{
    [Export(typeof(DockingAdapterViewModel))]
    public class DockingAdapterViewModel : PropertyChangedBase
    {
        private ObservableCollection<Workspace> dockingadapter;

        public ObservableCollection<Workspace> DockingAdapter
        {
            get { return dockingadapter; }
            set { dockingadapter = value; }
        }

        public DockingAdapterViewModel()
        {
            DockingAdapter = new ObservableCollection<Workspace>();

            ToolboxViewModel toolbox = new ToolboxViewModel() { Name = "ToolboxWindow", Header = "Toolbox", State = DockState.Dock, SideInDockMode = DockSide.Left, DesiredWidthInDockedMode = 250 };
            SolutionExplorerViewModel solutionexplorer = new SolutionExplorerViewModel() { Name = "SolutionExplorerWindow", Header = "Solution Explorer", State = DockState.Dock, SideInDockMode = DockSide.Right, DesiredWidthInDockedMode = 300 };
            ClassViewModel classview = new ClassViewModel() { Name = "ClassViewWindow", Header = "Class View", State = DockState.Dock, TargetNameInDockedMode = "SolutionExplorerWindow", SideInDockMode = DockSide.Tabbed };
            PropertiesViewModel properties = new PropertiesViewModel() { Name = "PropertiesWindow", Header = "Properties", State = DockState.Dock, TargetNameInDockedMode = "SolutionExplorerWindow", SideInDockMode = DockSide.Bottom };
            ErrorListViewModel errorlist = new ErrorListViewModel() { Name = "ErrorListWindow", Header = "Error List", State = DockState.Dock, SideInDockMode = DockSide.Bottom, DesiredHeightInDockedMode = 200 };
            FindSymbolResultsViewModel findsymbolresults = new FindSymbolResultsViewModel() { Name = "FindSymbolResultsWindow", Header = "Find Symbol Results", State = DockState.Dock, TargetNameInDockedMode = "ErrorListWindow", SideInDockMode = DockSide.Tabbed };
            OutputViewModel output = new OutputViewModel() { Name = "OutputWindow", Header = "Output", State = DockState.Dock, TargetNameInDockedMode = "ErrorListWindow", SideInDockMode = DockSide.Tabbed };
            FindResultsViewModel findresults = new FindResultsViewModel() { Name = "FindResults1Window", Header = "Find Results 1", State = DockState.Dock, TargetNameInDockedMode = "ErrorListWindow", SideInDockMode = DockSide.Tabbed };

            MainWindowXAMLViewModel mainwindowxaml = new MainWindowXAMLViewModel() { Header = "MainWindow.xaml", State = DockState.Document };
            MainWindowCSViewModel mainwindowcs = new MainWindowCSViewModel() { Header = "MainWindow.xaml.cs", State = DockState.Document };

            DockingAdapter.Add(toolbox);
            DockingAdapter.Add(solutionexplorer);
            DockingAdapter.Add(classview);
            DockingAdapter.Add(properties);
            DockingAdapter.Add(errorlist);
            DockingAdapter.Add(findsymbolresults);
            DockingAdapter.Add(output);
            DockingAdapter.Add(findresults);
            DockingAdapter.Add(mainwindowxaml);
            DockingAdapter.Add(mainwindowcs);
        }

        public Syncfusion.Windows.Tools.Controls.DockingManager AdapterDockingManager { get; set; }

        public void DockingManagerLoaded(DockingAdapterViewModel model)
        {
            AdapterDockingManager = (((((System.Windows.Application.Current.MainWindow as ShellView).Content as Grid).Children[1] as ContentControl).Content as DockingAdapterView).DockingAdapter.Content as Grid).Children[0] as Syncfusion.Windows.Tools.Controls.DockingManager;
        }
    }
}
