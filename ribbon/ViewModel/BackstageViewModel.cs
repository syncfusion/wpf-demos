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

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Class represents the behaviour or business logic for MainWindow.xaml
    /// </summary>
    public class BackstageViewModel : NotificationObject
    {
        /// <summary>
        ///  Maintains the collection of font.family.
        /// </summary>
        private ObservableCollection<GettingStartedModel> fontFamilyList = new ObservableCollection<GettingStartedModel>();

        /// <summary>
        ///  Maintains the collection of font.size.
        /// </summary>
        private ObservableCollection<GettingStartedModel> fontSizeList = new ObservableCollection<GettingStartedModel>();

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
        string filePath = @"Data\Ribbon\temp.rtf";

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
        /// Maintains the command for closing backstage from Help tabn.
        /// </summary>
        private ICommand helpTabCloseBackstageCommand;

        /// <summary>
        /// Maintains the command for inRecentTabCloseBackStage.
        /// </summary>
        private ICommand recentTabCloseBackStageCommand;

        /// <summary>
        /// Maintains the command for inInfoBackStage.
        /// </summary>
        private ICommand infoBackStageCloseCommand;

        /// <summary>
        /// Indicates whether the backstage can be closed or not in InfoTab <see cref="BackstageViewModel"/> class.
        /// </summary>
        public bool CancelBackStageClosingInInfoTab { get; set; }

        /// <summary>
        /// Indicates whether the backstage can be shown or not in HomeTab <see cref="BackstageViewModel"/> class.
        /// </summary>
        public bool CancelBackStageOpeningInHomeTab  { get; set; }

        /// <summary>
        /// Indicates whether the backstage can be shown or not in InsertTab <see cref="BackstageViewModel"/> class.
        /// </summary>
        public bool CancelBackStageOpeningInInsertTab { get; set; }

        /// <summary>
        /// Indicates whether the backstage can be shown or not in HelpTab <see cref="BackstageViewModel"/> class.
        /// </summary>
        public bool CancelBackStageClosingInHelpTab { get; set; }

        /// <summary>
        /// Indicates whether the backstage can be shown or not in RecentTab <see cref="BackstageViewModel"/> class.
        /// </summary>
        public bool CancelBackStageClosingInRecentTab { get; set; }

        /// <summary>
        /// Gets or sets the command for document content <see cref="BackstageViewModel"/> class.
        /// </summary>
        public string FileContent { get; set; }

        /// <summary>
        /// Gets or sets the command for exit backstage command button <see cref="BackstageViewModel"/> class.
        /// </summary>      
        public ICommand ExitCommand
        {
            get
            {
                return exitCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for saveas backstage command button <see cref="BackstageViewModel"/> class.
        /// </summary>
        public ICommand SaveAsCommand
        {
            get
            {
                return saveAsCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for open backstage command button <see cref="BackstageViewModel"/> class.
        /// </summary>
        public ICommand OpenCommand
        {
            get
            {
                return openCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for close backstage command button <see cref="BackstageViewModel"/> class.
        /// </summary>
        public ICommand CloseCommand
        {
            get
            {
                return closeCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command to open backstage in home tab button <see cref="BackstageViewModel"/> class.
        /// </summary>
        public ICommand HomeTabOpenBackstageCommand
        {
            get
            {
                return homeTabOpenBackstageCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command to open backstage in insert tab button <see cref="BackstageViewModel"/> class.
        /// </summary>
        public ICommand InsertTabOpenBackstageCommand
        {
            get
            {
                return insertTabOpenBackstageCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command to close backstage in help backstage tab <see cref="BackstageViewModel"/> class.
        /// </summary>
        public ICommand HelpTabCloseBackstageCommand
        {
            get
            {
                return helpTabCloseBackstageCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for button in recent backstage tab <see cref="BackstageViewModel"/> class.
        /// </summary>
        public ICommand RecentTabCloseBackStageCommand
        {
            get
            {
                return recentTabCloseBackStageCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for button in info backstage tab <see cref="BackstageViewModel"/> class.
        /// </summary>
        public ICommand InfoBackStageCloseCommand
        {
            get
            {
                return infoBackStageCloseCommand;
            }
        }

        /// <summary>
        /// Gets or sets the font family for the ItemSource of RibbonComboBox Control <see cref="BackstageViewModel"/> class.
        /// </summary>
        public ObservableCollection<GettingStartedModel> FontFamilyList
        {
            get
            {
                return fontFamilyList;
            }
            set
            {
                fontFamilyList = value;
                RaisePropertyChanged("FontFamilyList");
            }
        }

        /// <summary>
        /// Gets or sets the font size for the ItemSource of the RibbonComboBox Control <see cref="BackstageViewModel"/> class.
        /// </summary>
        public ObservableCollection<GettingStartedModel> FontSizeList
        {
            get
            {
                return fontSizeList;
            }
            set
            {
                fontSizeList = value;
                RaisePropertyChanged("FontSizeList");
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BackstageViewModel"/> class.
        /// </summary>
        public BackstageViewModel()
        {          
            exitCommand = new DelegateCommand<object>(ExecuteMethod );
            saveAsCommand = new DelegateCommand<object>(SaveAsExecute );
            openCommand = new DelegateCommand<object>(OpenExecute );
            closeCommand = new DelegateCommand<object>(CloseExecute );
            homeTabOpenBackstageCommand = new DelegateCommand<object>(HomeTabOpenBackstageExecute );
            insertTabOpenBackstageCommand = new DelegateCommand<object>(InsertTabOpenBackStageExecute );
            helpTabCloseBackstageCommand = new DelegateCommand<object>(HelpTabCloseBackstage);
            recentTabCloseBackStageCommand = new DelegateCommand<object>(RecentTabCloseBackStage );
            infoBackStageCloseCommand = new DelegateCommand<object>(InfoBackStageClose );
            string readText = File.ReadAllText(filePath);
            InitializeFont_FamilySize();
            FileContent = readText;
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
            DependencyProperty.RegisterAttached("Ribbon", typeof(Ribbon), typeof(BackstageViewModel), new FrameworkPropertyMetadata(OnRibbonChanged));       

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
            DependencyProperty.RegisterAttached("DocumentContent", typeof(string), typeof(BackstageViewModel), new FrameworkPropertyMetadata
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
            Backstage backstageDemosView = parameter as Backstage;
            if(backstageDemosView!=null)
            {
                backstageDemosView.Close();
            }
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
                FileContent = File.ReadAllText(filePath);
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
            if (CancelBackStageOpeningInHomeTab == false)
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
            if (CancelBackStageOpeningInInsertTab == false)
            {
                ribbon.ShowBackStage();
            }
        }

        /// <summary>
        /// Method to execute the command for hiding backstage.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void HelpTabCloseBackstage(object parameter)
        {
            if (CancelBackStageClosingInHelpTab == false)
            {
                ribbon.HideBackStage();
            }
        }

        /// <summary>
        /// Method to execute the recent backstage button command.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void RecentTabCloseBackStage(object parameter)
        {
            if (CancelBackStageClosingInRecentTab == false)
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
            if (CancelBackStageClosingInInfoTab == false)
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
                FontFamilyList.Add(new GettingStartedModel() { FontFamily = fontFamily.ToString() });
            }
            for (int i = 0; i < sizes.Length; i++)
            {
                FontSizeList.Add(new GettingStartedModel() { FontSize = sizes[i] });
            }
        }
    }
}
