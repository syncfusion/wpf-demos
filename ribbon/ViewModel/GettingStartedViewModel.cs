#region Copyright Syncfusion Inc. 2001-2020.
// Copyright Syncfusion Inc. 2001-2020. All rights reserved.
// Use of this code is subject to the terms of our license.
// A copy of the current license can be obtained at any time by e-mailing
// licensing@syncfusion.com. Any infringement will be prosecuted under
// applicable laws. 
#endregion

using Microsoft.Win32;
using syncfusion.demoscommon.wpf;
using Syncfusion.Windows.Tools;
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
using System.Windows.Media.Imaging;

namespace syncfusion.ribbondemos.wpf
{
    /// <summary>
    /// Represents the behaviour code for Window1.xaml
    /// </summary>
    public class GettingStartedViewModel : NotificationObject
    {        
        /// <summary>
        /// Maintains the command for remove style
        /// </summary>
        private ICommand removeStyleCommand;

        /// <summary>
        /// Maintains the command for minimize ribbon
        /// </summary>
        private ICommand minimizeRibbonCommand;

        /// <summary>
        /// Maintains the command for rich textBox selection change
        /// </summary>
        private ICommand richTextBoxSelectionChangedCommand;

        /// <summary>
        /// Maintains the command for mouse left button up.
        /// </summary>
        private ICommand richTextBoxPreviewMouseLeftButtonUpCommand;

        /// <summary>
        /// Maintains the command for buttons
        /// </summary>
        private ICommand buttonCommand;

        /// <summary>
        /// Maintains the command for dropdown
        /// </summary>
        private ICommand dropdownCommand;

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
        /// Maintains the command for backStage exit click.
        /// </summary>
        private ICommand backStageExitCommand;

        /// <summary>
        /// Maintains the command for return to editor button in info backStage.
        /// </summary>
        private ICommand returnToEditorCommand;

        /// <summary>
        /// Maintains the command for onilne help button in help backStage.
        /// </summary>
        private ICommand onlineHelpCommand;

        /// <summary>
        /// Maintains the command for getting started button in help backStage.
        /// </summary>
        private ICommand gettingStartedHelpCommand;

        /// <summary>
        /// Maintains the command for 1st gallery item.
        /// </summary>
        private ICommand galleryItemOneCommand;

        /// <summary>
        /// Maintains the command for 2nd gallery item.
        /// </summary>
        private ICommand galleryItemTwoCommand;

        /// <summary>
        /// Maintains the command for 3rd gallery item.
        /// </summary>
        private ICommand galleryItemThreeCommand;

        /// <summary>
        /// Maintains the command for 4th gallery item.
        /// </summary>
        private ICommand galleryItemFourCommand;

        /// <summary>
        /// Maintains the command for 5th gallery item.
        /// </summary>
        private ICommand galleryItemFiveCommand;

        /// <summary>
        /// Maintains the command for 6th gallery item.
        /// </summary>
        private ICommand galleryItemSixCommand;

        /// <summary>
        /// Maintains the command for 7th gallery item.
        /// </summary>
        private ICommand galleryItemSevenCommand;

        /// <summary>
        /// Maintains the command for 8th gallery item.
        /// </summary>
        private ICommand galleryItemEightCommand;

        /// <summary>
        /// Maintains the command for 9th gallery item.
        /// </summary>
        private ICommand galleryItemNineCommand;

        /// <summary>
        /// Maintains the command for 10th gallery item.
        /// </summary>
        private ICommand galleryItemTenCommand;

        /// <summary>
        /// Maintains the command for 11th gallery item.
        /// </summary>
        private ICommand galleryItemElevenCommand;

        /// <summary>
        /// Maintains the command for 12th gallery item.
        /// </summary>
        private ICommand galleryItemTwelveCommand;

        /// <summary>
        /// Maintains the command for 13th gallery item.
        /// </summary>
        private ICommand galleryItemThirteenCommand;

        /// <summary>
        /// Maintains the bold is selected or not
        /// </summary>
        private bool isFormatBoldSelected;

        /// <summary>
        /// Maintains the italic is selected or not
        /// </summary>
        private bool isFormatItalicSelected;

        /// <summary>
        /// Maintains the underline is selected or not
        /// </summary>
        private bool isFormatUnderLineSelected;

        /// <summary>
        /// Maintains the collection of font family.
        /// </summary>
        private ObservableCollection<GettingStartedModel> fontFamilyList = new ObservableCollection<GettingStartedModel>();

        /// <summary>
        /// Maintains the collection of font size.
        /// </summary>
        private ObservableCollection<GettingStartedModel> fontSizeList = new ObservableCollection<GettingStartedModel>();

        /// <summary>
        /// Maintains the ribbon properties.
        /// </summary>
        private static Ribbon ribbon = null;

        /// <summary>
        /// Maintains the richTextBox properties.
        /// </summary>
        private static RichTextBox richTextBox = null;

        /// <summary>
        /// Maintains the mini tool bar.
        /// </summary>
        private MiniToolbar toolBar;

        /// <summary>
        /// Initializes a new instance of the <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public GettingStartedViewModel()
        {
            CommonResourceDictionary = new ResourceDictionary() { Source = new Uri("/syncfusion.ribbondemos.wpf;component/Assets/Ribbon/PathIcon.xaml", UriKind.RelativeOrAbsolute) };
            CreateMiniToolBar();
            removeStyleCommand = new DelegateCommand<object>(ExecuteRemoveStyleCommand); 
            minimizeRibbonCommand = new DelegateCommand<object>(ExecuteMinimizeRibbonCommand);
            galleryItemOneCommand = new DelegateCommand<object>(ExecuteGalleryItemOneCommand);
            galleryItemTwoCommand = new DelegateCommand<object>(ExecuteGalleryItemTwoCommand);
            galleryItemThreeCommand = new DelegateCommand<object>(ExecuteGalleryItemThreeCommand);
            galleryItemFourCommand = new DelegateCommand<object>(ExecuteGalleryItemFourCommand);
            galleryItemFiveCommand = new DelegateCommand<object>(ExecuteGalleryItemFiveCommand);
            galleryItemSixCommand = new DelegateCommand<object>(ExecuteGalleryItemSixCommand);
            galleryItemSevenCommand = new DelegateCommand<object>(ExecuteGalleryItemSevenCommand);
            galleryItemEightCommand = new DelegateCommand<object>(ExecuteGalleryItemEightCommand);
            galleryItemNineCommand = new DelegateCommand<object>(ExecuteGalleryItemNineCommand);
            galleryItemTenCommand = new DelegateCommand<object>(ExecuteGalleryItemTenCommand);
            galleryItemElevenCommand = new DelegateCommand<object>(ExecuteGalleryItemElevenCommand);
            galleryItemTwelveCommand = new DelegateCommand<object>(ExecuteGalleryItemTwelveCommand);
            galleryItemThirteenCommand = new DelegateCommand<object>(ExecuteGalleryItemThirteenCommand);
            saveAsCommand = new DelegateCommand<object>(ExecuteSaveAsCommand);
            openCommand = new DelegateCommand<object>(ExecuteOpenCommand);
            closeCommand = new DelegateCommand<object>(ExecuteCloseCommand);
            buttonCommand = new DelegateCommand<object>(ButtonCommandExecute);
            dropdownCommand = new DelegateCommand<object>(DropDownCommandExecute);
            backStageExitCommand = new DelegateCommand<object>(ExecuteBackStageExitCommand);
            onlineHelpCommand = new DelegateCommand<object>(ExecuteOnlineHelpCommand);
            gettingStartedHelpCommand = new DelegateCommand<object>(ExecuteGettingStartedCommand);
            returnToEditorCommand = new DelegateCommand<object>(ExecuteReturnToEditorCommand);
            toolBar.PlacementTarget = richTextBox;
            richTextBoxPreviewMouseLeftButtonUpCommand = new DelegateCommand<object>(ExecuteRichTextBoxPreviewMouseLeftButtonUpCommand);
            richTextBoxSelectionChangedCommand = new DelegateCommand<object>(ExecuteRichTextBoxSelectionChangedCommand);
            TitleText = "WPF Ribbon";
            FirstParagraphText = "Ribbon illustrates the implementation of Office UI with Ribbon items and Backstage. Our product exposes most features of the new UI while conforming to the WPF architecture. Configuring and designing the layout is very easy when using XAML code. RibbonWindow has been implemented for giving a themed Office 2016 UI look and feel to the traditional window. Users can experience full-keyboard navigation. Key Tips are provided for faster access of items within the Ribbon. Enhanced tooltips help users use and understand the application very easily.";
            SecondTitleText = "Interactive  Features";
            PointOne = "Ribbon Window that overrides the default window and displays Office style windows.";
            PointTwo = "RibbonTab is available to add different tabs like in Microsoft Outlook.";
            PointThree = "Ribbon Bar structures the layouts.";
            PointFour = "Ribbon Bar Modes - LargeButton mode and SmallButton mode.";
            PointFive = "Ribbon has a custom implementation of button control as RibbonButton.";
            PointSix= "Can minimize/maximize the ribbon.";
            PointSeven = "Keyboard navigation simplified through Key Tip (super accelerator support).";
            PointEight = "Quick Access Toolbar (QAT) provides access to commonly used items.";
            PointNine = "RibbonStatusBar provides placing of StatusBar items.";
        }

        /// <summary>
        /// Indicates whether the format is bold or not <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public bool IsFormatBoldSelected
        {
            get
            {
                return isFormatBoldSelected;
            }
            set
            {
                isFormatBoldSelected = value;
                RaisePropertyChanged("IsFormatBoldSelected");
            }
        }

        /// <summary>
        /// Indicates whether the format is italic or not <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public bool IsFormatItalicSelected
        {
            get
            {
                return isFormatItalicSelected;
            }
            set
            {
                isFormatItalicSelected = value;
                RaisePropertyChanged("IsFormatItalicSelected");
            }
        }

        /// <summary>
        /// Indicates whether the format is underline or not <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public bool IsFormatUnderLineSelected
        {
            get
            {
                return isFormatUnderLineSelected;
            }
            set
            {
                isFormatUnderLineSelected = value;
                RaisePropertyChanged("IsFormatUnderLineSelected");
            }
        }

        /// <summary>
        /// Maintains the ribbon gallery selected item.
        /// </summary>
        public string RibbonGallerySelectedItem { get; set; }

        /// <summary>
        /// Maintains the title text
        /// </summary>
        public string TitleText { get; set; }

        /// <summary>
        /// Maintains the first paragraph
        /// </summary>
        public string FirstParagraphText { get; set; }

        /// <summary>
        /// Maintains the second title.
        /// </summary>
        public string SecondTitleText { get; set; }

        /// <summary>
        /// Maintains the point one.
        /// </summary>
        public string PointOne { get; set; }

        /// <summary>
        /// Maintains the point two.
        /// </summary>
        public string PointTwo { get; set; }

        /// <summary>
        /// Maintains the point three.
        /// </summary>
        public string PointThree { get; set; }

        /// <summary>
        /// Maintains the point four.
        /// </summary>
        public string PointFour { get; set; }

        /// <summary>
        /// Maintains the point five.
        /// </summary>
        public string PointFive { get; set; }

        /// <summary>
        /// Maintains the point six.
        /// </summary>
        public string PointSix { get; set; }

        /// <summary>
        /// Maintains the point seven.
        /// </summary>
        public string PointSeven { get; set; }

        /// <summary>
        /// Maintains the point eight.
        /// </summary>
        public string PointEight { get; set; }

        /// <summary>
        /// Maintains the point nine.
        /// </summary>
        public string PointNine { get; set; }

        /// <summary>
        /// Holds the required resouces for IconTemplate.
        /// </summary>
        private ResourceDictionary CommonResourceDictionary { get; set; }

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
            DependencyProperty.RegisterAttached("Ribbon", typeof(Ribbon), typeof(GettingStartedViewModel), new FrameworkPropertyMetadata(OnRibbonChanged));

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
            DependencyProperty.RegisterAttached("RichTextBox", typeof(string), typeof(GettingStartedViewModel), new FrameworkPropertyMetadata(OnRichTextBoxChanged));

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
        /// Gets or sets the command for 1st gallery item  <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand GalleryItemOneCommand
        {
            get
            {
                return galleryItemOneCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for 2nd gallery item <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand GalleryItemTwoCommand
        {
            get
            {
                return galleryItemTwoCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for 3rd gallery item <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand GalleryItemThreeCommand
        {
            get
            {
                return galleryItemThreeCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for 4th gallery item <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand GalleryItemFourCommand
        {
            get
            {
                return galleryItemFourCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for 5th gallery item <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand GalleryItemFiveCommand
        {
            get
            {
                return galleryItemFiveCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for 6th gallery item <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand GalleryItemSixCommand
        {
            get
            {
                return galleryItemSixCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for 7th gallery item <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand GalleryItemSevenCommand
        {
            get
            {
                return galleryItemSevenCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for 8th gallery item <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand GalleryItemEightCommand
        {
            get
            {
                return galleryItemEightCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for 9th gallery item <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand GalleryItemNineCommand
        {
            get
            {
                return galleryItemNineCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for 10th gallery item <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand GalleryItemTenCommand
        {
            get
            {
                return galleryItemTenCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for 11th gallery item <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand GalleryItemElevenCommand
        {
            get
            {
                return galleryItemElevenCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for 12th gallery item <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand GalleryItemTwelveCommand
        {
            get
            {
                return galleryItemTwelveCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for 13th gallery item <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand GalleryItemThirteenCommand
        {
            get
            {
                return galleryItemThirteenCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for richTextBox PreviewMouseLeftButtonUp <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand RichTextBoxPreviewMouseLeftButtonUpCommand
        {
            get
            {
                return richTextBoxPreviewMouseLeftButtonUpCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for richText box selection changed <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand RichTextBoxSelectionChangedCommand
        {
            get
            {
                return richTextBoxSelectionChangedCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for remove button <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand RemoveStyleCommand
        {
            get
            {
                return removeStyleCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for minimize ribbon button <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand MinimizeRibbonCommand
        {
            get
            {
                return minimizeRibbonCommand;
            }
        }

        /// <summary>
        /// Gets or sets the command for button <see cref="GettingStartedViewModel"/> class.
        /// </summary>      
        public ICommand ButtonCommand { get { return buttonCommand; } }

        /// <summary>
        /// Gets or sets the command for dropdown <see cref="GettingStartedViewModel"/> class.
        /// </summary>      
        public ICommand DropDownCommand { get { return dropdownCommand; } }

        /// <summary>
        /// Gets or sets the command for saveas backstage command button <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand SaveAsCommand { get { return saveAsCommand; } }

        /// <summary>
        /// Gets or sets the command for open backstage command button <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand OpenCommand { get { return openCommand; } }

        /// <summary>
        /// Gets or sets the command for close backstage command button <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand CloseCommand { get { return closeCommand; } }

        /// <summary>
        /// Gets or sets the command for backStage exit button <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand BackStageExitCommand { get { return backStageExitCommand; } }

        /// <summary>
        /// Gets or sets the command for return to editor button in info backstage <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand ReturnToEditorCommand { get { return returnToEditorCommand; } }

        /// <summary>
        /// Gets or sets the command for online help button in help backstage <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand OnlineHelpCommand { get { return onlineHelpCommand; } }

        /// <summary>
        /// Gets or sets the command for online getting started button in help backstage <see cref="GettingStartedViewModel"/> class.
        /// </summary>
        public ICommand GettingStartedHelpCommand { get { return gettingStartedHelpCommand; } }

        /// <summary>
        /// Gets or sets the font.family for the ItemSource of RibbonComboBox Control <see cref="GettingStartedViewModel"/> class.
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
        /// Gets or sets the font.size for the ItemSource of the RibbonComboBox Control <see cref="GettingStartedViewModel"/> class.
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
        /// Coerces the boolean value.
        /// </summary>
        /// <param name="value">Specifies the value.</param>
        /// <param name="trueValue">Specifies the true value.</param>
        /// <returns></returns>
        private bool? CoerceBooleanValue(object value, object trueValue)
        {
            if (value == null)
                return null;
            else if (value.Equals(trueValue))
                return true;
            else if (value == DependencyProperty.UnsetValue)
                return null;
            else
                return false;
        }

        /// <summary>
        /// Gets or sets the selection bold.
        /// </summary>
        /// <value>The selection bold.</value>
        public bool? SelectionBold
        {
            get
            {
                return this.CoerceBooleanValue(richTextBox.Selection.GetPropertyValue(TextElement.FontWeightProperty),
                    FontWeights.Bold);
            }
            set
            {
                richTextBox.Selection.ApplyPropertyValue(TextElement.FontWeightProperty,
                    (value != false ? FontWeights.Bold : FontWeights.Normal));
                RaisePropertyChanged("SelectionBold");
            }
        }

        /// <summary>
        /// Gets or sets the selection italic.
        /// </summary>
        /// <value>The selection italic.</value>
        public bool? SelectionItalic
        {
            get
            {
                return this.CoerceBooleanValue(richTextBox.Selection.GetPropertyValue(TextElement.FontStyleProperty),
                    FontStyles.Italic);
            }
            set
            {
                richTextBox.Selection.ApplyPropertyValue(TextElement.FontStyleProperty,
                    (value != false ? FontStyles.Italic : FontStyles.Normal));
                RaisePropertyChanged("SelectionItalic");
            }
        }

        /// <summary>
        /// Gets or sets the selection subscript.
        /// </summary>
        /// <value>The selection subscript.</value>
        public bool? SelectionSubscript
        {
            get
            {
                return this.CoerceBooleanValue(richTextBox.Selection.GetPropertyValue(Typography.VariantsProperty),
                    FontVariants.Subscript);
            }
            set
            {
                richTextBox.Selection.ApplyPropertyValue(Typography.VariantsProperty,
                    (value != false ? FontVariants.Subscript : FontVariants.Normal));
                RaisePropertyChanged("SelectionSubscript");
            }
        }

        /// <summary>
        /// Gets or sets the selection superscript.
        /// </summary>
        /// <value>The selection superscript.</value>
        public bool? SelectionSuperscript
        {
            get
            {
                return this.CoerceBooleanValue(richTextBox.Selection.GetPropertyValue(Typography.VariantsProperty),
                    FontVariants.Superscript);
            }
            set
            {
                richTextBox.Selection.ApplyPropertyValue(Typography.VariantsProperty,
                    (value != false ? FontVariants.Superscript : FontVariants.Normal));
                RaisePropertyChanged("SelectionSuperscript");
            }
        }

        /// <summary>
        /// Gets or sets the selection underline.
        /// </summary>
        /// <value>The selection underline.</value>
        public bool? SelectionUnderline
        {
            get
            {
                return this.CoerceBooleanValue(richTextBox.Selection.GetPropertyValue(TextBlock.TextDecorationsProperty),
                    TextDecorations.Underline);
            }
            set
            {
                richTextBox.Selection.ApplyPropertyValue(TextBlock.TextDecorationsProperty,
                    (value != false ? TextDecorations.Underline : null));
                RaisePropertyChanged("SelectionUnderline");
            }
        }

        /// <summary>
        /// Gets or sets the selection strikethrough.
        /// </summary>
        /// <value>The selection strikethrough.</value>
        public bool? SelectionStrikethrough
        {
            get
            {
                return this.CoerceBooleanValue(richTextBox.Selection.GetPropertyValue(TextBlock.TextDecorationsProperty),
                    TextDecorations.Strikethrough);
            }
            set
            {
                richTextBox.Selection.ApplyPropertyValue(TextBlock.TextDecorationsProperty,
                    (value != false ? TextDecorations.Strikethrough : null));
                RaisePropertyChanged("SelectionStrikethrough");
            }
        }

        /// <summary>
        /// Gets or sets the selection font family.
        /// </summary>
        /// <value>The selection font family.</value>
        public FontFamily SelectionFontFamily
        {
            get
            {
                object value = richTextBox.Selection.GetPropertyValue(TextElement.FontFamilyProperty);
                if (value == DependencyProperty.UnsetValue)
                    return null;
                else
                    return (FontFamily)value;
            }
            set
            {
                if (value != null)
                {
                    richTextBox.Selection.ApplyPropertyValue(TextElement.FontFamilyProperty, value);
                    RaisePropertyChanged("SelectionFontFamily");
                }
            }
        }

        /// <summary>
        /// Gets or sets the size of the selection font.
        /// </summary>
        /// <value>The size of the selection font.</value>
        public double SelectionFontSize
        {
            get
            {
                object value = richTextBox.Selection.GetPropertyValue(TextElement.FontSizeProperty);
                if (value == DependencyProperty.UnsetValue)
                    return double.NaN;
                else
                    return (double)value;
            }
            set
            {
                if (!value.Equals(double.NaN))
                {
                    richTextBox.Selection.ApplyPropertyValue(TextElement.FontSizeProperty, value);
                    RaisePropertyChanged("SelectionFontSize");
                }
            }
        }

        /// <summary>
        /// Gets or sets the selection foreground.
        /// </summary>
        /// <value>The selection foreground.</value>
        public Brush SelectionForeground
        {
            get
            {
                object value = richTextBox.Selection.GetPropertyValue(TextElement.ForegroundProperty);
                if (value == DependencyProperty.UnsetValue)
                    return null;
                else
                    return (Brush)value;
            }
            set
            {
                richTextBox.Selection.ApplyPropertyValue(TextElement.ForegroundProperty,
                    (value != null ? value : Brushes.Black));
                RaisePropertyChanged("SelectionForeground");
            }
        }

        /// <summary>
        /// Method used to execute the clear formatting command.
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteClearFormattingCommand(object parameter)
        {
            SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            SelectionFontSize = 14;         
        }

        /// <summary>
        /// Removes the item from the Style Gallery
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteRemoveStyleCommand(object parameter)
        {
            RibbonGallery gallery = ribbon.FindName("gallery") as RibbonGallery;
            RibbonGalleryItem galleryItemOne = ribbon.FindName("firstItem") as RibbonGalleryItem;
            RibbonGalleryItem galleryItemTwo = ribbon.FindName("secondItem") as RibbonGalleryItem;
            RibbonGalleryItem galleryItemThree = ribbon.FindName("thirdItem") as RibbonGalleryItem;
            RibbonGalleryItem galleryItemFour = ribbon.FindName("fourthItem") as RibbonGalleryItem;
            RibbonGalleryItem galleryItemFive = ribbon.FindName("fifthItem") as RibbonGalleryItem;
            RibbonGalleryItem galleryItemSix = ribbon.FindName("sixthItem") as RibbonGalleryItem;
            RibbonGalleryItem galleryItemSeven = ribbon.FindName("seventhItem") as RibbonGalleryItem;
            RibbonGalleryItem galleryItemEight = ribbon.FindName("eighthItem") as RibbonGalleryItem;
            RibbonGalleryItem galleryItemNine = ribbon.FindName("ninthItem") as RibbonGalleryItem;
            RibbonGalleryItem galleryItemTen = ribbon.FindName("tenthItem") as RibbonGalleryItem;
            RibbonGalleryItem galleryItemEleven = ribbon.FindName("eleventhItem") as RibbonGalleryItem;
            RibbonGalleryItem galleryItemItalic = ribbon.FindName("italicItem") as RibbonGalleryItem;
            RibbonGalleryItem galleryItemString = ribbon.FindName("superString") as RibbonGalleryItem;

            if (galleryItemOne.IsChecked)
            {
                gallery.Items.Remove(galleryItemOne);
            }
            if (galleryItemTwo.IsChecked)
            {
                gallery.Items.Remove(galleryItemTwo);
            }
            if (galleryItemThree.IsChecked)
            {
                gallery.Items.Remove(galleryItemThree);
            }
            if (galleryItemFour.IsChecked)
            {
                gallery.Items.Remove(galleryItemFour);
            }
            if (galleryItemFive.IsChecked)
            {
                gallery.Items.Remove(galleryItemFive);
            }
            if (galleryItemSix.IsChecked)
            {
                gallery.Items.Remove(galleryItemSix);
            }
            if (galleryItemSeven.IsChecked)
            {
                gallery.Items.Remove(galleryItemSeven);
            }
            if (galleryItemEight.IsChecked)
            {
                gallery.Items.Remove(galleryItemEight);
            }
            if (galleryItemNine.IsChecked)
            {
                gallery.Items.Remove(galleryItemNine);
            }
            if (galleryItemTen.IsChecked)
            {
                gallery.Items.Remove(galleryItemTen);
            }
            if (galleryItemEleven.IsChecked)
            {
                gallery.Items.Remove(galleryItemEleven);
            }
            if (galleryItemItalic.IsChecked)
            {
                gallery.Items.Remove(galleryItemItalic);
            }
            if (galleryItemString.IsChecked)
            {
                gallery.Items.Remove(galleryItemString);
            }        
        }

        /// <summary>
        /// Minimizes the ribbon when MinimizeRibbon is selected
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteMinimizeRibbonCommand(object parameter)
        {
            ribbon.RibbonState = RibbonState.Hide;
        }

        /// <summary>
        /// Creates the mini tool bar.
        /// </summary>
        private void CreateMiniToolBar()
        {
            toolBar = new MiniToolbar();
            RibbonComboBox fontFamilyComboBox = new RibbonComboBox();
            RibbonComboBox fontSizeComboBox = new RibbonComboBox();
            int[] sizes = new int[15] { 8, 9, 10, 11, 12, 14, 16, 18, 20, 22, 24, 28, 36, 48, 72 };
            foreach (FontFamily fontFamily in Fonts.SystemFontFamilies)
            {
                FontFamilyList.Add(new GettingStartedModel() { FontFamily = fontFamily.ToString() });
                RibbonComboBoxItem fontFamilyComboBoxItem = new RibbonComboBoxItem();
                fontFamilyComboBoxItem.Content = fontFamily;
                fontFamilyComboBox.Items.Add(fontFamilyComboBoxItem);
                fontFamilyComboBoxItem.PreviewMouseMove += RibbonComboBoxItem1_PreviewMouseMove;
            }
            for (int i = 0; i < sizes.Length; i++)
            {
                FontSizeList.Add(new GettingStartedModel() { FontSize = sizes[i] });
                RibbonComboBoxItem fontSizeComboBoxItem = new RibbonComboBoxItem();
                fontSizeComboBoxItem.Content = sizes[i];
                fontSizeComboBox.Items.Add(fontSizeComboBoxItem);
                fontSizeComboBoxItem.PreviewMouseMove += RibbonComboBoxItem2_PreviewMouseMove;
            }
            fontFamilyComboBox.Width = 100;
            fontFamilyComboBox.IsEditable = true;
            fontSizeComboBox.Width = 40;
            fontSizeComboBox.IsEditable = true;

            RibbonButton increaseFontButton = new RibbonButton();
            RibbonButton decreaseFontButton = new RibbonButton();
            RibbonButton toggleBoldButton = new RibbonButton();
            RibbonButton toggleItalicButton = new RibbonButton();
            RibbonButton toggleUnderlineButton = new RibbonButton();
            RibbonButton strikeButton = new RibbonButton();
            RibbonButton toggleSubScriptButton = new RibbonButton();
            RibbonButton toggleSuperScriptButton = new RibbonButton();
            RibbonButton fontColorButton = new RibbonButton();
            RibbonButton textHighlightButton = new RibbonButton();

            increaseFontButton.CommandBindings.Add(new CommandBinding(EditingCommands.IncreaseFontSize));
            decreaseFontButton.CommandBindings.Add(new CommandBinding(EditingCommands.DecreaseFontSize));
            toggleBoldButton.CommandBindings.Add(new CommandBinding(EditingCommands.ToggleBold));
            toggleItalicButton.CommandBindings.Add(new CommandBinding(EditingCommands.ToggleItalic));
            toggleUnderlineButton.CommandBindings.Add(new CommandBinding(EditingCommands.ToggleUnderline));
            toggleSubScriptButton.CommandBindings.Add(new CommandBinding(EditingCommands.ToggleSubscript));
            toggleSuperScriptButton.CommandBindings.Add(new CommandBinding(EditingCommands.ToggleSuperscript));

            increaseFontButton.Click += new RoutedEventHandler(OnIncreaseFontThrough);
            decreaseFontButton.Click += new RoutedEventHandler(OnDecreaseFontThrough);
            strikeButton.Click += new RoutedEventHandler(OnStrikeThrough);
            toggleBoldButton.Click += new RoutedEventHandler(OnBoldThrough);
            toggleItalicButton.Click += new RoutedEventHandler(OnItalicThrough);
            toggleUnderlineButton.Click += new RoutedEventHandler(OnUnderlineThrough);
            toggleSubScriptButton.Click += new RoutedEventHandler(OnSubScriptThrough);
            toggleSuperScriptButton.Click += new RoutedEventHandler(OnSuperScriptThrough);

            increaseFontButton.IconTemplate = CommonResourceDictionary["IncreaseFontSize"] as DataTemplate;
            decreaseFontButton.IconTemplate = CommonResourceDictionary["DecreaseFontSize"] as DataTemplate;
            toggleBoldButton.IconTemplate = CommonResourceDictionary["Bold"] as DataTemplate;
            toggleItalicButton.IconTemplate = CommonResourceDictionary["Italics"] as DataTemplate;
            toggleUnderlineButton.IconTemplate = CommonResourceDictionary["Underline"] as DataTemplate;
            toggleSubScriptButton.IconTemplate = CommonResourceDictionary["Bullets"] as DataTemplate;
            toggleSuperScriptButton.IconTemplate = CommonResourceDictionary["Numbering"] as DataTemplate;
            strikeButton.IconTemplate = CommonResourceDictionary["ClearFormatting"] as DataTemplate;
            fontColorButton.IconTemplate = CommonResourceDictionary["FontColor"] as DataTemplate;
            textHighlightButton.IconTemplate = CommonResourceDictionary["TextHighlight"] as DataTemplate;

            increaseFontButton.SizeForm = SizeForm.ExtraSmall;
            decreaseFontButton.SizeForm = SizeForm.ExtraSmall;
            toggleBoldButton.SizeForm = SizeForm.ExtraSmall;
            toggleItalicButton.SizeForm = SizeForm.ExtraSmall;
            toggleUnderlineButton.SizeForm = SizeForm.ExtraSmall;
            strikeButton.SizeForm = SizeForm.ExtraSmall;
            toggleSubScriptButton.SizeForm = SizeForm.ExtraSmall;
            toggleSuperScriptButton.SizeForm = SizeForm.ExtraSmall;
            fontColorButton.SizeForm = SizeForm.ExtraSmall;
            textHighlightButton.SizeForm = SizeForm.ExtraSmall;

            toolBar.Items.Add(fontFamilyComboBox);
            toolBar.Items.Add(fontSizeComboBox);
            toolBar.Items.Add(increaseFontButton);
            toolBar.Items.Add(decreaseFontButton);
            toolBar.Items.Add(toggleBoldButton);
            toolBar.Items.Add(toggleItalicButton);
            toolBar.Items.Add(toggleUnderlineButton);
            toolBar.Items.Add(strikeButton);
            toolBar.Items.Add(toggleSubScriptButton);
            toolBar.Items.Add(toggleSuperScriptButton);
            toolBar.Items.Add(fontColorButton);
            toolBar.Items.Add(textHighlightButton);
        }

        /// <summary>
        /// Method used to change the font family.
        /// </summary>
        /// <param name="sender">Specifies the object type.</param>
        /// <param name="e">Specifies the mouse event argument.</param>
        private void RibbonComboBoxItem1_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            RibbonComboBoxItem item = sender as RibbonComboBoxItem;
            if (item != null)
            {
                SelectionFontFamily = item.Content as FontFamily;
            }
        }

        /// <summary>
        /// Method used to change the font size
        /// </summary>
        /// <param name="sender">Specifies the object type.</param>
        /// <param name="e">Specifies the mouse event argument.</param>
        private void RibbonComboBoxItem2_PreviewMouseMove(object sender, MouseEventArgs e)
        {
            RibbonComboBoxItem item = sender as RibbonComboBoxItem;
            if (item != null)
            {
                SelectionFontSize = (int)item.Content;
            }
        }

        /// <summary>
        /// Called when [strike through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnStrikeThrough(object sender, EventArgs e)
        {
            SelectionStrikethrough = !SelectionStrikethrough;
        }

        /// <summary>
        /// Called when [bold through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnBoldThrough(object sender, EventArgs e)
        {
            SelectionBold = !SelectionBold;
            ResetCurrentEditorStyles();
        }

        /// <summary>
        /// Called when [italic through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnItalicThrough(object sender, EventArgs e)
        {
            SelectionItalic = !SelectionItalic;
            ResetCurrentEditorStyles();
        }

        /// <summary>
        /// Called when [underline through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnUnderlineThrough(object sender, EventArgs e)
        {
            SelectionUnderline = !SelectionUnderline;
            ResetCurrentEditorStyles();
        }

        /// <summary>
        /// Called when [increase font through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnIncreaseFontThrough(object sender, EventArgs e)
        {
            SelectionFontSize = SelectionFontSize + 1;
        }

        /// <summary>
        /// Called when [decrease font through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnDecreaseFontThrough(object sender, EventArgs e)
        {
            if (SelectionFontSize > 1)
                SelectionFontSize = SelectionFontSize - 1;
        }

        /// <summary>
        /// Called when [sub script through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnSubScriptThrough(object sender, EventArgs e)
        {
            SelectionSubscript = !SelectionSubscript;
        }

        /// <summary>
        /// Called when [super script through].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnSuperScriptThrough(object sender, EventArgs e)
        {
            SelectionSuperscript = !SelectionSuperscript;
        }

        /// <summary>
        /// Resets the current editor styles.
        /// </summary>
        private void ResetCurrentEditorStyles()
        {
            if (SelectionBold.HasValue)
            {
                IsFormatBoldSelected = SelectionBold.Value;
            }
            if (SelectionItalic.HasValue)
            {
                IsFormatItalicSelected = SelectionItalic.Value;
            }
            if (SelectionUnderline.HasValue)
            {
                IsFormatUnderLineSelected = SelectionUnderline.Value;
            }
            RibbonComboBox toolbarfont = (RibbonComboBox)toolBar.Items[0];
            RibbonComboBox toolbarfontsize = (RibbonComboBox)toolBar.Items[1];
            RibbonButton boldBtn = (RibbonButton)toolBar.Items[4];
            RibbonButton italicBtn = (RibbonButton)toolBar.Items[5];
            RibbonButton underlineBtn = (RibbonButton)toolBar.Items[6];
            RibbonButton strikeBtn = (RibbonButton)toolBar.Items[7];
            if (SelectionFontFamily != null)
                toolbarfont.Text = SelectionFontFamily.Source;
            if (!double.IsNaN(SelectionFontSize))
                toolbarfontsize.Text = SelectionFontSize.ToString();
            if (SelectionStrikethrough.HasValue)
                strikeBtn.IsSelected = SelectionStrikethrough.Value;
            if (SelectionBold.HasValue)
                boldBtn.IsSelected = SelectionBold.Value;
            if (SelectionItalic.HasValue)
                italicBtn.IsSelected = SelectionItalic.Value;
            if (SelectionUnderline.HasValue)
                underlineBtn.IsSelected = SelectionUnderline.Value;
        }

        /// <summary>
        /// Handles the MouseUp event of the editor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Input.MouseButtonEventArgs"/> instance containing the event data.</param>
        private void ExecuteRichTextBoxPreviewMouseLeftButtonUpCommand(object sender)
        {
            if (!richTextBox.Selection.IsEmpty)
            {
                RibbonComboBox toolbarfont = (RibbonComboBox)toolBar.Items[0];
                RibbonComboBox toolbarfontsize = (RibbonComboBox)toolBar.Items[1];
                RibbonButton boldBtn = (RibbonButton)toolBar.Items[4];
                RibbonButton italicBtn = (RibbonButton)toolBar.Items[5];
                RibbonButton underlineBtn = (RibbonButton)toolBar.Items[6];
                RibbonButton strikeBtn = (RibbonButton)toolBar.Items[7];
                if (SelectionFontFamily != null)
                    toolbarfont.Text = SelectionFontFamily.Source;
                if (!double.IsNaN(SelectionFontSize))
                    toolbarfontsize.Text = SelectionFontSize.ToString();
                if (SelectionStrikethrough.HasValue)
                    strikeBtn.IsSelected = SelectionStrikethrough.Value;
                if (SelectionBold.HasValue)
                    boldBtn.IsSelected = SelectionBold.Value;
                if (SelectionItalic.HasValue)
                    italicBtn.IsSelected = SelectionItalic.Value;
                if (SelectionUnderline.HasValue)
                    underlineBtn.IsSelected = SelectionUnderline.Value;
                toolBar.Show();
            }
            else
                toolBar.Hide();
        }

        /// <summary>
        /// Handles the SelectionChanged event of the editor control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        private void ExecuteRichTextBoxSelectionChangedCommand(object sender)
        {
            TextSelection selection = richTextBox.Selection;
            bool EmptySelection = selection.IsEmpty;
            if (EmptySelection)
                toolBar.Hide();
            ResetCurrentEditorStyles();
        }

        /// <summary>
        /// Method used to execute 1st gallery item. 
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteGalleryItemOneCommand(object parameter)
        {
            if (richTextBox.Selection.Text != string.Empty)
            {
                SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                SelectionFontSize = 14;
            }          
        }

        /// <summary>
        /// Method used to execute 2nd gallery item. 
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteGalleryItemTwoCommand(object parameter)
        {
            if (richTextBox.Selection.Text != string.Empty)
            {
                SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                SelectionFontSize = 12;
            }         
        }

        /// <summary>
        /// Method used to execute 3rd gallery item. 
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteGalleryItemThreeCommand(object parameter)
        {
            if (richTextBox.Selection.Text != string.Empty)
            {
                SelectionFontSize = 18;
                SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 139));
            }          
        }

        /// <summary>
        /// Method used to execute 4th gallery item. 
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteGalleryItemFourCommand(object parameter)
        {
            if (richTextBox.Selection.Text != string.Empty)
            {
                SelectionFontSize = 16;
                SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 139));
            }          
        }

        /// <summary>
        /// Method used to execute 5th gallery item. 
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteGalleryItemFiveCommand(object parameter)
        {
            if (richTextBox.Selection.Text != string.Empty)
            {
                SelectionFontSize = 14;
                SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 139));
            }          
        }

        /// <summary>
        /// Method used to execute 6th gallery item. 
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteGalleryItemSixCommand(object parameter)
        {
            if (richTextBox.Selection.Text != string.Empty)
            {
                SelectionFontSize = 12;
                SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 139));
            }         
        }

        /// <summary>
        /// Method used to execute 7th gallery item. 
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteGalleryItemSevenCommand(object parameter)
        {
            if (richTextBox.Selection.Text != string.Empty)
            {
                SelectionFontSize = 24;
                SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }           
        }

        /// <summary>
        /// Method used to execute 8th gallery item. 
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteGalleryItemEightCommand(object parameter)
        {
            if (richTextBox.Selection.Text != string.Empty)
            {
                SelectionItalic = true;
                SelectionFontSize = 14;
                SelectionForeground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }         
        }

        /// <summary>
        /// Method used to execute 9th gallery item. 
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteGalleryItemNineCommand(object parameter)
        {
            if (richTextBox.Selection.Text != string.Empty)
            {
                SelectionForeground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }          
        }

        /// <summary>
        /// Method used to execute 10th gallery item. 
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteGalleryItemTenCommand(object parameter)
        {
            if (richTextBox.Selection.Text != string.Empty)
            {
                SelectionForeground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }         
        }

        /// <summary>
        /// Method used to execute 11th gallery item. 
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteGalleryItemElevenCommand(object parameter)
        {
            if (richTextBox.Selection.Text != string.Empty)
            {
                SelectionForeground = new SolidColorBrush(Color.FromRgb(255, 0, 0));
            }         
        }

        /// <summary>
        /// Method used to execute 12th gallery item. 
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteGalleryItemTwelveCommand(object parameter)
        {
            if (richTextBox.Selection.Text != string.Empty)
            {
                SelectionFontSize = 16;
                SelectionItalic = true;
            }          
        }

        /// <summary>
        /// Method used to execute 13th gallery item. 
        /// </summary>
        /// <param name="parameter">Specifies the object type parameter.</param>
        private void ExecuteGalleryItemThirteenCommand(object parameter)
        {
            if (richTextBox.Selection.Text != string.Empty)
            {
                SelectionFontSize = 20;
                SelectionBold = true;
            }          
        }

        /// <summary>
        /// Method to execute returnToEditorCommand.
        /// </summary>
        /// <param name="parameter">Specifies the object parameter.</param>
        public void ExecuteReturnToEditorCommand(object parameter)
        {
            ribbon.HideBackStage();
        }

        /// <summary>
        /// Method which is used to execute the saveas command.
        /// </summary>
        /// <param name="parameter">Specifies the parameter of saveas command.</param>
        private void ExecuteSaveAsCommand(object parameter)
        {
            SaveFileDialog saveFile = new SaveFileDialog();
            FileStream rtfFile = null;
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
        public void ExecuteBackStageExitCommand(object parameter)
        {
            GettingStarted gettingStartedDemosView = parameter as GettingStarted;
            if (gettingStartedDemosView != null)
            {
                gettingStartedDemosView.Close();
            }
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
        /// Method used to execute the button command.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private void ButtonCommandExecute(object parameter)
        {
            MessageBox.Show("Click operation has been performed.");
        }

        /// <summary>
        /// Method used to execute the dropdown command.
        /// </summary>
        /// <param name="parameter">Specifies the object type.</param>
        private void DropDownCommandExecute(object parameter)
        {
            MessageBox.Show("The dropdown item has been selected.");
        }
    }
}
