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
using System.Windows.Input;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Windows.Media.Imaging;
using System.Windows.Controls;

namespace MenuAdvConfigurationDemo
{
    public class ViewModel : NotificationObject
    {
       
        private ObservableCollection<string> eventlog = new ObservableCollection<string>();
        private ObservableCollection<Model> menuModel;

        public ObservableCollection<string> EventLog
        {
            get { return eventlog; }
            set { eventlog = value; }
        }



        public void PropertyChangedHandler(object param)
        {
           
            EventLog.Add("Selection Changed:"+ param.ToString());
        }


        public ViewModel()
        {
           
            Image image = new Image() { Source = new BitmapImage(new Uri("/MenuAdvConfigurationDemo;component/Images/Save16.png", UriKind.RelativeOrAbsolute)) };
            menuModel = new ObservableCollection<Model>();
           
            Model menuModel0 = new Model() { MenuItemName = "File" };
            menuModel0.MenuItems.Add(new Model() { MenuItemName = "New", MenuItemClicked =  new DelegateCommand<object>(PropertyChangedHandler) });
            menuModel0.MenuItems.Add(new Model() { MenuItemName = "Open", MenuItemClicked =  new DelegateCommand<object>(PropertyChangedHandler)});
            menuModel0.MenuItems.Add(new Model() { MenuItemName = "Close", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});
            menuModel0.MenuItems.Add(new Model() { MenuItemName = "Save", ImagePath = image, MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});
            menuModel0.MenuItems.Add(new Model() { MenuItemName = "Advanced Save Options...", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
            menuModel0.MenuItems.Add(new Model() { MenuItemName = "Print", GestureText = "Ctrl + P", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
            menuModel0.MenuItems.Add(new Model() { MenuItemName = "Exit", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});

            Model menuModel1 = new Model() { MenuItemName = "Edit" };
            menuModel1.MenuItems.Add(new Model() { MenuItemName = "Undo", GestureText = "Ctrl + Z", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
            menuModel1.MenuItems.Add(new Model() { MenuItemName = "Redo", GestureText = "Ctrl + Y", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
            menuModel1.MenuItems.Add(new Model() { MenuItemName = "Cut", ImagePath = new Image() { Source = new BitmapImage(new Uri("/MenuAdvConfigurationDemo;component/Images/CutHS.png", UriKind.RelativeOrAbsolute)) }, GestureText = "Ctrl + X", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});
            menuModel1.MenuItems.Add(new Model() { MenuItemName = "Copy", ImagePath = new Image() { Source = new BitmapImage(new Uri("/MenuAdvConfigurationDemo;component/Images/CopyHS.png", UriKind.RelativeOrAbsolute)) }, GestureText = "Ctrl + C", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
            menuModel1.MenuItems.Add(new Model() { MenuItemName = "Paste", ImagePath = new Image() { Source = new BitmapImage(new Uri("/MenuAdvConfigurationDemo;component/Images/PasteHS.png", UriKind.RelativeOrAbsolute)) }, GestureText = "Ctrl + V", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});
            menuModel1.MenuItems.Add(new Model() { MenuItemName = "Check Spelling", ImagePath = new Image() { Source = new BitmapImage(new Uri("/MenuAdvConfigurationDemo;component/Images/CheckSpellingHS.png", UriKind.RelativeOrAbsolute)) }, MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });

            Model menuModel2 = new Model() { MenuItemName = "View" };
            Model menuModel21 = new Model() { MenuItemName = "Find Results", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) };
            menuModel21.MenuItems.Add(new Model() { MenuItemName = "Find Results 1", CheckIconType = CheckIconType.RadioButton, IsCheckable = true, MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
            menuModel21.MenuItems.Add(new Model() { MenuItemName = "Find Results 2", IsCheckable = true, MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
            menuModel21.MenuItems.Add(new Model() { MenuItemName = "Find Symbol Results", IsCheckable = true, MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });

            Model menuModel22 = new Model() { MenuItemName = "Other Windows", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)};
                menuModel22.MenuItems.Add(new Model() { MenuItemName = "Immediate Window", IsCheckable = true, MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});
                menuModel22.MenuItems.Add(new Model() { MenuItemName = "Output", IsCheckable = true, MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
                menuModel22.MenuItems.Add(new Model() { MenuItemName = "Command Window", IsCheckable = true, MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
                menuModel22.MenuItems.Add(new Model() { MenuItemName = "Macro Explorer", IsCheckable = true, MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
                menuModel22.MenuItems.Add(new Model() { MenuItemName = "Solution Explorer", IsCheckable = true, MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
            
                menuModel2.MenuItems.Add(menuModel21);
                menuModel2.MenuItems.Add(menuModel22);

            Model menuModel4 = new Model() { MenuItemName = "Project" };
                menuModel4.MenuItems.Add(new Model() { MenuItemName = "Add Window..", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
                menuModel4.MenuItems.Add(new Model() { MenuItemName = "Add User Control..", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});
                menuModel4.MenuItems.Add(new Model() { MenuItemName = "Add Resource Dictionary..", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});
                menuModel4.MenuItems.Add(new Model() { MenuItemName = "Add Page..", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});
                menuModel4.MenuItems.Add(new Model() { MenuItemName = "Add Class..", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});

            Model menuModel5 = new Model() { MenuItemName = "Build" };
                menuModel5.MenuItems.Add(new Model() { MenuItemName = "Build Solution", GestureText = "F6", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});
                menuModel5.MenuItems.Add(new Model() { MenuItemName = "ReBuild Solution", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});
                menuModel5.MenuItems.Add(new Model() { MenuItemName = "Clean Solution", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});
                menuModel5.MenuItems.Add(new Model() { MenuItemName = "Batch Build...", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});
                menuModel5.MenuItems.Add(new Model() { MenuItemName = "Configuration Manager...", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});

            Model menuModel6 = new Model() { MenuItemName = "Debug" };
                Model menuModel23 = new Model() { MenuItemName = "Windows", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) };
                menuModel23.MenuItems.Add(new Model() { MenuItemName = "BreakPoints", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
                menuModel23.MenuItems.Add(new Model() { MenuItemName = "Output", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
                menuModel23.MenuItems.Add(new Model() { MenuItemName = "Immediate", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler)});
                menuModel6.MenuItems.Add(menuModel23);

                menuModel6.MenuItems.Add(new Model() { MenuItemName = "Start Debugging", GestureText = "F6", ImagePath = new Image() { Source = new BitmapImage(new Uri("/MenuAdvConfigurationDemo;component/Images/FormRunHS.png", UriKind.RelativeOrAbsolute)) }, MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
                menuModel6.MenuItems.Add(new Model() { MenuItemName = "Start Without Debugging", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
                menuModel6.MenuItems.Add(new Model() { MenuItemName = "Attach to Process...", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
                menuModel6.MenuItems.Add(new Model() { MenuItemName = "Excpetions", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });

            Model menuModel7 = new Model() { MenuItemName = "Help" };
            menuModel7.MenuItems.Add(new Model() { MenuItemName = "About", MenuItemClicked = new DelegateCommand<object>(PropertyChangedHandler) });
            menuModel7.MenuItems.Add(new Model() { MenuItemName = "View Help", GestureText = "F6",MenuItemClicked =  new DelegateCommand<object>(PropertyChangedHandler), ImagePath = new Image() { Source = new BitmapImage(new Uri("/MenuAdvConfigurationDemo;component/Images/Help.png", UriKind.RelativeOrAbsolute)) } });
            menuModel7.MenuItems.Add(new Model() { MenuItemName = "About Syncfusion Essential Studio",MenuItemClicked =  new DelegateCommand<object>(PropertyChangedHandler), ImagePath = new Image() { Source = new BitmapImage(new Uri("/MenuAdvConfigurationDemo;component/App.ico", UriKind.RelativeOrAbsolute)) } });

            menuModel.Add(menuModel0);
            menuModel.Add(menuModel1);
            menuModel.Add(menuModel2);         
            menuModel.Add(menuModel4);
            menuModel.Add(menuModel5);
            menuModel.Add(menuModel6);
            MenuModel.Add(menuModel7);
        }

        public ObservableCollection<Model> MenuModel
        {
            get
            {
                return menuModel;
            }
            set
            {
                menuModel = value;
            }
        }
    }
}
