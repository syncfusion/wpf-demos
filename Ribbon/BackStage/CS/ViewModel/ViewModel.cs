#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion
using Microsoft.Win32;
using Syncfusion.Windows.Shared;
using Syncfusion.Windows.Tools.Controls;
using System.Collections.ObjectModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace BackStageSample
{
    /// <summary>
    /// Class represents the behaviour or business logic for MainWindow.xaml
    /// </summary>
    class ViewModel
    {
        /// <summary>
        ///  Maintains the collection of font family.
        /// </summary>
        private ObservableCollection<Model> fontfamilyList = new ObservableCollection<Model>();

        /// <summary>
        ///  Maintains the collection of font size.
        /// </summary>
        private ObservableCollection<Model> fontsizeList = new ObservableCollection<Model>();

        /// <summary>
        /// Maintains the ribbon properties.
        /// </summary>
        private static Ribbon ribbon = null;

        /// <summary>
        /// Maintains the richtextbox properties.
        /// </summary>
        private static RichTextBox rich = null;

        /// <summary>
        /// Maintains the file path to load file.
        /// </summary>
#if NETCORE
        string filePath =  @"..\..\..\Resources\temp.rtf";
#else
        string filePath = @"Resources\temp.rtf";
#endif

        /// <summary>
        /// Maintains the command for exit backstage item.
        /// </summary>
        private ICommand exitCommand;

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
        /// Maintains the command for homeTab open backstage button.
        /// </summary>
        private ICommand homeTabOpenBackstageCommand;

        /// <summary>
        /// Maintains the command for insertTab open backstage button.
        /// </summary>
        private ICommand insertTabOpenBackstageCommand;

        /// <summary>
        /// Maintains the command for help tab open backstage button.
        /// </summary>
        private ICommand inHelpOpenBackstageCommand;

        /// <summary>
        /// Maintains the command for onlineHelpCommand.
        /// </summary>
        private ICommand onlineHelpCommand;

        /// <summary>
        /// Maintains the command for help tab getting started button.
        /// </summary>
        private ICommand inHelpGettingStartedCommand;

        /// <summary>
        /// Maintains the command for inRecentTabCloseBackStage.
        /// </summary>
        private ICommand inRecentTabCloseBackStageCommand;

        /// <summary>
        /// Maintains the command for inInfoBackStage.
        /// </summary>
        private ICommand inInfoBackStageCloseCommand;

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
        /// Indicates whether the info backstage checkbox is checked or not <see cref="ViewModel"/> class.
        /// </summary>
        public bool InfoBackStageCheckBoxProperty { get; set; }

        /// <summary>
        /// Indicates whether home tab checkbox is checked or not. <see cref="ViewModel"/> class.
        /// </summary>
        public bool HomeTabCheckBoxProperty { get; set; }

        /// <summary>
        /// Indicates whether insert tab checkbox is checked or not. <see cref="ViewModel"/> class.
        /// </summary>
        public bool InsertTabCheckBoxProperty { get; set; }

        /// <summary>
        /// Indicates whether help backstage checkbox is checked or not. <see cref="ViewModel"/> class.
        /// </summary>
        public bool HelpBackStageCheckBoxProperty { get; set; }

        /// <summary>
        /// Indicates whether recent backstage checkbox is checked or not. <see cref="ViewModel"/> class.
        /// </summary>
        public bool RecentBackStageCheckBoxProperty { get; set; }

        /// <summary>
        /// Gets or sets the command for exit backstage command button <see cref="ViewModel"/> class.
        /// </summary>      
        public ICommand ExitCommand { get { return exitCommand; } }

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
        /// Gets or sets the command to open backstage in home tab button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand HomeTabOpenBackstageCommand { get { return homeTabOpenBackstageCommand; } }

        /// <summary>
        /// Gets or sets the command to open backstage in insert tab button <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand InsertTabOpenBackstageCommand { get { return insertTabOpenBackstageCommand; } }

        /// <summary>
        /// Gets or sets the command for button in help backstage tab <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand InHelpOpenBackstageCommand { get { return inHelpOpenBackstageCommand; } }

        /// <summary>
        /// Gets or sets the command for button in help backstage tab <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand OnlineHelpCommand { get { return onlineHelpCommand; } }

        /// <summary>
        /// Gets or sets the command for button in help backstage tab <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand InHelpGettingStartedCommand { get { return inHelpGettingStartedCommand; } }

        /// <summary>
        /// Gets or sets the command for button in recent backstage tab <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand InRecentTabCloseBackStageCommand { get { return inRecentTabCloseBackStageCommand; } }

        /// <summary>
        /// Gets or sets the command for button in info backstage tab <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand InInfoBackStageCloseCommand { get { return inInfoBackStageCloseCommand; } }

        /// <summary>
        /// Gets or sets the command for button <see cref="ViewModel"/> class.
        /// </summary>      
        public ICommand ButtonCommand { get { return buttonCommand; } }

        /// <summary>
        /// Gets or sets the command for dropdown <see cref="ViewModel"/> class.
        /// </summary>      
        public ICommand DropDownCommand { get { return dropdownCommand; } }

        /// <summary>
        /// Gets the command for ribbon comboBox <see cref="ViewModel"/> class.
        /// </summary>
        public ICommand RibbonComboBoxCommand { get  {   return ribbonComboBoxCommand; }  }

        /// <summary>
        /// Gets or sets the command for document content <see cref="ViewModel"/> class.
        /// </summary>
        public string DocContent { get; set; }

        /// <summary>
        /// Gets or sets the font.family for the ItemSource of RibbonComboBox Control <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> FontFamilyList
        {
            get { return fontfamilyList; }
            set { fontfamilyList = value; }
        }

        /// <summary>
        /// Gets or sets the font.size for the ItemSource of the RibbonComboBox Control <see cref="ViewModel"/> class.
        /// </summary>
        public ObservableCollection<Model> FontSizeList
        {
            get { return fontsizeList; }
            set { fontsizeList = value; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ViewModel"/> class.
        /// </summary>
        public ViewModel()
        {
            exitCommand = new DelegateCommand<object>(ExecuteMethod );
            saveAsCommand = new DelegateCommand<object>(SaveAsExecute );
            openCommand = new DelegateCommand<object>(OpenExecute );
            closeCommand = new DelegateCommand<object>(CloseExecute );
            homeTabOpenBackstageCommand = new DelegateCommand<object>(HomeTabOpenBackstageExecute );
            insertTabOpenBackstageCommand = new DelegateCommand<object>(InsertTabOpenBackStageExecute );
            inHelpOpenBackstageCommand = new DelegateCommand<object>(InHelpOpenBackStage );
            onlineHelpCommand = new DelegateCommand<object>(OnlineHelp );
            inHelpGettingStartedCommand = new DelegateCommand<object>(GettingStarted );
            inRecentTabCloseBackStageCommand = new DelegateCommand<object>(RecentTabCloseBackStage );
            inInfoBackStageCloseCommand = new DelegateCommand<object>(InfoBackStageClose );
            buttonCommand = new DelegateCommand<object>(ButtonCommandExecute);
            dropdownCommand = new DelegateCommand<object>(DropDownCommandExecute);
            ribbonComboBoxCommand = new DelegateCommand<object>(ExecuteRibbonComboBoxCommand);
            string readText = File.ReadAllText(filePath);
            InitializeFont_FamilySize();
            DocContent = readText;
        }

        /// <summary>
        /// Gets the ribbon property
        /// </summary>
        /// <param name="obj">Specifies the dependency object.</param>
        /// <returns></returns>
        public static Ribbon GetRibbon(DependencyObject obj)
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
        /// Gets the document content in richtext box.
        /// </summary>
        /// <param name="obj">Specifies the dependency object parameter.</param>
        /// <returns>Specifies the string return type.</returns>
        public static string GetDocumentContent(DependencyObject obj)
        {
            return (string)obj.GetValue(DocumentContentProperty);
        }

        /// <summary>
        /// Sets the document content in richtext box.
        /// </summary>
        /// <param name="obj">Specifies the dependency object parameter.</param>
        /// <param name="value">Specifies the value.</param>
        public static void SetDocumentContent(DependencyObject obj, string value)
        {
            obj.SetValue(DocumentContentProperty, value);
        }

        /// <summary>
        /// Using a DependencyProperty as the backing store for DocumentContent.This enables animation, styling, binding, etc...
        /// </summary>
        public static readonly DependencyProperty DocumentContentProperty =
            DependencyProperty.RegisterAttached("DocumentContent", typeof(string), typeof(ViewModel), new FrameworkPropertyMetadata
            {
                BindsTwoWayByDefault = true,
                PropertyChangedCallback = (obj, e) =>
                {
                     rich = (RichTextBox)obj;
                    var xaml = GetDocumentContent(rich);
                    var doc = new FlowDocument();
                    var range = new TextRange(doc.ContentStart, doc.ContentEnd);
                    using (var reader = new MemoryStream(Encoding.UTF8.GetBytes(xaml)))
                    {
                        reader.Position = 0;
                        rich.SelectAll();
                        rich.Selection.Load(reader, DataFormats.Rtf);
                    }
                }
            });

        /// <summary>
        /// Method which is used to execute the action.
        /// </summary>
        /// <param name="parameter">Specifies the parameter of execute action.</param>
        private void ExecuteMethod(object parameter)
        {
            Application.Current.Shutdown();
        }
      
        /// <summary>
        /// Method which is used to execute the saveas command.
        /// </summary>
        /// <param name="parameter">Specifies the parameter of saveas command.</param>
        private void SaveAsExecute(object parameter)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            FileStream rtfFile = null;
            saveFile.Filter = "FlowDocument Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
            if (saveFile.ShowDialog().Value)
            {
                rtfFile = saveFile.OpenFile() as FileStream;
                XamlWriter.Save(rich, rtfFile);
                TextRange t = new TextRange(rich.Document.ContentStart,rich.Document.ContentEnd);
                t.Save(rtfFile, System.Windows.DataFormats.Rtf);
                rtfFile.Close();
            }
        }

        /// <summary>
        /// Method which is used to execute the open command.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void OpenExecute(object parameter)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "FlowDocument Files (*.rtf)|*.rtf|All Files (*.*)|*.*";
            if (openFile.ShowDialog().Value)
            {
                string path = openFile.FileName;
                filePath = path;
                DocContent = File.ReadAllText(filePath);
                ribbon.HideBackStage();
            }
        }

        /// <summary>
        /// Method to hide the backstage for close backstage button.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void CloseExecute(object parameter)
        {
            ribbon.HideBackStage();
        }

        /// <summary>
        /// Method to execute the command for opening backstage in home tab.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void HomeTabOpenBackstageExecute(object parameter)
        {
            if (HomeTabCheckBoxProperty == false)
            {
                ribbon.ShowBackStage();
            }
        }

        /// <summary>
        /// Method to execute the command for opening backstage in insert tab.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void InsertTabOpenBackStageExecute(object parameter)
        {
            if (InsertTabCheckBoxProperty == false)
            {
                ribbon.ShowBackStage();
            }
        }

        /// <summary>
        /// Method to execute the command for hiding backstage.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void InHelpOpenBackStage(object parameter)
        {
            if (HelpBackStageCheckBoxProperty == false)
            {
                ribbon.HideBackStage();
            }
        }

        /// <summary>
        ///Method to execute the command for button in help backstage tab.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void OnlineHelp(object parameter)
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
        private void GettingStarted(object parameter)
        {
            if (MessageBox.Show("Are you sure to visit the getting started page ?", "Getting Started", MessageBoxButton.YesNo, MessageBoxImage.Asterisk) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start("https://help.syncfusion.com/wpf/ribbon/gettingstarted");
            }
        }

        /// <summary>
        /// Method to execute the recent backstage button command.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void RecentTabCloseBackStage(object parameter)
        {
            if (RecentBackStageCheckBoxProperty==false)
            {
               ribbon.HideBackStage();
            }
        }

        /// <summary>
        /// Method to execute the info backstage tab command.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void InfoBackStageClose(object parameter)
        {
            if (InfoBackStageCheckBoxProperty == false)
            {
                ribbon.HideBackStage();
            }
        }

        /// <summary>
        /// Initialization of font size and font family for RibbonComboBox.
        /// </summary>
        public void InitializeFont_FamilySize()
        {
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
