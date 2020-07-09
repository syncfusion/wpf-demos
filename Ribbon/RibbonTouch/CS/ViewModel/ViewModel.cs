#region Copyright Syncfusion Inc. 2001-2019.
// Copyright Syncfusion Inc. 2001-2019. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Threading;

namespace RibbonSample
{
    /// <summary>
    /// Represents the class of viewmodel
    /// </summary>
    public class ViewModel : NotificationObject
    {
        /// <summary>
        /// Maintains the command for save as backstage item.
        /// </summary>
        private ICommand saveAsCommand;

        /// <summary>
        /// Maintains the command for open backstage item.
        /// </summary>
        private ICommand openCommand;

        /// <summary>
        /// Maintains the command for close backstage item.
        /// </summary>
        private ICommand closeCommand;

        /// <summary>
        /// Maintains the flow direction.
        /// </summary>
        private ICommand flowDirectionCommand;

        /// <summary>
        /// Maintains the command for backStage exit click.
        /// </summary>
        private ICommand backStageExitCommand;

        /// <summary>
        /// Maintains the command for onilne help button in help backStage.
        /// </summary>
        private ICommand onlineHelpCommand;

        /// <summary>
        /// Maintains the command for getting started button in help backStage.
        /// </summary>
        private ICommand inHelpGettingStartedCommand;

        /// <summary>
        /// Maintains the command for return to editor button in info backStage.
        /// </summary>
        private ICommand returnToEditorCommand;

        /// <summary>
        /// Maintains the command for enable touch.
        /// </summary>
        private ICommand setEnableTouchCommand;

        /// <summary>
        /// Maintains the command for remove touch.
        /// </summary>
        private ICommand removeEnableTouchCommand;

        /// <summary>
        /// Maintains the command for open the model.
        /// </summary>
        private ICommand openModelTabCommand;

        /// <summary>
        /// Maintains the command for close model.
        /// </summary>
        private ICommand closeModelTabCommand;

        /// <summary>
        /// Maintains the command for splash window loaded.
        /// </summary>
        private ICommand splashWindowLoadedCommand;

        /// <summary>
        /// Maintains the command for main window closed.
        /// </summary>
        private ICommand mainWindowClosedCommand;

        /// <summary>
        /// Maintains the command for border style dropdown item.
        /// </summary>
        private ICommand ribbonDisableCommand;

        /// <summary>
        /// Maintains the command for buttons
        /// </summary>
        private ICommand buttonCommand;

        /// <summary>
        /// Maintains the command for dropdown
        /// </summary>
        private ICommand dropdownCommand;

        /// <summary>
        /// Maintains the command for ribbon combobox.
        /// </summary>
        private ICommand ribbonComboBoxCommand;

        /// <summary>
        /// Maintains the window flow direction.
        /// </summary>
        private FlowDirection flowDirectionProperty;

        /// <summary>
        /// Maintains the collection of slide items.
        /// </summary>
        private ObservableCollection<Model> slideItems;

        /// <summary>
        /// Maintains the boolean for isEnable property of simple button bar.
        /// </summary>
        private bool simpleButtonsBarIsEnableProperty;

        /// <summary>
        /// Maintains the ribbon properties.
        /// </summary>
        private static Ribbon ribbon = null;

        /// <summary>
        /// Maintains the richTextBox properties.
        /// </summary>
        private static RichTextBox richTextBox = null;

        /// <summary>
        /// Maintains the slide number.
        /// </summary>
        private int slideNo = 1;

        /// <summary>
        /// Maintains the splashScreen window property.
        /// </summary>
        private static Window splashScreenWindow = null;

        /// <summary>
        /// Maintains the collection of font family.
        /// </summary>
        private ObservableCollection<Model> fontFamilyList = new ObservableCollection<Model>();

        /// <summary>
        /// Maintains the collection of font size.
        /// </summary>
        private ObservableCollection<Model> fontSizeList = new ObservableCollection<Model>();

        /// <summary>
        /// Maintains the timings for opening or closing the window.
        /// </summary>
        private DispatcherTimer timer = null;

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel" /> class.
        /// </summary>  
        public ViewModel()
        {
            saveAsCommand = new DelegateCommand<object>(ExecuteSaveAsCommand);
            openCommand = new DelegateCommand<object>(ExecuteOpenCommand);
            closeCommand = new DelegateCommand<object>(ExecuteCloseCommand);
            backStageExitCommand = new DelegateCommand<object>(ExecuteBackStageExitCommand);
            onlineHelpCommand = new DelegateCommand<object>(ExecuteOnlineHelpCommand);
            inHelpGettingStartedCommand = new DelegateCommand<object>(ExecuteGettingStartedCommand);
            returnToEditorCommand = new DelegateCommand<object>(ExecuteReturnToEditorCommand);
            buttonCommand = new DelegateCommand<object>(ButtonCommandExecute);
            dropdownCommand = new DelegateCommand<object>(DropDownCommandExecute);
            ribbonComboBoxCommand = new DelegateCommand<object>(ExecuteRibbonComboBoxCommand);

            setEnableTouchCommand = new DelegateCommand<object>(ExecuteSetEnableTouchCommand);
            removeEnableTouchCommand = new DelegateCommand<object>(ExecuteRemoveEnableTouchCommand);
            openModelTabCommand = new DelegateCommand<object>(ExecuteOpenModelTabCommand);
            closeModelTabCommand = new DelegateCommand<object>(ExecuteCloseModelTabCommand);
            flowDirectionCommand = new DelegateCommand<object>(ExecuteFlowDirectionCommand);
            splashWindowLoadedCommand = new DelegateCommand<object>(ExecuteSplashWindowLoadedCommand);
            mainWindowClosedCommand = new DelegateCommand<object>(ExecuteMainWindowClosedCommand);
            ribbonDisableCommand = new DelegateCommand<object>(ExecuteRibbonDisableCommand);
            simpleButtonsBarIsEnableProperty = true;

            var items = new System.Collections.ObjectModel.ObservableCollection<Model>();
            items.Add(getSlideItem("Tools WPF Controls", ""));
            items.Add(getSlideItem("Ribbon", "Our collection of Office 2007-style UI  controls let you create Office-style menus, toolbars, window frames, etc. Bringing your application UI on par with industry standards and leaders has never been easier."));
            items.Add(getSlideItem("DockingManager", "The docking manager provides VS.NET-style docked container support to your application. Dock panels can be docked, floated, auto-hidden, etc. Based on a proven VS.NET-style architecture, your end users can interact with it in a very intuitive fashion. The layout can be set up easily in code or in XAML."));
            items.Add(getSlideItem("TabControlExt ", "The TabControlExt control provides a simple and intuitive interface for a tab-based navigation system. "));
            items.Add(getSlideItem("Carousel", "The Carousel control provides a 3-D interface for displaying objects in a rich visual manner that allows users to quickly navigate through data visually. "));
            items.Add(getSlideItem("Document Container", "If you missed the traditional multiple document interface (MDI) user interface in WPF, the MDI support in our document container framework comes to the rescue. You can also use the tabbed document interface (TDI) framework to build the latest VS 2010-style tabbed document interfaces."));
            items.Add(getSlideItem("Skin Manager", "The skin manager is a great utility that allows you to apply a uniform skin on all the controls in your application for both Syncfusion and other WPF controls. There are also several built-in skins that provide multiple options for creating a very professional look and feel for your applications."));
            items.Add(getSlideItem("TileView", "The TileView control acts as a container that holds a set of items to host information that can be maximized or minimized to provide an organized view of data."));
            items.Add(getSlideItem("TreeViewAdv", "The TreeViewAdv control provides all the advanced capabilities that are missing in the framework version. Advanced features such as multiple columns, drag-and-drop, multi-node selection, and inline editing support are also available. It also has a feature for adding images, and it contains the built-in ability to perform item sorting on a tree view."));
            items.Add(getSlideItem("Input Controls", "Such as ButtonAdv control is a basic button control that can be used to design complex forms and applications. "));
            SlideItems = items;

            int[] sizes = new int[15] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 28, 36, 48, 72 };
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                FontFamilyList.Add(new Model() { FontFamily = fontFamily.ToString() });
            }
            for (int i = 0; i < sizes.Length; i++)
            {
                FontSizeList.Add(new Model() { FontSize = sizes[i] });
            }
        }

        /// <summary>
        /// Gets or sets the font.family for the ItemSource of RibbonComboBox Control <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> FontFamilyList
        {
            get { return fontFamilyList; }
            set { fontFamilyList = value; }
        }
        /// <summary>
        /// Gets or sets the font.size for the ItemSource of the RibbonComboBox Control <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> FontSizeList
        {
            get { return fontSizeList; }
            set { fontSizeList = value; }
        }

        /// <summary>
        /// Getting slide items.
        /// </summary>
        /// <param name="name">Specifies the name os slide items</param>
        /// <param name="description">Specifies the description in the slide.</param>
        /// <returns>Returns slide item.</returns>
        private Model getSlideItem(string name, string description)
        {
            var slideItem = new Model();
            slideItem.ItemText = name;
            slideItem.Description = description;
            slideItem.SlideNumber = slideNo++;
            return slideItem;
        }

        /// <summary>
        /// Gets the ribbon property
        /// </summary>
        /// <param name="obj">Specifies the dependency object.</param>
        /// <returns></returns>
        public static Ribbon GetRibbon(System.Windows.DependencyObject obj)
        {
            return (Ribbon)obj.GetValue(RibbonProperty);
        }

        /// <summary>
        /// Sets the ribbon property
        /// </summary>
        /// <param name="obj">>Specifies the dependency object.</param>
        /// <param name="value">Specifies the ribbon value.</param>
        public static void SetRibbon(DependencyObject obj, Ribbon value)
        {
            obj.SetValue(RibbonProperty, value);
        }

        /// <summary>
        /// Dependency property.
        /// </summary>
        public static readonly DependencyProperty RibbonProperty =
            DependencyProperty.RegisterAttached("Ribbon", typeof(Ribbon), typeof(ViewModel), new FrameworkPropertyMetadata(OnRibbonChanged));

        /// <summary>
        /// Method used to access the ribbon control.
        /// </summary>
        /// <param name="obj">Specifies the dependency object.</param>
        /// <param name="args">Specifies the dependency property changes event args.</param>
        public static void OnRibbonChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            ribbon = obj as Ribbon;
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
        /// Gets the splash screen window property
        /// </summary>
        /// <param name="obj">Specifies the dependency object.</param>
        /// <returns></returns>
        public static Window GetWindow(DependencyObject obj)
        {
            return (Window)obj.GetValue(WindowProperty);
        }

        /// <summary>
        /// Sets the ribbon property
        /// </summary>
        /// <param name="obj">>Specifies the dependency object.</param>
        /// <param name="value">Specifies the ribbon value.</param>
        public static void SetWindow(DependencyObject obj, Window value)
        {
            obj.SetValue(WindowProperty, value);
        }

        /// <summary>
        /// Dependency property.
        /// </summary>
        public static readonly DependencyProperty WindowProperty =
            DependencyProperty.RegisterAttached("Window", typeof(Window), typeof(ViewModel), new FrameworkPropertyMetadata(OnWindowChanged));

        /// <summary>
        /// Method used to access the ribbon control.
        /// </summary>
        /// <param name="obj">Specifies the dependency object.</param>
        /// <param name="args">Specifies the dependency property changes event args.</param>
        public static void OnWindowChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            splashScreenWindow = obj as Window;
        }

        /// <summary>
        /// Indicates whether the split buttons bar isenable property is true or false <see cref="ViewModel"/>class.
        /// </summary>
        public bool SimpleButtonsBarIsEnableProperty { get { return simpleButtonsBarIsEnableProperty; } set { simpleButtonsBarIsEnableProperty = value; RaisePropertyChanged("SimpleButtonsBarIsEnableProperty"); } }

        /// <summary>
        /// Gets or sets the command for ribbon disable button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand RibbonDisableCommand { get { return ribbonDisableCommand; } }

        /// <summary>
        /// Gets or sets the command for window folw direction <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand FlowDirectionCommand { get { return flowDirectionCommand; } }

        /// <summary>
        /// Gets or sets the command for closing all the windows <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand MainWindowClosedCommand { get { return mainWindowClosedCommand; } }

        /// <summary>
        /// Gets or sets the command for splash window loaded <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand SplashWindowLoadedCommand { get { return splashWindowLoadedCommand; } }

        /// <summary>
        /// Gets or sets the command for saveas backstage command button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand SaveAsCommand { get { return saveAsCommand; } }

        /// <summary>
        /// Gets or sets the command for open backstage command button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand OpenCommand { get { return openCommand; } }

        /// <summary>
        /// Gets or sets the command for close backstage command button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand CloseCommand { get { return closeCommand; } }

        /// <summary>
        /// Gets or sets the command for backStage exit button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand BackStageExitCommand { get { return backStageExitCommand; } }

        /// <summary>
        /// Gets or sets the command for return to editor button in info backstage <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand ReturnToEditorCommand { get { return returnToEditorCommand; } }

        /// <summary>
        /// Gets or sets the command for online help button in help backstage <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand OnlineHelpCommand { get { return onlineHelpCommand; } }

        /// <summary>
        /// Gets or sets the command for online getting started button in help backstage <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand InHelpGettingStartedCommand { get { return inHelpGettingStartedCommand; } }

        /// <summary>
        /// Gets or sets the command for set enable touch <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand SetEnableTouchCommand { get { return setEnableTouchCommand; } }

        /// <summary>
        /// Gets or sets the command for remove enable touch <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand RemoveEnableTouchCommand { get { return removeEnableTouchCommand; } }

        /// <summary>
        /// Gets or sets the command for button <see cref="ViewModel"/> class.
        /// </summary>      
        public ICommand ButtonCommand { get { return buttonCommand; } }

        /// <summary>
        /// Gets or sets the command for dropdown <see cref="ViewModel"/> class.
        /// </summary>      
        public ICommand DropDownCommand { get { return dropdownCommand; } }

        /// <summary>
        /// Gets the command for opening model tab <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand OpenModelTabCommand {  get { return openModelTabCommand; } }

        /// <summary>
        /// Gets the flow direction for window <see cref="ViewModel"/> class.
        /// </summary>
        public FlowDirection FlowDirectionProperty {  get { return flowDirectionProperty; } set { flowDirectionProperty = value; RaisePropertyChanged("FlowDirectionProperty"); }  }

        /// <summary>
        /// Gets the command for opening model tab <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand CloseModelTabCommand {  get { return closeModelTabCommand; }  }

        /// <summary>
        /// Gets the command for ribbon comboBox <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand RibbonComboBoxCommand  { get  { return ribbonComboBoxCommand;   }  }

        /// <summary>
        /// Gets or sets the slide items.
        /// </summary>
        public ObservableCollection<Model> SlideItems
        {
            get { return slideItems; }
            set
            {
                slideItems = value;
                RaisePropertyChanged("SlideItems");
            }
        }

        /// <summary>
        /// Method which is used to execute the saveas command.
        /// </summary>
        /// <param name="parameter">Specifies the parameter of saveas command.</param>
        private void ExecuteSaveAsCommand(object parameter)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            System.IO.FileStream rtfFile = null;
            saveFile.Filter = "FlowDocument Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
            if (saveFile.ShowDialog().Value)
            {
                rtfFile = saveFile.OpenFile() as FileStream;
                XamlWriter.Save(richTextBox, rtfFile);
                TextRange t = new TextRange(richTextBox.Document.ContentStart, richTextBox.Document.ContentEnd);
                t.Save(rtfFile, System.Windows.DataFormats.Rtf);
                rtfFile.Close();
            }
        }

        /// <summary>
        /// Method which is used to execute the open command.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteOpenCommand(object parameter)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "FlowDocument Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
            if (openFile.ShowDialog().Value)
            {
                ribbon.HideBackStage();
            }
        }

        /// <summary>
        /// Method to hide the backstage for close backstage button.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteCloseCommand(object parameter)
        {
            ribbon.HideBackStage();
        }

        /// <summary>
        /// Method to execute backStageExitCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void ExecuteBackStageExitCommand(object parameter)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        ///Method to execute the command for button in help backstage tab.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteOnlineHelpCommand(object parameter)
        {
            if (MessageBox.Show("Are you sure to visit the help page ?", "Online Help", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/welcome-to-syncfusion-essential-wpf");
            }
        }

        /// <summary>
        /// Method to execute the command for button in help backstage tab.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteGettingStartedCommand(object parameter)
        {
            if (MessageBox.Show("Are you sure to visit the getting started page ?", "Getting Started", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/ribbon/gettingstarted");
            }
        }

        /// <summary>
        /// Method to execute returnToEditorCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void ExecuteReturnToEditorCommand(object parameter)
        {
            ribbon.HideBackStage();
        }

        /// <summary>
        /// Method used to execute the setEnableTouchCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void ExecuteSetEnableTouchCommand(object parameter)
        {
            SkinStorage.SetEnableTouch(ribbon, true);
        }

        /// <summary>
        /// Method used to execute the removeEnableTouchCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void ExecuteRemoveEnableTouchCommand(object parameter)
        {
            SkinStorage.SetEnableTouch(ribbon, false);
        }

        /// <summary>
        /// Method which is used to implement the openModelTab command.
        /// </summary>
        /// <param name="parameter">Model tab to be show and close.</param>
        private void ExecuteOpenModelTabCommand(object parameter)
        {
            ribbon.ShowModalTab("printpreview");
        }

        /// <summary>
        /// Method which is used to implement the closeModelTab command.
        /// </summary>
        /// <param name="parameter">Model tab to be show and close.</param>
        private void ExecuteCloseModelTabCommand(object parameter)
        {
            ribbon.CloseModalTabs();
        }

        /// <summary>
        /// Method which is used to implement the flow direction command.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void ExecuteFlowDirectionCommand(object parameter)
        {
            FlowDirectionProperty = (FlowDirection)(1 - (int)FlowDirectionProperty);
        }

        /// <summary>
        /// Timer
        /// </summary>
        void StartTimer()
        {
            timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += new EventHandler(timer_Elapsed);
            timer.Start();
        }

        /// <summary>
        /// Event used to open main window Window1.xaml
        /// </summary>
        /// <param name="sender">Specifies the object parameter.</param>
        /// <param name="e">Specifies the event.</param>
        void timer_Elapsed(object sender, EventArgs e)
        {
            if (splashScreenWindow != null)
            {
                splashScreenWindow.Close();
            }
            timer.Stop();
            Window1 window = new Window1();
            window.Show();
        }

        /// <summary>
        /// Method used to execute the splash window loaded command.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void ExecuteSplashWindowLoadedCommand(object parameter)
        {
            StartTimer();
        }

        /// <summary>
        /// Method used to execute the windowClosedCommand
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        private void ExecuteMainWindowClosedCommand(object parameter)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Method used to execute ribbonDisableCommnd. 
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteRibbonDisableCommand(object parameter)
        {
            SimpleButtonsBarIsEnableProperty = !SimpleButtonsBarIsEnableProperty;
        }

        /// <summary>
        /// Method used to execute the button command.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        public void ButtonCommandExecute(object parameter)
        {
            MessageBox.Show("Click operation has been performed.");
        }

        /// <summary>
        /// Method used to execute the dropdown command.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        public void DropDownCommandExecute(object parameter)
        {
            MessageBox.Show("The dropdown item has been selected.");
        }

        /// <summary>
        /// Method used to execute the ribbon comboBox command.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private void ExecuteRibbonComboBoxCommand(object parameter)
        {
            if ((parameter != null && (int)parameter >= 0))
            {
                MessageBox.Show("The dropdown item has been selected.");
            }
        }
    }
}
