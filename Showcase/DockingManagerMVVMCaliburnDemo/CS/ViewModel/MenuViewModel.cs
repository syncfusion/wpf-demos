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
using Caliburn.Micro;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows;
using Syncfusion.Windows.Tools.Controls;
using System.Diagnostics;

namespace DockingManagerMVVMCaliburnMicro
{
    [Export(typeof(MenuViewModel))]
    public class MenuViewModel : PropertyChangedBase
    {
        string[] ThemeArray = new string[11];
        string[] ViewArray = new string[9];

        public MenuViewModel()
        {
            GenerateFileMenuItemCollection();
            GenerateEditMenuItemCollection();
            GenerateViewMenuItemCollection();
            GenerateProjectMenuItemCollection();
            GenerateBuildMenuItemCollection();
            GenerateDebugMenuItemCollection();
            GenerateDataMenuItemCollection();
            GenerateToolsMenuItemCollection();
            GenerateTestMenuItemCollection();
            GenerateThemeMenuItemCollection();
            GenerateHelpMenuItemCollection();
            GenerateWindowMenuItemCollection();
            GenerateTestMenuItemCollection();
            GenerateMainMenuCollection();
        }

        public ShellViewModel ShellViewModel { get; set; }

        public DockingAdapterViewModel DockingAdapterViewModel { get; set; }

        private ObservableCollection<MenuModel> menu = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> Menu
        {
            get
            {
                return menu;
            }
            set
            {
                menu = value;
            }
        }

        private ObservableCollection<MenuModel> filemenuitemcolletion = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> FileMenuItemCollection
        {
            get
            {
                return filemenuitemcolletion;
            }
            set
            {
                filemenuitemcolletion = value;
            }
        }

        private ObservableCollection<MenuModel> editmenuitemcolletion = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> EditMenuItemCollection
        {
            get
            {
                return editmenuitemcolletion;
            }
            set
            {
                editmenuitemcolletion = value;
            }
        }

        private ObservableCollection<MenuModel> viewmenuitemcolletion = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> ViewMenuItemCollection
        {
            get
            {
                return viewmenuitemcolletion;
            }
            set
            {
                viewmenuitemcolletion = value;
            }
        }

        private ObservableCollection<MenuModel> projectmenuitemcolletion = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> ProjectMenuItemCollection
        {
            get
            {
                return projectmenuitemcolletion;
            }
            set
            {
                projectmenuitemcolletion = value;
            }
        }

        private ObservableCollection<MenuModel> buildmenuitemcolletion = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> BuildMenuItemCollection
        {
            get
            {
                return buildmenuitemcolletion;
            }
            set
            {
                buildmenuitemcolletion = value;
            }
        }

        private ObservableCollection<MenuModel> debugmenuitemcolletion = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> DebugMenuItemCollection
        {
            get
            {
                return debugmenuitemcolletion;
            }
            set
            {
                debugmenuitemcolletion = value;
            }
        }

        private ObservableCollection<MenuModel> datamenuitemcolletion = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> DataMenuItemCollection
        {
            get
            {
                return datamenuitemcolletion;
            }
            set
            {
                datamenuitemcolletion = value;
            }
        }

        private ObservableCollection<MenuModel> toolsmenuitemcolletion = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> ToolsMenuItemCollection
        {
            get
            {
                return toolsmenuitemcolletion;
            }
            set
            {
                toolsmenuitemcolletion = value;
            }
        }

        private ObservableCollection<MenuModel> thememenuitemcolletion = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> ThemeMenuItemCollection
        {
            get
            {
                return thememenuitemcolletion;
            }
            set
            {
                thememenuitemcolletion = value;
            }
        }

        private ObservableCollection<MenuModel> helpmenuitemcolletion = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> HelpMenuItemCollection
        {
            get
            {
                return helpmenuitemcolletion;
            }
            set
            {
                helpmenuitemcolletion = value;
            }
        }

        private ObservableCollection<MenuModel> windowmenuitemcolletion = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> WindowMenuItemCollection
        {
            get
            {
                return windowmenuitemcolletion;
            }
            set
            {
                windowmenuitemcolletion = value;
            }
        }

        private ObservableCollection<MenuModel> testmenuitemcolletion = new ObservableCollection<MenuModel>();

        public ObservableCollection<MenuModel> TestMenuItemCollection
        {
            get
            {
                return testmenuitemcolletion;
            }
            set
            {
                testmenuitemcolletion = value;
            }
        }

        private void GenerateFileMenuItemCollection()
        {
            FileMenuItemCollection = new ObservableCollection<MenuModel>();
            ObservableCollection<MenuModel> NewSubMenuModel = new ObservableCollection<MenuModel>();
            NewSubMenuModel.Add(new MenuModel() { Header = "Project" });
            NewSubMenuModel.Add(new MenuModel() { Header = "File" });
            NewSubMenuModel.Add(new MenuModel() { Header = "Team Project" });
            NewSubMenuModel.Add(new MenuModel() { Header = "Website" });
            FileMenuItemCollection.Add(new MenuModel() { Header = "New", SubMenuItemCollection = NewSubMenuModel });
            ObservableCollection<MenuModel> OpenSubMenuModel = new ObservableCollection<MenuModel>();
            OpenSubMenuModel.Add(new MenuModel() { Header = "Project" });
            OpenSubMenuModel.Add(new MenuModel() { Header = "File" });
            OpenSubMenuModel.Add(new MenuModel() { Header = "Team Project" });
            OpenSubMenuModel.Add(new MenuModel() { Header = "Website" });
            FileMenuItemCollection.Add(new MenuModel() { Header = "Open", SubMenuItemCollection = OpenSubMenuModel });
            ObservableCollection<MenuModel> AddSubMenuModel = new ObservableCollection<MenuModel>();
            AddSubMenuModel.Add(new MenuModel() { Header = "New Project" });
            AddSubMenuModel.Add(new MenuModel() { Header = "New Website" });
            AddSubMenuModel.Add(new MenuModel() { Header = "Existing Project" });
            AddSubMenuModel.Add(new MenuModel() { Header = "Existing Website" });
            FileMenuItemCollection.Add(new MenuModel() { Header = "Add", SubMenuItemCollection = AddSubMenuModel });
            FileMenuItemCollection.Add(new MenuModel() { Header = "Close" });
            FileMenuItemCollection.Add(new MenuModel() { Header = "Close Solution" });
            FileMenuItemCollection.Add(new MenuModel() { Header = "Exit" });
        }

        private void GenerateEditMenuItemCollection()
        {
            EditMenuItemCollection = new ObservableCollection<MenuModel>();
            EditMenuItemCollection.Add(new MenuModel() { Header = "UnDo" });
            EditMenuItemCollection.Add(new MenuModel() { Header = "ReDo" });
            EditMenuItemCollection.Add(new MenuModel() { Header = "Cut" });
            EditMenuItemCollection.Add(new MenuModel() { Header = "Copy" });
            EditMenuItemCollection.Add(new MenuModel() { Header = "Paste" });
            EditMenuItemCollection.Add(new MenuModel() { Header = "Delete" });
        }

        private void GenerateViewMenuItemCollection()
        {
            ViewMenuItemCollection = new ObservableCollection<MenuModel>();
            ViewMenuItemCollection.Add(new MenuModel() { Header = "Solution Explorer" });
            ViewMenuItemCollection.Add(new MenuModel() { Header = "Properties" });
            ViewMenuItemCollection.Add(new MenuModel() { Header = "Class View" });
            ViewMenuItemCollection.Add(new MenuModel() { Header = "Error List" });
            ViewMenuItemCollection.Add(new MenuModel() { Header = "Output" });
            ViewMenuItemCollection.Add(new MenuModel() { Header = "Find Results 1" });
            //ViewMenuItemCollection.Add(new MenuModel() { Header = "Find Results 2" });
            ViewMenuItemCollection.Add(new MenuModel() { Header = "Find Symbol Results" });
            ViewMenuItemCollection.Add(new MenuModel() { Header = "Toolbox" });
            for (int i = 0; i < ViewMenuItemCollection.Count; i++)
            {
                ViewArray[i] = ViewMenuItemCollection[i].Header;
            }
        }

        private void GenerateProjectMenuItemCollection()
        {
            ProjectMenuItemCollection = new ObservableCollection<MenuModel>();
            ProjectMenuItemCollection.Add(new MenuModel() { Header = "Add Class" });
            ProjectMenuItemCollection.Add(new MenuModel() { Header = "Add Resource Dictionary" });
            ProjectMenuItemCollection.Add(new MenuModel() { Header = "Add UserControl" });
            ProjectMenuItemCollection.Add(new MenuModel() { Header = "Add New Item" });
            ProjectMenuItemCollection.Add(new MenuModel() { Header = "Add Existing Item" });
        }

        private void GenerateBuildMenuItemCollection()
        {
            BuildMenuItemCollection = new ObservableCollection<MenuModel>();
            BuildMenuItemCollection.Add(new MenuModel() { Header = "Build Solution" });
            BuildMenuItemCollection.Add(new MenuModel() { Header = "Clean Solution" });
            BuildMenuItemCollection.Add(new MenuModel() { Header = "Re-Build Solution" });
        }

        private void GenerateDebugMenuItemCollection()
        {
            DebugMenuItemCollection = new ObservableCollection<MenuModel>();
            DebugMenuItemCollection.Add(new MenuModel() { Header = "Start Debugging" });
            DebugMenuItemCollection.Add(new MenuModel() { Header = "Start WithOut Debugging" });
            DebugMenuItemCollection.Add(new MenuModel() { Header = "Exceptions" });
            DebugMenuItemCollection.Add(new MenuModel() { Header = "Step Into" });
            DebugMenuItemCollection.Add(new MenuModel() { Header = "Step Over" });
        }

        private void GenerateDataMenuItemCollection()
        {
            DataMenuItemCollection = new ObservableCollection<MenuModel>();
            DataMenuItemCollection.Add(new MenuModel() { Header = "Show DataSources" });
            DataMenuItemCollection.Add(new MenuModel() { Header = "Add New DataSource" });
            DataMenuItemCollection.Add(new MenuModel() { Header = "Schema View" });
        }

        private void GenerateToolsMenuItemCollection()
        {
            ToolsMenuItemCollection = new ObservableCollection<MenuModel>();
            ToolsMenuItemCollection.Add(new MenuModel() { Header = "Attach To Process" });
            ToolsMenuItemCollection.Add(new MenuModel() { Header = "Connect To DataBase" });
            ToolsMenuItemCollection.Add(new MenuModel() { Header = "Connect To Server" });
            ToolsMenuItemCollection.Add(new MenuModel() { Header = "Customize" });
            ToolsMenuItemCollection.Add(new MenuModel() { Header = "Options" });
        }

        private void GenerateThemeMenuItemCollection()
        {
            ThemeMenuItemCollection = new ObservableCollection<MenuModel>();
            ThemeMenuItemCollection.Add(new MenuModel() { Header = "Blend" });
            ThemeMenuItemCollection.Add(new MenuModel() { Header = "Default" });
            ThemeMenuItemCollection.Add(new MenuModel() { Header = "Metro" });
            ThemeMenuItemCollection.Add(new MenuModel() { Header = "Office2007Blue" });
            ThemeMenuItemCollection.Add(new MenuModel() { Header = "Office2007Black" });
            ThemeMenuItemCollection.Add(new MenuModel() { Header = "Office2007Silver" });
            ThemeMenuItemCollection.Add(new MenuModel() { Header = "Office2010Blue" });
            ThemeMenuItemCollection.Add(new MenuModel() { Header = "Office2010Black" });
            ThemeMenuItemCollection.Add(new MenuModel() { Header = "Office2010Silver" });
            ThemeMenuItemCollection.Add(new MenuModel() { Header = "Transparent" });
            ThemeMenuItemCollection.Add(new MenuModel() { Header = "VS2010"});
            for (int i = 0; i < ThemeMenuItemCollection.Count; i++)
            {
                ThemeArray[i] = ThemeMenuItemCollection[i].Header;
            }
        }

        private void GenerateHelpMenuItemCollection()
        {
            HelpMenuItemCollection = new ObservableCollection<MenuModel>();
            HelpMenuItemCollection.Add(new MenuModel() { Header = "Help" });
            HelpMenuItemCollection.Add(new MenuModel() { Header = "MSDN Forums" });
            HelpMenuItemCollection.Add(new MenuModel() { Header = "Feedback" });
            HelpMenuItemCollection.Add(new MenuModel() { Header = "About Visual Studio" });
        }

        private void GenerateWindowMenuItemCollection()
        {
            WindowMenuItemCollection = new ObservableCollection<MenuModel>();
            WindowMenuItemCollection.Add(new MenuModel() { Header = "Dock" });
            WindowMenuItemCollection.Add(new MenuModel() { Header = "Document" });
            WindowMenuItemCollection.Add(new MenuModel() { Header = "Float" });
            WindowMenuItemCollection.Add(new MenuModel() { Header = "AutoHidden" });
            WindowMenuItemCollection.Add(new MenuModel() { Header = "Hidden" });
        }

        private void GenerateTestMenuItemCollection()
        {
            TestMenuItemCollection = new ObservableCollection<MenuModel>();
            TestMenuItemCollection.Add(new MenuModel() { Header = "New Test" });
            TestMenuItemCollection.Add(new MenuModel() { Header = "Load MetaDate File" });
            TestMenuItemCollection.Add(new MenuModel() { Header = "Create New Test List" });
            TestMenuItemCollection.Add(new MenuModel() { Header = "Run" });
            TestMenuItemCollection.Add(new MenuModel() { Header = "Debug" });
        }

        private void GenerateMainMenuCollection()
        {
            Menu = new ObservableCollection<MenuModel>();

            MenuModel FileMenuModel = new MenuModel() { Header = "File", MenuItemCollection = FileMenuItemCollection };
            MenuModel EditMenuModel = new MenuModel() { Header = "Edit", MenuItemCollection = EditMenuItemCollection };
            MenuModel ViewMenuModel = new MenuModel() { Header = "View", MenuItemCollection = ViewMenuItemCollection };
            MenuModel ThemeMenuModel = new MenuModel() { Header = "Theme", MenuItemCollection = ThemeMenuItemCollection };
            MenuModel ProjectMenuModel = new MenuModel() { Header = "Project", MenuItemCollection = ProjectMenuItemCollection };
            MenuModel BuildMenuModel = new MenuModel() { Header = "Build", MenuItemCollection = BuildMenuItemCollection };
            MenuModel DebugMenuModel = new MenuModel() { Header = "Debug", MenuItemCollection = DebugMenuItemCollection };
            MenuModel DataMenuModel = new MenuModel() { Header = "Data", MenuItemCollection = DataMenuItemCollection };
            MenuModel ToolsMenuModel = new MenuModel() { Header = "Tools", MenuItemCollection = ToolsMenuItemCollection };
            MenuModel TestMenuModel = new MenuModel() { Header = "Test", MenuItemCollection = TestMenuItemCollection };
            MenuModel WindowMenuModel = new MenuModel() { Header = "Window", MenuItemCollection = WindowMenuItemCollection };
            MenuModel HelpMenuModel = new MenuModel() { Header = "Help", MenuItemCollection = HelpMenuItemCollection };


            Menu.Add(FileMenuModel);
            Menu.Add(EditMenuModel);
            Menu.Add(ViewMenuModel);
            Menu.Add(ThemeMenuModel);
            Menu.Add(ProjectMenuModel);
            Menu.Add(BuildMenuModel);
            Menu.Add(DebugMenuModel);
            Menu.Add(DataMenuModel);
            Menu.Add(ToolsMenuModel);
            Menu.Add(TestMenuModel);
            Menu.Add(WindowMenuModel);
            Menu.Add(HelpMenuModel);
        }

        private string visualstyle;

        public string VisualStyle
        {
            get
            {
                return visualstyle;
            }
            set
            {
                UpdateTheme(value);
                visualstyle = value;
            }
        }

        private void UpdateTheme(string Style)
        {
            foreach (MenuModel model in ThemeMenuItemCollection)
            {
                if (model.Header == Style)
                {
                    model.IsChecked = true;
                    break;
                }
            }
        }

        public void MenuClick(MenuModel datamodel)
        {
            if (datamodel != null)
            {
                if (ThemeArray.Contains(datamodel.Header))
                {
                    foreach (MenuModel model in ThemeMenuItemCollection)
                    {
                        if (model != datamodel)
                        {
                            if (model.IsChecked)
                            {
                                model.IsChecked = false;
                                break;
                            }
                        }
                    }
                    datamodel.IsChecked = true;
                    ShellViewModel.ShellVisualStyle = datamodel.Header;
                }
                if (ViewArray.Contains(datamodel.Header))
                {
                    foreach (FrameworkElement element in DockingAdapterViewModel.AdapterDockingManager.Children)
                    {
                        if (DockingManager.GetHeader(element) == datamodel.Header && DockingManager.GetState(element) == DockState.Hidden)
                        {
                            DockingManager.SetState(element, DockState.Dock);
                            break;
                        }
                        else if (DockingManager.GetHeader(element) == datamodel.Header && DockingAdapterViewModel.AdapterDockingManager.ActiveWindow != element)
                        {
                            if (DockingManager.GetState(element) == DockState.AutoHidden)
                            {
                                DockingAdapterViewModel.AdapterDockingManager.ActivateWindow(element.Name);
                                break;
                            }
                            else
                            {
                                DockingAdapterViewModel.AdapterDockingManager.ActivateWindow(element.Name);
                                break;
                            }
                        }
                    }
                }
            }
        }
    }
}
