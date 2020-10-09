#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using Syncfusion.Windows.Shared;
using System.Windows.Input;
using System.Windows;
using System.Windows.Markup;

namespace syncfusion.navigationdemos.wpf
{
    /// <summary>
    /// Represents the view model class of MenuAdvControl.
    /// </summary>
    public class MenuGettingStartedViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains a collection of string for displaying events.
        /// </summary>
        private ObservableCollection<string> eventlog = new ObservableCollection<string>();
        /// <summary>
        /// Maintains a collection of model class.
        /// </summary>
        private ObservableCollection<GettingStartedModel> menuModel;

        /// <summary>
        /// Maintains the command for menu items.
        /// </summary>
        private ICommand itemCommand;

        /// <summary>
        /// Maintains the command for help.
        /// </summary>
        private ICommand helpCommand;

        /// <summary>
        /// Maintains the command for about.
        /// </summary>
        private ICommand aboutCommand;

        /// <summary>
        /// Maintains the command for essential studio.
        /// </summary>
        private ICommand essentialStudioCommand;

        /// <summary>
        /// Holds the required resouces for Icon.
        /// </summary>
        private ResourceDictionary CommonResourceDictionary { get; set; }

        /// <summary>
        /// Initializes  the instance of the <see cref="MenuGettingStartedViewModel"/>class.
        /// </summary>
        public MenuGettingStartedViewModel()
        {
            menuModel = new ObservableCollection<GettingStartedModel>();
            itemCommand = new DelegateCommand<object>(PropertyChangedHandler);
            helpCommand = new DelegateCommand<object>(ExecuteHelpCommand);
            aboutCommand = new DelegateCommand<object>(ExecuteAboutCommand);
            CommonResourceDictionary = new ResourceDictionary() { Source = new Uri("/syncfusion.navigationdemos.wpf;component/Assets/Menu/Icon.xaml", UriKind.RelativeOrAbsolute) };
            essentialStudioCommand = new DelegateCommand<object>(ExecuteEssentialStudioCommand);

            GettingStartedModel menuModel0 = new GettingStartedModel() { MenuItemName = "File" };
            menuModel0.MenuItems.Add(new GettingStartedModel() { MenuItemName = "New", MenuItemClicked = ItemCommand, ImagePath = CommonResourceDictionary["New"] as object });
            menuModel0.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Open", MenuItemClicked = ItemCommand, ImagePath = CommonResourceDictionary["Open"] as object });
            menuModel0.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Close", MenuItemClicked = ItemCommand });
            menuModel0.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Save", MenuItemClicked = ItemCommand, ImagePath = CommonResourceDictionary["Save"] as object });
            menuModel0.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Advanced Save Options", MenuItemClicked = ItemCommand, ImagePath = CommonResourceDictionary["AdvSave"] as object });
            menuModel0.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Print", GestureText = "Ctrl + P", MenuItemClicked = ItemCommand, ImagePath = CommonResourceDictionary["Print"] as object });
            menuModel0.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Exit", MenuItemClicked = ItemCommand, ImagePath = CommonResourceDictionary["Delete"] as object });

            GettingStartedModel menuModel1 = new GettingStartedModel() { MenuItemName = "Edit" };
            menuModel1.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Undo", GestureText = "Ctrl + Z", MenuItemClicked = ItemCommand, ImagePath = CommonResourceDictionary["Undo"] as object });
            menuModel1.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Redo", GestureText = "Ctrl + Y", MenuItemClicked = ItemCommand, ImagePath = CommonResourceDictionary["Redo"] as object });
            menuModel1.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Cut", GestureText = "Ctrl + X", MenuItemClicked = ItemCommand, ImagePath = CommonResourceDictionary["Cut"] as object });
            menuModel1.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Copy", GestureText = "Ctrl + C", MenuItemClicked = ItemCommand, ImagePath = CommonResourceDictionary["Copy"] as object });
            menuModel1.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Paste", GestureText = "Ctrl + V", MenuItemClicked = ItemCommand, ImagePath = CommonResourceDictionary["Paste"] as object });
            menuModel1.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Check Spelling", MenuItemClicked = ItemCommand, ImagePath = CommonResourceDictionary["SpellChecker"] as object });

            GettingStartedModel menuModel2 = new GettingStartedModel() { MenuItemName = "View" };
            GettingStartedModel menuModel21 = new GettingStartedModel() { MenuItemName = "Find Results", MenuItemClicked = ItemCommand };
            menuModel21.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Find Results 1", CheckIconType = CheckIconType.RadioButton, IsCheckable = true, MenuItemClicked = ItemCommand });
            menuModel21.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Find Results 2", IsCheckable = true, MenuItemClicked = ItemCommand });
            menuModel21.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Find Symbol Results", IsCheckable = true, MenuItemClicked = ItemCommand });

            GettingStartedModel menuModel22 = new GettingStartedModel() { MenuItemName = "Other Windows", MenuItemClicked = ItemCommand };
            menuModel22.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Immediate Window", IsCheckable = true, MenuItemClicked = ItemCommand });
            menuModel22.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Output", IsCheckable = true, MenuItemClicked = ItemCommand });
            menuModel22.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Command Window", IsCheckable = true, MenuItemClicked = ItemCommand });
            menuModel22.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Macro Explorer", IsCheckable = true, MenuItemClicked = ItemCommand });
            menuModel22.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Solution Explorer", IsCheckable = true, MenuItemClicked = ItemCommand });
            menuModel2.MenuItems.Add(menuModel21);
            menuModel2.MenuItems.Add(menuModel22);

            GettingStartedModel menuModel4 = new GettingStartedModel() { MenuItemName = "Project" };
            menuModel4.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Add Window..", MenuItemClicked = ItemCommand });
            menuModel4.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Add User Control..", MenuItemClicked = ItemCommand });
            menuModel4.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Add Resource Dictionary..", MenuItemClicked = ItemCommand });
            menuModel4.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Add Page..", MenuItemClicked = ItemCommand });
            menuModel4.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Add Class..", MenuItemClicked = ItemCommand });

            GettingStartedModel menuModel5 = new GettingStartedModel() { MenuItemName = "Build" };
            menuModel5.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Build Solution", GestureText = "F6", MenuItemClicked = ItemCommand });
            menuModel5.MenuItems.Add(new GettingStartedModel() { MenuItemName = "ReBuild Solution", MenuItemClicked = ItemCommand });
            menuModel5.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Clean Solution", MenuItemClicked = ItemCommand });
            menuModel5.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Batch Build...", MenuItemClicked = ItemCommand });
            menuModel5.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Configuration Manager...", MenuItemClicked = ItemCommand });

            GettingStartedModel menuModel6 = new GettingStartedModel() { MenuItemName = "Debug" };
            GettingStartedModel menuModel23 = new GettingStartedModel() { MenuItemName = "Windows", MenuItemClicked = ItemCommand };
            menuModel23.MenuItems.Add(new GettingStartedModel() { MenuItemName = "BreakPoints", MenuItemClicked = ItemCommand });
            menuModel23.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Output", MenuItemClicked = ItemCommand });
            menuModel23.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Immediate", MenuItemClicked = ItemCommand });
            menuModel6.MenuItems.Add(menuModel23);

            menuModel6.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Start Debugging", GestureText = "F6", MenuItemClicked = ItemCommand, ImagePath = CommonResourceDictionary["Start"] as object });
            menuModel6.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Start Without Debugging", MenuItemClicked = ItemCommand });
            menuModel6.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Attach to Process...", MenuItemClicked = ItemCommand });
            menuModel6.MenuItems.Add(new GettingStartedModel() { MenuItemName = "Excpetions", MenuItemClicked = ItemCommand });

            GettingStartedModel menuModel7 = new GettingStartedModel() { MenuItemName = "Help" };
            menuModel7.MenuItems.Add(new GettingStartedModel() { MenuItemName = "About", MenuItemClicked = AboutCommand });
            menuModel7.MenuItems.Add(new GettingStartedModel() { MenuItemName = "View Help", GestureText = "F6", MenuItemClicked = HelpCommand, ImagePath = CommonResourceDictionary["Help"] as object });
            menuModel7.MenuItems.Add(new GettingStartedModel() { MenuItemName = "About Syncfusion Essential Studio", MenuItemClicked = EssentialStudioCommand, ImagePath = new Image() { Source = new BitmapImage(new Uri("/syncfusion.navigationdemos.wpf;component/Assets/Menu/syncfusion.png", UriKind.RelativeOrAbsolute)) } });

            menuModel.Add(menuModel0);
            menuModel.Add(menuModel1);
            menuModel.Add(menuModel2);
            menuModel.Add(menuModel4);
            menuModel.Add(menuModel5);
            menuModel.Add(menuModel6);
            MenuModel.Add(menuModel7);
        }

        /// <summary>
        /// Gets or sets the command for help  <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand HelpCommand
        {
            get
            {
                return helpCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for essential studio  <see cref="GettingStartedModel"/> class.
        /// </summary>
        public ICommand EssentialStudioCommand
        {
            get
            {
                return essentialStudioCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for about <see cref="GettingStartedModel"/> class.
        /// </summary>
        public ICommand AboutCommand
        {
            get
            {
                return aboutCommand;
            }
        }

        /// <summary>
        /// Gets or seta the command for menu items <see cref="GettingStartedModel"/>class.
        /// </summary>
        public ICommand ItemCommand
        {
            get
            {
                return itemCommand;
            }
        }

        /// <summary>
        /// Gets or sets the collection of string to display events  <see cref="GettingStartedModel"/>class.
        /// </summary>
        public ObservableCollection<string> EventLog
        {
            get
            {
                return eventlog;
            }
            set
            {
                eventlog = value;
                RaisePropertyChanged("EventLog");
            }
        }

        /// <summary>
        /// Gets or sets the collection of <see cref="GettingStartedModel"/>class.
        /// </summary>
        public ObservableCollection<GettingStartedModel> MenuModel
        {
            get
            {
                return menuModel;
            }
            set
            {
                menuModel = value;
                RaisePropertyChanged("MenuModel");
            }
        }

        /// <summary>
        /// Method to execute menu item clicked.
        /// </summary>
        /// <param name="param">Specifies the menu item</param>
        public void PropertyChangedHandler(object param)
        {
            EventLog.Add("Selection Changed:" + param.ToString());
        }

        /// <summary>
        /// Method used to execute the helpCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private void ExecuteHelpCommand(object parameter)
        {
            if (MessageBox.Show("Are you sure to visit the page ?", "Help", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/welcome-to-syncfusion-essential-wpf");
            }
        }

        /// <summary>
        /// method used to execute aboutCommand
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private void ExecuteAboutCommand(object parameter)
        {
            if (MessageBox.Show("Are you sure to visit the page ?", "About", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start("https://www.syncfusion.com/company/about-us");
            }
        }

        /// <summary>
        /// method used to execute essentialstudioCommand
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private void ExecuteEssentialStudioCommand(object parameter)
        {
            if (MessageBox.Show("Are you sure to visit the page ?", "Essential Studio", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start("https://www.syncfusion.com/products/essential-studio");
            }
        }
    }
}
