#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using System;
using System.Collections.ObjectModel;
using Syncfusion.Windows.Shared;
using System.Windows.Media.Imaging;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace MenuAdvConfigurationDemo
{
    /// <summary>
    /// Represents the view model class of MenuAdvControl
    /// </summary>
    public class ViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains a collection of string for displaying events.
        /// </summary>
        private ObservableCollection<string> eventlog = new ObservableCollection<string>();
        /// <summary>
        /// Maintains a collection of model class.
        /// </summary>
        private ObservableCollection<Model> menuModel;

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
        /// Maintains the richTextBox properties.
        /// </summary>
        private static RichTextBox richTextBox = null;

        /// <summary>
        /// Initializes  the instance of the <see cref="ViewModel"/>class.
        /// </summary>
        public ViewModel()
        {
            menuModel = new ObservableCollection<Model>();
            itemCommand = new DelegateCommand<object>(PropertyChangedHandler);
            helpCommand = new DelegateCommand<object>(ExecuteHelpCommand);
            aboutCommand = new DelegateCommand<object>(ExecuteAboutCommand);
            essentialStudioCommand = new DelegateCommand<object>(ExecuteEssentialStudioCommand);

            Model menuModel0 = new Model() { MenuItemName = "File" };
            menuModel0.MenuItems.Add(new Model() { MenuItemName = "New", MenuItemClickCommand = ItemCommand,ImagePath= (Image)XamlReader.Parse(@" <Image xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><Image.Source><DrawingImage><DrawingImage.Drawing><DrawingGroup><GeometryDrawing Geometry='M0,0 L5.9999999,0 11,5 11,15 0,15 z' Brush='White'  /><GeometryDrawing Geometry='M7,1.7070007 L7,5 10.292999,5 z M1,1 L1,15 11,15 11,6 6,6 6,1 z M0,0 L6.7070007,0 12,5.2929993 12,16 0,16 z' Brush='#FF3A3A38' /></DrawingGroup></DrawingImage.Drawing></DrawingImage></Image.Source></Image>") });
            menuModel0.MenuItems.Add(new Model() { MenuItemName = "Open", MenuItemClickCommand = ItemCommand,ImagePath=(Image)XamlReader.Parse(@" <Image xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><Image.Source><DrawingImage><DrawingImage.Drawing><DrawingGroup><GeometryDrawing Brush='White' Geometry='M0,0 L5,0 6,1 12,1 12,3.4999998 11.499065,3.9999996 14.716998,3.9999996 11.92699,10.999 4.1853847,10.984859 0,10.982999 z' /><GeometryDrawing Brush='#FF3A3A38' Geometry='M5.162991,5.0009986 L1.7839907,10.979999 4.3081884,10.984653 5.0009999,10.984999 5.0009999,10.98593 12.088991,10.999 14.480014,5.0009986 z M0,0 L5.7069998,0 6.7069998,1 13,1 13,3.9999998 12,3.9999998 12,1.9999998 6.2930002,1.9999998 5.2930002,1 0.99999994,1 0.99999994,10.335325 4.5790062,4.0009986 15.954991,4.0009986 12.765994,12.000998 4.552258,11.98482 0,11.982999 z' /></DrawingGroup></DrawingImage.Drawing></DrawingImage></Image.Source></Image>") });
            menuModel0.MenuItems.Add(new Model() { MenuItemName = "Close", MenuItemClickCommand = ItemCommand });
            menuModel0.MenuItems.Add(new Model() { MenuItemName = "Save", MenuItemClickCommand = ItemCommand,ImagePath=(Image)XamlReader.Parse(@"<Image  xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><Image.Source><DrawingImage><DrawingImage.Drawing><GeometryDrawing Brush='#FF3A3A38' Geometry='M5.0000019,11 L5.0000019,15 11.000002,15 11.000002,11 z M4.0000019,1 L4.0000019,6 12.000002,6 12.000002,1 z M1,1 L1,13.174 2.7160001,15 4.0000019,15 4.0000019,10 12.000002,10 12.000002,15 15,15 15,1 13.000002,1 13.000002,7 3.0000019,7 3.0000019,1 z M0,0 L3.0000019,0 13.000002,0 16,0 16,16 12.000002,16 4.0000019,16 2.2840004,16 0,13.57 z' /></DrawingImage.Drawing></DrawingImage></Image.Source></Image>") });
            menuModel0.MenuItems.Add(new Model() { MenuItemName = "Advanced Save Options", MenuItemClickCommand = ItemCommand,ImagePath=(Image)XamlReader.Parse(@"<Image xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><Image.Source> <DrawingImage> <DrawingImage.Drawing> <GeometryDrawing Brush='#FF3A3A38' Geometry='M5.0000019,11 L5.0000019,15 11.000002,15 11.000002,11 z M4.0000019,1 L4.0000019,6 12.000002,6 12.000002,1 z M1,1 L1,13.174 2.7160001,15 4.0000019,15 4.0000019,10 12.000002,10 12.000002,15 15,15 15,1 13.000002,1 13.000002,7 3.0000019,7 3.0000019,1 z M0,0 L3.0000019,0 13.000002,0 16,0 16,16 12.000002,16 4.0000019,16 2.2840004,16 0,13.57 z' /></DrawingImage.Drawing> </DrawingImage></Image.Source></Image>") });
            menuModel0.MenuItems.Add(new Model() { MenuItemName = "Print", GestureText = "Ctrl + P", MenuItemClickCommand = ItemCommand,ImagePath=(Image)XamlReader.Parse(@"<Image xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><Image.Source><DrawingImage><DrawingImage.Drawing><DrawingGroup><GeometryDrawing Brush='White' Geometry='M4, 0 L11, 0 11, 5 15, 5 15, 11 11.106, 11 11, 11 11, 15 4, 15 4, 11 0, 11 0, 5 4, 5 z' /><GeometryDrawing Brush='#FF3A3A38' Geometry='M5,11 L5,15 11,15 11,11 z M2,7 L3,7 3,8 2,8 z M1,6 L1,11 4,11 4,10 12,10 12,11 15,11 15,6 12,6 4,6 z M5,1 L5,5 11,5 11,1 z M4,0 L12,0 12,5 16,5 16,12 12,12 12,16 4,16 4,12 0,12 0,5 4,5 z' /></DrawingGroup></DrawingImage.Drawing></DrawingImage> </Image.Source></Image>") });
            menuModel0.MenuItems.Add(new Model() { MenuItemName = "Exit", MenuItemClickCommand = ItemCommand });

            Model menuModel1 = new Model() { MenuItemName = "Edit" };
            menuModel1.MenuItems.Add(new Model() { MenuItemName = "Undo", GestureText = "Ctrl + Z", MenuItemClickCommand = ItemCommand,ImagePath=(Image)XamlReader.Parse(@"<Image xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><Image.Source><DrawingImage><DrawingImage.Drawing><GeometryDrawing Brush='#FF3A3A38' Geometry='M9.4821357,1.1920929E-07 C10.842761,-0.00024974346 12.203512,0.51175806 13.240013,1.5367737 14.244013,2.5307888 14.798014,3.8528089 14.798014,5.2588305 14.798014,6.665852 14.244013,7.9868721 13.240013,8.9808874 L6.1400083,15.999994 5.4370078,15.288983 12.536013,8.2708763 C13.350013,7.4658641 13.798013,6.3958477 13.798013,5.2588305 13.798013,4.121813 13.350013,3.0527968 12.536013,2.2477847 10.852012,0.58275911 8.1110095,0.58375913 6.4280085,2.2477847 L1.6224454,6.9990014 6.9999999,6.9990014 6.9999999,7.9990014 0,7.9990014 0,0.99900149 0.99999989,0.99900149 0.99999989,6.2083468 5.7250084,1.5367737 C6.7610091,0.51275805 8.1215094,0.0002502203 9.4821357,1.1920929E-07 z' /></DrawingImage.Drawing></DrawingImage></Image.Source></Image>") });
            menuModel1.MenuItems.Add(new Model() { MenuItemName = "Redo", GestureText = "Ctrl + Y", MenuItemClickCommand = ItemCommand,ImagePath=(Image)XamlReader.Parse(@"<Image xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><Image.Source><DrawingImage><DrawingImage.Drawing><GeometryDrawing Brush='#FF3A3A38' Geometry='M5.3151203,9.1339757E-08 C6.6757408,-0.00024967992 8.0364867,0.5117554 9.0729848,1.536765 L13.797998,6.2083356 13.797998,0.99899839 14.797998,0.99899839 14.797998,7.9989983 7.7979971,7.9989983 7.7979971,6.9989983 13.175562,6.9989983 8.3699828,2.2477743 C6.6849877,0.58275561 3.9439944,0.58376269 2.2619902,2.2477743 1.447996,3.0527944 0.99999856,4.1218111 0.99999844,5.2588217 0.99999856,6.395848 1.447996,7.4658562 2.2619902,8.2708761 L9.3609782,15.288974 8.6580068,15.999998 1.5580116,8.980879 C0.55401539,7.9868757 1.0524127E-07,6.6658561 0,5.2588217 1.0524127E-07,3.8528098 0.55401539,2.5307833 1.5580116,1.536765 2.5940057,0.51275485 3.9545001,0.00025004542 5.3151203,9.1339757E-08 z' /></DrawingImage.Drawing></DrawingImage></Image.Source></Image>") });
            menuModel1.MenuItems.Add(new Model() { MenuItemName = "Cut", GestureText = "Ctrl + X", MenuItemClickCommand = ItemCommand,ImagePath=(Image)XamlReader.Parse(@"<Image  xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><Image.Source><DrawingImage><DrawingImage.Drawing><DrawingGroup><GeometryDrawing Brush='#FF3A3A38' Geometry='M0.4800034,0 L3.2370005,5.6329948 5.9950049,0 6.4480002,1.3919982 3.8000043,6.7859942 6.4040015,12.108999 5.4240053,12.385 3.2370005,7.9400011 1.0859987,12.314001 0,12.249991 2.675004,6.7859942 0.027000348,1.3919982 z' /><GeometryDrawing Brush='#FF1D8BCC' Geometry='M2.0000019,1.0000033 C1.4480005,1.0000033 1.0000028,1.4489932 1.0000028,2.0000033 1.0000028,2.5509982 1.4480005,3.0000033 2.0000019,3.0000033 2.5519957,3.0000033 3.0000009,2.5509982 3.0000009,2.0000033 3.0000009,1.4489932 2.5519957,1.0000033 2.0000019,1.0000033 z M7.9999966,0.99999999 C7.4479966,0.99999993 6.9999966,1.449 6.9999966,2 6.9999966,2.5509999 7.4479966,3 7.9999966,3 8.5519962,3 8.9999962,2.5509999 8.9999962,2 8.9999962,1.449 8.5519962,0.99999993 7.9999966,0.99999999 z M2.0000019,3.2782542E-06 C3.1029978,3.3312692E-06 4,0.89700651 4,2.0000033 4,3.1030002 3.1029978,4.0000033 2.0000019,4.0000033 0.8969985,4.0000033 0,3.1030002 0,2.0000033 0,0.89700651 0.8969985,3.3312692E-06 2.0000019,3.2782542E-06 z M7.9999966,0 C9.1029968,-3.7871359E-08 9.9999962,0.89699995 9.9999962,2 9.9999962,3.1029999 9.1029968,4 7.9999966,4 6.8969965,4 5.9999966,3.1029999 5.9999966,2 5.9999966,0.89699995 6.8969965,-3.7871359E-08 7.9999966,0 z' /></DrawingGroup></DrawingImage.Drawing></DrawingImage></Image.Source></Image>") });
            menuModel1.MenuItems.Add(new Model() { MenuItemName = "Copy", GestureText = "Ctrl + C", MenuItemClickCommand = ItemCommand,ImagePath=(Image)XamlReader.Parse(@"<Image xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><Image.Source><DrawingImage><DrawingImage.Drawing><DrawingGroup><GeometryDrawing Brush='White' Geometry='M5.5000009,2.500005 L10.500001,2.500005 14.500001,6.500005 14.500001,14.500005 5.5000009,14.500005 z M0,0 L4.0000037,0 4.0000037,12 0,12 z' /><GeometryDrawing Brush='#FF3A3939' Geometry='M9.0000026,11.999999 L13.000003,11.999999 13.000003,12.999999 9.0000026,12.999999 z M9.0000026,9.9999986 L13.000003,9.9999986 13.000003,10.999999 9.0000026,10.999999 z M12,4.7070035 L12,7.0000033 14.293,7.0000033 z M6.9999967,4.0000001 L6.9999967,15 14.999997,15 14.999997,8.0000033 11,8.0000033 11,4.0000001 z M5.9999967,2.9999999 L11.706997,2.9999999 15.999997,7.293 15.999997,16 5.9999967,16 z M0,0 L6.9999967,0 6.9999967,2 5.9999971,2 5.9999971,1 1,1 1,13 4.9999976,13 4.9999976,14 0,14 z' /></DrawingGroup></DrawingImage.Drawing></DrawingImage></Image.Source></Image>") });
            menuModel1.MenuItems.Add(new Model() { MenuItemName = "Paste", GestureText = "Ctrl + V", MenuItemClickCommand = ItemCommand });
            menuModel1.MenuItems.Add(new Model() { MenuItemName = "Check Spelling", MenuItemClickCommand = ItemCommand,ImagePath=(Image)XamlReader.Parse(@"<Image  xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><Image.Source><DrawingImage><DrawingImage.Drawing><DrawingGroup><GeometryDrawing Brush='#FF3A3A38' Geometry='M1.5,4.9999994 C1.2249999,4.9999994 1,5.2249993 1,5.4999994 1,5.7749995 1.2249999,5.9999994 1.5,5.9999994 L2.9999999,5.9999994 2.9999999,4.9999994 z M5.9999852,2.9999999 L5.9999852,5.9999999 7.4999852,5.9999999 C7.7750096,5.9999999 7.9999852,5.7749976 7.9999852,5.4999999 L7.9999852,3.4999999 C7.9999852,3.2249984 7.7750096,2.9999999 7.4999852,2.9999999 z M11.5,1.9999993 L14,1.9999993 14,2.9999994 11.5,2.9999994 C11.225,2.9999994 11,3.2249993 11,3.4999994 L11,5.4999994 C11,5.7749995 11.225,5.9999994 11.5,5.9999994 L14,5.9999994 14,6.9999994 11.5,6.9999994 C10.673,6.9999994 10,6.3269995 10,5.4999994 L10,3.4999994 C10,2.6729995 10.673,1.9999994 11.5,1.9999993 z M1,1.9999993 L2.5,1.9999993 C3.327,1.9999994 4,2.6729995 4.0000001,3.4999994 L4.0000001,6.9999994 1.5,6.9999994 C0.67299986,6.9999994 0,6.3269995 0,5.4999994 0,4.6729993 0.67299986,3.9999994 1.5,3.9999994 L2.9999999,3.9999994 2.9999999,3.4999994 C3,3.2249993 2.7750001,2.9999994 2.5,2.9999994 L1,2.9999994 z M4.9999853,0 L5.9999852,0 5.9999852,1.9999999 7.4999852,1.9999999 C8.3270116,1.9999999 8.9999852,2.6730002 8.9999852,3.4999999 L8.9999852,5.4999999 C8.9999852,6.3269995 8.3270116,6.9999999 7.4999852,6.9999999 L4.9999853,6.9999999 z' /><GeometryDrawing Brush='#FF2DB25F' Geometry='M8.2930122,0 L8.9979997,0.7089998 3.668005,6.0010002 2.2200046,6.0010002 0,3.7970014 0.70498769,3.0879979 2.6319926,5.0010002 3.256017,5.0010002 z' /></DrawingGroup></DrawingImage.Drawing></DrawingImage></Image.Source></Image>") });

            Model menuModel2 = new Model() { MenuItemName = "View" };
            Model menuModel21 = new Model() { MenuItemName = "Find Results", MenuItemClickCommand = ItemCommand };
            menuModel21.MenuItems.Add(new Model() { MenuItemName = "Find Results 1", CheckIconType = CheckIconType.RadioButton, IsCheckable = true, MenuItemClickCommand = ItemCommand });
            menuModel21.MenuItems.Add(new Model() { MenuItemName = "Find Results 2", IsCheckable = true, MenuItemClickCommand = ItemCommand });
            menuModel21.MenuItems.Add(new Model() { MenuItemName = "Find Symbol Results", IsCheckable = true, MenuItemClickCommand = ItemCommand });

            Model menuModel22 = new Model() { MenuItemName = "Other Windows", MenuItemClickCommand = ItemCommand };
            menuModel22.MenuItems.Add(new Model() { MenuItemName = "Immediate Window", IsCheckable = true, MenuItemClickCommand = ItemCommand });
            menuModel22.MenuItems.Add(new Model() { MenuItemName = "Output", IsCheckable = true, MenuItemClickCommand = ItemCommand });
            menuModel22.MenuItems.Add(new Model() { MenuItemName = "Command Window", IsCheckable = true, MenuItemClickCommand = ItemCommand });
            menuModel22.MenuItems.Add(new Model() { MenuItemName = "Macro Explorer", IsCheckable = true, MenuItemClickCommand = ItemCommand });
            menuModel22.MenuItems.Add(new Model() { MenuItemName = "Solution Explorer", IsCheckable = true, MenuItemClickCommand = ItemCommand });
            menuModel2.MenuItems.Add(menuModel21);
            menuModel2.MenuItems.Add(menuModel22);

            Model menuModel4 = new Model() { MenuItemName = "Project" };
            menuModel4.MenuItems.Add(new Model() { MenuItemName = "Add Window..", MenuItemClickCommand = ItemCommand });
            menuModel4.MenuItems.Add(new Model() { MenuItemName = "Add User Control..", MenuItemClickCommand = ItemCommand });
            menuModel4.MenuItems.Add(new Model() { MenuItemName = "Add Resource Dictionary..", MenuItemClickCommand = ItemCommand });
            menuModel4.MenuItems.Add(new Model() { MenuItemName = "Add Page..", MenuItemClickCommand = ItemCommand });
            menuModel4.MenuItems.Add(new Model() { MenuItemName = "Add Class..", MenuItemClickCommand = ItemCommand });

            Model menuModel5 = new Model() { MenuItemName = "Build" };
            menuModel5.MenuItems.Add(new Model() { MenuItemName = "Build Solution", GestureText = "F6", MenuItemClickCommand = ItemCommand });
            menuModel5.MenuItems.Add(new Model() { MenuItemName = "ReBuild Solution", MenuItemClickCommand = ItemCommand });
            menuModel5.MenuItems.Add(new Model() { MenuItemName = "Clean Solution", MenuItemClickCommand = ItemCommand });
            menuModel5.MenuItems.Add(new Model() { MenuItemName = "Batch Build...", MenuItemClickCommand = ItemCommand });
            menuModel5.MenuItems.Add(new Model() { MenuItemName = "Configuration Manager...", MenuItemClickCommand = ItemCommand });

            Model menuModel6 = new Model() { MenuItemName = "Debug" };
            Model menuModel23 = new Model() { MenuItemName = "Windows", MenuItemClickCommand = ItemCommand };
            menuModel23.MenuItems.Add(new Model() { MenuItemName = "BreakPoints", MenuItemClickCommand = ItemCommand });
            menuModel23.MenuItems.Add(new Model() { MenuItemName = "Output", MenuItemClickCommand = ItemCommand });
            menuModel23.MenuItems.Add(new Model() { MenuItemName = "Immediate", MenuItemClickCommand = ItemCommand });
            menuModel6.MenuItems.Add(menuModel23);

            menuModel6.MenuItems.Add(new Model() { MenuItemName = "Start Debugging", GestureText = "F6", MenuItemClickCommand = ItemCommand,ImagePath=(Image)XamlReader.Parse(@"<Image xmlns='http://schemas.microsoft.com/winfx/2006/xaml/presentation'><Image.Source><DrawingImage><DrawingImage.Drawing><DrawingGroup><GeometryDrawing Brush='White' Geometry='M0,0 L10.599,7.0660113 0,14.131 z' /><GeometryDrawing Brush='#FF379E4E' Geometry='M1,1.8690033 L1,14.130997 10.19696,8 z M0,0 L12,8 0,16 z' /></DrawingGroup></DrawingImage.Drawing></DrawingImage></Image.Source></Image>") });
            menuModel6.MenuItems.Add(new Model() { MenuItemName = "Start Without Debugging", MenuItemClickCommand = ItemCommand });
            menuModel6.MenuItems.Add(new Model() { MenuItemName = "Attach to Process...", MenuItemClickCommand = ItemCommand });
            menuModel6.MenuItems.Add(new Model() { MenuItemName = "Excpetions", MenuItemClickCommand = ItemCommand });

            Model menuModel7 = new Model() { MenuItemName = "Help" };
            menuModel7.MenuItems.Add(new Model() { MenuItemName = "About", MenuItemClickCommand = AboutCommand });
            menuModel7.MenuItems.Add(new Model() { MenuItemName = "View Help", GestureText = "F6", MenuItemClickCommand = HelpCommand });
            menuModel7.MenuItems.Add(new Model() { MenuItemName = "About Syncfusion Essential Studio", MenuItemClickCommand = EssentialStudioCommand });

            menuModel.Add(menuModel0);
            menuModel.Add(menuModel1);
            menuModel.Add(menuModel2);
            menuModel.Add(menuModel4);
            menuModel.Add(menuModel5);
            menuModel.Add(menuModel6);
            MenuModel.Add(menuModel7);
        }

        /// <summary>
        /// Gets the rich textBox property
        /// </summary>
        /// <param name="obj">Specifies the dependency object.</param>
        /// <returns></returns>
        public static string GetRichTextBox(DependencyObject obj)
        {
            return (string)obj.GetValue(RichTextBoxProperty);
        }

        /// <summary>
        /// Sets the rich textBox property
        /// </summary>
        /// <param name="obj">>Specifies the dependency object.</param>
        /// <param name="value">Specifies the ribbon value.</param>
        public static void SetRichTextBox(DependencyObject obj, string value)
        {
            obj.SetValue(RichTextBoxProperty, value);
        }

        /// <summary>
        /// Dependency property.
        /// </summary>
        public static readonly DependencyProperty RichTextBoxProperty =
            DependencyProperty.RegisterAttached("RichTextBox", typeof(string), typeof(ViewModel), new FrameworkPropertyMetadata(OnRichTextBoxChanged));

        /// <summary>
        /// Method used to access the rich textBox control.
        /// </summary>
        /// <param name="obj">Specifies the dependency object.</param>
        /// <param name="args">Specifies the dependency property changes event args.</param>
        public static void OnRichTextBoxChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            richTextBox = obj as RichTextBox;
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
        /// Gets or sets the command for essential studio  <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand EssentialStudioCommand
        {
            get
            {
                return essentialStudioCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for about <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand AboutCommand
        {
            get
            {
                return aboutCommand;
            }
        }

        /// <summary>
        /// Gets or seta the command for menu items <see cref="ViewModel"/>class.
        /// </summary>
        public ICommand ItemCommand
        {
            get
            {
                return itemCommand;
            }
        }

        /// <summary>
        /// Gets or sets the collection of string to display events <see cref="ViewModel"/>class.
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
        /// Gets or sets the collection of <see cref="ViewModel"/>class.
        /// </summary>
        public ObservableCollection<Model> MenuModel
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
            EventLog.Add("Selection Changed : " + param.ToString());
            MessageBox.Show("Menu item has been clicked.");
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
